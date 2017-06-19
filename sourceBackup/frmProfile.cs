using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace sourceBackup
{
    /// <summary>
    /// Profile form.  Saves profile data to registry or file
    /// </summary>
    public class frmProfile : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtProfileName;
		private System.Windows.Forms.Button cmdGo;
		private System.Windows.Forms.Button cmdCancel;

		private string project;
		private string backup;
		private string zipName;
		private string debug;
		private string profileName;
		private bool fileMode = false;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        /// <summary>
        /// default contructor
        /// </summary>
		public frmProfile()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			//
		}

        /// <summary>
        /// non-default constructor.  assigns values to local properties depending on passed values
        /// </summary>
        /// <param name="profileParts">string list containing the 5 parts of the profile</param>
		public frmProfile(string[] profileParts)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// DONETODO: Add any constructor code after InitializeComponent call
			//
			profileName = profileParts[0];
			project = profileParts[1];
			backup = profileParts[2];
			zipName = profileParts[3];
			debug = profileParts[4];

		}

        /// <summary>
        /// non-default constructor.  assigns values to local properties depending on passed values
        /// </summary>
        /// <param name="profileParts">string list containing the 5 parts of the profile</param>
        /// <param name="filemode">boolean determining whether profile is in registry or file</param>
		public frmProfile(string[] profileParts, bool filemode)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// DONETODO: Add any constructor code after InitializeComponent call
			//
			profileName = profileParts[0];
			project = profileParts[1];
			backup = profileParts[2];
			zipName = profileParts[3];
			debug = profileParts[4];
			fileMode = filemode;

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
			this.label1 = new System.Windows.Forms.Label();
			this.txtProfileName = new System.Windows.Forms.TextBox();
			this.cmdGo = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Enter the profile name:";
			// 
			// txtProfileName
			// 
			this.txtProfileName.Location = new System.Drawing.Point(128, 8);
			this.txtProfileName.Name = "txtProfileName";
			this.txtProfileName.Size = new System.Drawing.Size(168, 20);
			this.txtProfileName.TabIndex = 1;
			this.txtProfileName.Text = "";
			// 
			// cmdGo
			// 
			this.cmdGo.Location = new System.Drawing.Point(304, 8);
			this.cmdGo.Name = "cmdGo";
			this.cmdGo.TabIndex = 2;
			this.cmdGo.Text = "OK";
			this.cmdGo.Click += new System.EventHandler(this.cmdGo_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.Location = new System.Drawing.Point(384, 8);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 3;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// frmProfile
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(466, 40);
			this.ControlBox = false;
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdGo);
			this.Controls.Add(this.txtProfileName);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmProfile";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Name Profile";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.frmProfile_Load);
			this.ResumeLayout(false);

		}
		#endregion

        /// <summary>
        /// this form's load method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void frmProfile_Load(object sender, System.EventArgs e)
		{
		   //DONETODO: take all the passed variables and assign them locally?
			if(profileName != null)
				this.txtProfileName.Text = profileName.ToString();
		}

        /// <summary>
        /// saves the profile data either to file or to registry, depending on user options.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void cmdGo_Click(object sender, System.EventArgs e)
		{

			string profileName = txtProfileName.Text.ToString();
			if(txtProfileName.Text.Length > 0)
			{
				if(fileMode)
				{
					try
					{
						bool valid = this.CheckForInvalidChars(profileName);
						if(valid)
						{
							// save to a new file under the profiles directory
							DirectoryInfo profiles = new DirectoryInfo(System.Environment.CurrentDirectory + @"\Profiles");
							if(!profiles.Exists)
								profiles.Create();
							FileInfo newProfile = new FileInfo(profiles.FullName.ToString() + @"\" + profileName.ToString() + ".psbt");
							if(newProfile.Exists)
							{
								DialogResult result = MessageBox.Show(newProfile.Name.ToString() + " exists, would you like to replace it?", "Replace Profile...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
								if(result == DialogResult.No)
								{
									return;
								}
							}
							// create a new file and write to it.
							StreamWriter logFile = new StreamWriter(newProfile.FullName.ToString(),false);
							logFile.WriteLine(project);
							logFile.WriteLine(backup);
							logFile.WriteLine(zipName);
							logFile.WriteLine(debug);
							logFile.Flush();
							logFile.Close();   
						}
						else
						{
							// build a message to show the user invalid characters
							string message = "Please enter a Windows(tm) VALID filename.\n";
							message += "Illegal characters are as follows:\n\n";
							message += @" \ , / , : , * , ? , "" , < , > , | ";
							// now show the user the message
							MessageBox.Show(message,"Illegal Filename...");
							return;
						}


						RegistryKey profileLocation = Registry.CurrentUser;
						string location =   @"SOFTWARE\acnicholls.com\Project Source Backup Tool\Profiles\" + profileName.ToString();
						RegistryKey storage = profileLocation.CreateSubKey(location);
						storage.SetValue("ProjectLocation",project);
						storage.SetValue("BackupLocation", backup);
						storage.SetValue("zipName", zipName);
						storage.SetValue("RemoveDebug",Convert.ToInt32(debug));
					}
					catch(System.Exception x)
					{
						MessageBox.Show(x.Message, "Profile not Saved...");
						frmMain.parts[0] = "Failed";
						return;
					}
					finally
					{
						frmMain.parts[0] = profileName;
						profileName = "";
						project = "";
						backup = "";
						zipName = "";
						debug = "";
						this.Close();
					}

				}
				else
				{
					try
					{
						RegistryKey profileLocation = Registry.CurrentUser;
						string location =   @"SOFTWARE\acnicholls.com\Project Source Backup Tool\Profiles\" + profileName.ToString();
						RegistryKey storage = profileLocation.CreateSubKey(location);
						storage.SetValue("ProjectLocation",project);
						storage.SetValue("BackupLocation", backup);
						storage.SetValue("zipName", zipName);
						storage.SetValue("RemoveDebug",Convert.ToInt32(debug));
					}
					catch(System.Exception x)
					{
						MessageBox.Show(x.Message, "Profile not Saved...");
						frmMain.parts[0] = "Failed";
						return;
					}
					finally
					{
						frmMain.parts[0] = profileName;
						profileName = "";
						project = "";
						backup = "";
						zipName = "";
						debug = "";
						this.Close();
					}
				}
			}
			else
				MessageBox.Show("Please enter a name for your project profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

				
		}

        /// <summary>
        /// closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

        /// <summary>
        /// checks the supplied filename for invalid windows filename characters
        /// </summary>
        /// <param name="filename">the string to check</param>
        /// <returns>true/false</returns>
		private bool CheckForInvalidChars(string filename)
		{

			bool valid = true;
			int loc = 0;

			loc = filename.IndexOf(@"""");
			if(loc > 0)
				valid = false;
			loc = filename.IndexOf(@"\");
			if(loc > 0)
				valid = false;
			loc = filename.IndexOf(@"?");
			if(loc > 0)
				valid = false;
			loc = filename.IndexOf(@"|");
			if(loc > 0)
				valid = false;
			loc = filename.IndexOf(@"/");
			if(loc > 0)
				valid = false;
			loc = filename.IndexOf(@":");
			if(loc > 0)
				valid = false;
			loc = filename.IndexOf(@"<");
			if(loc > 0)
				valid = false;
			loc = filename.IndexOf(@">");
			if(loc > 0)
				valid = false;
			loc = filename.IndexOf(@"*");
			if(loc > 0)
				valid = false;
			return valid;
		}


	}
}
