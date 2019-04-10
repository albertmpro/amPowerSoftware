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
using tk = Xceed.Wpf.Toolkit;
using Albert.Standard.Win32;
namespace amDevFl.View
{
	/// <summary>
	/// Interaction logic for WriterFlow.xaml
	/// </summary>
	public partial class WriterFlow : FlowDoc
	{
		Writer writer; 
		public WriterFlow(TabControl _tab)
		{
			InitializeComponent();

			writer = new Writer();
			writer.SpellCheck.IsEnabled = true;

			//Create a new TabItem 
			TabItem = new DocumentTabItem($"WriterDocument{Count++}", true, this, _tab);
			
			//TabItem Closed Method 
			TabItem.Closed += (sender, e) =>
			{
				//Create a and show a Message Box
				var msg = tk.MessageBox.Show("Do you want to close this tab?", "Closing Tab", MessageBoxButton.YesNo);

				switch(msg)
				{
					case MessageBoxResult.Yes:
						TabItem.RemoveTab();
						break;
					case MessageBoxResult.No:
						// Do nothing 
						break;
				}
			};

			//Add the grid contnet 
			SingleGrid(gridContent, writer);

			//Focus 
			TabItem.Focus();
			writer.Focus();


		}
	}
}
