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
// Creation Date: 2019/09/12 2:11 PM

#region Used Directives

using Diten.Security;

#endregion

namespace Diten.Blockchain
{
	public interface IContract
	{
		/// <summary>
		///    Get the private key of the current contract.
		/// </summary>
		Key PrivateKey {get;}

		/// <summary>
		///    Get the public key of the current contract.
		/// </summary>
		Key PublicKey {get;}
	}
}