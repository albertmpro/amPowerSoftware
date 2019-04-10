using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
namespace Albert.Standard.Win32
{

	/// <summary>
	/// Designed to be on on screan control for preforming task wucickly 
	/// </summar
	public class DialogControl : ADock
	{

		/// <summary>
		/// Default Constructor 
		/// </summary>
		public DialogControl()
		{
			DefaultStyleKey = typeof(DialogControl);
		}

		public event Action OnShow;
		public event Action OnHide;




		/// <summary>
		/// Method to hide dialog
		/// </summary>
		public void Hide()
		{
			//Excute On Hide Event
			OnHide?.Invoke();
			Visibility = Visibility.Collapsed;
		}/// <summary>
		/// Method to show dialog 
		/// </summary>
		public void Show()
		{
			//Excute the OnSHow 
			OnShow?.Invoke();
			this.Visibility = Visibility.Visible;
		}
	}
}
