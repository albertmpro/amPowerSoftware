using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Albert.Standard.Win32.MediaCv;
using System.Windows.Media;
using static Albert.Standard.Win32.ColorUtility;
namespace Albert.Standard.Win32
{
	/// <summary>
	/// Defines the color of the drawing object 
	/// </summary>
	public class DrawTheme : PropBase
	{
		Color background, foreground;

		public DrawTheme()
		{

			BackgroundColor = HexColor("#fffffff");
			ForegroundColor = HexColor("#000000");
			Name = $"Foreground:{ForegroundColor}\nBackground:{BackgroundColor}";


		}
        public DrawTheme(string _name, string _forground,string _background)
        {
            try
            {
                //Foreground
                ForegroundColor = HexColor(_forground);
                //Background
                BackgroundColor = HexColor(_background);
                Name = _name;
            }
            catch // Do the Default
            {
                BackgroundColor = HexColor("#fffffff");
                ForegroundColor = HexColor("#000000");
                Name = _name;
            }
        }
		public DrawTheme(string _strforeground, string _strbackground)
		{
			try
			{
				//Foreground
				ForegroundColor = HexColor(_strforeground);
				//Background
				BackgroundColor = HexColor(_strbackground);
				Name = $"Foreground:{ForegroundColor}\nBackground:{BackgroundColor}";
			}
			catch // Do the Default
			{
				BackgroundColor = HexColor("#fffffff");
				ForegroundColor = HexColor("#000000");
				Name = $"Foreground:{ForegroundColor}\nBackground:{BackgroundColor}";
			}
		}
		public DrawTheme(Color _forground, Color _background)
		{
			
			BackgroundColor = _background;
			ForegroundColor = _forground;
			Name = $"Foreground:{ForegroundColor}\nBackground:{BackgroundColor}";
		}

		public DrawTheme(string _name, Color _forground, Color _background)
		{ 
			Name= _name;
			BackgroundColor = _background;
			ForegroundColor = _forground;
		}

		/// <summary>
		/// Get or sets Background Color 
		/// </summary>
		public Color BackgroundColor
		{
			get { return background; }
			set { background = value; OnPropertyChanged("BackgroundColor"); }
		}

		/// <summary>
		/// Get or sets the Drawing Color 
		/// </summary>
		public Color ForegroundColor
		{
			get { return foreground;  }
			set { foreground = value; OnPropertyChanged("ForegroundColor"); }
		}

		public override string ToString()
		{
			return $"Name: {Name}\nForeground: {ForegroundColor}\nBackground: {BackgroundColor}";
		}
	}
}
