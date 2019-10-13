using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static Albert.Standard.Win32.QuickAnimation;
namespace Albert.Standard.Win32
{
	public class ShowEventArgs : RoutedEventArgs
	{

		public void AnimateOpacity(UIElement _el, double _from,double _to, double _seconds)
		{
			//Create the Animation 
			RunDouble(_el, "Opacity",_from,_to,TimeSpan.FromSeconds(_seconds));
		}

		/// <summary>
		/// Gets or sets the Opacity 
		/// </summary>
		public double  Opacity { get; set; }
		/// <summary>
		/// Gets or sets the Visibility 
		/// </summary>
		public Visibility Visibility { get; set; }
	}
}
