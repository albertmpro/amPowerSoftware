using Albert.Standard.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amFlowDoczBase.Controls
{
	public class FlowScreen: DocumentControl
	{


		FlowViewModel vm =(FlowViewModel)App.Current.Resources["viewModel"];


       

		/// <summary>
		/// Get or set   main ViewModel 
		/// </summary>
		public FlowViewModel VM
		{
			get { return vm; }
            set { vm = value; }
	
		}

	}
}
