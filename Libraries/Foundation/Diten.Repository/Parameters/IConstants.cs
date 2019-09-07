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
// Creation Date: 2019/09/05 2:30 AM

#endregion

namespace Diten.Parameters
{
	public interface IConstants
	{
		string NoReplyMailAddress { get; set; }
		string SmtpPassword { get; set; }
	}
}