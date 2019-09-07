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

namespace Diten.DirectoryServices
{
	public enum UserFlags
	{
		// ReSharper disable once InconsistentNaming
		SCRIPT = 0x0001,

		// ReSharper disable once InconsistentNaming
		ACCOUNTDISABLE = 0x0002,

		// ReSharper disable once InconsistentNaming
		HOMEDIR_REQUIRED = 0x0008,

		// ReSharper disable once InconsistentNaming
		LOCKOUT = 0x0010,

		// ReSharper disable once InconsistentNaming
		PASSWD_NOTREQD = 0x0020,

		// ReSharper disable once InconsistentNaming
		PASSWD_CANT_CHANGE = 0x0040,

		// ReSharper disable once InconsistentNaming
		ENCRYPTED_TEXT_PWD_ALLOWED = 0x0080,

		// ReSharper disable once InconsistentNaming
		TEMP_DUPLICATE_ACCOUNT = 0x0100,

		// ReSharper disable once InconsistentNaming
		NORMAL_ACCOUNT = 0x0200,

		// ReSharper disable once InconsistentNaming
		INTERDOMAIN_TRUST_ACCOUNT = 0x0800,

		// ReSharper disable once InconsistentNaming
		WORKSTATION_TRUST_ACCOUNT = 0x1000,

		// ReSharper disable once InconsistentNaming
		SERVER_TRUST_ACCOUNT = 0x2000,

		// ReSharper disable once InconsistentNaming
		DONT_EXPIRE_PASSWORD = 0x10000,

		// ReSharper disable once InconsistentNaming
		MNS_LOGON_ACCOUNT = 0x20000,

		// ReSharper disable once InconsistentNaming
		SMARTCARD_REQUIRED = 0x40000,

		// ReSharper disable once InconsistentNaming
		TRUSTED_FOR_DELEGATION = 0x80000,

		// ReSharper disable once InconsistentNaming
		NOT_DELEGATED = 0x100000,

		// ReSharper disable once InconsistentNaming
		USE_DES_KEY_ONLY = 0x200000,

		// ReSharper disable once InconsistentNaming
		DONT_REQ_PREAUTH = 0x400000,

		// ReSharper disable once InconsistentNaming
		PASSWORD_EXPIRED = 0x800000,

		// ReSharper disable once InconsistentNaming
		TRUSTED_TO_AUTH_FOR_DELEGATION = 0x1000000
	}
}