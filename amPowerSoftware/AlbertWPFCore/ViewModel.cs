using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using static Albert.Standard.Win32.Win32IO;
using System.Windows;

namespace Albert.Standard.Win32
{
    /// <summary>
    /// Base View Model for my Wpf APplications
    /// </summary>
    public abstract class ViewModel : ViewModelBase
    {
        #region Field's 
        string cf;
        FileInfo fi;
        #endregion


        #region Method's 
        
        
        /// <summary>
        /// Create's a Save Dialog Task
        /// </summary>
        /// <param name="_title"></param>
        /// <param name="_filter"></param>
        /// <param name="_method"></param>
        public void SaveTask(string _title, string _filter, Action<SaveFileDialog> _method)
        {
            //Method 
            SaveDialogTask(_title, _filter, _method);

        }
        
        /// <summary>
        /// Create a Open Dialog Task
        /// </summary>
        /// <param name="_title"></param>
        /// <param name="_filter"></param>
        /// <param name="_method"></param>
        public void OpenTask(string _title, string _filter, Action<OpenFileDialog> _method)
        {
            //
            OpenDialogTask(_title, _filter, _method);
        }
        
        /// <summary>
        /// Export to Png image  method 
        /// </summary>
        /// <param name="_ele"></param>
        public void ExportImage(FrameworkElement _ele)
        {
            SaveDialogTask("Export", "Png Format(.png)|*.png", (s) =>
              {
                  //Create a Png File 
                  Win32IO.CreatePng(s.FileName, 96, _ele);
              });
        }

     
     
        #endregion



        #region Public Propeties
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
            p.Dispose();

        }

        #endregion


    }
}
