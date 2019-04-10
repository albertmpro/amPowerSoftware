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
using amDevFl.Properties;
namespace amDevFl.View
{
	/// <summary>
	/// Interaction logic for MainView.xaml
	/// </summary>
	public partial class MainView : Window
	{
		FlowViewModel vm;
		public MainView()
		{
			InitializeComponent();

			//Link to the Default ViewModel 
			vm = (FlowViewModel)App.Current.Resources["viewModel"];

			//Linke tabControl to the VMTab
			vm.VMTab = tabControl;

			//Gets the default settings of the Application
			var settings = Settings.Default;

			//Method for Closing the window 
			Closed += (sender, e) =>
			{
				
				//Get the Window State
				settings.WindowState = WindowState;

				settings.Save();

			};


			//Method for opeing a window 
			Loaded += (sender, e) =>
			{
				//Set the WindowState 
				WindowState = settings.WindowState;
			};
				

		}
	}
}
