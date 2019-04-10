using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Graphics.Imaging;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml.Controls;
using static Albert.Standard.Runtime.Device10x;
namespace Albert.Standard.Runtime
{
	/// <summary>
	/// A special class for streamlining async file read/write code
	/// </summary>
	public static class AsyncIO
	{


		#region Read and Write Text Method's 

		/// <summary>
		/// Writing a text file to the application 
		/// </summary>
		/// <param name="_fileName"></param>
		/// <param name="_content"></param>
		/// <returns></returns>
		public static async Task WriteTextAsync(string _fileName, string _content)
		{
			//byte[] filebytes = System.Text.Encoding.UTF8.GetBytes(_content.ToCharArray());
			try
			{
				var localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
				var file = await localFolder.CreateFileAsync(_fileName, CreationCollisionOption.ReplaceExisting);

				await FileIO.WriteTextAsync(file, _content);

			}
			catch (Exception ex)
			{

				var msg = new MessageDialog(ex.Message);
				await msg.ShowAsync();
			}


		}



		/// <summary>
		/// Writing a text file to a target location 
		/// </summary>
		/// <param name="_file"></param>
		/// <param name="_content">main</param>
		/// <returns></returns>
		public static async Task WriteTextAsync(StorageFile _file, string _content)
		{
			//byte[] filebytes = System.Text.Encoding.UTF8.GetBytes(_content.ToCharArray());
			await FileIO.WriteTextAsync(_file, _content);

		}

		/// <summary>
		/// Read text file from application 
		/// </summary>
		/// <param name="_fileName"></param>
		/// <returns></returns>
		public static async Task<string> ReadTextAsync(string _fileName)
		{

			var folder = ApplicationData.Current.LocalFolder;
			var file = await folder.GetFileAsync(_fileName);

			//Read the file 
			var rv = await FileIO.ReadTextAsync(file);

			return rv;

		}
		/// <summary>
		/// Read text file from target location 
		/// </summary>
		/// <param name="_file"></param>
		/// <returns></returns>
		public static async Task<string> ReadTextAsync(StorageFile _file)
		{

			try
			{
				var rv = await FileIO.ReadTextAsync(_file);

				return rv;
			}
			catch
			{

				return "";
			}

		}
		#endregion

		#region Read and Write Xml Method's 

		public static async Task<XElement> ReadXmlFileAsync(string _ext)
		{
			try
			{
				var picker = new FileOpenPicker();
				picker.FileTypeFilter.Add(_ext);
				var file = await picker.PickSingleFileAsync();
				var content = await ReadTextAsync(file);
				var xml = XElement.Parse(content);
				return xml;




			}
			catch (Exception ex)
			{
				var x =  new XElement("Nothing");
				x.Add(new XElement("Nothing", "Bad Luck!"));

				await MsgShow("Error", $"Xml File Did not Load.\n{x}", "Ok");
				
				return x;
			}
		}

		public static async Task<XElement> ReadXmlFileAsync(StorageFile _file)
		{
			try
			{
				var content = await ReadTextAsync(_file);
				var xml = XElement.Parse(content);
				return xml;
			}
			catch (Exception ex)
			{
				var xml = new XElement("Nothing", ex.Message);

				return xml;
			}
		}

		public static async Task<IEnumerable<XElement>> ReadAndQueryXmlFileAsync(StorageFile _file, string _selectValue)
		{
			try
			{
				var content = await ReadTextAsync(_file);
				var xml = XElement.Parse(content);
				var query = from doc in xml.Descendants(_selectValue)
							select doc;

				return query;
			}
			catch (Exception ex)
			{


				var xml = new XElement("Nothing", ex.Message);
				var query = from doc in xml.Descendants(_selectValue)
							select doc;
				return query;
			}
		}
		public static async Task<IEnumerable<XElement>> ReadAndQueryXmlFileAsync(string _fileName, string _selectValue)
		{

			try
			{
				var file = await ApplicationData.Current.LocalFolder.GetFileAsync(_fileName);
				using (var stream = await file.OpenStreamForReadAsync())
				{
					var xml = XElement.Load(stream);
					var query = from doc in xml.Descendants(_selectValue)
								select doc;

					await stream.FlushAsync();
					return query;


				}
			}
			catch (Exception ex)
			{


				var xml = new XElement("Nothing", ex.Message);
				var query = from doc in xml.Descendants(_selectValue)
							select doc;
				return query;
			}


		}

		/// <summary>
		/// Writing an xml document using XElement 
		/// </summary>
		/// <param name="_FileName">File name</param>
		/// <param name="_xmlFile">XElement that is used</param>
		/// <returns></returns>
		public static async Task WriteXmlFileAsync(string _FileName, XElement _xmlFile)
		{

			//var localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

			StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(_FileName, CreationCollisionOption.ReplaceExisting);

			//await FileIO.WriteTextAsync(file, _xmlFile.ToString());
			using (var stream = await file.OpenStreamForWriteAsync())
			{
				//Save to stream 
				_xmlFile.Save(stream);

				await stream.FlushAsync(); // Realese from memory 
				stream.Dispose();
			}
		}
		/// <summary>
		/// Write Xml FIle with FIle Picker 
		/// </summary>
		/// <param name="_xml"></param>
		/// <param name="_extention"></param>
		/// <returns></returns>
		public static async Task WriteXmlFileAsync(XElement _xml,string _extention)
		{
			try
			{
				var picker = new FileSavePicker();
				picker.SuggestedStartLocation = PickerLocationId.ComputerFolder;
				picker.FileTypeChoices.Add("All Formats", new List<string> { _extention, ".xml", });

				var file = await picker.PickSaveFileAsync();

				using (var stream = await file.OpenStreamForWriteAsync())
				{
					//Write the xml file
					_xml.Save(stream);

					//Flush a Stream 
					await stream.FlushAsync();
					
					//Dispose Stream 
					stream.Dispose();

				}
			}	
			catch(Exception exp)
			{
				
			}
		}

		public static async Task WriteXmlFileAsync(StorageFile _storageFile, XElement _xmlFile)
		{

			if (_storageFile != null)
			{

				using (var stream = await _storageFile.OpenStreamForWriteAsync())
				{
					//Save to stream 
					_xmlFile.Save(stream);

					await stream.FlushAsync(); // Realese from memory 

					stream.Dispose();
				}
			}
		}
		#endregion

		#region Export Image Method's 



		public static async Task LoadImageSourceAsync(Image _img, StorageFile _file)
		{
			if (_file != null)
			{
				using (IRandomAccessStream stream = await _file.OpenAsync(FileAccessMode.Read))
				{
					var bitmap = new BitmapImage();
					await bitmap.SetSourceAsync(stream);
					_img.Source = bitmap;
				}

			}
		}


		/// <summary>
		/// Writes a JPEG to the Windows Phone Platform 
		/// </summary>
		/// <param name="_content"></param>
		/// <param name="_fileName"></param>
		/// <returns></returns>


		public static async Task ExportJpegThumbNailsAsync(string _defaultName, double _dpi, List<Image> _images)
		{
			var fPicker = new FolderPicker();
			//Suggested Folder to Start in
			fPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
			//Suggested view of the Folder 
			fPicker.ViewMode = PickerViewMode.Thumbnail;
			//The types that will be sceen in the folder 
			fPicker.FileTypeFilter.Add(".jpg");

			// Create a new StorageFolder 
			var folder = await fPicker.PickSingleFolderAsync();

			//Foreach Image in the method write the defaultName + the image width 
			foreach (var img in _images)
			{
				//Create the File Name
				var fstr = $"{_defaultName}_{img.Width}.jpg";
				//Create a Storage Folder
				var sf = await folder.CreateFileAsync(fstr);
				//Export it to the Jpeg Format 
				await ExportJpegAsync(sf, img, _dpi);
			}

		}

		public static async Task ExportTiffThumbNails(string _defaultName, double _dpi, params Image[] _images)
		{
			var fPicker = new FolderPicker();
			//Suggested Folder to Start in
			fPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
			//Suggested view of the Folder 
			fPicker.ViewMode = PickerViewMode.Thumbnail;
			//The types that will be sceen in the folder 
			fPicker.FileTypeFilter.Add(".tiff");

			// Create a new StorageFolder 
			var folder = await fPicker.PickSingleFolderAsync();

			//Foreach Image in the method write the defaultName + the image width 
			foreach (var img in _images)
			{
				//Create the File Name
				var fstr = $"{_defaultName}_{img.Width}.tiff";
				//Create a Storage Folder
				var sf = await folder.CreateFileAsync(fstr);
				//Export it to the Tiff Format 
				await ExportTiffAsync(sf, img, _dpi);
			}

		}


		public static async Task ExportPngThumbNails(string _defaultName, double _dpi, params Image[] _images)
		{
			var fPicker = new FolderPicker();
			//Suggested Folder to Start in
			fPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
			//Suggested view of the Folder 
			fPicker.ViewMode = PickerViewMode.Thumbnail;
			//The types that will be sceen in the folder 
			fPicker.FileTypeFilter.Add(".png");

			// Create a new StorageFolder 
			var folder = await fPicker.PickSingleFolderAsync();

			//Foreach Image in the method write the defaultName + the image width 
			foreach (var img in _images)
			{
				//Create the File Name
				var fstr = $"{_defaultName}_{img.Width}.png";
				//Create a Storage Folder
				var sf = await folder.CreateFileAsync(fstr);
				//Export it to the Png Format 
				await ExportPngAsync(sf, img, _dpi);
			}

		}


		/// <summary>
		/// Export Jpeg Image with StorageFile
		/// </summary>
		/// <param name="_file">The Storage file</param>
		/// <param name="_content">The UIElement</param>
		/// <param name="_dpi">The dpi of the file</param>
		/// <returns></returns>
		public static async Task ExportJpegAsync(StorageFile _file, UIElement _content, double _dpi)
		{
			//Create Bitmap
			var bmp = new RenderTargetBitmap();
			//render the control to a bitmap 
			await bmp.RenderAsync(_content);
			var pixelBuffer = await bmp.GetPixelsAsync();

			if (_file != null)
			{
				using (var stream = await _file.OpenAsync(FileAccessMode.ReadWrite))
				{

					var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream);
					//encode the bitmap
					Stream pixelStream = pixelBuffer.AsStream();
					byte[] pixels = new byte[pixelStream.Length];
					await pixelStream.ReadAsync(pixels, 0, pixels.Length);
					encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, (uint)bmp.PixelWidth, (uint)bmp.PixelHeight, _dpi, _dpi, pixels);




					//Set the file name 

					//Clean up the mess
					await encoder.FlushAsync();
				}


			}

		}
		/// <summary>
		/// Export Png Image with StorageFile
		/// </summary>
		/// <param name="_file">The Storage file</param>
		/// <param name="_content">The UIElement</param>
		/// <param name="_dpi">The dpi of the file</param>
		/// <returns></returns>
		public static async Task ExportPngAsync(StorageFile _file, UIElement _content, double _dpi)
		{
			var bmp = new RenderTargetBitmap();
			//render the control to a bitmap 
			await bmp.RenderAsync(_content);
			var pixelBuffer = await bmp.GetPixelsAsync();

			if (_file != null)
			{
				using (var stream = await _file.OpenAsync(FileAccessMode.ReadWrite))
				{

					var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
					//encode the bitmap
					Stream pixelStream = pixelBuffer.AsStream();
					byte[] pixels = new byte[pixelStream.Length];
					await pixelStream.ReadAsync(pixels, 0, pixels.Length);
					encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, (uint)bmp.PixelWidth, (uint)bmp.PixelHeight, _dpi, _dpi, pixels);






					//Clean up the mess
					await encoder.FlushAsync();
				}


			}

		}
		/// <summary>
		/// Export Tiff Image with StorageFile
		/// </summary>
		/// <param name="_file">The Storage file</param>
		/// <param name="_content">The UIElement</param>
		/// <param name="_dpi">The dpi of the file</param>
		/// <returns></returns>
		public static async Task ExportTiffAsync(StorageFile _file, UIElement _content, double _dpi)
		{
			var bmp = new RenderTargetBitmap();
			//render the control to a bitmap 
			await bmp.RenderAsync(_content);
			var pixelBuffer = await bmp.GetPixelsAsync();

			if (_file != null)
			{
				using (var stream = await _file.OpenAsync(FileAccessMode.ReadWrite))
				{

					var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.TiffEncoderId, stream);
					//encode the bitmap
					Stream pixelStream = pixelBuffer.AsStream();
					byte[] pixels = new byte[pixelStream.Length];
					await pixelStream.ReadAsync(pixels, 0, pixels.Length);
					encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, (uint)bmp.PixelWidth, (uint)bmp.PixelHeight, _dpi, _dpi, pixels);




					//Set the file name 

					//Clean up the mess
					await encoder.FlushAsync();
				}


			}

		}


		/// <summary>
		/// Export Png Image with SavePicker 
		/// </summary>
		/// <param name="_content">The UIElement</param>
		/// <param name="_dpi">The dpi of the file</param>
		/// <returns></returns>
		public static async Task ExportPngAsync(UIElement _content, double _dpi)
		{
			RenderTargetBitmap bmp = new RenderTargetBitmap();
			//render the control to a bitmap 
			await bmp.RenderAsync(_content);

			var pixelBuffer = await bmp.GetPixelsAsync();
			//Create a new file picker 
			var savePicker = new FileSavePicker();
			//Set location to Pictures 
			savePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
			//Setup that default extenstion 
			savePicker.DefaultFileExtension = ".png";
			savePicker.FileTypeChoices.Add("png", new string[] { ".png", ".jpg", ".jpeg" });
			StorageFile fileSave = await savePicker.PickSaveFileAsync();
			if (fileSave != null)
			{
				using (var stream = await fileSave.OpenAsync(FileAccessMode.ReadWrite))
				{

					var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
					//encode the bitmap
					Stream pixelStream = pixelBuffer.AsStream();
					byte[] pixels = new byte[pixelStream.Length];
					await pixelStream.ReadAsync(pixels, 0, pixels.Length);
					encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, (uint)bmp.PixelWidth, (uint)bmp.PixelHeight, _dpi, _dpi, pixels);




					//Set the file name 

					//Clean up the mess
					await encoder.FlushAsync();
				}
			}


		}
		/// <summary>
		/// Export Jpeg Image with SavePicker 
		/// </summary>
		/// <param name="_content">The UIElement</param>
		/// <param name="_dpi">The dpi of the file</param>
		public static async Task ExportJpegAsync(UIElement _content, double _dpi)
		{

			var bmp = new RenderTargetBitmap();
			//render the control to a bitmap 
			await bmp.RenderAsync(_content);
			var pixelBuffer = await bmp.GetPixelsAsync();
			//Create a new file picker 
			var savePicker = new FileSavePicker();
			//Set location to Pictures 
			savePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
			//Setup that default extenstion 
			savePicker.DefaultFileExtension = ".jpg";
			savePicker.FileTypeChoices.Add("jpg", new string[] { ".jpg", ".jpeg" });
			StorageFile fileSave = await savePicker.PickSaveFileAsync();
			if (fileSave != null)
			{
				using (var stream = await fileSave.OpenAsync(FileAccessMode.ReadWrite))
				{

					var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream);
					//encode the bitmap
					Stream pixelStream = pixelBuffer.AsStream();
					byte[] pixels = new byte[pixelStream.Length];
					await pixelStream.ReadAsync(pixels, 0, pixels.Length);
					encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, (uint)bmp.PixelWidth, (uint)bmp.PixelHeight, _dpi, _dpi, pixels);




					//Set the file name 

					//Clean up the mess
					await encoder.FlushAsync();
				}
			}
		}

		public static async Task ExportJpegAsync(string _suggestedName, UIElement _content, double _dpi)
		{
			
				var bmp = new RenderTargetBitmap();
				//render the control to a bitmap 
				await bmp.RenderAsync(_content);
				var pixelBuffer = await bmp.GetPixelsAsync();
				//Create a new file picker 
				var savePicker = new FileSavePicker();
				//Create a name 
				
				savePicker.SuggestedFileName = _suggestedName;
				//Set location to Pictures 
				savePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
				//Setup that default extenstion 
				savePicker.DefaultFileExtension = ".jpg";
				savePicker.FileTypeChoices.Add("jpg", new string[] { ".jpg", ".jpeg" });
				StorageFile fileSave = await savePicker.PickSaveFileAsync();
				if (fileSave != null)
				{
					using (var stream = await fileSave.OpenAsync(FileAccessMode.ReadWrite))
					{

						var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream);
						//encode the bitmap
						Stream pixelStream = pixelBuffer.AsStream();
						byte[] pixels = new byte[pixelStream.Length];
						await pixelStream.ReadAsync(pixels, 0, pixels.Length);
						encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, (uint)bmp.PixelWidth, (uint)bmp.PixelHeight, _dpi, _dpi, pixels);


						//Set the file name 

						//Clean up the mess
						await encoder.FlushAsync();
					}







				}
			
		}

		/// <summary>
		/// Export Tiff Image with SavePicker 
		/// </summary>
		/// <param name="_content">The UIElement</param>
		/// <param name="_dpi">The dpi of the file</param>
		public static async Task ExportTiffAsync(UIElement _content, double _dpi)
		{
			var bmp = new RenderTargetBitmap();
			//render the control to a bitmap 
			await bmp.RenderAsync(_content);
			var pixelBuffer = await bmp.GetPixelsAsync();
			//Create a new file picker 
			var savePicker = new FileSavePicker();
			//Set location to Pictures 
			savePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
			//Setup that default extenstion 
			savePicker.DefaultFileExtension = ".tiff";
			savePicker.FileTypeChoices.Add("Tiff Foramt ", new string[] { ".tiff" });
			StorageFile fileSave = await savePicker.PickSaveFileAsync();
			if (fileSave != null)
			{
				using (var stream = await fileSave.OpenAsync(FileAccessMode.ReadWrite))
				{

					var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.TiffEncoderId, stream);
					//encode the bitmap
					Stream pixelStream = pixelBuffer.AsStream();
					byte[] pixels = new byte[pixelStream.Length];
					await pixelStream.ReadAsync(pixels, 0, pixels.Length);
					encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, (uint)bmp.PixelWidth, (uint)bmp.PixelHeight, 72, 72, pixels);




					//Set the file name 

					//Clean up the mess
					await encoder.FlushAsync();
				}
			}

		}

		#endregion

		#region IO Picker Method's 




		/// <summary>
		///  A special await task for dealing with the FileSavePicker
		/// </summary>
		/// <param name="_filter">List(string) Filter for the file Formats</param>
		/// <param name="_method">The Method that excutes the SavePicker Logic</param>
		/// <returns></returns>
		public static async Task SaveTextAsync(string _suggestedName,string _content)
		{
			try
			{
				var picker = new FileSavePicker();
				picker.SuggestedStartLocation = PickerLocationId.ComputerFolder;
				picker.FileTypeChoices.Add("All Formats", new List<string> { ".txt", ".htm", ".html", ".css", ".scss", ".sass", ".php", ".cs", ".vb", ".js", ".json", ".cpp", ".h", ".rb", ".py", ".pyw", ".xml", });

				picker.SuggestedFileName = _suggestedName;
				var file = await picker.PickSaveFileAsync();


				if (file != null)
				{
					//Do the method 
					await WriteTextAsync(file, _content);
				}
				else
				{
					// Do nothing 
				}
			}
			catch (Exception ex)
			{

				await Device10x.MsgShow("Eror", ex.Message, "Ok");
			}



		}

		public static async Task OpenPictureAsync(Image _img)
		{
			var picker = new FileOpenPicker();
			picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
			picker.FileTypeFilter.Add(".png");
			picker.FileTypeFilter.Add(".jpg");
			picker.FileTypeFilter.Add(".jpeg");
			picker.FileTypeFilter.Add(".tiff");

			//Show the Dialog 
			var file = await picker.PickSingleFileAsync();

			if (file != null)
			{
				//Load the Picture 
				await LoadImageSourceAsync(_img, file);
			}
			else
			{
				//Do Nothing for now 
			}
		}

		public static async Task OpenPictureAsync(List<Image> images)
		{
			//Creae the OpenFile Picker 
			var picker = new FileOpenPicker();
			picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
			picker.FileTypeFilter.Add(".png");
			picker.FileTypeFilter.Add(".jpg");
			picker.FileTypeFilter.Add(".jpeg");
			picker.FileTypeFilter.Add(".tiff");

			//Show the Dialog 
			var file = await picker.PickSingleFileAsync();

			if (file != null)
			{
				//Load the Picture 
				//await LoadImageSourceAsync(_img, file);
				foreach(var image in images)
				{
					//Load all images at once 
					await LoadImageSourceAsync(image, file);
				}



			}
			else
			{
				//Do Nothing for now 
			}
		}

		

		/// <param name="_method">The Method that excutes the OpenPicker Logic</param>
		/// <returns></returns>
		public static async Task OpenTextFileAsync(Action<FileOpenPicker, StorageFile> _method)
		{

			var picker = new FileOpenPicker();
			picker.SuggestedStartLocation = PickerLocationId.ComputerFolder;

			picker.FileTypeFilter.Add(".txt");
			picker.FileTypeFilter.Add(".html");
			picker.FileTypeFilter.Add(".css");
			picker.FileTypeFilter.Add(".sass");
			picker.FileTypeFilter.Add(".scss");
			picker.FileTypeFilter.Add(".php");
			picker.FileTypeFilter.Add(".cs");
			picker.FileTypeFilter.Add(".vb");
			picker.FileTypeFilter.Add(".svg");
			picker.FileTypeFilter.Add(".cshtml");
			picker.FileTypeFilter.Add(".xml");
			picker.FileTypeFilter.Add(".js");
			picker.FileTypeFilter.Add(".json");
			picker.FileTypeFilter.Add(".cpp");
			picker.FileTypeFilter.Add(".h");
			picker.FileTypeFilter.Add(".py");
			picker.FileTypeFilter.Add(".pyw");
			var file = await picker.PickSingleFileAsync();

			if (file != null)
			{
				_method?.Invoke(picker, file);
			}
			else
			{
				//Do Nothing for now 
			}

		}
		#endregion

		#region Folder Method's 

		public static async Task FolderPickerAsync(Action<StorageFolder> _method)
		{
			var fPicker = new FolderPicker();
			//Suggested Folder to Start in
			fPicker.SuggestedStartLocation = PickerLocationId.Desktop;
			//Suggested view of the Folder 
			fPicker.ViewMode = PickerViewMode.Thumbnail;
			//Filter 
			fPicker.FileTypeFilter.Add(".txt");
			//Get the folder that has been selected 
			var folder = await fPicker.PickSingleFolderAsync();

			//Excute the Method 
			_method?.Invoke(folder);

		}



		#endregion

	}
}
