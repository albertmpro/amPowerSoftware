using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert.Standard;
namespace Albert.Standard.Runtime
{
	/// <summary>
	/// Model is designed to quiclky build a responsive  html document 
	/// </summary>
	public class HtmlTemp : Notify
	{
		//Field's 
		string description, keywords, author, head, body;
		List<string> styles, scripts;

		#region Constructor's 
		/// <summary>
		/// Default Constructor returns everything empty 
		/// </summary>
		public HtmlTemp()
		{
			description = "";
			keywords = "";
			author = "";
			head = "";
			body = "";
		}
		/// <summary>
		/// Constructor desgined the discritpon,head and body tag
		/// </summary>
		/// <param name="_description"></param>
		/// <param name="_keywords"></param>
		/// <param name="_author"></param>
		/// <param name="_head"></param>
		/// <param name="_body"></param>
		public HtmlTemp(string _description, string _keywords, string _author, string _head, string _body)
		{
			description = _description;
			keywords = _keywords;
			author = _author;
			head = _head;
			body = _body;
		}
		/// <summary>
		/// Constructor designed to discribe the description 
		/// </summary>
		/// <param name="_description"></param>
		/// <param name="_keywords"></param>
		/// <param name="_author"></param>
		public HtmlTemp(string _description, string _keywords, string _author)
		{
			description = _description;
			keywords = _keywords;
			author = _author;
			head = "";
			body = "";

		}
		#endregion

		#region Converters 
		/// <summary>
		/// Converts a link to your javascript file 
		/// </summary>
		/// <param name="_url"></param>
		/// <returns></returns>
		public static string ConvertScriptTag(string _url)
		{
			return $"<script langauge='javascript' src='{_url}'></script>";
		}
		/// <summary>
		/// Converts a link to your Css  file 
		/// </summary>
		/// <param name="_url"></param>
		/// <returns></returns>
		public static string ConvertCssTag(string _url)
		{
			return $"<link rel='styleseet' type='text/css' media='screen' href='{_url}' />";
		}
		public static string ConvertCssTag(string _url, string _media)
		{
			return $"<link rel='styleseet' media='{_media}' type='text/css' href='{_url}' />";
		}
		public static string ConvertIconTag(string _url)
		{
			return $"<link rel='shortcut icon' href='{_url}' type='image/x-icon' />";
		}
		public static string ConvertImgTag(string _url, string _title)
		{
			return $"<img src={_url} src='{_title}' />";
		}
		public static string ConvertDivTag(string _content)
		{
			return $"<div>\n{_content}\n</div>";
		}
		public static string ConvertParagraphTag(string _content)
		{
			return $"<p>\n{_content}\n</p>";
		}
		#endregion

		#region Properties 

		public List<string> Styles
		{
			get { return styles; }
			set { styles = value; OnPropertyChanged("Styles"); }
		}
		public List<string> Scripts
		{
			get { return scripts; }
			set { scripts = value; OnPropertyChanged("Scripts"); }
		}
		public string Description
		{
			get
			{
				var rv = $"<meta name='description' content='{description}' >";
				return rv;
			}

			set
			{
				description = value;
				OnPropertyChanged("Description");
			}
		}

		public string Author
		{
			get
			{
				var rv = $"<meta name='author' content='{author}' >";
				return rv;
			}

			set
			{
				author = value;
				OnPropertyChanged("Author");
			}
		}



		public string Keywords
		{
			get
			{
				var rv = $"<meta name='keywords' content='{keywords}' >";
				return rv;
			}

			set
			{
				keywords = value;
				OnPropertyChanged("Keywords");
			}
		}



		public string Head
		{
			get
			{
				var start = "\n<head>\n";
				var middle = $"\n<head>\n<meta charset='UTF-8'>\n<meta name='viewport' content = 'width=device-width, initial-scale=1' >\n{Description}\n{Keywords}\n{Author}\n";
				var end = "\n</head>";

				Styles?.ForEach((s) =>
				{
					middle += ConvertCssTag(s);
				});
				//Spit back out into the main head tag organized into the head 
				return $"{start}{middle}{head}{end}";
			}

			set
			{
				head = value;
				OnPropertyChanged("Head");
			}
		}

		public string Body
		{
			get
			{
				var start = "\n<body>\n";
				var middle = $"{body}";
				var end = "\n</body>\n";

				Scripts?.ForEach((s) =>
				{
					middle += ConvertScriptTag(s);
					middle += "\n";
				});
				return $"{start}{middle}{end}";
			}

			set
			{
				body = value;
				OnPropertyChanged("Body");
			}
		}
		#endregion



		/// <summary>
		/// Returns a HTML 5 document 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{

			var str = $"<!DOCTYPE html>\n{Head}\n\n{Body}\n</html>";

			return str;
		}


	}
}
