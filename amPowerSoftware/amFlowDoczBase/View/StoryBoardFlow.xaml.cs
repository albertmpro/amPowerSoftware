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
using amFlowDoczBase.Controls;
namespace amFlowDoczBase.View
{
    /// <summary>
    /// Interaction logic for StoryBoardFlow.xaml
    /// </summary>
    public partial class StoryBoardFlow : ThemeScreen
    {
        public StoryBoardFlow(TabControl _tab)
        {
            InitializeComponent();

            //Setup your TabITem 
            SetupTab($"Count{Count++}", _tab, () =>
              {
                  TabItem.RemoveTab();
              });
        }
    }
}
