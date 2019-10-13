using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert.Standard.Win32;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Controls;
using System.Windows.Media;
namespace amFlowDoczBase
{

	#region  TemplateEventArgs
	/// <summary>
	/// An EventArgs design to setup Templates for Text Documents 
	/// </summary>
	public class TemplateEventArgs: RoutedEventArgs
	{
		public bool IsPlusAdded { get; set; }
		public string Template { get; set; }

		public void ApplyTemplate(string _text)
		{
			switch(IsPlusAdded)
			{
				case true: //Add the Template Along with th e Text already anythere
					_text += Template;
					break;
				case false:// Make the entire Text your Template 
					_text = Template;
					break;
			}
		}
	}
	#endregion

	#region NewInkEventArgs 
	public class NewInkEventArgs : DrawEventArgs
	{
		public void CreatNewInkCanvas(InkCanvas _inkcanvas, DrawingAttributes _drawatt)
		{
			//Setup the InkCanvas
			_inkcanvas.Width = Width;
			_inkcanvas.Height = Height;
			_inkcanvas.Background = new SolidColorBrush(BackColor);
			
			//Setup Drawing Attributes 
			_drawatt.Color = ForeColor;
		

		}
	}

	#endregion

	#region NewFlowMsgEventArgs

	public class NewFlowMsgEventArgs: DrawEventArgs
	{
		public void NewRichTextBlock(RichTextBlock _rtb)
		{
			//Background
			var back = new SolidColorBrush(BackColor);
			//Foreground 
			var fore = new SolidColorBrush(ForeColor);
			
			//Setup RichTextBlock 
			_rtb.Background = back;
			_rtb.Foreground = fore;
			_rtb.Width = Width;
			_rtb.Height = Height;
		


		}
	}

	#endregion





}
