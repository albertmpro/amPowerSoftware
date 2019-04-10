using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert.Standard.Win32;
using System.Xml.Linq;
using static Albert.Standard.Win32.Win32IO;
using System.IO;
using System.Windows.Media;
using static Albert.Standard.Win32.ColorUtility;
using static System.Convert;
using System.Windows;

namespace amDevFl
{
    public class WebMsgViewModel: ViewModel 
    {
		string filter = "Web Msg(.msg)|*.msg";
		string efilter = "Png(.png)|*.png";

		#region Public Method's 
		/// <summary>
		/// Export to PNG Format
		/// </summary>
		/// <param name="_txt"></param>
		/// <param name="_tabItem"></param>
		public void ExportWebMsg(ATextField _txt, DocumentTabItem _tabItem)
		{
			//Save Dialog for the export
			SaveDialogTask("Export to Image", efilter, (s) =>
			{
				//Create Png File 
				CreatePng(s.FileName, 96, _txt);
				var info = new FileInfo(s.FileName);
				//Update the tab info 
				_tabItem.Header = info.Name;

			});
		}

		public void OpenWebMsg(ATextField _txt, string _cf, FileInfo _fi, DocumentTabItem _tb)
		{
			//Open File with Dialog 
			OpenDialogTask("Open Webmsg", filter, (o) =>
			{
				//Let method do that dirty work 
				loadMsg(o.FileName, _txt, _cf, _fi, _tb);

			});
		}


		public void SaveWebMsg(ATextField _txt, string _cf, FileInfo _fi, DocumentTabItem _tabItem)
		{
			//Create your xml documen t
			var xml = createXml(_txt);

			switch (_cf)
			{
				case null:
					SaveDialogTask("Save WebMsg", filter, (s) =>
					{
						//Save the xml file 
						xml.Save(s.FileName);
						//Set the Current File
						_cf = s.FileName;
						//Setup the file Info 
						_fi = new FileInfo(_cf);
						//TabItem Header
						_tabItem.Header = _fi.Name;
					});
					break;
				default:
					//Save the xml file 
					xml.Save(_cf);

					//Setup the file Info 
					_fi = new FileInfo(_cf);

					//TabItem Header
					_tabItem.Header = _fi.Name;
					break;
			}
		}
		public void SaveAsWebMsg(ATextField _txt, string _cf, FileInfo _fi, DocumentTabItem _tabItem)
		{
			//Create xml document
			var xml = createXml(_txt);

			SaveDialogTask("Save WebMsg", filter, (s) =>
			 {
				 //Save the xml file 
				 xml.Save(s.FileName);
				 //Set the Current File
				 _cf = s.FileName;
				 //Setup the file Info 
				 _fi = new FileInfo(_cf);
				 //TabItem Header
				 _tabItem.Header = _fi.Name;
			 });


		}
		#endregion


		#region Dirty Xml Work 
		/// <summary>
		/// Load the xml into the document
		/// </summary>
		/// <param name="_file"></param>
		/// <param name="_txt"></param>
		/// <returns></returns>
		void loadMsg(string _file, ATextField _txt, string _cf, FileInfo _fi, DocumentTabItem _tb)
		{
			var xml = XElement.Load(_file);
			//Link to the Body element
			var body = xml.Element("webmsg").Element("body");
			//Link to the colors element
			var colors = body.Element("colors");
			//Link to the content 
			var content = body.Element("content");


			//Get the Colors 
			var backColor = (Color)ColorFromString(colors.Attribute("background").Value);
			var foreColor = (Color)ColorFromString(colors.Attribute("foreground").Value);
			var borderColor = (Color)ColorFromString(colors.Attribute("border").Value);

			//Put the Colors in SolidColorBrushes 
			var back = new SolidColorBrush(backColor);
			var fore = new SolidColorBrush(foreColor);
			var border = new SolidColorBrush(borderColor);

			//Get the thickness and radius 
			var thickness = ToDouble(body.Attribute("thickness").Value);
			var radius = ToDouble(body.Attribute("radius").Value);

			//Get the width and height 
			var width = ToDouble(body.Attribute("width").Value);
			var heifht = ToDouble(body.Attribute("hieght").Value);

			//Get the font 
			var font = content.Attribute("fontfamily").Value;
			var fsize = ToDouble(content.Attribute("fontsize").Value);
			//Get the main content 
			var text = content.Value;

			//Load it into the ATextField 
			_txt = new ATextField
			{
				Width = width,
				Height = heifht,
				BorderBrush = border,
				Background = back,
				Foreground = fore,
				BorderThickness = new Thickness(thickness),
				CornerRadius = new CornerRadius(radius),
				FontFamily = new FontFamily(font),
				FontSize = fsize,
				Text = text
			};

			//File Info Stuff 
			_cf = _file;
			_fi = new FileInfo(_cf);
			_tb.Header = _fi.Name;



		}
		/// <summary>
		/// XElement designed to setup a web msg Document
		/// </summary>
		/// <param name="_txt"></param>
		/// <returns></returns>
		XElement createXml(ATextField _txt)
		{
			//Convert and grab colors 
			var back = (SolidColorBrush)_txt.Background;
			var fore = (SolidColorBrush)_txt.Foreground;
			var border = (SolidColorBrush)_txt.BorderBrush;
			//Convert the Thicnkess and corner radius 
			var bt = _txt.BorderThickness.Top;
			var cr = _txt.CornerRadius.TopLeft;

			//width and height 
			var width = _txt.Width;
			var height = _txt.Height;
			var font = _txt.FontFamily;
			//Create the xml file 
			var xml = new XElement("amDevFlow");

			var webmsg = new XElement("webmsg");
			var body = new XElement("body");
			//Width and Height
			body.Add(new XAttribute("width", width),
				new XAttribute("height", height));
			//Thickness and Radius
			body.Add(new XAttribute("thickness", bt),
				new XAttribute("radius", cr));
			//Main Content
			var content = new XElement("content", _txt.Text);
			//Grab the font family 
			content.Add(new XAttribute("fontfamily", font));
			content.Add(new XAttribute("fontsize", _txt.FontSize));
			// Grab all your Colors 
			var colors = new XElement("colors");
			colors.Add(new XAttribute("background", back.Color),
				new XAttribute("foreground", fore.Color),
				new XAttribute("border", border.Color));
			//Combine the Xml document.
			body.Add(colors);
			body.Add(content);
			webmsg.Add(body);
			xml.Add(webmsg);

			return xml;
		} 
		#endregion




	}
}
