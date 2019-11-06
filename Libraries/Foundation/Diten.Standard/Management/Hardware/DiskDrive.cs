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

#region Used Directives

using System.Diagnostics.CodeAnalysis;
using Diten.Attributes;
using Diten.Collections.Generic;

#endregion

namespace Diten.Management.Hardware
{
	[SuppressMessage("ReSharper",
		"InconsistentNaming")]
	public class DiskDrive: Hardware<DiskDrive>
	{
		public object Availability {get; set;}
		public object BytesPerSector {get; set;}
		public object Capabilities {get; set;}
		public object CapabilityDescriptions {get; set;}
		public object Caption {get; set;}
		public object CompressionMethod {get; set;}
		public object ConfigManagerErrorCode {get; set;}
		public object ConfigManagerUserConfig {get; set;}
		public object CreationClassName {get; set;}
		public object DefaultBlockSize {get; set;}
		public new object Description {get; set;}
		public object DeviceID {get; set;}
		public object ErrorCleared {get; set;}
		public object ErrorDescription {get; set;}
		public object ErrorMethodology {get; set;}
		public object FirmwareRevision {get; set;}
		public object Index {get; set;}
		public object InstallDate {get; set;}
		public object InterfaceType {get; set;}
		public object LastErrorCode {get; set;}
		public object Manufacturer {get; set;}
		public object MaxBlockSize {get; set;}
		public object MaxMediaSize {get; set;}
		public object MediaLoaded {get; set;}
		public object MediaType {get; set;}
		public object MinBlockSize {get; set;}

		[SHAReady]
		public object Model {get; set;}

		public new object Name {get; set;}
		public object NeedsCleaning {get; set;}
		public object NumberOfMediaSupported {get; set;}
		public object Partitions {get; set;}
		public object PNPDeviceID {get; set;}
		public object PowerManagementCapabilities {get; set;}
		public object PowerManagementSupported {get; set;}
		public object SCSIBus {get; set;}
		public object SCSILogicalUnit {get; set;}
		public object SCSIPort {get; set;}
		public object SCSITargetId {get; set;}
		public object SectorsPerTrack {get; set;}

		[SHAReady]
		public object SerialNumber {get; set;}

		public new object Signature {get; set;}
		public object Size {get; set;}
		public object Status {get; set;}
		public object StatusInfo {get; set;}
		public object SystemCreationClassName {get; set;}
		public object SystemName {get; set;}
		public object TotalCylinders {get; set;}

		[SHAReady]
		public object TotalHeads {get; set;}

		public object TotalSectors {get; set;}
		public object TotalTracks {get; set;}
		public object TracksPerCylinder {get; set;}

		//public Drive()
		//{
		//    Win32DiskDrive = new ManagementClass(ManagementClass).GetInstances();
		//}

		/*

		ManagementObjectSearcher searcher = new
		ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

		foreach(ManagementObject wmi_HD in searcher.Get())
		{
		HardDrive hd = new HardDrive();
		hd.Model = wmi_HD["Model"].ToString();
		hd.Type  = wmi_HD["InterfaceType"].ToString(); 
		hdCollection.Add(hd);
		}

		Get the Serial Number

		searcher = new
		ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");

		int i = 0;
		foreach(ManagementObject wmi_HD in searcher.Get())
		{
		// get the hard drive from collection
		// using index
		HardDrive hd = (HardDrive)hdCollection[i];

		// get the hardware serial no.
		if (wmi_HD["SerialNumber"] == null)
		 hd.SerialNo = "None";
		else
		 hd.SerialNo = wmi_HD["SerialNumber"].ToString();

		++i;
		}
		*/
	}
}