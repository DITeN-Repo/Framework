#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 4:42 PM

#endregion

#region Used Directives

using Diten.Collections.Generic;
using System.Linq;

#endregion

namespace Diten.Numeric
{
	public static class Duosexagesimal
	{
		public static List<char> Characters =>
			new List<char>().AddRange(Enumerable.Range('0', '9'-'0').Select(x => (char)x).ToArray())
				.AddRange(Enumerable.Range('A', 'Z'-'A').Select(x => (char)x).ToArray())
				.AddRange(Enumerable.Range('a', 'z'-'a').Select(x => (char)x).ToArray());
	}
}