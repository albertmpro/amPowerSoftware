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
using Albert.Standard.Win32;
using tk = Xceed.Wpf.Toolkit;
namespace amDevFl.View
{
    /// <summary>
    /// Interaction logic for WebMsgFlow.xaml
    /// </summary>
    public partial class WebMsgFlow : FlowDoc 
    {
		WebMsgViewModel vmmsg;
        public WebMsgFlow(TabControl _tab)
        {
            InitializeComponent();

			TabItem = new DocumentTabItem($"WebMsg{Count++}",true, this, _tab);
			//TabItem Close Method 
			TabItem.Closed += (sender, e) =>
			 {
				 //Create the Message Box
				 var msg = tk.MessageBox.Show("Do you want to Close this Tab?", "Closing Tab", MessageBoxButton.YesNo);

				 switch(msg)
				 {
					 case MessageBoxResult.Yes:
						 //Close Tabs
						 TabItem.RemoveTab();
						 break;
					 case MessageBoxResult.No:

						 break;
				 }

			 };

			//Link to the 
			vmmsg = VM.WebMsg;
			//Commands
			commands();

			//Focus 
			TabItem.Focus();
			txt.Focus();

	

        }
		/// <summary>
		/// Add the Commands to this Application 
		/// </summary>
		void commands()
		{
			//New Command 
			AddCmd(ApplicationCommands.New, (sender, e) =>
			{
				var msg = tk.MessageBox.Show("Do you want to create a new Message?", "New Message", MessageBoxButton.YesNo);

				switch (msg)
				{
					case MessageBoxResult.Yes:
						txt.Text = "";
						break;
					case MessageBoxResult.No:
						// Do nothing
						break;
				}

			});

			//Open Command 
			AddCmd(ApplicationCommands.Open, (sender, e) =>
			{
				VM.WebMsg.OpenWebMsg(txt, CurrentFile, FileInfo, TabItem);
			});

			//Save Command
			AddCmd(ApplicationCommands.Save, (sender, e) =>
			{
				VM.WebMsg.SaveWebMsg(txt, CurrentFile, FileInfo, TabItem);
			});

			AddCmd(DesktopCommands.SaveAs, (sender, e) =>
			{
				VM.WebMsg.SaveAsWebMsg(txt, CurrentFile, FileInfo, TabItem);
			});
			//Export 
			AddCmd(DesktopCommands.Export, (sender, e) =>
			{
				VM.WebMsg.ExportWebMsg(txt, TabItem);
			});
		}

		void optCP_Click(object sender, RoutedEventArgs e)
		{
			var opt = sender as OptionButton;
			var brush = (SolidColorBrush)opt.BorderBrush;
			var color = brush.Color;
			colorPicker.SelectedColor = color;
			



		}

		void colorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
		{
			var brush = new SolidColorBrush((Color)colorPicker.SelectedColor);
			if (optBack.IsChecked == true)
			{
				txt.Background = brush;
			}
			else if (optText.IsChecked == true)
			{
				txt.Foreground = brush;
			}
			else if (optBorder.IsChecked == true)
			{
				txt.BorderBrush = brush;
			}
		}

		void optAlign_Click(object sender,RoutedEventArgs e)
		{
			var opt = sender as OptionButton;

			switch(opt.Tag)
			{
				case "left": //Left Align
					txt.TextAlignment = TextAlignment.Left;
					break;
				case "center":// Center Align
					txt.TextAlignment = TextAlignment.Center;
					break;
				case "right": //Right Align
					txt.TextAlignment = TextAlignment.Right;
					break;
			}

		}
		 void slide_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			var slide = sender as Slider;

			if (slide.Value != null)
			{
				//Grab the slide value
				var sv = slide.Value;
				switch (slide.Tag)
				{
					case "size": //Control the FontSize
						try
						{
							txt.FontSize = sv;
						}
						catch //Don't let it get to 0
						{
							txt.FontSize = 10;
						}
						break;
					case "border": //Control the Border Size
						txt.BorderThickness = new Thickness(sv);
						break;
					case "radius": //Control the Radius
						txt.CornerRadius = new CornerRadius(sv);
						break;
				}
			}
		}
	}
}

