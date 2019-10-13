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
using Albert.Standard.Win32;
using static Albert.Standard.Win32.Win32IO;
using amFlowDoczBase.Controls;
using System.IO;

namespace amFlowDoczBase.View
{
	/// <summary>
	/// Interaction logic for CodeFlow.xaml
	/// </summary>
	public partial class CodeFlow : FlowScreen 

	{
		public CodeFlow(TabControl _tab)
		{
			InitializeComponent();
			//Commands 
			cmdMethods();

			//Create the Tab Item 
			TabItem = new DocumentTabItem($"CodeFile{Count++}", this, _tab);

            //Close Lamba 
            TabItem.Closed += (sender, e) =>
            {
                txtDialog.Show("Close Tab", "Do you want to close This Text Document?", "Close", "Cancel", () =>
                {
                    TabItem.RemoveTab();
                });
            };
            //Focus
            TabItem.Focus();
			txt.Focus();
		}

		public CodeFlow(string _fn, TabControl _tab)
		{
			InitializeComponent();
			//Commands
			cmdMethods();

			//Load Text File 
			txt.Text = LoadText(_fn);
			FileInfo = new FileInfo(_fn);

			//Create TabItem 
			TabItem = new DocumentTabItem(FileInfo.Name, this, _tab);
            //Close Lamba 
            TabItem.Closed += (sender, e) =>
             {
                 txtDialog.Show("Close Tab", "Do you want to close this Text Document?", "Close", "Cancel", () =>
                     {
                         TabItem.RemoveTab();
                     });
             };

			//Focus
			TabItem.Focus();
			txt.Focus();
		}

        void cmdMethods()
        {
            //StartView 
            AddCommand(DesktopCommands.StartView, (sender, e) =>
            {
                //Go to the Start View
                VM.VMTab.SelectedIndex = 0;
            });

			//New Command 
			AddCommand(ApplicationCommands.New, (sender, e) =>
			{

				//Create a blank documnet 
				txt.Text = "";
			});

			//Open Command 
			AddCommand(ApplicationCommands.Open, (sender, e) =>
			{
				//Load text  file Command 
				VM.LoadTextFile(txt,TabItem,FileInfo);
			});

			//Save Command 
			AddCommand(ApplicationCommands.Save, (sender, e) =>
			{
				//Save TextFile
				VM.SaveTextFile(txt,TabItem,FileInfo);
			});

            AddCommand(DesktopCommands.SaveAs, (sender, e) =>
            {
                //Save TextFile
                VM.SaveTextFile(txt,TabItem,FileInfo);
            });
        }

		void Slide_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			var slide = sender as Slider;
			try
			{
				switch (slide.Tag)
				{
					case "Font":
						var nf = e.NewValue;
						txt.FontSize = nf;
						break;
				}
			}
			catch
			{

			}

		}
	}
}

