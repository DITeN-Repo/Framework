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

#endregion

namespace Diten.Numeric
{
	public class Tetrasexagesimal
	{
		public static List<char> Characters => Duosexagesimal.Characters.AddRange(new List<char> {'=', '+'});
		public static List<char> YouTubeCharacters => Duosexagesimal.Characters.AddRange(new List<char> {'-', '_'});
	}
}