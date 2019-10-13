using Albert.Standard.Win32;
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

namespace amFlowDoczBase.Controls
{
    /// <summary>
    /// Interaction logic for TextDialog.xaml
    /// </summary>
    public partial class TextDialog : FlowScreen
    {
        //Field 
        Action onButtonOnePress;
        public TextDialog()
        {
            InitializeComponent();
            //Hide on Creation 
            Hide();
        }

         

        public void Show(string _Title, string _message, string _btnOneContent, string _btnTwoContent, Action _method)
        {
            //Show the Dialog 
            Show();
            //Setup your Propeties 
            runTitle.Text = _Title;
            runMessage.Text = _message;
            btnOne.Content = _btnOneContent;
            btnTwo.Content = _btnTwoContent;
            onButtonOnePress = _method;
        }

        void push_Clcik(object sender,RoutedEventArgs e)
        {
            var push = sender as PushButton;

            switch(push.Tag)
            {
                case "btn1":
                    if (onButtonOnePress != null)
                    {
                        onButtonOnePress.Invoke();
                    }
                    Hide();
                    break;
                case "btn2":

                    //Hide the Dialog 
                    Hide();
                    
                    break;
            }
        }
    }
}
