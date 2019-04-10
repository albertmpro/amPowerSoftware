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

using static amSparkDesk.SparkViewModel;
namespace amSparkDesk.View
{
	/// <summary>
	/// Interaction logic for LaunchPad.xaml
	/// </summary>
	public partial class LaunchPad : UserControl
	{
		public LaunchPad()
		{
			InitializeComponent();
		}

		void hyp_Click(object sender, RoutedEventArgs e)
		{
			var hyp = sender as Hyperlink; 
			switch(hyp.Tag)
			{
				case "NewCode":
					//Create a new Code Document 

					var code = new CodeView(VMTab);
					code.Focus();

					break;
				case "NewWriter":
					//Create a new Writer Document 

					var writer = new WriterView(VMTab);
					writer.Focus();
					break;
				case "NewFontLab":
					//Create a new FontLab
					var font = new FontExplore(VMTab);
					//Go to the TabView 
				
					font.Focus();
					break;
				case "NewInk":
					//Create new ink object
					var ink = new InkProject(VMTab);
					ink.Focus();
					break;
				case "NewMsg":
					//Create a new WebMsg 
					var msg = new WebMsg(VMTab);
					
					
					msg.Focus();
					break;
				case "NewNote":
					//Create new WebNote
					var note = new WebNote(VMTab);
					//Focus on the WebNote
					note.Focus();
					break;
			}
		}

	}
}
