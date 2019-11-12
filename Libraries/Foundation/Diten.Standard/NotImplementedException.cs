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
// Creation Date: 2019/09/04 10:30 PM

#region Used Directives

using Diten.Reflection;

#endregion

namespace Diten
{
	/// <inheritdoc cref="System.NotImplementedException" />
	public class NotImplementedException: System.NotImplementedException
	{
		public NotImplementedException(): this(
		                                       $@"Module [{Assembly.GetCurrentMethodName()}] must be controlled later for logical mistakes.") {}

		public NotImplementedException(System.String message): base(message) {}
	}
}