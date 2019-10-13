using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.AvalonEdit;
using System.Windows;
using System.Windows.Media;
using static Albert.Standard.Win32.ColorUtility;
using System.Windows.Input;

namespace amFlowDoczBase.Controls
{
	public class CodeBox: TextEditor
	{
		public CodeBox()
		{
			//Default Background
			Background = BrushFromString("#222222");
			//Default Foregrond
			Foreground = BrushFromString("#ffffff");
			//Default Font Size 
			FontSize = 30;
			//Default Font Family 
			FontFamily = new FontFamily("Courier New");
			ShowLineNumbers = true;




		}


		/// <summary>
		/// Quick way to add a Coomamand to the control
		/// </summary>
		/// <param name="_command"></param>
		/// <param name="_method"></param>
		public void AddCommand(ICommand _command, ExecutedRoutedEventHandler _method)
		{
			CommandBindings.Add(new CommandBinding(_command, _method));
		}
	}
}
