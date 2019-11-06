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
// Creation Date: 2019/09/12 10:13 PM

#region Used Directives

using System.Linq;
using Diten.Management.Hardware;
using Diten.Security;
using Diten.Security.Cryptography;

#endregion

namespace Diten.Blockchain
{
	/// <summary>
	///    Base of contributor class.
	/// </summary>
	/// <typeparam name="TKey">Type of signature in <see cref="ISHA" /></typeparam>
	public abstract class ContributorBase<TKey>
		where TKey: ISHA
	{
		/// <summary>
		///    Get signature of the <see cref="ContributorBase{TKey}" />
		/// </summary>
		public Signature<TKey> Signature =>
			new Signature<TKey>(SHA256.Encrypt(Computer.Processors.ToList()
			                                           .Aggregate(string.Empty,
			                                                      (result,
			                                                       next) => $@"{
					                                                                next.Manufacturer
				                                                                }{
					                                                                next.ProcessorType
				                                                                }{
					                                                                next.Architecture
				                                                                }{
					                                                                next.Version
				                                                                }{
					                                                                next.Revision
				                                                                }" +
			                                                                $@"{
					                                                                next.NumberOfCores
				                                                                }{
					                                                                next.PartNumber
				                                                                }{
					                                                                next.ProcessorId
				                                                                }{
					                                                                next.SerialNumber
				                                                                }{
					                                                                next.DeviceID
				                                                                }")));
	}
}