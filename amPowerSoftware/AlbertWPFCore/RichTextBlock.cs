using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
namespace Albert.Standard.Win32
{
	public class RichTextBlock: RichTextBox
	{

		public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(RichTextBlock), new PropertyMetadata(new CornerRadius(3)));

		public RichTextBlock()
		{
			//Reset the Look 
			DefaultStyleKey = typeof(RichTextBlock); 

		}
		/// <summary>
		/// Get or set the CornerRadius 
		/// </summary>
		public CornerRadius CornerRadius
		{
			get { return (CornerRadius)GetValue(CornerRadiusProperty); }
			set { SetValue(CornerRadiusProperty, value); }
		}
		
	}

}
