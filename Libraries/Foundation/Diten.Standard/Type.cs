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
// Creation Date: 2019/08/15 4:35 PM

#endregion

namespace Diten
{
	public static class Types
	{
		public struct RegisteredType
		{
			public string Name { get; set; }
			public string Title { get; set; }
			public string Description { get; set; }
			public string IconCls { get; set; }
		}
	}
}