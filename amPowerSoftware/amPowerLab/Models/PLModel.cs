using Albert.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amPowerLab.Models
{
	public abstract class PLModel : Notify
	{
		string name;
		/// <summary>
		/// Gets or set the Name Property 
		/// </summary>
		public string Name
		{
			get { return name; }
			set { name = value;OnPropertyChanged("Name"); }
		}
	}
}
