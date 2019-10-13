using abFlowDocs.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Albert.Standard.Win32;
using static System.IO.File;
using static Albert.Standard.Win32.Win32IO;
using System.IO;

namespace abFlowDocs.View
{
    /// <summary>
    /// Interaction logic for TextFlow.xaml
    /// </summary>
    public partial class TextFlow : FlowDoc
    {

        //Field's 
        TextMode mode;
        public TextFlow(TabControl _tab)
        {
            InitializeComponent();

            //Setup Your Tab 
            SetupTab($"TextFile{Count++}", _tab, Close);

            //Do your Logic 
            Logic();
        }



        public TextFlow(string _filename, TabControl _tab)
        {

           
            //Setup File
            var file = ReadAllText(_filename);
            FileInfo = new FileInfo(file);
            CurrentFile = file;

            switch(TextMode)
            {
                case TextMode.Code:
                    txtCode.Text = file;
                    break;
                case TextMode.Write:
                    txtWriter.Text = file;
                    break;
            }

            //Setup Tab 
            SetupTab(FileInfo.Name, _tab,Close);
       
            //Do your Logic 
            Logic();
        }

        void Close()
        {
            ShowClose("Closing Text File", "Do you want to close this Text FIle?", () =>
              {
                  //Remove the Tab
                  TabItem.RemoveTab();
              
              });
        }

        public override void OnLogic()
        {
            //Filter 
            var filter = VM.Filters().Text;  
            //Start with Code Mode
            TextMode = TextMode.Code;

            //Commands 

            //New Command 
            AddCommand(ApplicationCommands.New, (sender, e) =>
             {
                 ShowNew("New Text File", "Do you want to create a new Text File?", () =>
                   {
                       //Create New Text File 
                       TabItem.Header = $"TextFile{Count++}";
                       txtCode.Text = "";
                       txtWriter.Text = "";
                   
                   });
             });

            AddCommand(ApplicationCommands.Open, (sender, e) =>
            {
                //Use ViewModel Open Task
                VM.OpenTask("Open Text File", filter, (o) =>
                {
                    //Clear TextBox's 
                    txtCode.Text = "";
                    txtWriter.Text = "";
                    //Setup the Current File 
                    CurrentFile = o.FileName;

                    //Seutp FileInfo 
                    FileInfo = new FileInfo(o.FileName);
                    //Grab the Text
                    var file = ReadAllText(o.FileName);
                    switch (TextMode)
                    {
                        case TextMode.Code:
                            //Load to the Code Ediior 
                            txtCode.Text = ReadAllText(o.FileName);
                            break;
                        case TextMode.Write:
                            //Load to the Writer Editor 
                            txtWriter.Text = ReadAllText(o.FileName);

                            break;
                    }



                });

            });

            AddCommand(ApplicationCommands.Save, (sender, e) =>
            {
                
                if (CurrentFile != null)
                {
                        switch (TextMode)
                        {
                            case TextMode.Code:
                                //Write from the Codebox;
                                WriteAllText(CurrentFile, txtCode.Text);
                                break;
                            case TextMode.Write:
                                //Write from the Writer;
                                WriteAllText(CurrentFile, txtWriter.Text);
                                break;
                        }

                }
                else if (CurrentFile == null)
                {

                    VM.SaveTask("Save Text File", filter, (s) =>
                    {
                        switch (TextMode)
                        {
                            case TextMode.Code:
                                //Write from the Codebox;
                                WriteAllText(s.FileName, txtCode.Text);
                                break;
                            case TextMode.Write:
                                //Write from the Codebox;
                                WriteAllText(s.FileName, txtWriter.Text);
                                break;
                        }
                    });

                }

            });

            AddCommand(DesktopCommands.SaveAs, (sender, e) =>
            {
               
                VM.SaveTask("Save Text File", filter, (s) =>
                {
                    switch(TextMode)
                    {
                        case TextMode.Code:
                            //Write from the Codebox;
                            WriteAllText(s.FileName, txtCode.Text);
                            break;
                        case TextMode.Write:
                            //Write from the Codebox;
                            WriteAllText(s.FileName, txtWriter.Text);
                            break;
                    }
                });
            });
        }

        void Txtmode_Click(object sender, RoutedEventArgs e)
        {
            var opt = sender as OptionButton;

            switch(opt.Tag)
            {
                case "Code":
                    TextMode = TextMode.Code;
                    break;
                case "Writer":
                    TextMode = TextMode.Write;
                    break;
                      
            }

        }

        #region Public Properties 

        public TextMode TextMode
        {
            get { return mode; }
            set
            {
                mode = value;

                switch (value)
                {
                    case TextMode.Code:
                        //Show the Code View 
                        txtCode.Visibility = Visibility.Visible;
                        txtWriter.Visibility = Visibility.Collapsed;
                        if(txtWriter.Text != null)
                        {
                            txtCode.Text = txtWriter.Text;
                           
                        }
                      
                        break;
                    case TextMode.Write:
                        //Show the Writer Mode 
                        txtCode.Visibility = Visibility.Collapsed;
                        txtWriter.Visibility = Visibility.Visible;
                        if (txtCode.Text != null)
                        {
                            txtWriter.Text = txtCode.Text;

                        }
                        break;
                }
            }
        }

        #endregion

    }



}
