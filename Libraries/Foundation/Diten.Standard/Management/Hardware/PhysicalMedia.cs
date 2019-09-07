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

using Diten.Collections.Generic;

#endregion

namespace Diten.Management.Hardware
{
	public class PhysicalMedia : Hardware<PhysicalMedia>
	{
		public object Capacity { get; set; }
		public object Caption { get; set; }
		public object CleanerMedia { get; set; }
		public object CreationClassName { get; set; }
		public object Description { get; set; }
		public object HotSwappable { get; set; }
		public object InstallDate { get; set; }
		public object Manufacturer { get; set; }
		public object MediaDescription { get; set; }
		public object MediaType { get; set; }
		public object Model { get; set; }
		public object Name { get; set; }
		public object OtherIdentifyingInfo { get; set; }
		public object PartNumber { get; set; }
		public object PoweredOn { get; set; }
		public object Removable { get; set; }
		public object Replaceable { get; set; }
		public object SerialNumber { get; set; }
		public object SKU { get; set; }
		public object Status { get; set; }
		public object Tag { get; set; }
		public object Version { get; set; }
		public object WriteProtectOn { get; set; }
	}
}