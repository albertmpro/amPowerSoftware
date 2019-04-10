using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Albert.Standard.Runtime
{
    /// <summary>
    /// A basic Chrome to make styling easier than before 
    /// </summary>
    public class ChromeBase: ContentControl
    {
		public static readonly DependencyProperty CornerRadiusProperty, BackgroundAProperty, BackgroundBProperty, BackgroundCProperty,
	BorderBrushAProperty, BorderBrushBProperty, BorderBrushCProperty, ForegroundAProperty, ForegroundBProperty, ForegroundCProperty;

		/// <summary>
		/// Construct the Depdencey Properties here 
		/// </summary>
		static ChromeBase()
		{
			//CornerRadius 
			CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ChromeBase), null);

			//Background
			BackgroundAProperty = DependencyProperty.Register("BackgroundA", typeof(Brush), typeof(ChromeBase), null);
			BackgroundBProperty = DependencyProperty.Register("BackgroundB", typeof(Brush), typeof(ChromeBase), null);
			BackgroundCProperty = DependencyProperty.Register("BackgroundC", typeof(Brush), typeof(ChromeBase), null);

			//Foreground 
			ForegroundAProperty = DependencyProperty.Register("ForegroundA", typeof(Brush), typeof(ChromeBase), null);
			ForegroundBProperty = DependencyProperty.Register("ForegroundB", typeof(Brush), typeof(ChromeBase), null);
			ForegroundCProperty = DependencyProperty.Register("ForegroundC", typeof(Brush), typeof(ChromeBase), null);

			//Border Brush 
			BorderBrushAProperty = DependencyProperty.Register("BorderBrushA", typeof(Brush), typeof(ChromeBase), null);
			BorderBrushBProperty = DependencyProperty.Register("BorderBrushB", typeof(Brush), typeof(ChromeBase), null);
			BorderBrushCProperty = DependencyProperty.Register("BorderBrushC", typeof(Brush), typeof(ChromeBase), null);

		}

		public ChromeBase()
		{
			DefaultStyleKey = typeof(ChromeBase);
		}


		/// <summary>
		/// Gets or sets CornerRadius
		/// </summary>
		public CornerRadius CornerRadius
		{
			get { return (CornerRadius)GetValue(CornerRadiusProperty); }
			set { SetValue(CornerRadiusProperty, value); }
		}

		/// <summary>
		/// Gets or sets BackgroundA 
		/// </summary>
		public Brush BackgroundA
		{
			get { return (Brush)GetValue(BackgroundAProperty); }
			set { SetValue(BackgroundAProperty, value); }
		}
		/// <summary>
		/// Gets or sets BackgroundB
		/// </summary>
		public Brush BackgroundB
		{
			get { return (Brush)GetValue(BackgroundBProperty); }
			set { SetValue(BackgroundBProperty, value); }
		}
		/// <summary>
		/// Gets or sets BackgroundC
		/// </summary>
		public Brush BackgroundC
		{
			get { return (Brush)GetValue(BackgroundCProperty); }
			set { SetValue(BackgroundCProperty, value); }
		}
		/// <summary>
		/// Gets or sets ForegroundA
		/// </summary>
		public Brush ForegroundA
		{
			get { return (Brush)GetValue(ForegroundAProperty); }
			set { SetValue(ForegroundAProperty, value); }
		}
		/// <summary>
		/// Gets or sets ForegroundB
		/// </summary>
		public Brush ForegroundB
		{
			get { return (Brush)GetValue(ForegroundBProperty); }
			set { SetValue(ForegroundBProperty, value); }
		}
		/// <summary>
		/// Gets or sets ForegroundC
		/// </summary>
		public Brush ForegroundC
		{
			get { return (Brush)GetValue(ForegroundCProperty); }
			set { SetValue(ForegroundCProperty, value); }
		}
		/// <summary>
		/// Gets or sets BorderBrushA
		/// </summary>
		public Brush BorderBrushA
		{
			get { return (Brush)GetValue(BorderBrushAProperty); }
			set { SetValue(BorderBrushAProperty, value); }
		}
		/// <summary>
		/// Gets or sets BorderBrushB
		/// </summary>
		public Brush BorderBrushB
		{
			get { return (Brush)GetValue(BorderBrushBProperty); }
			set { SetValue(BorderBrushBProperty, value); }
		}
		/// <summary>
		/// Gets or sets BorderBrushC
		/// </summary>
		public Brush BorderBrushC
		{
			get { return (Brush)GetValue(BorderBrushCProperty); }
			set { SetValue(BorderBrushCProperty, value); }
		}


    }
}
