using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using static Albert.Standard.Win32.MediaCv;
namespace Albert.Standard.Win32
{
	/// <summary>
	/// Class designed to capture Color
	/// </summary>
	public class ColorBase: PropBase
	{
		//Private Field's 
		Color color;
		string  htc;
		public ColorBase(string _color)
		{
			Name = "Color";
			color = HexColor(_color);
		}

		public ColorBase()
		{
			Name = "Color";
			color = Color.FromArgb(255, 0, 0, 0);
		}
		public ColorBase(Color _color)
		{
			Name = "Color";
			color = _color;
		}
		public ColorBase(SolidColorBrush _brush)
		{
			Name = "Color";
			color = _brush.Color;
		}

		public ColorBase(byte _a, byte _r, byte _g, byte _b)
		{
			Name = "Color";
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


		public string HtmlString
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

		public override string ToString()
		{
			var str = $"{Name}\nColor: {Color}";
			return base.ToString();
		}
	}
}
