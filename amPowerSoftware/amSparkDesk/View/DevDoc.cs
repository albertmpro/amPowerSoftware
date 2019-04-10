using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Albert.Standard.Win32;
namespace amSparkDesk.View
{
	/// <summary>
	/// A special Document Control that interacts with eht Spark ViewModel
	/// </summary>
	public class DevDoc : DocumentControl
	{
		//Feild's 
		//Default ViewModel
		SparkViewModel vm = (SparkViewModel)App.Current.Resources["viewModel"];
		//Column Definitions 
		ColumnDefinition c1, c2, c3, c4, c5;
		//Grid Splitters 
		GridSplitter split1, split2;
		/// <summary>
		/// Default Constructor 
		/// </summary>
		public DevDoc()
		{
			//Column for the FIrst objsect 
			c1 = new ColumnDefinition();
			//Column for the GridSPitter 
			c2 = new ColumnDefinition { MinWidth = 10, MaxWidth = 10 };
			//Column for the second object 
			c3 = new ColumnDefinition();
			//Column for the Second Grid Splitter 
			c4 = new ColumnDefinition { MinWidth = 10, MaxWidth = 10 };
			//Column for the Third object 
			c5 = new ColumnDefinition();
			//Grid Splitter 1 
			split1 = new GridSplitter();
			//Grid Splitter 2 
			split2 = new GridSplitter();
		}

		/// <summary>
		/// Single Grid for one object
		/// </summary>
		/// <param name="_grid"></param>
		/// <param name="_obj"></param>
		public void SingleGrid(Grid _grid, UIElement _obj)
		{
			void work(Grid _g, UIElement _o)
			{
				//Clear up the Columns 
				_g.ColumnDefinitions.Clear();
				_g.Children.Clear();
				_g.Children.Add(_o);
			}
			if (_grid != null)
			{
				//Do the work 
				work(_grid, _obj);
			}
			else if (_grid == null)
			{
				
				_grid = new Grid();
				//Do the work
				work(_grid, _obj);
			}
		}
		/// <summary>
		/// DoubleSplit Grid for working with 2 Objects  
		/// </summary>
		/// <param name="_grid"></param>
		/// <param name="_first"></param>
		/// <param name="_second"></param>
		public void DoubleSplitGrid(Grid _grid, UIElement _first, UIElement _second)
		{
			void work(Grid _g, UIElement _f, UIElement _s)
			{
				//Create the Columns 
				_g.ColumnDefinitions.Clear();
				_g.ColumnDefinitions.Add(c1);
				_g.ColumnDefinitions.Add(c2);
				_g.ColumnDefinitions.Add(c3);
				//Add the Objects
				_g.Children.Clear();
				_g.Children.Add(_f);
				_g.Children.Add(split1);
				_g.Children.Add(_s);
				
			}

			if(_grid !=null)
			{
				work(_grid,_first,_second);
			}
			else if (_grid == null)
			{
				_grid = new Grid();
				
				work(_grid, _first, _second);

			}
		}
		/// <summary>
		/// Triple Split Grid for working with 3 objects
		/// </summary>
		/// <param name="_grid"></param>
		/// <param name="_first"></param>
		/// <param name="_second"></param>
		/// <param name="_third"></param>
		public void TripleSplitGrid(Grid _grid, UIElement _first, UIElement _second, UIElement _third) 
		{
				void work(Grid _g, UIElement _f, UIElement _s, UIElement _t)
				{
					//Create the Columns 
					_g.ColumnDefinitions.Clear();
					_g.ColumnDefinitions.Add(c1);
					_g.ColumnDefinitions.Add(c2);
					_g.ColumnDefinitions.Add(c3);
					_g.ColumnDefinitions.Add(c4);
					_g.ColumnDefinitions.Add(c5);

					//Add the Objects
					_g.Children.Clear();
					_g.Children.Add(_f);
					_g.Children.Add(split1);
					_g.Children.Add(_s);
					_g.Children.Add(split2);
					_g.Children.Add(_t);
				}

				if (_grid != null)
				{
					work(_grid, _first, _second,_third);
				}
				else if (_grid == null)
				{
					_grid = new Grid();

					work(_grid, _first, _second,_third);

				}

			}

		public SparkViewModel ViewModel
		{
			get { return vm; }
		}



	}
}
