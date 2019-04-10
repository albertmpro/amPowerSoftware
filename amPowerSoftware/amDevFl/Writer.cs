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

using tk = Xceed.Wpf.Toolkit;
namespace amDevFl
{ 
    public class Writer: TextBox 
    {
		public Writer()
		{
			var vm = (TextViewModel)App.Current.Resources["textViewModel"];
			DataContext = vm;

			#region Commands 

			// New Command 
			void New_Command(object sender, ExecutedRoutedEventArgs e)
			{
				// Create and show the Message Box 
				var msg = tk.MessageBox.Show("Do you want to create a new document?", "New Document", MessageBoxButton.YesNo);

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
				vm.OpenText(Text,CurrentFile,FileInfo,TabItem);

			}

			// Save Command 
			void Save_Command(object sender, ExecutedRoutedEventArgs e)
			{
				vm.SaveText(Text, CurrentFile, FileInfo, TabItem);
			}

			// Save As Command 
			void SaveAs_Command(object sender, ExecutedRoutedEventArgs e)
			{
				vm.SaveAsText(Text, CurrentFile, FileInfo, TabItem);
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

