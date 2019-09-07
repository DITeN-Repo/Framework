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
// Creation Date: 2019/09/04 7:18 PM

#endregion

namespace Diten.Parameters
{
	public sealed partial class SystemParams
	{
		/// <summary>
		///    User for connection to database with limited privileges.
		/// </summary>
		public string DatabaseUser => DefaultUser;

		/// <summary>
		///    User password for connection to database with limited privileges.
		/// </summary>
		public string DatabaseUserPassword => DefaultUserPassword;

		/// <summary>
		///    Administrator for connection to database with administrator privileges.
		/// </summary>
		public string DatabaseAdministrator => AdminUser;

		/// <summary>
		///    Administrator password for connection to database with administrator privileges.
		/// </summary>
		public string DatabaseAdministratorUserPassword => AdminUserPassword;

		/// <summary>
		///    Database owner user for connection to database with owner privileges.
		/// </summary>
		public string DatabaseOwner => DefaultUser;

		/// <summary>
		///    Database owner user password for connection to database with owner privileges.
		/// </summary>
		public string DatabaseOwnerPassword => DefaultUserPassword;

		/// <summary>
		///    Scheduled tasks user for connection to database with owner privileges.
		/// </summary>
		public string ScheduledTasksUser => DefaultUser;

		/// <summary>
		///    Scheduled tasks user password for connection to database with owner privileges.
		/// </summary>
		public string ScheduledTasksUserPassword => DefaultUserPassword;
	}
}