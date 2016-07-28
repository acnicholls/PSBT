using System;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.IO;
using Microsoft.Win32;

namespace sourceBackup
{
	/// <summary>
	/// Summary description for frmMain.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtProjectLocation;
		private System.Windows.Forms.TextBox txtBackupLocation;
		private System.Windows.Forms.FolderBrowserDialog fbDialog;
		private System.Windows.Forms.CheckBox chkDebug;
		private System.Windows.Forms.MenuItem mnuMain;
		private System.Windows.Forms.MenuItem mnuExit;
		private System.Windows.Forms.TextBox txtBackupName;
		private System.Windows.Forms.MenuItem mnuHelp;
		private System.Windows.Forms.MenuItem mnuAbout;
		private System.Windows.Forms.Button cmdProjectLocation;
		private System.Windows.Forms.Button cmdBackupLocation;
		private System.Windows.Forms.Button cmdGo;
		private System.Windows.Forms.MainMenu menuMain;
		private System.Windows.Forms.MenuItem mnuContents;
		private static bool debugMode = false;
		private System.Windows.Forms.MenuItem mnuProjectProfiles;
		private System.Windows.Forms.MenuItem mnuSepProjects;
		private System.Windows.Forms.MenuItem mnuProfile;
		public static string[] parts = new string[5];
		private System.Windows.Forms.MenuItem mnuDeleteProfile;
		private System.Windows.Forms.MenuItem mnuSaveProfile;
		private System.Windows.Forms.MenuItem mnuClear;
		private System.Windows.Forms.MenuItem mnuSepMain;
		private System.Windows.Forms.StatusBar sbMainStatusBar;
		public System.Windows.Forms.StatusBarPanel sbMainPanel1;
		private ArrayList removeList = new ArrayList(5);
		private bool CompileFound = false;
		private System.Windows.Forms.Label lblBackupFileName;
		private bool validCompress = true;
		private static bool fileMode = false;
		private System.Windows.Forms.MenuItem miMainDefault;
	 // file/registry boolean
		public string StatusBarText
		{
			get { string send = sbMainPanel1.Text;
					return send;}
			set{ string send = value;
				 sbMainPanel1.Text = send;}
		}
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// DONETODO: Add any constructor code after InitializeComponent call
			//
			// DONETODO: add registry keys that save the backup locations for certain project profiles.
			// DONETODO: re-arrange interface to make better sense
			// DONETODO: autmatic finding of debug and release folders under the current project directory.
			// TODO: have a "backups location" saved to registry
			// DONETODO: add my own compression.
			// DONETODO: contact geralgibson RE: using his compression package.


			// this function writes a log of important info and is useful for debugging

			//DONETODO: replace this with a registry call to the proper location.
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
			this.label1 = new System.Windows.Forms.Label();
			this.txtProjectLocation = new System.Windows.Forms.TextBox();
			this.cmdProjectLocation = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtBackupLocation = new System.Windows.Forms.TextBox();
			this.cmdBackupLocation = new System.Windows.Forms.Button();
			this.cmdGo = new System.Windows.Forms.Button();
			this.fbDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.chkDebug = new System.Windows.Forms.CheckBox();
			this.menuMain = new System.Windows.Forms.MainMenu();
			this.mnuMain = new System.Windows.Forms.MenuItem();
			this.mnuClear = new System.Windows.Forms.MenuItem();
			this.mnuSepMain = new System.Windows.Forms.MenuItem();
			this.mnuExit = new System.Windows.Forms.MenuItem();
			this.mnuProjectProfiles = new System.Windows.Forms.MenuItem();
			this.mnuSaveProfile = new System.Windows.Forms.MenuItem();
			this.mnuDeleteProfile = new System.Windows.Forms.MenuItem();
			this.mnuSepProjects = new System.Windows.Forms.MenuItem();
			this.mnuProfile = new System.Windows.Forms.MenuItem();
			this.mnuHelp = new System.Windows.Forms.MenuItem();
			this.mnuContents = new System.Windows.Forms.MenuItem();
			this.mnuAbout = new System.Windows.Forms.MenuItem();
			this.txtBackupName = new System.Windows.Forms.TextBox();
			this.lblBackupFileName = new System.Windows.Forms.Label();
			this.sbMainStatusBar = new System.Windows.Forms.StatusBar();
			this.sbMainPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.miMainDefault = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.sbMainPanel1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(110, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Project Location:";
			// 
			// txtProjectLocation
			// 
			this.txtProjectLocation.Enabled = false;
			this.txtProjectLocation.Location = new System.Drawing.Point(128, 16);
			this.txtProjectLocation.Name = "txtProjectLocation";
			this.txtProjectLocation.Size = new System.Drawing.Size(544, 20);
			this.txtProjectLocation.TabIndex = 0;
			this.txtProjectLocation.Text = "";
			// 
			// cmdProjectLocation
			// 
			this.cmdProjectLocation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmdProjectLocation.Location = new System.Drawing.Point(680, 16);
			this.cmdProjectLocation.Name = "cmdProjectLocation";
			this.cmdProjectLocation.Size = new System.Drawing.Size(24, 20);
			this.cmdProjectLocation.TabIndex = 1;
			this.cmdProjectLocation.Text = "...";
			this.cmdProjectLocation.Click += new System.EventHandler(this.cmdProjectLocation_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(110, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Backups Location:";
			// 
			// txtBackupLocation
			// 
			this.txtBackupLocation.Enabled = false;
			this.txtBackupLocation.Location = new System.Drawing.Point(128, 48);
			this.txtBackupLocation.Name = "txtBackupLocation";
			this.txtBackupLocation.Size = new System.Drawing.Size(544, 20);
			this.txtBackupLocation.TabIndex = 2;
			this.txtBackupLocation.Text = "";
			// 
			// cmdBackupLocation
			// 
			this.cmdBackupLocation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmdBackupLocation.Location = new System.Drawing.Point(680, 48);
			this.cmdBackupLocation.Name = "cmdBackupLocation";
			this.cmdBackupLocation.Size = new System.Drawing.Size(24, 20);
			this.cmdBackupLocation.TabIndex = 3;
			this.cmdBackupLocation.Text = "...";
			this.cmdBackupLocation.Click += new System.EventHandler(this.cmdBackupLocation_Click);
			// 
			// cmdGo
			// 
			this.cmdGo.Location = new System.Drawing.Point(636, 80);
			this.cmdGo.Name = "cmdGo";
			this.cmdGo.Size = new System.Drawing.Size(69, 23);
			this.cmdGo.TabIndex = 6;
			this.cmdGo.Text = "Backup";
			this.cmdGo.Click += new System.EventHandler(this.cmdGo_Click);
			// 
			// chkDebug
			// 
			this.chkDebug.Location = new System.Drawing.Point(472, 80);
			this.chkDebug.Name = "chkDebug";
			this.chkDebug.Size = new System.Drawing.Size(152, 24);
			this.chkDebug.TabIndex = 5;
			this.chkDebug.Text = "Remove Source Debug?";
			// 
			// menuMain
			// 
			this.menuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.mnuMain,
																					 this.mnuProjectProfiles,
																					 this.mnuHelp});
			// 
			// mnuMain
			// 
			this.mnuMain.Index = 0;
			this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuClear,
																					this.miMainDefault,
																					this.mnuSepMain,
																					this.mnuExit});
			this.mnuMain.Text = "&Main";
			// 
			// mnuClear
			// 
			this.mnuClear.Index = 0;
			this.mnuClear.Text = "&Clear";
			this.mnuClear.Click += new System.EventHandler(this.mnuClear_Click);
			// 
			// mnuSepMain
			// 
			this.mnuSepMain.Index = 2;
			this.mnuSepMain.Text = "-";
			// 
			// mnuExit
			// 
			this.mnuExit.Index = 3;
			this.mnuExit.Text = "E&xit";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// mnuProjectProfiles
			// 
			this.mnuProjectProfiles.Index = 1;
			this.mnuProjectProfiles.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							   this.mnuSaveProfile,
																							   this.mnuDeleteProfile,
																							   this.mnuSepProjects,
																							   this.mnuProfile});
			this.mnuProjectProfiles.Text = "&Projects";
			// 
			// mnuSaveProfile
			// 
			this.mnuSaveProfile.Index = 0;
			this.mnuSaveProfile.Text = "&Save Profile...";
			this.mnuSaveProfile.Click += new System.EventHandler(this.mnuSaveProfile_Click);
			// 
			// mnuDeleteProfile
			// 
			this.mnuDeleteProfile.Enabled = false;
			this.mnuDeleteProfile.Index = 1;
			this.mnuDeleteProfile.Text = "&Delete Profile";
			this.mnuDeleteProfile.Click += new System.EventHandler(this.mnuDeleteProfile_Click);
			// 
			// mnuSepProjects
			// 
			this.mnuSepProjects.Index = 2;
			this.mnuSepProjects.Text = "-";
			// 
			// mnuProfile
			// 
			this.mnuProfile.Index = 3;
			this.mnuProfile.Text = "P&rofiles";
			// 
			// mnuHelp
			// 
			this.mnuHelp.Index = 2;
			this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuContents,
																					this.mnuAbout});
			this.mnuHelp.Text = "&Help";
			// 
			// mnuContents
			// 
			this.mnuContents.Index = 0;
			this.mnuContents.Text = "&Contents";
			this.mnuContents.Click += new System.EventHandler(this.mnuContents_Click);
			// 
			// mnuAbout
			// 
			this.mnuAbout.Index = 1;
			this.mnuAbout.Text = "&About";
			this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
			// 
			// txtBackupName
			// 
			this.txtBackupName.Location = new System.Drawing.Point(128, 80);
			this.txtBackupName.Name = "txtBackupName";
			this.txtBackupName.Size = new System.Drawing.Size(336, 20);
			this.txtBackupName.TabIndex = 4;
			this.txtBackupName.Text = "";
			this.txtBackupName.DoubleClick += new System.EventHandler(this.txtBackupName_DoubleClick);
			// 
			// lblBackupFileName
			// 
			this.lblBackupFileName.Location = new System.Drawing.Point(8, 80);
			this.lblBackupFileName.Name = "lblBackupFileName";
			this.lblBackupFileName.Size = new System.Drawing.Size(112, 23);
			this.lblBackupFileName.TabIndex = 11;
			this.lblBackupFileName.Text = "Backup Filename:";
			// 
			// sbMainStatusBar
			// 
			this.sbMainStatusBar.Location = new System.Drawing.Point(0, 107);
			this.sbMainStatusBar.Name = "sbMainStatusBar";
			this.sbMainStatusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																							   this.sbMainPanel1});
			this.sbMainStatusBar.ShowPanels = true;
			this.sbMainStatusBar.Size = new System.Drawing.Size(714, 24);
			this.sbMainStatusBar.SizingGrip = false;
			this.sbMainStatusBar.TabIndex = 12;
			// 
			// sbMainPanel1
			// 
			this.sbMainPanel1.Width = 720;
			// 
			// miMainDefault
			// 
			this.miMainDefault.Index = 1;
			this.miMainDefault.Text = "&Default Folder...";
			this.miMainDefault.Click += new System.EventHandler(this.miMainDefault_Click);
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(714, 131);
			this.Controls.Add(this.sbMainStatusBar);
			this.Controls.Add(this.txtBackupName);
			this.Controls.Add(this.txtBackupLocation);
			this.Controls.Add(this.txtProjectLocation);
			this.Controls.Add(this.lblBackupFileName);
			this.Controls.Add(this.chkDebug);
			this.Controls.Add(this.cmdGo);
			this.Controls.Add(this.cmdBackupLocation);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cmdProjectLocation);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Menu = this.menuMain;
			this.MinimizeBox = false;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Project Source Backup Tool";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.sbMainPanel1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{


///This is my first attempt at licensing.  
///CODE : c0cbe7cb-23de-4b3c-ac36-627cfd8eef24
///KEY : 9940c1d7-ec41-455a-be84-c5eebd4d811d
/// fff
/// *
/// *
/// In some way the key must unlock the code, allowing the user to continue to run the program, 
/// If it does not, then the program will close.
/// *
/// *
/// my first assumption is that when the KEY has undergone a certian 
/// calculation, then it will match the code?  
/// *
/// second, it could be that using the code to unravel the key 
/// will equal a predefined third set of characters.
/// 
			string stringKey = "9940c1d7-ec41-455a-be84-c5eebd4d811d";
			string stringCode = "c0cbe7cb-23de-4b3c-ac36-627cfd8eef24";
			System.Text.Encoding enc = Encoding.Unicode;
			Security licence = new Security();
			byte[] arrKEY = licence.ConvertKeyStringToByteArray(stringCode);
			string KEYString = licence.ConvertByteArrayToKeyString(arrKEY);
			byte[] arrHASH = licence.GetSHA1Hash(arrKEY);
///  save this for later to put into an if statement on a check against the license file text.
			string[] cmdLine = System.Environment.GetCommandLineArgs();
			if(cmdLine.Length > 1)
			{
				foreach(string option in cmdLine)
				{
					switch(option.ToUpper())
					{
						case "/DEBUG":
						{
							debugMode = true;
							break;
						}
						case "/FILE":
						{
							fileMode = true;
							break;
						}
					}
				}
			}
			
			WriteLog("Entering Main Sequence.");
			string hashedValue = licence.CalculateSHA1(KEYString, enc);
			WriteLog("This is your managed cipher's value?  " + hashedValue);
			WriteLog("This is your managed cipher's length?  " + hashedValue.Length.ToString());
			Application.Run(new frmMain());
		}
		/// <summary>
		/// click here to tell Project Source backup Tool where to find your source location.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdProjectLocation_Click(object sender, System.EventArgs e)
		{
			// find default project location
			RegistryKey profileLocation = Registry.CurrentUser;
			string location =   @"SOFTWARE\acnicholls.com\Project Source Backup Tool\";
			RegistryKey storage = profileLocation.OpenSubKey(location);
			object projectDefault = storage.GetValue("DefaultProjectLocation", null);
			if(projectDefault != null)
				this.fbDialog.SelectedPath = Convert.ToString(projectDefault);
			else
				this.fbDialog.SelectedPath = Application.StartupPath;
			this.fbDialog.Description = "Select the folder containing your source code.";
			this.fbDialog.ShowNewFolderButton = false;
			this.fbDialog.ShowDialog();
			this.txtProjectLocation.Text = this.fbDialog.SelectedPath.ToString();
			if(this.txtBackupLocation.Text.Length > 0)
				NameBackup();
		}
		/// <summary>
		/// click this button to tell Project Source Backup Tool where to put the finished zip file.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdBackupLocation_Click(object sender, System.EventArgs e)
		{
			// find default project location
			RegistryKey profileLocation = Registry.CurrentUser;
			string location =   @"SOFTWARE\acnicholls.com\Project Source Backup Tool\";
			RegistryKey storage = profileLocation.OpenSubKey(location);
			object projectDefault = storage.GetValue("DefaultProjectLocation", null);
			if(projectDefault != null)
				this.fbDialog.SelectedPath = Convert.ToString(projectDefault);
			else
                this.fbDialog.SelectedPath = Application.StartupPath;
			this.fbDialog.Description = "Select the folder in which to place the backup zipfile.  Remember not to select the same folder as the source.";
			this.fbDialog.ShowNewFolderButton = true;
			this.fbDialog.ShowDialog();
			this.txtBackupLocation.Text = this.fbDialog.SelectedPath.ToString();
			if(this.txtProjectLocation.Text.Length > 0)
				NameBackup();
		}

		/// <summary>
		/// this is an internal function to write debug information to a textfile 
		/// if the cmdline option /debug is used.
		/// </summary>
		/// <param name="message"></param>
		private static void WriteLog(string message)
		{
			if(debugMode)
			{
				// this function writes a log of important info and is useful for debugging
				StreamWriter logFile = new StreamWriter(System.Environment.CurrentDirectory + @"\debug.txt",true);
				logFile.WriteLine(DateTime.Now + "    " + message);
				logFile.Flush();
				logFile.Close();   
			}
		}

		/// <summary>
		/// click this button to start the compression process.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdGo_Click(object sender, System.EventArgs e)
		{
			bool valid = true;
			CompileFound = false;
			string source, dest, file;
			validCompress = true;


			if((this.txtProjectLocation.Text.Length <= 0)|(this.txtBackupLocation.Text.Length <= 0)|(this.txtBackupName.Text.Length <= 0))
			{
				MessageBox.Show("Please choose a project to backup", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				valid = false;
			}
			// if all is valid assign it to variables
			source = this.txtProjectLocation.Text.ToString();
			dest = this.txtBackupLocation.Text.ToString();
			file = this.txtBackupName.Text.ToString();
			// check the filename for invalid characters
			if(!CheckForInvalidChars(file))
			{
				// build a message to show the user invalid characters
				string message = "Please enter a Windows(tm) VALID filename.\n";
				message += "Illegal characters are as follows:\n\n";
				message += @" \ , / , : , * , ? , "" , < , > , | ";
				// now show the user the message
				MessageBox.Show(message,"Illegal Filename...");
				// invalidate the setup.
				valid = false;
			}
			// check the source location for spaces
			if(source.IndexOf(" ") != -1)
			{
				//we got a space in the path so wrap it in double qoutes
				source = @"" + txtProjectLocation.Text + "";
			}
			// make sure the destination ends in a backslash
			if(dest.EndsWith(@"\") == false)
			{
				dest += @"\";
			}
			//Make sure the zip file name ends with a zip extension
			if(file.ToUpper().EndsWith(".ZIP") == false)
			{
				file += ".zip";
			}
			// check the destination so for spaces
//			if(dest.IndexOf(" ") != -1)
//			{
//				//we got a space in the path so wrap it in double qoutes
//				dest = "\"" + txtBackupLocation.Text + "\"";
//			}
			// check for valid source folder
			DirectoryInfo checkSource = new DirectoryInfo(source);
			if(!checkSource.Exists)
			{
				MessageBox.Show("Please choose a valid source directory.", "Invalid Directory...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				valid = false;
			}
			// check for valid destination folder
			DirectoryInfo checkDest = new DirectoryInfo(dest);
			if(!checkDest.Exists)
			{
				MessageBox.Show("Please choose a valid destination directory.", "Invalid Directory...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				valid = false;
			}
			// check for valid destination folder
			FileInfo checkDestFile = new FileInfo(dest + @"\" + file);
			if(checkDestFile.Exists)
			{
				DialogResult result = MessageBox.Show("That file already exists, do you wish to overwrite?\n\nHINT: You can double click the filename box to automatically change the filename.", "Existing File...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if(result == DialogResult.No)
				{
					valid = false;
				}
			}
			// that should take care of any potential problems.
			if(valid)
			{
				string message = "Are you sure you wish to backup this project?";
				DialogResult result = MessageBox.Show(message,"Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if(result == DialogResult.Yes)
				{
					// check the debug box
					if(this.chkDebug.Checked == true)
					{
						sbMainPanel1.Text = "Removing Source Debug and Release folders...";
						DirectoryInfo d = new DirectoryInfo(source);
						CompileFound = CheckSubDirs(d);
						if(CompileFound)
						{
							foreach(DirectoryInfo remove in removeList)
							{
								remove.Delete(true);
							}
						}
					}
					// call the compression method...
					CompressionSequence(source,dest,file);
					if(validCompress)
					{
						sbMainPanel1.Text = "Compression Sequence Complete.";
						DialogResult exit = MessageBox.Show("Project Source Backup Complete.  Exit?","Finished...",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
						if(exit == DialogResult.Yes)
							Application.Exit();
						else
							this.mnuClear_Click(this,EventArgs.Empty);
					}
				}
			}
		}


		private void frmMain_Load(object sender, System.EventArgs e)
		{
				LoadProfiles();
		}
		/// <summary>
		/// Once you've entered the information, you can save the 'profile' to your registry for later 
		/// retreival
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mnuProfiles_Click(object sender, System.EventArgs e)
		{
			MenuItem profile = (MenuItem)sender;
			string profileName = profile.Text.ToString();
			parts[0] = profileName;
			if(fileMode)
			{
				// TODO: load and read the correct file
				DirectoryInfo profiles = new DirectoryInfo(System.Environment.CurrentDirectory + @"\Profiles");
				FileInfo profileFile = new FileInfo(profiles.FullName.ToString() + @"\" + profileName.ToString() + ".psbt");
				if(profileFile.Exists)
				{
					try
					{
						StreamReader valueFile = new StreamReader(profileFile.FullName);
						string project = valueFile.ReadLine();
						if(project != null)
							parts[1] = project;	
						else
							parts[1] = "";
						string backup = valueFile.ReadLine();
						if(backup != null)
                            parts[2] = backup;
						else
							parts[2] = "";
						string zipName = valueFile.ReadLine();
						if(zipName != null)
							parts[3] = zipName;
						else
							parts[3] = "";
						string removeDebug = valueFile.ReadLine();
						if(removeDebug != null)
							parts[4] = removeDebug;
						else
							parts[4] = "0";
						// now close the file
						valueFile.Close();
					}
					catch(Exception)
					{
						string message = "There's a problem with your .psbt file, please check it's contents, and re-run the Backup Tool";
						message += "\n";
						message += "\nA PSBT file should have 4 lines only, each containing only the required information as follows:";
						message += "\nLine 1: The Project's Source Location";
						message += "\nLine 2: The Project's Backup Location";
						message += "\nLine 3: The Project's Backup Filename, including the .zip extension";
						message += "\nLine 4: The number 1 to remove debug folders, 0 to leave them as is";

						MessageBox.Show(message, "Invalid Config File", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
	
			}
			else
			{
				RegistryKey profileLocation = Registry.CurrentUser;
				string location =   @"SOFTWARE\acnicholls.com\Project Source Backup Tool\Profiles\" + profileName.ToString();
				RegistryKey storage = profileLocation.OpenSubKey(location.ToString());
				string project = storage.GetValue("ProjectLocation").ToString();
				parts[1] = project;
				string backup = storage.GetValue("BackupLocation").ToString();
				parts[2] = backup;
				string zipName = storage.GetValue("zipName").ToString();
				parts[3] = zipName;
				string debug = storage.GetValue("RemoveDebug").ToString();
				parts[4] = debug;
			}
			if(debugMode)
			{
				string message = "Project: " + parts[1].ToString() + "\n";
				message += "Backup: " + parts[2].ToString() + "\n";
				message += "ZipName: " + parts[3].ToString() + "\n";
				message += "Debug: " + parts[4].ToString() + "\n";
				MessageBox.Show(message);
			}
			this.txtProjectLocation.Text = parts[1].ToString();
			this.txtBackupLocation.Text = parts[2].ToString();
			this.txtBackupName.Text = parts[3].ToString();
			this.chkDebug.Checked = Convert.ToBoolean(Convert.ToInt32(parts[4].ToString()));
			this.mnuDeleteProfile.Enabled = true;
		}

		/// <summary>
		/// to find out more about Project Source Backup Tool, click here.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mnuAbout_Click(object sender, System.EventArgs e)
		{
			frmAbout about = new frmAbout();
			about.ShowDialog(this);
		}
		/// <summary>
		/// Click this menu option when you've entered your project information.  That way it's saved in registry, and 
		/// you won't ever have to enter the information again.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mnuSaveProfile_Click(object sender, System.EventArgs e)
		{
			if((this.txtProjectLocation.Text.Length > 0) & (this.txtBackupName.Text.Length > 0) & (this.txtBackupLocation.Text.Length > 0))
			{
				sbMainPanel1.Text = "Capturing Profile Information...";
				parts[1] = this.txtProjectLocation.Text.ToString();
				parts[2] = this.txtBackupLocation.Text.ToString();
				parts[3] = this.txtBackupName.Text.ToString();
				parts[4] = Convert.ToString(Convert.ToInt32(this.chkDebug.Checked));
				frmProfile profile;
				if(fileMode)
				{
					profile = new frmProfile(parts, true);
				}
				else
				{
					profile = new frmProfile(parts);
				}
				sbMainPanel1.Text = "Please enter a profile name.";
				profile.ShowDialog(this);
				if(parts[0] == "Failed")
					this.sbMainPanel1.Text = "Profile not saved...";
				else
					this.sbMainPanel1.Text = "Profile saved.";
				LoadProfiles();
			}
			else
				MessageBox.Show("Please enter all details for your project before saving a profile.", "Error");
		}
		/// <summary>
		/// click this option to exit the program
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		/// <summary>
		/// click this option if you've selected a profile you'd like to delete.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mnuDeleteProfile_Click(object sender, System.EventArgs e)
		{
			//TODO: set changed[bool] when buttons clicked 
			if(parts[0] == null)
				MessageBox.Show("Please select a profile to erase.");
			else
			{
				DialogResult result = MessageBox.Show("Are you sure you wish to delete the profile: " + parts[0].ToString() + "?", "Delete Profile...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if(result == DialogResult.Yes)
				{
					try
					{
						if(fileMode)
						{
							DirectoryInfo profileDir = new DirectoryInfo(System.Environment.CurrentDirectory + @"\Profiles");
							FileInfo deleteProfile = new FileInfo(profileDir.FullName.ToString() + @"\" + parts[0].ToString() + ".psbt");
							deleteProfile.Delete();
						}
						else
						{
							string remove = parts[0].ToString();
							RegistryKey ProfileLocations = Registry.CurrentUser;
							RegistryKey storage = ProfileLocations.OpenSubKey(@"SOFTWARE\acnicholls.com\Project Source Backup Tool\Profiles", true);
							storage.DeleteSubKey(remove);
						}
					}
					catch(System.Exception x)
					{
						MessageBox.Show(x.Message, "Error");
					}
					finally
					{
						this.mnuClear_Click(this,System.EventArgs.Empty);
						LoadProfiles();
					}
				}
			}
		}

		/// <summary>
		/// click this option if you'd like to clear the form and start over.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mnuClear_Click(object sender, System.EventArgs e)
		{
			WriteLog("Got to mnuClear_Click");
			//DONETODO: Clear the form and declare a new profile array.
			this.chkDebug.Checked = false;
			this.txtBackupLocation.Text = "";
			this.txtBackupName.Text = "";
			this.txtProjectLocation.Text = "";
			this.sbMainPanel1.Text = "";
			for(int key=0;key<=4;key++)
			{
				WriteLog("Parts : " + key.ToString() + " cleared.");
				parts[key] = "";
			}
			this.mnuDeleteProfile.Enabled = false;
		}
		/// <summary>
		/// this is an internal function that formulates the name of the zipfile, using the source location folder name
		/// today's date and time, and the .zip extension.
		/// </summary>
		private void NameBackup()
		{
			if((this.txtBackupLocation.Text.Length > 0) & (this.txtProjectLocation.Text.Length > 0))
			{
				char pad = '0';
				// grab project location
				string backup = this.txtProjectLocation.Text.ToString();
				// split project location into it's many folders
				string[] projectName = backup.Split(Convert.ToChar(@"\"));
				// grab the number of folders deep
				int x = projectName.Length - 1;
				// grab the LAST folder's name and add backup to it
				backup = projectName[x].ToString() + "_Backup";
				// get today's DAY number
				string tempTime = DateTime.Now.Day.ToString();
				// make sure it's 2 characters in length
				if(tempTime.Length < 2)
					tempTime = tempTime.PadLeft(2,pad);
				// add the day to the backup name
				backup += "_" + tempTime;
				// get the MONTH number
				tempTime = DateTime.Now.Month.ToString();
				// make sure it's 2 characters in length
				if(tempTime.Length < 2)
					tempTime = tempTime.PadLeft(2,pad); 
				// add it to the backup name
				backup += tempTime;
				// add the year to the backup name
				backup += DateTime.Now.Year.ToString();
				// get the HOUR number
				tempTime = DateTime.Now.Hour.ToString();
				// make sure it's 2 characters in length
				if(tempTime.Length < 2)
					tempTime = tempTime.PadLeft(2,pad); 
				// add it to the backup name
				backup += "_" + tempTime;
				// get the MINUTE number
				tempTime = DateTime.Now.Minute.ToString(); 
				// make it 2 characters in length
				if(tempTime.Length < 2)
					tempTime = tempTime.PadLeft(2,pad); 
				// add it to the backup name
				backup += tempTime;
				// add the file extension
				backup += ".zip";
				// move this string to the backup text on the GUI.
				this.txtBackupName.Text = backup.ToString();
			}
		}

		/// <summary>
		/// this is an internal function that will load all the profiles you've currently saved to registry when you
		/// load the program.
		/// </summary>
		public void LoadProfiles()
		{
			sbMainPanel1.Text = "Loading Profiles...";
			// clear the current list of profiles
			mnuProfile.MenuItems.Clear();
			if(fileMode)
			{
				// open the folder and load a profileName for each file.
				DirectoryInfo cwd = new DirectoryInfo(System.Environment.CurrentDirectory.ToString() + @"\Profiles");
				if(cwd.Exists)
				{
					FileInfo[] projFile = cwd.GetFiles("*.PSBT");
					foreach(FileInfo profile in projFile)
					{
						string profileName = profile.Name.Substring(0,profile.Name.Length - 5);
						this.mnuProfile.MenuItems.Add(profileName, new System.EventHandler(this.mnuProfiles_Click));
					}
				}
			}
			else
			{
				// Load saved profiles from registry.
				RegistryKey hive = Registry.CurrentUser;
				RegistryKey storage = hive.OpenSubKey(@"SOFTWARE\acnicholls.com\Project Source Backup Tool\Profiles\",false);
				if(storage != null)
				{
					string[] profiles = storage.GetSubKeyNames();
					foreach(string profile in profiles)
					{
						this.mnuProfile.MenuItems.Add(profile, new System.EventHandler(this.mnuProfiles_Click));
					}
				}
			}
			sbMainPanel1.Text = "Ready.";
		}

		/// <summary>
		/// this is an internal function that checks to see if there are debug or release folders when the user
		/// requests for the source ones to be removed.
		/// </summary>
		/// <param name="d"></param>
		/// <returns></returns>
		private bool CheckSubDirs(DirectoryInfo d) 
		{ 
			try
			{
				// Add subdirectories.
				int x = d.GetDirectories().Length;
				if ( x > 0)
				{
					DirectoryInfo[] dis = d.GetDirectories();
					foreach (DirectoryInfo di in dis) 
					{
						if((di.Name == "Debug")|(di.Name == "Release"))
						{
							removeList.Add(di);
							CompileFound = true;
							continue;							
						}
						else
						{
							int y;
							try
							{
								y = di.GetDirectories().Length;
							}
							catch(System.UnauthorizedAccessException)
							{
								continue;
							}
							if (y > 0)
							{
								CheckSubDirs(di);
							}
						}
					}
				}
			}
			catch(System.Exception e)
			{
				string message =  e.Message;
				MessageBox.Show(message, "Error", MessageBoxButtons.OK);
			}
			return CompileFound;

		}

		/// <summary>
		/// Main compression sequence, many thanks to GeraldGibson.net
		/// slightly modified to send messages to the user via the status bar
		/// and to remove the debug and release project folders from the backup 
		/// in order to save space in the zip.
		/// </summary>
		private void CompressionSequence(string source, string destination, string fileName)
		{
			try
			{
				//Create an empty zip file
				byte[] emptyzip = new byte[]{80,75,5,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};

				FileStream fs = File.Create(destination + fileName);
				fs.Write(emptyzip, 0, emptyzip.Length);
				fs.Flush();
				fs.Close();
				fs = null;

				//Copy a folder and its contents into the newly created zip file
				Shell32.ShellClass sc = new Shell32.ShellClass();
				Shell32.Folder SrcFlder = sc.NameSpace(source);
				Shell32.Folder DestFlder = sc.NameSpace(destination + fileName); 
				//Shell32.FolderItems items = SrcFlder.Items();

				//All of the _DELETE_ME_ stuff is because Windows pops up a 
				//message box about empty folders not being able to be added
				//to zip folders. So we make the folders NOT empty by adding
				//the _DELETE_ME_ files before the copy into zip folder
				//and then remove the _DELETE_ME_ files afterwards from the
				//source folder structure and from the zip file
			
			

				//Add _DELETE_ME_ file to each empty folder
				AddNULLFiles(source);
				//The '3' version of FolderItems has a method called Filter
				//Filter allows you to demand that hidden files also be included in the list
				//I ran into this because I was ziping visual studio project directories
				//which have hidden files that were not being counted but were being copied
				//which caused an infinite loop below at the for( ; ; )
				//Actually SOME hidden files were being copied into the zip and some were not
				//So I am passing the '3' version of FolderItems into the CopyHere method also
				//which seemed to force it to include all hidden files in the copy
				//This resulted in the number of files in the source and the destination
				//zip to be equal as soon as the zip process is finished.
				Shell32.Folder3 DestFlder3 = (Shell32.Folder3)sc.NameSpace(source);
				Shell32.FolderItems3 items3 = (Shell32.FolderItems3)DestFlder3.Items();
				int SHCONTF_INCLUDEHIDDEN = 128;
				int SHCONTF_FOLDERS = 32;
				int SHCONTF_NONFOLDERS = 64;
				//"*" == all files
				items3.Filter(SHCONTF_INCLUDEHIDDEN | SHCONTF_NONFOLDERS | SHCONTF_FOLDERS, "*");

				//System.Windows.Forms.MessageBox.Show("sdf");
				this.sbMainPanel1.Text = "Check for Invalid files...";
				// added by acnicholls
				DebugFileList(SrcFlder);

				//We know when the zip process is complete by checking
				//the number of files in the original source location
				//with the number of files in the zip folder
				//When they are equal we are done.

				//Count the number of FolderItems in the original source location
				int OriginalItemCount = RecurseCount3(items3);
				//Start the ziping
				DestFlder.CopyHere((Shell32.FolderItems3)items3,1024);
				//Timeout period... if the compression is not done within this time
				//limit then the zip.exe shuts down and the ziping is stoped
				DateTime timeoutDeadline = DateTime.Now.AddMinutes(5);
				//Wait until the ziping is done.
				this.sbMainPanel1.Text = "Executing Compression Sequence.";

				for( ;; )
				{
					//Are we past the deadline?
					if(DateTime.Now > timeoutDeadline)
					{
						break;
					}

					//Check the number of items in the new zip to see if it matches
					//the number of items in the original source location

					//Only check the item count every 5 seconds
					System.Threading.Thread.Sleep(5000);
					this.sbMainPanel1.Text += ".";
					int ZipFileItemCount = RecurseCount(DestFlder.Items());
					WriteLog("Source File Count: " + OriginalItemCount.ToString() + "  >>  Destination File Count: " + ZipFileItemCount.ToString());
					if(OriginalItemCount == ZipFileItemCount)
					{
						break;
					}

				}	
			
				this.sbMainPanel1.Text = "Deleting Null files from source.";
				//Remove all _DELETE_ME_ files from the source
				DeleteNULLFiles(SrcFlder.Items());

				//Remove all _DELETE_ME_ files from the zip file

				//First create a zip_temp folder where the zip.exe is at so we can
				//cut paste from the zip folder into this zip_temp folder
				Shell32.Folder MoveToFolder = sc.NameSpace(AppDomain.CurrentDomain.BaseDirectory);
				MoveToFolder.NewFolder("zip_temp", 0);

				Shell32.FolderItem TempFolder = null;

				//Find the zip_temp folder
				foreach(Shell32.FolderItem item in MoveToFolder.Items())
				{
					if(item.Name == "zip_temp")
					{
						TempFolder = item;
					}
				}
				DeleteNULLFilesFromZip(DestFlder.Items(), TempFolder);
			}
			catch(System.InvalidOperationException)
			{
				string message = "There is a zipFile in your project location.";
				message += "\nThis will cause a failure in the compression routine.";
				message += "\nPlease remove this file before continuing.";
				MessageBox.Show(message, "Invalid File Type...", MessageBoxButtons.OK, MessageBoxIcon.Warning);

			}
			catch(System.IO.FileNotFoundException)
			{
				MessageBox.Show("An important file is missing, please reinstall the application.", "Missing file...", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}
		}

		/// <summary>
		/// This void removes all temporary files in the zip_temp..
		/// </summary>
		private void DeleteNULLFilesFromZip(Shell32.FolderItems Source, Shell32.FolderItem TempFolder)
		{
			Shell32.ShellClass sc = new Shell32.ShellClass();
			
			//for each file that we find with the name _DELETE_ME_ cut and
			//paste it into the TempFolder
			foreach(Shell32.FolderItem item in Source)
			{
				this.sbMainPanel1.Text = "Removing Null files.";
				if(item.IsFolder == true)
				{ 
					DeleteNULLFilesFromZip(((Shell32.Folder)item.GetFolder).Items(), TempFolder);
				}
				else
				{ 
					if(item.Name == "_DELETE_ME_")
					{
						//If there is already a file there by that name then delete it
						if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + "zip_temp\\_DELETE_ME_") == true)
						{
							File.Delete(AppDomain.CurrentDomain.BaseDirectory + "zip_temp\\_DELETE_ME_");
						}						
						//Move file out of zip
						item.InvokeVerb("Cut");
						this.sbMainPanel1.Text += ".";
						TempFolder.InvokeVerb("Paste");						
					}
				}
			}
			foreach(Shell32.FolderItem item in Source)
			{
				this.sbMainPanel1.Text = "Removing Debug or Release Folder Contents.";

				// added by acnicholls
				// if it's a folder and it's name is debug or release
				// remove from zip to save space in zipfile.
				// only files are removed, directory structure stays...
				if(item.IsFolder & ((item.Name == "Debug") | (item.Name == "Release")))
				{
					//Directory.Delete(item.Path,true);
					item.InvokeVerb("Cut");
					this.sbMainPanel1.Text += ".";
					TempFolder.InvokeVerb("Paste");
				}
			}



			//Once that is all done remove all files from the zip_temp folder
			//and then delete the zip_temp folder
			if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + "zip_temp\\_DELETE_ME_") == true)
			{
				File.Delete(AppDomain.CurrentDomain.BaseDirectory + "zip_temp\\_DELETE_ME_");
			}

			//Delete the zip_temp folder
			if(Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "zip_temp") == true)
			{
				Directory.Delete(AppDomain.CurrentDomain.BaseDirectory + "zip_temp", true);
			}
		}




		//Add _DELETE_ME_ files to each empty folder
		private void AddNULLFiles(string CurrentDir)
		{
			//add A NULL file to empty dirs
			string[] files=System.IO.Directory.GetFiles(CurrentDir,"*.*");
			//Now recurse to sub dirs
			string[] subdirs=System.IO.Directory.GetDirectories(CurrentDir);
			foreach( string dir in subdirs)
			{
				AddNULLFiles(dir);
			}
			if((files.Length==0)&&(subdirs.Length==0))
			{
				FileStream fs = File.Create(CurrentDir+"\\_DELETE_ME_");
				fs.Close();
				fs = null;
			}
		}
		
		//Remove all _DELETE_ME_ files from all folders
		private void DeleteNULLFiles(Shell32.FolderItems Source)
		{
			foreach(Shell32.FolderItem item in Source)
			{
				this.sbMainPanel1.Text += ".";
				if(item.IsFolder == true)
				{ 
					DeleteNULLFiles(((Shell32.Folder)item.GetFolder).Items());
				}
				else
				{ 
					if(item.Name.EndsWith("_DELETE_ME_"))
					{
						System.IO.File.Delete(item.Path);
					}
				}
			}
		}

		//Get the number of files and folders in the source location
		//including all subfolders
		private static int RecurseCount(Shell32.FolderItems Source)
		{
			int ItemCount = 0;

			foreach(Shell32.FolderItem item in Source)
			{
				if(item.IsFolder == true)
				{
					//Add one for this folder
					ItemCount++;
					//Then continue walking down the folder tree
					ItemCount += RecurseCount(((Shell32.Folder)item.GetFolder).Items());					
				}
				else
				{					
					//Add one for this file
					ItemCount++;					
				}
			}

			return ItemCount;
		}

		//Get the number of files and folders in the source location
		//including all subfolders and hidden files
		private static int RecurseCount3(Shell32.FolderItems3 Source)
		{
			int ItemCount = 0;

			foreach(Shell32.FolderItem item in Source)
			{
				if(item.IsFolder == true)
				{
					//Add one for this folder
					ItemCount++;
					Shell32.FolderItems3 items3 = (Shell32.FolderItems3)((Shell32.Folder3)item.GetFolder).Items();
					int SHCONTF_INCLUDEHIDDEN = 128;
					int SHCONTF_FOLDERS = 32;
					int SHCONTF_NONFOLDERS = 64;
					items3.Filter(SHCONTF_INCLUDEHIDDEN | SHCONTF_NONFOLDERS | SHCONTF_FOLDERS, "*");
					//Then continue walking down the folder tree
					ItemCount += RecurseCount3(items3);					
				}
				else
				{					
					//Add one for this file
					ItemCount++;					
				}
			}

			return ItemCount;
		}

		private void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			DialogResult result = MessageBox.Show("Are you sure you wish to exit?", "Confirm Exit...", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if(result == DialogResult.Yes)
				Application.Exit();
			else
				e.Cancel = true;				
		}

		/// <summary>
		/// double clicking the zip file name text box will rename the file using the current date and time.  This allows a useer to save everything 
		/// to registry then rename the file after reloading from registry.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtBackupName_DoubleClick(object sender, System.EventArgs e)
		{
			int x = this.txtProjectLocation.Text.Length;
			int y = this.txtBackupLocation.Text.Length;
			if(x>0 && y>0)
			{
				NameBackup();
			}
			else
			{
				MessageBox.Show("Please select locations before trying to name your backup file.", "Invalid input...", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	
		/// <summary>
		/// this brings up the help file.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mnuContents_Click(object sender, System.EventArgs e)
		{
			string filelocation = Application.StartupPath + @"\Help\PrjSrcBckupToolHelp.chm";
			FileInfo check = new FileInfo(filelocation);
			if(check.Exists)
			{
				WriteLog("Attempting to load helpfile: " + filelocation);
				Help.ShowHelp(this, filelocation);
			}
			else
			{
				MessageBox.Show("Your help file is missing, please re-run the installer.", "Missing help file...", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		/// <summary>
		/// Written by AC Nicholls
		/// This procedure searches for Windows(tm) 'illegal' filename characters
		/// As the folders entered are chosen via a GUI, there's no way to enter illegal folder names,
		/// but the filename is chosen by the use and so this procedure.
		/// </summary>
		/// <param name="filename">inputs the string to search for illegal characters</param>
		/// <returns>a boolean value representing the validity of the filename, false is invalid</returns>
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

		private void DebugFileList(Shell32.Folder Source)
		{
			try
			{
				foreach(Shell32.FolderItem item in Source.Items())
				{

					if(item.IsFolder == true)
					{
						WriteLog("Folder : " + item.Name);
						DebugFileList((Shell32.Folder)item.GetFolder);
					}
					else
					{					
						//Add one for this file
						if(item.Name.IndexOf(".zip") > 0)
						{
							Exception x = new System.InvalidOperationException();
							throw x;
						}
						WriteLog("    " + item.Name);
					}
				}
			}
			catch(System.InvalidOperationException)
			{
				string message = "There is a ZIP file in your project folder.";
				message += "\nPlease remove it before continuing.";
				MessageBox.Show(message,"Invalid File Type...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				validCompress = false;
			}


		}

		private void miMainDefault_Click(object sender, System.EventArgs e)
		{
			this.fbDialog.Description = "Select the folder to use as default project folder.";
			DialogResult result = this.fbDialog.ShowDialog(this);
			if(result == DialogResult.OK)
			{
				// set registry entry for default folder.
				RegistryKey profileLocation = Registry.CurrentUser;
				string location =   @"SOFTWARE\acnicholls.com\Project Source Backup Tool\";
				RegistryKey storage = profileLocation.CreateSubKey(location);
				storage.SetValue("DefaultProjectLocation",fbDialog.SelectedPath.ToString());
			}
		}




	}
}
