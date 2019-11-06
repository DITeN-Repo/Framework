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
// Creation Date: 2019/09/04 6:56 PM

#region Used Directives

using System.Collections.Generic;
using System.Linq;

#endregion

namespace Diten.Numeric
{
	public static class Duosexagesimal
	{
		public static List<char> Characters =>
			new List<char>().AddRange(Enumerable.Range('0',
			                                           '9' - '0')
			                                    .Select(x => (char) x)
			                                    .ToArray())
			                .AddRange(Enumerable.Range('A',
			                                           'Z' - 'A')
			                                    .Select(x => (char) x)
			                                    .ToArray())
			                .AddRange(Enumerable.Range('a',
			                                           'z' - 'a')
			                                    .Select(x => (char) x)
			                                    .ToArray());
	}
}