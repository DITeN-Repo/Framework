#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/07/30 4:59 PM

#endregion

#region Used Directives

using System.DirectoryServices;

#endregion

namespace Diten.DirectoryServices.ActiveDirectory
{
	public class DirectoryEntryConfiguration
	{
		public DirectoryEntryConfiguration(string domainADsPath)
		{
			EntryConfiguration = new DirectoryEntry(domainADsPath).Options;
		}

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