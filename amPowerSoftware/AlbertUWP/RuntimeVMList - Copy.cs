using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;
using Windows.Storage; 
namespace Albert.Standard.Runtime
{
	/// <summary>
	/// A special runtime list design to handle both json & xml 
	/// </summary>
	/// <typeparam name="T">Object that will be used for the list</typeparam>
	public class RuntimeVMList<T>: ObservableCollection<T>
	{
		#region Field's 

		//Field's 
		XElement root, document;
		bool isAnInsert = false; 
		#endregion

		#region Constructor's 
		/// <summary>
		/// Default Constructor 
		/// </summary>
		public RuntimeVMList()
		{
		
			
		}
		/// <summary>
		/// Xml Constructor 
		/// </summary>
		/// <param name="_rootName"></param>
		/// <param name="_documentName"></param>
		public RuntimeVMList(string _rootName, string _documentName)
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

		#endregion

		#region Public Method's 


		/// <summary>
		/// ForEach Lamba in the current list
		/// </summary>
		/// <param name="_method">What happens in the foreach</param>
		public void ForEach(Action<T> _method)
		{
			foreach(var i in this)
			{
				_method?.Invoke(i);
			}
		}
		public void QForEach(IEnumerable<XElement> _XElementQuery,Action<XElement> _method)
		{
			foreach (var i in _XElementQuery)
			{
				_method?.Invoke(i);
			}
		}

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
		public bool IsAnInsert
		{
			get
			{
				return isAnInsert;
			}
			set
			{
				isAnInsert = value;
			}
		}



		#endregion
		

	}


}