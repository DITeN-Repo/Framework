#region Using Directives

using System.Web;

#endregion

namespace Diten.Web
{
	/// <inheritdoc />
	/// <summary>
	///     An IHttpHandler for the messages that are sent from a session
	/// </summary>
	public class HttpMessageHandler : IHttpHandler
	{
		#region IHttpHandler Members

		public bool IsReusable => true;

		public void ProcessRequest(System.Web.HttpContext context)
		{
			// Find the handle in the queue, identified by its session id
			var recipient = context.Request["recipient"];
			//var tt = Global.Sessions.FirstOrDefault(sid => sid.Equals(recipient));
			var handle = HttpAsyncHandler.Queue.Find(q => q.SessionId == recipient);

			// just a small check to prevent NullReferenceException
			if (handle == null)
				return;

			// Dump the message in the handle;
			handle.Message = context.Request["message"];

			// Set the handle to complete, this triggers the callback
			handle.SetCompleted(true);
		}

		#endregion
	}
}