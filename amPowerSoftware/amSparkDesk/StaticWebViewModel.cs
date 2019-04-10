using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Albert.Standard.Win32;
using static Albert.Standard.Win32.Win32IO;
using System.IO;
using Albert.Standard;

namespace amSparkDesk
{
	/// <summary>
	/// A special ViewModel for Genrerateing static websites from scratch
	/// </summary>
	public class StaticWebViewModel : ViewModel
	{

		//Field's 
		//Xml Filter 
		string XmlFilter = "Xml FIle (.xml)|*.xml";
		
		//Lists of Stylesheets and Javascript files
		VMList<string> jsfile, cssfiles;
		/// <summary>
		/// Default Construcor
		/// </summary>
		public StaticWebViewModel()
		{


		}

		public void CreateSite(string _name)
		{
			SaveDialogTask("Create Site Folder", XmlFilter, (s) =>
			  {
				  //Get the Diretory your in 
				  var dir = new DirectoryInfo(s.InitialDirectory);

				  //Create your main Directory
				  var main = dir.CreateSubdirectory(_name);
				  //Create a images Directory for the main folder
				  var img = main.CreateSubdirectory("images");
				  //Create a font directory for the main folder
				  var font = main.CreateSubdirectory("fonts");
			  });



			}

		
	}
}
