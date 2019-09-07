#region DITeN Registration Info

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
// Creation Date: 2019/09/02 7:01 PM

#endregion

#region Used Directives

using System.DirectoryServices;

#endregion

namespace Diten.DirectoryServices.ActiveDirectory
{
	public class DirectoryEntryConfiguration
	{
		public DirectoryEntryConfiguration(string domainADsPath) =>
			EntryConfiguration = new DirectoryEntry(domainADsPath).Options;

		private System.DirectoryServices.DirectoryEntryConfiguration EntryConfiguration { get; }

		/// <summary>
		///    Get that is mutually authenticated.
		/// </summary>
		public bool IsMutuallyAuthenticated => EntryConfiguration.IsMutuallyAuthenticated();

		/// <summary>
		///    Get page size.
		/// </summary>
		public int PageSize => EntryConfiguration.PageSize;

		/// <summary>
		///    Get password encodign.
		/// </summary>
		public PasswordEncodingMethod PasswordEncoding => EntryConfiguration.PasswordEncoding;

		/// <summary>
		///    Get password port.
		/// </summary>
		public int PasswordPort => EntryConfiguration.PasswordPort;

		/// <summary>
		///    Get referral.
		/// </summary>
		public ReferralChasingOption Referral => EntryConfiguration.Referral;

		/// <summary>
		///    Get security masks.
		/// </summary>
		public SecurityMasks SecurityMasks => EntryConfiguration.SecurityMasks;

		/// <summary>
		///    Get current server name.
		/// </summary>
		public string Server => EntryConfiguration.GetCurrentServerName();
	}
}