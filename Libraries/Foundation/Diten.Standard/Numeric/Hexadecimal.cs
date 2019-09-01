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
	public class Hexadecimal
	{
		public static List<char> Characters =>
			new List<char>().AddRange(Enumerable.Range('0', '9'-'0'+1).Select(x => (char)x).ToArray())
				.AddRange(Enumerable.Range('A', 'F'-'A'+1).Select(x => (char)x).ToArray());
	}
}