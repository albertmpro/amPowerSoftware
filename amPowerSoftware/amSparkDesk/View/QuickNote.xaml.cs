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
using tk= Xceed.Wpf.Toolkit;
using System.IO;
using static Albert.Standard.Win32.Win32IO;
namespace amSparkDesk.View
{
	/// <summary>
	/// Interaction logic for QuickNote.xaml
	/// </summary>
	public partial class QuickNote : tk.ChildWindow
	{
		public QuickNote()
		{
			InitializeComponent();
		}

		void push_click(object sender, RoutedEventArgs e )
		{
			//Grab the Button instance 
			var push = sender as PushButton;

			//Default Filter 
			var filter = "All Files (.)|*.*";
			
			// Function by the Tag on the Button 
			switch(push.Tag)
			{
				case "New":
					//Create the MessageBox 
					var msg = tk.MessageBox.Show("Do you want to create a new Document", "New Note", MessageBoxButton.YesNo);

					switch(msg)
					{
						case MessageBoxResult.Yes:
							txt.Text = "";
							break;
						case MessageBoxResult.No:
							
							

							break;
					}



					break;
				case "Open":

					//Open Dialog Lamba 
					OpenDialogTask("Open Text File", filter, (o) =>
					  {
						  //Open File and throw it on the Text box
						  txt.Text = File.ReadAllText(o.FileName);
					  });
					break;
				case "Save":
					SaveDialogTask("Save Text File", filter, (s) =>
					{
						//Write the TextFile 
						File.WriteAllText(s.FileName, txt.Text);
					});
					break;
			}

		}

	}
}
