using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Media;
using Albert.Standard;
using Albert.Standard.Win32;
using static Albert.Standard.Win32.MediaCv;
namespace abFlowDocs
{
    /// <summary>
    /// Model deisgned for Artboard Brushes 
    /// </summary>
    public class BrushModel : PropBase
    {
        //Field's 
        Color color;
        double size;

        /// <summary>
        /// Constructor for Hex Color
        /// </summary>
        /// <param name="_hex">Hex Color</param>
        public BrushModel(string _hex)
        {
            try
            {
                BrushColor = HexColor(_hex);
                BrushSize = 0;
            }
            catch
            {
                BrushColor = HexColor("#fff000000");
                BrushSize = 0;
            }
        }

        /// <summary>
        /// Constructor for Color 
        /// </summary>
        /// <param name="_color">Color</param>
        public BrushModel(Color _color)
        {
            BrushColor = _color;
            BrushSize = 0;
        }

        /// <summary>
        /// Constructor for Brush SIze 
        /// </summary>
        /// <param name="_size">Size</param>
        public BrushModel(double _size)
        {
            BrushColor = Colors.Transparent;
            BrushSize = _size;
        }

        /// <summary>
        /// Constructor for HexCoolor and Size 
        /// </summary>
        /// <param name="hex">Hex Color</param>
        /// <param name="_size">SIze</param>
        public BrushModel(string _hex, double _size)
        {
            try
            {
                BrushColor = HexColor(_hex);
                BrushSize = _size;
            }
            catch 
            {
                BrushColor = HexColor("#ff000000");
                BrushSize = _size;
            }
                
        }

        /// <summary>
        /// Constructor for Color and SIze 
        /// </summary>
        /// <param name="_color">Color</param>
        /// <param name="_size">Size</param>
        public BrushModel(Color _color, double _size)
        {
            BrushColor = _color;
            BrushSize = _size;
        }


        /// <summary>
        /// Get or set the Brush Color
        /// </summary>
        public Color BrushColor
        {
            get { return color; }
            set { color = value; OnPropertyChanged("BrushColor"); }
        }
        /// <summary>
        /// Get or set the Brush Size 
        /// </summary>
        public double BrushSize
        {
            get { return size; }
            set { size = value; OnPropertyChanged("BrushSize"); }
        }






    }
}
