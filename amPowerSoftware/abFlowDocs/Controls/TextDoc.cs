using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using static Albert.Standard.Win32.MediaCv;
using System.Windows.Controls;
namespace abFlowDocs.Controls
{
    public class TextDoc: FlowDoc
    {
        public static DependencyProperty TextPropety = DP("Text", typeof(string), typeof(TextDoc));


        /// <summary>
        /// Get or set the Main Text 
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextPropety); }
            set { SetValue(TextPropety, value); }
        }
    }
}
