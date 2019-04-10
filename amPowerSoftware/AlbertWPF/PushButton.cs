using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace Albert.Standard.Win32
{
	/// <summary>
	/// Button with properites to make phone task  easier 
	/// </summary>
	public class PushButton : Button
	{
		public PushButton()
		{
			//ReDraw the Template 
			DefaultStyleKey = typeof(PushButton);


		}

		#region Dedenency Properties

		public static readonly DependencyProperty TabCountProperty =

			DependencyProperty.Register("TabCount", typeof(int), typeof(PushButton), null);
		public static readonly DependencyProperty NavStringProperty =
  DependencyProperty.Register("NavString", typeof(string), typeof(PushButton), null);

		public static readonly DependencyProperty ImgOpacityProperty =
	DependencyProperty.Register("ImgOpacity", typeof(double), typeof(PushButton), null);
		public static readonly DependencyProperty SourceProperty =
			DependencyProperty.Register("Source", typeof(ImageSource), typeof(PushButton), null);
		public static readonly DependencyProperty StretchProperty =
	DependencyProperty.Register("Stretch", typeof(Stretch), typeof(PushButton), null);
		public static readonly DependencyProperty BackgroundPressedProperty =
	DependencyProperty.Register("BackgroundPressed", typeof(Brush), typeof(PushButton), null);


		public static readonly DependencyProperty ForegroundPressedProperty =
	DependencyProperty.Register("ForegroundPressed", typeof(Brush), typeof(PushButton), null);

		public static readonly DependencyProperty BorderBrushPressedProperty =
	DependencyProperty.Register("BorderBrushPressed", typeof(Brush), typeof(PushButton), null);

		public static readonly DependencyProperty BackgroundMouseOverProperty =
DependencyProperty.Register("BackgroundMouseOver", typeof(Brush), typeof(PushButton), null);


		public static readonly DependencyProperty ForegroundMouseOverProperty =
	DependencyProperty.Register("ForegroundMouseOver", typeof(Brush), typeof(PushButton), null);

		public static readonly DependencyProperty BorderBrushMouseOverProperty =
	DependencyProperty.Register("BorderBrushMouseOver", typeof(Brush), typeof(PushButton), null);




		public static readonly DependencyProperty CornerRadiusProperty =
	DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(PushButton), null);
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

		public int TabCount
		{
			get { return (int)GetValue(TabCountProperty); }
			set { SetValue(TabCountProperty, value); }
		}

		public Brush BackgroundPressed
		{
			get { return (Brush)GetValue(BackgroundPressedProperty); }
			set { SetValue(BackgroundPressedProperty, value); }
		}
		public Brush ForegroundPressed
		{
			get { return (Brush)GetValue(ForegroundPressedProperty); }
			set { SetValue(ForegroundPressedProperty, value); }
		}
		public Brush BorderBrushPressed
		{
			get { return (Brush)GetValue(BorderBrushPressedProperty); }
			set { SetValue(BorderBrushPressedProperty, value); }
		}
		public Brush BackgroundMouseOver
		{
			get { return (Brush)GetValue(BackgroundMouseOverProperty); }
			set { SetValue(BackgroundMouseOverProperty, value); }
		}
		public Brush ForegroundMouseOver
		{
			get { return (Brush)GetValue(ForegroundMouseOverProperty); }
			set { SetValue(ForegroundMouseOverProperty, value); }
		}
		public Brush BorderBrushMouseOver
		{
			get { return (Brush)GetValue(BorderBrushMouseOverProperty); }
			set { SetValue(BorderBrushMouseOverProperty, value); }
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
