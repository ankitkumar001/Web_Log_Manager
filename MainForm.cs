using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using PU;

namespace WSLA
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl m_TabControl;
		private System.Windows.Forms.TabPage DailyTrafficPage;
		private System.Windows.Forms.TabPage DomainReportPage;
		private WSLA.DailyTrafficListView DailyTrafficListView;
		private WSLA.DomainsListView DomainsListView;
		private System.Windows.Forms.TabPage UserAgentsPage;
		private WSLA.UserAgentsListView UserAgentsListView;
		private System.Windows.Forms.TabPage ReferrerPage;
		private WSLA.ReferrerListView ReferrerListView;
		private System.Windows.Forms.TabPage DownloadsPage;
		private WSLA.DownloadsListView DownloadsListView;
		private System.Windows.Forms.TabPage AccessPage;
		private WSLA.AccessesListView AccessesListView;
		private System.Windows.Forms.MainMenu TheMenu;
		private System.Windows.Forms.MenuItem FileMenuItem;
		private System.Windows.Forms.MenuItem DownloadLogMenuItem;
		private System.Windows.Forms.MenuItem ExitMenuItem;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.TabPage StatusCodesPage;
		private WSLA.StatusCodesListView StatusCodesListView;
		private System.Windows.Forms.MenuItem OptionsMenuItem;
		private System.Windows.Forms.MenuItem SettingsMenuItem;
		private SettingsForm SF = new SettingsForm();
		private System.Windows.Forms.StatusBar TheStatusBar;
        private System.Windows.Forms.TabPage BrowserPage;
		private bool Loading = false;
		private bool Updating = false;
		private WSLA.ErrorsListView ErrorsListView;
		private System.Windows.Forms.TabPage ErrorsPage;
		private System.Windows.Forms.MenuItem HelpMenuItem;
        private System.Windows.Forms.MenuItem HelpAboutMenuItem;
		private System.Windows.Forms.MenuItem OpenLogFileMenuItem;
		private System.Windows.Forms.TabPage QueriesPage;
		private WSLA.SearchQueriesListView SearchQueriesListView;
		private System.Windows.Forms.TabPage DownloadsByCountryPage;
		private WSLA.DownloadsByCountryListView m_DownloadsByCountryListView;
		private System.Windows.Forms.TabPage DownloadsByUserAgentPage;
		private WSLA.DownloadsByUserAgentListView DLByUserAgentListView;
		private System.Windows.Forms.TabPage UniqueVisitorsPage;
		private WSLA.UniqueVisitorsListView VisitorsListView;
		private System.Windows.Forms.TabPage HourlyTrafficPage;
		private WSLA.HourlyTrafficListView m_HourlyTrafficListView;
		private System.Windows.Forms.TabPage DotNetUsersPage;
		private WSLA.DotNetListView m_DotNetListView;
		private System.Windows.Forms.Button UpdateButton;
		private System.Windows.Forms.Label LatestLogDate;
		private System.Windows.Forms.Label EarliestLogDate;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker Date2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker Date1;
		private System.Windows.Forms.TabPage SearchWordsPage;
		private WSLA.SearchWordsListView searchWordsListView;
		private System.Windows.Forms.Button downloadButton;
		private System.Windows.Forms.TabPage operatingSystemsTabPage;
		private WSLA.OperatingSystemsListView statusCodesListView1;
        private static string textFilePath;
        private WebBrowser Browser;
        private IContainer components;

		public MainForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.m_TabControl = new System.Windows.Forms.TabControl();
            this.DailyTrafficPage = new System.Windows.Forms.TabPage();
            this.DailyTrafficListView = new WSLA.DailyTrafficListView();
            this.HourlyTrafficPage = new System.Windows.Forms.TabPage();
            this.m_HourlyTrafficListView = new WSLA.HourlyTrafficListView();
            this.ReferrerPage = new System.Windows.Forms.TabPage();
            this.ReferrerListView = new WSLA.ReferrerListView();
            this.BrowserPage = new System.Windows.Forms.TabPage();
            this.Browser = new System.Windows.Forms.WebBrowser();
            this.DownloadsPage = new System.Windows.Forms.TabPage();
            this.DownloadsListView = new WSLA.DownloadsListView();
            this.DownloadsByCountryPage = new System.Windows.Forms.TabPage();
            this.m_DownloadsByCountryListView = new WSLA.DownloadsByCountryListView();
            this.DownloadsByUserAgentPage = new System.Windows.Forms.TabPage();
            this.DLByUserAgentListView = new WSLA.DownloadsByUserAgentListView();
            this.UserAgentsPage = new System.Windows.Forms.TabPage();
            this.UserAgentsListView = new WSLA.UserAgentsListView();
            this.DotNetUsersPage = new System.Windows.Forms.TabPage();
            this.m_DotNetListView = new WSLA.DotNetListView();
            this.AccessPage = new System.Windows.Forms.TabPage();
            this.AccessesListView = new WSLA.AccessesListView();
            this.QueriesPage = new System.Windows.Forms.TabPage();
            this.SearchQueriesListView = new WSLA.SearchQueriesListView();
            this.SearchWordsPage = new System.Windows.Forms.TabPage();
            this.searchWordsListView = new WSLA.SearchWordsListView();
            this.UniqueVisitorsPage = new System.Windows.Forms.TabPage();
            this.VisitorsListView = new WSLA.UniqueVisitorsListView();
            this.DomainReportPage = new System.Windows.Forms.TabPage();
            this.DomainsListView = new WSLA.DomainsListView();
            this.StatusCodesPage = new System.Windows.Forms.TabPage();
            this.StatusCodesListView = new WSLA.StatusCodesListView();
            this.ErrorsPage = new System.Windows.Forms.TabPage();
            this.ErrorsListView = new WSLA.ErrorsListView();
            this.operatingSystemsTabPage = new System.Windows.Forms.TabPage();
            this.statusCodesListView1 = new WSLA.OperatingSystemsListView();
            this.TheMenu = new System.Windows.Forms.MainMenu(this.components);
            this.FileMenuItem = new System.Windows.Forms.MenuItem();
            this.DownloadLogMenuItem = new System.Windows.Forms.MenuItem();
            this.OpenLogFileMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.ExitMenuItem = new System.Windows.Forms.MenuItem();
            this.OptionsMenuItem = new System.Windows.Forms.MenuItem();
            this.SettingsMenuItem = new System.Windows.Forms.MenuItem();
            this.HelpMenuItem = new System.Windows.Forms.MenuItem();
            this.HelpAboutMenuItem = new System.Windows.Forms.MenuItem();
            this.TheStatusBar = new System.Windows.Forms.StatusBar();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.LatestLogDate = new System.Windows.Forms.Label();
            this.EarliestLogDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Date2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Date1 = new System.Windows.Forms.DateTimePicker();
            this.downloadButton = new System.Windows.Forms.Button();
            this.m_TabControl.SuspendLayout();
            this.DailyTrafficPage.SuspendLayout();
            this.HourlyTrafficPage.SuspendLayout();
            this.ReferrerPage.SuspendLayout();
            this.BrowserPage.SuspendLayout();
            this.DownloadsPage.SuspendLayout();
            this.DownloadsByCountryPage.SuspendLayout();
            this.DownloadsByUserAgentPage.SuspendLayout();
            this.UserAgentsPage.SuspendLayout();
            this.DotNetUsersPage.SuspendLayout();
            this.AccessPage.SuspendLayout();
            this.QueriesPage.SuspendLayout();
            this.SearchWordsPage.SuspendLayout();
            this.UniqueVisitorsPage.SuspendLayout();
            this.DomainReportPage.SuspendLayout();
            this.StatusCodesPage.SuspendLayout();
            this.ErrorsPage.SuspendLayout();
            this.operatingSystemsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_TabControl
            // 
            this.m_TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_TabControl.Controls.Add(this.DailyTrafficPage);
            this.m_TabControl.Controls.Add(this.HourlyTrafficPage);
            this.m_TabControl.Controls.Add(this.ReferrerPage);
            this.m_TabControl.Controls.Add(this.BrowserPage);
            this.m_TabControl.Controls.Add(this.DownloadsPage);
            this.m_TabControl.Controls.Add(this.DownloadsByCountryPage);
            this.m_TabControl.Controls.Add(this.DownloadsByUserAgentPage);
            this.m_TabControl.Controls.Add(this.UserAgentsPage);
            this.m_TabControl.Controls.Add(this.DotNetUsersPage);
            this.m_TabControl.Controls.Add(this.AccessPage);
            this.m_TabControl.Controls.Add(this.QueriesPage);
            this.m_TabControl.Controls.Add(this.SearchWordsPage);
            this.m_TabControl.Controls.Add(this.UniqueVisitorsPage);
            this.m_TabControl.Controls.Add(this.DomainReportPage);
            this.m_TabControl.Controls.Add(this.StatusCodesPage);
            this.m_TabControl.Controls.Add(this.ErrorsPage);
            this.m_TabControl.Controls.Add(this.operatingSystemsTabPage);
            this.m_TabControl.Location = new System.Drawing.Point(0, 69);
            this.m_TabControl.Multiline = true;
            this.m_TabControl.Name = "m_TabControl";
            this.m_TabControl.Padding = new System.Drawing.Point(0, 0);
            this.m_TabControl.SelectedIndex = 0;
            this.m_TabControl.Size = new System.Drawing.Size(840, 380);
            this.m_TabControl.TabIndex = 10;
            this.m_TabControl.SelectedIndexChanged += new System.EventHandler(this.m_TabControl_SelectedIndexChanged);
            // 
            // DailyTrafficPage
            // 
            this.DailyTrafficPage.Controls.Add(this.DailyTrafficListView);
            this.DailyTrafficPage.Location = new System.Drawing.Point(4, 40);
            this.DailyTrafficPage.Name = "DailyTrafficPage";
            this.DailyTrafficPage.Size = new System.Drawing.Size(832, 336);
            this.DailyTrafficPage.TabIndex = 0;
            this.DailyTrafficPage.Tag = "Displays downloads per day.";
            this.DailyTrafficPage.Text = "Daily Traffic";
            // 
            // DailyTrafficListView
            // 
            this.DailyTrafficListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DailyTrafficListView.FullRowSelect = true;
            this.DailyTrafficListView.GridLines = true;
            this.DailyTrafficListView.HideSelection = false;
            this.DailyTrafficListView.Location = new System.Drawing.Point(0, 0);
            this.DailyTrafficListView.MultiSelect = false;
            this.DailyTrafficListView.Name = "DailyTrafficListView";
            this.DailyTrafficListView.Size = new System.Drawing.Size(832, 336);
            this.DailyTrafficListView.TabIndex = 0;
            this.DailyTrafficListView.UseCompatibleStateImageBehavior = false;
            this.DailyTrafficListView.View = System.Windows.Forms.View.Details;
            // 
            // HourlyTrafficPage
            // 
            this.HourlyTrafficPage.Controls.Add(this.m_HourlyTrafficListView);
            this.HourlyTrafficPage.Location = new System.Drawing.Point(4, 40);
            this.HourlyTrafficPage.Name = "HourlyTrafficPage";
            this.HourlyTrafficPage.Size = new System.Drawing.Size(832, 336);
            this.HourlyTrafficPage.TabIndex = 15;
            this.HourlyTrafficPage.Tag = "Displays downloads per hour.";
            this.HourlyTrafficPage.Text = "Hourly Traffic";
            // 
            // m_HourlyTrafficListView
            // 
            this.m_HourlyTrafficListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_HourlyTrafficListView.FullRowSelect = true;
            this.m_HourlyTrafficListView.GridLines = true;
            this.m_HourlyTrafficListView.HideSelection = false;
            this.m_HourlyTrafficListView.Location = new System.Drawing.Point(0, 0);
            this.m_HourlyTrafficListView.MultiSelect = false;
            this.m_HourlyTrafficListView.Name = "m_HourlyTrafficListView";
            this.m_HourlyTrafficListView.Size = new System.Drawing.Size(832, 336);
            this.m_HourlyTrafficListView.TabIndex = 3;
            this.m_HourlyTrafficListView.UseCompatibleStateImageBehavior = false;
            this.m_HourlyTrafficListView.View = System.Windows.Forms.View.Details;
            // 
            // ReferrerPage
            // 
            this.ReferrerPage.Controls.Add(this.ReferrerListView);
            this.ReferrerPage.Location = new System.Drawing.Point(4, 40);
            this.ReferrerPage.Name = "ReferrerPage";
            this.ReferrerPage.Size = new System.Drawing.Size(832, 336);
            this.ReferrerPage.TabIndex = 3;
            this.ReferrerPage.Tag = "Displays URLs that were active before files were downloaded.";
            this.ReferrerPage.Text = "Referrer";
            // 
            // ReferrerListView
            // 
            this.ReferrerListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReferrerListView.FullRowSelect = true;
            this.ReferrerListView.GridLines = true;
            this.ReferrerListView.HideSelection = false;
            this.ReferrerListView.Location = new System.Drawing.Point(0, 0);
            this.ReferrerListView.MultiSelect = false;
            this.ReferrerListView.Name = "ReferrerListView";
            this.ReferrerListView.Size = new System.Drawing.Size(832, 336);
            this.ReferrerListView.TabIndex = 1;
            this.ReferrerListView.UseCompatibleStateImageBehavior = false;
            this.ReferrerListView.View = System.Windows.Forms.View.Details;
            // 
            // BrowserPage
            // 
            this.BrowserPage.Controls.Add(this.Browser);
            this.BrowserPage.Location = new System.Drawing.Point(4, 40);
            this.BrowserPage.Name = "BrowserPage";
            this.BrowserPage.Size = new System.Drawing.Size(832, 336);
            this.BrowserPage.TabIndex = 7;
            this.BrowserPage.Tag = "Displays the referring URL when you click on a row in the Referrer tab.";
            this.BrowserPage.Text = "Browser";
            // 
            // Browser
            // 
            this.Browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Browser.Location = new System.Drawing.Point(0, 0);
            this.Browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.Browser.Name = "Browser";
            this.Browser.Size = new System.Drawing.Size(832, 336);
            this.Browser.TabIndex = 0;
            this.Browser.NewWindow += new System.ComponentModel.CancelEventHandler(this.Browser_NewWindow);
            // 
            // DownloadsPage
            // 
            this.DownloadsPage.Controls.Add(this.DownloadsListView);
            this.DownloadsPage.Location = new System.Drawing.Point(4, 40);
            this.DownloadsPage.Name = "DownloadsPage";
            this.DownloadsPage.Size = new System.Drawing.Size(832, 336);
            this.DownloadsPage.TabIndex = 4;
            this.DownloadsPage.Tag = "Displays number of times that files have been downloaded.";
            this.DownloadsPage.Text = "DLs";
            // 
            // DownloadsListView
            // 
            this.DownloadsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DownloadsListView.FullRowSelect = true;
            this.DownloadsListView.GridLines = true;
            this.DownloadsListView.HideSelection = false;
            this.DownloadsListView.Location = new System.Drawing.Point(0, 0);
            this.DownloadsListView.MultiSelect = false;
            this.DownloadsListView.Name = "DownloadsListView";
            this.DownloadsListView.Size = new System.Drawing.Size(832, 336);
            this.DownloadsListView.TabIndex = 1;
            this.DownloadsListView.Tag = "Displays number of times that files have been downloaded.";
            this.DownloadsListView.UseCompatibleStateImageBehavior = false;
            this.DownloadsListView.View = System.Windows.Forms.View.Details;
            // 
            // DownloadsByCountryPage
            // 
            this.DownloadsByCountryPage.Controls.Add(this.m_DownloadsByCountryListView);
            this.DownloadsByCountryPage.Location = new System.Drawing.Point(4, 40);
            this.DownloadsByCountryPage.Name = "DownloadsByCountryPage";
            this.DownloadsByCountryPage.Size = new System.Drawing.Size(832, 336);
            this.DownloadsByCountryPage.TabIndex = 12;
            this.DownloadsByCountryPage.Tag = "Displays which files have been downloaded by users in different countries.";
            this.DownloadsByCountryPage.Text = "DLs by Country";
            // 
            // m_DownloadsByCountryListView
            // 
            this.m_DownloadsByCountryListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_DownloadsByCountryListView.FullRowSelect = true;
            this.m_DownloadsByCountryListView.GridLines = true;
            this.m_DownloadsByCountryListView.HideSelection = false;
            this.m_DownloadsByCountryListView.Location = new System.Drawing.Point(0, 0);
            this.m_DownloadsByCountryListView.MultiSelect = false;
            this.m_DownloadsByCountryListView.Name = "m_DownloadsByCountryListView";
            this.m_DownloadsByCountryListView.Size = new System.Drawing.Size(832, 336);
            this.m_DownloadsByCountryListView.TabIndex = 2;
            this.m_DownloadsByCountryListView.UseCompatibleStateImageBehavior = false;
            this.m_DownloadsByCountryListView.View = System.Windows.Forms.View.Details;
            // 
            // DownloadsByUserAgentPage
            // 
            this.DownloadsByUserAgentPage.Controls.Add(this.DLByUserAgentListView);
            this.DownloadsByUserAgentPage.Location = new System.Drawing.Point(4, 40);
            this.DownloadsByUserAgentPage.Name = "DownloadsByUserAgentPage";
            this.DownloadsByUserAgentPage.Size = new System.Drawing.Size(832, 336);
            this.DownloadsByUserAgentPage.TabIndex = 13;
            this.DownloadsByUserAgentPage.Tag = "Displays which files have been downloaded by different User Agents.";
            this.DownloadsByUserAgentPage.Text = "DLs by UA";
            // 
            // DLByUserAgentListView
            // 
            this.DLByUserAgentListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DLByUserAgentListView.FullRowSelect = true;
            this.DLByUserAgentListView.GridLines = true;
            this.DLByUserAgentListView.HideSelection = false;
            this.DLByUserAgentListView.Location = new System.Drawing.Point(0, 0);
            this.DLByUserAgentListView.MultiSelect = false;
            this.DLByUserAgentListView.Name = "DLByUserAgentListView";
            this.DLByUserAgentListView.Size = new System.Drawing.Size(832, 336);
            this.DLByUserAgentListView.TabIndex = 2;
            this.DLByUserAgentListView.UseCompatibleStateImageBehavior = false;
            this.DLByUserAgentListView.View = System.Windows.Forms.View.Details;
            // 
            // UserAgentsPage
            // 
            this.UserAgentsPage.Controls.Add(this.UserAgentsListView);
            this.UserAgentsPage.Location = new System.Drawing.Point(4, 40);
            this.UserAgentsPage.Name = "UserAgentsPage";
            this.UserAgentsPage.Size = new System.Drawing.Size(832, 336);
            this.UserAgentsPage.TabIndex = 2;
            this.UserAgentsPage.Tag = "Displays the User Agents that are accessing the website.";
            this.UserAgentsPage.Text = "UAs";
            // 
            // UserAgentsListView
            // 
            this.UserAgentsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserAgentsListView.FullRowSelect = true;
            this.UserAgentsListView.GridLines = true;
            this.UserAgentsListView.HideSelection = false;
            this.UserAgentsListView.Location = new System.Drawing.Point(0, 0);
            this.UserAgentsListView.MultiSelect = false;
            this.UserAgentsListView.Name = "UserAgentsListView";
            this.UserAgentsListView.Size = new System.Drawing.Size(832, 336);
            this.UserAgentsListView.TabIndex = 1;
            this.UserAgentsListView.UseCompatibleStateImageBehavior = false;
            this.UserAgentsListView.View = System.Windows.Forms.View.Details;
            // 
            // DotNetUsersPage
            // 
            this.DotNetUsersPage.Controls.Add(this.m_DotNetListView);
            this.DotNetUsersPage.Location = new System.Drawing.Point(4, 40);
            this.DotNetUsersPage.Name = "DotNetUsersPage";
            this.DotNetUsersPage.Size = new System.Drawing.Size(832, 336);
            this.DotNetUsersPage.TabIndex = 16;
            this.DotNetUsersPage.Tag = "Displays the percentage of unique visitors that have the .NET CLR installed.";
            this.DotNetUsersPage.Text = "% .NET Users";
            // 
            // m_DotNetListView
            // 
            this.m_DotNetListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_DotNetListView.FullRowSelect = true;
            this.m_DotNetListView.GridLines = true;
            this.m_DotNetListView.HideSelection = false;
            this.m_DotNetListView.Location = new System.Drawing.Point(0, 0);
            this.m_DotNetListView.MultiSelect = false;
            this.m_DotNetListView.Name = "m_DotNetListView";
            this.m_DotNetListView.Size = new System.Drawing.Size(832, 336);
            this.m_DotNetListView.TabIndex = 1;
            this.m_DotNetListView.UseCompatibleStateImageBehavior = false;
            this.m_DotNetListView.View = System.Windows.Forms.View.Details;
            // 
            // AccessPage
            // 
            this.AccessPage.Controls.Add(this.AccessesListView);
            this.AccessPage.Location = new System.Drawing.Point(4, 40);
            this.AccessPage.Name = "AccessPage";
            this.AccessPage.Size = new System.Drawing.Size(832, 336);
            this.AccessPage.TabIndex = 5;
            this.AccessPage.Tag = "Displays the number of accesses and bytes downloaded by each user.";
            this.AccessPage.Text = "Accesses";
            // 
            // AccessesListView
            // 
            this.AccessesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AccessesListView.FullRowSelect = true;
            this.AccessesListView.GridLines = true;
            this.AccessesListView.HideSelection = false;
            this.AccessesListView.Location = new System.Drawing.Point(0, 0);
            this.AccessesListView.MultiSelect = false;
            this.AccessesListView.Name = "AccessesListView";
            this.AccessesListView.Size = new System.Drawing.Size(832, 336);
            this.AccessesListView.TabIndex = 1;
            this.AccessesListView.UseCompatibleStateImageBehavior = false;
            this.AccessesListView.View = System.Windows.Forms.View.Details;
            // 
            // QueriesPage
            // 
            this.QueriesPage.Controls.Add(this.SearchQueriesListView);
            this.QueriesPage.Location = new System.Drawing.Point(4, 40);
            this.QueriesPage.Name = "QueriesPage";
            this.QueriesPage.Size = new System.Drawing.Size(832, 336);
            this.QueriesPage.TabIndex = 9;
            this.QueriesPage.Tag = "Displays the search queries that users have submitted to search engines.";
            this.QueriesPage.Text = "Searches";
            // 
            // SearchQueriesListView
            // 
            this.SearchQueriesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchQueriesListView.FullRowSelect = true;
            this.SearchQueriesListView.GridLines = true;
            this.SearchQueriesListView.HideSelection = false;
            this.SearchQueriesListView.Location = new System.Drawing.Point(0, 0);
            this.SearchQueriesListView.MultiSelect = false;
            this.SearchQueriesListView.Name = "SearchQueriesListView";
            this.SearchQueriesListView.Size = new System.Drawing.Size(832, 336);
            this.SearchQueriesListView.TabIndex = 1;
            this.SearchQueriesListView.UseCompatibleStateImageBehavior = false;
            this.SearchQueriesListView.View = System.Windows.Forms.View.Details;
            // 
            // SearchWordsPage
            // 
            this.SearchWordsPage.Controls.Add(this.searchWordsListView);
            this.SearchWordsPage.Location = new System.Drawing.Point(4, 40);
            this.SearchWordsPage.Name = "SearchWordsPage";
            this.SearchWordsPage.Size = new System.Drawing.Size(832, 336);
            this.SearchWordsPage.TabIndex = 17;
            this.SearchWordsPage.Tag = "Displays words used in searches";
            this.SearchWordsPage.Text = "Search Words";
            // 
            // searchWordsListView
            // 
            this.searchWordsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchWordsListView.FullRowSelect = true;
            this.searchWordsListView.GridLines = true;
            this.searchWordsListView.HideSelection = false;
            this.searchWordsListView.Location = new System.Drawing.Point(0, 0);
            this.searchWordsListView.MultiSelect = false;
            this.searchWordsListView.Name = "searchWordsListView";
            this.searchWordsListView.Size = new System.Drawing.Size(832, 336);
            this.searchWordsListView.TabIndex = 2;
            this.searchWordsListView.UseCompatibleStateImageBehavior = false;
            this.searchWordsListView.View = System.Windows.Forms.View.Details;
            // 
            // UniqueVisitorsPage
            // 
            this.UniqueVisitorsPage.Controls.Add(this.VisitorsListView);
            this.UniqueVisitorsPage.Location = new System.Drawing.Point(4, 40);
            this.UniqueVisitorsPage.Name = "UniqueVisitorsPage";
            this.UniqueVisitorsPage.Size = new System.Drawing.Size(832, 336);
            this.UniqueVisitorsPage.TabIndex = 14;
            this.UniqueVisitorsPage.Tag = "Displays the number of unique visitors to the website.";
            this.UniqueVisitorsPage.Text = "Visitors";
            // 
            // VisitorsListView
            // 
            this.VisitorsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisitorsListView.FullRowSelect = true;
            this.VisitorsListView.GridLines = true;
            this.VisitorsListView.HideSelection = false;
            this.VisitorsListView.Location = new System.Drawing.Point(0, 0);
            this.VisitorsListView.MultiSelect = false;
            this.VisitorsListView.Name = "VisitorsListView";
            this.VisitorsListView.Size = new System.Drawing.Size(832, 336);
            this.VisitorsListView.TabIndex = 3;
            this.VisitorsListView.UseCompatibleStateImageBehavior = false;
            this.VisitorsListView.View = System.Windows.Forms.View.Details;
            // 
            // DomainReportPage
            // 
            this.DomainReportPage.Controls.Add(this.DomainsListView);
            this.DomainReportPage.Location = new System.Drawing.Point(4, 40);
            this.DomainReportPage.Name = "DomainReportPage";
            this.DomainReportPage.Size = new System.Drawing.Size(832, 336);
            this.DomainReportPage.TabIndex = 1;
            this.DomainReportPage.Tag = "Displays visitors\' countries and the number of requests and bytes downloaded.";
            this.DomainReportPage.Text = "Countries";
            // 
            // DomainsListView
            // 
            this.DomainsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DomainsListView.FullRowSelect = true;
            this.DomainsListView.GridLines = true;
            this.DomainsListView.HideSelection = false;
            this.DomainsListView.Location = new System.Drawing.Point(0, 0);
            this.DomainsListView.MultiSelect = false;
            this.DomainsListView.Name = "DomainsListView";
            this.DomainsListView.Size = new System.Drawing.Size(832, 336);
            this.DomainsListView.TabIndex = 1;
            this.DomainsListView.UseCompatibleStateImageBehavior = false;
            this.DomainsListView.View = System.Windows.Forms.View.Details;
            // 
            // StatusCodesPage
            // 
            this.StatusCodesPage.Controls.Add(this.StatusCodesListView);
            this.StatusCodesPage.Location = new System.Drawing.Point(4, 40);
            this.StatusCodesPage.Name = "StatusCodesPage";
            this.StatusCodesPage.Size = new System.Drawing.Size(832, 336);
            this.StatusCodesPage.TabIndex = 6;
            this.StatusCodesPage.Tag = "Displays status codes for HTTP requests.";
            this.StatusCodesPage.Text = "Status Codes";
            // 
            // StatusCodesListView
            // 
            this.StatusCodesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusCodesListView.FullRowSelect = true;
            this.StatusCodesListView.GridLines = true;
            this.StatusCodesListView.HideSelection = false;
            this.StatusCodesListView.Location = new System.Drawing.Point(0, 0);
            this.StatusCodesListView.MultiSelect = false;
            this.StatusCodesListView.Name = "StatusCodesListView";
            this.StatusCodesListView.Size = new System.Drawing.Size(832, 336);
            this.StatusCodesListView.TabIndex = 1;
            this.StatusCodesListView.UseCompatibleStateImageBehavior = false;
            this.StatusCodesListView.View = System.Windows.Forms.View.Details;
            // 
            // ErrorsPage
            // 
            this.ErrorsPage.Controls.Add(this.ErrorsListView);
            this.ErrorsPage.Location = new System.Drawing.Point(4, 40);
            this.ErrorsPage.Name = "ErrorsPage";
            this.ErrorsPage.Size = new System.Drawing.Size(832, 336);
            this.ErrorsPage.TabIndex = 8;
            this.ErrorsPage.Tag = "Displays error codes for HTTP requests.";
            this.ErrorsPage.Text = "Errors";
            // 
            // ErrorsListView
            // 
            this.ErrorsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorsListView.FullRowSelect = true;
            this.ErrorsListView.GridLines = true;
            this.ErrorsListView.HideSelection = false;
            this.ErrorsListView.Location = new System.Drawing.Point(0, 0);
            this.ErrorsListView.MultiSelect = false;
            this.ErrorsListView.Name = "ErrorsListView";
            this.ErrorsListView.Size = new System.Drawing.Size(832, 336);
            this.ErrorsListView.TabIndex = 1;
            this.ErrorsListView.UseCompatibleStateImageBehavior = false;
            this.ErrorsListView.View = System.Windows.Forms.View.Details;
            // 
            // operatingSystemsTabPage
            // 
            this.operatingSystemsTabPage.Controls.Add(this.statusCodesListView1);
            this.operatingSystemsTabPage.Location = new System.Drawing.Point(4, 40);
            this.operatingSystemsTabPage.Name = "operatingSystemsTabPage";
            this.operatingSystemsTabPage.Size = new System.Drawing.Size(832, 336);
            this.operatingSystemsTabPage.TabIndex = 18;
            this.operatingSystemsTabPage.Tag = "Displays user\'s operating systems";
            this.operatingSystemsTabPage.Text = "OSs";
            // 
            // statusCodesListView1
            // 
            this.statusCodesListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusCodesListView1.FullRowSelect = true;
            this.statusCodesListView1.GridLines = true;
            this.statusCodesListView1.HideSelection = false;
            this.statusCodesListView1.Location = new System.Drawing.Point(0, 0);
            this.statusCodesListView1.MultiSelect = false;
            this.statusCodesListView1.Name = "statusCodesListView1";
            this.statusCodesListView1.Size = new System.Drawing.Size(832, 336);
            this.statusCodesListView1.TabIndex = 2;
            this.statusCodesListView1.UseCompatibleStateImageBehavior = false;
            this.statusCodesListView1.View = System.Windows.Forms.View.Details;
            // 
            // TheMenu
            // 
            this.TheMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.FileMenuItem,
            this.OptionsMenuItem,
            this.HelpMenuItem});
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.Index = 0;
            this.FileMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.DownloadLogMenuItem,
            this.OpenLogFileMenuItem,
            this.menuItem1,
            this.ExitMenuItem});
            this.FileMenuItem.Text = "&File";
            // 
            // DownloadLogMenuItem
            // 
            this.DownloadLogMenuItem.Index = 0;
            this.DownloadLogMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
            this.DownloadLogMenuItem.Text = "&Download Log File from Server";
            this.DownloadLogMenuItem.Click += new System.EventHandler(this.DownloadLogMenuItem_Click);
            // 
            // OpenLogFileMenuItem
            // 
            this.OpenLogFileMenuItem.Index = 1;
            this.OpenLogFileMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.OpenLogFileMenuItem.Text = "&Open Log File...";
            this.OpenLogFileMenuItem.Click += new System.EventHandler(this.OpenLogFileMenuItem_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 2;
            this.menuItem1.Text = "-";
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Index = 3;
            this.ExitMenuItem.Text = "E&xit";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // OptionsMenuItem
            // 
            this.OptionsMenuItem.Index = 1;
            this.OptionsMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.SettingsMenuItem});
            this.OptionsMenuItem.Text = "&Options";
            // 
            // SettingsMenuItem
            // 
            this.SettingsMenuItem.Index = 0;
            this.SettingsMenuItem.Text = "&Settings...";
            this.SettingsMenuItem.Click += new System.EventHandler(this.SettingsMenuItem_Click);
            // 
            // HelpMenuItem
            // 
            this.HelpMenuItem.Index = 2;
            this.HelpMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.HelpAboutMenuItem});
            this.HelpMenuItem.Text = "&Help";
            // 
            // HelpAboutMenuItem
            // 
            this.HelpAboutMenuItem.Index = 0;
            this.HelpAboutMenuItem.Text = "&About WSLA";
            this.HelpAboutMenuItem.Click += new System.EventHandler(this.HelpAboutMenuItem_Click);
            // 
            // TheStatusBar
            // 
            this.TheStatusBar.Location = new System.Drawing.Point(0, 448);
            this.TheStatusBar.Name = "TheStatusBar";
            this.TheStatusBar.Size = new System.Drawing.Size(840, 19);
            this.TheStatusBar.TabIndex = 11;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(613, 7);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(80, 20);
            this.UpdateButton.TabIndex = 4;
            this.UpdateButton.Text = "&Update";
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // LatestLogDate
            // 
            this.LatestLogDate.Location = new System.Drawing.Point(380, 35);
            this.LatestLogDate.Name = "LatestLogDate";
            this.LatestLogDate.Size = new System.Drawing.Size(227, 20);
            this.LatestLogDate.TabIndex = 8;
            // 
            // EarliestLogDate
            // 
            this.EarliestLogDate.Location = new System.Drawing.Point(380, 7);
            this.EarliestLogDate.Name = "EarliestLogDate";
            this.EarliestLogDate.Size = new System.Drawing.Size(227, 20);
            this.EarliestLogDate.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(267, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Latest Date in Log:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(267, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Earliest Date in Log:";
            // 
            // Date2
            // 
            this.Date2.Location = new System.Drawing.Point(60, 35);
            this.Date2.Name = "Date2";
            this.Date2.Size = new System.Drawing.Size(193, 20);
            this.Date2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "&To:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "F&rom:";
            // 
            // Date1
            // 
            this.Date1.Location = new System.Drawing.Point(60, 7);
            this.Date1.Name = "Date1";
            this.Date1.Size = new System.Drawing.Size(193, 20);
            this.Date1.TabIndex = 1;
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(613, 35);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(80, 20);
            this.downloadButton.TabIndex = 9;
            this.downloadButton.Text = "&Download";
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(840, 467);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.LatestLogDate);
            this.Controls.Add(this.EarliestLogDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Date2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Date1);
            this.Controls.Add(this.TheStatusBar);
            this.Controls.Add(this.m_TabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.TheMenu;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Real-time Web Server Log Analyzer with on-demand Reporting";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.m_TabControl.ResumeLayout(false);
            this.DailyTrafficPage.ResumeLayout(false);
            this.HourlyTrafficPage.ResumeLayout(false);
            this.ReferrerPage.ResumeLayout(false);
            this.BrowserPage.ResumeLayout(false);
            this.DownloadsPage.ResumeLayout(false);
            this.DownloadsByCountryPage.ResumeLayout(false);
            this.DownloadsByUserAgentPage.ResumeLayout(false);
            this.UserAgentsPage.ResumeLayout(false);
            this.DotNetUsersPage.ResumeLayout(false);
            this.AccessPage.ResumeLayout(false);
            this.QueriesPage.ResumeLayout(false);
            this.SearchWordsPage.ResumeLayout(false);
            this.UniqueVisitorsPage.ResumeLayout(false);
            this.DomainReportPage.ResumeLayout(false);
            this.StatusCodesPage.ResumeLayout(false);
            this.ErrorsPage.ResumeLayout(false);
            this.operatingSystemsTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args) 
		{
			if (ProcessUtils.ThisProcessIsAlreadyRunning())
			{
				MessageBox.Show(Globals.ProgramName + " is already running.", Globals.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				if (args.Length == 1 && File.Exists(args[0]))
				{
					textFilePath = args[0];
				}

				MainForm MF = new MainForm();

				Application.Run(MF);
			}
		}

		private void ExitMenuItem_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private string FileName = Application.StartupPath + @"\access_log.txt";
		private System.Windows.Forms.OpenFileDialog m_OpenFileDialog = new System.Windows.Forms.OpenFileDialog();

		private void LoadWebLog(bool DownloadFromServer)
		{
			if (!Loading)
			{
				Cursor.Current = Cursors.WaitCursor;

				Loading = true;

				String FilePath = Application.StartupPath + @"\access_log.txt";

				bool Error = SettingsForm.m_Settings.FTPServer == null || SettingsForm.m_Settings.FTPServer.Length == 0 ||
					SettingsForm.m_Settings.User      == null || SettingsForm.m_Settings.User.Length      == 0 ||
					SettingsForm.m_Settings.FileName  == null || SettingsForm.m_Settings.FileName.Length  == 0;

				if (DownloadFromServer && Error)
				{
					Cursor.Current = Cursors.Arrow;

					MessageBox.Show("Select Options / Settings to configure.", Globals.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					if (DownloadFromServer)
					{
						TheStatusBar.Text = "Downloading web server log file " + SettingsForm.m_Settings.FileName + " from " + SettingsForm.m_Settings.FTPServer;

						try
						{
							FTP.GetFtpFile(SettingsForm.m_Settings.FTPServer, 
								SettingsForm.m_Settings.User, 
								SettingsForm.m_Settings.Password, 
								SettingsForm.m_Settings.FileName, 
								FilePath, 
								true);
						}
						catch(FTPException F)
						{
							MessageBox.Show(F.Message);
							Error = true;
						}
					}
					else
					{
						m_OpenFileDialog.Title        = "Open";
						m_OpenFileDialog.FileName     = FileName;
						m_OpenFileDialog.Filter       = "Web Server Log Files (*.txt)|*.txt|All Files (*.*)|*.*";
						m_OpenFileDialog.AddExtension = true;

						if (m_OpenFileDialog.ShowDialog() == DialogResult.OK)
						{
							FileName = m_OpenFileDialog.FileName;
							FilePath = FileName;
							Error = false;
						}
						else
						{
							Error = true;
						}
					}

					if (!Error)
					{
						LoadWebLog(FilePath);
					}
				}

				Loading = false;
			}

			// Update status bar with description of current report.
			m_TabControl_SelectedIndexChanged(this, null);
		}

		private void LoadWebLog(string FilePath)
		{
			Application.DoEvents();

			Cursor.Current = Cursors.WaitCursor;

			WebServerLog.Load(FilePath, TheStatusBar);

			UpdateDatePickers();
			UpdateDisplays();

			Cursor.Current = Cursors.Default;
		}

		private void DownloadLogMenuItem_Click(object sender, System.EventArgs e)
		{
			LoadWebLog(true);
		}

		private void UpdateDisplays()
		{
			if (!Updating)
			{
				Application.DoEvents();
				Cursor.Current = Cursors.WaitCursor;

				Updating = true;

				TheStatusBar.Text = "Creating reports";

				for (int i = 0; i < m_TabControl.TabCount; i++)
				{
					TabPage TP = m_TabControl.TabPages[i];

					foreach (Control C in TP.Controls)
					{
						if (C is QueryListView)
						{
							QueryListView QLV = (QueryListView) C;
							QLV.Load(Date1.Value.Date, Date2.Value.Date);
						}
					}
				}

				TheStatusBar.Text = "Ready";

				Updating = false;

				Cursor.Current = Cursors.Arrow;
			}
		}

		private void SettingsMenuItem_Click(object sender, System.EventArgs e)
		{
			SF.ShowDialog();
		}

		public void DisplayURLInBrowser(String URL)
		{
			Browser.Navigate(URL);
		}

		private void HelpAboutMenuItem_Click(object sender, System.EventArgs e)
		{
			using (AboutForm AF = new AboutForm())
			{
				AF.ShowDialog();
			}
		}

		private void HelpVisitOurWebSiteMenuItem_Click(object sender, System.EventArgs e)
		{
			System.Diagnostics.Process.Start("http://www.PersonalMicroCosms.com");
		}

		// Set the date pickers to the minimum and maximum dates found in the
		// database.

		private void UpdateDatePickers()
		{
			DateTime MinLogDate, MaxLogDate;

			if (WebServerLog.GetMinMaxDatesFromDatabase(out MinLogDate, out MaxLogDate))
			{
				EarliestLogDate.Text = MinLogDate.ToLongDateString();
				LatestLogDate.Text   = MaxLogDate.ToLongDateString();

				// Avoid a MinDate > MaxDate exception.
				DateTime Min = new DateTime(1900, 1, 1);
				DateTime Max = new DateTime(2100, 1, 1);

				Date1.MinDate = Min;
				Date1.MaxDate = Max;
				Date1.Value   = MinLogDate;
				Date1.MinDate = MinLogDate;
				Date1.MaxDate = MaxLogDate;

				Date2.MinDate = Min;
				Date2.MaxDate = Max;
				Date2.Value   = MaxLogDate;
				Date2.MinDate = MinLogDate;
				Date2.MaxDate = MaxLogDate;
			}
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			MinimumSize = Size;

			ActiveControl = m_TabControl;

			Globals.m_Database.Open();

			// Update status bar with description of current report.
			m_TabControl_SelectedIndexChanged(this, null);

			Application.DoEvents();

			UpdateDatePickers();

			UpdateDisplays();

			if (textFilePath != null)
			{
				LoadWebLog(textFilePath);
			}
		}

		private void OpenLogFileMenuItem_Click(object sender, System.EventArgs e)
		{
			LoadWebLog(false);
		}

		private void UpdateButton_Click(object sender, System.EventArgs e)
		{
			UpdateDisplays();
		}

		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Globals.m_Database.Close();

			using (CompactingForm CF = new CompactingForm())
			{
				CF.ShowDialog();
			}
		}

		private void m_TabControl_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			TheStatusBar.Text = m_TabControl.SelectedTab.Tag.ToString();
		}

		private void downloadButton_Click(object sender, System.EventArgs e)
		{
			DownloadLogMenuItem_Click(null, null);
		}

        private void Browser_NewWindow(object sender, CancelEventArgs e)
        {
            // Disallow popup windows.
            e.Cancel = true;
        }

        public CompactingForm CompactingForm
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public QueryUtils QueryUtils
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Database Database
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public SettingsForm SettingsForm
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public ExtractURL ExtractURL
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public WebServerLog WebServerLog
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
	}
}
