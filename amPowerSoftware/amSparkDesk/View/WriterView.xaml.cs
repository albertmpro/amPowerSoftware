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
namespace amSparkDesk.View
{
	/// <summary>
	/// Interaction logic for WriterView.xaml
	/// </summary>
	public partial class WriterView : DevDoc
	{
		public WriterView(TabControl _tab)
		{
			InitializeComponent();

			//Create a new TabItem 
			TabItem = new DocumentTabItem($"WriterDocument{Count++}", true, this, _tab);
			TabItem.Focus();
		}
	}
}
