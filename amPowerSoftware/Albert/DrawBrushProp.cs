using System;
using System.Collections.Generic;
using System.Text;

namespace Albert.Standard
{
	/// <summary>
	/// Dfines DrawSize and or Opacity if allowed 
	/// </summary>
	public class DrawBrushProp: PropBase
	{
		//Fiezsld's 
		double size, opacity;

		public DrawBrushProp()
		{
			//Default name 
			Name = "Pen";
			Size = 10;
			Opacity = 1;
		}
		public DrawBrushProp(double _drawsize, double _opacity)
		{
			//Default name 
			Name = "Pen";
			Size = _drawsize;
			Opacity = _opacity;
		}

		public DrawBrushProp(string _name, double _size, double _opacity)
		{
			//Default name 
			Name = _name;
			Size = _size;
			Opacity = _opacity;
		}
		/// <summary>
		/// Get or set the Size of your brush 
		/// </summary>
		public double Size
		{
			get { return size; }
			set { size = value; OnPropertyChanged("Size"); }
		}
		/// <summary>
		/// Get or set the Opacity of the Brush 
		/// </summary>
		public double Opacity
		{
			get { return opacity; }
			set { opacity = value; OnPropertyChanged("Opacity"); }
		}

		public override string ToString()
		{
			//Convert to Percent
			var opcv = Opacity * 100;
			return $"{Name}\nSize: {Size}\nOpacity: {opcv}%";
		}

	}



}
