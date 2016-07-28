using System;

namespace sourceBackup
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Class1
	{
		public Class1()
		{
			//
			// TODO: Add constructor logic here
			//

			RegistryKey profileLocation = Registry.CurrentUser;
			string location =   @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer";
			RegistryKey storage = profileLocation.OpenSubKey(location);
					
			object currentShellState = storage.GetValue("ShellState");
			// this value is the current shell state (ie: whether to show the confirm file delete dialog or not)
			System.Array array = (System.Array)currentShellState;
			string ShellStateString = "";
			foreach(byte a in array)
			{
				ShellStateString += a.ToString();
			}
			WriteLog("On = " + ShellStateString);
			// set the confirmation dialog byte
			array.SetValue(Convert.ToByte('>'),4);
			// reconvert to an 'object'
			object modifiedShellState = (object)array;
			// write the new value to log for testing
			ShellStateString = "";
			foreach(byte a in array)
			{
				ShellStateString += a.ToString();
			}
			WriteLog("Off = " + ShellStateString);

			// write the registry value
			storage.SetValue("ShellState", modifiedShellState);
			//MessageBox.Show(ShellStateString,"Current Shell State", MessageBoxButtons.OK, MessageBoxIcon.Information);

			///delete the file
			item.InvokeVerb("Delete");

			// reset the shell state to the original
			storage.SetValue("ShellState", currentShellState);

		}
	}
}
