using Albert.Standard.Win32;
using amFlowDoczBase.Controls;
using amFlowDoczBase.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using System.Windows.Controls;
using static Albert.Standard.Win32.Win32IO;
namespace amFlowDoczBase
{
	/// <summary>
	/// Main ViewMddel of the Application 
	/// </summary>
	public class FlowViewModel : ViewModel
	{
        #region Field's  


        //Pages 
        TabPage tabPage;

         string title;
		TabControl tab;
        Frame frame;

        //View Model's 
        CodeViewModel code = (CodeViewModel)App.Current.Resources["codeViewModel"];
        DrawViewModel draw = (DrawViewModel)App.Current.Resources["drawViewModel"];

        
        #endregion

        public FlowViewModel()
        {
            //Do nothing 
        }


        #region Text File Logic  

        public void SaveTextFile(CodeBox _txt,DocumentTabItem _tabItem, FileInfo _fileinfo)
		{
			var filter = MakeFilter("All FIles", "*.*");
			SaveDialogTask("Save Text File", filter, (s) =>
			  {
				  //Save the Text File 
				  SaveText(_txt.Text, s.FileName);
                  //Create the fileinfo 
                  _fileinfo = new FileInfo(s.FileName);
                  //Set the TabItem Header
                  _tabItem.Header = _fileinfo.Name;

                  //Send a message 
                  Message($"You have saved{_fileinfo.Name} file in the {_fileinfo.DirectoryName} folder.");
              

              });
		}

        public void SaveTextFile(TextBox _txt, DocumentTabItem _tabItem, FileInfo _fileinfo)
        {
            var filter = MakeFilter("All FIles", "*.*");
            SaveDialogTask("Save Text File", filter, (s) =>
            {
                //Save the Text File 
                SaveText(_txt.Text, s.FileName);
                //Create the fileinfo 
                _fileinfo = new FileInfo(s.FileName);
                //Set the TabItem Header
                _tabItem.Header = _fileinfo.Name;

                //Send a message 
                Message($"You have saved{_fileinfo.Name} file in the {_fileinfo.DirectoryName} folder.");
            });
        }


        public void LoadTextFile(CodeBox _codeBox,DocumentTabItem _tabitem, FileInfo _fileInfo)
		{
			var filter = MakeFilter("All FIles", ".*");
			OpenDialogTask("Open Text FIle", filter, (o) =>
			  {
                  //Code Box 
                  _codeBox.Text = File.ReadAllText(o.FileName);
                  //Setup the File INfo 
                  _fileInfo = new FileInfo(o.FileName);
                  //Setup the Header 
                  _tabitem.Header = _fileInfo.Name;

                  //Send a message 
                  Message($"You have loaded{_fileInfo.Name} from the {_fileInfo.DirectoryName} folder.");


              });
		}

        public void LoadTextFile(TextBox _txt, DocumentTabItem _tabitem, FileInfo _fileInfo)
        {
            var filter = MakeFilter("All FIles", ".*");
            OpenDialogTask("Open Text FIle", filter, (o) =>
            {
                //Load the File 
                _txt.Text = File.ReadAllText(o.FileName);
                //Setup the File INfo 
                _fileInfo = new FileInfo(o.FileName);
                //Setup the Header 
                _tabitem.Header = _fileInfo.Name;

                //Send a message 
                Message($"You have loaded{_fileInfo.Name} from the {_fileInfo.DirectoryName} folder.");

            });
        }


        #endregion

        #region Export Image Logic  

        public void ExportImage(FrameworkElement _content,DocumentTabItem _tabitem,FileInfo _fileinfo)
		{
			var filter = MakeFilter("PNG Format", ".png");

			SaveDialogTask("Export Png File", filter, (s) =>
			 {
				 //Create the Png FIle
				 CreatePng(s.FileName, 96, _content);

                 //Send a message 
                 Message($"You have saved the{_fileinfo.Name} image in the {_fileinfo.DirectoryName} folder.");
             });

		}

		#endregion

		#region Ink Logic  

		public void SaveInk(InkCanvas _ink,DocumentTabItem _tabitem,FileInfo _fileinfo)
		{
			//Create a Save Task 
			SaveDialogTask("Save Ink", "amInk(.amink}|*.amink", (s) =>
			  {
				//Save Ink Strokes 
				 SaveInkStrokes(_ink, s.FileName);
                  //FilieInfo 
                  _fileinfo = new FileInfo(s.FileName);
                  //TabItemHeader 
                  _tabitem.Header = _fileinfo.Name;

                  //Send a Message 
                  Message($"You saved the ink file {_fileinfo.Name} to the {_fileinfo.DirectoryName} folder.");
			  });
		}
			//Load Ink 
			public void LoadInk(InkCanvas _ink,DocumentTabItem _tabitem, FileInfo _fileinfo)
			{
				OpenDialogTask("Load Ink", "amInk(.amink}|*.amink", (o) =>
				{
					//Load Ink Strokes 
					LoadInkStrokes(_ink, o.FileName);
                    
                    //Create the FileInfo 
                    _fileinfo = new FileInfo(o.FileName);
                    
                    //TabItemHeader 
                    _tabitem.Header = _fileinfo.Name;
                    
                    //Send a message 
                    Message($"You have loaded the ink strokes from {_fileinfo.Name} located in the {_fileinfo.DirectoryName} folder.");



                });

			}



        #endregion

        #region RichText Logic 

        public void SaveRTB(RichTextBlock _rtb,DocumentTabItem _tabitem,FileInfo _fileinfo)
        {
            

            SaveDialogTask("Save Your Message", "AB Rich Text(.abrt)|*.abrt", (s) =>
              {
                  
                  SaveXDoc("amflowdocs", "mgsflow",s.FileName, (xml) =>
                  {
                      
                  });

                  //SaveRichTextData(_rtb,s.FileName);
                  //Create New FileInfo 
                  _fileinfo = new FileInfo(s.FileName);
                  //Header 
                  _tabitem.Header = _fileinfo.Name;

                  //Send a Message 
                  Message($"You saved the MSG File {_fileinfo.Name} to the {_fileinfo.DirectoryName} folder.");
              });
        }

        public void LoadRTB(RichTextBlock _rtb,DocumentTabItem _tabitem,FileInfo _fileinfo)
        {
            OpenDialogTask("Load Message", "AB Rich Text(.abrt)|*.abrt", (o) =>
            {
                LoadRichTextData(_rtb, o.FileName);
                //Create New FileInfo 
                _fileinfo = new FileInfo(o.FileName);
                //Header 
                _tabitem.Header = _fileinfo.Name;

                //Send a Message 
                Message($"You have loaded the MSG {_fileinfo.Name} file from the {_fileinfo.DirectoryName} folder.");

            });
        }

        #endregion

        #region Navigation Logic 

        public void NavigateTabPage()
        {
            if (VMFrame != null)
            {
                VMFrame.Navigate(tabPage);
            }
        }


		#endregion

		/// <summary>
		/// Get or set the Main Title 
		/// </summary>
		public string Title
		{
			get { return title; }
			set { title = value; OnPropertyChanged("Title"); }
		}

        /// <summary>
        /// Gets or sets the Main Tab COntrol 
        /// </summary>
		public TabControl VMTab
		{
			get { return tab; }
			set { tab = value; OnPropertyChanged("VMTab"); }
		}
        /// <summary>
        /// Get or set the default Frame of the Application 
        /// </summary>
        public  Frame VMFrame
        {
            get { return frame; }
            set { frame = value; OnPropertyChanged("VMFrame"); }
        }

        public TabPage TabPage
        {
            get { return tabPage; }
            set { tabPage = value;OnPropertyChanged("TabPage"); }
        }

        public CodeViewModel Code
        {
            get { return code; }
            set { code = value; OnPropertyChanged("Code"); }
        }

        public DrawViewModel Draw
        {
            get { return draw; }
            set { draw = value; OnPropertyChanged("Draw"); }
        }

    }
}
