#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/09/02 12:51 AM

#endregion

namespace Diten.Web
{
	/// <inheritdoc />
	public abstract class HttpException : System.Web.HttpException
	{
		protected HttpException(string message) : base(message)
		{
		}
	}
}