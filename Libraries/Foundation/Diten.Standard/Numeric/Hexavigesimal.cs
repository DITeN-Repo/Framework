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
	public class Hexavigesimal
	{
		public static List<char> Characters =>
			new List<char>().AddRange(Enumerable.Range('A', 26).Select(x => (char)x).ToArray());
	}
}