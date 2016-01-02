using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;
using JRO;

namespace WSLA
{
	/// <summary>
	/// Summary description for Database.
	/// </summary>
	public class Database
	{
		public OleDbConnection Connection;

		public Database()
		{
		}

		public void Open()
		{
			try
			{
				Connection = new OleDbConnection(GetConnectionString());
				Connection.Open();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Globals.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				Connection = null;
			}
		}

		public void Close()
		{
			if (Connection != null)
			{
				try
				{
					Connection.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, Globals.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		// Compact the database (which must be closed before
		// this method is called).  If the database is not
		// periodically compacted it will keep getting bigger
		// and bigger.

		public void Compact()
		{
			try
			{
				String OriginalDBPath  = GetDBFilePath(".MDB");
				String CompactedDBPath = GetDBFilePath(".TMP");

				// Delete the temporary file if it exists.

				try
				{
					File.Delete(CompactedDBPath);
				}
				catch (Exception)
				{
				}

				JetEngine J = new JRO.JetEngine();

				// Compress the database (DATABASE.MDB) file to a temporary file
				// (DATABASE.TMP).
				J.CompactDatabase(GetConnectionString(), GetConnectionString(".TMP"));

				// Copy the compressed database file over the original database file.
				File.Copy(CompactedDBPath, OriginalDBPath, true);

				// Delete the temporary file.
				File.Delete(CompactedDBPath);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Globals.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// Return the full file path of database.  Specify a FileType
		// of ".MDB" for the database or ".TMP" for a temporary
		// file.

		private String GetDBFilePath(String FileType)
		{
			String Result = Path.GetDirectoryName(Application.ExecutablePath) + @"\DATABASE" + FileType;

			return Result;
		}

		// Returns a connection string to the database.

		private String GetConnectionString()
		{
			return GetConnectionString(".MDB");
		}

		// Returns a connection string to the database.  Specify a
		// FileType of ".MDB" for the database or ".TMP" for a 
		// temporary file.

		private String GetConnectionString(String FileType)
		{
			String Result = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" + GetDBFilePath(FileType) + "\"";

			return Result;
		}

	}
}
