using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
namespace Albert.Standard.Win32
{

	/// <summary>
	/// Basic EventArgs for Drawing objects
	/// </summary>
	public class DrawEventArgs: RoutedEventArgs 
	{
		/// <summary>
		/// Get or sets the Width of the Draw Document
		/// </summary>
		public double Width { get; set; }
		/// <summary>
		/// Get or sets the Height of the draw document
		/// </summary>
		public double Height { get; set; }
		/// <summary>
		/// Get or set the Background Color of the draw document 
		/// </summary>
		public Color BackColor { get; set; }
		/// <summary>
		/// Get or set the Foreground color of the draw document
		/// </summary>
		public Color ForeColor { get; set; }
	}
}
