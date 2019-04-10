using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albert.Standard
{
	public struct CssAtt
	{
		private string name, myvalue; 

		public CssAtt(string _name, string _value)
		{
			name = _name;
			myvalue = _value;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		public string Value
		{
			get { return myvalue; }
			set { myvalue = value; }
		}

		public override string ToString()
		{
			return $"\n\t{Name}: {Value};\n";
		}
	}
}
