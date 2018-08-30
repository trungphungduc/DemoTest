using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cp.Common.Util
{
	/// <summary>
	/// StringUtility class
	/// </summary>
	public class StringUtility
	{
		/// <summary>
		/// To the empty.
		/// </summary>
		/// <param name="objSrc">The object source.</param>
		/// <returns></returns>
		public static string ToEmpty(object objSrc)
		{
			if ((objSrc == null) || (objSrc == DBNull.Value))
			{
				return "";
			}

			return objSrc.ToString();
		}

		/// <summary>
		/// To the value.
		/// </summary>
		/// <param name="objSrc">The object source.</param>
		/// <param name="objNullValue">The object null value.</param>
		/// <returns></returns>
		public static object ToValue(object objSrc, object objNullValue)
		{
			if ((objSrc == null) || (objSrc == DBNull.Value))
			{
				return objNullValue;
			}

			return objSrc;
		}

		/// <summary>
		/// To the null.
		/// </summary>
		/// <param name="objSrc">The object source.</param>
		/// <returns></returns>
		public static string ToNull(object objSrc)
		{
			return (ToEmpty(objSrc) == "") ? null : ToEmpty(objSrc);
		}

		/// <summary>
		/// To the date string.
		/// </summary>
		/// <param name="objSrc">The object source.</param>
		/// <returns>Date string with default format</returns>
		public static string ToDateString(object objSrc)
		{
            return ToDateString(objSrc, Constants.DEFAULT_DATE_FORMAT, "");
		}

		/// <summary>
		/// To the date string.
		/// </summary>
		/// <param name="objSrc">The object source.</param>
		/// <param name="strDateFormat">The string date format.</param>
		/// <returns></returns>
		public static string ToDateString(object objSrc, string strDateFormat)
		{
			return ToDateString(objSrc, strDateFormat, "");
		}

		/// <summary>
		/// To the date string.
		/// </summary>
		/// <param name="objSrc">The object source.</param>
		/// <param name="strDateFormat">The string date format.</param>
		/// <param name="strDefault">The string default.</param>
		/// <returns></returns>
		public static string ToDateString(object objSrc, string strDateFormat, string strDefault)
		{
			if ((objSrc != DBNull.Value)
				&& (objSrc is DateTime))
			{
				return ((DateTime)objSrc).ToString(strDateFormat);
			}
			else if (objSrc is string)
			{
				DateTime dtTemp;
				if (DateTime.TryParse((string)objSrc, out dtTemp))
				{
					return dtTemp.ToString(strDateFormat);
				}
			}

			return strDefault;
		}

		/// <summary>
		/// To the numeric.
		/// </summary>
		/// <param name="objSrc">The object source.</param>
		/// <returns></returns>
		public static string ToNumeric(object objSrc)
		{
			string strSrc = ToEmpty(objSrc);
	
			decimal dSrc;
			if (decimal.TryParse(strSrc, out dSrc))
			{
				if (strSrc.IndexOf('.') != -1)
				{
					long lSrc = (long)dSrc;

					return string.Format("{0:#,##0}", lSrc) + (dSrc - lSrc).ToString().Substring(1);
				}
				else
				{
					return string.Format("{0:#,##0}", dSrc);
				}
			}

			return "";
		}

		/// <summary>
		/// To the zero numeric.
		/// </summary>
		/// <param name="objSrc">The object source.</param>
		/// <param name="ilength">The ilength.</param>
		/// <returns></returns>
		public static string ToZeroNumeric(object objSrc, int ilength)
		{
			decimal dSrc;
			if (decimal.TryParse(ToEmpty(objSrc), out dSrc))
			{
				return String.Format("{0:D" + ilength + "}", dSrc);
			}

			return "";
		}

		/// <summary>
		/// To the price.
		/// </summary>
		/// <param name="objSrc">The object source.</param>
		/// <returns></returns>
		public static string ToPrice(object objSrc)
		{
			decimal dSrc;
			if (decimal.TryParse(ToEmpty(objSrc), out dSrc))
			{
				return string.Format("{0:c}", dSrc);
			}

			return "";
		}

		/// <summary>
		/// Strings the trim.
		/// </summary>
		/// <param name="src">The source.</param>
		/// <param name="length">The length.</param>
		/// <returns></returns>
		public static string StrTrim(object src, int length)
		{
			return StrTrim(src, length, "");
		}

		/// <summary>
		/// Strings the trim.
		/// </summary>
		/// <param name="src">The source.</param>
		/// <param name="length">The length.</param>
		/// <param name="replaceString">The replace string.</param>
		/// <returns></returns>
		public static string StrTrim(object src, int length, string replaceString)
		{
			string srcString = ToEmpty(src);
			if (srcString.Length <= length) return srcString;

			var info = new System.Globalization.StringInfo(srcString);
			if (info.LengthInTextElements > length)
			{
				srcString = info.SubstringByTextElements(0, length) + replaceString;
			}
			return srcString;
		}

		/// <summary>
		/// Changes to aster.
		/// </summary>
		/// <param name="objSrc">The object source.</param>
		/// <returns></returns>
		public static string ChangeToAster(string objSrc)
		{
			StringBuilder sbResult = new StringBuilder();
			for (int iLoop = 0; iLoop < objSrc.Length; iLoop++)
			{
				sbResult.Append("*");
			}

			return sbResult.ToString();
		}

		/// <summary>
		/// Changes to br tag.
		/// </summary>
		/// <param name="objSrc">The object source.</param>
		/// <returns></returns>
		public static string ChangeToBrTag(string objSrc)
		{
			if (objSrc != null)
			{
				return objSrc.Replace("\r\n", "<br />").Replace("\r", "<br />").Replace("\n", "<br />");
			}

			return "";
		}

		/// <summary>
		/// Converts the back slash to slash.
		/// </summary>
		/// <param name="targetString">The target string.</param>
		/// <returns></returns>
		public static string ConvertBackSlashToSlash(string targetString)
		{
			return (targetString != null) ? targetString.Replace(@"\", "/") : "";
		}

		/// <summary>
		/// Converts the slach to back slash.
		/// </summary>
		/// <param name="targetString">The target string.</param>
		/// <returns></returns>
		public static string ConvertSlachToBackSlash(string targetString)
		{
			return (targetString != null) ? targetString.Replace("/", @"\") : "";
		}

		/// <summary>
		/// Escapes the CSV column.
		/// </summary>
		/// <param name="objSrc">The object source.</param>
		/// <param name="newLineReplaceString">The new line replace string.</param>
		/// <returns></returns>
		public static string EscapeCsvColumn(string objSrc, string newLineReplaceString = "\n")
		{
			if (objSrc != null)
			{
				return objSrc.Replace("\r\n", newLineReplaceString).Replace("\r", newLineReplaceString).Replace("\"", "\"\"");
			}

			return "";
		}

		/// <summary>
		/// Creates the escaped CSV string.
		/// </summary>
		/// <param name="strings">The strings.</param>
		/// <returns></returns>
		public static string CreateEscapedCsvString(IEnumerable<string> strings)
		{
			var result = string.Join(",",
				strings.Select(s => string.Format("\"{0}\"", EscapeCsvColumn(s))));
			return result;
		}

		/// <summary>
		/// Gets the splited value.
		/// </summary>
		/// <param name="objSrc">The object source.</param>
		/// <param name="chSeparator">The ch separator.</param>
		/// <param name="iIndex">Index of the i.</param>
		/// <returns></returns>
		public static string GetSplitedValue(object objSrc, char chSeparator, int iIndex)
		{
			string[] strSepareted = (ToEmpty(objSrc)).Split(chSeparator);
			if (iIndex < strSepareted.Length)
			{
				return strSepareted[iIndex];
			}

			return "";
		}

		/// <summary>
		/// Splits the CSV line.
		/// </summary>
		/// <param name="strCsvLine">The string CSV line.</param>
		/// <returns></returns>
		public static string[] SplitCsvLine(string strCsvLine)
		{
			string[] strResults = null;

			string strParrtern1 = "(\"(?:[^\"]|\"\")*\"|[^,]*),";

			string strParrtern2 = "^\"|\",$|,$";

			Regex regx = new Regex(strParrtern1);
			MatchCollection match = regx.Matches(strCsvLine + ",");

			strResults = new string[match.Count];
			for (int iLoop = 0; iLoop < match.Count; iLoop++)
			{
				Regex regx2 = new Regex(strParrtern2);
				strResults[iLoop] = regx2.Replace(match[iLoop].Value, "").Replace("\"\"", "\"");
			}

			return strResults;
		}

		/// <summary>
		/// SQLs the like string sharp escape.
		/// </summary>
		/// <param name="objSrc">The object source.</param>
		/// <returns></returns>
		public static string SqlLikeStringSharpEscape(object objSrc)
		{
			return ToEmpty(objSrc)
				.Replace("#", "##")
				.Replace("%", "#%")
				.Replace("_", "#_")
				.Replace("[", "#[");
		}

		/// <summary>
		/// Adds the header footer.
		/// </summary>
		/// <param name="strHeader">The string header.</param>
		/// <param name="ojbSrc">The ojb source.</param>
		/// <param name="strFooter">The string footer.</param>
		/// <returns></returns>
		public static string AddHeaderFooter(string strHeader, object ojbSrc, string strFooter)
		{
			if (ToEmpty(ojbSrc) != "")
			{
				return strHeader + ojbSrc + strFooter;
			}

			return "";
		}

		/// <summary>
		/// Gets the code.
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		/// <returns></returns>
		public static Encoding GetCode(byte[] bytes)
		{
			if (bytes.Length >= 4 &&
				(bytes[0] == 0xFF && bytes[1] == 0xFE && bytes[2] == 0x00 && bytes[3] == 0x00))
			{
				return Encoding.GetEncoding(12000); // UTF-32
			}
			if (bytes.Length >= 4 &&
				(bytes[0] == 0x00 && bytes[1] == 0x00 && bytes[2] == 0xFE && bytes[3] == 0xFF))
			{
				return Encoding.GetEncoding(12001); // UTF-32 Big Endian
			}
			if (bytes.Length >= 2 && (bytes[0] == 0xFF && bytes[1] == 0xFE))
			{
				return Encoding.GetEncoding(1200);  // UTF-16
			}
			if (bytes.Length >= 2 && (bytes[0] == 0xFE && bytes[1] == 0xFF))
			{
				return Encoding.GetEncoding(1201);  // UTF-16 Big Endian
			}
			if (IsJis(bytes) == true)
			{
				return Encoding.GetEncoding(50220);
			}
			if (IsAscii(bytes) == true)
			{
				return Encoding.GetEncoding(20127); // US-ASCII
			}
			int utf8 = 0, sjis = 0, euc = 0;
			bool bomFrag = false;
			bool Utf8Flag = IsUTF8(bytes, ref utf8, ref bomFrag);
			bool SJisFlag = IsShiftJis(bytes, ref sjis);
			bool EucFlag = IsEUC(bytes, ref euc);
			if (Utf8Flag == true && SJisFlag == false && EucFlag == false)
			{
				if (bomFrag == true)
				{
					return new UTF8Encoding(true);		// UTF-8
				}
				else
				{
					return new UTF8Encoding(false);		// UTF-8N
				}
			}
			else if (SJisFlag == true && Utf8Flag == false && EucFlag == false)
			{
				return Encoding.GetEncoding(932);
			}
			else if (EucFlag == true && Utf8Flag == false && SJisFlag == false)
			{
				return Encoding.GetEncoding(51932);
			}
			else
			{
				if (euc > sjis && euc > utf8)
				{
					return Encoding.GetEncoding(51932);
				}
				if (sjis > euc && sjis > utf8)
				{
				}
				else if (utf8 > euc && utf8 > sjis)
				{
					if (bomFrag == true)
					{
						return new UTF8Encoding(true);
					}
					else
					{
						return new UTF8Encoding(false);
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Determines whether the specified bytes is jis.
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		/// <returns></returns>
		private static bool IsJis(byte[] bytes)
		{
			int length = bytes.Length;
			byte[] temp = new byte[6];
			for (int i = 0; i < length; i++)
			{
				temp[0] = bytes[i];
				if (temp[0] > 0x7F)
				{
					return false;   // Not ISO-2022-JP (0x00～0x7F)
				}
				else if (i < length - 2)
				{
					temp[1] = bytes[i + 1];
					temp[2] = bytes[i + 2];
					if (temp[0] == 0x1B && temp[1] == 0x28 && temp[2] == 0x42)
					{
						return true;    // ESC ( B  : JIS ASCII
					}
					else if (temp[0] == 0x1B && temp[1] == 0x28 && temp[2] == 0x4A)
					{
						return true;    // ESC ( J  : JIS X 0201-1976 Roman Set
					}
					else if (temp[0] == 0x1B && temp[1] == 0x28 && temp[2] == 0x49)
					{
						return true;    // ESC ( I  : JIS X 0201-1976 kana
					}
					else if (temp[0] == 0x1B && temp[1] == 0x24 && temp[2] == 0x40)
					{
						return true;    // ESC $ @  : JIS X 0208-1978(old_JIS)
					}
					else if (temp[0] == 0x1B && temp[1] == 0x24 && temp[2] == 0x42)
					{
						return true;    // ESC $ B  : JIS X 0208-1983(new_JIS)
					}
				}
				else if (i < length - 3)
				{
					temp[1] = bytes[i + 1];
					temp[2] = bytes[i + 2];
					temp[3] = bytes[i + 3];
					if (temp[0] == 0x1B && temp[1] == 0x24 && temp[2] == 0x28 && temp[3] == 0x44)
					{
						return true;    // ESC $ ( D  : JIS X 0212-1990（JIS_hojo_kanji）
					}
				}
				else if (i < length - 5)
				{
					temp[1] = bytes[i + 1];
					temp[2] = bytes[i + 2];
					temp[3] = bytes[i + 3];
					temp[4] = bytes[i + 4];
					temp[5] = bytes[i + 5];
					if (temp[0] == 0x1B && temp[1] == 0x26 && temp[2] == 0x40 &&
						temp[3] == 0x1B && temp[4] == 0x24 && temp[5] == 0x42)
					{
						return true;    // ESC & @ ESC $ B  : JIS X 0208-1990, JIS X 0208:1997
					}
				}
				else
				{
					continue;
				}
			}
			return false;
		}

		/// <summary>
		/// Determines whether the specified bytes is ASCII.
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		/// <returns></returns>
		private static bool IsAscii(byte[] bytes)      // Check for Ascii
		{
			foreach (byte bt in bytes)
			{
				if (bt <= 0x7F)
				{
					// ASCII : 0x00～0x7F
					continue;
				}
				else
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Determines whether [is shift jis] [the specified bytes].
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		/// <param name="sjis">The sjis.</param>
		/// <returns></returns>
		private static bool IsShiftJis(byte[] bytes, ref int sjis)
		{
			int length = bytes.Length;
			byte[] temp = new byte[2];
			for (int i = 0; i < length; i++)
			{
				temp[0] = bytes[i];
				if (temp[0] >= 0x00 && temp[0] <= 0x7F)
				{
					// ASCII : 0x00～0x7F
					continue;
				}
				if (temp[0] >= 0xA1 && temp[0] <= 0xDF)
				{
					// kana  : 0xA1～0xDF
					continue;
				}
				if (i < length - 1)
				{
					temp[1] = bytes[i + 1];
					if (((temp[0] >= 0x81 && temp[0] <= 0x9F) || (temp[0] >= 0xE0 && temp[0] <= 0xFC)) &&
						((temp[1] >= 0x40 && temp[1] <= 0x7E) || (temp[1] >= 0x80 && temp[1] <= 0xFC)))
					{
						// kanji first byte  : 0x81～0x9F or 0xE0～0xFC
						//       second byte : 0x40～0x7E or 0x80～0xFC
						i += 1;
						sjis += 2;
						continue;
					}
				}
				return false;
			}
			return true;
		}

		/// <summary>
		/// Determines whether the specified bytes is euc.
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		/// <param name="euc">The euc.</param>
		/// <returns></returns>
		private static bool IsEUC(byte[] bytes, ref int euc)
		{
			int length = bytes.Length;
			byte[] temp = new byte[3];
			for (int i = 0; i < length; i++)
			{
				temp[0] = bytes[i];
				if (temp[0] >= 0x00 && temp[0] <= 0x7F)
				{
					// ASCII : 0x00～0x7F
					continue;
				}
				if (i < length - 1)
				{
					temp[1] = bytes[i + 1];
					if ((temp[0] >= 0xA1 && temp[0] <= 0xFE) &&
						(temp[1] >= 0xA1 && temp[1] <= 0xFE))
					{
						// kanji - 0xA1～0xFE, 0xA1～0xFE
						i += 1;
						euc += 2;
						continue;
					}
					if ((temp[0] == 0x8E) &&
						(temp[1] >= 0xA1 && temp[1] <= 0xDF))
					{
						// kana - 0x8E, 0xA1～0xDF
						i += 1;
						euc += 2;
						continue;
					}
				}
				if (i < length - 2)
				{
					temp[1] = bytes[i + 1];
					temp[2] = bytes[i + 2];
					if ((temp[0] == 0x8F) &&
						(temp[1] >= 0xA1 && temp[1] <= 0xFE) &&
						(temp[2] >= 0xA1 && temp[2] <= 0xFE))
					{
						// hojo kanji - 0x8F, 0xA1～0xFE, 0xA1～0xFE
						i += 2;
						euc += 3;
						continue;
					}
				}
				return false;
			}
			return true;
		}

		/// <summary>
		/// Determines whether [is ut f8] [the specified bytes].
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		/// <param name="utf8">The UTF8.</param>
		/// <param name="bomFlg">if set to <c>true</c> [bom FLG].</param>
		/// <returns></returns>
		private static bool IsUTF8(byte[] bytes,ref int utf8, ref bool bomFlg)
		{
			int len = bytes.Length;
			byte[] temp = new byte[4];
			for (int i = 0; i < len; i++)
			{
				temp[0] = bytes[i];
				if (temp[0] >= 0x00 && temp[0] <= 0x7F)
				{
					// ASCII : 0x00～0x7F
					continue;
				}
				if (i < len - 1)
				{
					temp[1] = bytes[i + 1];
					if ((temp[0] >= 0xC0 && temp[0] <= 0xDF) &&
						(temp[1] >= 0x80 && temp[1] <= 0xBF))
					{
						// 2 byte char
						i += 1;
						utf8 += 2;
						continue;
					}
				}
				if (i < len - 2)
				{
					temp[1] = bytes[i + 1]; temp[2] = bytes[i + 2];
					if (temp[0] == 0xEF && temp[1] == 0xBB && temp[2] == 0xBF)
					{
						// BOM : 0xEF 0xBB 0xBF
						bomFlg = true;
						i += 2;
						utf8 += 3;
						continue;
					}
					if ((temp[0] >= 0xE0 && temp[0] <= 0xEF) &&
						(temp[1] >= 0x80 && temp[1] <= 0xBF) &&
						(temp[2] >= 0x80 && temp[2] <= 0xBF))
					{
						// 3 byte char
						i += 2;
						utf8 += 3;
						continue;
					}
				}
				if (i < len - 3)
				{
					temp[1] = bytes[i + 1]; temp[2] = bytes[i + 2]; temp[3] = bytes[i + 3];
					if ((temp[0] >= 0xF0 && temp[0] <= 0xF7) &&
						(temp[1] >= 0x80 && temp[1] <= 0xBF) &&
						(temp[2] >= 0x80 && temp[2] <= 0xBF) &&
						(temp[3] >= 0x80 && temp[3] <= 0xBF))
					{
						// 4 byte char
						i += 3;
						utf8 += 4;
						continue;
					}
				}
				return false;
			}
			return true;
		}

		/// <summary>
		/// To the word break string.
		/// </summary>
		/// <param name="src">The source.</param>
		/// <param name="letterCount">The letter count.</param>
		/// <returns></returns>
		public static string ToWordBreakString(string src, int letterCount)
		{
			return System.Text.RegularExpressions.Regex.Replace(src, "([\x21-\x7E]{" + letterCount + "})", "$1<br>");
		}

		/// <summary>
		/// To Phone Number Format
		/// </summary>
		/// <param name="phoneNumber">Phone number</param>
		/// <returns>
		/// Phone number format
		/// </returns>
		/// <remarks>
		/// ex."09072481626"→"090-7248-1626"
		/// </remarks>
		public static string ToPhoneNumber(string phoneNumber)
		{
			if (string.IsNullOrEmpty(phoneNumber)) return phoneNumber;

			return string.Join("-", Regex.Replace(phoneNumber.Replace("-", string.Empty), @"(\d{0,6})(\d{0,4})(\d{1,4})", "$1-$2-$3", RegexOptions.RightToLeft)
				.Split('-').Where(x => string.IsNullOrEmpty(x) == false).ToList());
		}

		/// <summary>
		/// Gets the length of the with specified byte.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="byteStartPosition">The byte start position.</param>
		/// <param name="byteLength">Length of the byte.</param>
		/// <param name="encoding">The encoding.</param>
		/// <returns></returns>
		public static string GetWithSpecifiedByteLength(string value, int byteStartPosition, int byteLength, Encoding encoding)
		{
			var result = new StringBuilder();
			var currentLength = 0;
			var byteEndPostion = byteStartPosition + byteLength;
			foreach (var appendChar in value)
			{
				currentLength += GetByteLength(appendChar.ToString(), encoding);
				if (currentLength < byteStartPosition) continue;
				if (currentLength > byteEndPostion) break;
				result.Append(appendChar);
			}
			return result.ToString();
		}

		/// <summary>
		/// Gets the length of the byte.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="encoding">The encoding.</param>
		/// <returns></returns>
		public static int GetByteLength(string value, Encoding encoding)
		{
			return encoding.GetByteCount(value);
		}

		/// <summary>
		/// Generates random string with specific length.
		/// </summary>
		/// <param name="length">The length of random string.</param>
		/// <returns>The random string.</returns>
		public static string GenerateRandomString(int length = 5)
		{
			var allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
			var randomString = new StringBuilder();
			var random = new Random();

			for (int i = 0; i < length; i++)
			{
				randomString.Append(allowedChars[random.Next(0, allowedChars.Length)]);
			}

			return randomString.ToString();
		}
	}
}
