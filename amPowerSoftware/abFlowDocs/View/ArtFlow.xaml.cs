using abFlowDocs.Controls;
using Albert.Standard.Win32;
using System;
using System.Collections.Generic;
using System.Text;
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

namespace abFlowDocs.View
{
    /// <summary>
    /// Interaction logic for ArtFlow.xaml
    /// </summary>
    public partial class ArtFlow : FlowDoc
    {
        ArtBrushType brushType;


        #region Constructor's and Logic

        public ArtFlow(TabControl _tab)
        {

            InitializeComponent();

            SetupTab($"Artboard{Count++}", _tab, Close);

            //Do your Logic 
            Logic();
        }
        /// <summary>
        /// Constuctor for Loading Ink File 
        /// </summary>
        /// <param name="_filename"></param>
        /// <param name="_tab"></param>
        public ArtFlow(string _filename, TabItem _tab)
        {

            InitializeComponent();


            //Do your Logic 
            Logic();
        }

        void Close()
        {
            ShowClose("Closing Artboard", "Do you want close this Artboard?", () =>
              {
                  TabItem.RemoveTab();
              });
        }

        public override void OnLogic()
        {
            BrushType = ArtBrushType.Marker;

            SetArtBrushSize(15);

            //Commands 

            //New Command 
            AddCommand(ApplicationCommands.New, (sender, e) =>
             {
                 dialogNew.Show("New Artboard", "Do you want to create a new Artboard?", "New Artboard", "Cancel", () =>
                     {
                         //Create a new ArtBoard  via Tuple Breakdown
                         (double width, double height, SolidColorBrush background, Color brush) = VM.NewArtBoard(VM.NewBoard);

                         //Clear the Artboard 
                         artBoard.Strokes = new StrokeCollection();

                         artBoard.Width = width;
                         artBoard.Height = height;
                         artBoard.Background = background;

                         //Set the OptionButtons 
                         optBackground.Background = background;
                         optBackground.BackgroundChecked = background;
                         optBrush.Background = new SolidColorBrush(brush);
                         optBrush.BackgroundChecked = new SolidColorBrush(brush);


                         //Set the Brush
                         SetArtBrushColor(brush);


                     });

             });
        }
        #endregion


        #region Method's 
        /// <summary>
        /// Set the ArtBrush SIze 
        /// </summary>
        /// <param name="_size"></param>
        void SetArtBrushSize(double _size)
        {
            //Set the Brush Size 
            artBoard.DefaultDrawingAttributes.Width = _size;
            artBoard.DefaultDrawingAttributes.Height = _size;
        }
        /// <summary>
        /// Set the ArtBrush Color 
        /// </summary>
        /// <param name="_color"></param>
        void SetArtBrushColor(Color _color)
        {
            //Set the old Color 
            VM.OldColor = _color;

            //Get the ArtBrush Color and BrushTYpe
            var thecolor = VM.CreateArtBrush(VM.AlphaColor, _color).ColorOutput;

            //Set the Artboard Color 
            artBoard.DefaultDrawingAttributes.Color = thecolor;

            //Set the ColorPicker Brush 
            colorPicker.SelectedColor = (Color?)thecolor;
            //Set the optBrush.Backgrond and BackgundChecked 
            optBrush.Background = new SolidColorBrush(thecolor);
            optBrush.BackgroundChecked = new SolidColorBrush(thecolor);

        }

        void BrushType_Click(object sender, RoutedEventArgs e)
        {
            var opt = sender as OptionButton;

            switch (opt.Tag)
            {
                case "Pencil":
                    BrushType = ArtBrushType.Pencil;
                    break;
                case "Pen":
                    BrushType = ArtBrushType.Pen;
                    break;
                case "Marker":
                    BrushType = ArtBrushType.Marker;
                    break;
            }
        }

        void Selection_Clcik(object sender, RoutedEventArgs e)
        {
            var push = sender as PushButton;

            switch (push.Tag)
            {
                case "Paint":
                    artBoard.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "Erase":
                    artBoard.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    break;
                case "EraseLine":
                    artBoard.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
                case "Select":
                    artBoard.EditingMode = InkCanvasEditingMode.Select;
                    break;

            }


        }

        /// <summary>
        /// Get or set your Brush Type 
        /// </summary>


        private void CMB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cmb = sender as ComboBox;

            if (cmb.SelectedItem != null)
            {
                var item = (BrushModel)cmb.SelectedItem;

                switch (cmb.Tag)
                {
                    case "Brush": //Set the Color 
                        SetArtBrushColor(item.BrushColor);
                        break;
                    case "Size": //Set the Size
                        SetArtBrushSize(item.BrushSize);
                        break;

                }

            }
        }

        private void lstNew_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lst = sender as ListBox;


            if (lst.SelectedItem != null)
            {
                //Create a item
                var item = (ArtBoardModel)lst.SelectedItem;

                switch (lst.Tag)
                {
                    case "size":// Set the Sizes 
                        VM.NewBoard.Width = item.Width;
                        VM.NewBoard.Height = item.Height;

                        //Display 
                        runWidth.Text = $"{item.Width}px";
                        runHeight.Text = $"{item.Height}px";

                        break;
                    case "theme":// Set the theme 
                        var background = new SolidColorBrush(item.BackgroundColor);
                        var brush = new SolidColorBrush(item.BrushColor);

                        //Display Rectangle 
                        rectSelected.Fill = background;
                        rectSelected.Stroke = brush;

                        VM.NewBoard.BackgroundColor = item.BackgroundColor;
                        VM.NewBoard.BrushColor = item.BrushColor;
                        break;
                }
            }
        }

        void PaintOpt_Click(object sender, RoutedEventArgs e)
        {
            var opt = sender as OptionButton;
            var brush = (SolidColorBrush)opt.Background;
            colorPicker.SelectedColor = (Color?)brush.Color;
        }

        /// <summary>
        /// Color Picker Logic 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void colorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            //Grab the Color ;
            var cpcolor = (Color)colorPicker.SelectedColor;

            //Convert color from CreateArtBrush Tuple 
            var color = VM.CreateArtBrush(VM.AlphaColor, cpcolor).ColorOutput;

            //Create a brush 
            var background = new SolidColorBrush(cpcolor);
            var brush = new SolidColorBrush(color);

            if (optBackground.IsChecked == true)
            {
                optBackground.Background = background;
                optBackground.BackgroundChecked = background;
                artBoard.Background = brush;
            }
            else if (optBrush.IsChecked == true)
            {
                optBrush.Background = brush;
                optBrush.BackgroundChecked = brush;
                SetArtBrushColor(color);

            }
            else if (optPaint1.IsChecked == true)
            {
                optPaint1.Background = brush;
                optPaint1.BackgroundChecked = brush;
                optBrush.Background = brush;
                optBrush.BackgroundChecked = brush;
            }
            else if (optPaint2.IsChecked == true)
            {
                optPaint2.Background = brush;
                optPaint2.BackgroundChecked = brush;
                optBrush.Background = brush;
                optBrush.BackgroundChecked = brush;
                SetArtBrushColor(color);
            }
            else if (optPaint4.IsChecked == true)
            {
                optPaint4.Background = brush;
                optPaint4.BackgroundChecked = brush;
                optBrush.Background = brush;
                optBrush.BackgroundChecked = brush;
                SetArtBrushColor(color);
            }
            else if (optPaint5.IsChecked == true)
            {
                optPaint5.Background = brush;
                optPaint5.BackgroundChecked = brush;
                optBrush.Background = brush;
                optBrush.BackgroundChecked = brush;
                SetArtBrushColor(color);

            }
            else if (optPaint6.IsChecked == true)
            {
                optPaint6.Background = brush;
                optPaint6.BackgroundChecked = brush;
                optBrush.Background = brush;
                optBrush.BackgroundChecked = brush;
                SetArtBrushColor(color);
            }
            else if (optPaint7.IsChecked == true)
            {
                optPaint7.Background = brush;
                optPaint7.BackgroundChecked = brush;
                optBrush.Background = brush;
                optBrush.BackgroundChecked = brush;
                SetArtBrushColor(color);
            }
            else if (optPaint8.IsChecked == true)
            {
                optPaint8.Background = brush;
                optPaint8.BackgroundChecked = brush;
                optBrush.Background = brush;
                optBrush.BackgroundChecked = brush;
                SetArtBrushColor(color);
            }


        }




        #endregion


        public ArtBrushType BrushType
        {
            get { return brushType; }
            set
            {
                brushType = value;

                switch (value)
                {
                    case ArtBrushType.Pencil: //Pencil Type Brush 
                        VM.AlphaColor = 45;
                        SetArtBrushColor(VM.OldColor);
                        break;
                    case ArtBrushType.Marker: //Marker type Brush 
                        VM.AlphaColor = 120;
                        SetArtBrushColor(VM.OldColor);
                        break;
                    case ArtBrushType.Pen: //Pen Type Brush
                        VM.AlphaColor = 200;
                        SetArtBrushColor(VM.OldColor);
                        break;
                }
            }
        }


    }
}
