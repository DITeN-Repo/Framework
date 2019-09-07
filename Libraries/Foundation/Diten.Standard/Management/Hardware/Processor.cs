#region DITeN Registration Info

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
// Creation Date: 2019/08/15 8:37 PM

#endregion

#region Used Directives

using Diten.Attributes;
using Diten.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

#endregion

namespace Diten.Management.Hardware
{
	public class Processor : Hardware<Processor>
	{
		public object AddressWidth { get; set; }
		public object Architecture { get; set; }
		public object AssetTag { get; set; }
		public object Availability { get; set; }

		public object Caption { get; set; }

		public object Characteristics { get; set; }
		public object ConfigManagerErrorCode { get; set; }
		public object ConfigManagerUserConfig { get; set; }
		public object CpuStatus { get; set; }
		public object CreationClassName { get; set; }
		public object CurrentClockSpeed { get; set; }
		public object CurrentVoltage { get; set; }
		public object DataWidth { get; set; }
		public object Description { get; set; }
		public object DeviceID { get; set; }
		public object ErrorCleared { get; set; }
		public object ErrorDescription { get; set; }
		public object ExtClock { get; set; }
		public object Family { get; set; }
		public object InstallDate { get; set; }
		public object L2CacheSize { get; set; }
		public object L2CacheSpeed { get; set; }
		public object L3CacheSize { get; set; }
		public object L3CacheSpeed { get; set; }
		public object LastErrorCode { get; set; }
		public object Level { get; set; }
		public object LoadPercentage { get; set; }
		public object Manufacturer { get; set; }
		public object MaxClockSpeed { get; set; }
		public object Name { get; set; }
		public object NumberOfCores { get; set; }
		public object NumberOfEnabledCore { get; set; }
		public object NumberOfLogicalProcessors { get; set; }
		public object OtherFamilyDescription { get; set; }
		public object PartNumber { get; set; }
		public object PNPDeviceID { get; set; }
		public object PowerManagementCapabilities { get; set; }
		public object PowerManagementSupported { get; set; }

		[SHAReady] public object ProcessorId { get; set; }

		[SHAReady] public object ProcessorType { get; set; }

		public object Revision { get; set; }
		public object Role { get; set; }
		public object SecondLevelAddressTranslationExtensions { get; set; }

		[SHAReady] public object SerialNumber { get; set; }

		public object SocketDesignation { get; set; }
		public object Status { get; set; }
		public object StatusInfo { get; set; }
		public object Stepping { get; set; }
		public object SystemCreationClassName { get; set; }
		public object SystemName { get; set; }
		public object ThreadCount { get; set; }
		public object UniqueId { get; set; }
		public object UpgradeMethod { get; set; }
		public object Version { get; set; }
		public object VirtualizationFirmwareEnabled { get; set; }
		public object VMMonitorModeExtensions { get; set; }
		public object VoltageCaps { get; set; }
	}
}