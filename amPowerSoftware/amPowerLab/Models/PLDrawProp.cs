using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert.Standard.Runtime;
using Albert.Standard;
namespace amPowerLab.Models
{
	public class PLDrawProp: PLModel 
	{
		double drawsize, drawopacity;
		

		/// <summary>
		/// Default Constructor 
		/// </summary>
		public PLDrawProp()
		{
			Name = "Pen";
			drawopacity = .35;
			drawsize = 20;
		}
		/// <summary>
		/// Second Constructor for building the properties up 
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="_size"></param>
		/// <param name="_opacity"></param>
		public PLDrawProp(string _name, double _size,double _opacity)
		{
			Name = _name;
			drawsize = _size;
			drawopacity = _opacity;
		}

	

		public double DrawOpacity
		{
			get { return drawopacity; }
			set { drawopacity = value; OnPropertyChanged("DrawOpacity"); }
		}

		public double DrawSize
		{
			get { return drawsize; }
			set { drawsize = value; OnPropertyChanged("DrawSize"); }
		}

		public override string ToString()
		{
			var str = $"{Name} DrawSize{DrawSize} DrawOpacity{DrawOpacity}";
			return str ;
		}



	}
}
