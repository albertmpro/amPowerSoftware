using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
namespace Albert.Standard.Win32
{
	/// <summary>
	/// A list of my Personal Commands 
	/// </summary>
	public static class DesktopCommands
	{
		private static readonly RoutedUICommand runconsole, export, startview, about, options, saveas, quit, zoomin, zoomout,clear,snips;

		static DesktopCommands()
		{

			runconsole = new RoutedUICommand("RunConsole", "Runconsole", typeof(DesktopCommands));
			runconsole.InputGestures.Add(new KeyGesture(Key.D, ModifierKeys.Control, "Ctrl+D"));
			//Export Comand 
			export = new RoutedUICommand("Export", "Export", typeof(DesktopCommands));
			export.InputGestures.Add(new KeyGesture(Key.E, ModifierKeys.Control, "Ctrl+E"));
			//StartView Command
			startview = new RoutedUICommand("StartView", "StartView", typeof(DesktopCommands));
			startview.InputGestures.Add(new KeyGesture(Key.N, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+N"));

			//About Command
			about = new RoutedUICommand("About", "About", typeof(DesktopCommands));
			about.InputGestures.Add(new KeyGesture(Key.A, ModifierKeys.Alt, "Alt+A"));

			//SaveAs Command 
			saveas = new RoutedUICommand("SaveAs", "SaveAs", typeof(DesktopCommands));
			saveas.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+S"));

			//Quit Commmand
			quit = new RoutedUICommand("Quit", "Quit", typeof(DesktopCommands));
			quit.InputGestures.Add(new KeyGesture(Key.Q, ModifierKeys.Control, "Ctrl+Q"));

			zoomin = new RoutedUICommand("ZoomIn", "ZoomIn", typeof(DesktopCommands));
			zoomin.InputGestures.Add(new KeyGesture(Key.OemPlus, ModifierKeys.Control, "Ctrl+"));

			zoomout = new RoutedUICommand("ZoomOut", "ZoomOut", typeof(DesktopCommands));
			zoomout.InputGestures.Add(new KeyGesture(Key.OemMinus, ModifierKeys.Control, "Ctrl-"));

			
			//Snip Command
			snips = new RoutedUICommand("Snips", "Snips", typeof(DesktopCommands));
			snips.InputGestures.Add(new KeyGesture(Key.Space, ModifierKeys.Control));

			
		
			
		}
		/// <summary>
		/// Get RunConsole Command
		/// </summary>
		public static RoutedUICommand RunConsole
		{
			get { return runconsole; }
		}
		/// <summary>
		/// Get the Export Command
		/// </summary>
		public static RoutedUICommand Export
		{
			get { return export; }
		}
		/// <summary>
		/// Get the snips command
		/// </summary>
		public static RoutedUICommand Snips
		{
			get { return snips; }
		}

	/// <summary>
	/// Get the StartView Commands
	/// </summary>
		public static RoutedUICommand StartView
		{
			get
			{
				return startview;
			}
		}

		public static RoutedUICommand Options
		{
			get
			{
				return options;
			}
		}

		public static RoutedUICommand About
		{
			get
			{
				return about;
			}
		}
		/// <summary>
		/// Get the Save As Command
		/// </summary>
		public static RoutedUICommand SaveAs
		{
			get
			{
				return saveas;
			}

		}
		/// <summary>
		/// Get the Quit Command 
		/// </summary>
		public static RoutedUICommand Quit
		{
			get
			{
				return quit;
			}
		}

		public static RoutedUICommand ZoomIn
		{
			get
			{
				return zoomin;
			}
		}

		public static RoutedUICommand ZoomOut
		{
			get
			{
				return zoomout;
			}
		}


		public static RoutedUICommand Clear
		{
			get
			{
				return clear;
			}
		}
	}
}
