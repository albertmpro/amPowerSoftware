using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using static Albert.Standard.Win32.MediaCv;
namespace amFlowDoczBase.Controls
{
    /// <summary>
    /// Theme Screen is used to define a fixed document with 5 basic colors
    /// </summary>
    public class ThemeScreen: FlowScreen
    {

       

        public static DependencyProperty ColorOneProperty = DependencyProperty.Register("ColorOne", typeof(Color), typeof(ThemeScreen), new PropertyMetadata(HexColor("#ffffff")));

        public static DependencyProperty ColorTwoProperty = DependencyProperty.Register("ColorTwo", typeof(Color), typeof(ThemeScreen), new PropertyMetadata(HexColor("#000000")));

        public static DependencyProperty ColorThreeProperty = DependencyProperty.Register("ColorThree", typeof(Color), typeof(ThemeScreen), new PropertyMetadata(HexColor("#FFCC0000")));

        public static DependencyProperty ColorFourProperty = DependencyProperty.Register("ColorFour", typeof(Color), typeof(ThemeScreen), new PropertyMetadata(HexColor("#FF8D0000")));

        public static DependencyProperty ColorFiveProperty = DependencyProperty.Register("ColorFive", typeof(Color), typeof(ThemeScreen), new PropertyMetadata(HexColor("#FFE94343")));



      

        /// <summary>
        /// Get or set Color One
        /// </summary>
        public Color ColorOne
        {
            get { return (Color)GetValue(ColorOneProperty); }
            set { SetValue(ColorOneProperty, value); }
        }

        /// <summary>
        /// Get or set Color Two 
        /// </summary>
        public Color ColorTwo
        {
            get { return (Color)GetValue(ColorTwoProperty); }
            set { SetValue(ColorTwoProperty, value); }
        }

        /// <summary>
        /// Get or set Color Three
        /// </summary>
        public Color ColorThree
        {
            get { return (Color)GetValue(ColorThreeProperty); }
            set { SetValue(ColorThreeProperty, value); }
        }

        /// <summary>
        /// Get or set Color Four 
        /// </summary>
        public Color ColorFour
        {
            get { return (Color)GetValue(ColorFourProperty); }
            set { SetValue(ColorFourProperty, value); }
        }

        /// <summary>
        /// Get or set Color Five 
        /// </summary>
        public Color ColorFive
        {
            get { return (Color)GetValue(ColorFiveProperty); }
            set { SetValue(ColorFiveProperty, value); }
        }


    }
}
