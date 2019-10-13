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
using amFlowDoczBase.Controls;
using static Albert.Standard.Win32.MediaCv;
namespace amFlowDoczBase.View
{
	/// <summary>
	/// Interaction logic for MainView.xaml
	/// </summary>
	public partial class MainView : FlowShell
	{

        TabPage tabPage;

		public MainView()
		{
            InitializeComponent();

            //Setup your main ViewModel 
            setupViewModel();

            //Setup your Message System 
            setupMessage();

            VM.Message("Welcome to amFlowDocz");
	
		}

        void setupMessage()
        {
            //inner void 
            void msg(string _str)
            {
                tbStatus.Text = _str;
               
                //Do Quick Animation 
                NotifyHide(tbStatus, 5.3);
            }

            VM.Message = msg;
        }

        /// <summary>
        /// Method Sets up your Main ViewModel for the Shell WIndow 
        /// </summary>
        void setupViewModel()
        {
            //Link to ViewModel Frame 
            VM.VMFrame = frame;
            //Setup the TabPage 
            tabPage = new TabPage();

            //Link to TabPage on the ViewModel 
            VM.TabPage = tabPage;

            //Setup Main TabControl 
            VM.VMTab = VM.TabPage.tab;


            //Navigate to TabPage 
            VM.NavigateTabPage();
        }

		
	}
}
