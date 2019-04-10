using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Albert.Standard.Runtime
{
	/// <summary>
	/// A special ContentControl design to be based around 5 Colors 
	/// </summary>
	public class ThemeControl: ContentControl
	{
		public static readonly DependencyProperty ColorOneProperty, ColorTwoProperty, ColorThreeProperty, ColorFourProperty, ColorFiveProperty;

		/// <summary>
		/// Default Constructor 
		/// </summary>
		public ThemeControl()
		{
			DefaultStyleKey = typeof(ThemeControl);
		}

		

		static ThemeControl()
		{
			ColorOneProperty = DependencyProperty.Register("ColorOne", typeof(Color), typeof(ThemeControl), new PropertyMetadata( Colors.Black));		;

			ColorTwoProperty = DependencyProperty.Register("ColorTwo", typeof(Color), typeof(ThemeControl), new PropertyMetadata( Colors.White));

			ColorThreeProperty = DependencyProperty.Register("ColorThree", typeof(Color), typeof(ThemeControl), new PropertyMetadata(Colors.LightBlue));

			ColorFourProperty = DependencyProperty.Register("ColorFour", typeof(Color), typeof(ThemeControl), new PropertyMetadata(Colors.Blue));

			ColorFiveProperty = DependencyProperty.Register("ColorFive", typeof(Color), typeof(ThemeControl), new PropertyMetadata(Colors.DarkBlue));
		}
		/// <summary>
		/// Gets or sets Color 1 of the theme 
		/// </summary>
		public Color ColorOne
		{
			get { return (Color)GetValue(ColorOneProperty); }
			set { SetValue(ColorOneProperty, value); }
		}

		/// <summary>
		/// Gets or sets Color 2 of the theme 
		/// </summary>
		public Color ColorTwo
		{
			get { return (Color)GetValue(ColorTwoProperty); }
			set { SetValue(ColorTwoProperty, value); }
		}

		/// <summary>
		/// Gets or sets Color 3 of the theme 
		/// </summary>
		public Color ColorThree
		{
			get { return (Color)GetValue(ColorThreeProperty); }
			set { SetValue(ColorThreeProperty, value); }
		}

		/// <summary>
		/// Gets or sets Color 4 of the theme 
		/// </summary>
		public Color ColorFour
		{
			get { return (Color)GetValue(ColorFourProperty); }
			set { SetValue(ColorFourProperty, value); }
		}

		/// <summary>
		/// Gets or sets Color 5 of the theme 
		/// </summary>
		public Color ColorFive
		{
			get { return (Color)GetValue(ColorFiveProperty); }
			set { SetValue(ColorFiveProperty, value); }
		}





	}
}
