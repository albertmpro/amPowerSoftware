using Albert.Standard.Win32;
using amFlowDoczBase.Controls;
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

namespace amFlowDoczBase.View
{
    /// <summary>
    /// Interaction logic for WebNoteFlow.xaml
    /// </summary>
    public partial class WebNoteFlow : FlowScreen
    {
        public WebNoteFlow(TabControl _tab)
        {
            InitializeComponent();

            TabItem = new DocumentTabItem($"WebNote{Count++}", this, _tab);
            


            TabItem.Focus();
            webView.Focus();
        }
    }
}
