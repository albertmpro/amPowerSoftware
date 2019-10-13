using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Albert.Standard;
using Albert.Standard.Win32;
namespace amFlowDoczBase.Controls
{
    public class FlowPage : Page, IAddCommand
    {
        //Get the Main view Model 
        FlowViewModel vm = (FlowViewModel)App.Current.Resources["viewModel"];

        /// <summary>
        /// A quick whay to add commands 
        /// </summary>
        /// <param name="_command"></param>
        /// <param name="_method"></param>
        public void AddCommand(ICommand _command, ExecutedRoutedEventHandler _method)
        {
            CommandBindings.Add(new CommandBinding(_command, _method));
        }


        public FlowViewModel VM
        {
            get { return vm; }
            set { vm = value; }
        }
    }
}
