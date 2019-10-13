using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert.Standard;
using Albert.Standard.Win32;
using System.Windows;
using System.Windows.Media;
using static Albert.Standard.Win32.ColorUtility;  
namespace amFlowDoczBase
{
	public class DrawViewModel : ViewModel
	{
		//Field's 
		VMList<DrawPaper> sizes;
		VMList<DrawTheme> themes;

		public DrawViewModel()
		{
			//Create the Lists 
			initLists();
		}

		void initLists()
		{
			//All Document Sizes 
			sizes = new VMList<DrawPaper>();
			sizes.Add(new DrawPaper(1920, 1080));
			sizes.Add(new DrawPaper(1080, 1920));
			sizes.Add(new DrawPaper(1080, 1080));
			sizes.Add(new DrawPaper(850, 1100));
			sizes.Add(new DrawPaper(1100, 850));
			sizes.Add(new DrawPaper(504, 504));
			sizes.Add(new DrawPaper(300, 300));
			sizes.Add(new DrawPaper(100, 100));

			//Define Default Theme 
			themes = new VMList<DrawTheme>();
            themes.Add(new DrawTheme("Black & White", "#ffffff", "#000000"));
            themes.Add(new DrawTheme(" Old Paper", "#000000", "#FFB8B016"));
            themes.Add(new DrawTheme("Caulkboard", "#ffffff", "#FF1C7158"));
            themes.Add(new DrawTheme("Blueboard", "#ffffff", "#FF07128B"));


        }
		/// <summary>
		/// Get the Sizes 
		/// </summary>
		public VMList<DrawPaper> Sizes
		{
			get { return sizes; }
            set { sizes = value; OnPropertyChanged("Sizes"); }
                    
		}
		/// <summary>
		/// Get the Default THemes  LIst 
		/// </summary>
		public VMList<DrawTheme> Themes
		{
			get {return themes; }
            set { themes = value; OnPropertyChanged("Themes"); }
       
      
		}

	}
}
