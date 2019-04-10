using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert.Standard.Win32;
using static Albert.Standard.HtmlCore;
using Albert.Standard;
namespace amSparkDesk
{
	public class CssViewModel : ViewModel
	{
		//Feild's 
		//Standard Css Libary List
		VMList<string> stLib;

		public CssViewModel()
		{
			
		}

		void createStandaredLib()
		{
			//Setup the string list 
			stLib = new VMList<string>();
			//body
			stLib.Add("*/Standard Libary*/ \n");
			//Standard for the body of the html document
			stLib.Add(CssDef("body", "margin: 0px\ntop: 0px\npadding 0px;\nwidth: 100%;\nfont-size: 1.3rem\nfoline-height: 1.3rem;"));
			//Standard Look for controls 
			stLib.Add(CssDef("article, aside, details, figcaption, figure, footer, header, main, menu, nav, section, summary", "display: block;"));
			//Setup how to display Video, Audio, and canvas controsls 
			stLib.Add(CssDef("video,progress,canvas,audio", "display: inline-block;\nvertical-align: baseline;"));
			//
			stLib.Add(CssDef("", ""));

		}
		
	}
}
