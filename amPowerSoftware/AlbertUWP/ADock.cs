using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Albert.Standard.Runtime
{
	/// <summary>
	/// Albert M. Byrd's personal verson of the  DockPanel 
	/// </summary>
	public class ADock : ContentControl
	{
		//Side Bar Field's 
		public static DependencyProperty TopBarProperty = DependencyProperty.Register("TopBar", typeof(object), typeof(ADock),null);
		public static DependencyProperty BottomBarProperty = DependencyProperty.Register("BottomBar", typeof(object), typeof(ADock), null);
		public static DependencyProperty LeftBarProperty = DependencyProperty.Register("LeftBar", typeof(object), typeof(ADock), null);
		public static DependencyProperty RightBarProperty = DependencyProperty.Register("RightBar", typeof(object), typeof(ADock), null);
		//Visbikity Bar Field's 
		public static DependencyProperty TopBarVisibilityProperty = DependencyProperty.Register("TopBarVisibility", typeof(Visibility), typeof(ADock), null);
		public static DependencyProperty BottomBarVisibilityProperty = DependencyProperty.Register("BottomBarVisibility", typeof(Visibility), typeof(ADock), null);
		public static DependencyProperty LeftBarVisibilityProperty = DependencyProperty.Register("LeftBarVisibility", typeof(Visibility), typeof(ADock), null);
		public static DependencyProperty RightBarVisibilityProperty = DependencyProperty.Register("RightBarVisibility", typeof(Visibility), typeof(ADock), null);

		//Zoom Field's  
		public static DependencyProperty StretchProperty = DependencyProperty.Register("Stretch", typeof(Stretch), typeof(ADock), new PropertyMetadata(Stretch.None));
		public static DependencyProperty ZoomProperty = DependencyProperty.Register("Zoom", typeof(Thickness), typeof(ADock), new PropertyMetadata(new Thickness(0)));


		/// <summary>
		/// Default Constuctor 
		/// </summary>
		public ADock()
		{
			DefaultStyleKey = typeof(ADock);
			//Visibility
		}
		/// <summary>
		/// Get or sets how content is Stretched 
		/// </summary>
		public Stretch Stretch
		{
			get { return (Stretch)GetValue(StretchProperty); }
			set { SetValue(StretchProperty, value); }
		}
		/// <summary>
		/// Gets or sets the Zooom level
		/// </summary>
		public Thickness Zoom
		{
			get { return (Thickness)GetValue(ZoomProperty); }
			set { SetValue(ZoomProperty, value); }
		}
		/// <summary>
		/// Get or sets the TopBar
		/// </summary>
		public object TopBar
		{
			get { return (object)GetValue(TopBarProperty); }
			set { SetValue(TopBarProperty, value); }
		}

		/// <summary>
		/// Get or sets the RightBar
		/// </summary>
		public object RightBar
		{
			get { return (object)GetValue(RightBarProperty); }
			set { SetValue(RightBarProperty, value); }
		}

		/// <summary>
		/// Get or sets the BottomBar
		/// </summary>
		public object BottomBar
		{
			get { return (object)GetValue(BottomBarProperty); }
			set { SetValue(BottomBarProperty, value); }
		}


		/// <summary>
		/// Get or Set the LeftBar
		/// </summary>
		public object LeftBar
		{
			get { return (object)GetValue(LeftBarProperty); }
			set { SetValue(LeftBarProperty, value); }
		}
		/// <summary>
		/// Get or sets TopBar Visibility
		/// </summary>
		public Visibility TopBarVisibility
		{
			get { return (Visibility)GetValue(TopBarVisibilityProperty); }
			set { SetValue(TopBarVisibilityProperty, value); }
		}
		/// <summary>
		/// Get or sets the BottomBar Visibility
		/// </summary>
		public Visibility BottomBarVisibility
		{
			get { return (Visibility)GetValue(BottomBarVisibilityProperty); }
			set { SetValue(BottomBarVisibilityProperty, value); }
		}

		/// <summary>
		/// Get or sets RightBar Visibility 
		/// </summary>
		public Visibility RightBarVisibility
		{
			get { return (Visibility)GetValue(RightBarVisibilityProperty); }
			set { SetValue(RightBarVisibilityProperty, value); }
		}
		/// <summary>
		/// Get or sets LeftBar Visibility 
		/// </summary>
		public Visibility LeftBarVisibility
		{
			get { return (Visibility)GetValue(LeftBarVisibilityProperty); }
			set { SetValue(LeftBarVisibilityProperty, value); }
		}



	}
}
