using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using System.Xml.Linq;

namespace Albert.Standard.Runtime
{
	public class PushButton : Button
	{
		public PushButton()
		{
			this.DefaultStyleKey = typeof(PushButton);


		}
		#region Dedenency Properties

		public static readonly DependencyProperty TabCountProperty = DependencyProperty.Register("TabCount", typeof(int), typeof(PushButton), null);

			
		public static readonly DependencyProperty BackgroundPointerOverProperty =
	DependencyProperty.Register("BackgroundPointerOver", typeof(Brush), typeof(PushButton), null);


		public static readonly DependencyProperty ForegroundPointerOverProperty =
	DependencyProperty.Register("ForegroundPointerOver", typeof(Brush), typeof(PushButton), null);

		public static readonly DependencyProperty BorderBrushPointerOverProperty =
	DependencyProperty.Register("BorderBrushPointerOver", typeof(Brush), typeof(PushButton), null);

			
		public static readonly DependencyProperty NavStringProperty =
  DependencyProperty.Register("NavString", typeof(string), typeof(PushButton), null);


		public static readonly DependencyProperty BackgroundPressedProperty =
	DependencyProperty.Register("BackgroundPressed", typeof(Brush), typeof(PushButton), null);


		public static readonly DependencyProperty ForegroundPressedProperty =
	DependencyProperty.Register("ForegroundPressed", typeof(Brush), typeof(PushButton), null);

		public static readonly DependencyProperty BorderBrushPressedProperty =
	DependencyProperty.Register("BorderBrushPressed", typeof(Brush), typeof(PushButton), null);

		public static readonly DependencyProperty CornerRadiusProperty =
	DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(PushButton), null);

        public static readonly DependencyProperty SourceProperty =
    DependencyProperty.Register("Source", typeof(ImageSource), typeof(PushButton), null);

        public static readonly DependencyProperty StretchProperty =
    DependencyProperty.Register("Stretch", typeof(Stretch), typeof(PushButton), null);

        #endregion

        #region Public Properties

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

        public string NavString
		{
			get { return (string)GetValue(NavStringProperty); }
			set { SetValue(NavStringProperty, value); }
		}

		public int TabCount
		{
			get { return (int)GetValue(TabCountProperty); }
			set { SetValue(TabCountProperty, value); }
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
		public CornerRadius CornerRadius
		{
			get { return (CornerRadius)GetValue(CornerRadiusProperty); }
			set { SetValue(CornerRadiusProperty, value); }
		}

		#endregion










	}
}
