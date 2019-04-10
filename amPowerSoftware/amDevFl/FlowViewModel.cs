using Albert.Standard;
using Albert.Standard.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace amDevFl
{
	/// <summary>
	/// Default ViewModel Hub of the Application 
	/// </summary>
	public class FlowViewModel:ViewModel
	{
		#region Feild's
		
		string title;
		WebMsgViewModel webVM; 
		#endregion

		/// <summary>
		/// Default Constructor 
		/// </summary>
		public FlowViewModel()
		{
			title = "amDevFlow 1.0";

			//Grab the WebMsg VM 
			webVM = (WebMsgViewModel)App.Current.Resources["webMsgViewModel"];
		}

		/// <summary>
		/// Get the WebMsgVeiwModel Resource
		/// </summary>
		public WebMsgViewModel WebMsg
		{
			get { return webVM; }
		}


		/// <summary>
		/// Gets or sets the Title of the Application
		/// </summary>
		public string Title
		{
			get { return title; }
			set { title = value;  }
		}
		/// <summary>
		/// Gets or sets the Main Tab Control that will be used for the documents
		/// </summary>
		public TabControl VMTab { get; set; }
	}
}
