using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
namespace Albert.Standard.Runtime
{
	public class Screen : ContentControl
	{

		public event Action<ScreenEventArgs> OnShow; 

		public event Action<ScreenEventArgs> OnHide;

		/// <summary>
		/// Quick Method to show the Screen 
		/// </summary>
		public void Show()
		{
			var args = new ScreenEventArgs(this);

			if (OnShow != null)
			{
				OnShow.Invoke(args);
				Visibility = Visibility.Visible;
			}
			else
			{
				Visibility = Visibility.Visible;
			}
		}
		/// <summary>
		/// Quick method to Hide the Screen
		/// </summary>
		public void Hide()
		{
			var args = new ScreenEventArgs(this);
			if (OnHide != null)
			{
				OnHide.Invoke(args);
				Visibility = Visibility.Collapsed;
			}
			else
			{
				Visibility = Visibility.Collapsed;
			}

		}
	}
}
