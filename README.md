# PSBT
Project Source Backup Tool is a project that I started before I learned of version control, it was my way of backing up code once I was finished with a version.  Compressed files could be saved using any manner of naming convention, therefore keeping a type of source control and allowing the user to backup their projects routinely.

## Project Source Backup Tool features

- supports profiles so you don't have to enter the same information again and again
- removes debug and release folders to save space
- uses WINDOWS(TM) shell compression, so there's no need for (other) third party compression tools.

### What's New in Version 1.4.1
 - fixing a bug when profile name has an underscore
 - created a website, in aspnetcore3.1
 - updated to run on win10, needed an application manifest

### What's New in Version 1.4

- added new cmdLine option /file to save project profiles to file instead of registry
- changed about box layout to include softpedia award
- changed some reporting text on status bar panel

### What's New in Version 1.3

- allowed version number to pull from assembly, instead of setting in multiple places 
- added check for valid folders in source and destination 
- added check for overwrite file, with message to instruct user how to rename file automatically 
- added a chm help file 
- added check of help file before loading 
- added check for locations before attempting to rename file 
- added check for zipfile in project location, was causing endless loop 
- changed some messages to match the actual events more 
- changed null file and debug/release removal to separate loops 
- changed the Browse For Folder dialog for the Project location to not show the 'New Folder' Button 
- changed title on confirm dialog when closing program 
- changed installer to msi file 
