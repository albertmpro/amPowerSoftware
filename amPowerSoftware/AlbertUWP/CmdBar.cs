using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Albert.Standard.Runtime
{
	/// <summary>
	/// A special CommandBar for CodeBehind(Yes Code Behind) 
	/// </summary>
	public class CmdBar: CommandBar
	{
		public void AddPrimary(CmdButton btn)
		{
			PrimaryCommands.Add(btn);
		}
		public void AddSecondary(CmdButton btn)
		{
			SecondaryCommands.Add(btn);
		}

		public void AddPrimary(CmdButton btn, params CmdButton[] btns)
		{
			PrimaryCommands.Add(btn);

			foreach (var i in btns)
			{
				PrimaryCommands.Add(i);
			}
		}
		public void AddSecondary(CmdButton btn, params CmdButton[] btns)
		{
			SecondaryCommands.Add(btn);

			foreach(var i in btns)
			{
				SecondaryCommands.Add(i);
			}
		}


	}
}
