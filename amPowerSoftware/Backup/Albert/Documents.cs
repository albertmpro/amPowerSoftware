using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albert.Standard
{
	/// <summary>
	/// Default Text Documents that I want to use in this Application 
	/// </summary>
	public static class Documents
	{///
		/// <summary>
		/// Get apage.js document 
		/// </summary>
		public static string aPageJS
		{
			get
			{
				var rv = "//basic page functions\n\n//Quick id grab\nfunction a(id);\n{\n\tdocument.getElementById(id)\n}\n\n//ForEach\nfunction forEach(array,e)\n{\n\tfor(var i - 0; array.length; i++)\n\t\t//Execute the function\n\t\te(array[i];\n}\nfunction astyle(id)\n{\nreturn document.getElementById(id).style;\n}\nfunction ashowhide(id)\n{\nif(astyle*id).display == \"block\")\n\tastyle(id).display = \"none\";\n}\nelse\n{\n\tastyle(id).display =\"block\";\n}";
				return rv;
			}
		}
		/// <summary>
		/// Get the aFlex.scss
		/// </summary>
		public static string aFlex
		{
			get
			{
				var rv = @"
//flex.scss
// Designed to help create complex css layouts
// Created by Albert M. Byrd
// Copyright 2017




@mixin bodySetup($cwidth,$font,$fontsize,$fore,$back) {
	body {
		margin: 0px;
		padding: 0px;
		width: 100%; //Default width
		font-family: $font; //Default font
		font-size: $fontsize; // Default fontsize
		background: $back; //DefaultBackground
	}
	#mnu
	{
		display: none; 
	}

	img {
		border: 0px;
	}

	#paper {
		width: 100%;
		position: absolute;
		top: 0px;
	}

	.content {
		//@include contentSetup($cwidth,15px);
		margin-right: auto;
		margin-left: auto; 
		padding: 15px; 
		width: $cwidth; 
	}

	.clear {
		clear: both;
	}

	.crow {
		display: table;
		padding-left: -15px;
		padding-right: -15px;
	}

	.c2 {
		width: 50%;
		padding: 5px;
		margin-left: auto;
		margin-right: auto;
	}

	.c3 {
		width: 33%;
		padding: 5px;
		margin-left: auto;
		margin-right: auto;
	}

	.c4 {
		width: 25%;
		padding: 5px;
		margin-left: auto;
		margin-right: auto;
	}

	.c5 {
		width: 20%;
		padding: 5px;
		margin-left: auto;
		margin-right: auto;
	}

	.cmain {
		width: 66%;
		padding: 5px;
		margin-left: auto;
		margin-right: auto;
	}

	.cside {
		width: 30%;
		padding: 5px;
		margin-left: auto;
		margin-right: auto;
	}

	.cmain_pull {
		width: 66%;
		padding: 5px;
		float: left;
		margin-left: auto;
		margin-right: auto;
	}

	.cside_pull {
		width: 30%;
		padding: 5px;
		float: right;
		margin-left: auto;
		margin-right: auto;
	}
	// Left Align
	.left {
		text-align: left;
	}
	// Center Align
	.center {
		text-align: center;
	}
	// Right Align
	.right {
		text-align: right;
	}
	// Justify Align
	.justify {
		text-align: justify;
	}



	#mnu // Do not show this menu {
		display: none;

		div {
			display: none;
		}
	}
	//mobile setup
	@media screen and (max-width: 768px) {
		#mnu 
		{
			float: right;
			//margin-top: 10px;
			width: 40px;
			height: 40px;
			display: block;
			cursor: pointer;

			div 
			{
				width: 20px;
				height: 4px;
				background: #fff;
				margin: 3px 0px;
				border-radius: 4px;
				display: block;
			}
		}

		.content {
			width: 85%;
			margin-left: 15px;
			margin-right: 15px;
		}

		.c2, .c3, .c4, .cmain, .cside, .cmain_pull, .cside_pull {
			padding: 5px;
			width: 95%;
			display: block;
			float: none;
		}
	}
}


";

				return rv;
			}
		}
		/// <summary>
		/// Get the WPindex Theme document
		/// </summary>
		public static string WPIndex
		{
			get
			{
				var rv = "<?php\n\nif(have_posts():\n\twhile(have_post()):\n\t\tthe_post();\n\n\t\tget_template_part('content');\n\n\tendwhile;\nelse\n\tehco\"nothing found\"\nendif;\n?>\n<?php\n\n?> ";
				return rv;
			}
		}
		/// <summary>
		/// Get the WordPress functions document 
		/// </summary>
		public static string WPFunctions
		{
			get
			{
				var rv = "<?php\n\n?>";
				return rv;
			}
		}
		/// <summary>
		/// Gets the WordpRess Header for a theme
		/// </summary>
		public static string WPHeader
		{
			get
			{
				var rv = "<!DOCYTPE html>\n\n<html>\n<head>\n\n<title><?php  bloginfo('name'); ?></title>\n\n<?php wp_head(); //Hook for WordPress ?>\n\n</head>\n\n<body>\n";
				return rv;
			}
		}
		/// <summary>
		/// Get the WordPress footer for a theme 
		/// </summary>
		public static string WPFooter
		{
			get
			{
				var rv = "\n</body>\n\n</html>\n";
				return rv;
			}
		}
		/// <summary>
		/// Get the WordPress Stylesheet 
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="_author"></param>
		/// <param name="_version"></param>
		/// <returns></returns>
		public static string WPStyle(string _name, string _author, string _version)
		{
			var rv = $"/*\n\nTheme Name:{_name}\nAuthor:{_author}\nVersion:{_version}\n\n*/";
			return rv;
		}

	}
}
