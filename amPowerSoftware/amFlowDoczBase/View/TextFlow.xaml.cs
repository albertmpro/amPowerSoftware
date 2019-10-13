using Albert.Standard.Win32;
using amFlowDoczBase.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace amFlowDoczBase.View
{


    /// <summary>
    /// Interaction logic for TextFlow.xaml
    /// </summary>
    public partial class TextFlow : ThemeScreen
    {
        //Field's 
        TxtMode txtmode;


        #region Constructor 
        public TextFlow(TabControl _tab)
        {
            InitializeComponent();

            //Setup Tab 
            SetupTab($"TxtDocument{Count++}", _tab, closeMethod);
            //Setup Commands 
            commands();
        }
        public TextFlow(string _fn,TabControl _tab)
        {
            InitializeComponent();
            //Setup FileInfo 
            FileInfo = new FileInfo(_fn);
            //Setup Tab 
            SetupTab(FileInfo.Name, _tab, closeMethod);
            //Setup Commands 
            commands();
           
        }


        void closeMethod()
        {
            dialog.Show("Closing", "Do you want to close this Text Document?", "Close", "Cancel", () =>
            {
                //Remove the Tab 
                TabItem.RemoveTab();
            });

        }

        void commands()
        {
            //Set the default TxtMode 
            TxtMode = TxtMode.Code;

            //StartView Command 
            AddCommand(DesktopCommands.StartView, (sender, e) =>
            {
                //Go the Start 
                VM.VMTab.SelectedIndex = 0;

            });

            //New Command 
            AddCommand(ApplicationCommands.New, (sender, e) =>
             {
                 dialog.Show("New Text Document", "Do you want to create a new Text Document?", "New", "Cancel", () =>
                    {
                        txtCode.Text = "";
                        txtWriter.Text = "";
                    });

             });
            //Open Command 
            AddCommand(ApplicationCommands.Open, (sender, e) =>
            {
                switch(TxtMode)
                {
                    case TxtMode.Code:
                        //TextCode 
                        VM.LoadTextFile(txtCode, TabItem, FileInfo);
                        break;
                    case TxtMode.Writer:
                        //TxtWriter 
                        VM.LoadTextFile(txtWriter, TabItem, FileInfo);
                        break;
                }

            });
            //Save Command 
            AddCommand(ApplicationCommands.Save, (sender, e) =>
            {
                switch(TxtMode)
                {
                    case TxtMode.Code:
                        VM.SaveTextFile(txtCode, TabItem, FileInfo);
                        break;
                    case TxtMode.Writer:
                        VM.SaveTextFile(txtWriter, TabItem, FileInfo);
                        break;
                }
            });

        }


        #endregion


        void txtmode_Click(object sender, RoutedEventArgs e)
        {
            var opt = sender as OptionButton;

            switch(opt.Tag)
            {
                case "Code":
                    TxtMode = TxtMode.Code;
                    break;
                case "Writer":
                    TxtMode = TxtMode.Writer;
                    break;
            }
        }


        public TxtMode TxtMode
        {
            get { return txtmode; }

            set
            {
                txtmode = value;

                switch(value)
                {
                    case TxtMode.Code:
                        //Show the Code View 
                        txtCode.Visibility = Visibility.Visible;
                        txtWriter.Visibility = Visibility.Collapsed;
                        if(txtWriter.Text != null)
                        {
                            var writer = txtWriter.Text;
                            txtCode.Text = writer;
                        }
                        break;
                    case TxtMode.Writer:
                        //Show the Writer Mode 
                        txtCode.Visibility = Visibility.Collapsed;
                        txtWriter.Visibility = Visibility.Visible;
                        if (txtCode.Text != null)
                        {
                            var code = txtCode.Text;
                            txtWriter.Text = code;
                        }

                  
                        break;
                }
            }
        }



    }

    /// <summary>
    /// Enum to define the TxtMode State 
    /// </summary>
    public enum TxtMode
    {
        Writer, Code
    }
    /// <summary>
    /// Enum to define the TextFlowMode State 
    /// </summary>
    public enum TextFlowMode
    {
        Normal, Theme, Ref
    }
}
