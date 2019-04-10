using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
namespace Albert.Standard.Win32
{
	public interface IFileManager
	{
		/// <summary>
		/// Gets or sets the info on the file you are working on.
		/// </summary>
		FileInfo FileInfo { get; set; }
		/// <summary>
		/// Gets or sets the OpenFileDialog for the document you are on 
		/// </summary>
		OpenFileDialog OpenDialog { get; set; }
		/// <summary>
		/// Gets or sets the SaveFileDialog for the document you are on 
		/// </summary>
		SaveFileDialog SaveDialog { get; set; }
		/// <summary>
		/// Gets or sets the Current file 
		/// </summary>
		string CurrentFile { get; set; }


	}
	public interface ILoadSaveMethod
	{
		void Load();

		void Save();

		event Action OnSave;

		event Action OnLoad;
	}
}
