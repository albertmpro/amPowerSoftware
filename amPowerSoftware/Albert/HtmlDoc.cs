using System;
using System.Collections.Generic;
using System.Text;

namespace Albert.Standard
{
	public class HtmlDoc : Notify
	{
		//Field's 
		string aname, disc, keywords,title,body,head;
		/// <summary>
		/// Get or set the Author Name 
		/// </summary>
		public string Author
		{
			get { return aname; }
			set { aname = value; OnPropertyChanged("Author"); }
		}
		/// <summary>
		/// Get or sets the keywords
		/// </summary>
		public string Keywords
		{
			get { return keywords; }
			set { keywords = value; OnPropertyChanged("Keywords"); }
		}
		public string Description
		{
			get { return disc; }
			set { disc = value; OnPropertyChanged("Description"); }
		}
		/// <summary>
		/// Get or sets the BOdy of the html contnet 
		/// </summary>
		public string Body
		{
			get { return body; }
			set { body = value; OnPropertyChanged("Body"); }
		}
		/// <summary>
		/// Get or sets other head content 
		/// </summary>
		public string Head
		{
			get { return head; }
			set { head = value; OnPropertyChanged("head"); }
		}

		public string Title
		{
			get { return title; }
			set { title = value; OnPropertyChanged("Title"); }
		}



		/// <summary>
		/// Creates an HTml document 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			var rv = $"<!DOCTYPE html>\n<html lang=\"en\">\n<head>\n<meta charset=\"UTF-8\"\n<meta name=\"viewport\" content=\"width=device-width,initial-scale=1\" >\n <meta name=\"description\" content=\"{Description}\">\n<meta name=\"keywords\" content=\"{Keywords}\">\n<meta name=\"author\" content=\"{Author}\" >\n<title>{Title}</title>\n{Head}\n</head>\n<body>\n\n</body>\n{Body}\n</html>";
			return rv;
		}

	}
}
