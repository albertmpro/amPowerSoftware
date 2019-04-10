using Albert.Standard.Win32;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using Microsoft.Toolkit.Wpf.UI.Controls;
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
using tk = Xceed.Wpf.Toolkit;
namespace amDevFl.View
{
	/// <summary>
	/// Interaction logic for BrowserFlow.xaml
	/// </summary>
	public partial class BrowserFlow : FlowDoc 
	{
		//Field's 
		WebView webView;
		CodeEditor notes;
		public BrowserFlow(TabControl _tab)
		{
			InitializeComponent();

			//Init the Grid Content 
			InitGridContent();


			//Create a new TabItem 
			TabItem = new DocumentTabItem($"Browser{Count++}", true, this, _tab);

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

			//Focus 
			TabItem.Focus();
			webView.Focus();
		}

		void InitGridContent()
		{

			#region WebView
			//Create the webView
			webView = new WebView();
			webView.NavigationStarting += webView_NavigationStarting;
			webView.NavigationCompleted += webView_NavigationCompleted;

			//Lamba for if a new window is requested 
			webView.NewWindowRequested += (sender, e) =>
			{
				var navstring = e.Uri.OriginalString;

				//Navigate that string 
				Navigate(navstring);

			};
			#endregion

			#region Notes 
			notes = new CodeEditor();
			#endregion

		}
		//Navigation method 
		public void Navigate(string _url)
		{
			if (_url.StartsWith("http://"))
			{
				webView.Navigate(_url);
			}
			else
			{
				//Change the beging of the string 
				var nstr = $"http://{_url}";
				//Navigate 
				webView.Navigate(nstr);
			}








		}

		void btn_click(object sender, RoutedEventArgs e)
		{
			var push = sender as PushButton;



			switch (push.Tag)
			{
				case "Go": //Navigation 
						   //Start the Navigation 
					Navigate(txtUrl.Text);
					break;
				case "Refresh": //Refresh 
					webView.Refresh();
					break;
			}

		}

		private void webView_NavigationStarting(object sender, WebViewControlNavigationStartingEventArgs e)
		{

		}

		private void webView_NavigationCompleted(object sender, WebViewControlNavigationCompletedEventArgs e)
		{
			txtUrl.Text = webView.Source.ToString();
		}



		private void txtUrl_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				Navigate(txtUrl.Text);
			}
		}

		void txtUrl_GotFocus(object sender, RoutedEventArgs e)
		{
			txtUrl.SelectAll();
		}



		void txtUrl_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
		{
			txtUrl.SelectAll();
		}
	}
}
