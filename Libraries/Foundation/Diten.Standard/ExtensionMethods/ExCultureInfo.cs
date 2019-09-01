#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 4:42 PM

#endregion

#region Used Directives

using JetBrains.Annotations;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

#endregion

namespace Diten
{
	[SuppressMessage("ReSharper", "UnusedParameter.Global")]
	public static class ExCultureInfo
	{
		public static List<CultureInfo> GetAllCultures([NotNull] this CultureInfo cultureInfo)
		{
			return CultureInfo.GetCultures(CultureTypes.AllCultures&~CultureTypes.NeutralCultures).ToList();
		}
	}
}