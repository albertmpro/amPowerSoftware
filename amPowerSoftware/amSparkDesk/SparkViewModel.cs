using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Controls;
using Albert.Standard.Win32;
using System.Xml.Linq;
using static System.Convert;
using static Albert.Standard.Core;
using System.Windows;

using amSparkDesk.View;
using static amSparkDesk.SparkViewModel;
namespace amSparkDesk
{
	/// <summary>
	/// Main ViewModel of the Application 
	/// </summary>
	public class SparkViewModel : ViewModel
	{
		//static WRViewModel wr = (WRViewModel)App.Current.Resources["wrViewModel"];
		string notes;
		public SparkViewModel()
		{
			
			
		}
		public void SaveSettings()
		{
			// Create a root xml tree
			var saveroot = new XElement("settings");
			//Save the Window State  
			var winstate = new XElement("winstate", VMShell.WindowState);
			//Save the Notes 
			//VMNotes = VMTabView.writer.Text;
			var vmnotes = new XElement("notes", VMNotes);

			//Put the document together
			saveroot.Add(winstate,vmnotes);

			//Save your settings to a file to be reloaded
			saveroot.Save("settings.xml");
		}

		public void LoadSettings()
		{
			if (File.Exists("settings.xml"))
			{
				
				var loadroot = XElement.Load("settings.xml");

				var winstate = loadroot.Element("winstate").Value;
				var notes = loadroot.Element("notes").Value; 
				VMShell.WindowState = ConvertEnum<WindowState>(winstate);
				VMNotes = notes;

			}
		}

		public static void VMTabNavigate()
		{
			
			
			//Go to the TabView
			VMFrame.Navigate(VMTabView);
		
		}

		
		public string VMNotes
		{
			get { return notes; }
			set
			{
				notes = value;
				OnPropertyChanged("VMNotes");
			}
		}


		/// <summary>
		/// Get or set the Curent WIndow 
		/// </summary>
		public ViewShell VMShell { get; set; }
		/// <summary>
		/// Gets or sets the VMTabControl
		/// </summary>
		public static TabControl VMTab { get; set; }
		/// <summary>
		/// Gets or sets the VMFrame
		/// </summary>
		public static Frame VMFrame { get; set; }
		



		public static TabView VMTabView { get; set; }
		
		
		/// <summary>
		///  Notifcation method
		/// </summary>
		public static Action<string> VMNotify;
	}

}
