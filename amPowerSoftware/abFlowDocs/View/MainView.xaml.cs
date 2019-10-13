using Albert.Standard.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using abCommand;
namespace abFlowDocs.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Shell
    {
        //StartFlow 
        StartFlow startFlow;
        public MainView()
        {
            InitializeComponent();

            
            //Do the Logic 
            Logic();
        }
        /// <summary>
        /// Create the Logic to do 
        /// </summary>
        public override void OnLogic()
        {
            //Setup ViewModel 
            var vm = (DocViewModel)App.Current.Resources["viewModel"];

            vm.VMTab = tab;
            
            //StartView 
            startFlow = new StartFlow(tab);
            
            //Start View Command 
            AddCommand(DesktopCommands.StartView, (sender, e) =>
             {
                
             });
        }



    }
}
