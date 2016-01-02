using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WSLA
{
	/// <summary>
	/// Summary description for SettingsForm.
	/// </summary>
	public class SettingsForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox FTPServerTextBox;
		private System.Windows.Forms.TextBox UserTextBox;
		private System.Windows.Forms.TextBox PasswordTextBox;
		private System.Windows.Forms.TextBox FileNameTextBox;
		private System.Windows.Forms.Button m_OKButton;
		private System.Windows.Forms.Button m_CancelButton;
		private System.Windows.Forms.CheckBox DecodeCheckBox;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		[Serializable]
		public class Settings
		{
			public String FTPServer;
			public String User;
			public String Password;
			public String FileName;
			public bool   DecodeIPAddresses;
		}

		private static String GetConfigFilePath()
		{
			return Path.GetDirectoryName(Application.ExecutablePath) + @"\config.dat";
		}

		public static void SaveSettings()
		{
			Stream Write = null;

			try
			{
				FileInfo FI = new FileInfo(GetConfigFilePath());

				Write = FI.OpenWrite();

				BinaryFormatter BF = new BinaryFormatter();

				BF.Serialize(Write, m_Settings);
			}
			catch(Exception)
			{
			}
			finally
			{
				if (Write != null)
				{
					Write.Close();
				}
			}
		}

		public static void LoadSettings()
		{
			Stream Read = null;

			try
			{
				FileInfo FI = new FileInfo(GetConfigFilePath());

				Read = FI.OpenRead();

				BinaryFormatter BF = new BinaryFormatter();

				Settings Tmp = (Settings) BF.Deserialize(Read);
				m_Settings = Tmp;
			}
			catch(Exception)
			{
			}
			finally
			{
				if (Read != null)
				{
					Read.Close();
				}
			}
		}

		public static Settings m_Settings = new Settings();

		public SettingsForm()
		{
			InitializeComponent();

			LoadSettings();

			ActiveControl = FTPServerTextBox;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FTPServerTextBox = new System.Windows.Forms.TextBox();
            this.UserTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.FileNameTextBox = new System.Windows.Forms.TextBox();
            this.m_OKButton = new System.Windows.Forms.Button();
            this.m_CancelButton = new System.Windows.Forms.Button();
            this.DecodeCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "&FTP Server:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "&User:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "&Password:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "File &Name:";
            // 
            // FTPServerTextBox
            // 
            this.FTPServerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FTPServerTextBox.Location = new System.Drawing.Point(107, 14);
            this.FTPServerTextBox.Name = "FTPServerTextBox";
            this.FTPServerTextBox.Size = new System.Drawing.Size(352, 20);
            this.FTPServerTextBox.TabIndex = 1;
            // 
            // UserTextBox
            // 
            this.UserTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.UserTextBox.Location = new System.Drawing.Point(107, 42);
            this.UserTextBox.Name = "UserTextBox";
            this.UserTextBox.Size = new System.Drawing.Size(352, 20);
            this.UserTextBox.TabIndex = 3;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTextBox.Location = new System.Drawing.Point(107, 69);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(352, 20);
            this.PasswordTextBox.TabIndex = 5;
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FileNameTextBox.Location = new System.Drawing.Point(107, 97);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.Size = new System.Drawing.Size(352, 20);
            this.FileNameTextBox.TabIndex = 7;
            // 
            // m_OKButton
            // 
            this.m_OKButton.Location = new System.Drawing.Point(126, 180);
            this.m_OKButton.Name = "m_OKButton";
            this.m_OKButton.Size = new System.Drawing.Size(62, 20);
            this.m_OKButton.TabIndex = 9;
            this.m_OKButton.Text = "&OK";
            this.m_OKButton.Click += new System.EventHandler(this.m_OKButton_Click);
            // 
            // m_CancelButton
            // 
            this.m_CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_CancelButton.Location = new System.Drawing.Point(206, 180);
            this.m_CancelButton.Name = "m_CancelButton";
            this.m_CancelButton.Size = new System.Drawing.Size(62, 20);
            this.m_CancelButton.TabIndex = 10;
            this.m_CancelButton.Text = "&Cancel";
            // 
            // DecodeCheckBox
            // 
            this.DecodeCheckBox.Location = new System.Drawing.Point(13, 139);
            this.DecodeCheckBox.Name = "DecodeCheckBox";
            this.DecodeCheckBox.Size = new System.Drawing.Size(174, 20);
            this.DecodeCheckBox.TabIndex = 8;
            this.DecodeCheckBox.Text = "&Decode IP Addresses (slow!)";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.m_OKButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.m_CancelButton;
            this.ClientSize = new System.Drawing.Size(472, 202);
            this.Controls.Add(this.DecodeCheckBox);
            this.Controls.Add(this.m_CancelButton);
            this.Controls.Add(this.m_OKButton);
            this.Controls.Add(this.FileNameTextBox);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UserTextBox);
            this.Controls.Add(this.FTPServerTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1250, 236);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 236);
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void m_OKButton_Click(object sender, System.EventArgs e)
		{
			m_Settings.FTPServer         = FTPServerTextBox.Text;
			m_Settings.User              = UserTextBox.Text;
			m_Settings.Password          = PasswordTextBox.Text;
			m_Settings.FileName          = FileNameTextBox.Text;
			m_Settings.DecodeIPAddresses = DecodeCheckBox.Checked;

			SaveSettings();

			Close();
		}

		private void SettingsForm_Load(object sender, System.EventArgs e)
		{
			LoadSettings();

			FTPServerTextBox.Text  = m_Settings.FTPServer;
			UserTextBox.Text       = m_Settings.User;
			PasswordTextBox.Text   = m_Settings.Password;
			FileNameTextBox.Text   = m_Settings.FileName;
			DecodeCheckBox.Checked = m_Settings.DecodeIPAddresses;
		}
	}
}
