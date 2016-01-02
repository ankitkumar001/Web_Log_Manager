using System;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;
using System.Text;
using System.Data.OleDb;

namespace WSLA
{
	/// <summary>
	/// Summary description for WebServerLog.
	/// </summary>
	public class WebServerLog
	{
		private static readonly String []MonthNames = { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };
		private static readonly String Delimiter = "|";

		private WebServerLog()	// no need to instantiate objects of this class
		{
		}

		// Load the HTTP log into the database.

		public static void Load(String FilePath, StatusBar TheStatusBar)
		{
			Cursor.Current = Cursors.WaitCursor;
			
			TheStatusBar.Text = "Parsing web server log";

			Stream LogFileS = File.OpenRead(FilePath);

			StreamReader LogFileSR = new StreamReader(LogFileS, System.Text.Encoding.ASCII);
			LogFileSR.BaseStream.Seek(0, SeekOrigin.Begin);

			String Pattern = @"(?<IPAddr>[\S]+)(?<Discard>[\s-\[]*)(?<Day>\d{1,2})(?<Discard>/)(?<Month>[a-zA-Z]+)(?<Discard>/)(?<Year>\d{2,4})(?<Discard>:)(?<Hour>\d{1,2})(?<Discard>:)(?<Minute>\d{1,2})(?<Discard>:)(?<Second>\d{1,2})(?<Discard>[\s]*)(?<TZInt>[\+\-]*\d{2})(?<TZFrac>\d{2})(?<Discard>([\]\s])*""(GET|HEAD)([\s])*)(?<File>[\S]*)(?<Discard>[^""]*""[\s]*)(?<Status>[0-9]*)(?<Discard>[\s]*)(?<Bytes>([0-9])*)(?<Discard>[^""]*"")(?<RefURL>[^""]*)(?<Discard>[^""]*""[^""]*"")(?<UserAgent>[^""]*)";
			Regex RE = new Regex(Pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);

			// Prepare to create a temporary file used to import data into the
			// database.
			String ImportFileName = Path.GetDirectoryName(Application.ExecutablePath) + @"\data.txt";

			StreamWriter ImportFileSW = new StreamWriter(ImportFileName);

			String WordsFileName = Path.GetDirectoryName(Application.ExecutablePath) + @"\words.txt";
			StreamWriter WordsFileSW = new StreamWriter(WordsFileName);

			Regex searchRegex = new Regex(@"[\s]+""SEARCH[\s]+", RegexOptions.IgnoreCase | RegexOptions.Compiled);

			while (LogFileSR.Peek() > -1) 
			{
				String Line = LogFileSR.ReadLine().Trim();

				try
				{
					// If this entry is not a "SEARCH" entry...
					if (searchRegex.Match(Line).Length == 0)
					{
						Match M = RE.Match(Line);

						String IPAddress = M.Result("${IPAddr}");
						IPAddress = DecodeIPAddress(IPAddress);

						int Day          = Int32.Parse(M.Result("${Day}"));
						String MonthName = M.Result("${Month}");

						int Month  = GetMonth(MonthName);
						int Year   = Int32.Parse(M.Result("${Year}"));
						int Hour   = Int32.Parse(M.Result("${Hour}"));
						int Minute = Int32.Parse(M.Result("${Minute}"));
						int Second = Int32.Parse(M.Result("${Second}"));

						int   HoursFromUTInt  = Int32.Parse(M.Result("${TZInt}"));
						float HoursFromUTFrac = Int32.Parse(M.Result("${TZFrac}")) / 100.0f;

						DateTime TheDateTime = new DateTime(Year, Month, Day, Hour, Minute, Second);

						String FileName     = M.Result("${File}");
						int StatusCode      = Int32.Parse(M.Result("${Status}"));
						int Bytes           = Int32.Parse(M.Result("${Bytes}"));
						String ReferringURL = M.Result("${RefURL}");
						String UserAgent    = M.Result("${UserAgent}");

						String TopLevelDomain = GetTopLevelDomain(IPAddress);
						String HoursFromUT    = HoursFromUTInt + "." + HoursFromUTFrac;

						// Add an entry to the temporary file in the format
						// specified by schema.ini.
						String TextLine = IPAddress      + Delimiter +
							TopLevelDomain + Delimiter +
							TheDateTime    + Delimiter +
							HoursFromUT    + Delimiter +
							FileName       + Delimiter +
							StatusCode     + Delimiter +
							Bytes          + Delimiter +
							ReferringURL   + Delimiter +
							UserAgent;

						ImportFileSW.WriteLine(TextLine);

						ExtractWords(ReferringURL, WordsFileSW, TheDateTime);
					}
				}
				catch(Exception)
				{
				}
			}
         
			ImportFileSW.Close();
			LogFileSR.Close();
			LogFileS.Close();

			WordsFileSW.Close();

			TheStatusBar.Text = "Loading database";

			ImportData();
			ImportSearchWords();

			Cursor.Current = Cursors.Arrow;
		}

		// Import the data in the temporary file into the database.

		private static void ImportData()
		{
			// Remove all records from HTTPInfo table in database.
			OleDbCommand Command = new OleDbCommand("DELETE * FROM HTTPInfo", Globals.m_Database.Connection);
			int RowsAffected = Command.ExecuteNonQuery();

			// Import the new data into the database.
			String QueryStr = "INSERT INTO HTTPInfo SELECT * FROM [data.txt] IN \"" + Path.GetDirectoryName(Application.ExecutablePath) + "\" \"TEXT;\";";

			Command = new OleDbCommand(QueryStr, Globals.m_Database.Connection);
			RowsAffected = Command.ExecuteNonQuery();
		}

		private static void ImportSearchWords()
		{
			// Remove all records from HTTPInfo table in database.
			OleDbCommand Command = new OleDbCommand("DELETE * FROM SearchWords", Globals.m_Database.Connection);
			int RowsAffected = Command.ExecuteNonQuery();

			// Import the new data into the database.
			String QueryStr = "INSERT INTO SearchWords SELECT * FROM [words.txt] IN \"" + Path.GetDirectoryName(Application.ExecutablePath) + "\" \"TEXT;\";";

			Command = new OleDbCommand(QueryStr, Globals.m_Database.Connection);
			RowsAffected = Command.ExecuteNonQuery();
		}

		// Return the month number corresponding to the month name.  For
		// example, return 1 for "JAN".

		private static int GetMonth(String MonthName)
		{
			int Month = 0;

			for (int i = 0; Month == 0 && i < MonthNames.Length; i++)
			{
				if (String.Compare(MonthName, MonthNames[i], true) == 0)
				{
					Month = i + 1;
				}
			}

			return Month;
		}

		// Extract the top level domain from the IPAddress.  For example, given
		// an IP Address of xyz.company.com, the top level domain is "COM".

		private static String GetTopLevelDomain(String IPAddress)
		{
			String TopLevelDomain = "";

			int Pos = IPAddress.LastIndexOf(".");

			if (Pos != -1)
			{
				TopLevelDomain = IPAddress.Substring(Pos + 1).ToUpper();
			}

			// Clear TopLevelDomain if it's all digits.
			if (TopLevelDomain.Length > 0)
			{
				bool Numeric = true;

				try
				{
					Int32.Parse(TopLevelDomain);
				}
				catch (FormatException)
				{
					Numeric = false;
				}
				finally
				{
					if (Numeric)
					{
						TopLevelDomain = "000";  // database code for unresolved numerical address
					}
				}
			}

			return TopLevelDomain;
		}

		// Convert a numeric IPAddress to the corresponding textual form.

		static String DecodeIPAddress(String IPAddress)
		{
			String Result = IPAddress;

			// Decode IP addresses if the user has requested this.  This is 
			// slow so we only do it if requested.
			if (SettingsForm.m_Settings.DecodeIPAddresses)
			{
				Result = Globals.m_DecodeIPAddresses.Decode(IPAddress);
			}

			return Result;
		}

		// Query the database for the minimum and maximum dates.  If the dates are
		// found (because the database isn't empty) a value of true is returned.

		public static bool GetMinMaxDatesFromDatabase(out DateTime MinDate, out DateTime MaxDate)
		{
			MinDate = new DateTime();
			MaxDate = new DateTime();

			bool Result = false;

			OleDbCommand Command = new OleDbCommand("SELECT Min(DateSerial(Year([DT]),Month([DT]),Day([DT]))) AS [Min], Max(DateSerial(Year([DT]),Month([DT]),Day([DT]))) AS [Max] FROM HTTPInfo;",
				                                    Globals.m_Database.Connection);

			OleDbDataReader Reader = null;

			// May get an exception if the database is empty.
			try
			{
				Reader = Command.ExecuteReader();

				Reader.Read();

				String MinDateString = Reader.GetValue(0).ToString();
				String MaxDateString = Reader.GetValue(1).ToString();

				MinDate = DateTime.Parse(MinDateString);
				MaxDate = DateTime.Parse(MaxDateString);

				Result = true;
			}
			catch (Exception)
			{
			}
			finally
			{
				if (Reader != null)
				{
					Reader.Close();
				}
			}

			return Result;
		}

		// Extract words if the ReferringURL is a search.

		static void ExtractWords(String ReferringURL, StreamWriter WordsFileSW, DateTime TheDateTime)
		{
			Match QueryMatch = QueryUtils.QueryRE.Match(ReferringURL);

			if (QueryMatch != null && QueryMatch.Value.Length > 0)
			{
				String SearchText = QueryUtils.ExtractQuery(ReferringURL);

				MatchCollection WordsMatches = QueryUtils.WordsRE.Matches(SearchText);

				foreach (Match WM in WordsMatches)
				{
					WordsFileSW.WriteLine(WM.Value.ToLower() + Delimiter + TheDateTime);
				}
			}
		}

	}
}
