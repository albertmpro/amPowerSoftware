using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Albert.Standard.Win32
{
	/// <summary>
	/// A special class for Event driven Console Applcations 
	/// </summary>
	public static class ConsoleApp
	{
	
		#region Program Method's  

		/// <summary>
		/// Method help's easy create the program to be used for a Console Application  
		/// </summary>
		/// <param name="_title"> Title of the Program</param>
		/// <param name="_returnMethod">Used to restart the program</param>
		/// <param name="_start">The Start Program </param>
		/// <param name="_logic">Logic of the Program</param>
		public static void RunProgram(string _title, Action _returnMethod,Action _start, Action _logic)
		{
			Clear();// Clear the console 
			WriteLine(_title);
			WriteLine("------------------------");
			WriteLine();
			Write("Do you want to start? (y/n): ");
			var st = ReadLine(); // Type here

			if (st == "y")
			{
				//Run the Logic  
				_logic.Invoke();
			}
			else
			{
				ExitProgram(_returnMethod,_start);
			}
		}




		/// <summary>
		/// Gives you an option to exit the code back to the start method 
		/// </summary>
		/// <param name="_program">the current code being run</param>
		public static void ExitProgram(Action _program, Action _startup)
		{
			//Exit 
			Write("Do you want to go back to the start? (y/n): ");
			var aws = ReadLine(); // type in y 

			switch(aws)
			{
				case "y":
					//Run the start up method 
					_startup?.Invoke();
					break;
				case "n":
					//Run the program method 
					_program?.Invoke();
					break;
				default:
					//Run the start up method 
					_startup?.Invoke();
					break;
			}


			
		}


		#endregion


	}
}
