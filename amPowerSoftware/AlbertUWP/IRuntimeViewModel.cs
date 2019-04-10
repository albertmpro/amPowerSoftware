using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Albert.Standard;
namespace Albert.Standard.Runtime
{
	public interface IRuntimeViewModel
	{
		//Gets or sets the current frame
		Frame VMFrame { get; set; }
		//Gets or sets the SplitView of the Application 
		SplitView VMSplitView { get; set; }
		
	}
}
