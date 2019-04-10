using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert.Standard;
using Albert.Standard.Runtime;
namespace amPowerLab.Models
{
	public class PLFormat : PLModel
	{
		//Field's 
		double width, height;
		

		public PLFormat()
		{ 
			Name = "Sketch";

		}

		public PLFormat(double _width, double _heihgt)
		{
			width = _width;
			height = _heihgt;
			Name = $"Sketch";
		}
		public PLFormat(string _name, double _width, double _heihgt)
		{
			width = _width;
			height = _heihgt;
			Name = _name;
		}

	

		public double Width
		{
			get { return width; }
			set { width = value; OnPropertyChanged("Width"); }

		}
		public double Height
		{
			get { return height; }
			set { height = value; OnPropertyChanged("Height"); }
		}
		public override string ToString()
		{
			var str = $"{Name} {Width}px x {Height}px";
			return str;
		}






	}

}
