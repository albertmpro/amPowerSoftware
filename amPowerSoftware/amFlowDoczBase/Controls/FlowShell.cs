using Albert.Standard.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace amFlowDoczBase.Controls
{

    /// <summary>
    /// Defines the Default window for the Application 
    /// </summary>
    public class FlowShell : Window, IAddCommand
    {
        //Get the Main view Model 
        FlowViewModel vm = (FlowViewModel)App.Current.Resources["viewModel"];



        public void AddCommand(ICommand _command, ExecutedRoutedEventHandler _method)
        {
            CommandBindings.Add(new CommandBinding(_command, _method));
        }

        /// <summary>
        /// Gets or sets the main Viewmodel of the Application 
        /// </summary>
        public FlowViewModel VM
        {
            get { return vm; }
            set { vm = value; }
        }



    }
}
