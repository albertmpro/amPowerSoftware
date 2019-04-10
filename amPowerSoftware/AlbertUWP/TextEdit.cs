using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.ViewManagement;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.System;
using Windows.UI.Text;
using Windows.UI.Xaml.Documents;

namespace Albert.Standard.Runtime
{
	/// <summary>
	/// A special RichEditBox that allows tabs for coding. 
	/// </summary>
	public class TextEdit:RichEditBox
	{

		public static readonly DependencyProperty AcceptsTabProperty = DependencyProperty.Register("AcceptsTab", typeof(bool), typeof(TextEdit), new PropertyMetadata(true)); 

		public TextEdit()
		{
			AcceptsReturn = true;
		


			//Adds the Tab function 
			KeyDown += (sender, e) =>
				{
					
					if (e.Key == VirtualKey.Tab)
					{
						if(AcceptsTab == true)
						{
							
							if (this != null)
							{
								Document.Selection.TypeText("\t");
								e.Handled = true;
							}
						}
					}
				


				};
		}


		public bool AcceptsTab
		{
			get {return (bool)GetValue(AcceptsTabProperty);}
			set { SetValue(AcceptsTabProperty, value); }

		}




		public string StringText
		{
			get
			{
				var rv = ""; 
				Document.GetText(TextGetOptions.None, out rv);
				return rv;
			}
		}

	}
}
