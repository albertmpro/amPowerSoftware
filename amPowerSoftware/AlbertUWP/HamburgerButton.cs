using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
namespace Albert.Standard.Runtime
{



	[TemplatePart(Name = "PART_Icon", Type = typeof(Image))]
	[TemplatePart(Name = "PART_Symbol", Type = typeof(TextBlock))]

	/// <summary>
	/// A special button f
	/// \0or the SplitView
	/// </summary>
	public class HamburgerButton : PushButton
	{

		//Field's 
		TextBlock tbSymbol = new TextBlock();
		Image imgIcon = new Image();

		public static readonly DependencyProperty SymbolProperty = DependencyProperty.Register(
			"Symbol", typeof(string), typeof(HamburgerButton), null);



		public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
			"Label", typeof(string), typeof(HamburgerButton), null);

		public static readonly DependencyProperty ShowSymbolProperty = DependencyProperty.Register(
	"ShowSymbol", typeof(Visibility), typeof(HamburgerButton), null);

		public static readonly DependencyProperty ShowImageProperty = DependencyProperty.Register(
"ShowImage", typeof(Visibility), typeof(HamburgerButton), null);
		public static readonly DependencyProperty SymbolFontFamilyProperty = DependencyProperty.Register("SymbolFontFamily", typeof(FontFamily), typeof(HamburgerButton), new PropertyMetadata(new FontFamily("Segoe MDL2 Assets")));

		public static readonly DependencyProperty IconSourceProperty = DependencyProperty.Register("IconSource", typeof(ImageSource), typeof(HamburgerButton), null);

		public static readonly DependencyProperty IconStretchProperty = DependencyProperty.Register("IconStretch", typeof(Stretch), typeof(HamburgerButton), new PropertyMetadata(Stretch.Uniform));


		protected override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			tbSymbol = GetTemplateChild("PART_Symbol") as TextBlock;
			imgIcon = GetTemplateChild("PART_Icon") as Image;

		}

		public HamburgerButton()
		{
			DefaultStyleKey = typeof(HamburgerButton);
		}

		public Visibility ShowSymbol
		{
			get { return (Visibility)GetValue(ShowSymbolProperty); }
			set { SetValue(ShowSymbolProperty, value); }
		}

		public Visibility ShowImage
		{
			get { return (Visibility)GetValue(ShowImageProperty); }
			set { SetValue(ShowImageProperty, value); }
		}

		public ImageSource IconSource
		{
			get { return (ImageSource)GetValue(IconSourceProperty); }
			set { SetValue(IconSourceProperty, value); }
		}

		public Stretch IconStretch
		{
			get { return (Stretch)GetValue(IconStretchProperty); }
			set { SetValue(IconStretchProperty, value); }
		}

	
		public string Symbol
		{
			get
			{
				return (string)GetValue(SymbolProperty);
			}
			set
			{
				SetValue(SymbolProperty, value);
			}
		}
		public string Label
		{
			get
			{
				return (string)GetValue(LabelProperty);
			}
			set
			{
				SetValue(LabelProperty, value);
			}
		}

		public FontFamily SymbolFontFamily
		{
			get
			{
				return (FontFamily)GetValue(SymbolFontFamilyProperty);
			}
			set
			{
				SetValue(SymbolFontFamilyProperty, value);
			}
		}

	

	}

}
