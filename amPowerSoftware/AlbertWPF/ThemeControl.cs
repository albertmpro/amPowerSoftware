using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
namespace Albert.Standard.Win32
{
	/// <summary>
	/// A special control that captures a color theme 
	/// </summary>
	public class ThemeControl: ContentControl
	{
		public static readonly DependencyProperty ColorOneProperty, ColorTwoProperty, ColorThreeProperty, ColorFourProperty, ColorFiveProperty,CornerRadiusProperty;

		static ThemeControl()
		{
			//Gets the CornerRadius Property 
			CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ThemeControl), null);
			// Gets the ColorOne Property 
			ColorOneProperty = DependencyProperty.Register("ColorOne", typeof(Brush), typeof(ThemeControl),new PropertyMetadata(Brushes.Black));
			// Gets the ColorTwo Property 
			ColorTwoProperty = DependencyProperty.Register("ColorTwo", typeof(Brush), typeof(ThemeControl), new PropertyMetadata(Brushes.White));
			ColorThreeProperty = DependencyProperty.Register("ColorThree", typeof(Brush), typeof(ThemeControl), new PropertyMetadata(Brushes.DarkBlue));
			ColorFourProperty = DependencyProperty.Register("ColorFour", typeof(Brush), typeof(ThemeControl), new PropertyMetadata(Brushes.Blue));
			ColorFiveProperty = DependencyProperty.Register("ColorFive", typeof(Brush), typeof(ThemeControl), new PropertyMetadata(Brushes.LightBlue));
		}

		/// <summary>
		/// Gets or sets the CornerRadius of the control 
		/// </summary>
		public CornerRadius CornerRadius
		{
			get { return (CornerRadius)GetValue(CornerRadiusProperty); }
			set { SetValue(CornerRadiusProperty, value); }
		}

		/// <summary>
		/// Gets or sets Color 1 of the theme 
		/// </summary>
		public Brush ColorOne
		{
			get { return (Brush)GetValue(ColorOneProperty);}
			set { SetValue(ColorOneProperty, value); }
		}

		/// <summary>
		/// Gets or sets Color 2 of the theme 
		/// </summary>
		public Brush ColorTwo
		{
			get { return (Brush)GetValue(ColorTwoProperty); }
			set { SetValue(ColorTwoProperty, value); }
		}

		/// <summary>
		/// Gets or sets Color 3 of the theme 
		/// </summary>
		public Brush ColorThree
		{
			get { return (Brush)GetValue(ColorThreeProperty); }
			set { SetValue(ColorThreeProperty, value); }
		}

		/// <summary>
		/// Gets or sets Color 4 of the theme 
		/// </summary>
		public Brush ColorFour
		{
			get { return (Brush)GetValue(ColorFourProperty); }
			set { SetValue(ColorFourProperty, value); }
		}

		/// <summary>
		/// Gets or sets Color 5 of the theme 
		/// </summary>
		public Brush ColorFive
		{
			get { return (Brush)GetValue(ColorFiveProperty); }
			set { SetValue(ColorFiveProperty, value); }
		}


	}
}
