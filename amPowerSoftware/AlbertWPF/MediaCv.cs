using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static Albert.Standard.Win32.QuickAnimation;

    
namespace Albert.Standard.Win32
{
    /// <summary>
    /// A class design to easily convert WPF Stuff  
    /// </summary>
    public static class MediaCv
    {
        #region Dependency Propertiey Method's 

        /// <summary>
        /// Method to Quckly Define Depedency Properites 
        /// </summary>
        /// <param name="_name">Name of the Property</param>
        /// <param name="_type">Type of the Propety</param>
        /// <param name="_class">The Class it's a part of </param>
        /// <returns>DependencyProperty</returns>
        public static DependencyProperty DP(string _name, Type _type, Type _class)
        {
            return DependencyProperty.Register(_name,_type,_class,null);
        }

        public static DependencyProperty DP(string _name, Type _type, Type _class,object _defaultvalue)
        {
            return DependencyProperty.Register(_name, _type, _class, new PropertyMetadata(_defaultvalue));
        }

        public static DependencyProperty DP(string _name, Type _type, Type _class,DependencyPropertyChangedEventHandler _event)
        {
            return DependencyProperty.Register(_name, _type, _class, new PropertyMetadata(_event));
        }

        #endregion

        #region Some Quick Animations 
        public static void NotifyHide(UIElement _elm, double _secondsRun )
        {
            RunDouble(_elm, "Opacity", 1, 0, TimeSpan.FromSeconds(_secondsRun));
        }
        #endregion


        #region Color Converters 
        /// <summary>
        /// Convert Color From Hexdeicmal Value
        /// </summary>
        /// <param name="hex">Hexdecimal string value </param>
        /// <returns></returns>
        public static Color HexColor(string hex)
        {
            try
            {
                //remove the # at the front
                hex = hex.Replace("#", "");

                byte a = 255;
                byte r = 255;
                byte g = 255;
                byte b = 255;

                int start = 0;

                //handle ARGB strings (8 characters long)
                if (hex.Length == 8)
                {
                    a = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                    start = 2;
                }
                else if (hex.Length < 6)
                {

                    MessageBox.Show("Your color is not valid, you get BLACK!", "Error", MessageBoxButton.OK);

                    return Colors.Black;

                }
                else if (hex.Length > 6)
                {


                }

                //convert RGB characters to bytes
                r = byte.Parse(hex.Substring(start, 2), System.Globalization.NumberStyles.HexNumber);
                g = byte.Parse(hex.Substring(start + 2, 2), System.Globalization.NumberStyles.HexNumber);
                b = byte.Parse(hex.Substring(start + 4, 2), System.Globalization.NumberStyles.HexNumber);

                return Color.FromArgb(a, r, g, b);
            }
            catch
            {
                MessageBox.Show("Your color is not valid, you get BLACK!", "Error", MessageBoxButton.OK);

                return Colors.Black;

            }
        }
        /// <summary>
        /// Creates a ARGB Color 
        /// </summary>
        /// <param name="_alpha"></param>
        /// <param name="_red"></param>
        /// <param name="_green"></param>
        /// <param name="_blue"></param>
        /// <returns></returns>
        public static Color ARGBColor(byte _alpha, byte _red, byte _green, byte _blue)
        {
            return Color.FromArgb(_alpha, _red, _green, _blue);
        }
        /// <summary>
        /// Creates a RGB Color 
        /// </summary>
        /// <param name="_red"></param>
        /// <param name="_green"></param>
        /// <param name="_blue"></param>
        /// <returns></returns>
        public static Color RGBColor(byte _red, byte _green, byte _blue)
        {
            return Color.FromArgb(255, _red, _green, _blue);
        }


        #endregion

        #region Solid Color Brush Converters 


        /// <summary>
        /// Converts Hex string to SOlidColorBrush 
        /// </summary>
        /// <param name="hex"></param>
        /// <returns>Solid Color Brush</returns>
        public static SolidColorBrush HexBrush(string hex)
        {
            try
            {
                //remove the # at the from the hex value
                hex = hex.Replace("#", "");

                byte a = 255;
                byte r = 255;
                byte g = 255;
                byte b = 255;

                int start = 0;


                if (hex.Length == 8)// if hex is an ARGB value 
                {
                    a = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                    start = 2;
                }
                else if (hex.Length < 6)
                {

                    MessageBox.Show("Your color is not valid, you get BLACK!", "Error", MessageBoxButton.OK);

                    return new SolidColorBrush(Colors.Black);

                }
                else if (hex.Length > 6)
                {


                }

                //convert RGB characters to bytes
                r = byte.Parse(hex.Substring(start, 2), System.Globalization.NumberStyles.HexNumber);
                g = byte.Parse(hex.Substring(start + 2, 2), System.Globalization.NumberStyles.HexNumber);
                b = byte.Parse(hex.Substring(start + 4, 2), System.Globalization.NumberStyles.HexNumber);

                return new SolidColorBrush(Color.FromArgb(a, r, g, b));
            }
            catch
            {
                MessageBox.Show("Your color is not valid, you get BLACK!", "Error", MessageBoxButton.OK);

                return new SolidColorBrush(Colors.Black);

            }
        }
        /// <summary>
        /// Converts ARBG values into a SolidColorBrush
        /// </summary>
        /// <param name="_alpha"></param>
        /// <param name="_red"></param>
        /// <param name="_green"></param>
        /// <param name="_blue"></param>
        /// <returns>SolidColorBrush</returns>
        public static SolidColorBrush ARGBBrush(byte _alpha, byte _red, byte _green, byte _blue)
        {
            return new SolidColorBrush(Color.FromArgb(_alpha, _red, _green, _blue));
        }

        public static SolidColorBrush RGBBrush(byte _red, byte _green, byte _blue)
        {
            return new SolidColorBrush(Color.FromArgb(255, _red, _green, _blue));
        }


        #endregion

        #region Linear Gradient Brush Converters 
        public static LinearGradientBrush LinearBrush(Color _c1, Color _c2)
        {
            var brush = new LinearGradientBrush();
            var s1 = new GradientStop(_c1, 0);
            var s2 = new GradientStop(_c2, 1);

            brush.GradientStops.Add(s1);
            brush.GradientStops.Add(s2);

            return brush;

        }
        public static LinearGradientBrush LinearBrush(Color _c1, double _stop1, Color _c2, double _stop2)
        {
            var brush = new LinearGradientBrush();
            var s1 = new GradientStop(_c1, _stop1);
            var s2 = new GradientStop(_c2, _stop2);

            brush.GradientStops.Add(s1);
            brush.GradientStops.Add(s2);

            return brush;

        }
        public static LinearGradientBrush LinearBrush(string _hexcolor1, string _hexcolor2)
        {
            //Main Brush 
            var brush = new LinearGradientBrush();
            //Convert the Colors 
            var c1 = HexColor(_hexcolor1);
            var c2 = HexColor(_hexcolor2);

            //Create your Gradient Stop's 
            var s1 = new GradientStop(c1, 0);
            var s2 = new GradientStop(c2, 1);

            //Add your Gradient Stops 
            brush.GradientStops.Add(s1);
            brush.GradientStops.Add(s2);


            //Return the Brush 
            return brush;

        }

        public static LinearGradientBrush LinearBrush(string _hexcolor1, double _offset1, string _hexcolor2, double _offset2)
        {
            //Main Brush 
            var brush = new LinearGradientBrush();
            //Convert the Colors 
            var c1 = HexColor(_hexcolor1);
            var c2 = HexColor(_hexcolor2);

            //Create your Gradient Stop's 
            var s1 = new GradientStop(c1, _offset1);
            var s2 = new GradientStop(c2, _offset2);

            //Add your Gradient Stops 
            brush.GradientStops.Add(s1);
            brush.GradientStops.Add(s2);


            //Return the Brush 
            return brush;

        }

        #endregion

        #region Radial Gradient Brush Converters
        public static RadialGradientBrush RadialBrush(Color _c1, Color _c2)
        {
            var brush = new RadialGradientBrush();
            var s1 = new GradientStop(_c1, 0);
            var s2 = new GradientStop(_c2, 1);

            brush.GradientStops.Add(s1);
            brush.GradientStops.Add(s2);

            return brush;

        }
        public static RadialGradientBrush RadialBrush(Color _c1, double _stop1, Color _c2, double _stop2)
        {
            var brush = new RadialGradientBrush();
            var s1 = new GradientStop(_c1, _stop1);
            var s2 = new GradientStop(_c2, _stop2);

            brush.GradientStops.Add(s1);
            brush.GradientStops.Add(s2);

            return brush;

        }
        public static RadialGradientBrush RadialBrush(string _hexcolor1, string _hexcolor2)
        {
            //Main Brush 
            var brush = new RadialGradientBrush();
            //Convert the Colors 
            var c1 = HexColor(_hexcolor1);
            var c2 = HexColor(_hexcolor2);

            //Create your Gradient Stop's 
            var s1 = new GradientStop(c1, 0);
            var s2 = new GradientStop(c2, 1);

            //Add your Gradient Stops 
            brush.GradientStops.Add(s1);
            brush.GradientStops.Add(s2);


            //Return the Brush 
            return brush;

        }

        public static RadialGradientBrush RadialBrush(string _hexcolor1, double _offset1, string _hexcolor2, double _offset2)
        {
            //Main Brush 
            var brush = new RadialGradientBrush();
            //Convert the Colors 
            var c1 = HexColor(_hexcolor1);
            var c2 = HexColor(_hexcolor2);

            //Create your Gradient Stop's 
            var s1 = new GradientStop(c1, _offset1);
            var s2 = new GradientStop(c2, _offset2);

            //Add your Gradient Stops 
            brush.GradientStops.Add(s1);
            brush.GradientStops.Add(s2);


            //Return the Brush 
            return brush;

        }

        #endregion

        #region Image Converter 


        public static void ImageFile(Image _img,string _url)
        {
            //Create the Image
            var img = _img;

            img.Source = new BitmapImage(new Uri(_url));



        }
        public static void ImageFile(Image _img ,string _url, Stretch _stretch)
        {
            //Create the Image
            var img = _img;

            //Create the Image
            img.Source = new BitmapImage(new Uri(_url));


            //Setup the Stretch Property 
            img.Stretch = _stretch;

            
        }

        public static ImageBrush ImgBrush(string _url)
        {
            //Create the Image Bruhs 
            var imgbrush = new ImageBrush();
            //Create the Bitmap 
            var bitmap = new BitmapImage();
            bitmap.UriSource = new Uri(_url);
            //Set the Bitmap as the sourcde 
            imgbrush.ImageSource = bitmap;
            //Return the image brush 
            return imgbrush;

        }

        public static ImageBrush ImgBrush(string _url,Stretch _stretch )
        {
            //Create the Image Bruhs 
            var imgbrush = new ImageBrush();
            //Create the Bitmap 
            var bitmap = new BitmapImage();
            bitmap.UriSource = new Uri(_url);
            //Set the Bitmap as the sourcde 
            imgbrush.ImageSource = bitmap;

            //Set the Stretch 
            imgbrush.Stretch = _stretch;
            
            //Return the image brush 
            return imgbrush;

        }






        #endregion

    }
}
