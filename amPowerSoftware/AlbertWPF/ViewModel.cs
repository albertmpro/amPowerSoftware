using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Albert.Standard.Win32
{
	/// <summary>
	/// Base View Model for my Wpf APplications
	/// </summary>
    public abstract class ViewModel: ViewModelBase
    {
		//Field's
		string cf,fl;
		FileInfo fi; 
		
		/// <summary>
		/// Get or set the Default Filter
		/// </summary>
		public string Filter
		{
			get { return fl; }
			set { fl = value; OnPropertyChanged("Filter"); }
		}

		/// <summary>
		/// Grabs the current file 
		/// </summary>
		public string CurrentFile
		{
			get { return cf; } 
			set { cf = value; OnPropertyChanged("CurrentFIle"); }
		}
		/// <summary>
		/// Get or sets the file infor of the current file
		/// </summary>
		public FileInfo FileInfo
		{
			get { return fi; }
			set { fi = value; OnPropertyChanged("FileInfo"); }
		}


        /// <summary>
        /// Method allows the ViewModel to run other .exe on the system 
        /// </summary>
        /// <param name="exeFile">File path of the .exe file</param>
        public static void RunExeFile(string exeFile)
        {
            Process p = new Process();
            p.StartInfo.FileName = exeFile;
            p.Start();
        }

		//public static Action<string> VMNotify;

		//Interface values 


    }
}
