/*
=========================================================================================================
  Module      : Object utility(ObjectUtility.cs)
 ･･･････････････････････････････････････････････････････････････････････････････････････････････････････
  Copyright   : Copyright CP Co.,Ltd 2017 All Rights Reserved.
=========================================================================================================
*/
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Cp.Common.Util
{
	public static class ObjectUtility
	{
		/// <summary>
		/// Deeps the copy.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The source.</param>
		/// <returns>The new object copy</returns>
		public static T DeepCopy<T>(T source)
		{
			using (MemoryStream stream = new MemoryStream())
			{
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(stream, source);
				stream.Position = 0;

				return (T)formatter.Deserialize(stream);
			}
		}
	}
}
