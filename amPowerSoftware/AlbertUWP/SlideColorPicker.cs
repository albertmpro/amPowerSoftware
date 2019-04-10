using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Albert.Standard;
using static Albert.Standard.Runtime.Device10x;
// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace Albert.Standard.Runtime
{
	[TemplatePart(Name = "PART_SlideRed", Type = typeof(Slider))]
	[TemplatePart(Name = "PART_SlideGreen", Type = typeof(Slider))]
	[TemplatePart(Name = "PART_SlideBlue", Type = typeof(Slider))]
	[TemplatePart(Name = "PART_RectangleColor", Type = typeof(Rectangle))]
	[TemplatePart(Name = "PART_List", Type = typeof(GridView))]
	[TemplatePart(Name = "PART_Copy", Type = typeof(TextBox))]
	/// <summary>
	/// Pick a color with sliders 
	/// </summary>
	public sealed class SlideColorPicker : Control
	{


		Slider slideRed = new Slider();
		Slider slideGreen = new Slider();
		Slider slideBlue = new Slider();
		Rectangle rectangle = new Rectangle();
		GridView colorList = new GridView();
		VMList<ColorModel> colors = new VMList<ColorModel>();
		TextBox txtCopy = new TextBox();
		public SlideColorPicker()
		{
			this.DefaultStyleKey = typeof(SlideColorPicker);
		}

		protected override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			slideRed = GetTemplateChild("PART_SlideRed") as Slider;
			slideGreen = GetTemplateChild("PART_SlideGreen") as Slider;
			slideBlue = GetTemplateChild("PART_SlideBlue") as Slider;
			rectangle = GetTemplateChild("PART_RectangleColor") as Rectangle;
			colorList = GetTemplateChild("PART_List") as GridView;
			txtCopy  = GetTemplateChild("PART_Copy") as TextBox;

			//txtCopy Lamba 
			if(txtCopy != null)
			{
				txtCopy.GotFocus += (sender, e) =>
				{
					txtCopy.SelectAll();
				};
			}
		

			//Link list to list here 
			colorList.ItemsSource = colors;
			
			//colorList selected lamba 
			colorList.SelectionChanged += (sender, e) =>
			{
				if (colorList.SelectedItem != null)
				{
					var cm = (ColorModel)colorList.SelectedItem;
					SelectedColor = cm.Color;

				
				}
			};


			//Changed 
			slideRed.ValueChanged += Slide_ValueChanged;
			slideGreen.ValueChanged += Slide_ValueChanged;
			slideBlue.ValueChanged += Slide_ValueChanged;
		}
		public event Action<Color> OnColorChanged;

		public static readonly DependencyProperty ListHeightProperty = NewDP("ListHeight", typeof(double), typeof(SlideColorPicker));
		public static readonly DependencyProperty ListWidthProperty = NewDP("ListWidth", typeof(double), typeof(SlideColorPicker));

		public static readonly DependencyProperty SelectedColorProperty = DependencyProperty.Register("SelectedColor",
			typeof(Color),
			typeof(ColorPickBase), new PropertyMetadata(Colors.Black, ((sender, e) =>
			{
				SlideColorPicker slide = (SlideColorPicker)sender;
				var color = slide.SelectedColor; 

				if(color != null)
				{
					slide.slideRed.Value = color.R;
					slide.slideGreen.Value = color.G;
					slide.slideBlue.Value = color.B;
				}

			})));

		public VMList<ColorModel> ColorHistory { get { return colors; } }

		public Color SelectedColor
		{
			get { return (Color)GetValue(SelectedColorProperty); }
			set { SetValue(SelectedColorProperty, value); }
		}
		/// <summary>
		/// Gets or sets the height of the listbox 
		/// </summary>
		public double ListHeight
		{
			get { return (double)GetValue(ListHeightProperty); }
			set { SetValue(ListHeightProperty, value); }
		}

		/// <summary>
		/// Gets or sets the width of the listbox
		/// </summary>
		public double ListWidth
		{
			get { return (double)GetValue(ListWidthProperty); }
			set { SetValue(ListWidthProperty, value); }
		}

		void Slide_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
		{
			//Convert Slide values to Color Values 
			byte R, G, B;
			R = Convert.ToByte(slideRed.Value);
			G = Convert.ToByte(slideGreen.Value);
			B = Convert.ToByte(slideBlue.Value);
			SelectedColor = Color.FromArgb(255, R, G, B);
			rectangle.Fill = new SolidColorBrush(SelectedColor);

			if (OnColorChanged != null)
			{
				ColorHistory.Add(new ColorModel(SelectedColor));
				OnColorChanged(SelectedColor);

				if (ColorHistory.Count >= 1000)
					ColorHistory.Clear();

			}
		}


	}
}
