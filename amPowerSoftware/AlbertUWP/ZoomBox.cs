using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI;
using Windows.UI.Xaml;

namespace Albert.Standard.Runtime
{
	public class ZoomBox: ContentControl
	{
		public static DependencyProperty StretchProperty = DependencyProperty.Register("Stretch",typeof(Stretch),typeof(ZoomBox), new PropertyMetadata(Stretch.Uniform));

		public static DependencyProperty ZoomProperty = DependencyProperty.Register("Zoom", typeof(Thickness), typeof(ZoomBox), new PropertyMetadata(new Thickness(0)));


		
		/// <summary>
		/// Default Constructor 
		/// </summary>
		public ZoomBox()
		{
			DefaultStyleKey = typeof(ZoomBox);
		}

		public Stretch Stretch
		{
			get { return (Stretch)GetValue(StretchProperty); }
			set { SetValue(StretchProperty, value); }
		}

		public Thickness Zoom
		{
			get { return (Thickness)GetValue(ZoomProperty); }
			set { SetValue(ZoomProperty, value); }
		}




	}
}
