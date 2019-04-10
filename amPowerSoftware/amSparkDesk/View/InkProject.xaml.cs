using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Albert.Standard.Win32;
using System.IO;
using Albert.Standard;

namespace amSparkDesk.View
{
	/// <summary>
	/// Interaction logic for InkProject.xaml
	/// </summary>
	public partial class InkProject : DevDoc
	{
		//Field's
		double newWidth, newHeight,oldWidth,oldHeight;
		//Brushes
		SolidColorBrush transpBrush,oldBrush;
		//InkViewModel 
		InkViewModel inkVM;
	

	
		public InkProject(TabControl _tab)
		{
			InitializeComponent();

			//Setup the ViewModel 
			inkVM = (InkViewModel) App.Current.Resources["inkViewModel"];
			//Default oldBrush 
			oldBrush = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
			//Transparent Brush 
			transpBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));

		

			//Set the New width and height 
			newWidth = 1920;
			newHeight = 1080;
			

			
			//Create a new TabITem

			TabItem = new DocumentTabItem($"InkDocument{Count++}", true, this, _tab);
			TabItem.Focus();
			//On Close Tab 
			TabItem.Closed += (sender, e) =>
			{
				var msg = MessageBox.Show("Do you want to close this tab?", "Closeing tab", MessageBoxButton.YesNo);
				switch (msg)
				{
					case MessageBoxResult.Yes:
						//Remove the tab 
						TabItem.RemoveTab();
						break;
					case MessageBoxResult.No:
						// Do nothing 
						break;
				}
			};


			//cmb new Item 
			cmbPresets.SelectionChanged += (sender, e) =>
			{
				var item = (DrawPaper)cmbPresets?.SelectedItem;

				runWidth.Text = $"{item.Width}px";
				runHeight.Text = $"{item.Height}px";
			};
			//Commands 
			Commands();
		}

		void Commands()
		{
			//New Command 
			CommandBindings.Add(new CommandBinding(ApplicationCommands.New, (sender,e) =>
			{
				//Show the New Item Window 
				winNewItem.Show();
			}));

			//Open Command 
			CommandBindings.Add(new CommandBinding(ApplicationCommands.Open, (sender, e) =>
			{
				//Open your ink file 
				inkVM.OpenInk(inkCanvas, CurrentFile, FileInfo, TabItem);

			}));
			//Save Command 
			CommandBindings.Add(new CommandBinding(ApplicationCommands.Save, (sender, e) =>
			{
				//Save your inkFile 
				inkVM.SaveInk(inkCanvas, CurrentFile, FileInfo, TabItem);

			}));
			//SaveAs Command 
			CommandBindings.Add(new CommandBinding(DesktopCommands.SaveAs, (sender, e) =>
			{

				//Save your inkFile 
				inkVM.SaveAsInk(inkCanvas, CurrentFile, FileInfo, TabItem);


			}));

			//Export Image
			CommandBindings.Add(new CommandBinding(DesktopCommands.Export, (sender, e) =>
			{
				//Export Window 
				winExport.Show();
			}));

		}


		void newitem_Click(object sender, RoutedEventArgs e)
		{
			var push = sender as PushButton;

			switch (push.Tag)
			{
				case "Ok":
					var item = (DrawPaper)cmbPresets?.SelectedItem;

					//Clear the Strokes 
					inkCanvas.Strokes.Clear();
					//Set the new Width and Height
					inkCanvas.Width = item.Width;
					inkCanvas.Height = item.Height;
					
					//Close Window 
					winNewItem.Close();
					break;
				case "Cancel":

					//Close Window 
					winNewItem.Close();
					break;
			}
} 

		void export_Click(object sender, RoutedEventArgs e)
		{
			var push = sender as PushButton;

			switch(push.Tag)
			{
				case "Export":

					switch(chkTransparent.IsChecked)
					{
						case true:// Drop the Background 
							inkCanvas.Background = transpBrush;
							inkVM.ExportInk(inkCanvas);
							break;
						case false: //Do it without changing the background 
							inkVM.ExportInk(inkCanvas);
							break;

					}
					winExport.Close();
					break;
				case "Cancel":

					winExport.Close();
					break;
			}



		}

		void optPenSize_Click(object sender, RoutedEventArgs e)
		{
			var opt = sender as OptionButton;

			switch(opt.Tag)
			{
				case "Thin":
					drawAtt.Width = 1.5;
					drawAtt.Height = 1.5;
					slideSize.Value = 1.5;
					break;
				case "Pen":
					drawAtt.Width = 3.5;
					drawAtt.Height = 3.5;
					slideSize.Value = 3.5;
					break;
				case "Marker":
					drawAtt.Width = 15;
					drawAtt.Height = 15;
					slideSize.Value = 15;
					break;
				case "Paint":
					drawAtt.Width = 45;
					drawAtt.Height = 45;
					slideSize.Value = 45;
					break;
			}
		}

		void opt_Click(object sender, RoutedEventArgs e)
		{
			var opt = sender as OptionButton;
			switch (opt.Tag)
			{
				case "Ink": //Ink 

					inkCanvas.EditingMode = InkCanvasEditingMode.Ink;
			  
					break;
				case "Erase": // Erase by Pixel 
					inkCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
					break;
				case "EraseS": //Erase by Stroke
					inkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
					break;
				case "Select": //Select an Object
					inkCanvas.EditingMode = InkCanvasEditingMode.Select;
					break;

			}
		}

		void optCP_Click(object sender, RoutedEventArgs e)
		{
			var opt = sender as OptionButton;
			var brush = (SolidColorBrush)opt.BorderBrush;
			var color = brush.Color;
			colorPicker.SelectedColor = color;
		
		}

		private void slideSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			try
			{
				
				if (slideSize != null)
				{
					var d = (double)slideSize.Value;
					//Change Brush Size 
					drawAtt.Width = d;
					drawAtt.Height = d;
					//lastBrushSize = d;
					
				}
			}
			catch
			{

			}
		}

		private void colorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
		{
			var color = (Color)colorPicker.SelectedColor;
			var brush = new SolidColorBrush(color);
			if (optBack.IsChecked == true)
			{
				inkCanvas.Background = brush;
				//oldBrush = brush;
				
				
			}
			else if (optBrush.IsChecked == true)
			{


				drawAtt.Color = color;
				optBrush.BorderBrush = brush;
				//drawBrush = brush;

			}
			
		}

	

	
	}




}
