using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace Albert.Standard.Runtime
{
	public  class OptionButton : RadioButton
	{
		public OptionButton()
		{
			//Redraw the UI 
			this.DefaultStyleKey = typeof(OptionButton);
		}

		#region Dedenency Properties

		public static readonly DependencyProperty NavStringProperty =
DependencyProperty.Register("NavString", typeof(string), typeof(OptionButton), null);


		public static readonly DependencyProperty ImgOpacityProperty =
DependencyProperty.Register("ImgOpacity", typeof(double), typeof(OptionButton), null);

		public static readonly DependencyProperty OptionVisibilityProperty =
DependencyProperty.Register("OptionVisibility", typeof(Visibility), typeof(OptionButton), null);

		public static readonly DependencyProperty BackgroundPointerOverProperty =
DependencyProperty.Register("BackgroundPointerOver", typeof(Brush), typeof(OptionButton), null);

		public static readonly DependencyProperty BorderBrushPointerOverProperty =
DependencyProperty.Register("BorderBrushPointerOver", typeof(Brush), typeof(OptionButton), null);

			
		public static readonly DependencyProperty ForegroundPointerOverProperty =
	DependencyProperty.Register("ForegroundPointerOver", typeof(Brush), typeof(OptionButton), null);

		public static readonly DependencyProperty SourceProperty =
	DependencyProperty.Register("Source", typeof(ImageSource), typeof(OptionButton), null);

		public static readonly DependencyProperty StretchProperty =
	DependencyProperty.Register("Stretch", typeof(Stretch), typeof(OptionButton), null);


		public static readonly DependencyProperty BackgroundCheckedProperty =
	DependencyProperty.Register("BackgroundChecked", typeof(Brush), typeof(OptionButton), null);


		public static readonly DependencyProperty ForegroundCheckedProperty =
	DependencyProperty.Register("ForegroundChecked", typeof(Brush), typeof(OptionButton), null);

		public static readonly DependencyProperty BorderBrushCheckedProperty =
	DependencyProperty.Register("BorderBrushChecked", typeof(Brush), typeof(OptionButton), null);

		public static readonly DependencyProperty CornerRadiusProperty =
	DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(OptionButton), null);
		#endregion

		#region Public Properties

		public string NavString
		{
			get { return (string)GetValue(NavStringProperty); }
			set { SetValue(NavStringProperty, value); }
		}


		public double ImgOpacity
		{
			get { return (double)GetValue(ImgOpacityProperty); }
			set { SetValue(ImgOpacityProperty, value); }
		}
		public Brush BorderBrushPointerOver
		{
			get { return (Brush)GetValue(BorderBrushPointerOverProperty); }
			set { SetValue(BorderBrushPointerOverProperty, value); }
		}
		public Brush BackgroundPointerOver
		{
			get { return (Brush)GetValue(BackgroundPointerOverProperty); }
			set { SetValue(BackgroundPointerOverProperty, value); }
		}
		public Brush ForegroundPointerOver
		{
			get { return (Brush)GetValue(ForegroundPointerOverProperty); }
			set { SetValue(ForegroundPointerOverProperty, value); }
		}
		public Visibility OptionVisibility
		{
			get { return (Visibility)GetValue(OptionVisibilityProperty); }
			set { SetValue(OptionVisibilityProperty, value); }
		}

		public Brush BackgroundChecked
		{
			get { return (Brush)GetValue(BackgroundCheckedProperty); }
			set { SetValue(BackgroundCheckedProperty, value); }
		}
		public Brush ForegroundChecked
		{
			get { return (Brush)GetValue(ForegroundCheckedProperty); }
			set { SetValue(ForegroundCheckedProperty, value); }
		}
		public Brush BorderBrushChecked
		{
			get { return (Brush)GetValue(BorderBrushCheckedProperty); }
			set { SetValue(BorderBrushCheckedProperty, value); }
		}
		public CornerRadius CornerRadius
		{
			get { return (CornerRadius)GetValue(CornerRadiusProperty); }
			set { SetValue(CornerRadiusProperty, value); }
		}
		public ImageSource Source
		{
			get { return (ImageSource)GetValue(SourceProperty); }
			set { SetValue(SourceProperty, value); }
		}
		public Stretch Stretch
		{
			get { return (Stretch)GetValue(StretchProperty); }
			set { SetValue(StretchProperty, value); }
		}
		#endregion


	}
}
