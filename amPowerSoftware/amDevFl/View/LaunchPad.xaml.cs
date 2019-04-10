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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace amDevFl.View
{
	/// <summary>
	/// Interaction logic for LaunchPad.xaml
	/// </summary>
	public partial class LaunchPad : UserControl
	{
		//ViewModel 
		FlowViewModel vm;
		public LaunchPad()
		{
			InitializeComponent();
			vm = (FlowViewModel)App.Current.Resources["viewModel"];
		}
		 
		void hyp_Click(object sender, RoutedEventArgs e )
		{
			var link = sender as Hyperlink;

			switch(link.Tag)
			{
				case "Code":
					var code = new CodeFlow(vm.VMTab);
					break;
				case "Writer":
					var writer = new WriterFlow(vm.VMTab);
					break;
				case "Ink":

					break;
				case "Msg":
					var msg = new WebMsgFlow(vm.VMTab);

					break;
				case "Browser":
					var browser = new BrowserFlow(vm.VMTab);
					break;
			}
		}
	}
}
