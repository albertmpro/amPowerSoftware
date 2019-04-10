using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Albert.Standard.Runtime
{
	/// <summary>
	/// A Special ContnetDialog designed to work better with the page 
	/// </summary>
	public class SettingsDialog: ContentDialog
	{
		/// <summary>
		/// Event is for the First Button
		/// </summary>
		public event Action OnFirstButton;
		/// <summary>
		/// Event is for the Second Button 
		/// </summary>
		public event Action OnSecondButton;

		public void FirstButtonAction()
		{
		
			//Execute the event if not null
			OnFirstButton?.Invoke();
			
		}


		public void SecondButtonAction()
		{
			//Execute the event if not null
			OnSecondButton?.Invoke();
			
		}





	}
}
