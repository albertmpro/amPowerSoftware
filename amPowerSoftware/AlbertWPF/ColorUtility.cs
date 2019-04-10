using System;
using System.Windows;
using System.Windows.Media;
namespace Albert.Standard.Win32
{
	/// <summary>
	/// Special Converter Class design to convert ARGB color Values 
	/// </summary>
	public static  class ColorUtility
	{
		

		/// <summary>
		/// Return's a Solid Color Brus 
		/// </summary>
		/// <param name="_alpha"></param>
		/// <param name="_red"></param>
		/// <param name="_green"></param>
		/// <param name="_blue"></param>
		/// <returns></returns>
		public static SolidColorBrush BrushFromArgb(byte _alpha, byte _red, byte _green, byte _blue)
		{
			return new SolidColorBrush(Color.FromArgb(_alpha, _red, _green, _blue));
		}


		public static Color ColorFromStringValues(string _alpha, string _red, string _green, string _blue)
		{
			var a = Convert.ToByte(_alpha);
			var r = Convert.ToByte(_red);
			var g = Convert.ToByte(_green);
			var b = Convert.ToByte(_blue);
			return Color.FromArgb(a, r, g, b);
		}

		public static LinearGradientBrush LinearGradientBrush(Color _c1, Color _c2)
		{
			var brush = new LinearGradientBrush();
			var s1 = new GradientStop(_c1, 0);
			var s2 = new GradientStop(_c2, 1);

			brush.GradientStops.Add(s1);
			brush.GradientStops.Add(s2);

			return brush;

		}

		public static Color ColorFromString(string hex)
		{
			try
			{
				//remove the # at the front
				hex = hex.Replace("#", "");

				byte a = 255;
				byte r = 255;
				byte g = 255;
				byte b = 255;

				int start = 0;

				//handle ARGB strings (8 characters long)
				if (hex.Length == 8)
				{
					a = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
					start = 2;
				}
				else if (hex.Length < 6)
				{

					MessageBox.Show("Your color is not valid, you get BLACK!", "Error", MessageBoxButton.OK);

					return Colors.Black;

				}
				else if (hex.Length > 6)
				{
					

				}

				//convert RGB characters to bytes
				r = byte.Parse(hex.Substring(start, 2), System.Globalization.NumberStyles.HexNumber);
				g = byte.Parse(hex.Substring(start + 2, 2), System.Globalization.NumberStyles.HexNumber);
				b = byte.Parse(hex.Substring(start + 4, 2), System.Globalization.NumberStyles.HexNumber);

				return Color.FromArgb(a, r, g, b);
			}
			catch 
			{
				MessageBox.Show("Your color is not valid, you get BLACK!", "Error", MessageBoxButton.OK);

					return Colors.Black;
				
			}
		}


		public static SolidColorBrush BrushFromString(string hex)
		{
			try
			{
				//remove the # at the from the hex value
				hex = hex.Replace("#", "");

				byte a = 255;
				byte r = 255;
				byte g = 255;
				byte b = 255;

				int start = 0;

				
				if (hex.Length == 8)// if hex is an ARGB value 
				{
					a = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
					start = 2;
				}
				else if (hex.Length < 6)
				{

					MessageBox.Show("Your color is not valid, you get BLACK!", "Error", MessageBoxButton.OK);

					return new SolidColorBrush(Colors.Black);

				}
				else if (hex.Length > 6)
				{


				}

				//convert RGB characters to bytes
				r = byte.Parse(hex.Substring(start, 2), System.Globalization.NumberStyles.HexNumber);
				g = byte.Parse(hex.Substring(start + 2, 2), System.Globalization.NumberStyles.HexNumber);
				b = byte.Parse(hex.Substring(start + 4, 2), System.Globalization.NumberStyles.HexNumber);

				return new SolidColorBrush(Color.FromArgb(a, r, g, b));
			}
			catch
			{
				MessageBox.Show("Your color is not valid, you get BLACK!", "Error", MessageBoxButton.OK);

				return new SolidColorBrush(Colors.Black);

			}
		}
	

	}
}
