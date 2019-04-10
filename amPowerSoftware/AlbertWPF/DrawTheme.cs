using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static Albert.Standard.Win32.ColorUtility;
namespace Albert.Standard.Win32
{
	/// <summary>
	/// Defines the color of the drawing object 
	/// </summary>
	public class DrawTheme: PropBase
	{
		Color background, foreground;

		public DrawTheme()
		{
			Name = "Draw Document";
			background = ColorFromString("#fffffff");
			foreground = ColorFromString("#000000");
		}
		public DrawTheme(Color _forground, Color _background)
		{
			Name = "Draw Document";
			background = _background;
			foreground = _forground;
		}

		public DrawTheme(string _name, Color _forground, Color _background)
		{ 
			Name= _name;
			background = _background;
			foreground = _forground;
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
