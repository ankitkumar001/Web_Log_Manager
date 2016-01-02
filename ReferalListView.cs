using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace WSLA
{
	public class ReferrerListView : QueryListView
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ReferrerListView()
		{
			InitializeComponent();
		}

		public override String GetQuery(DateTime Date1, DateTime Date2)
		{
			String Result =
				"SELECT Count(*) AS [# Requests], [ReferringURL] AS [Referring URL], [FileName] AS URL\n" +
				"FROM HTTPInfo\n" +
				"WHERE [HTTPInfo].[DT] >= " + GetSQLDate(Date1) + " AND [HTTPInfo].[DT] < " + GetSQLDate(Date2.AddDays(1)) + "\n" +
				"GROUP BY [ReferringURL], [FileName]\n" +
				"ORDER BY [ReferringURL], [FileName];";

			return Result;
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
			this.SelectedIndexChanged += new System.EventHandler(this.ReferrerListView_SelectedIndexChanged);
		}
		#endregion

		private void ReferrerListView_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (SelectedIndices.Count == 1)
			{
				int Index = SelectedIndices[0];

				String URL = Items[Index].SubItems[1].Text;

				MainForm MF = (MainForm) this.Parent.Parent.Parent;
				MF.DisplayURLInBrowser(URL);
			}
		}
	}	
}
