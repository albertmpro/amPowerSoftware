using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Albert.Standard.Win32
{
	/// <summary>
	/// Design to capture the content's of Folder Browser  
	/// </summary>
	public class FolderBrowser
	{
		FolderBrowserDialog browser;
		DirectoryInfo directory;

		public FolderBrowser(bool _show)
		{
			browser = new FolderBrowserDialog();
			if (_show == true)
			{

	           browser.ShowDialog();

				try
				{
					directory = new DirectoryInfo(browser.SelectedPath);
				}
				catch (Exception ex)
				{

					MessageBox.Show(ex.Message);
				}

			
			   
			}
			else if (_show == false)
			{
				//Do Nothing 
			}

			
		}

		public FolderBrowser(string _path)
		{
			directory = new DirectoryInfo(_path);
		}

		public void Show()
		{
			browser.ShowDialog();
		}
		public string SelectedPath
		{
			get { return browser.SelectedPath; }
			set { browser.SelectedPath = value; }
		}

		public DirectoryInfo DirectoryInfo
		{
			get { return directory; }
			set { directory = value; }
		}


		


	}
}
