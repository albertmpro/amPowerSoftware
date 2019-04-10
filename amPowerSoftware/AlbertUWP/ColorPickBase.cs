using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
namespace Albert.Standard.Runtime
{
	/// <summary>
	/// BaseClass for ColorPickers
	/// </summary>
	public  class ColorPickBase: Control
	{
		

		public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", 
			typeof(Color),
			typeof(ColorPickBase),null);

		public Color Color
		{
			get { return (Color)GetValue(ColorProperty); }
			set { SetValue(ColorProperty, value); }
		}

		

	}
}
