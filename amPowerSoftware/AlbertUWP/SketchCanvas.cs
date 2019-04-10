using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;
namespace Albert.Standard.Runtime
{
	public class SketchCanvas: Canvas 
	{
		uint _penID, _touchID;

		//Represnts the current draw state 
		SketchState state;
		
		//Gets the previous and current points 
		Point _previousPoint, _currentPoint;
		
		//Lines 
		private Line straightLine; 

		// drawThickness,drawOpacity, and X and Y Coridnents 
		double x1, y1, x2, y2,drawThickness,drawOpacity;

		//PenLineTips of the brush 
		PenLineCap startPenLineCap, endPenLineCap; 

		//DrawBrush 
		Brush drawBrush;

	

		// Pepresents a Circle 
		private Ellipse newCircle;

		//Represents Rectangle
		private Rectangle newRectangle;

		private Path newPath;

		//int numberOfChildrenBeforeRender;
		/// <summary>
		/// Default Constructor 
		/// </summary>
		public SketchCanvas()
		{
			InitSkeetch();

		}

		public void InitSkeetch()
		{
			//Default Background
			Background = new SolidColorBrush(Colors.White);

			//Default for the DrawBrush 
			drawBrush = new SolidColorBrush(Colors.Black);

			//Default the Thickness 
			drawThickness = 4.9;

			//Default SketchState 
			SketchState = SketchState.Draw;
			//Default Opacity 
			drawOpacity = .10;// 10% opacity

			//Default Canvas PointerEvnets for drawing 
			PointerPressed += new PointerEventHandler(Canvas_PointerPressed);
			PointerMoved += new PointerEventHandler(Canvas_PointerMoved);
			PointerReleased += new PointerEventHandler(Canvas_PointerReleased);
			PointerExited += new PointerEventHandler(Canvas_PointerReleased);
		}

		void Canvas_PointerPressed(object sender, PointerRoutedEventArgs e)
		{
			PointerPoint pt = e.GetCurrentPoint(this);
			_previousPoint = pt.Position;

			PointerDeviceType pointerDevType = e.Pointer.PointerDeviceType;
			if (pointerDevType == PointerDeviceType.Pen || pointerDevType == PointerDeviceType.Touch
			|| pointerDevType == PointerDeviceType.Mouse &&
				   pt.Properties.IsLeftButtonPressed)
			{

				_penID = pt.PointerId;
				_touchID = pt.PointerId;
				//inkManger.ProcessPointerDown(pt);
				e.Handled = true;
			}
			switch(SketchState)
			{
				case SketchState.Line:
							
							straightLine = new Line();
							straightLine.X1 = e.GetCurrentPoint(this).Position.X;
							straightLine.Y1 = e.GetCurrentPoint(this).Position.Y;
							straightLine.X2 = straightLine.X1 + 1;
							straightLine.Y2 = straightLine.Y1 + 1;
							straightLine.StrokeThickness = drawThickness;
							straightLine.Stroke = drawBrush;
							straightLine.Opacity = drawOpacity;


							Children.Add(straightLine);
					break;
				case SketchState.Rectangle:
					newRectangle = new Rectangle();
					x1 = e.GetCurrentPoint(this).Position.X;
					y1 = e.GetCurrentPoint(this).Position.Y;
					x2 = x1;
					y2 = y1;
					newRectangle.Width = x2 - x1;
					newRectangle.Height = y2 - y1;
					newRectangle.StrokeThickness = drawThickness;
					newRectangle.Stroke = drawBrush;
					newRectangle.Opacity = drawOpacity;
					Children.Add(newRectangle);
					break;
				case SketchState.Circle:
					newCircle = new Ellipse();
					x1 = e.GetCurrentPoint(this).Position.X;
					y1 = e.GetCurrentPoint(this).Position.Y;
					x2 = x1;
					y2 = y1;
					newCircle.Width = x2 - x1;
					newCircle.Height = y2 - y1;
					newCircle.StrokeThickness = drawThickness;
					newCircle.Stroke = drawBrush;
					newCircle.Opacity = drawOpacity;
					Children.Add(newCircle);
					break;
				case SketchState.Triangle:
					newPath = XamlReader.Load("<Path xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'  Stretch='Fill'  Data='F1 M 9.45441,55.171L 65.837,56.0177L 38.379,6.76554L 9.45441,55.171 Z' />") as Path;
					x1 = e.GetCurrentPoint(this).Position.X;
					y1 = e.GetCurrentPoint(this).Position.Y;
					x2 = x1;
					y2 = y1;
					newPath.Width = x2 - x1;
					newPath.Height = y2 - y1;
					newPath.StrokeThickness = drawThickness;
					newPath.Stroke = drawBrush;
					newPath.Opacity = drawOpacity;
					Children.Add(newPath);
					break;
				case SketchState.Star:
					
					newPath = XamlReader.Load("<Path xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'  Stretch='Fill'  Data='M113,332 L228,332 L268,220 L302,333 L423,334 L326,401 L363,515 L268,440 L173,512 L203,401 z' />") as Path;
					x1 = e.GetCurrentPoint(this).Position.X;
					y1 = e.GetCurrentPoint(this).Position.Y;
					x2 = x1;
					y2 = y1;
					newPath.Width = x2 - x1;
					newPath.Height = y2 - y1;
					newPath.StrokeThickness = drawThickness;
					newPath.Stroke = drawBrush;
					newPath.Opacity = drawOpacity;
					Children.Add(newPath);
					break;


			}


		}
		void Canvas_PointerMoved(object sender, PointerRoutedEventArgs e)
		{
			PointerPoint pt = e.GetCurrentPoint(this);

			_currentPoint = pt.Position;
			x1 = _previousPoint.X;
			y1 = _previousPoint.Y;
			x2 = _currentPoint.X;
			y2 = _currentPoint.Y;

			if (e.Pointer.PointerId == _touchID)
			{
				
				switch (state)
				{
					case SketchState.Draw:
						if (Distance(x1, y1, x2, y2) > 2.0)
						{ 
							Line mainStroke = new Line
							{
								X1 = x1,
								Y1 = y1,
								X2 = x2,
								Y2 = y2,
								StrokeStartLineCap = startPenLineCap,
								StrokeEndLineCap = endPenLineCap,
								StrokeThickness = drawThickness,
								Stroke = drawBrush,
								Opacity = drawOpacity
							};

							_previousPoint = _currentPoint;
							//Draw Child on the canvas
							Children.Add(mainStroke);
							//inkManger.ProcessPointerUpdate(pt);
						}

						break;
					case SketchState.Line:

						straightLine.X2 = e.GetCurrentPoint(this).Position.X;
						straightLine.Y2 = e.GetCurrentPoint(this).Position.Y;
						
						
						break;
					case SketchState.Rectangle:
						        x2 = e.GetCurrentPoint(this).Position.X;
                              y2 = e.GetCurrentPoint(this).Position.Y;
                              if ((x2 - x1) > 0 && (y2 - y1) > 0)
                                  newRectangle.Margin = new Thickness(x1, y1, x2, y2);
                              else if ((x2 - x1) < 0)
								  newRectangle.Margin = new Thickness(x2, y1, x1, y2);
                              else if ((y2 - y1) < 0)
								  newRectangle.Margin = new Thickness(x1, y2, x2, y1);
                              else if ((x2 - x1) < 0 && (y2 - y1) < 0)
								  newRectangle.Margin = new Thickness(x2, y1, x1, y2);
							  newRectangle.Width = Math.Abs(x2 - x1);
							  newRectangle.Height = Math.Abs(y2 - y1);
						break;
					case SketchState.Circle:
							 x2 = e.GetCurrentPoint(this).Position.X;
                              y2 = e.GetCurrentPoint(this).Position.Y;
                              if ((x2 - x1) > 0 && (y2 - y1) > 0)
                                  newCircle.Margin = new Thickness(x1, y1, x2, y2);
                              else if ((x2 - x1) < 0)
								  newCircle.Margin = new Thickness(x2, y1, x1, y2);
                              else if ((y2 - y1) < 0)
								  newCircle.Margin = new Thickness(x1, y2, x2, y1);
                              else if ((x2 - x1) < 0 && (y2 - y1) < 0)
								  newCircle.Margin = new Thickness(x2, y1, x1, y2);
							  newCircle.Width = Math.Abs(x2 - x1);
							  newCircle.Height = Math.Abs(y2 - y1);
						break;
					case SketchState.Triangle:
						x2 = e.GetCurrentPoint(this).Position.X;
						y2 = e.GetCurrentPoint(this).Position.Y;
						if ((x2 - x1) > 0 && (y2 - y1) > 0)
							newPath.Margin = new Thickness(x1, y1, x2, y2);
						else if ((x2 - x1) < 0)
							newPath.Margin = new Thickness(x2, y1, x1, y2);
						else if ((y2 - y1) < 0)
							newPath.Margin = new Thickness(x1, y2, x2, y1);
						else if ((x2 - x1) < 0 && (y2 - y1) < 0)
							newPath.Margin = new Thickness(x2, y1, x1, y2);
						newPath.Width = Math.Abs(x2 - x1);
						newPath.Height = Math.Abs(y2 - y1);
						break;
					case SketchState.Star:
							 x2 = e.GetCurrentPoint(this).Position.X;
                              y2 = e.GetCurrentPoint(this).Position.Y;
                              if ((x2 - x1) > 0 && (y2 - y1) > 0)
                                  newPath.Margin = new Thickness(x1, y1, x2, y2);
                              else if ((x2 - x1) < 0)
								  newPath.Margin = new Thickness(x2, y1, x1, y2);
                              else if ((y2 - y1) < 0)
								  newPath.Margin = new Thickness(x1, y2, x2, y1);
                              else if ((x2 - x1) < 0 && (y2 - y1) < 0)
								  newPath.Margin = new Thickness(x2, y1, x1, y2);
							  newPath.Width = Math.Abs(x2 - x1);
							  newPath.Height = Math.Abs(y2 - y1);
						break;
					case SketchState.Disabled:
						// Do nothing 
						break;
					case SketchState.Erase: //Erase strokes 
						if (Distance(x1, y1, x2, y2) > 2.0)
						{
							Line erase = new Line
							{
								X1 = x1,
								Y1 = y1,
								X2 = x2,
								Y2 = y2,
								StrokeStartLineCap = startPenLineCap,
								StrokeEndLineCap = endPenLineCap,
								StrokeThickness = 15,
								Stroke = Background,
								Opacity = .35
							};
							_previousPoint = _currentPoint;
							//Draw Child on the canvas
							Children.Add(erase);
							//inkManger.ProcessPointerUpdate(pt);
						}
						break;
				}
				

			}
			else if(e.Pointer.PointerId == _penID)
			{
				var pressure = pt.Properties.Pressure;

				switch (state)
				{
					case SketchState.Draw:
						if (Distance(x1, y1, x2, y2) > 2.0)
						{
							Line mainStroke = new Line
							{
								X1 = x1,
								Y1 = y1,
								X2 = x2,
								Y2 = y2,
								StrokeStartLineCap = startPenLineCap,
								StrokeEndLineCap = endPenLineCap,
								StrokeThickness = drawThickness,
								Stroke = drawBrush,
								Opacity = drawOpacity
							};

							_previousPoint = _currentPoint;
							//Draw Child on the canvas
							Children.Add(mainStroke);
							//inkManger.ProcessPointerUpdate(pt);
						}

						break;
					case SketchState.Line:

						straightLine.X2 = e.GetCurrentPoint(this).Position.X;
						straightLine.Y2 = e.GetCurrentPoint(this).Position.Y;


						break;
					case SketchState.Rectangle:
						x2 = e.GetCurrentPoint(this).Position.X;
						y2 = e.GetCurrentPoint(this).Position.Y;
						if ((x2 - x1) > 0 && (y2 - y1) > 0)
							newRectangle.Margin = new Thickness(x1, y1, x2, y2);
						else if ((x2 - x1) < 0)
							newRectangle.Margin = new Thickness(x2, y1, x1, y2);
						else if ((y2 - y1) < 0)
							newRectangle.Margin = new Thickness(x1, y2, x2, y1);
						else if ((x2 - x1) < 0 && (y2 - y1) < 0)
							newRectangle.Margin = new Thickness(x2, y1, x1, y2);
						newRectangle.Width = Math.Abs(x2 - x1);
						newRectangle.Height = Math.Abs(y2 - y1);
						break;
					case SketchState.Circle:
						x2 = e.GetCurrentPoint(this).Position.X;
						y2 = e.GetCurrentPoint(this).Position.Y;
						if ((x2 - x1) > 0 && (y2 - y1) > 0)
							newCircle.Margin = new Thickness(x1, y1, x2, y2);
						else if ((x2 - x1) < 0)
							newCircle.Margin = new Thickness(x2, y1, x1, y2);
						else if ((y2 - y1) < 0)
							newCircle.Margin = new Thickness(x1, y2, x2, y1);
						else if ((x2 - x1) < 0 && (y2 - y1) < 0)
							newCircle.Margin = new Thickness(x2, y1, x1, y2);
						newCircle.Width = Math.Abs(x2 - x1);
						newCircle.Height = Math.Abs(y2 - y1);
						break;
					case SketchState.Triangle:
						x2 = e.GetCurrentPoint(this).Position.X;
						y2 = e.GetCurrentPoint(this).Position.Y;
						if ((x2 - x1) > 0 && (y2 - y1) > 0)
							newPath.Margin = new Thickness(x1, y1, x2, y2);
						else if ((x2 - x1) < 0)
							newPath.Margin = new Thickness(x2, y1, x1, y2);
						else if ((y2 - y1) < 0)
							newPath.Margin = new Thickness(x1, y2, x2, y1);
						else if ((x2 - x1) < 0 && (y2 - y1) < 0)
							newPath.Margin = new Thickness(x2, y1, x1, y2);
						newPath.Width = Math.Abs(x2 - x1);
						newPath.Height = Math.Abs(y2 - y1);
						break;
					case SketchState.Star:
						x2 = e.GetCurrentPoint(this).Position.X;
						y2 = e.GetCurrentPoint(this).Position.Y;
						if ((x2 - x1) > 0 && (y2 - y1) > 0)
							newPath.Margin = new Thickness(x1, y1, x2, y2);
						else if ((x2 - x1) < 0)
							newPath.Margin = new Thickness(x2, y1, x1, y2);
						else if ((y2 - y1) < 0)
							newPath.Margin = new Thickness(x1, y2, x2, y1);
						else if ((x2 - x1) < 0 && (y2 - y1) < 0)
							newPath.Margin = new Thickness(x2, y1, x1, y2);
						newPath.Width = Math.Abs(x2 - x1);
						newPath.Height = Math.Abs(y2 - y1);
						break;
					case SketchState.Disabled:
						// Do nothing 
						break;
					case SketchState.Erase: //Erase strokes 
						if (Distance(x1, y1, x2, y2) > 2.0)
						{
							Line erase = new Line
							{
								X1 = x1,
								Y1 = y1,
								X2 = x2,
								Y2 = y2,
								StrokeStartLineCap = startPenLineCap,
								StrokeEndLineCap = endPenLineCap,
								StrokeThickness = 15,
								Stroke = Background,
								Opacity = .35
							};
							_previousPoint = _currentPoint;
							//Draw Child on the canvas
							Children.Add(erase);
							//inkManger.ProcessPointerUpdate(pt);
						}
						break;
				}
			}
		}
		void Canvas_PointerReleased(object sender, PointerRoutedEventArgs e)
		{
			if (e.Pointer.PointerId == _penID)
			{
				PointerPoint pt = e.GetCurrentPoint(this);
				//inkManger.ProcessPointerUp(pt);
			}
			else if (e.Pointer.PointerId == _touchID)
			{
				PointerPoint pt = e.GetCurrentPoint(this);
				//inkManger.ProcessPointerUp(pt);
			}
			_penID = 0;
			_touchID = 0;


			//mainStroke = null;
			straightLine = null;
			newCircle = null;
			newRectangle = null;
			newPath = null;
			e.Handled = true;
		}

		void Canvas_PointerExited(object sender, PointerRoutedEventArgs e)
		{
		}

		#region Depdencey Properties and Properties

		public static readonly DependencyProperty SketchStateProperty = DependencyProperty.Register("SketchState", typeof(SketchState), typeof(SketchCanvas),
			new PropertyMetadata(null,(sender, e) =>
		{
			SketchCanvas sketch = sender as SketchCanvas;
			sketch.state = (SketchState)e.NewValue;
		}));
		/// <summary>
		/// Gets or Set the State of the DrawCanvas
		/// </summary>
		public SketchState SketchState
		{
			get
			{
				return (SketchState)GetValue(SketchStateProperty);
			}
			set
			{
				SetValue(SketchStateProperty, value);
			}
		}



		public static readonly DependencyProperty DrawBrushProperty = DependencyProperty.Register("DrawBrush", typeof(Brush),
			typeof(SketchCanvas),
			new PropertyMetadata(null, (sender, e) =>
			{
				SketchCanvas sketch = sender as SketchCanvas;
				sketch.drawBrush = (Brush)e.NewValue;
			}));

		public Brush DrawBrush
		{
			get { return (Brush)GetValue(DrawBrushProperty); }
			set { SetValue(DrawBrushProperty, value); }
		}

		public static readonly DependencyProperty DrawThicknessProperty = DependencyProperty.Register("DrawThickness", typeof(double),
			typeof(SketchCanvas),
			new PropertyMetadata(null, (sender, e) =>
			{
				SketchCanvas sketch = sender as SketchCanvas;
				sketch.drawThickness = (double)e.NewValue;
			}));


		public double DrawThickness
		{
			get { return (double)GetValue(DrawThicknessProperty); }
			set { SetValue(DrawThicknessProperty, value); }
		}

		public static readonly DependencyProperty DrawOpacityProperty = DependencyProperty.Register("DrawOpacity", typeof(double),
	typeof(SketchCanvas),
	new PropertyMetadata(null, (sender, e) =>
	{
		SketchCanvas sketch = sender as SketchCanvas;
		sketch.drawOpacity = (double)e.NewValue;




	}));

		public double DrawOpacity
		{
			get { return (double)GetValue(DrawOpacityProperty); }
			set { SetValue(DrawOpacityProperty, value); }
		}



		public static readonly DependencyProperty StartPenLineCapProperty = DependencyProperty.Register("StartPenLineCap",
			typeof(PenLineCap),
			typeof(SketchCanvas),
			new PropertyMetadata(null, (sender, e) =>
			{
				SketchCanvas draw = sender as SketchCanvas;
				draw.startPenLineCap = (PenLineCap)e.NewValue;
			}));


		public PenLineCap StartPenLineCap
		{
			get { return (PenLineCap)GetValue(StartPenLineCapProperty); }
			set { SetValue(StartPenLineCapProperty, value); }
		}


		public static readonly DependencyProperty EndPenLineCapProperty = DependencyProperty.Register("EndPenLineCap",
			typeof(PenLineCap),
			typeof(SketchCanvas),
			new PropertyMetadata(null,(sender, e) =>
			{
				SketchCanvas draw = sender as SketchCanvas;
				draw.endPenLineCap = (PenLineCap)e.NewValue;

			}));

		public PenLineCap EndPenLineCap
		{
			get { return (PenLineCap)GetValue(EndPenLineCapProperty); }
			set { SetValue(EndPenLineCapProperty, value); }
		}


		#endregion


		private double Distance(double x1, double y1, double x2, double y2)
		{
			double d = 0;
			d = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
			return d;
		}
	}

	public enum SketchState
	{
		Draw,Line,Triangle,Rectangle,Circle,Star, Erase, Disabled
	}
}
