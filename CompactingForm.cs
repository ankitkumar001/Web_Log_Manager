using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WSLA
{
	/// <summary>
	/// Summary description for CompactingForm.
	/// </summary>
	public class CompactingForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer TheTimer;
		private System.ComponentModel.IContainer components;

		public CompactingForm()
		{
			InitializeComponent();

			TheTimer.Enabled = true;
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompactingForm));
            this.label1 = new System.Windows.Forms.Label();
            this.TheTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 58);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please wait while the database is compacted.  If the database is not periodically" +
                " compacted it will keep growing larger and larger.";
            // 
            // TheTimer
            // 
            this.TheTimer.Tick += new System.EventHandler(this.TheTimer_Tick);
            // 
            // CompactingForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(303, 97);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CompactingForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Compacting Database";
            this.ResumeLayout(false);

		}
		#endregion

		private void TheTimer_Tick(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			Globals.m_Database.Compact();

			Cursor.Current = Cursors.Arrow;

			Close();
		}
	}
}
