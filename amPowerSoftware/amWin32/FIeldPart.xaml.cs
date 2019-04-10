using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace amWin32
{
    public sealed partial class FieldPart : UserControl
    {
		//Field's 
		string filter;

		public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(string), typeof(FieldPart), new PropertyMetadata("Header", (sender, e) =>
		{
			var cp = sender as FieldPart;

			// Grab the tb Header 
			cp.tbHeader.Text = (string)e.NewValue;


		}));

		public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(FieldPart), new PropertyMetadata("", (sender, e) =>
		{
			var cp = sender as FieldPart;

			// Grab the Code.Text 
			cp.txtContent.Text = (string)e.NewValue;


		}));

		public static readonly DependencyProperty FilterProperty = DependencyProperty.Register("Filter", typeof(string), typeof(FieldPart), new PropertyMetadata("All Files(.)|*.*", (sender, e) =>
		{
			var cp = sender as FieldPart;

			// Grab the Code.Text 
			cp.filter = (string)e.NewValue;


		}));

		public FieldPart()
        {
            this.InitializeComponent();
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
