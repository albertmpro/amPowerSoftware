﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace Albert.Standard.Win32
{
	public class OptionButton: RadioButton
	{
		public OptionButton()
		{
			//ReDraw the Template 
			DefaultStyleKey = typeof(OptionButton);
		}

		#region Dedenency Properties

		public static readonly DependencyProperty ImgOpacityProperty =
DependencyProperty.Register("ImgOpacity", typeof(double), typeof(OptionButton), null);

		public static readonly DependencyProperty OptionVisibilityProperty =
DependencyProperty.Register("OptionVisibility", typeof(Visibility), typeof(OptionButton), null);


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

		public static readonly DependencyProperty BackgroundMouseOverProperty =
DependencyProperty.Register("BackgroundMouseOver", typeof(Brush), typeof(OptionButton), null);


		public static readonly DependencyProperty ForegroundMouseOverProperty =
	DependencyProperty.Register("ForegroundMouseOver", typeof(Brush), typeof(OptionButton), null);

		public static readonly DependencyProperty BorderBrushMouseOverProperty =
	DependencyProperty.Register("BorderBrushMouseOver", typeof(Brush), typeof(OptionButton), null);



		public static readonly DependencyProperty CornerRadiusProperty =
	DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(OptionButton), null);
		#endregion

		#region Public Properties

		public double ImgOpacity
		{
			get { return (double)GetValue(ImgOpacityProperty); }
			set { SetValue(ImgOpacityProperty, value); }
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
