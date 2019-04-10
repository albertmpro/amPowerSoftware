using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Input;
using System.Xml.Linq;
using Albert.Standard.Win32;
using System.IO;
using static Albert.Standard.Win32.Win32IO;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Media;
using Albert.Standard;

namespace amSparkDesk
{
	public class InkViewModel : ViewModel
	{
		//Field's 
		//Export Png Filter 
		string exportFilter = "Png File(.png)|*.png";
		//InkProject Filter 
		string inkfilter = "Ink Project (.inkpr)|*.inkpr";
		VMList<DrawPaper> papers;

		public InkViewModel()
		{
			papers = new VMList<DrawPaper>();
			papers.Add(new DrawPaper());
			papers.Add(new DrawPaper("Sqaure",1080,1080));
			papers.Add(new DrawPaper("Medium Standard 1`", 1280, 800));
			papers.Add(new DrawPaper("Medium Standard 2", 1024, 768));
			papers.Add(new DrawPaper("Small Tablet", 800, 600));
			papers.Add(new DrawPaper("Sqaure", 1080, 1080));
			papers.Add(new DrawPaper("Small Suaure", 504, 504));
			papers.Add(new DrawPaper("Small Phone", 480, 800));
			papers.Add(new DrawPaper("Icon Sqaure", 100, 100));


		}

		/// <summary>
		/// Get the Preset Paper Sizes 
		/// </summary>
		public VMList<DrawPaper> Papers
		{
			get { return papers; }

		}


		//Method for creating an XmlFile 
		XElement createXml(InkCanvas _canvas)
		{
			//Base level Xml
			var xml = new XElement("amsparkdesk");
			//Document type 
			var ink = new XElement("inkproject");
			// 
			var scbrush = (SolidColorBrush)_canvas.Background;
			var body = new XElement("body", new XAttribute("width", _canvas.Width),
				new XAttribute("height", _canvas.Height), new XAttribute("background", scbrush.Color.ToString()));
			ink.Add(body);
			//Create the xml document 
			xml.Add(ink);
			return xml;
		}
		

		public void ExportInk(FrameworkElement _canvas)
		{
			//Setup Save Dialog 
			SaveDialogTask("Export Ink to Image", exportFilter, (s) =>
			  {
				  //Export the Image 
				  CreatePng(s.FileName, 96, _canvas);
			  });

		}

		/// <summary>
		/// Open Method for InkProject 
		/// </summary>
		/// <param name="_canvas"></param>
		/// <param name="_currentFile"></param>
		/// <param name="_fileInfo"></param>
		/// <param name="_tabitem"></param>
		public void OpenInk(InkCanvas _canvas,string _currentFile, FileInfo _fileInfo, DocumentTabItem _tabitem)
		{
			//Load 
			OpenDialogTask("Load Ink Project", inkfilter, (o) =>
			  {
				  //Set the Current file  
				  _currentFile = o.FileName;

				  //Load the Xml 
				  //var xml = XElement.Load(_currentFile);

				  //Grab Ink Data 
				  //var ink = xml.Element("inkproject").Element("body").Value;

				  //Convert the Ink Data into to the INk Canvas 
				  using (var stream = new FileStream(o.FileName, FileMode.Open))
				  {
					  var collection = new StrokeCollection(stream);
					  
					  //Stroke Collection 
					  _canvas.Strokes = collection;
					  
					  
					  
					  stream.Flush();
				  }
					  //Setup the FileInfo and Tab Item 
					  _fileInfo = new FileInfo(_currentFile);

				  
				 
				  //Set the Tab Item Header 
				  _tabitem.Header = _fileInfo.Name;




			  });


		
		}

	/// <summary>
	/// Save Method for Ink Project 
	/// </summary>
	/// <param name="_canvas"></param>
	/// <param name="_currentFile"></param>
	/// <param name="_fileINfo"></param>
	/// <param name="_tabitem"></param>
		public void SaveInk(InkCanvas _canvas, string _currentFile, FileInfo _fileINfo, DocumentTabItem _tabitem)
		{
			var xml = createXml(_canvas);
		
			//ink data 
			//var inkdata = new XElement("inkproject", new XElement("body", inkinfo));

			//Create a Xml File  
			//var xml = new XElement("amsparkdesk", inkdata); 
			//Create Filter for SaveDialog 
			//var filter = "InkProject(.inkpr)|*.inkpr";
			if (_currentFile != null)
			{
				//Save Xml 
				//xml.Save(_currentFile);
				using (var stream = new FileStream(_currentFile, FileMode.Create))
				{
					//Save strokes 
					_canvas.Strokes.Save(stream);
					//Flush
					stream.Flush();
				}
					//Save the File info 
					_fileINfo = new FileInfo(_currentFile);

				//Send the Doc name to the TabItem
				_tabitem.Header = _fileINfo.Name;
			}
			else if (_currentFile == null)
			{
				//Create the Save Dialog Object
				SaveDialogTask("Save ink", inkfilter, (d) =>
				  {
				  //Setup the Current file for the tab 
				  _currentFile = d.FileName;
					  //Save the xml to a file
					 
					  using (var stream = new FileStream(d.FileName, FileMode.Create))
					  {
						  //Save Strokes 
						  _canvas.Strokes.Save(stream);
						  stream.Flush();
					  }
					  
					  //Save the File info 
					  _fileINfo = new FileInfo(_currentFile);

				  //Send the Doc name to the TabItem
				  _tabitem.Header = _fileINfo.Name;
			
			  });
			}

			
		}
		/// <summary>
		/// Save as Method for Ink Project 
		/// </summary>
		/// <param name="_canvas"></param>
		/// <param name="_currentFile"></param>
		/// <param name="_fileINfo"></param>
		/// <param name="_tabitem"></param>
		public void SaveAsInk(InkCanvas _canvas , string _currentFile, FileInfo _fileINfo, DocumentTabItem _tabitem)
		{

			//ink data 
			var inkdata = new XElement("inkproject");
			//body 
			var body = new XElement("body");
			
			body.Add(new XAttribute("width", _canvas.Width));
			//Create a Xml File  
			var xml = new XElement("amsparkdesk", inkdata);
			//Create the Save Dialog Object
			SaveDialogTask("Save ink", inkfilter, (d) =>
			{
				//Setup the Current file for the tab 
				_currentFile = d.FileName;
				using (var stream = new FileStream(d.FileName, FileMode.Create))
				{
					//Save Strokes 
					_canvas.Strokes.Save(stream);
					stream.Flush();
				}
				//Save the File info 
				_fileINfo = new FileInfo(_currentFile);

				//Send the Doc name to the TabItem
				_tabitem.Header = _fileINfo.Name;

			});
		}


	}
}
