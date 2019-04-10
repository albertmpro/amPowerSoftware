namespace Albert.Standard
{
	/// <summary>
	/// Static CLass designed to create webpages,css,and javascript files 
	/// </summary>
	public static class HtmlCore
	{


		#region Html Generator's 
		/// <summary>
		/// Default Html Document 
		/// </summary>
		/// <param name="_description">Description</param>
		/// <param name="_keywords">Keywords</param>
		/// <param name="_author">Author</param>
		/// <returns></returns>
		public static string HtmlDoc(string _description, string _keywords, string _author)
		{
			var description = _description; //Define the website
			var keywords = _keywords; //Define keywords
			var author = _author; //Define the author of the webpage 
								  //Spit out an html document 
			var rv = $"<!DOCTYPE html>\n<html lang=\"en\">\n<head>\n<meta charset=\"UTF-8\"\n<meta name=\"viewport\" content=\"width=device-width,initial-scale=1\" >\n <meta name=\"description\" content=\"{description}\">\n<meta name=\"keywords\" content=\"{keywords}\">\n<meta name=\"author\" content=\"{author}\" >\n\n</head>\n<body>\n\n</body>\n\n</html>";
			//Return the html document 
			return rv;
		}
		/// <summary>
		/// Html Document with Title 
		/// </summary>
		/// <param name="_description">Description</param>
		/// <param name="_keywords">Keywords</param>
		/// <param name="_author">Author</param>
		/// <param name="_title">Title</param>
		/// <returns></returns>
		public static string HtmlDoc(string _description, string _keywords, string _author, string _title)
		{
			var description = _description; //Define the website
			var keywords = _keywords; //Define keywords
			var author = _author; //Define the author of the webpage
			var title = _title;
			//Spit out an html document 
			var rv = $"<!DOCTYPE html>\n<html lang=\"en\">\n<head>\n<meta charset=\"UTF-8\">\n<title>{title}</title>\n<meta name=\"viewport\" content=\"width=device-width,initial-scale=1\">\n <meta name=\"description\" content=\"{description}\">\n<meta name=\"keywords\" content=\"{keywords}\">\n<meta name=\"author\" content=\"{author}\" >\n\n</head>\n<body>\n\n</body>\n\n</html>";
			//Return the html document 
			return rv;
		}


		public static string HtmlDoc(string _description, string _keywords, string _author, string _title, string _style)
		{
			var description = _description; //Define the website
			var keywords = _keywords; //Define keywords
			var author = _author; //Define the author of the webpage
			var title = _title; //Define the title 
			var style = _style; // Define the style 
								//Spit out an html document 
			var rv = $"<!DOCTYPE html>\n<html lang=\"en\">\n<head>\n<meta charset=\"UTF-8\">\n<title>{title}</title>\n<meta name=\"viewport\" content=\"width=device-width,initial-scale=1\">\n <meta name=\"description\" content=\"{description}\">\n<meta name=\"keywords\" content=\"{keywords}\">\n<meta name=\"author\" content=\"{author}\" >\n<link rel=\"stylesheet\" type=\"text/css\" media=\"screen\" href=\"{style}\" />\n\n</head>\n<body>\n\n</body>\n\n</html>";
			//Return the html document 
			return rv;
		}

		public static string HtmlDoc(string _description, string _keywords, string _author, string _title, string _style, string _script)
		{
			var description = _description; //Define the website
			var keywords = _keywords; //Define keywords
			var author = _author; //Define the author of the webpage
			var title = _title; //Define the title 
			var style = ConvertCssTag(_style); // Define the style 
			var script = ConvertCssTag(_script); // Define the script file 

			//Spit out an html document 
			var rv = $"<!DOCTYPE html>\n<html lang=\"en\">\n<head>\n<meta charset=\"UTF-8\">\n<title>{title}</title>\n<meta name=\"viewport\" content=\"width=device-width,initial-scale=1\">\n <meta name=\"description\" content=\"{description}\">\n<meta name=\"keywords\" content=\"{keywords}\">\n<meta name=\"author\" content=\"{author}\" >\n{style}\n\n</head>\n<body>\n\n{script}\n\n</body>\n\n</html>";
			//Return the html document 
			return rv;
		}

		public static string HtmlDoc(string _description, string _keywords, string _author, string _title, CoreList<string> _styles, CoreList<string> _scripts)
		{
			var description = _description; //Define the website
			var keywords = _keywords; //Define keywords
			var author = _author; //Define the author of the webpage
			var title = _title; //Define the title 
			var style = ""; // Define the style 
			var script = ""; // Define the script file 

			//Create styles 
			_styles?.ForEach((i) =>
			{
				style += ConvertCssTag(i);
			});

			//Create scripts 
			_scripts?.ForEach((i) =>
			{
				script += ConvertScriptTag(i);
			});

			//Spit out an html document 
			var rv = $"<!DOCTYPE html>\n<html lang=\"en\">\n<head>\n<meta charset=\"UTF-8\">\n<title>{title}</title>\n<meta name=\"viewport\" content=\"width=device-width,initial-scale=1\">\n <meta name=\"description\" content=\"{description}\">\n<meta name=\"keywords\" content=\"{keywords}\">\n<meta name=\"author\" content=\"{author}\" >\n{style}\n\n</head>\n<body>\n\n{script}\n\n</body>\n\n</html>";
			//Return the html document 
			return rv;
		}
		#endregion

		#region Css Functions 
		/// <summary>
		/// Create a CSS Defnition 
		/// </summary>
		/// <param name="_content"></param>
		/// <returns></returns>
		public static string CssDef(string _content)
		{
			var rv = $"\n{{\n\t{_content}\n}}\n";

			return rv;
		}

		public static string CssDef(string _name, CoreList<string> _list)
		{
			var rv = $"{_name}\n{{";
			_list?.ForEach((i) =>
			{
				rv += i;
			});
			rv += $"}}";
			return rv;
		}

		public static string CssDef(string _name, string _content)
		{
			var rv = $"{_name}\n{{\n{_content}\n}}\n";
			return rv;
		}
		

		public static string CssDef(string _name, CoreList<CssAtt> _list)
		{
			var rv = $"{_name}\n{{";
			_list?.ForEach((i) =>
			{
				rv += i.ToString();
			});
			rv += $"}}";
			return rv;
		} 
		#endregion
		

		#region Converters

		


		/// <summary>
		/// Create CSS Attribute 
		/// </summary>
		/// <param name="_name">Name</param>
		/// <param name="_value">Value </param>
		/// <returns></returns>
		public static string CssAtt(string _name, string _value)
		{
			var rv = $"\t{_name}: {_value};";

			return rv;
		}

		/// <summary>
		/// Create JavaScript file 
		/// </summary>
		/// <param name="_url"></param>
		/// <returns></returns>
		public static string ConvertScriptTag(string _url)
		{
			return $"<script langauge=\"javascript\" src=\"{_url}\"></script>";
		}
		/// <summary>
		/// Create a Css Tag
		/// </summary>
		/// <param name="_url"></param>
		/// <returns></returns>
		public static string ConvertCssTag(string _url)
		{
			return $"<link rel=\"stylesheet\" type=\"text/css\" media=\"screen\" href=\"{_url}\" />";
		}
		/// <summary>
		/// Create a Css Tag with Media
		/// </summary>
		/// <param name="_url"></param>
		/// <param name="_media"></param>
		/// <returns></returns>
		public static string ConvertCssTag(string _url, string _media)
		{
			return $"<link rel=\"stylesheet\" media=\"{_media}\" type=\"text/css\" href=\"{_url}\" />";
		}
		/// <summary>
		/// Create Icon tag
		/// </summary>
		/// <param name="_url"></param>
		/// <returns></returns>
		public static string ConvertIconTag(string _url)
		{
			return $"<link rel=\"shortcut icon\" href=\"{_url}\" type=\"image/x-icon\" />";
		}
		/// <summary>
		/// Create an Image Tag
		/// </summary>
		/// <param name="_url"></param>
		/// <param name="_title"></param>
		/// <returns></returns>
		public static string ConvertImgTag(string _url, string _title)
		{
			return $"<img src={_url} src=\"{_title}\" />";
		}
		/// <summary>
		/// Create a Div Tag
		/// </summary>
		/// <param name="_content"></param>
		/// <returns></returns>
		public static string ConvertDivTag(string _content)
		{
			return $"<div>\n{_content}\n</div>";
		}
		/// <summary>
		/// Create a Paragraph Tag
		/// </summary>
		/// <param name="_content"></param>
		/// <returns></returns>
		public static string ConvertParagraphTag(string _content)
		{
			return $"<p>\n{_content}\n</p>";
		}
		#endregion


	}
}
