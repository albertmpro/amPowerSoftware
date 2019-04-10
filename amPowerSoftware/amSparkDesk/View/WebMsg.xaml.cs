using Albert.Standard.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace amSparkDesk.View
{
	/// <summary>
	/// Interaction logic for WebMsg.xaml
	/// </summary>
	public partial class WebMsg : DevDoc
	{
		//Get the ViewModel
		WebMsgViewModel vm = (WebMsgViewModel)App.Current.Resources["wmViewModel"];
		public WebMsg(TabControl _tab)
		{

			InitializeComponent();
			//Create a new TabItem 
			TabItem = new DocumentTabItem($"MsgDocument{Count++}", true, this, _tab);
			TabItem.Focus();
			//Commands 
			Commands();

			


		}

		void Commands()
		{
			//NEw Commmand
			AddCommand(ApplicationCommands.New, (sender, e) =>
			 {
				 //Clear the text box 
				 txt.Text = "";
			 });
			//Open Command 
			AddCommand(ApplicationCommands.Open, (sender, e) =>
			 {

			 });

			AddCommand(DesktopCommands.Export, (sender, e) =>
			{
				//Create the image  
				vm.Export(txt);
			});


		}

		private void slideFontSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			try
			{
				if (slideFontSize != null)
				{
					//Set the FontSize
					txt.FontSize = (double)slideFontSize.Value;
				}
			}
			catch
			{
				slideFontSize.Value = 10;
			}
		}

		void opt_Click(object sender, RoutedEventArgs e)
		{
			var opt = sender as OptionButton;

			switch (opt.Tag)
			{
				case "Left":
					txt.TextAlignment = TextAlignment.Left;
					break;
				case "Center":
					txt.TextAlignment = TextAlignment.Center;
					break;
				case "Right":
					txt.TextAlignment = TextAlignment.Right;
					break;
			}
		}

		private void slideBorder_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (slideBorder != null)
			{
				//Create Double 
				var db = (double)slideBorder.Value;
				//Change the Border size
				txt.BorderThickness = new Thickness(db);
			}
		}

		void optCP_Click(object sender, RoutedEventArgs e)
		{
			var opt = sender as OptionButton;
			var brush = (SolidColorBrush)opt.BorderBrush;
			var color = brush.Color;
			switch (opt.Tag)
			{
				default:
					colorPicker.SelectedColor = color;
					break;
				
			}



		}

		private void colorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
		{
			var brush = new SolidColorBrush((Color)colorPicker.SelectedColor);
			if(optBack.IsChecked == true)
			{
				txt.Background = brush;
			}
			else if(optText.IsChecked == true)
			{
				txt.Foreground = brush;
			}
			else if(optBorder.IsChecked == true)
			{
				txt.BorderBrush = brush;
			}
		}
	}
}
