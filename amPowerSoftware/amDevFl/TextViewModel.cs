using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Albert.Standard.Win32;
using static Albert.Standard.Win32.Win32IO;
namespace amDevFl
{
	/// <summary>
	/// Base ViewModel for dealng with text documents 
	/// </summary>
	public class TextViewModel : ViewModel
	{
		//Default Filter File 
		string filter = "All Files(.)|*.*";


		public void OpenText(string _txt, string _currentFile, FileInfo _fileInfo, DocumentTabItem _tabItem)
		{
			//OpenDialog Lamba Task 
			OpenDialogTask("Open Text File", filter, (o) =>
			{
				_currentFile = o.FileName;
				//Send the text to the Text box 
				_txt = File.ReadAllText(o.FileName);
				//Setup the FileInfo 
				_fileInfo = new FileInfo(o.FileName);
				//Stetup the Tabitem 
				_tabItem.Header = _fileInfo.Name;

			});
		}

		public void SaveText(string _txt, string _currentFile, FileInfo _fileInfo, DocumentTabItem _tabItem)
		{
			if (_currentFile != null)
			{
				//Write your file 
				File.WriteAllText(_currentFile, _txt);

				//File Info 
				_fileInfo = new FileInfo(_currentFile);
				//Set the TabItem Header
				_tabItem.Header = _fileInfo.Name;
			}
			else if (_currentFile == null)
			{

				//Call the SaveDialog Lamba
				SaveDialogTask("Save Text File", filter, (s) =>
				  {
					  //Write your file 
					  File.WriteAllText(s.FileName, _txt);
					  //Create the File Information 
					  _currentFile = s.FileName;
					  //File Info 
					  _fileInfo = new FileInfo(s.FileName);
					  //Set the TabItem Header
					  _tabItem.Header = _fileInfo.Name;

				  });
			}
		}

		public void SaveAsText(string _txt, string _currentFile, FileInfo _fileInfo, DocumentTabItem _tabItem)
		{
			//Call the SaveDialog Lamba
			SaveDialogTask("Save Text File", filter, (s) =>
			{
				//Write your file 
				File.WriteAllText(s.FileName, _txt);
				//Create the File Information 
				_currentFile = s.FileName;
				//File Info 
				_fileInfo = new FileInfo(s.FileName);
				//Set the TabItem Header
				_tabItem.Header = _fileInfo.Name;

			});
		}

	}
}
