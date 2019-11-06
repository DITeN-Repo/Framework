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
// Creation Date: 2019/08/15 4:42 PM

namespace Diten
{
	/// <summary>
	///    Exception extension methods class
	/// </summary>
	public static class ExException
	{
		/// <summary>
		///    Converting <see cref="System.Exception" /> to <see cref="Exception" />
		/// </summary>
		/// <param name="exception">Exception of type <see cref="System.Exception" /></param>
		/// <returns>Exception of type <see cref="Exception" /></returns>
		// ReSharper disable once UnusedMethodReturnValue.Global
		public static Exception ToException(this System.Exception exception)
		{
			return new Exception(exception.Message,
			                     exception.InnerException);
		}
	}
}