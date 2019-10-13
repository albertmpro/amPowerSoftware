using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Albert.Standard.Win32
{

    /// <summary>
    /// Base Shell For WPF Application's 
    /// </summary>
    public class Shell: Window, IAddCommand, ILogic, IRunProgram
    {


        #region Method's 
        /// <summary>
        /// Method used to Quickly add a command
        /// </summary>
        /// <param name="_command"></param>
        /// <param name="_method"></param>
        public void AddCommand(ICommand _command, ExecutedRoutedEventHandler _method)
        {
            CommandBindings.Add(new CommandBinding(_command,_method));
        }
       
        public void RunProgram(string _fileName)
        {
            //Start the FIle nme 
            var p = Process.Start(_fileName);
        }
        /// <summary>
        /// A quick way to add extra logic to the constructor 
        /// </summary>
        public void Logic()
        {
            //Run On Logic 
            OnLogic();
        }
        /// <summary>
        /// Override method for handling the Logic of the Application 
        /// </summary>
        public virtual void OnLogic()
        {

        }

        /// <summary>
        /// Overide method to display a string message
        /// </summary>
        /// <param name="_str"></param>
        public virtual void ShellMsg(string _str)
        {
            //Do nothing for now 
        }
        #endregion
    }
}
