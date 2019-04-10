using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Albert.Standard.Win32
{
	/// <summary>
	/// Creates a way for the UI to use the ViewModel 
	/// </summary>
	public class VMCommand : ICommand
	{

		#region Field's 
		Action method;
		Func<bool> canExecute;

		#endregion

		#region Constructors 

		public VMCommand(Action _method,Func<bool> _canExecute)
		{
			// Link to the Field's 
			method = _method;
			canExecute = _canExecute;
		}

		public VMCommand(Action _method):this(_method,null)
		{
			
			
		}
		#endregion


		public void RaiseCanExecuteChaged()
		{
			if(CanExecuteChanged != null )
			{
				CanExecuteChanged(this, EventArgs.Empty);
			}
		}

		#region ICommand 

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			if (canExecute == null)
			{
				return true;
			}
			else
			{
				bool rv = canExecute.Invoke();
				return rv;
			}
			
		}

		public void Execute(object parameter)
		{
			method.Invoke();
			CanExecute(parameter);
		} 

		#endregion
	}
}
