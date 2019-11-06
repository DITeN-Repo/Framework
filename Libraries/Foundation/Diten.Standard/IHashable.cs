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
// Creation Date: 2019/09/09 4:20 PM

namespace Diten
{
	/// <summary>
	///    Entities that required to be hashed .
	/// </summary>
	public interface IHashable
	{
		/// <summary>
		///    Converting value into Base64Text encryption.
		/// </summary>
		/// <param name="value">The current entity that must be converted into Base64Text encryption.</param>
		/// <returns>A Base64Text hashed string.</returns>
		string ToBase64Text(string value);
	}
}