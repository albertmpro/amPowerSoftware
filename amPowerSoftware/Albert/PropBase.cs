using System;
using System.Collections.Generic;
using System.Text;

namespace Albert.Standard
{
	/// <summary>
	/// Abstract class for creating Properties for softwae 
	/// </summary>
	public abstract class PropBase: Notify
	{
		string name; 

		/// <summary>
		/// Gets or set the name of the property 
		/// </summary>
		public string Name
		{
			get { return name; }
			set { name = value; OnPropertyChanged("Name"); }
		}
	}
}
