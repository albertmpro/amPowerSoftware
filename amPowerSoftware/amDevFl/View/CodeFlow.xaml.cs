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
using tk = Xceed.Wpf.Toolkit;

namespace amDevFl.View
{
	/// <summary>
	/// Interaction logic for CodeFlow.xaml
	/// </summary>
	public partial class CodeFlow : FlowDoc
	{
		//Code editor's 
		CodeEditor code;
		
		public CodeFlow(TabControl _tab)
		{
			InitializeComponent();

			//Create the TabItem 
			TabItem = new DocumentTabItem($"CodeDocument{Count++}",true,this,VM.VMTab);
			//TabItem Closed Method 
			TabItem.Closed += (sender, e) =>
			{
				//Create a and show a Message Box
				var msg = tk.MessageBox.Show("Do you want to close this tab?", "Closing Tab", MessageBoxButton.YesNo);

				switch (msg)
				{
					case MessageBoxResult.Yes:
						TabItem.RemoveTab();
						break;
					case MessageBoxResult.No:
						// Do nothing 
						break;
				}
			};



			code = new CodeEditor();
		
			
			//Single Code View 
			SingleGrid(gridContent, code);

			//Set the Focus 
			TabItem.Focus();
			code.Focus();
			
		}


	}

	
}
