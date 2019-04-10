using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
namespace Albert.Standard.Runtime
{
	public class CheckButton: CheckBox
	{
		public CheckButton()
		{
			DefaultStyleKey = typeof(CheckButton);
		}


		#region Dedenency Properties



		public static readonly DependencyProperty ImgOpacityProperty =
DependencyProperty.Register("ImgOpacity", typeof(double), typeof(CheckButton), null);


		public static readonly DependencyProperty BackgroundPointerOverProperty =
DependencyProperty.Register("BackgroundPointerOver", typeof(Brush), typeof(CheckButton), null);


		public static readonly DependencyProperty ForegroundPointerOverProperty =
	DependencyProperty.Register("ForegroundPointerOver", typeof(Brush), typeof(CheckButton), null);

		public static readonly DependencyProperty BorderBrushPointerOverProperty =
DependencyProperty.Register("BorderBrushPointerOver", typeof(Brush), typeof(CheckButton), null);

		public static readonly DependencyProperty BorderBrushCheckedProperty =
DependencyProperty.Register("BorderBrushChecked", typeof(Brush), typeof(CheckButton), null);

		public static readonly DependencyProperty SourceProperty =
	DependencyProperty.Register("Source", typeof(ImageSource), typeof(CheckButton), null);

		public static readonly DependencyProperty StretchProperty =
	DependencyProperty.Register("Stretch", typeof(Stretch), typeof(CheckButton), null);


		public static readonly DependencyProperty BackgroundCheckedProperty =
	DependencyProperty.Register("BackgroundChecked", typeof(Brush), typeof(CheckButton), null);


		public static readonly DependencyProperty ForegroundCheckedProperty =
	DependencyProperty.Register("ForegroundChecked", typeof(Brush), typeof(CheckButton), null);


		public static readonly DependencyProperty CornerRadiusProperty =
	DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(CheckButton), null);
		#endregion

		#region Public Properties

		public double ImgOpacity
		{
			get { return (double)GetValue(ImgOpacityProperty); }
			set { SetValue(ImgOpacityProperty, value); }
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

		public Brush BorderBrushPointerOver
		{
			get { return (Brush)GetValue(BorderBrushPointerOverProperty); }
			set { SetValue(BorderBrushPointerOverProperty, value); }
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
