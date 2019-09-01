#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 4:42 PM

#endregion

#region Used Directives

using Diten.Security.Cryptography;
using System;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Reflection;

// ReSharper disable All

#endregion

namespace Diten.Collections.Generic
{
	public class Hardware<THardware>:Hardware<THardware, SHA1>
	//where THardware : IHardware<THardware, SHA1>
	{
	}


	public abstract class Hardware<THardware, TKey>:Object<THardware>
		//where THardware:IHardware<THardware, TKey>
		where TKey : ISHA
	{
		private static ManagementObjectCollection ManagementObjectCollection =>
			new ManagementClass(
					$@"{Variables.System.Default.Win32Extention}{typeof(THardware).ToString().Split(".".ToCharArray()).Last()}")
				.GetInstances();

		/// <summary>
		///    Unique key of the hardware.
		/// </summary>
		public new string Key
		{
			get
			{
				Touch();
				return base.Key;
			}
		}

		public List<THardware> Touch()
		{
			var _return = new List<THardware>();

			foreach(var managementBaseObject in ManagementObjectCollection)
			{
				var instance = (THardware)Activator.CreateInstance(typeof(THardware));
				var instanceProperties = instance.GetType().GetProperties().ToList();

				foreach(var propertyData in managementBaseObject.Properties)
				{
					if(instanceProperties.Any(p => p.Name.ToUpper().Equals(propertyData.Name.ToUpper())))
					{
						instanceProperties.FirstOrDefault(p => p.Name.ToUpper().Equals(propertyData.Name.ToUpper()))
							?.SetValue(instance, propertyData.Value??string.Empty);

						continue;
					}

					if(instanceProperties.Any(p => p.Name.ToUpper().Equals(propertyData.Name.ToUpper()))||
						 instance.GetType().GetRuntimeProperties().ToList()
							 .Any(p => p.Name.ToUpper().Equals(propertyData.Name.ToUpper())))
						continue;

					var dic = instance.GetType().GetProperty(Enum.GetName(Enum.PropertyNames.Dictionary))
						?.GetValue(instance);
					dic?.GetType().GetMethod(Enum.GetName(Enum.MethodNames.Add))?.Invoke(
						dic, BindingFlags.Public, null,
						new[] { propertyData.Name, propertyData.Value },
						CultureInfo.CurrentCulture);
				}

				_return.Add(instance);
			}

			return _return;
		}
	}
}