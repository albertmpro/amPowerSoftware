using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using System.Xml.Linq;
namespace Albert.Standard
{
	/// <summary>
	/// Static Class for doing basic graphic design core math 
	/// </summary>
	public static class Core
	{

		/// <summary>
		/// Return's a Inch Value from a pixel 
		/// </summary>
		/// <param name="_pixel">Pixel</param>
		/// <param name="_ppi">Pixel per inch</param>
		/// <param name="_round">Round off number</param>
		/// <returns></returns>
		public static double PixelToInch(double _pixel, double _ppi, int _round)
		{
			var math = _pixel / _ppi;
			return Round(math, _round);
		}


		public static double ConvertInchToFeet(double inches)
		{
			var cal = inches / 12; // Do the math
			var rt = Round(cal, 1);// Round to 1
			return rt;// Return the value;
		}
		public static double ConvertFeetToInch(double ft)
		{
			var cal = ft * 12;// Do the math 
			var rt = Round(cal, 1);// Round to 1
			return rt;// Return the value
		}
		public static double ConvertInchToYard(double inches)
		{
			var cal = inches / 36; // Do the math
			var rt = Round(cal, 1);// Round to 1
			return rt;// Return the value;
		}

		public static double ConvertYardToInch(double yard)
		{
			var cal = yard * 36;// Do the math 
			var rt = Round(cal, 1);// Round to 1
			return rt;// Return the value
		}

		public static double ConvertFeetToYard(double ft)
		{
			var cal = ft / 3; // Do the math
			var rt = Round(cal, 1);// Round to 1
			return rt;// Return the value;
		}
		public static double ConvertYardToFeet(double yard)
		{
			var cal = yard * 3;// Do the math 
			var rt = Round(cal, 1);// Round to 1
			return rt;// Return the value
		}
		/// <summary>
		/// Find out what happens when you add tax 
		/// </summary>
		/// <param name="dollorvalue">Dollar Amount</param>
		/// <param name="percent">Percent(You do not need to use a decimal)</param>
		/// <returns></returns>
		public static double PlusTax(double dollorvalue, double percent)
		{
			var pc = percent * .01;//Convert Percent  
			var tv = dollorvalue * pc; // Get the tax value
			var cal = dollorvalue + tv;// Add the tax value to the dollar amount
			var rt = Math.Round(cal, 2); // Round to 2
			return rt; // Return the value 
		}

		public static double PercentOfNumber(double number, double percent)
		{
			var pc = percent * .01;//Convert Percent 
			var cal = number * pc;
			var rt = Round(cal, 1); //Convert to have 1 decimal point; 
			return rt; //Return the value; 
		}
		public static double ConvertFeetToMile(double ft)
		{
			var cal = ft / 5280; // Do the math
			var rt = Math.Round(cal, 1);// Round to 1
			return rt;// Return the value;
		}
		public static double ConvertMileToFeet(double mi)
		{
			var cal = mi * 5280;// Do the math 
			var rt = Round(cal, 1);// Round to 1
			return rt;// Return the value
		}

		public static double ConvertYardToMile(double yard)
		{
			var cal = yard / 1760; // Do the math
			var rt = Round(cal, 1);// Round to 1
			return rt;// Return the value;
		}
		public static double ConvertMileToYard(double mi)
		{
			var cal = mi * 1760;// Do the math 
			var rt = Round(cal, 1);// Round to 1
			return rt;// Return the value
		}

		public static double ConvertInchToMetter(double inches)
		{
			var cal = inches / 39; // Do the math
			var rt = Round(cal, 1);// Round to 1
			return rt;// Return the value;
		}
		public static double ConvertMetterToInch(double m)
		{
			var cal = m * 39;// Do the math 
			var rt = Math.Round(cal, 1);// Round to 1
			return rt;// Return the value
		}

		public static double ConvertMileToKilometer(double mi)
		{
			var cal = mi / 0.6; // Do the math
			var rt = Round(cal, 1);// Round to 1
			return rt;// Return the value;
		}
		public static double ConvertKilometerToMile(double km)
		{
			var cal = km * 0.6;// Do the math 
			var rt = Round(cal, 1);// Round to 1
			return rt;// Return the value
		}

		public static double PoundToKilogram(double lbs)
		{
			var cal = lbs * .45;// do the math 
			var rt = Round(cal, 1); // Round to 1
			return rt;
		}

		public static double KilogramToPound(double kg)
		{
			var cal = kg / .45;// do the math 
			var rt = Round(cal, 1); // Round to 1
			return rt;
		}

		public static double ConvertToDouble(string _value)
		{
			try
			{
				var rt = Convert.ToDouble(_value); //Try to convert the string value 
				return rt;
			}
			catch
			{
				return -1;
			}
		}
		public static int ConvertToInt32(string _value)
		{
			try
			{
				var rt = Convert.ToInt32(_value); //Try to convert the string value 
				return rt;
			}
			catch
			{
				return -1;
			}
		}


		public static byte ConvertToByte(string _value)
		{
			try
			{
				var rt = Convert.ToByte(_value); //Try to convert the string value 
				return rt;
			}
			catch
			{
				return 0;
			}
		}


		public static string ConvertAlphaToHtml(string _str)
		{
			var rv = _str.Replace("#FF","#");
			//Return the Value 
			return rv;
		}
		/// <summary>
		/// Convert String to Enum Type  
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="strvalue"></param>
		/// <returns></returns>
		public static T ConvertEnum<T>(string strvalue)
		{
			//Return the enum type 
			return (T)Enum.Parse(typeof(T), strvalue, true);
		}





	}
}
