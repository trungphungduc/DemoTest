/*
=========================================================================================================
  Module      : Pagination(Pagination.cs)
 ･･･････････････････････････････････････････････････････････････････････････････････････････････････････
  Copyright   : Copyright CP Co.,Ltd 2017 All Rights Reserved.
=========================================================================================================
*/

namespace Cp.Common.Util
{
	/// <summary>
	/// Pagination
	/// </summary>
	public class Pagination
	{
		/// <summary>
		/// Get Grid Text Display
		/// </summary>
		/// <param name="totalRows">Total rows</param>
		/// <param name="minRowNumber">Min row number</param>
		/// <param name="maxRowNumber">Max row number</param>
		/// <returns>Text row number in total</returns>
		public static string GetGridTextDisplay(int totalRows, int minRowNumber, int maxRowNumber)
		{
			return string.Format("Hiển thị dòng {0} - {1}/ {2} dòng", minRowNumber, maxRowNumber, totalRows);
		}
	}
}
