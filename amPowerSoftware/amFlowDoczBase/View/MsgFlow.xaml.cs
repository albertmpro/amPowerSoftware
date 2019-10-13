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
using amFlowDoczBase.Controls;
using Albert.Standard.Win32;
using Albert.Standard;
using static Albert.Standard.Win32.MediaCv;
using static Albert.Standard.Win32.Win32IO;

namespace amFlowDoczBase.View
{
	/// <summary>
	/// Interaction logic for MsgFlow.xaml
	/// </summary>
	public partial class MsgFlow : ThemeScreen
	{
        #region Field's 
        DialogState state;
        //New Values for new ink document 
        double newwidth;
        double newheight;
        Color newfore;
        Color newback;
        #endregion

        public MsgFlow(TabControl _tab)
		{
			InitializeComponent();

			
			//Create and set the Tab Item 
			TabItem = new DocumentTabItem($"NewMsg{Count++}", this, _tab);
			TabItem.Focus();

            //Closed Lamba 
            TabItem.Closed += (sender, e) =>
            {
                DialogState = DialogState.Close;
                //Dialog for Closing 
                dialog.Show("Closing Tab", "Do you want to this MsgFlow Doecument?", "Close", "Cancel", () =>
                    {
                        TabItem.RemoveTab();
                    });

            };

            //Init Commands 
            commands();

            //EditingCommands.ToggleNumbering



			
	
			
	
		}


		void commands()
		{
            //Start New Commands
            AddCommand(DesktopCommands.StartView, (sender, e) =>
            {
                VM.VMTab.SelectedIndex = 0;
            });

            //New Command 
            AddCommand(ApplicationCommands.New, (sender, e) =>
            {
                //Get the Defualt Values
                //Set the Default Values 
                newwidth = defnew().width;
                newheight = defnew().height;
                newback = defnew().back;
                newfore = defnew().fore;

                //Show in dialog 
                runWidth.Text = $"{newwidth}px";
                runHeight.Text = $"{newheight}px";
                rectSelefct.Fill = new SolidColorBrush(newback);
                rectSelefct.Stroke = new SolidColorBrush(newfore);

                //Change the Dialog Stat e
                DialogState = DialogState.New;
                //Show the Dialog 
                dialog.Show("New Ink Canvas", "Do you want to create a new Ink Canvas?", "Create", "Cancel", () =>
                {
                    var foreBrush = new SolidColorBrush(newfore);
                    var backBrush = new SolidColorBrush(newback);

                    //Setup the Rich Text Block 
                    rtb.Width = newwidth;
                    rtb.Height = newheight;
                    rtb.Foreground = foreBrush;
                    rtb.BorderBrush = foreBrush;
                    rtb.Background = backBrush;
                    //Setup Color Options 
                    optText.Background = foreBrush;
                    optBack.Background = backBrush;
                    optBorder.Background = foreBrush;

                    


                });
                ;
            });

            //Open Command 
            AddCommand(ApplicationCommands.Open, (sender, e) =>
            {
                //Load a document
                VM.LoadRTB(rtb,TabItem,FileInfo);
            });
            //Save Command 
            AddCommand(ApplicationCommands.Save, (sender, e) =>
            {
                //Save your Data
                VM.SaveRTB(rtb,TabItem,FileInfo);
            });

            //Save As Command 
            AddCommand(DesktopCommands.SaveAs, (sender, e) =>
            {
                //Save your Data
                VM.SaveRTB(rtb,TabItem,FileInfo);
            });

            //Export Command 
            AddCommand(DesktopCommands.Export, (sender, e) =>
            {
                //Chnage Dialog State to Export
                DialogState = DialogState.Export;

                dialog.Show("Export", "Export your Message", "Export", "Cancel", () =>
                   {
                       if(chkBack.IsChecked == true)
                       {
                           rtb.Background = Brushes.Transparent;
                       }
                       else if(chkBorder.IsChecked == true)
                       {
                           rtb.BorderBrush = Brushes.Transparent;
                       }
                       else if (chkBack.IsChecked == true && chkBorder.IsChecked == true)
                       {
                           rtb.Background = Brushes.Transparent;
                           rtb.BorderBrush = Brushes.Transparent;
                       }
                       //Export the the Image 
                       VM.ExportImage(rtb,TabItem,FileInfo);

                   });


            });

        }

        #region Method's

        //Default Value Tuple 
        private (double width, double height, Color fore, Color back) defnew()
        {
            return (1920, 1080, HexColor("#ffffff"), HexColor("#000000"));
        }


        void lst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lst = sender as ListBox;

            if (lst.SelectedItem != null)
            {
                switch (lst.Tag)
                {
                    case "Sizes":
                        // Create  the Draw Paper
                        var paper = (DrawPaper)lst.SelectedItem;

                        //Set the New Width and Height 
                        newwidth = paper.Width;
                        newheight = paper.Height;
                        runWidth.Text = $"{newwidth}px";
                        runHeight.Text = $"{newheight}px";


                        break;
                    case "Theme":
                        var theme = (DrawTheme)lst.SelectedItem;

                        //Set a new Theme
                        newfore = theme.ForegroundColor;
                        newback = theme.BackgroundColor;
                        rectSelefct.Fill = new SolidColorBrush(newback);
                        rectSelefct.Stroke = new SolidColorBrush(newfore);
                        break;
                }
            }
        }

        void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            var color = (Color)colorPicker.SelectedColor;
            if (optText.IsChecked == true)
            {
                optText.Background = new SolidColorBrush(color);
                optText.BackgroundChecked = new SolidColorBrush(color);
                rtb.Foreground = new SolidColorBrush(color);

            }
            else if (optBack.IsChecked == true)
            {
                optBack.Background = new SolidColorBrush(color);
                optBack.BackgroundChecked = new SolidColorBrush(color);
                rtb.Background = new SolidColorBrush(color);
         
            }
            else if (optBorder.IsChecked == true)
            {
                optBorder.Background = new SolidColorBrush(color);
                optBorder.BackgroundChecked = new SolidColorBrush(color);
                rtb.BorderBrush = new SolidColorBrush(color);
            }
        }

        void colors_Click(object sender, RoutedEventArgs e)
        {
            var opt = sender as OptionButton;

            //Create the Brush 
            var brush = (SolidColorBrush)opt.Background;
            //Make the Color Picker the selected brush color 
            colorPicker.SelectedColor = brush.Color;

            

        }

        void Sl_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
            var slide = sender as Slider;
			try
			{
                var nv = (double)e.NewValue;
                switch (slide.Tag)
                {
                    case "Font":
                       //Change the Font Size
                        rtb.FontSize = nv;
                        break;
                    case "Border":
                       
                      
                        //Create a new thickness of the Border 
                        rtb.BorderThickness = new Thickness(nv);
                        break;
                    case "Corner":
                        
                        //Change the CornerRadius 
                        rtb.CornerRadius = new CornerRadius(nv);
                        break;
                }
			
			}
			catch
			{
				
			}
		}

	
        private void CmbMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        #endregion

        public DialogState DialogState
        {
            get { return state; }
            set
            {
                state = value;
                switch (value)
                {

                    case DialogState.New: //New Content
                        gridNew.Visibility = Visibility.Visible;
                        gridExport.Visibility = Visibility.Collapsed;
                        break;
                    case DialogState.Export: //Export Content
                        gridNew.Visibility = Visibility.Collapsed;
                        gridExport.Visibility = Visibility.Visible;
                        break;
                    case DialogState.Close: //Close COntent 
                        gridNew.Visibility = Visibility.Collapsed;
                        gridExport.Visibility = Visibility.Collapsed;

                        break;
                    default:
                        gridNew.Visibility = Visibility.Collapsed;
                        gridExport.Visibility = Visibility.Collapsed;
                        break;
                }
            }
        }

    }
}
