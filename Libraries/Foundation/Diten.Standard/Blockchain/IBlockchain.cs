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
// Creation Date: 2019/09/12 2:05 PM

namespace Diten.Blockchain
{
	/// <summary>
	///    Entities that required to be authentic.
	/// </summary>
	public interface IBlockchain: IHashable
	{
		/// <summary>
		///    Get the hash of the current contract.
		/// </summary>
		IContract Contract {get;}

		/// <summary>
		///    Get the hash of the contributor who wants to have a blockchain contraction.
		/// </summary>
		string Contributor {get;}
	}
}