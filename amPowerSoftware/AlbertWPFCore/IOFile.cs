using System.IO;

namespace Albert.Standard.Win32
{

	public class IOFile: Notify
	{
		FileInfo fileInfo;


		public IOFile(string _filename)
		{
			//Create the FileInfoObject
			fileInfo = new FileInfo(_filename);
		}


		public FileInfo FileInfo
		{
			get { return fileInfo; }
			set { fileInfo = value; OnPropertyChanged("FileInfo"); }
		}

	}
	
}
