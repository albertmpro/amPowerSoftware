using System;
using System.Windows;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;

namespace Albert.Standard.Runtime
{

	/// <summary>
	/// A static class to do quick animations 
	/// </summary>
	public static class QuickAnimation
	{
	
		public static void RunDouble(UIElement _Element,string _ElementProperty, double _From, double _To, Duration _duration)
		{

			
				//Create the double animation 
				DoubleAnimation dbl = new DoubleAnimation { From = _From, To = _To, Duration = _duration };
				//Setup the StoryBoard 
				Storyboard story = new Storyboard();
				//Set the target
				Storyboard.SetTarget(dbl, _Element);
				//Set the Property
				Storyboard.SetTargetProperty(story, _ElementProperty);
				//Setup the Storyboard
				story.Children.Add(dbl);
				//Run the StoryBoard
				story.Begin();
			



		}


	}
}
