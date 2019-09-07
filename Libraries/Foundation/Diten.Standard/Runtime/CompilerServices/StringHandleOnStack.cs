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
// Creation Date: 2019/09/02 9:11 PM

#endregion

#region Used Directives

using System;

#endregion

namespace Diten.Runtime.CompilerServices
{
	internal struct StringHandleOnStack
	{
		private IntPtr m_ptr;

		internal StringHandleOnStack(IntPtr pString) => m_ptr = pString;
	}
}