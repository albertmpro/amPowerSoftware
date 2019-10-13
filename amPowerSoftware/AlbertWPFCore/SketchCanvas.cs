using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Input;

using System.Windows.Markup;

namespace Albert.Standard.Win32
{
	/// <summary>
	/// A special canvas designed for  Sketching
	/// </summary>
	public class SketchCanvas : Canvas
	{
		#region Private Field's

		//Can Finger Piant 
		bool canFingerPaint;

		//Gets the current state 
		private SketchState state;

		//Free Straight Line  
		private Line mainStroke, straightLine;

		
		//Image used to reander current state of the canvas 
		private Image imgRender = new Image();

		//Start and End of the touch stroke 
		private PenLineCap startPenLineCap, endPenLineCap;

		//FillBrush, DrawBrush,
		private Brush fillBrush, drawBrush;

		// Line Position, DrawThickness, and DrawOpcity 
		double x1, x2, y1, y2, drawThickness, drawOpacity;


		//Get Current Point 
		Point current, previous;

		// Pepresents a Circle 
		private Ellipse newCircle;

		//Represents Rectangle
		private Rectangle newRectangle;

		//Represents Triangle and Star 
		private Path newPath;


		/*
		 * Sets the number of children before the canvas renders a image to
		 * speed up memory 
		 */
		private int numberOfChildrenBeforeRender;

		//Gets the touch points of your fingers 

		double[] preXArray = new double[10];

		double[] preYArray = new double[10];
		//CanFingerPaint Depends 
		public static readonly DependencyProperty CanFingerPaintProperty = DependencyProperty.Register("CanFingerPaint", typeof(bool), typeof(SketchCanvas), new PropertyMetadata((sender, e) =>
		{
			var sketch = sender as SketchCanvas;
			var mybool = (bool)e.NewValue;
			void donothing(object send, TouchFrameEventArgs e1)
			{
				// Do nothing 
			}
			switch(mybool)
			{
				case true:
				
					try
					{
						
					
						// Use Touch Frame Logic 
						Touch.FrameReported += sketch.Touch_Canvas;
					}
					catch
					{

						Touch.FrameReported -= donothing;
						// Use Touch Frame Logic 
						Touch.FrameReported += sketch.Touch_Canvas;
				
					}
				
					break;
				case false:
					 try
					{
					
						//Remove Logic 
						Touch.FrameReported -= sketch.Touch_Canvas;
						//Add the do nothing 
						Touch.FrameReported += donothing;
			

					}
					catch
					{
						//Add the do nothing 
						Touch.FrameReported += donothing;
			
					}
	
					break;
			}

			sketch.canFingerPaint = mybool;
	
	}));
		//Sketch State Depends 
		public static readonly DependencyProperty SketchStateProperty = DependencyProperty.Register("SketchState", typeof(SketchState), typeof(SketchCanvas), new PropertyMetadata((sender, e) =>
		{
			SketchCanvas sketch = sender as SketchCanvas;
			sketch.state = (SketchState)e.NewValue;
		}));

		#endregion

		#region Constructor
		public SketchCanvas()
		{
			//Default PenLineCap for Start and End
			startPenLineCap = PenLineCap.Square;
			endPenLineCap = PenLineCap.Square;

			//Default for the Background
			Background = new SolidColorBrush(Colors.White);

			//Default for the DrawBrush 
			drawBrush = new SolidColorBrush(Colors.Black);

			//Default the Thicnkess 
			drawThickness = 4.9;

			//Default Opacity 
			drawOpacity = .09;// 9%

			//Default SketchState 
			state = SketchState.Draw;

			//Default render Count 
			numberOfChildrenBeforeRender = 1000;

			//OnMouseMove
			//OnMouseDown
			//OnMouseUp

			//Turn Finger Paint on 
			CanFingerPaint = true;

		}
		#endregion

		#region Properties

		public bool CanFingerPaint
		{
			get { return (bool)GetValue(CanFingerPaintProperty); }
			set { SetValue(CanFingerPaintProperty, value); }
		}
		
		/// <summary>
		/// Gets or Set the State of the SketchCanvas
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
			new PropertyMetadata((sender, e) =>
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
			new PropertyMetadata((sender, e) =>
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
	new PropertyMetadata((sender, e) =>
	{
		SketchCanvas sketch = sender as SketchCanvas;
		sketch.drawOpacity = (double)e.NewValue;




	}));

		public double DrawOpacity
		{
			get { return (double)GetValue(DrawOpacityProperty); }
			set { SetValue(DrawOpacityProperty, value); }
		}
		public static readonly DependencyProperty FillBrushProperty = DependencyProperty.Register("FillBrush", typeof(Brush), typeof(SketchCanvas),
				new PropertyMetadata((sender, e) =>
					{
						SketchCanvas draw = (SketchCanvas)sender;
						draw.fillBrush = (Brush)e.NewValue;
					}));



		public Brush FillBrush
		{
			get { return (Brush)GetValue(FillBrushProperty); }
			set { SetValue(FillBrushProperty, value); }
		}


		public static readonly DependencyProperty ItemsToRenderCountProperty = DependencyProperty.Register("ItemsToRenderCount", typeof(int), typeof(SketchCanvas),
				new PropertyMetadata((sender, e) =>
				{
					SketchCanvas draw = (SketchCanvas)sender;
					draw.numberOfChildrenBeforeRender = (int)e.NewValue;

				}));

		public int ItemsToRenderCount
		{
			get { return (int)GetValue(ItemsToRenderCountProperty); }
			set { SetValue(ItemsToRenderCountProperty, value); }
		}


		public static readonly DependencyProperty StartPenLineCapProperty = DependencyProperty.Register("StartPenLineCap",
			typeof(PenLineCap),
			typeof(SketchCanvas),
			new PropertyMetadata((sender, e) =>
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
			new PropertyMetadata((sender, e) =>
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


		#region Touch and Render Evnets

	
		private double Distance(double _x1, double _y1, double _x2, double _y2)
		{
			double d = 0;
			d = Math.Sqrt(Math.Pow((_x2 - _x1), 2) + Math.Pow((_y2 - _y1), 2));
			return d;
		}

		void Mouse_Up(object sender, MouseEventArgs e)
		{
			//Release objects 
			newPath = null;
			straightLine = null;
			mainStroke = null;
			newCircle = null;
			newRectangle = null;
		}

		void Mouse_Down(object sender, MouseEventArgs e)
		{
			var xp = e.GetPosition(this).X;
			var yp = e.GetPosition(this).Y;
			switch(state)
			{
			
				case SketchState.Line: //Draw the line 
					straightLine = new Line();
					straightLine.X1 = xp;
					straightLine.Y1 = yp;
					straightLine.X2 = straightLine.X1 + 1;
					straightLine.Y2 = straightLine.Y1 + 1;
					straightLine.StrokeThickness = drawThickness;
					straightLine.Stroke = drawBrush;
					straightLine.Opacity = drawOpacity;
					Children.Add(straightLine);
					break;
				case SketchState.Rectangle:
					newRectangle = new Rectangle();
					x1 = xp;
					y1 = yp;
					y2 = y1;
					x2 = x1;

					newRectangle.Width = x2 - x1;
					newRectangle.Height = y2 - y1;
					newRectangle.Opacity = drawOpacity;
					newRectangle.StrokeThickness = drawThickness;
					newRectangle.Stroke = drawBrush;
					newRectangle.Fill = fillBrush;
					Children.Add(newRectangle);
					break;
				case SketchState.Circle:
					newCircle = new Ellipse();
					x1 = xp;
					y1 = yp;
					y2 = y1;
					x2 = x1;

					newCircle.Width = x2 - x1;
					newCircle.Height = y2 - y1;
					newCircle.Opacity = drawOpacity;
					newCircle.StrokeThickness = drawThickness;
					newCircle.Stroke = drawBrush;
					newCircle.Fill = fillBrush;
					Children.Add(newCircle);

					break;
				case SketchState.Triangle:
					newPath = XamlReader.Parse("<Path xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'  Stretch='Fill'  Data='M224,54 L125,216 L321,216 z' />") as Path;

					x1 = xp;
					y1 = yp;
					y2 = y1;
					x2 = x1;

					newPath.Width = x2 - x1;
					newPath.Height = y2 - y1;
					newPath.Opacity = drawOpacity;
					newPath.StrokeThickness = drawThickness;
					newPath.Stroke = drawBrush;
					newPath.Fill = fillBrush;
					Children.Add(newPath);
					break;
				case SketchState.Star:
					newPath = XamlReader.Parse("<Path xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'  Stretch='Fill'  Data='M224,54 L125,216 L321,216 z' />") as Path;

					x1 = xp;
					y1 = yp;
					y2 = y1;
					x2 = x1;

					newPath.Width = x2 - x1;
					newPath.Height = y2 - y1;
					newPath.Opacity = drawOpacity;
					newPath.StrokeThickness = drawThickness;
					newPath.Stroke = drawBrush;
					newPath.Fill = fillBrush;
					Children.Add(newPath);
					break;
				
			}
		}

		void Mouse_Move(object sender, MouseEventArgs e)
		{
			var xp = e.GetPosition(this).X;
			var yp = e.GetPosition(this).Y;

			//Ge the current point 
			current = new Point(xp, yp);
			previous = current;
			//x and y 1 = previous point 
			x1 = previous.X;
			y1 = previous.Y;
			//x and y 2 = the current point 
			x2 = current.X;
			y2 = current.Y;


			switch (state)
			{
				case SketchState.Draw:
					if (Distance(x1, x2, y1, y2) > 2.0)
					{
						mainStroke = new Line();


						mainStroke.X1 = x1;
						mainStroke.Y1 = y1;
						mainStroke.X2 = x2;
						mainStroke.Y2 = y2;

						mainStroke.Opacity = drawOpacity;

						mainStroke.StrokeStartLineCap = startPenLineCap;
						mainStroke.StrokeEndLineCap = endPenLineCap;
						mainStroke.Stroke = drawBrush;
						mainStroke.StrokeThickness = drawThickness;

						this.Children.Add(mainStroke);
						//Make the previios pont the current
						previous = current;
					}

					break;
				case SketchState.Erase:
					if (Distance(x1, x2, y1, y2) > 2.0)
					{
						mainStroke = new Line();


						mainStroke.X1 = x1;
						mainStroke.Y1 = y1;
						mainStroke.X2 = x2;
						mainStroke.Y2 = y2;

						mainStroke.Opacity = drawOpacity;

						mainStroke.StrokeStartLineCap = startPenLineCap;
						mainStroke.StrokeEndLineCap = endPenLineCap;
						mainStroke.Stroke = Background;
						mainStroke.StrokeThickness = drawThickness;

						this.Children.Add(mainStroke);
						previous = current;
					}
					break;
				case SketchState.Line:
					straightLine.X2 = xp;
					straightLine.Y2 = yp;
					this.Children.Add(straightLine);
					//UndoObjects.Push(drawStroke);
					previous = current;
					break;
				case SketchState.Rectangle:
					x2 = xp;
					y2 = yp;
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
					x2 = xp;
					y2 = yp;
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
					x2 = xp;
					y2 = yp;
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
					x2 = xp;
					y2 = yp;
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
			}
				
			
		}

		void Mouse_Nothing(object sender, MouseEventArgs e)
		{
			//Do nothing 
		}

		private void Touch_Canvas(object sender, TouchFrameEventArgs e)
		{
			try
			{
				//Get the touch points  
				int pointsNumber = e.GetTouchPoints(this).Count;
				//Create a Collection of the Touch Points 
				TouchPointCollection pointCollection = e.GetTouchPoints(this);
			
		

				for (var i = 0; i < pointsNumber; i++)
				{
					
						switch (pointCollection[i].Action)
						{
							case TouchAction.Up://When you lift your finger up 

								//Release objects 
								newPath = null;
								straightLine = null;
								mainStroke = null;
								newCircle = null;
								newRectangle = null;



								break;
							case TouchAction.Down:// When you put your finger down 
												  //Get's the X Position of your finger
								preXArray[i] = pointCollection[i].Position.X;
								//Get's the Y Position of your finger
								preYArray[i] = pointCollection[i].Position.Y;

								//Each SketchState does something diffrent 
								switch (state)
								{
									case SketchState.Line:
										straightLine = new Line();
										straightLine.X1 = pointCollection[i].Position.X;
										straightLine.Y1 = pointCollection[i].Position.Y;
										straightLine.X2 = straightLine.X1 + 1;
										straightLine.Y2 = straightLine.Y1 + 1;
										straightLine.StrokeThickness = drawThickness;
										straightLine.Stroke = drawBrush;
										straightLine.Opacity = drawOpacity;
										Children.Add(straightLine);

										break;
									case SketchState.Triangle:
										newPath = XamlReader.Parse("<Path xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'  Stretch='Fill'  Data='M224,54 L125,216 L321,216 z' />") as Path;

										x1 = pointCollection[i].Position.X;
										y1 = pointCollection[i].Position.Y;
										y2 = y1;
										x2 = x1;

										newPath.Width = x2 - x1;
										newPath.Height = y2 - y1;
										newPath.Opacity = drawOpacity;
										newPath.StrokeThickness = drawThickness;
										newPath.Stroke = drawBrush;
										newPath.Fill = fillBrush;
										Children.Add(newPath);
										break;
									case SketchState.Star:
										newPath = XamlReader.Parse("<Path xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'  Stretch='Fill'  Data='M113,332 L228,332 L268,220 L302,333 L423,334 L326,401 L363,515 L268,440 L173,512 L203,401 z' />") as Path;

										x1 = pointCollection[i].Position.X;
										y1 = pointCollection[i].Position.Y;
										y2 = y1;
										x2 = x1;

										newPath.Width = x2 - x1;
										newPath.Height = y2 - y1;
										newPath.Opacity = drawOpacity;
										newPath.StrokeThickness = drawThickness;
										newPath.Stroke = drawBrush;
										newPath.Fill = fillBrush;
										Children.Add(newPath);
										break;
									case SketchState.Circle:
										newCircle = new Ellipse();
										x1 = pointCollection[i].Position.X;
										y1 = pointCollection[i].Position.Y;
										y2 = y1;
										x2 = x1;

										newCircle.Width = x2 - x1;
										newCircle.Height = y2 - y1;
										newCircle.Opacity = drawOpacity;
										newCircle.StrokeThickness = drawThickness;
										newCircle.Stroke = drawBrush;
										newCircle.Fill = fillBrush;
										Children.Add(newCircle);

										break;
									case SketchState.Rectangle:
										newRectangle = new Rectangle();
										x1 = pointCollection[i].Position.X;
										y1 = pointCollection[i].Position.Y;
										y2 = y1;
										x2 = x1;

										newRectangle.Width = x2 - x1;
										newRectangle.Height = y2 - y1;
										newRectangle.Opacity = drawOpacity;
										newRectangle.StrokeThickness = drawThickness;
										newRectangle.Stroke = drawBrush;
										newRectangle.Fill = fillBrush;
										Children.Add(newRectangle);
										break;

								}

								break;
							case TouchAction.Move://Accures when you are moving your finger 
												  //Depends on the state  
								switch (state)
								{
									case SketchState.Draw:
										mainStroke = new Line();


										mainStroke.X1 = preXArray[i];
										mainStroke.Y1 = preYArray[i];
										mainStroke.X2 = pointCollection[i].Position.X;
										mainStroke.Y2 = pointCollection[i].Position.Y;

										mainStroke.Opacity = drawOpacity;

										mainStroke.StrokeStartLineCap = startPenLineCap;
										mainStroke.StrokeEndLineCap = endPenLineCap;
										mainStroke.Stroke = drawBrush;
										mainStroke.StrokeThickness = drawThickness;

										this.Children.Add(mainStroke);


										preXArray[i] = pointCollection[i].Position.X;
										preYArray[i] = pointCollection[i].Position.Y;
										break;
									case SketchState.Erase:
										mainStroke = new Line();


										mainStroke.X1 = preXArray[i];
										mainStroke.Y1 = preYArray[i];
										mainStroke.X2 = pointCollection[i].Position.X;
										mainStroke.Y2 = pointCollection[i].Position.Y;

										mainStroke.Opacity = .25;
										//mainStroke.OpacityMask = drawOpacityMask;
										mainStroke.StrokeStartLineCap = PenLineCap.Round;
										mainStroke.StrokeEndLineCap = PenLineCap.Round;
										mainStroke.Stroke = Background;
										mainStroke.StrokeThickness = 35;

										this.Children.Add(mainStroke);
										//UndoObjects.Push(drawStroke);

										preXArray[i] = pointCollection[i].Position.X;
										preYArray[i] = pointCollection[i].Position.Y;
										break;

									case SketchState.Triangle:
										x2 = pointCollection[i].Position.X;
										y2 = pointCollection[i].Position.Y;
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
										x2 = pointCollection[i].Position.X;
										y2 = pointCollection[i].Position.Y;
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
									case SketchState.Line:

										straightLine.X2 = pointCollection[i].Position.X;
										straightLine.Y2 = pointCollection[i].Position.Y;
										this.Children.Add(straightLine);
										//UndoObjects.Push(drawStroke);

										preXArray[i] = pointCollection[i].Position.X;
										preYArray[i] = pointCollection[i].Position.Y;
										break;
									case SketchState.Rectangle:
										x2 = pointCollection[i].Position.X;
										y2 = pointCollection[i].Position.Y;
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
										x2 = pointCollection[i].Position.X;
										y2 = pointCollection[i].Position.Y;
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
								}





								break;

						}
					




				}


			}
			catch
			{

			}
		}


	
		#endregion







	}

	public enum SketchState
	{
		Draw, Erase, Line, Disabled, Rectangle, Circle, Triangle, Star
	}
}
