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
using System.Windows.Navigation;
using System.Windows.Shapes;
using abFlowDocs.Controls;
namespace abFlowDocs.View
{
    /// <summary>
    /// Interaction logic for StartFlow.xaml
    /// </summary>
    public partial class StartFlow : FlowDoc
    {
        public StartFlow(TabControl _tab)
        {
            InitializeComponent();

            SetupTab("StartPage", false, _tab);
        }

        //Clink Method for the Hyperlinks 
        void hyper_Click(object sender, RoutedEventArgs e)
        {
            var hyper = sender as Hyperlink;

            switch (hyper.Tag)
            {
                case "Text":
                    var text = new TextFlow(VM.VMTab);
                    text.Focus();
                    break;
                case "Artboard":
                    var artboard = new ArtFlow(VM.VMTab);
                    artboard.Focus();
                    break;
                case "Msg":

                    break;
            }

                    
        }


    }
}
