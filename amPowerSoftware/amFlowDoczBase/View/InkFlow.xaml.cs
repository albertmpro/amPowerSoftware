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
using static Albert.Standard.Win32.Win32IO;
using static Albert.Standard.Win32.MediaCv;
using amFlowDoczBase.Controls;
using System.IO;
using System.Windows.Ink;
using Albert.Standard;

namespace amFlowDoczBase.View
{
    public enum InkFlowwState
    {
        Ink, Ref,Theme
    }

    /// <summary>
    /// Interaction logic for InkFlow.xaml
    /// </summary>
    public partial class InkFlow : ThemeScreen
    {
        #region Field's 
        //Dialog State 
        DialogState state;
        //InkFlowState 
        InkFlowwState inkstate;

        //MainContent 
        InkCanvas ink;
        DrawingAttributes drawAtt;
        GridSplitter split;
        Image imgRef;
        ZoomBox zoomRef, zoomInk;
        Border bdInk, bdRef;
        PushButton btnLoadRef;
        Grid gridRef;
        RowDefinition r1, r2;
        ColumnDefinition c1, c2, c3;

        //New Values for new ink document 
        double newwidth;
        double newheight;
        Color newfore;
        Color newback;

        #endregion

        #region Constructor's 


        void InitMainContent()
        {
            //Create the Border for the inkCanvas 
            bdInk = new Border { Margin = new Thickness(7), BorderBrush = HexBrush("#ffffff"), BorderThickness = new Thickness(1.2) };
            //Create InkCanvas
            ink = new InkCanvas();

            //Creage Draw Attributes 
            drawAtt = new DrawingAttributes { Color = HexColor("#ffffff"), Width = 10, Height = 10 };

            //Set InkCanvas Default Draw Attributes 
            ink.DefaultDrawingAttributes = drawAtt;

            //Link Border to the inkCanvas 
            bdInk.Child = ink;

            //Create the Zoombox for the ink 
            zoomInk = new ZoomBox();
            zoomInk.Content = bdInk;



            //Create the GridSpliter 
            split = new GridSplitter();

            //Border for the Image Ref 
            bdRef = new Border { Margin = new Thickness(7), BorderBrush = HexBrush("#ffffff"), BorderThickness = new Thickness(1.2) };

            //Create the Zoombox for the image ref 
            zoomRef = new ZoomBox();

            //Grid for the Ref 
            gridRef = new Grid();

            //RowDef 
            r1 = new RowDefinition { Height = GridLength.Auto };
            r2 = new RowDefinition();



            //Button to Load Image Ref 
            btnLoadRef = new PushButton { Content = "Load Image", Width = 120 };

            //Button Click Event 
            btnLoadRef.Click += (sender, e) =>
            {
                Win32IO.OpenDialogTask("Load Image", "Image Formats(.png,jpg,jpeg)|*.png;*.jpg;*.jpeg", (o) =>
                  {
                      //Set the Image FIle 
                      ImageFile(imgRef, o.FileName);
                  });
            };

            //Create Image Refrence 
            imgRef = new Image();

            //Set bdRef Child 
            bdRef.Child = imgRef;

            //Set Rows 
            Grid.SetRow(btnLoadRef, 0);
            Grid.SetRow(bdRef, 1);
            //Add Children to the Grid
            gridRef.RowDefinitions.Add(r1);
            gridRef.RowDefinitions.Add(r2);
            gridRef.Children.Add(btnLoadRef);
            gridRef.Children.Add(bdRef);


            //Add Grid to Zoombox 
            zoomRef.Content = gridRef;

            //Row Defnitons 
            c1 = new ColumnDefinition();
            c2 = new ColumnDefinition { MaxWidth = 20 };
            c3 = new ColumnDefinition();

            // Default InkFLow State
            InkFlowState = InkFlowwState.Ink;

        }

        public InkFlow(TabControl _tab)
        {
            InitializeComponent();
            //Create the Main Content 
            InitMainContent();


            //Init Commands 
            commands();
            //Create the tab
            TabItem = new DocumentTabItem($"InkDocument{Count++}", this, _tab);

            //Close Lamba 
            TabItem.Closed += (sender, e) =>
            {
                //Hide Export Grid 
                //gridExport.Visibility = Visibility.Collapsed;

                //Show Dialog 
                DialogState = DialogState.Close;
                dialog.Show("Close Tab", "Do you wnat close this Ink Canvas?", "Close", "Cancel", () =>
                    {
                
                        //Close Tab 
                        TabItem.RemoveTab();
                    });

            };

            //Focus on the Tab 
            TabItem.Focus();
            ink.Focus();
        }

        public InkFlow(string _fn, TabControl _tab)
        {
            InitializeComponent();

            //Create the Main Content 
            InitMainContent();

            //Init Commands 
            commands();

            //Create the tab
            FileInfo = new FileInfo(_fn);
            TabItem = new DocumentTabItem(FileInfo.Name, this, _tab);

            //Load Strokes 
            Win32IO.LoadInkStrokes(ink, _fn);

            //Close Lamba 
            TabItem.Closed += (sender, e) =>
            {
                //Hide Export Grid 

                gridExport.Visibility = Visibility.Collapsed;
                //Show Dialog Lamba 
                DialogState = DialogState.Close;
                dialog.Show("Close Tab", "Do you wnat close this Ink Canvas?", "Close", "Cancel", () =>
                {
                    //Close Tab 
                    TabItem.RemoveTab();
                });

            };

            //Focus on the Tab 
            TabItem.Focus();
            ink.Focus();
        }


        #endregion

        #region Method's and Tuple's 



        //Default Value Tuple 
        private (double width, double height, Color fore, Color back) defnew()
        {
            return (1920, 1080, HexColor("#ffffff"), HexColor("#000000"));
        }

        /// <summary>
        /// Method to simplfy changing the brush isze
        /// </summary>
        /// <param name="_size"></param>
        void sizeMethod(double _size)
        {
            drawAtt.Width = _size;
            drawAtt.Height = _size;
            borderSize.Width = _size;
            borderSize.Height = _size;
        }

        /// <summary>
        /// Hold's all the commands 
        /// </summary>
        void commands()
        {
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
                         //Create a new set of strokes 
                         ink.Strokes = new StrokeCollection();
                         //Set the Default Values 
                         ink.Width = newwidth;
                         ink.Height = newheight;
                         ink.Background = new SolidColorBrush(newback);
                         drawAtt.Color = newfore;
                         //Brush OptionButton
                         optBrush.Background = new SolidColorBrush(newfore);
                         //Background OptionButton
                         optBackground.Background = new SolidColorBrush(newback);

                         ;


                     });
                 ;
             });

            //Open Command 
            AddCommand(ApplicationCommands.Open, (sender, e) =>
            {
                //Load Ink 
                VM.LoadInk(ink,TabItem,FileInfo);
            });


            //Save Command 
            AddCommand(ApplicationCommands.Save, (sender, e) =>
            {
                //Save your inkCanvas
                VM.SaveInk(ink,TabItem,FileInfo);
            });

            //SaveAs Command 
            AddCommand(DesktopCommands.SaveAs, (sender, e) =>
            {
                //Save your inkCanvas
                VM.SaveInk(ink,TabItem,FileInfo);
            });


            //Export Command 
            AddCommand(DesktopCommands.Export, (sender, e) =>
            {
                DialogState = DialogState.Export;
                dialog.Show("Export Image", "Export Options", "Export", "Cancel", () =>
                {
                    //Boolean for Transparent Background 
                    var bct = chkBack.IsChecked;
                    if (bct == true)
                    {
                        //Make Background Transparent 
                        ink.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                    }
                    //Export the Ink Canvas 
                    try
                    {
                        VM.ExportImage(ink,TabItem,FileInfo);
                    }
                    catch
                    {
                        MessageBox.Show("You cannot save it to your Ref Img!");
                    }
                    //Close Export Options 

                });
            });

        }

        void selection_Click(object sender, RoutedEventArgs e)
        {
            var opt = sender as OptionButton;
            switch (opt.Tag)
            {
                case "Draw":
                    ink.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "Erase":
                    ink.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    break;
                case "EraseStroke":
                    ink.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
                case "Select":
                    ink.EditingMode = InkCanvasEditingMode.Select;
                    break;
            }
        }

        void SlSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                var ds = e.NewValue;
                //Set the Size 
                sizeMethod(ds);


            }
            catch
            {
                slSize.Value = 10;
            }

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

        void CmbMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbMode.SelectedItem != null)
            {
                switch(cmbMode.SelectedIndex)
                {
                    case 0:
                        InkFlowState = InkFlowwState.Ink;
                        break;
                    case 1:
                        InkFlowState = InkFlowwState.Ref;
                        break;
                    case 2:
                        InkFlowState = InkFlowwState.Theme;
                        break;
                }
            }
  
        }

        private void ThemePicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            //Define the Color 
            var color = (Color)themePicker.SelectedColor;
            //Create the brush 
            var brush = new SolidColorBrush(color);
            //Make the Color the Bursh 
            drawAtt.Color = color;
            if (optColor1.IsChecked == true)
            {
                optColor1.Background = brush;
                optColor1.BackgroundChecked = brush;
            }
            else if (optColor2.IsChecked == true)
            {
                optColor2.Background = brush;
                optColor2.BackgroundChecked = brush;
            }
            else if (optColor3.IsChecked == true)
            {
                optColor3.Background = brush;
                optColor3.BackgroundChecked = brush;
            }
            else if (optColor4.IsChecked == true)
            {
                optColor4.Background = brush;
                optColor4.BackgroundChecked = brush;
            }
            else if (optColor5.IsChecked == true)
            {
                optColor5.Background = brush;
                optColor5.BackgroundChecked = brush;
            }
        }

        void theme_Click(object sender, RoutedEventArgs e)
        {
            var opt = sender as OptionButton;

            //Grab brush 
            var brush = (SolidColorBrush)opt.Background;
            //Set Brush 
            drawAtt.Color = brush.Color;
            //Set the THem Picker 
            themePicker.SelectedColor = brush.Color;
       }

        private void CmbSizes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSizes.SelectedItem != null)
            {
                var paper = (DrawPaper)cmbSizes.SelectedItem;

                //Resize the Ink Canvas
                ink.Width = paper.Width;
                ink.Height = paper.Height;
            }

        }
        void color_Checked(object sender, RoutedEventArgs e)
        {
            var opt = sender as OptionButton;
            //Create a SolidBrush
            var brush = (SolidColorBrush)opt.BorderBrush;
            //Create a Color 
            var color = brush.Color;
            //Set the ColorPicker 
            colorPicker.SelectedColor = color;

        }
        /// <summary>
        ///Preset Bursh Button Logic 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void brush_Click(object sender, RoutedEventArgs e)
        {
            var push = sender as PushButton;

            switch (push.Tag)
            {
                case "b3":
                    sizeMethod(3);
                    break;
                case "b7":
                    sizeMethod(7);
                    break;
                case "b10":
                    sizeMethod(10);
                    break;
                case "b15":
                    sizeMethod(15);
                    break;
                case "b20":
                    sizeMethod(20);
                    break;
                case "b35":
                    sizeMethod(35);
                    break;
                case "b50":
                    sizeMethod(50);
                    break;
                case "b55":
                    sizeMethod(55);
                    break;
                case "b60":
                    sizeMethod(60);
                    break;
                case "b65":
                    sizeMethod(65);
                    break;

            }
        }



        void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            var color = (Color)colorPicker.SelectedColor;
            if (optBrush.IsChecked == true)
            {
                optBrush.Background = new SolidColorBrush(color);
                optBrush.BackgroundChecked = new SolidColorBrush(color);
                drawAtt.Color = color;
            }
            else if (optBackground.IsChecked == true)
            {
                optBackground.Background = new SolidColorBrush(color);
                optBackground.BackgroundChecked = new SolidColorBrush(color);
                ink.Background = new SolidColorBrush(color);
            }
        }
        #endregion

        public InkFlowwState InkFlowState
        {
            get { return inkstate; }
            set
            {
                inkstate = value;

                switch (value)
                {
                    case InkFlowwState.Ink:
                        //Clear the Main Grid
                        gridMain.Children.Clear();
                        //Clear Column Definitions 
                        gridMain.ColumnDefinitions.Clear();
                        gridMain.Children.Add(zoomInk);
                        break;

                    case InkFlowwState.Ref:
                        //Clear the Main Grid 
                        gridMain.Children.Clear();
                        //Clear Colum Definitions 
                        gridMain.ColumnDefinitions.Clear();
                        //Redefine Column Defnition 
                        gridMain.ColumnDefinitions.Add(c1);
                        gridMain.ColumnDefinitions.Add(c2);
                        gridMain.ColumnDefinitions.Add(c3);
                        //Set the Columns 
                        Grid.SetColumn(zoomInk, 0);
                        Grid.SetColumn(split, 1);
                        Grid.SetColumn(zoomRef, 2);
                        //Create a Grid Splint Betwwen INk and Ref
                        gridMain.Children.Add(zoomInk);
                        gridMain.Children.Add(split);
                        gridMain.Children.Add(zoomRef);
                        break;
                    case InkFlowwState.Theme:
                        //Clear the Main Grid 
                        gridMain.Children.Clear();
                        //Clear Colum Definitions 
                        gridMain.ColumnDefinitions.Clear();
                        //Redefine Column Defnition 
                        gridMain.ColumnDefinitions.Add(c1);
                        gridMain.ColumnDefinitions.Add(c2);
                        gridMain.ColumnDefinitions.Add(c3);
                        //Set the Columns 
                        Grid.SetColumn(zoomInk, 0);
                        Grid.SetColumn(split, 1);
                        Grid.SetColumn(zoomTheme, 2);
                        //Create a Grid Splint Betwwen INk and Ref
                        gridMain.Children.Add(zoomInk);
                        gridMain.Children.Add(split);
                        gridMain.Children.Add(zoomTheme);

                        break;

                }
            }
        }

          
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
