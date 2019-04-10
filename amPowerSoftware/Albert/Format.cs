using System;
using System.Collections.Generic;
using System.Text;

namespace Albert.Standard
{/// <summary>
/// A special struct fo rdealing with pixeal formats 
/// </summary>
    public struct Format
    {
		//Filed's
		double width, height;
		string name,swidth, sheight; 
		/// <summary>
		/// Constructor creates a custom name for the format
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="_width"></param>
		/// <param name="_height"></param>
		public Format(string _name, double _width, double _height)
		{
			
			width = _width;
			height = _height;
			name = $"{_name} {width}px x {height}px";
			swidth = $"{width}px";
			sheight = $"{height}px";
		}
		/// <summary>
		/// Constructor creates just the width and height of the format
		/// </summary>
		/// <param name="_width"></param>
		/// <param name="_height"></param>
		public Format(double _width,double _height)
		{
			width = _width;
			height = _height;
			name = $"Format {width}px x {height}px ";
			swidth = $"{width}px";
			sheight = $"{height}px";
		}
		/// <summary>
		/// Gets the name of the format 
		/// </summary>
		public string Name
		{
			get { return name; }
		}
		/// <summary>
		/// Gets the string Width of the format 
		/// </summary>
		public string sWidth
		{
			get { return swidth; }
		}
		/// <summary>
		/// Gets the string Height of the Format 
		/// </summary>
		public string sHeight
		{
			get { return sHeight; }
		}
		/// <summary>
		/// Gets the Width value 
		/// </summary>
		public double Width
		{
			get { return width; }
		}
		/// <summary>
		/// Gets the gheight value 
		/// </summary>
		public double Height
		{
			get { return height; }
		}
    }
	
}
