using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
namespace Albert.Standard.Win32
{
	/// <summary>
	/// Basic Window for doing MVVM applicatoins 
	/// </summary>
	public class ViewShell : Window
	{
		/// <summary>
		/// Sends a message to the Application 
		/// </summary>
		/// <param name="_message">String Message</param>
		protected virtual void OnNotification(string _message)
		{

		}
	}
}
