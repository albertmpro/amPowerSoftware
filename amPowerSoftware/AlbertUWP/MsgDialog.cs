using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.ViewManagement;
using static Albert.Standard.Runtime.Device10x;
using Windows.Phone.UI.Input;
using Windows.Graphics.Display;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;
using Windows.UI;
namespace Albert.Standard.Runtime
{
	public class MsgDialog:ContentDialog 
	{
		public MsgDialog()
		{
			//Do Nothing 
		}

	

		public MsgDialog(string _title, object _content, string _button1)
		{
			Title = _title;
			Content = _content;
			PrimaryButtonText = _button1;

			PrimaryButtonClick += (sender, e) =>
			{
				Hide(); 
			};

		}

		public MsgDialog(string _title,object _content, string _button1, string _button2,Action _action)
		{
			Title = _title;
			Content = _content;
			PrimaryButtonText = _button1;
			SecondaryButtonText = _button2;

			PrimaryButtonClick += (sender, e) =>
			{
				if(_action != null)
				{
					//Do the Action 
					_action();
                    Hide();
				}
				else if(_action == null)
				{
					Hide();
				}
			};
			SecondaryButtonClick += (sender, e) =>
			{
				Hide();
			};

		}


		public MsgDialog(string _title, object _content, string _button1, string _button2, Action _action, Action  _action2)
		{
			Title = _title;
			Content = _content;
			PrimaryButtonText = _button1;
			SecondaryButtonText = _button2;

			PrimaryButtonClick += (sender, e) =>
			{
				if (_action != null)
				{
					//Do the Action 
					_action();
					Hide();
				}
				else if (_action == null)
				{
					Hide();
				}
			};
			SecondaryButtonClick += (sender, e) =>
			{
				if (_action2 != null)
				{
					//Do the Action 
					_action();
					Hide();
				}
				else if (_action2 == null)
				{
					Hide();
				}
			};

		}

		/// <summary>
		/// Setup the Look of the MsgDialog
		/// </summary>
		/// <param name="_backgorund">Backgorund </param>
		/// <param name="_foreground">Foreground</param>
		public void SetColors(Color _backgorund, Color _foreground)
		{
			Background = new SolidColorBrush(_backgorund);
			Foreground = new SolidColorBrush(_foreground);
		}
		/// <summary>
		/// Setup the Look of the MsgDialog
		/// </summary>
		/// <param name="_backgorund">Backgorund </param>
		/// <param name="_foreground">Foreground</param>
		public void SetColors(Brush _backgorund, Brush _foreground)
		{
			Background = _backgorund;
			Foreground = _foreground;
		}
	}
}
