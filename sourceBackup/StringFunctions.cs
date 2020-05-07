using System;
using System.Collections.Generic;
using System.Text;

namespace sourceBackup
{
    public sealed class StringFunctions
    {

		/// <summary>
		/// Written by AC Nicholls
		/// This procedure searches for Windows(tm) 'illegal' filename characters
		/// As the folders entered are chosen via a GUI, there's no way to enter illegal folder names,
		/// but the filename is chosen by the use and so this procedure.
		/// </summary>
		/// <param name="filename">inputs the string to search for illegal characters</param>
		/// <returns>a boolean value representing the validity of the filename, false is invalid</returns>
		public static  bool CheckForInvalidChars(string filename)
		{

			bool valid = true;
			int loc;

			loc = filename.IndexOf(@"""");
			if (loc > 0)
				valid = false;
			loc = filename.IndexOf(@"\");
			if (loc > 0)
				valid = false;
			loc = filename.IndexOf(@"?");
			if (loc > 0)
				valid = false;
			loc = filename.IndexOf(@"|");
			if (loc > 0)
				valid = false;
			loc = filename.IndexOf(@"/");
			if (loc > 0)
				valid = false;
			loc = filename.IndexOf(@":");
			if (loc > 0)
				valid = false;
			loc = filename.IndexOf(@"<");
			if (loc > 0)
				valid = false;
			loc = filename.IndexOf(@">");
			if (loc > 0)
				valid = false;
			loc = filename.IndexOf(@"*");
			if (loc > 0)
				valid = false;
			return valid;
		}

	}
}
