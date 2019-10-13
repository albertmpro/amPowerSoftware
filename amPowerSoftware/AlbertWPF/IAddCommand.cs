using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Albert.Standard.Win32
{
	public interface IAddCommand
	{
		void AddCommand(ICommand _command, ExecutedRoutedEventHandler _method);
	}
}
