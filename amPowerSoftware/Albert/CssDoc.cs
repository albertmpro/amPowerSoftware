using System;
using System.Collections.Generic;
using System.Text;

namespace Albert.Standard
{
	public class CssDoc: Notify 
	{
		string mainbody;
		private string cssp(string _name, params string[] _properties)
		{
			//Hold's the Properities 
			mainbody = "";
			var rv = $"{_name}\n{{\n{mainbody}\n}}\n";

			//Foreach 
			foreach (var i in _properties)
			{
				//Add the property one by one 
				mainbody += $"\t{i}\n";

				return rv;

			}

			return rv;
		}

		public override string ToString()
		{
			var rv = "";
			rv += "/*Basic Styylesheet*/ \n";
			//Create a Display Block for  most common properties 
			rv += cssp("article,aside,details,figcaption, figure, footer, header,hgroup, main, menu, nav, section, summary", "display:block;");
			//body of the document 
			rv += cssp("body", "");
			return rv;
		}
	}
}
