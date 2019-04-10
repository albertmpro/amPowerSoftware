using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Albert.Standard.Runtime
{
	/// <summary>
	/// A special AppBarButton class for setting up in code
	/// </summary>
	public class CmdButton : AppBarButton
	{
		#region Dependency Proprties 
		public static readonly DependencyProperty ForegroundPressedProperty =
DependencyProperty.Register("ForegroundPressed", typeof(Brush), typeof(CmdButton), null);

		public static readonly DependencyProperty ForegroundPointerOverProperty =
	DependencyProperty.Register("ForegroundPointerOver", typeof(Brush), typeof(PushButton), null); 

		#endregion
		public CmdButton()
		{
			//Do nothing
		}

		/// <summary>
		/// Constructor sets the label 
		/// </summary>
		/// <param name="_label">sets the label</param>
		public CmdButton(string _label)
		{
			//Set the label
			Label = _label;
		}
		/// <summary>
		/// Constructor sets the label and a custom icon 
		/// </summary>
		/// <param name="_label">sets the label</param>
		/// <param name="_uri">sets the path of the icon</param>
		public CmdButton(string _label, string _uri)
		{
			//Set the label 
			Label = _label;
			//Create a Uri 

			//Create a BitmapIcon 
			var bitmapIcon = new BitmapIcon();
			try
			{
				bitmapIcon.UriSource = new Uri(_uri, UriKind.Absolute);
			}
			catch
			{

			}
			//Set the BitmapIcon 
			Icon = bitmapIcon;
		}
		/// <summary>
		/// Constructor sets the label and a default icon 
		/// </summary>
		/// <param name="_label">sets the label</param>
		/// <param name="_symbol">sets the default icon</param>
		public CmdButton(string _label, Symbol _symbol)
		{
			//Create the label 
			Label = _label;
			//Set the label 
			Icon = new SymbolIcon(_symbol);
		}

		public CmdButton(string _label, Color _color)
		{
			//Set the label
			Label = _label;
			var brush = new SolidColorBrush(_color);
			Foreground = brush;
		}
		/// <summary>
		/// Constructor sets the label and a custom icon 
		/// </summary>
		/// <param name="_label">sets the label</param>
		/// <param name="_uri">sets the path of the icon</param>
		public CmdButton(string _label, string _uri, Color _color)
		{
			//Set the label 
			Label = _label;
			//Create a Uri 

			//Create a BitmapIcon 
			var bitmapIcon = new BitmapIcon();
			try
			{
				bitmapIcon.UriSource = new Uri(_uri, UriKind.Absolute);
			}
			catch
			{

			}
			//Set the BitmapIcon 
			Icon = bitmapIcon;
			var brush = new SolidColorBrush(_color);
			Foreground = brush;
		}
		/// <summary>
		/// Constructor sets the label and a default icon 
		/// </summary>
		/// <param name="_label">sets the label</param>
		/// <param name="_symbol">sets the default icon</param>
		public CmdButton(string _label, Symbol _symbol,Color _color)
		{
			//Create the label 
			Label = _label;
			//Set the label 
			Icon = new SymbolIcon(_symbol);

			var brush = new SolidColorBrush(_color);
			Foreground = brush;
		}

	

	}
}
