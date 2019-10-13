using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Albert.Standard.Runtime
{
	/// <summary>
	/// Special Event for the Screen 
	/// </summary>
	public class ScreenEventArgs : RoutedEventArgs
	{

		public ScreenEventArgs()
		{
			//Do nothing 
		}

		public ScreenEventArgs(Screen _screen)
		{
			_screen.Visibility = Visibility;
		}
		/// <summary>
		/// Get or set the Visibility of the Event
		/// </summary>
		public Visibility Visibility { get; set; }
	}
}
