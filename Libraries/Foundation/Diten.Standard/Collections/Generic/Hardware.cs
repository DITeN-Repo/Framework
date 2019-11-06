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
// Creation Date: 2019/08/15 4:42 PM

#region Used Directives

using System;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.Serialization;
using Diten.Parameters;
using Diten.Security;

// ReSharper disable All

#endregion

namespace Diten.Collections.Generic
{
	public abstract class Hardware<THardware>: WebObject<THardware>
		where THardware: ISerializable, IWebObject<THardware>
	{
		private static ManagementObjectCollection ManagementObjectCollection
		{
			get
			{
				using (var managementObjectCollection = new ManagementClass(
				                                                            $@"{
						                                                            SystemParams.Default.Win32Extention
					                                                            }{
						                                                            typeof(THardware).ToString().Split(".".ToCharArray()).Last()
					                                                            }")) return managementObjectCollection.GetInstances();
			}
		}

		/// <summary>
		///    Unique key of the hardware.
		/// </summary>
		public new Signature Signature
		{
			get
			{
				Touch();

				return new Signature<TKey>();
			}
		}

		public List<THardware> Touch()
		{
			var _return = new List<THardware>();

			foreach (var managementBaseObject in ManagementObjectCollection)
			{
				var instance = (THardware) Activator.CreateInstance(typeof(THardware));
				var instanceProperties = instance.GetType().GetProperties().ToList();

				foreach (var propertyData in managementBaseObject.Properties)
				{
					if (instanceProperties.Any(p => p.Name.ToUpper().Equals(propertyData.Name.ToUpper())))
					{
						instanceProperties.FirstOrDefault(p => p.Name.ToUpper().Equals(propertyData.Name.ToUpper()))
						                  ?.SetValue(instance,
						                             propertyData.Value ?? string.Empty);

						continue;
					}

					if (instanceProperties.Any(p => p.Name.ToUpper().Equals(propertyData.Name.ToUpper())) ||
					    instance.GetType()
					            .GetRuntimeProperties()
					            .ToList()
					            .Any(p => p.Name.ToUpper().Equals(propertyData.Name.ToUpper()))) continue;

					var dic = instance.GetType()
					                  .GetProperty(Enum.GetName(Enum.PropertyNames.Dictionary))
					                  ?.GetValue(instance);
					dic?.GetType()
					   .GetMethod(Enum.GetName(Enum.MethodNames.Add))
					   ?.Invoke(
					            dic,
					            BindingFlags.Public,
					            null,
					            new[] {propertyData.Name, propertyData.Value},
					            CultureInfo.CurrentCulture);
				}

				_return.Add(instance);
			}

			return _return;
		}
	}
}