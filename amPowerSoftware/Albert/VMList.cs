using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
namespace Albert.Standard
{
	/// <summary>
	/// A special genaric  list designed to work with MVVM and aother types of applications
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class VMList<T>: CoreList<T>
	{




		///<summary>
		/// Query's an xml document
		/// </summary>
		/// <param name="doc">get's the xml document</param>
		/// <param name="querystring">gets the name of the decendants name that will be used</param>
		/// <returns></returns>
		public IEnumerable<XElement> QueryDocument(XElement doc, string querystring)
		{
			//Create a query that will grab the elements that you want 
			var rquery = from document in doc.Descendants(querystring)
						 select document;

			return rquery;
		}

		/// <summary>
		/// XElement use to gentrate an xml document as quickly as possible
		/// </summary>
		/// <param name="_name">Names the default first tag</param>
		/// <param name="_method">method for setting up the document</param>
		/// <returns></returns>
		public static XElement CreateXml(string _name, Action<XElement> _method)
		{
			//Create the Xml Document 
			var xml = new XElement(_name);
			//Do the  method 
			_method?.Invoke(xml);
			//Return the xml 
			return xml;

		}
	}
}
