using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Win32;

namespace Albert.Standard.Win32
{

	[TemplatePart(Name = "PART_CloseButton", Type  = typeof(PushButton))]
	public class DocumentTabItem: TabItem 
	{
		//Field's
		PushButton btn = new PushButton(); 

		//Depdendcey 
		public static readonly DependencyProperty IsClosedEnabledProperty = DependencyProperty.Register("IsClosedEnabled",
			typeof(bool),typeof(DocumentTabItem), new PropertyMetadata(true));

		public static readonly DependencyProperty IsPageEnabledProperty = DependencyProperty.Register("IsPageEnabled",
		typeof(bool), typeof(DocumentTabItem), new PropertyMetadata(false));


		public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", 
			typeof(CornerRadius), typeof(DocumentTabItem));

		public static readonly DependencyProperty MainTabProperty = DependencyProperty.Register("MainTab", typeof(TabControl), typeof(DocumentTabItem), null);





		public DocumentTabItem()
		{
			DefaultStyleKey = typeof(DocumentTabItem);

		}

		public DocumentTabItem(string _Header,bool _isClosedEnabled, object _content,TabControl _mainTabControl)
		{
			DefaultStyleKey = typeof(DocumentTabItem);
			Header = _Header;
			IsClosedEnabled = _isClosedEnabled;
			Content = _content;
			MainTab = _mainTabControl;
			SetTab();
		}
		
		public override void OnApplyTemplate()
		{
			btn = GetTemplateChild("PART_CloseButton") as PushButton;
			//Closed Event to the Button 
			btn.Click += Closed_Click;
		}

		public void SetTab()
		{
			if (MainTab != null)
				MainTab.Items.Add(this);
		}

		public event VTabItemEventHandler Closed;

		public void RemoveTab()
		{
			//Remove the Tab
			MainTab.Items.Remove(this);
		}

		void OnClosed(object sender, VTabItemEventArgs e)
		{
			if (Closed != null)
			{
				e.TabItem = this;
				Closed(this, e);
			}
			else if (Closed == null && MainTab != null)
			{
				MainTab.Items.Remove(this);
				Content = null;
			}
		}

		void Closed_Click(object sender, RoutedEventArgs e)
		{
			var args = new VTabItemEventArgs();
			OnClosed(this, args);
			
		}

		//Public Properties 

		public CornerRadius CornerRadius
		{
			get { return (CornerRadius)GetValue(CornerRadiusProperty); }
			set { SetValue(CornerRadiusProperty, value); }
		}


		public TabControl MainTab
		{
			get { return (TabControl)GetValue(MainTabProperty); }
			set { SetValue(MainTabProperty, value); }
		}


		public bool IsClosedEnabled
		{
			get { return (bool)GetValue(IsClosedEnabledProperty); }
			set { SetValue(IsClosedEnabledProperty, value); }
		}

	}



}
