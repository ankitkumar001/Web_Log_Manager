using System;
using System.Collections;
using System.ComponentModel;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WSLA
{
	/// <summary>
	/// Summary description for QueryListView.
	/// </summary>
	public abstract class QueryListView : ListView
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public enum DataType { TypeString, TypeInt, TypeDate };
		protected DataType[] ColumnDataTypes;

		protected QueryListView()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		protected virtual void FormatFields(String[] Fields)
		{
			for (int i = 0; i < Fields.Length; i++)
			{
				switch (ColumnDataTypes[i])
				{
					case DataType.TypeDate:
					{
						int Index = Fields[i].IndexOf(' ');

						if (Index != -1)
						{
							Fields[i] = Fields[i].Substring(0, Index);
						}
					}
						break;

					case DataType.TypeInt:
					{
						try
						{
							Fields[i] = String.Format("{0:N0}", int.Parse(Fields[i]));
						}
                        catch (FormatException)
                        {
                        }
                        catch (OverflowException)
                        {
                        }
                    }
					break;
				}
			}
		}

		// Load the ListView with query results.

		public void Load(DateTime Date1, DateTime Date2)
		{
			// Remove existing items in ListView.
			Items.Clear();

			// Get SQL query.
			String Query = GetQuery(Date1, Date2);
			OleDbCommand Command = new OleDbCommand(Query, Globals.m_Database.Connection);

			// Create an ArrayList that will hold 
			// ListViewItems containing fields from 
			// the query results.
			ArrayList ArrayListItems = new ArrayList();

			// Execute the query.
			using (OleDbDataReader Reader = Command.ExecuteReader())
			{
				StoreColumnTypes(Reader);

				// Extract column headers from "AS" statements.
				CreateColumnHeaders(Reader);

				while (Reader.Read()) 
				{
					String[] Fields = new String[Reader.FieldCount];

					for (int i = 0; i < Fields.Length; i++)
					{
						// Some queries will throw exceptions when the
						// database is empty.
						try
						{
							Fields[i] = Reader.GetValue(i).ToString();
						}
						catch (OleDbException)
						{
							Fields[i] = "";
						}
					}

					FormatFields(Fields);

					ArrayListItems.Add(new ListViewItem(Fields));
				}
			}

			// Load the ListView.
			ListViewItem[] ListViewItems = (ListViewItem[]) ArrayListItems.ToArray(typeof(ListViewItem));
			Items.AddRange(ListViewItems);
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// QueryListView
			// 
			this.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.QueryListView_ColumnClick);

		}
		#endregion

		private int PreviousColumn = -1;
		private static int Column  = -1;

		public static DataType ColumnDataType;

		// Comparison functions for sorting when columns are clicked.

		private class Sorter : IComparer
		{
			public int Compare(object Obj1, object Obj2)
			{
				int Result = 0;

				try
				{
					String Text1 = ((ListViewItem) Obj1).SubItems[Column].Text;
					String Text2 = ((ListViewItem) Obj2).SubItems[Column].Text;

					switch (ColumnDataType)
					{
						case DataType.TypeString:
						{
							Result = String.Compare(Text1, Text2, true);
						}
							break;

						case DataType.TypeInt:
						{
							Result = Int32.Parse(Text1.Replace(",", "")) - Int32.Parse(Text2.Replace(",", ""));
						}
							break;

						case DataType.TypeDate:
						{
							DateTime DT1 = DateTime.Parse(Text1);
							DateTime DT2 = DateTime.Parse(Text2);

							if (DT1 > DT2)
							{
								Result = 1;
							}
							else if (DT1 < DT2)
							{
								Result = -1;
							}
							else
							{
								Result = 0;
							}
						}
							break;
					}

					if (((ListViewItem) Obj1).ListView.Sorting == SortOrder.Descending)
					{
						Result *= -1;
					}
				}
				catch(Exception)
				{
					Result = 0;
				}

				return Result;
			}
		}

		public void QueryListView_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			Parent.Cursor = Cursors.WaitCursor;

			Column = e.Column;

			ColumnDataType = ColumnDataTypes[Column];

			// Toggle the sort order when user clicks on the column twice in a row.
			if (Column == PreviousColumn)
			{
				Sorting = Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
			}
			else
			{
				Sorting = SortOrder.Ascending;
			}

			ListViewItemSorter = new Sorter();

			PreviousColumn = Column;

			Parent.Cursor = Cursors.Arrow;
		}

		public void StoreColumnTypes(OleDbDataReader Reader)
		{
			ColumnDataTypes = new DataType[Reader.FieldCount];

			for (int i = 0; i < ColumnDataTypes.Length; i++)
			{
				Type T = Reader.GetFieldType(i);

				if (T == Type.GetType("System.String"))
				{
					ColumnDataTypes[i] = DataType.TypeString;
				}
				else if (T == Type.GetType("System.DateTime"))
				{
					ColumnDataTypes[i] = DataType.TypeDate;
				}
				else
				{
					ColumnDataTypes[i] = DataType.TypeInt;
				}
			}
		}

		public void CreateColumnHeaders(OleDbDataReader Reader)
		{
			Columns.Clear();

			ColumnHeader[] ColumnHeaders = new ColumnHeader[Reader.FieldCount];

			for (int i = 0; i < ColumnHeaders.Length; i++)
			{
				ColumnHeaders[i] = new ColumnHeader();
				ColumnHeaders[i].Text = Reader.GetName(i);
				ColumnHeaders[i].Width  = (Width / ColumnHeaders.Length) * 9 / 10;
				Columns.Add(ColumnHeaders[i]);
			}
		}

		public abstract String GetQuery(DateTime Date1, DateTime Date2);

		protected String GetSQLDate(DateTime Date)
		{
			return "#" + Date.Month + "/" + Date.Day + "/" + Date.Year + "#";
		}
	}
}
