using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Albert.Standard.Runtime.AsyncIO;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace Albert.Standard.Runtime
{
	/// <summary>
	/// Base Class for doing ViewModel's with Windows App's or Windows Phone App's
	/// </summary>
	public abstract class ViewModel : Notify
	{
		#region Suggested Static Method  

		//public static void VMNavigate(Type _page)
		//{
		//Navigate to the Frame 
		//VMFrame?.Navigate(_page);

		//Close the Pane View of the Application 
		//if (VMSplitView != null)
		//VMSplitView.IsPaneOpen = false;
		//}


		//public static Action<string> VMNotify; 


		//public static Frame VMFrame { get; set; }

		//public static SplitView VMSplitView { get; set; }




		#endregion

		public ApplicationDataContainer Settings { get; } = ApplicationData.Current.LocalSettings;

		public StorageFolder LocalFolder { get; } = ApplicationData.Current.LocalFolder;

	}
}
