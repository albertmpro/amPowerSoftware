using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;


namespace Albert.Standard.Runtime
{
	/// <summary>
	/// Repesents a set of Colors 
	/// </summary>
	public class Theme : Notify
	{
		Color color1, color2, color3, color4, color5;

		public Theme()
		{
			// Do nothing 
		}

		public Theme(Color _1,Color _2,Color _3,Color _4,Color _5)
		{
			color1 = _1;
			color2 = _2;
			color3 = _3;
			color4 = _4;
			color5 = _5; 


		}
		
		/// <summary>
		/// Gets or sets ColorOne
		/// </summary>
		/// 
		public Color ColorOne
		{
			get { return color1; }
			set { color1 = value; OnPropertyChanged("ColorOne"); }
		}
		/// <summary>
		/// Gets or sets ColorTwo
		/// </summary>
		public Color ColorTwo
		{
			get { return color2; }
			set { color2 = value; OnPropertyChanged("ColorTwo"); }
		}
		/// <summary>
		/// Gets or sets ColorThree
		/// </summary>
		public Color ColorThree
		{
			get { return color3; }
			set { color3 = value; OnPropertyChanged("ColorThree"); }
		}

		/// <summary>
		/// Gets or sets ColorFour
		/// </summary>
		public Color ColorFour
		{
			get { return color4; }
			set { color4 = value; OnPropertyChanged("ColorFour"); }
		}
		/// <summary>
		/// Gets or sets ColorFive
		/// </summary>
		public Color ColorFive
		{
			get { return color5; }
			set { color5 = value; OnPropertyChanged("ColorFive"); }
		}



	}
}
