using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Xml.Linq;
 
namespace Albert.Standard.Win32
{
	/// <summary>
	/// A special class to speed up the IO Process on Windows Applications 
	/// </summary>
	public static class Win32IO
	{

		#region MessageBox 

		public static void YesNoMsgBox(string _title, string _caption, Action _yes)
		{
			var msg = MessageBox.Show(_caption, _title, MessageBoxButton.YesNo);

			switch(msg)
			{
				case MessageBoxResult.Yes:
					//Yes Method 
					_yes?.Invoke();
					break;
				case MessageBoxResult.No:
					//Do Nothing 
					break;
			}
		}


		public static void YesNoMsgBox(string _title, string _caption, Action _yes,Action _no)
		{
			var msg = MessageBox.Show(_caption, _title, MessageBoxButton.YesNo);

			switch (msg)
			{
				case MessageBoxResult.Yes:
					//Yes Method 
					_yes?.Invoke();
					break;
				case MessageBoxResult.No:
					//No Method 
					_no?.Invoke();
					break;
			}
		}


		#endregion

		#region Win32 DialogBoxes 
		/// <summary>
		/// A special task to speed up the SaveDialog Proecss 
		/// </summary>
		/// <param name="_title">Title of the Window</param>
		/// <param name="_filter">Filter for the fileformats</param>
		/// <param name="_method">(diloag class)The Method that will be used</param>
		public static void SaveDialogTask(string _title, string _filter, Action<SaveFileDialog> _method)
		{
			var dialog = new SaveFileDialog { Title = _title, Filter = _filter };//Create a new dialog 

			if (dialog.ShowDialog() == true)
			{
				_method.Invoke(dialog); //Run the method
			}
		}

		/// <summary>
		/// A special task to speed up the OpenDialog Proecss 
		/// </summary>
		/// <param name="_title">Title of the Window</param>
		/// <param name="_filter">Filter for the fileformats</param>
		/// <param name="_method">(diloag class)The Method that will be used</param>
		public static void OpenDialogTask(string _title, string _filter, Action<OpenFileDialog> _method)
		{

			var dialog = new OpenFileDialog { Title = _title, Filter = _filter }; //Create a new dialog 
			dialog.Multiselect = true; // Enable selecting multple vfiles  
			if (dialog.ShowDialog() == true)
			{
				_method.Invoke(dialog); //Run the method
			}
		}


		#endregion


		#region Copy File Path Logic 
		public static void CopyTextFileFromFile(string _originalFilePath, string _directory, string _newName)
		{
			if (File.Exists(_originalFilePath))
			{
				var content = File.ReadAllText(_originalFilePath); // Read all the content in the file
				var newpath = Path.Combine(_directory, _newName); // Create a new directory and path for the file 
				File.WriteAllText(newpath, content); // Create the file 


			}
			else
			{
				MessageBox.Show($"Could not find{_originalFilePath}");
			}

		}
		#endregion



		#region Bitmap Section 
		/// <summary>
		/// Create a .png file 
		/// </summary>
		/// <param name="_fileName"></param>
		/// <param name="dpi"></param>
		/// <param name="element"></param>
		public static void CreatePng(string _fileName, int dpi, FrameworkElement element)
		{
			//Mesuse and Create the right size of the Element
			element.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
			element.Arrange(new Rect(new Point(0, 0), element.DesiredSize));

			//Convert width and height to whole pixels
			var width = (int)Math.Ceiling(element.ActualWidth);
			var height = (int)Math.Ceiling(element.ActualHeight);

			width = width == 0 ? 1 : width;
			height = height == 0 ? 1 : height;

			//Create a RenderTargetBitmap and discribe its properties 
			var bitmap = new RenderTargetBitmap(width, height, dpi, dpi, PixelFormats.Default);
			//Render the Visual 
			bitmap.Render(element);

			if (_fileName != string.Empty)
			{
				using (var stream = new FileStream(_fileName, FileMode.Create))
				{
					var encoder = new PngBitmapEncoder();
					encoder.Frames.Add(BitmapFrame.Create(bitmap));
					//Save the bitmap 
					encoder.Save(stream);
					//Close the stream 
					stream.Close();
				}
			}

			//All done! 

		}
		/// <summary>
		/// Create a jpeg file 
		/// </summary>
		/// <param name="_fileName"></param>
		/// <param name="dpi"></param>
		/// <param name="element"></param>
		public static void CreateJpeg(string _fileName, int dpi, FrameworkElement element)
		{
			//Mesuse and Create the right size of the Element
			element.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
			element.Arrange(new Rect(new Point(0, 0), element.DesiredSize));

			//Convert width and height to whole pixels
			var width = (int)Math.Ceiling(element.ActualWidth);
			var height = (int)Math.Ceiling(element.ActualHeight);

			width = width == 0 ? 1 : width;
			height = height == 0 ? 1 : height;

			var bitmap = new RenderTargetBitmap(width, height, dpi, dpi, PixelFormats.Default);
			//Render the Visual 
			bitmap.Render(element);

			if (_fileName != string.Empty)
			{
				using (var stream = new FileStream(_fileName, FileMode.Create))
				{
					var encoder = new JpegBitmapEncoder();

					encoder.Frames.Add(BitmapFrame.Create(bitmap));
					//Save the bitmap 
					encoder.Save(stream);
					//Close the stream 
					stream.Close();
				}
			}
		}

		#endregion

		#region Xml Helper's 

		/// <summary>
		/// A special XElement to spead up the process of creating a xml document 
		/// </summary>
		/// <param name="_topTag">The top tag in the document </param>
		/// <param name="_docTag">The tag that holds the documnet</param>
		/// <returns></returns>
		public static XElement XmlDocument(string _topTag, string _docTag)
		{
			var rv = new XElement(_topTag);
			var doc = new XElement(_docTag);
			rv.Add(doc);

			//Return Value 
			return rv;
		}

		public static XElement XmlDocument(string _topTag, string _docTag, Action<XElement> _method)
		{
			var rv = new XElement(_topTag);
			var doc = new XElement(_docTag);
			rv.Add(doc);


			_method?.Invoke(rv);

			//Return Value 
			return rv;
		}

		public static IEnumerable<XElement> XmlQueryDocument(XElement doc, string querystring)
		{
			//Create a query that will grab the elements that you want 
			var rquery = from document in doc.Descendants(querystring)
						 select document;

			return rquery;
		}

		#endregion


	}
}
