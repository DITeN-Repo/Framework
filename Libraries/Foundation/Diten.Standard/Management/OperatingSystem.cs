#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 8:37 PM

#endregion

#region Used Directives

using Diten.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

#endregion

namespace Diten.Management
{
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public class OperatingSystem:Hardware<OperatingSystem>
	{
		/// <summary>
		///    Operating system version.
		/// </summary>
		public string Caption { get; set; }

		/// <summary>
		///    Operating system version.
		/// </summary>
		public string OSVersion => Caption;
	}
}