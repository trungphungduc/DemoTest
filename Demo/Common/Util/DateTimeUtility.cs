/*
=========================================================================================================
  Module      : Datetime utility(DateTimeUtility.cs)
 ･･･････････････････････････････････････････････････････････････････････････････････････････････････････
  Copyright   : Copyright CP Co.,Ltd 2017 All Rights Reserved.
=========================================================================================================
*/
using System;
using System.Globalization;

namespace Cp.Common.Util
{
	public class DateTimeUtility
	{
		/// <summary>
		/// Check is date
		/// </summary>
		/// <param name="objValue">Object value</param>
		/// <returns>True: Is date, False: Is not date</returns>
		public static bool IsDate(object objValue)
		{
			DateTime dateOutput;

			return DateTime.TryParseExact(
				StringUtility.ToEmpty(objValue),
				Constants.DEFAULT_DATE_FORMAT,
				CultureInfo.InvariantCulture,
				DateTimeStyles.None, out dateOutput);
		}

		/// <summary>
		/// To date
		/// </summary>
		/// <param name="objValue">Object value</param>
		/// <returns>Datetime with default format</returns>
		public static DateTime ToDate(object objValue)
		{
			DateTime dateOutput;

			DateTime.TryParseExact(
				StringUtility.ToEmpty(objValue),
				Constants.DEFAULT_DATE_FORMAT,
				CultureInfo.InvariantCulture,
				DateTimeStyles.None, out dateOutput);

			return dateOutput;
		}
	}
}