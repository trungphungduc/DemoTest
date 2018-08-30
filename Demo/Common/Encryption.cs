/*
=========================================================================================================
  Module      : Encryption.cs
 ･･･････････････････････････････････････････････････････････････････････････････････････････････････････
  Copyright   : Copyright Cp Co.,Ltd. 2017 All Rights Reserved.
=========================================================================================================
*/
using System;
using System.Security.Cryptography;
using System.Text;

namespace Cp.Common
{
	/// <summary>
	/// Class Encryption
	/// </summary>
	public class Encryption
	{
		/// <summary>
		/// Encrypt
		/// </summary>
		/// <param name="toEncrypt">To encrypt</param>
		/// <param name="key">Key</param>
		/// <param name="useHashing">Use hashing</param>
		/// <returns></returns>
		public static string Encrypt(string toEncrypt, string key, bool useHashing)
		{
			if (toEncrypt == string.Empty)
			{
				return string.Empty;
			}

			byte[] keyArray;
			var toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

			if (useHashing)
			{
				MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
				keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
			}
			else
				keyArray = UTF8Encoding.UTF8.GetBytes(key);

			var tdes = new TripleDESCryptoServiceProvider
			{
				Key = keyArray,
				Mode = CipherMode.ECB,
				Padding = PaddingMode.PKCS7
			};

			var cTransform = tdes.CreateEncryptor();
			var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

			return Convert.ToBase64String(resultArray, 0, resultArray.Length);
		}

		/// <summary>
		/// Decrypt
		/// </summary>
		/// <param name="toDecrypt">To decrypt</param>
		/// <param name="key">Key</param>
		/// <param name="useHashing">Use hashing</param>
		/// <returns></returns>
		public static string Decrypt(string toDecrypt, string key, bool useHashing)
		{
			if (toDecrypt == string.Empty)
			{
				return string.Empty;
			}

			byte[] keyArray;
			var toEncryptArray = Convert.FromBase64String(toDecrypt);

			if (useHashing)
			{
				var hashmd5 = new MD5CryptoServiceProvider();
				keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
			}
			else
				keyArray = UTF8Encoding.UTF8.GetBytes(key);

			var tdes = new TripleDESCryptoServiceProvider
			{
				Key = keyArray,
				Mode = CipherMode.ECB,
				Padding = PaddingMode.PKCS7
			};

			var cTransform = tdes.CreateDecryptor();
			byte[] resultArray;
			try
			{
				resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
			}
			catch
			{
				throw new ArgumentException("File Data is bad.");
			}

			return UTF8Encoding.UTF8.GetString(resultArray);
		}
	}
}
