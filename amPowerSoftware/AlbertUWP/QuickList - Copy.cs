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
	/// A special grid view that can easily be setup in code behind
	/// </summary>
	public class QuickListView:GridView
	{
		
		public void SetupList(Application _app, string _itemTemplate,object _Source)
		{
			if(_app !=null)
			{
				ItemTemplate = (DataTemplate)_app.Resources[_itemTemplate];
				ItemsSource = _Source;
			}
		}

		public void SetupList(Application _app, string _itemTemplate, object _Source, string _itemPanel)
		{
			if (_app != null)
			{
				ItemTemplate = (DataTemplate)_app.Resources[_itemTemplate];
				ItemsPanel = (ItemsPanelTemplate)_app.Resources[_itemPanel];
				ItemsSource = _Source;
			}
		}


	}
}
