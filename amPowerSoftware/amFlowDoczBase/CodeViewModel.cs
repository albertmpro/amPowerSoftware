using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert.Standard.Win32;
using static Albert.Standard.Win32.Win32IO;
using System.IO;
namespace amFlowDoczBase
{
	public class CodeViewModel : ViewModel
	{

		#region Folder Creation 
		/// <summary>
		/// Create a Web Folder 
		/// </summary>
		/// <param name="_name">Folder Name</param>
		public void CreateWebFolder(string _name)
		{
			//Name
			SaveNewFolder((s, dir) =>
			 {

				 //Create the Web Directory 
				 var web = dir.CreateSubdirectory(_name);
				 //Images Folder 
				 web.CreateSubdirectory("images");
				 //Style Folder 
				 var style = web.CreateSubdirectory("styles");
				 //Create style.css
				 var scontent = getCssDoc();
				 CreateFile("style.css", style.FullName,scontent);

				 //JS Folder 
				 var js = web.CreateSubdirectory("js");
				 //Create albert.js
				 CreateFile("albert.js", js.FullName);
				  });
		}

		public void CreateBlenderPipelineFolder(string _folderName)
		{
            SaveNewFolder((s,dir) =>
            {
                //Create the folder to store your python files 
                var blender = dir.CreateSubdirectory(_folderName);
                //Create a Main Python File 
                CreateFile("main.py", blender.FullName);


            });
		}


		#endregion

		#region File Templates
		public string getBlenderScript()
		{ 
			var rv = "\nimport bpy\n\n";
			return rv;
		}

		private string cssp(string _name, params string[] _properties)
		{
			//Hold's the Properities 
			var mainbody = "";
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


		public string getHtml()
		{
			var rv = $"<!DOCTYPE html>\n < html lang =\"en\">\n<head>\n<meta charset=\"UTF-8\"\n<meta name=\"viewport\" content=\"width=device-width,initial-scale=1\" >\n <meta name='description' content=''>\n<meta name=''keywords='' content=''>\n<meta name='' content='' >\n<title></title>\n\n</head>\n<body>\n\n</body>\n\n</html>";

			return rv;
		}

		public string getCssDoc()
		{
			var rv = "";
			//Body Properties 
			rv += cssp("body", "font-family: Verdana, Arial, Helvetica, sans-serif;", "margin: 0px;", "top: 0px;","width: 100%;","padding: 0px;","linee-height: 1.3rem","font-size:1.3rem");

			rv += cssp("article, aside, details, figcaption, figure, footer, header,hgroup, main, menu, nav, section, summary", "display: block");


			//Default for video,aduio, canvas, progress 
			rv += cssp("video,audio,canvas, progress", "display: inline-block;", "vertical-align: baseline;");

			//Clear 
			rv += cssp(".clear", "clear: both;");

			//Default Image 
			rv += cssp("img", "border: 0px;", "width: 85%;", "height: auto;", "display: inline-block;", "padding: 0px;");

			//Left Align
			rv += cssp(".left", "text-align: left;");

			//Center Align
			rv += cssp(".center", "text-align: center;");

			//Right Align
			rv += cssp(".right", "text-align: right;");

			//Justify Align
			rv += cssp(".justify", "text-align: justify;");


			//Cover  For Full pages 
			rv += cssp(".cover", "position: absolute;", "width: 100%;", "top: 0px;");


			//Center Block 
			rv += cssp(".cblock", "margin-left: auto;", "margin-right: auto;", "display:block");


				
			return rv;
		}
			

		#endregion

	}

	
}
