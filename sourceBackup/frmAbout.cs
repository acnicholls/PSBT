using System;
using System.Diagnostics;
using System.Reflection;

namespace sourceBackup
{

    /// <summary>
    /// About form, describes the project, the author, and relevent licence data
    /// </summary>
    public class FrmAbout : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.Label labelDisclaimer;
		private System.Windows.Forms.Label labelAdvertise;

		private readonly ProjectInfo info;
		private System.Windows.Forms.LinkLabel labelRequests;
		private System.Windows.Forms.LinkLabel labelThanks;
		private System.Windows.Forms.PictureBox pictureBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private readonly System.ComponentModel.Container components = null;

        /// <summary>
        /// default constructor with changes.  Instantiates local class
        /// </summary>
		public FrmAbout()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// DONETODO: Add any constructor code after InitializeComponent call
			//	Insert text for about...
			info = new ProjectInfo();

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmAbout));
			this.labelVersion = new System.Windows.Forms.Label();
			this.labelRequests = new System.Windows.Forms.LinkLabel();
			this.cmdOK = new System.Windows.Forms.Button();
			this.labelDescription = new System.Windows.Forms.Label();
			this.labelDisclaimer = new System.Windows.Forms.Label();
			this.labelAdvertise = new System.Windows.Forms.Label();
			this.labelThanks = new System.Windows.Forms.LinkLabel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// labelVersion
			// 
			this.labelVersion.Location = new System.Drawing.Point(304, 232);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(175, 70);
			this.labelVersion.TabIndex = 8;
			this.labelVersion.Text = "Version : 1.0.1.020\r\nManufacturer: victoriahosting.com\r\nAuthor: kod3brkr\r\n\r\nCopyr" +
				"ight: 2007";
			// 
			// labelRequests
			// 
			this.labelRequests.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
			this.labelRequests.Location = new System.Drawing.Point(184, 120);
			this.labelRequests.Name = "labelRequests";
			this.labelRequests.Size = new System.Drawing.Size(304, 23);
			this.labelRequests.TabIndex = 2;
			this.labelRequests.TabStop = true;
			this.labelRequests.Text = "For Change Requests Click Here";
			this.labelRequests.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labelRequests.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
			// 
			// cmdOK
			// 
			this.cmdOK.Location = new System.Drawing.Point(408, 19);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 0;
			this.cmdOK.Text = "OK";
			this.cmdOK.Click += new System.EventHandler(this.Button1_Click);
			// 
			// labelDescription
			// 
			this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelDescription.Location = new System.Drawing.Point(16, 10);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(384, 54);
			this.labelDescription.TabIndex = 3;
			this.labelDescription.Text = "DESCRIPTION: This program builds a list of folders on a target drive, alongside t" +
				"he size in bytes, kilobytes or megabytes. \r\nAn excellent tool for network admini" +
				"strators.\r\n";
			// 
			// labelDisclaimer
			// 
			this.labelDisclaimer.Location = new System.Drawing.Point(8, 232);
			this.labelDisclaimer.Name = "labelDisclaimer";
			this.labelDisclaimer.Size = new System.Drawing.Size(288, 72);
			this.labelDisclaimer.TabIndex = 4;
			this.labelDisclaimer.Text = @"WARNING: This computer program is protected by copyright law and international treaties.  Unauthorized reproduction or distribution of this program, or any part of it, may result in severe and criminal penalties, and will be prosecuted to the maximum extent possible under the law.";
			this.labelDisclaimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelAdvertise
			// 
			this.labelAdvertise.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelAdvertise.Location = new System.Drawing.Point(8, 176);
			this.labelAdvertise.Name = "labelAdvertise";
			this.labelAdvertise.Size = new System.Drawing.Size(480, 48);
			this.labelAdvertise.TabIndex = 5;
			this.labelAdvertise.Text = "Produces a printed report.\r\nSchedulable, Unattended.\r\nSees network drives\r\n";
			this.labelAdvertise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelThanks
			// 
			this.labelThanks.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
			this.labelThanks.Location = new System.Drawing.Point(184, 80);
			this.labelThanks.Name = "labelThanks";
			this.labelThanks.Size = new System.Drawing.Size(296, 23);
			this.labelThanks.TabIndex = 1;
			this.labelThanks.TabStop = true;
			this.labelThanks.Text = "Compression routine thanks to GeraldGibson.net";
			this.labelThanks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labelThanks.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelThanks_LinkClicked);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 56);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(176, 112);
			this.pictureBox1.TabIndex = 9;
			this.pictureBox1.TabStop = false;
			// 
			// frmAbout
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(494, 318);
			this.ControlBox = false;
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.labelThanks);
			this.Controls.Add(this.labelAdvertise);
			this.Controls.Add(this.labelDisclaimer);
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.labelRequests);
			this.Controls.Add(this.labelVersion);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmAbout";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About Project Source Backup Tool";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.FrmAbout_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Click this link to start up your default email provider and send me an email describing a problem, suggestion
		/// or question about Project Source Backup Tool.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LinkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			var address = "http://acnlop.dyndns.org/?op=support";
			//address += "?Subject=Project Source backup Tool Change Request";
			Process myProcess = new Process();
			myProcess.StartInfo.FileName = address;
			myProcess.StartInfo.UseShellExecute = true;
			myProcess.StartInfo.RedirectStandardOutput=false;
			myProcess.Start();
			myProcess.Dispose();
		}

        /// <summary>
        /// closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void Button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	
		/// <summary>
		/// this form is just an informational screen related to the project and it's contents.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmAbout_Load(object sender, System.EventArgs e)
		{
			string message = "Version: " + info.Version.ToString() + "\n";
			message += "Manufacturer: " + info.Manufacturer.ToString() + "\n";
			message += "Author: " + info.Author.ToString() + "\n";
			message += "\n";
			message += "Copyright 2007";
			this.labelVersion.Text = message;

			this.labelDescription.Text = info.Description.ToString();

			message = "Project backup without the need for external compression utility.\n";
			message += "Removal of Debug and Release folders.\n";
			message += "Supports project profiles.";
			this.labelAdvertise.Text = message;
			
			// DONETODO: Setup other label variables here
		}
		/// <summary>
		/// opens two tabs/windows in internet explorer, one to Gerald Gibsons main page, and another to the 
		/// code that's involoved in this project.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LabelThanks_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			var address = "http://geraldgibson.net/dnn/Home/CZipFileCompression/tabid/148/Default.aspx";
			Process myProcess = new Process();
			myProcess.StartInfo.FileName = address;
			myProcess.StartInfo.UseShellExecute = true;
			myProcess.StartInfo.RedirectStandardOutput=false;
			myProcess.Start();
			myProcess.Dispose();
		}
	}

    /// <summary>
    /// this class contains properties related to the project, it's author, version, language, etc.
    /// </summary>
	public class ProjectInfo
	{
		public string Version
		{
			get
			{
				Assembly a = Assembly.GetExecutingAssembly();
				AssemblyName an = a.GetName();
				return Convert.ToString(an.Version);
			}
		}
		public string Language = "C#";
		public string Author = "AC Nicholls";
		public string Website = "http://www.acnicholls.com";
		public string Name = "Project Source Backup Tool";
		public string Manufacturer = "acnicholls.com";
		public string Description = "DESCRIPTION: This program builds a WINDOWS compressed folder of the designated folder, while removing debug and release folder content from the compressed file.";
	} 

}
