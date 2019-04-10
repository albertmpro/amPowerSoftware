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

namespace amWin32
{
	/// <summary>
	/// Interaction logic for ContentPart.xaml
	/// </summary>
	public partial class ContentPart : UserControl
	{
		//Field's 
		string filter; 

		public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(string), typeof(ContentPart), new PropertyMetadata("Header", (sender, e) =>
		{
			var cp = sender as ContentPart;

			// Grab the tb Header 
			cp.tbHeader.Text = (string)e.NewValue;


		}));

		public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(ContentPart), new PropertyMetadata("", (sender, e) =>
		{
			var cp = sender as ContentPart;

			// Grab the Code.Text 
			cp.txtContent.Text = (string)e.NewValue;


		}));

		public static readonly DependencyProperty FilterProperty = DependencyProperty.Register("Filter", typeof(string), typeof(ContentPart), new PropertyMetadata("All Files(.)|*.*", (sender, e) =>
		{
			var cp = sender as ContentPart;

			// Grab the Code.Text 
			cp.filter = (string)e.NewValue;


		}));


		public ContentPart()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets or sets the Header above the code 
		/// </summary>
		public string Header
		{
			get { return (string)GetValue(HeaderProperty); }
			set { SetValue(HeaderProperty, value); }
		}
		/// <summary>
		/// Gets or sets the Text that is used and saved
		/// </summary>
		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}
		/// <summary>
		/// Gets or sets the File Format that will be used 
		/// </summary>
		public string Filter
		{
			get { return (string)GetValue(FilterProperty); }
			set { SetValue(FilterProperty, value); }
		}


	}
}
