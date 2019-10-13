using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
namespace Albert.Standard.Win32
{
	/// <summary>
	/// A special ContentControl designed to deal with handling tab documents. 
	/// </summary>
	public class DocumentControl : ContentControl, IAddCommand, ILogic
	{
        #region Depedency Properties
        public static DependencyProperty TopDialogBarProperty = DependencyProperty.Register("TopDialogBar", typeof(object),typeof(DocumentControl),null);
        public static DependencyProperty BottomDialogBarProperty = DependencyProperty.Register("BottomDialogBar", typeof(object), typeof(DocumentControl), null);
        public static DependencyProperty TopDialogVisibilityProperty = DependencyProperty.Register("TopDialogVisibility", typeof(Visibility), typeof(DocumentControl), new PropertyMetadata(Visibility.Visible));
        public static DependencyProperty BottomDialogVisibilityProperty = DependencyProperty.Register("BottomDialogVisibility", typeof(Visibility), typeof(DocumentControl), new PropertyMetadata(Visibility.Visible));

        #endregion
        public DocumentControl()
        {
            //ReDraw the Control 
            DefaultStyleKey = typeof(DocumentControl);
        }

        #region ILogic Method's 

        /// <summary>
        /// A quick way to add extra logic to the constructor 
        /// </summary>
        public void Logic()
        {
            //Run On Logic 
            OnLogic();
        }
        /// <summary>
        /// Override method for handling the Logic of the Application 
        /// </summary>
        public virtual void OnLogic()
        {

        }

        #endregion


        #region Method's for Creating Tab's Quickly

        public void SetupTab(string _header,bool _isClosedEnabled,TabControl _tab)
        {
            //Create a new TabItem 
            TabItem = new DocumentTabItem(_header, _isClosedEnabled , this, _tab);

        }


        public void SetupTab(string _header,TabControl _tab,Action _closeMethod)
        {
            //Create a new TabItem 
            TabItem = new DocumentTabItem(_header, this, _tab);

            //Close Method 
            TabItem.Closed += (sender, e) =>
            {
                _closeMethod.Invoke();
            };

            //Focus on the Tab 
            TabItem.Focus();
            this.Focus();

        }

        #endregion


        #region Method from IAddCommand 

        /// <summary>
        /// Quick way to add a Coomamand to the control
        /// </summary>
        /// <param name="_command"></param>
        /// <param name="_method"></param>
        public void AddCommand(ICommand _command, ExecutedRoutedEventHandler _method)
		{
			CommandBindings.Add(new CommandBinding(_command, _method));
		}

        #endregion 

        #region Hide and Show Functions 
        /// <summary>
        /// Event Happens when Show the documen t
        /// </summary>
        public event Action<ShowEventArgs> OnShow;
		/// <summary>
		/// Event happens when you hide the document
		/// </summary>
		public event Action<ShowEventArgs> OnHide;

        /// <summary>
        /// A quick method to show the control
        /// </summary>
        public void Show()
		{
            //Setup your ShowEventArgs
            ShowEventArgs args = new ShowEventArgs
            {
                Visibility = Visibility,
                Opacity = Opacity
            };
            //OnShow
            switch (OnShow)
			{
				case null:
					Visibility = Visibility.Visible;
					break;
				default:
					OnShow.Invoke(args);
					Visibility = Visibility.Visible;
					break;
			}
		}
		/// <summary>
		/// Quick way to hide the control
		/// </summary>
		public void Hide()
		{
			//Setup your ShowEventArgs
			var args = new ShowEventArgs();
			args.Visibility = Visibility;
			args.Opacity = Opacity;
			
			//OnHide 
			switch (OnHide)
			{
				case null:
					Visibility = Visibility.Collapsed;
					break;
				default:
					Visibility = Visibility.Collapsed;
					//Do the OnHide Method 
					OnHide.Invoke(args);
					break;
			}
		}

        #endregion

        #region Main Public Properties
        
        public object TopDialogBar
        {
            get { return (object)GetValue(TopDialogBarProperty); }
            set { SetValue(TopDialogBarProperty, value); }
        }

        public object BottomDialogBar
        {
            get { return (object)GetValue(BottomDialogBarProperty); }
            set { SetValue(BottomDialogBarProperty, value); }
        }

        public object TopDialogVisibility
        {
            get { return (Visibility)GetValue(TopDialogVisibilityProperty); }
            set { SetValue(TopDialogVisibilityProperty, value); }
        }


        public Visibility BottomDialogVisibility
        {
            get { return (Visibility)GetValue(BottomDialogVisibilityProperty); }
            set { SetValue(BottomDialogVisibilityProperty, value); }
        }

        /// <summary>
        /// Gets or sets a Page that ueses the DocumentControl
        /// </sBoxummary>
        public Page Page { get; set; }

		/// <summary>
		/// Gets or sets the TabItem that uses the DocumentControl 
		/// </summary>
		public DocumentTabItem TabItem { get; set; }


		/// <summary>
		/// Gets or sets the TabControl that uses the DocumentControl 
		/// </summary>
		public TabControl MainTabControl { get; set; }

		public string CurrentFile { get; set; }

		public FileInfo FileInfo { get; set; }

		public static int Count { get; set; } = 1;

        #endregion


    }
}
