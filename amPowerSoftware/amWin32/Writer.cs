using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Input;
using static System.IO.File;
using System.Windows;
using System.Windows.Controls;
using Albert.Standard.Win32;
using static Albert.Standard.Win32.Win32IO;
using static System.Windows.MessageBox;
using static amSparkDesk.SparkViewModel;

namespace amWin32
{ 
    public class Writer: TextBox 
    {
		public Writer()
		{
			#region Commands 

			// New Command 
			void New_Command(object sender, ExecutedRoutedEventArgs e)
			{
				// Create and show the Message Box 
				var msg = Show("Do you want to create a new document?", "New Document", MessageBoxButton.YesNo);

				switch (msg)
				{
					case MessageBoxResult.Yes:

						//Create a new document 
						Text = "";


						break;
					default:
						// Do Nothing 
						break;
				}


			}

			// Open Command 
			void Open_Command(object sender, ExecutedRoutedEventArgs e)
			{
				//OpenDialog Lamba  
				OpenDialogTask("Open Text FIle", Filter, (o) =>
				{

					//Define the FIle Info 
					FileInfo = new FileInfo(o.FileName);

					//Define the Current File 
					CurrentFile = o.FileName;

					//Update your TabItem 
					TabItem.Header = FileInfo.Name;
					//Load the File 
					Text = ReadAllText(CurrentFile);
					
					//Send message to the Applcatio 
					VMNotify($"You have opened {FileInfo.Name} in the {FileInfo.DirectoryName} directory.");

				});

			}

			// Save Command 
			void Save_Command(object sender, ExecutedRoutedEventArgs e)
			{
				switch (CurrentFile)
				{
					case null:
						//SaveDialog Lamba Task 
						SaveDialogTask("Save your TextFile", Filter, (s) =>
						{
							// Define the File Info
							FileInfo = new FileInfo(s.FileName);
							// Define the Current File 
							CurrentFile = s.FileName;
							//Write the Text File 
							WriteAllText(CurrentFile, Text);
							//Update tab 
							TabItem.Header = FileInfo.Name;
							//Send message to applicaiton 
							VMNotify($"You have saved {FileInfo.Name} in the {FileInfo.DirectoryName} directory.");
						});
						break;
					default:
						//Write the Text File 
						WriteAllText(CurrentFile, Text);
						//Update your TabItem 
						TabItem.Header = FileInfo.Name;
						//Send message to applicaiton 
						VMNotify($"You have saved {FileInfo.Name} in the {FileInfo.DirectoryName} directory.");
						break;
				}
			}

			// Save As Command 
			void SaveAs_Command(object sender, ExecutedRoutedEventArgs e)
			{
				SaveDialogTask("Save your TextFile", Filter, (s) =>
				{
					// Define the File Info
					FileInfo = new FileInfo(s.FileName);
					// Define the Current File 
					CurrentFile = s.FileName;


					//Write the Text File 
					WriteAllText(CurrentFile, Text);

					//Update your TabItem 
					TabItem.Header = FileInfo.Name;

					//Send message to applicaiton 
					VMNotify($"You have saved {FileInfo.Name} in the {FileInfo.DirectoryName} directory.");
				});
			}


			//Link to the Command Bindinngs 
			//New Command 
			CommandBindings.Add(new CommandBinding(ApplicationCommands.New, New_Command));

			//Open Command 
			CommandBindings.Add(new CommandBinding(ApplicationCommands.Open, Open_Command));

			//Save  Command 
			CommandBindings.Add(new CommandBinding(ApplicationCommands.Save, Save_Command));


			//Save As Command 
			CommandBindings.Add(new CommandBinding(DesktopCommands.SaveAs, SaveAs_Command));

			#endregion
		}
		/// <summary>
		/// Gets or Set the TabItem used
		/// </summary>
		public DocumentTabItem TabItem { get; set; }



		public string Filter { get; set; } = "All Files(.)|*.*";
		/// <summary>
		/// Gets the File info if something is saved 
		/// </summary>
		public FileInfo FileInfo { get; set; }
		/// <summary>
		/// Gets or sets the current file 
		/// </summary>
		public string CurrentFile { get; set; }




	}


}

