using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Albert.Standard.Win32
{
	[TemplatePart(Name = "PART_TextBox", Type = typeof(TextBox))]
	[TemplatePart(Name = "PART_TextBlock", Type = typeof(TextBlock))]
	public class TextField : Control
	{
		TextBox txt = new TextBox();
		TextBlock tb = new TextBlock();
		
		public TextField()
		{
			//Redraw the Template 
			DefaultStyleKey = typeof(TextField);
		}
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			//Link to the TextBox 
			txt = GetTemplateChild("PART_TextBox") as TextBox;
			//Link to the TextBlock
			tb = GetTemplateChild("PART_TextBlock") as TextBlock;

		

		}

		//public event TextChangedEventHandler TextChanged;


		#region Dependency Properites

		//Header Margin 
		public static readonly DependencyProperty HeaderMarginProperty = DependencyProperty.Register("HeaderMargin", typeof(Thickness), typeof(TextField));
		//TextBox Margin 
		public static readonly DependencyProperty TextBoxMarginProperty = DependencyProperty.Register("TextBoxMargin", typeof(Thickness), typeof(TextField));
		//Header Fourground 
		public static readonly DependencyProperty HeaderForegroundProperty = DependencyProperty.Register("HeaderForeground", typeof(Brush), typeof(TextField), new PropertyMetadata(Brushes.Black));

		//TextBox Height Property
		public static readonly DependencyProperty TextBoxHeightProperty = DependencyProperty.Register("TextBoxHeight", typeof(double), typeof(TextField));

		//Text Property
		public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(TextField));
		//HeaderText Property
		public static readonly DependencyProperty HeaderTextProperty = DependencyProperty.Register("HeaderText", typeof(string), typeof(TextField));
		//Header FontFamily
		public static readonly DependencyProperty HeaderFontFamilyProperty = DependencyProperty.Register("HeaderFontFamily", typeof(FontFamily), typeof(TextField));
		//Header FontSize
		public static readonly DependencyProperty HeaderFontSizeProperty = DependencyProperty.Register("HeaderFontSize", typeof(double), typeof(TextField));
		//Header FontWeight
		public static readonly DependencyProperty HeaderFontWeightProperty = DependencyProperty.Register("HeaderFontWeight", typeof(FontWeight), typeof(TextField));

		#endregion


		#region Public Properties 

		public Thickness HeaderMargin
		{
			get { return (Thickness)GetValue(HeaderMarginProperty); }
			set { SetValue(HeaderMarginProperty, value); }
		}

		public Thickness TextBoxMargin
		{
			get { return (Thickness)GetValue(TextBoxMarginProperty); }
			set { SetValue(TextBoxMarginProperty, value); }
		}
		public Brush HeaderForeground
		{
			get { return (Brush)GetValue(HeaderForegroundProperty); }
			set { SetValue(HeaderForegroundProperty, value); }
		}

		public double TextBoxHeight
		{
			get { return (double)GetValue(TextBoxHeightProperty); }
			set { SetValue(TextBoxHeightProperty, value); }
		}

		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}
		public string HeaderText
		{
			get { return (string)GetValue(HeaderTextProperty); }
			set { SetValue(HeaderTextProperty, value); }
		}
		public FontFamily HeaderFontFamily
		{
			get { return (FontFamily)GetValue(HeaderFontFamilyProperty); }
			set { SetValue(HeaderFontFamilyProperty, value); }
		}
		public double HeaderFontSize
		{
			get { return (double)GetValue(HeaderFontSizeProperty); }
			set { SetValue(HeaderFontSizeProperty, value); }
		}

		public FontWeight HeaderFontWeight
		{
			get { return (FontWeight)GetValue(HeaderFontWeightProperty); }
			set { SetValue(HeaderFontWeightProperty, value); }
		}









		#endregion

		public void SelectAll()
		{
			txt.SelectAll();
			
		}


	}
}
