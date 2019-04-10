using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Albert.Standard.Win32;
using static amSparkDesk.SparkViewModel;
using static System.Windows.MessageBox;
namespace amSparkDesk.View
{
	/// <summary>
	/// Interaction logic for MainView.xaml
	/// </summary>
	public partial class MainView : ViewShell
	{
		//Feild's
		TabView tab;
		//LaunchView launch;
		SparkViewModel viewModel = (SparkViewModel)App.Current.Resources["viewModel"];
			
		public MainView()
		{
			InitializeComponent();

			//Command Logic 
			Commands();
			// Create the TabVIew 
			tab = new TabView();
			//Launch View 
			//launch = new LaunchView();

			//Link Launch and Tab View to the View model 
			VMTabView = tab;
			//VMLaunchView = launch;
			//Setup VMShell  
			viewModel.VMShell = this;
			//SetuAp the ViewMod[[ VMFrame 
			
			VMFrame = frame;
			//Naviga++te Frame to the TabView-
			VMFrame.Navigate(tab);
			
		

	

		}
		
		void Commands()
		{
			//StartView 
			
			//New item Logic 
			void New_Command(object sender, ExecutedRoutedEventArgs e)
			{
				//Go to the Start Tab 
				VMTab.SelectedIndex = 0;
			   
			}

			void Open_Command(object sender, ExecutedRoutedEventArgs e)
			{

			}
			void About_Command(object sender, ExecutedRoutedEventArgs e)
			{
				//Show the About Window 
				winAbout.Show();
			}

			void Exit_Command(object sender, ExecutedRoutedEventArgs e)
			{
				//Close the Window 
				Close();
			}

			//Link Commands to Application 
			CommandBindings.Add(new CommandBinding(DesktopCommands.StartView, New_Command));
			CommandBindings.Add(new CommandBinding(ApplicationCommands.New, New_Command));
			CommandBindings.Add(new CommandBinding(ApplicationCommands.Open, Open_Command));
			CommandBindings.Add(new CommandBinding(DesktopCommands.Quit
				, Exit_Command));
			CommandBindings.Add(new CommandBinding(DesktopCommands.About, About_Command));


		}
	


		}
}
