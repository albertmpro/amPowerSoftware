using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI;
using Windows.UI.ViewManagement;
using static Albert.Standard.Runtime.Device10x;

namespace Albert.Standard.Runtime
{
	public class Page10x : Page
	{
		public void SetTitle(string str)
		{
			//Set the main Title of the Application 
			Device10x.SetTitle(str);
			
			
		}
		public void TitleTheme(Color _background,Color _foreground)
		{
			//Set the Title Theme
		Device10x.TitleBarStyle(_background,_foreground);
		}

		/// <summary>
		/// Quick Message 
		/// </summary>
		/// <param name="_title"></param>
		/// <param name="_maessage"></param>
		/// <param name="_btn"></param>
		/// <returns></returns>
		public async Task MsgShow(string _title,string _message, string _btn)
		{
			await Device10x.MsgShow(_title, _message, _btn);
		}
		/// <summary>
		/// Message with a single method
		/// </summary>
		/// <param name="_title"></param>
		/// <param name="_maessage"></param>
		/// <param name="_btn1"></param>
		/// <param name="_btn2"></param>
		/// <param name="_method"></param>
		/// <returns></returns>
		public async Task MsgShow(string _title, string _message, string _btn1,string _btn2, Action _method)
		{
			await Device10x.MsgShow(_title, _message, _btn1,_btn2,_method);
		}
		/// <summary>
		/// Message with 2 method's 
		/// </summary>
		/// <param name="_title"></param>
		/// <param name="_maessage"></param>
		/// <param name="_btn1"></param>
		/// <param name="_btn2"></param>
		/// <param name="_method1"></param>
		/// <param name="_method2"></param>
		/// <returns></returns>
		public async Task MsgShow(string _title, string _message, string _btn1, string _btn2, Action _method1,Action _method2)
		{
			await Device10x.MsgShow(_title, _message, _btn1, _btn2, _method1, _method2);
		}

	}
}
