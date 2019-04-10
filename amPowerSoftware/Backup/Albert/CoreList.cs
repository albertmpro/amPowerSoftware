using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace Albert.Standard
{
	/// <summary>
	/// A special List for dealing with data
	/// </summary>
	/// <typeparam name="T">Type</typeparam>
	public class CoreList<T>: ObservableCollection<T>
	{

		public void ForEach(Action<T> _method)
		{
			foreach (var i in this)
			{
				_method?.Invoke(i);
			}
		}

	}
}
