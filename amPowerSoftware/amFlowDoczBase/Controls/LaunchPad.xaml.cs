using amFlowDoczBase.View;
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

namespace amFlowDoczBase.Controls
{
	/// <summary>
	/// Main Launch Pad for the Application 
	/// </summary>
	public partial class LaunchPad : FlowScreen
	{
		public LaunchPad()
		{
			InitializeComponent();
		}

		void hyperlink_Click(object sender, RoutedEventArgs e)
		{
			var link = sender as Hyperlink;

			switch(link.Tag)
			{
				case "Text":
					//Create New Code File 
					var text = new TextFlow(VM.VMTab);
					text.Focus();
                    VM.Message("Created a new TextFlow File");
					break;
				case "Ink":
					var ink = new InkFlow(VM.VMTab);
					ink.Focus();
                    VM.Message("Created a new InkFlow File");
                    break;
				case "Msg":
					var msg = new MsgFlow(VM.VMTab);
					msg.Focus();
                    VM.Message("Created a new MSGFlow File");
                    break;
                case "Storyboard":
                    //Storyboard 
                    var story = new StoryBoardFlow(VM.VMTab);
                    story.Focus();
                    VM.Message("Created a new Storyboard File");

                    break;
              
			}

		}

	}
}
