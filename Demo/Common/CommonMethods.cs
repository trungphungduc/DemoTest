using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using Cp.Common.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Cp.Common
{
	public class CommonMethods
	{
		public static int ConvertToInt32(object number)
		{
			try
			{
				return Convert.ToInt32(number);
			}
			catch
			{
				return 0;
			}
		}

		public static long ConvertToInt64(object number)
		{
			try
			{
				return Convert.ToInt64(number);
			}
			catch
			{
				return 0;
			}
		}

		public static decimal ConvertToDecimal(object number)
		{
			try
			{
				return Convert.ToDecimal(number);
			}
			catch
			{
				return 0;
			}
		}

		public static double ConvertToDouble(object number)
		{
			try
			{
				return Convert.ToDouble(number);
			}
			catch
			{
				return 0;
			}
		}

		public static string ConvertToString(object value)
		{
			try
			{
				return Convert.ToString(value);
			}
			catch
			{
				return string.Empty;
			}
		}

		public static DateTime ConvertToDateTime(string value)
		{
			return ConvertToDateTime(value, Constants.DEFAULT_DATE_FORMAT);
		}

		public static DateTime ConvertToDateTime(string value, string format)
		{
			try
			{
				return DateTime.ParseExact(value, format, null);
			}
			catch
			{
				return DateTime.MinValue;
			}
		}

		public static DateTime? TryParseDateTime(string value)
		{
			DateTime date;
			return DateTime.TryParse(value, out date) ? date : (DateTime?)null;
		}

		public static DateTime ToDateTime(object value)
		{
			try
			{
				return Convert.ToDateTime(value);
			}
			catch
			{
				return DateTime.MinValue;
			}
		}

		public static bool ConvertToBoolean(object value)
		{
			try
			{
				return Convert.ToBoolean(value);
			}
			catch
			{
				return false;
			}
		}

		public static string FormatDateTime(DateTime value)
		{
			return FormatDateTime(value, Constants.DEFAULT_DATE_FORMAT);
		}

		public static string FormatDateTime(DateTime value, string format)
		{
			try
			{
				return value.ToString(format);
			}
			catch
			{
				return "";
			}
		}

	}
}