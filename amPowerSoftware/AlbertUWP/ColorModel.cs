
using Windows.UI;
using Windows.UI.Xaml.Media;
using static Albert.Standard.Runtime.ColorUtility;
namespace Albert.Standard.Runtime
{
	/// <summary>
	/// Designed to capture the Color for MVVM pattern's 
	/// </summary>
	public class ColorModel: Notify
	{
		//Private Field's 
		Color color;
		string sc, htc;
		public ColorModel(string _color)
		{
			color = ColorFromString(_color);
		}

		public ColorModel()
		{
		
			color = Color.FromArgb(255, 0, 0, 0);
		}
		public ColorModel(Color _color)
		{
			color = _color;
		}
		public ColorModel(SolidColorBrush _brush)
		{
			color = _brush.Color;
		}

		public ColorModel(byte _a,byte _r, byte _g, byte _b)
		{
			color = Color.FromArgb(_a, _r, _g, _b);
		}

		public Color Color
		{
			get { return color; }
			set
			{
				color = value;
				OnPropertyChanged("Color");
				OnPropertyChanged("StringColor");
				OnPropertyChanged("HtmlString");
			}

			
		}

		public  string StringColor
		{
			get
			{
				return color.ToString();
			}
			set
			{
				sc = value;
				OnPropertyChanged("StringColor");
			}
		}

		public  string HtmlString
		{
			get
			{
				var v = color.ToString();
				var rv = v.Replace("#FF", "#");
				return rv;
			}
			set
			{
				htc = value;
				OnPropertyChanged("HtmlString");
			}
		}
	}
}
