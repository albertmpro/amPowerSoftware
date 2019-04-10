using Albert.Standard.Win32;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
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

namespace amSparkDesk.View
{
	/// <summary>
	/// Interaction logic for Browser.xaml
	/// </summary>
	public partial class Browser : DevDoc
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="_tab"></param>
		/// <param name="_url"></param>
		public Browser(TabControl _tab,string _url)
		{
			InitializeComponent();
			TabItem = new DocumentTabItem(_url, true, this, _tab);

			//Focus 
			TabItem.Focus();
			txtUrl.Focus();
			Navigate(_url);
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

		void btn_click(object sender, RoutedEventArgs e )
		{
			var push = sender as PushButton;

			

			switch(push.Tag)
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
			if(e.Key == Key.Enter)
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
