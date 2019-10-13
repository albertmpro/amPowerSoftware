using Albert.Standard.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace abFlowDocs.Controls
{
    /// <summary>
    /// Main Control type for this Application 
    /// </summary>
    public class FlowDoc : DocumentControl
    {
        //Field's 
        DocViewModel vm = (DocViewModel)App.Current.Resources["viewModel"];
        DocumentDialog dialog;
        
        
        public FlowDoc()
        {
            dialog = new DocumentDialog();
            //Set it at the top 
            TopDialogBar = dialog;
        }


        /// <summary>
        /// Method to quickly close the Tab 
        /// </summary>
        /// <param name="_title"></param>
        /// <param name="_question"></param>
        /// <param name="_method"></param>
        public void ShowClose(string _title,string _question,Action _method)
        {
            //Show the Dialog 
            dialog.Show(_title, _question, "Close", "Cancel", _method);

        }
        /// <summary>
        /// Method to quickly create a new project 
        /// </summary>
        /// <param name="_title"></param>
        /// <param name="_question"></param>
        /// <param name="_method"></param>
        public void ShowNew(string _title, string _question, Action _method)
        {
            //Show the Dialog 
            dialog.Show(_title, _question, "New", "Cancel", _method);

        }
        /// <summary>
        /// Gets or sets the Default View Model
        /// </summary>
        public DocViewModel VM
        {
            get { return vm; }
            set { vm = value; }
        }
    }
}
