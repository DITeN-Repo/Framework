// Copyright alright reserved by DITeN™ ©® 2003 - 2019
// ----------------------------------------------------------------------------------------------
// Agreement:
// 
// All developers could modify or developing this code but changing the architecture of
// the product is not allowed.
// 
// DITeN Research & Development
// ----------------------------------------------------------------------------------------------
// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 4:35 PM

#region Used Directives

using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using Diten.Parameters;
using EN = Diten.Environment;

// ReSharper disable UnusedMember.Global

#endregion

// ReSharper disable FormatStringProblem

namespace Diten
{
	/// <summary>
	///    Conversion tools in diten framework.
	/// </summary>
	public static class Convert
	{
		internal static readonly Type[] ConvertTypes =
		{
			typeof(object),
			typeof(DBNull),
			typeof(bool),
			typeof(char),
			typeof(sbyte),
			typeof(byte),
			typeof(short),
			typeof(ushort),
			typeof(int),
			typeof(uint),
			typeof(long),
			typeof(ulong),
			typeof(float),
			typeof(double),
			typeof(decimal),
			typeof(DateTime),
			typeof(object),
			typeof(System.String)
		};

		private static readonly Type EnumType = typeof(Enum);

		internal static object DefaultToType(IConvertible value,
		                                     Type targetType,
		                                     IFormatProvider provider)
		{
			if (targetType == null) throw new ArgumentNullException(nameof(targetType));
			var runtimeType = targetType;

			if (runtimeType == null)
				throw new InvalidCastException(Environment.GetResourceString("InvalidCast_FromTo",
				                                                             value.GetType().FullName,
				                                                             targetType.FullName));

			if (value.GetType() == targetType) return value;
			if (runtimeType == ConvertTypes[3]) return value.ToBoolean(provider);
			if (runtimeType == ConvertTypes[4]) return value.ToChar(provider);
			if (runtimeType == ConvertTypes[5]) return value.ToSByte(provider);
			if (runtimeType == ConvertTypes[6]) return value.ToByte(provider);
			if (runtimeType == ConvertTypes[7]) return value.ToInt16(provider);
			if (runtimeType == ConvertTypes[8]) return value.ToUInt16(provider);
			if (runtimeType == ConvertTypes[9]) return value.ToInt32(provider);
			if (runtimeType == ConvertTypes[10]) return value.ToUInt32(provider);
			if (runtimeType == ConvertTypes[11]) return value.ToInt64(provider);
			if (runtimeType == ConvertTypes[12]) return value.ToUInt64(provider);
			if (runtimeType == ConvertTypes[13]) return value.ToSingle(provider);
			if (runtimeType == ConvertTypes[14]) return value.ToDouble(provider);
			if (runtimeType == ConvertTypes[15]) return value.ToDecimal(provider);
			if (runtimeType == ConvertTypes[16]) return value.ToDateTime(provider);
			if (runtimeType == ConvertTypes[18]) return value.ToString(provider);
			if (runtimeType == ConvertTypes[1]) return value;
			if (runtimeType == EnumType) return (System.Enum) value;

			if (runtimeType == ConvertTypes[2]) throw new InvalidCastException(EN.GetResourceString(Exceptions.Default.InvalidCast_DBNull));
			if (runtimeType == ConvertTypes[0]) throw new InvalidCastException(EN.GetResourceString(Exceptions.Default.InvalidCast_Empty));

			throw new InvalidCastException(EN.GetResourceString(Exceptions.Default.InvalidCast_FromTo,
			                                                    value.GetType().FullName,
			                                                    targetType.FullName));
		}

		/// <summary>Converts a base data type to another base data type.</summary>
		/// <summary>
		///    Converting a type name into diten data type.
		/// </summary>
		/// <param name="typeName">name of the type in diten framework.</param>
		/// <returns>A type in diten framework.</returns>
		public static Type ToDitenDataType(System.String typeName)
		{
			if (System.String.IsNullOrEmpty(typeName) ||
			    string.IsNullOrWhiteSpace(typeName))
				throw new ArgumentOutOfRangeException(nameof(typeName),
				                                      typeName,
				                                      @"Type name can not be null or empty.");

			var type = Assembly.GetExecutingAssembly()
			                   .GetType(typeName,
			                            false,
			                            true);

			if (type == null)
				throw new ArgumentOutOfRangeException(nameof(typeName),
				                                      typeName,
				                                      @"Type not found.");

			return type;
		}

		/// <summary>
		///    Converting a 8 bytes array into double.
		/// </summary>
		/// <param name="index">the starting position within value.</param>
		/// <param name="data">An eight bytes array of data for conversion.</param>
		/// <returns>A double.</returns>
		public static double ToDouble(this byte[] data,
		                              int index = 0)
		{
			return BitConverter.ToDouble(data,
			                             index);
		}

		/// <summary>
		///    Convert DistinguishedName to ObjectGUID
		/// </summary>
		/// <param name="objectDn">Distinguished name</param>
		/// <returns>Guid of object.</returns>
		public static Guid ToGuid(this string objectDn) { return new DirectoryEntry(objectDn).Guid; }

		/// <summary>
		///    Converting a TimeSpan into HH:MM format.
		/// </summary>
		/// <param name="time">a TimeSpan.</param>
		/// <returns>A string of time in HH:MM format.</returns>
		public static System.String ToHHMM(this TimeSpan time) { return time.ToString("hh\\:mm"); }

		/// <summary>
		///    Converting a TimeSpan into HH:MM:SS format.
		/// </summary>
		/// <param name="time">a TimeSpan.</param>
		/// <returns>A string of time in HH:MM:SS format.</returns>
		public static System.String ToHHMMSS(this TimeSpan time) { return time.ToString("hh\\:mm\\:ss"); }

		/// <summary>
		///    Converting hexadecimal number into integer.
		/// </summary>
		/// <param name="hexValue">Hexadecimal number.</param>
		/// <returns>An integer.</returns>
		public static int ToInt(System.String hexValue)
		{
			return int.Parse(hexValue,
			                 NumberStyles.HexNumber);
		}

		/// <summary>
		///    Converting IP address to integer.
		/// </summary>
		/// <param name="address">IP Address.</param>
		/// <returns>An integer address.</returns>
		public static int ToInt(IPAddress address)
		{
			return BitConverter.ToInt32(address.GetAddressBytes(),
			                            0);
		}

		/// <summary>
		///    Converting a TimeSpan into integer.
		/// </summary>
		/// <param name="time">A TimeSpan.</param>
		/// <returns>An integer that represent time.</returns>
		public static int ToInteger(this TimeSpan time)
		{
			return int.Parse(
			                 time.Hours +
			                 time.Minutes.ToString()
			                     .PadLeft(2,
			                              '0') +
			                 time.Seconds.ToString()
			                     .PadLeft(2,
			                              '0'));
		}

		/// <summary>
		///    Translate the Friendly Domain Name to Fully Qualified Domain.
		/// </summary>
		/// <param name="domainName">Friendly domain name.</param>
		/// <returns>LDAP domain name.</returns>
		public static System.String ToLdapDomain(System.String domainName)
		{
			return Domain.GetDomain(new DirectoryContext(DirectoryContextType.Domain,
			                                             domainName))
			             .Name;
		}

		/// <summary>
		///    Converting a separated string into list of strings.
		/// </summary>
		/// <param name="data">Separated string by main separator.</param>
		/// <returns>A list of separated values of string.</returns>
		public static List<System.String> ToList(System.String data) { return data.ToArray().ToList(); }

		/// <summary>
		///    Converting byte array into object.
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public static object ToObject(this byte[] data)
		{
			using (var memStream = new MemoryStream())
			{
				var binForm = new BinaryFormatter();
				memStream.Write(data,
				                0,
				                data.Length);
				memStream.Seek(0,
				               SeekOrigin.Begin);
				var obj = binForm.Deserialize(memStream);

				return obj;
			}
		}

		/// <summary>
		///    Convert an ObjectGUID to OctetString: The Native ObjectGUID
		/// </summary>
		/// <param name="objectGuid">Object GUID.</param>
		/// <returns>Octet string.</returns>
		public static System.String ToOctetString(Guid objectGuid)
		{
			return objectGuid.ToByteArray()
			                 .Aggregate(System.String.Empty,
			                            (current,
			                             b) => current + $@"\{b:x2}");
		}

		public static short ToShort(this TimeSpan time)
		{
			return short.Parse(time.Hours +
			                   time.Minutes.ToString()
			                       .PadLeft(2,
			                                '0'));
		}

		/// <summary>
		///    Get splitted data from a dictionary.
		///    Data will be separated by main separator.
		///    Data parameter and data value will be separated using value separator character.
		/// </summary>
		/// <param name="data">A dictionary that contains string data and string keys for making separated value string.</param>
		/// <returns>Separated keys and values string.</returns>
		public static System.String ToSplittedData(Dictionary<System.String, string> data)
		{
			var _return = string.Empty;

			return data == null
				       ? _return
				       : data.Aggregate(_return,
				                        (current,
				                         _string) => current +
				                                     _string.Key +
				                                     Char.ReservedChars.Equals.ToChar() +
				                                     _string.Value +
				                                     Char.ReservedChars.Semicolon.ToChar());
		}

		/// <summary>
		///    Get splitted data from a list.
		///    Data will be separated by main separator.
		/// </summary>
		/// <param name="data">A list of string for making separated value string.</param>
		/// <returns>Separated values string.</returns>
		public static System.String ToSplittedData(IEnumerable<System.String> data)
		{
			return data.Aggregate(System.String.Empty,
			                      (current,
			                       _string) => current + _string + Char.ReservedChars.Semicolon.ToChar());
		}

		/// <summary>
		///    Get splitted data from a string.
		///    Data will be separated by main separator.
		/// </summary>
		/// <param name="data">An array of string for making separated value string.</param>
		/// <returns>Separated values string.</returns>
		public static System.String ToSplittedData(System.String[] data)
		{
			return data.Aggregate(System.String.Empty,
			                      (current,
			                       _string) => current + _string + EN.TextValuingSeparator);
		}

		/// <summary>
		///    Converting memory stream into string.
		/// </summary>
		/// <param name="memoryStream"></param>
		/// <returns></returns>
		public static System.String ToString(MemoryStream memoryStream)
		{
			var position = memoryStream.Position;
			memoryStream.Position = 0;

			var _return = new StreamReader(memoryStream).ReadToEnd();

			memoryStream.Position = position;

			return _return;
		}

		/// <summary>
		///    Convert Diten.String array to System.String array
		/// </summary>
		/// <param name="value">A Diten.String array</param>
		/// <returns>A System.String array</returns>
		public static System.String[] ToStringArray(String[] value)
		{
			var _return = new string[value.Length];

			for (var i = 0;
			     i < value.Length;
			     i++) _return[i] = value[i].Value;

			return _return;
		}

		/// <summary>
		///    Converting a string type name into type.
		/// </summary>
		/// <param name="typeName">Type name for conversion.</param>
		/// <param name="isReferenced">True if type is in referenced assembly.</param>
		/// <returns>A n array that contains types who has the type name parameter value in it's name.</returns>
		public static Type[] ToType(System.String typeName,
		                            bool isReferenced = true)
		{
			return ToType(typeName,
			              isReferenced,
			              true);
		}

		/// <summary>
		///    Converting a string type name into type.
		/// </summary>
		/// <param name="typeName">Type name for conversion.</param>
		/// <param name="isReferenced">True if type is in referenced assembly.</param>
		/// <param name="isGac">True if type is in GAC.</param>
		/// <returns>A n array that contains types who has the type name parameter value in it's name.</returns>
		private static Type[] ToType(System.String typeName,
		                             bool isReferenced,
		                             bool isGac)
		{
			if (System.String.IsNullOrEmpty(typeName) ||
			    !isReferenced && !isGac) return new Type[] {};

			var currentAssembly = Assembly.GetExecutingAssembly();

			var assemblyFullNames = new List<System.String>();
			var types = new List<Type>();

			if (isReferenced)
				foreach (var assemblyName in currentAssembly.GetReferencedAssemblies())
				{
					var assembly = Assembly.Load(assemblyName.FullName);
					var type = assembly.GetType(typeName,
					                            false,
					                            true);

					if (type == null ||
					    assemblyFullNames.Contains(assembly.FullName)) continue;

					types.Add(type);
					assemblyFullNames.Add(assembly.FullName);
				}

			if (!isGac) return types.ToArray();
			{
				foreach (var file in Constants.GetGlobalAssemblyCacheFiles(
				                                                           $@"{
						                                                           System.Environment
						                                                                 .GetFolderPath(System.Environment.SpecialFolder
						                                                                                      // ReSharper disable once StringLiteralTypo
						                                                                                      .Windows)
					                                                           }\assembly")
				)
					try
					{
						var assembly = Assembly.ReflectionOnlyLoadFrom(file);
						var type = assembly.GetType(typeName,
						                            false,
						                            true);

						if (type == null ||
						    assemblyFullNames.Contains(assembly.FullName)) continue;
						types.Add(type);
						assemblyFullNames.Add(assembly.FullName);
					}
					catch
					{
						// ignored
					}
			}

			return types.ToArray();
		}
	}
}