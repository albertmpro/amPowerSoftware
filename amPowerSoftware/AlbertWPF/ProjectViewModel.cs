using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albert.Standard.Win32
{
	/// <summary>
	/// A special ViewModel designed to deal with loading and saving documents 
	/// </summary>
	public class ProjectViewModel : Notify
	{
		/// <summary>
		/// Event for Creating a new Project 
		/// </summary>
		public event Action OnCreateNewProject;

		/// <summary>
		/// Event for Loading the Project 
		/// </summary>
		public event Action OnLoadProject;

		/// <summary>
		/// Event for Saving Project 
		/// </summary>
		public event Action OnSaveProject;
		/// <summary>
		/// Create Project Method 
		/// </summary>
		public void CreateNewProject()
		{
			//Fire On Create Project Evnet 
			OnCreateNewProject?.Invoke();

		}
		/// <summary>
		/// Load Project Method
		/// </summary>
		public void LoadProject()
		{
			//Fire the Load Project Event 
			OnLoadProject?.Invoke();
		}
		/// <summary>
		/// Save Project Method 
		/// </summary>

		public void SaveProject()
		{
			//Fire Save Project Event 
			OnSaveProject?.Invoke();
		}


	}
}
