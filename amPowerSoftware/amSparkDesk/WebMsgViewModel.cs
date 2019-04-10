using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Albert.Standard;
using Albert.Standard.Win32;
using System.Xml.Linq;
using static System.Convert;
using static Albert.Standard.Win32.ColorUtility;
using static Albert.Standard.Win32.Win32IO;
using System.IO;

namespace amSparkDesk
{
	public class WebMsgViewModel : ViewModel
	{


		public WebMsgViewModel()
		{
		


		}
		public void Open(TextBox _txt)
		{
			/*
			 * Example 
			 * <amsparkdesk>
			 * <webmsg font='' fontsize=''>
			 * <body width='' height='' thickness=''>
			 * <colors background='' text='' border='' />
			 * </body>
			 * </webmsg>
			 * </amsparkdesk>
			 */

			OpenDialogTask("Open Msg", "WebMsg(.msg)|*.msg", (d) =>
			 {
				 var xml = XElement.Load(d.FileName);
				 //Breakdown the xml fil e
				 var webmsg = xml.Element("webmsg");
				 var body = webmsg.Element("body");
				 var color = body.Element("color");
				 var text = body.Element("text");
			 });

		}
		public void Save( TextBox _txt)
		{
			if (_txt != null)
			{
				//Create the Dialog 
				SaveDialogTask("Save Msg", "WebMsg(.msg)|*.msg", (s) =>
				  {
					  //Grab the Colors 
					  var textc = (SolidColorBrush)_txt.Background;
					  var back = (SolidColorBrush)_txt.Background;
					  var borderc = (SolidColorBrush)_txt.BorderBrush;
					  //Create an Xml document
					  var xml = new XElement("amsparkdesk", $"<webmsg font='{_txt.FontFamily}' fontsize='{_txt.FontSize}'>\n<body width='{_txt.Width}' height='{_txt.Height}' thickness='{_txt.BorderThickness.Top}'>\n<colors background='{back.Color}' text='{textc.Color}' border='{borderc.Color}' />\n<text>{_txt.Text}</text>\n</body>\n</webmsg>");
					  //Save the Xml to a FIle 
					  xml.Save(s.FileName);
					  //Set the CurrentFile 
					  CurrentFile = s.FileName;
					  //Setup the File Info 
					  FileInfo = new FileInfo(CurrentFile);
					  
			  });
				
			}
		}

		public void Export(FrameworkElement _txt)
		{
			if (_txt != null)
			{
				//Create the save dialog task 
				SaveDialogTask("Export Image", "PNG FIle(.png)|*.png", (s) =>
				 {
					 //Export the Image to the png file
					 CreatePng(s.FileName, 96, _txt);
				 });
			}
		}








	}
}
