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
// Creation Date: 2019/08/16 12:16 AM

namespace Diten.Globalization.Languages
{
	public class Translation
	{
		public static string Translate(string source,
		                               string systemCultureName,
		                               string cultureName)
		{
			return Translate(source,
			                 systemCultureName,
			                 cultureName,
			                 false);
		}

		public static string Translate(string source,
		                               string systemCultureName,
		                               string cultureName,
		                               bool isValidSystemWord)
		{
			return source;
		}
	}
}