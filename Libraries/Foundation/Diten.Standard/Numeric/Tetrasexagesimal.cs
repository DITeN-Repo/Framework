#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 4:42 PM

#endregion

#region Used Directives

using Diten.Collections.Generic;

#endregion

namespace Diten.Numeric
{
	public class Tetrasexagesimal
	{
		public static List<char> Characters => Duosexagesimal.Characters.AddRange(new List<char> { '=', '+' });
		public static List<char> YouTubeCharacters => Duosexagesimal.Characters.AddRange(new List<char> { '-', '_' });
	}
}