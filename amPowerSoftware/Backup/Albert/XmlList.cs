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
	/// Class for using xml with a list
	/// </summary>
	/// <typeparam name="T">Object that will be used for the list</typeparam>
	public class XmlList<T> : ObservableCollection<T>
	{
		#region Field's 
		//Field's 
		private XElement root, document;

		#endregion

		#region Constructor 

		/// <summary>
		/// Set the root and document name of the Xml when you declare the object.
		/// </summary>
		/// <param name="_rootName">Name of the top tag in a xml document</param>
		/// <param name="_documentName">Name of the second tag in xml document(where your information goes)</param>
		public XmlList(string _rootName, string _documentName)
		{
			

			//Declare the root of the xml document  
			root = new XElement(_rootName);
			//Declare the document of element 
			document = new XElement(_documentName);
			//Add document to the root 
			root.Add(document);
			/* resault 
			 *	<file>
			 *		<document>
			 *			Content is entered here ...
			 *		</document>
			 *	</file>
			 */

		}

		public XmlList()
		{
			// Do nothing 
		}

		#endregion



		#region Public Properties
		/// <summary>
		/// Gets or sets the entire Xml File 
		/// </summary>
		public XElement XmlFile
		{
			get
			{
				return root;
			}
			set
			{
				root = value;
			}
		}
		/// <summary>
		/// Gets or sets the Xml document
		/// </summary>
		public XElement XmlDocument
		{
			get
			{
				return document;
			}
			set
			{
				document = value;
			}
		}



		#endregion

		#region Public Method's


		///<summary>
		/// Query's an xml documen t
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

		public void ForEach(Action<T> _method)
		{
			foreach (var i in this)
			{
				_method?.Invoke(i);
			}
		}



		#endregion
	}
}
