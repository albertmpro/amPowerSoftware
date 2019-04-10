using Albert.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Albert.Standard.Runtime;
using static Albert.Standard.Runtime.ColorUtility;
namespace amPowerLab.Models
{
	public class PLPaper: PLModel
	{
		//Fiedl's 
		 
		Brush  background, brush;
		

		/// <summary>
		/// Default 
		/// </summary>
		public PLPaper()
		{
			// Default Name 
			Name = "SketchBoard Type";
			//Define the Brush 
			brush = BrushFromString("#000000");
			//Define the Background
			background = BrushFromString("ffffff");
		
		}

		public PLPaper(string _name, Brush _brush, Brush _background)
		{
			Name = _name;
			brush = _brush;
			background = _background;
		}

		
		public Brush Brush
		{
			get { return brush;}
			set { brush = value; OnPropertyChanged("Brush"); }
		}
		public Brush Background
		{
			get { return background; }
			set { background = value; OnPropertyChanged("Brush"); }
		}

		public override string ToString()
		{
			var str = $"{Name}";

			return str;
		}

	}
}
