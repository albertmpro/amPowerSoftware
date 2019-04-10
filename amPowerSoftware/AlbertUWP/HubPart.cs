using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Albert.Standard.Runtime
{
	/// <summary>
	/// Special Control to have bothe header and footer for Hub Control
	/// </summary>
	public class HubPart: ContentControl 
	{
		public static DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(object), typeof(HubPart),new PropertyMetadata(null));

		public static DependencyProperty FooterProperty = DependencyProperty.Register("Footer", typeof(object), typeof(HubPart), new PropertyMetadata(null));
		/// <summary>
		/// Default Consturcor 
		/// </summary>
		public HubPart()
		{
			//ReDraw the Template 
			DefaultStyleKey = typeof(HubPart);
		}



		/// <summary>
		/// Gets or set the Header of the Hub section 
		/// </summary>
		public object Header
		{
			get { return (object)GetValue(HeaderProperty); }
			set { SetValue(HeaderProperty, value); }
		}
		/// <summary>
		/// Gets or set the Foooter of the Part
		/// </summary>
		public object Footer
		{
			get { return (object)GetValue(FooterProperty); }
			set { SetValue(FooterProperty, value); }
		}
	}
}
