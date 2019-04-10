using System;
using System.Collections.Generic;
using System.Text;

namespace Albert.Standard 
{
	/// <summary>
	/// Defines the width and height of Drawing objet 
	/// </summary>
	public class DrawPaper: PropBase
	{
		double width, height;

		/// <summary>
		/// Default Constructor 
		/// </summary>
		public DrawPaper()
		{
			Name = "Default";
			Width = 1920;
			Height = 1080;
		}
		/// <summary>
		/// Secondary Constructor 		/// </summary>
		/// <param name="_width"></param>
		/// <param name="_height"></param>
		public DrawPaper(double _width, double _height)
		{
			Name = "Default";
			Width = _width;
			Height = _height;

		}
		public DrawPaper(string _name,double _width, double _height)
		{
			Name = _name;
			Width = _width;
			Height = _height;
		}
		/// <summary>
		/// Get or sets Width of Draw doecument 
		/// </summary>
		public double Width
		{
			get { return width; }
			set { width = value; OnPropertyChanged("Width"); }
		}
		/// <summary>
		/// Gets or set the pixel height of a document
		/// </summary>
		public double Height
		{
			get { return height; }
			set { height = value; OnPropertyChanged("Height"); }
		}

		public override string ToString()
		{
			return $"Name: {Name}\nWidth: {Width}px\nHeight: {Height}px";
			
		}

	}
}
