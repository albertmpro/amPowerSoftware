using System;
using System.Collections.Generic;
using System.Text;
using Albert.Standard;
using System.Windows.Media;
using static Albert.Standard.Win32.MediaCv;
namespace abFlowDocs
{
    /// <summary>
    /// Model design to setup an ArtBoard
    /// </summary>
    public class ArtBoardModel : PropBase
    {
        //Feild's 
        private double width, height;
        private Color back, brush;



        public ArtBoardModel()
        {
            Width = 1920;
            Height = 1080;
            BackgroundColor = HexColor("#ffB8b8b8");
            BrushColor = HexColor("#ff000000");
        }
        /// <summary>
        /// Constructor for making an square Artboard Size
        /// </summary>
        /// <param name="_widthheght"></param>
        public ArtBoardModel(double _widthheght)
        {
            Width = _widthheght;
            Height = _widthheght;
            BackgroundColor = HexColor("#ffB8b8b8");
            BrushColor = HexColor("#fff000000");
        }
        /// <summary>
        /// Constructor for making a custim Artbaord Size
        /// </summary>
        /// <param name="_width"></param>
        /// <param name="_heght"></param>
        public ArtBoardModel(double _width,double _heght)
        {
            Width = _width;
            Height = _heght;
            BackgroundColor = HexColor("#ffB8b8b8");
            BrushColor = HexColor("#fff000000");
        }
        /// <summary>
        /// Constructor for
        /// </summary>
        /// <param name="_brush"></param>
        /// <param name="_background"></param>
        public ArtBoardModel(string _brush,string _background)
        {
            Width = 1920;
            Height = 1080;
            BackgroundColor = HexColor(_background);
            BrushColor = HexColor(_brush);
        }


        public ArtBoardModel(double _width, double _heght,string _brush, string _background)
        {
            Width = _width;
            Height = _heght;
            BackgroundColor = HexColor(_background);
            BrushColor = HexColor(_brush);
        }

        public ArtBoardModel(double _width, double _heght, Color _brush, Color _background)
        {
            Width = _width;
            Height = _heght;
            BackgroundColor = _background;
            BrushColor = _brush;
        }


        public ArtBoardModel(Color _brush, Color _background)
        {
            Width = 1920;
            Height = 1080;
            BackgroundColor = _background;
            BrushColor = _brush;
        }


        public double Width
        {
            get { return width; }
            set { width = value; OnPropertyChanged("Width"); }
        }
        public double Height
        {
            get { return height; }
            set { height = value; OnPropertyChanged("Height"); }
        }

        public Color BackgroundColor
        {
            get { return back; }
            set { back = value; OnPropertyChanged("BackgorundColor"); }
        }

        public Color BrushColor
        {
            get { return brush; }
            set
            {
                brush = value; OnPropertyChanged("BrushColor");
            }

        }

    }
}
