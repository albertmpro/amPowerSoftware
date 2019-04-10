using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Albert.Standard.Win32
{
	/// <summary>
	/// Albert's Version of the TextBox
	/// </summary>
	public class ATextField: TextBox
	{
		public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ATextField), new PropertyMetadata(new CornerRadius(3)));

		public static readonly DependencyProperty TextMarginProperty = DependencyProperty.Register("TextMargin", typeof(Thickness), typeof(ATextField), new PropertyMetadata(new Thickness(3)));

		public ATextField()
		{
			//ReDraw the Tempalte 
			DefaultStyleKey = typeof(ATextField);
		}

		public CornerRadius CornerRadius
		{
			get { return (CornerRadius)GetValue(CornerRadiusProperty); }
			set { SetValue(CornerRadiusProperty, value); }
		}
		public Thickness TextMargin
		{
			get { return (Thickness)GetValue(TextMarginProperty); }
			set { SetValue(TextMarginProperty, value); }
		}

	}
}
