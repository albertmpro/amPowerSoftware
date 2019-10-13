using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Albert.Standard.Win32.MediaCv;
namespace Albert.Standard.Win32
{
    #region DialogState 
    public enum DialogState
    {
        New,Open,Save,Import,Export,Close
    }
    #endregion 

    [TemplatePart(Name = "PART_tbMessage", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_btnOne", Type = typeof(PushButton))]
    [TemplatePart(Name = "PART_btnTwo", Type = typeof(PushButton))]
    public class DocumentDialog : ContentControl, IAddCommand
    {
        #region Field's 
        //Field's
        //Controls 
        TextBlock tbMessage = new TextBlock();
        PushButton btnOne = new PushButton();
        PushButton btnTwo = new PushButton();
   
        //Action 
        Action onBtnOne, onBtnTwo;

        //Depdencey Propertey 
        public static DependencyProperty TitleProperty = DP("Title", typeof(string), typeof(DocumentDialog));

        public static DependencyProperty MessageProperty = DP("Message", typeof(string), typeof(DocumentDialog));

        public static DependencyProperty ButtonTextOneProperty = DP("ButtonTextOne", typeof(string), typeof(DocumentDialog));


        public static DependencyProperty ButtonTextTwoProperty = DP("ButtonTextTwo", typeof(string), typeof(DocumentDialog));

      


        #endregion

        public DocumentDialog()
        {
            //ReDraw the Control 
            DefaultStyleKey = typeof(DocumentDialog);
            //Make Hidden by default 
            Visibility = Visibility.Collapsed;


        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            //Message TextBlock  
            tbMessage = GetTemplateChild("PART_tbMessage") as TextBlock;

            //Button One 
            btnOne = GetTemplateChild("PART_btnOne") as PushButton;
            //BUtton Two 
            btnTwo = GetTemplateChild("PART_btnTwo") as PushButton;

         
            //Button One Logic 
            btnOne.Click += btnOne_Click;
        
            // Button Two Logic 
            btnTwo.Click += btnTwo_Click;
            
            
        }

        #region Button Logic 

        void btnOne_Click(object sender, RoutedEventArgs e)
        {
            if (onBtnOne != null)
            {
                //Execute onBtnThree
                onBtnOne();
            }
            //Hide the Dialog when finished 
            Visibility = Visibility.Collapsed;
        }
        void btnTwo_Click(object sender, RoutedEventArgs e)
        {
            if (onBtnTwo != null)
            {
                //Execute onBtnThree
                onBtnTwo();
            }
            //Hide the Dialog when finished 
            Visibility = Visibility.Collapsed;
        }

      

        #endregion 


        /// <summary>
        /// IAddCommand Method to easialy add commands 
        /// </summary>
        /// <param name="_command"></param>
        /// <param name="_method"></param>
        public void AddCommand(ICommand _command, ExecutedRoutedEventHandler _method)
        {
            CommandBindings.Add(new CommandBinding(_command,_method));
        }

        #region Show Method's 
     
 

        public void Show(string _title, string _msg,string _btnOneText,string _btnTwoText, Action _method)
        {
            //Show the Control 
            Visibility = Visibility.Visible;
            Title = _title;
            Message = _msg;
            //Default Text is Ok 
            ButtonTextOne = _btnOneText;
            ButtonTextTwo = _btnTwoText;
            //Link to BtnONe Method 
            onBtnOne = _method;
          
        }

        public void Show(string _title, string _msg, string _btnOneText, string _btnTwoText, Action _method,Action _method2)
        {
            //Show the Control 
            Visibility = Visibility.Visible;
            Title = _title;
            Message = _msg;
            //Default Text is Ok 
            ButtonTextOne = _btnOneText;
            ButtonTextTwo = _btnTwoText;
            //Link to BtnONe Method 
            onBtnOne = _method;
            //Link to Button Two 
            onBtnTwo = _method2;
  
        }

   
        #endregion

        #region Public Properties 
        /// <summary>
        /// Gets or sets the Title 
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        /// <summary>
        /// Gets or sets the Messsage 
        /// </summary>
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }
        /// <summary>
        /// Gets or sets the Text For Button One 
        /// </summary>
        public string ButtonTextOne
        {
            get { return (string)GetValue(ButtonTextOneProperty); }
            set { SetValue(ButtonTextOneProperty, value); }
        }
        /// <summary>
        /// Gets or sets the text for Button Two 
        /// </summary>
        public string ButtonTextTwo
        {
            get { return (string)GetValue(ButtonTextTwoProperty); }
            set { SetValue(ButtonTextTwoProperty, value); }
        }

        
        #endregion


    }
}
