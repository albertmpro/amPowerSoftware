using System.IO;
namespace Albert.Standard.Win32
{
	/// <summary>
	/// Designed to represent a folder on the file system 
	/// </summary>
	public class IOFolder: Notify
	{
		DirectoryInfo folder; 

		/// <summary>
		/// Default Constructor 
		/// </summary>
		/// <param name="_folder">Folder path</param>
		public IOFolder(string _folder)
		{
			folder = new DirectoryInfo(_folder);
		}

		/// <summary>
		/// Gets or set the Folder 
		/// </summary>
		public DirectoryInfo Folder
		{
			get { return folder; }
			set { folder = value; OnPropertyChanged("Folder"); }
		}
	}
}
