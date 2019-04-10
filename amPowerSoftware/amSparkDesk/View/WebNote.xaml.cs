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
using Albert.Standard.Win32;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using tk = Xceed.Wpf.Toolkit;
using static amSparkDesk.SparkViewModel;
using Microsoft.Toolkit.Wpf.UI.Controls;

namespace amSparkDesk.View
{

	/// <summary>
	/// Interaction logic for WebNote.xaml
	/// </summary>
	public partial class WebNote : DevDoc
	{
		WebView webView;


		public WebNote(TabControl _tab)
		{
			InitializeComponent();

			//Create the WebView 
			webView = new WebView();
			
			//Link Events 
			webView.NavigationCompleted += webView_NavigationCompleted;
			webView.NavigationStarting += webView_NavigationStarting;
			webView.NewWindowRequested += webView_NewWindowRequested;

			

			//Setup Default View 
			SingleGrid(gridContent, webView);

			//Set the Default link 
			



			//Create a new TabItem 
			TabItem = new DocumentTabItem($"WebNote{Count++}", true, this, _tab);
			
			//Set the Focus 
			TabItem.Focus();
			txtUrl.Focus();

			//Close TabMethod 
			TabItem.Closed += (sender, e) =>
			 {
				 //Message Box Dialog 
				 var msg = tk.MessageBox.Show("Do you want to close this WebNote?", "Closing", MessageBoxButton.YesNo );
				 tk.MessageBox m;
				
				 
				 switch(msg)
				 {
					 case MessageBoxResult.Yes:
						 //Remove the TabItem 
						 TabItem.RemoveTab();
						 break;
					 case MessageBoxResult.No:
						 //Do nothing 
						 break;
				 }
			 };
			//Navigate to home page
			Navigate("http://albertmpro.github.io");


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
				case "Back":
					//Go Back one 
					webView.GoBack();
					break;
				case "Notes":

				
					break;
				case "Ink":
					//Show the Window
					quickInk.Show();


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

		private void webView_NewWindowRequested(object sender, WebViewControlNewWindowRequestedEventArgs e)
		{
			var link = e.Uri.OriginalString;
			//Stay on the same Tab 
			Navigate(link);
		}
	}
}
