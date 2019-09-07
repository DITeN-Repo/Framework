#region Using Directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

#endregion

namespace Diten.Web
{
	/// <inheritdoc />
	/// <summary>
	///     An IHttpAsyncHandler to "push" messages to the intended recipients
	/// </summary>
	public class HttpAsyncHandler : IHttpAsyncHandler
	{
		/// <summary>
		///     The queue holds a list of asynchronous results with information about registered sessions
		/// </summary>
		public static List<AsyncResult> Queue;

		/// <summary>
		///     Static constructor
		/// </summary>
		static HttpAsyncHandler()
		{
			// Initialize the queue
			Queue = new List<AsyncResult>();
		}

		#region IHttpAsyncHandler Members

		public IAsyncResult BeginProcessRequest(System.Web.HttpContext context, AsyncCallback cb, object extraData)
		{
			// Fetch the session id from the request
			var sessionId = context.Request["sessionId"];

			// Check if the session is already registered
			if (Queue.Find(q => q.SessionId == sessionId) != null)
			{
				var index = Queue.IndexOf(Queue.Find(q => q.SessionId == sessionId));

				// The session has already been registered, just refresh the HttpContext and the AsyncCallback
				Queue[index].Context = context;
				Queue[index].Callback = cb;

				return Queue[index];
			}

			// Create a new AsyncResult that holds the information about the session
			var asyncResult = new AsyncResult(context, cb, sessionId);

			// This session has not been registered yet, add it to the queue
			Queue.Add(asyncResult);

			return asyncResult;
		}

		public void EndProcessRequest(IAsyncResult result)
		{
			var tmpResult = (AsyncResult) result;

			// send the message to the recipient using the recipients HttpContext.Response object

			//todo: Remove commented codes.
			//if (tmpResult.Context.Session["Result"] != null)
			tmpResult.Context.Response.Write($@"Server Response: {tmpResult.Message} </ br>");

			if (HttpContext.Current.Application.AllKeys.Any(k => k.Equals("SessionHolder")))
			{
				var response =
					$@"{((HttpSessionState) ((Dictionary<string, object>) HttpContext.Current.Application["SessionHolder"])[tmpResult.SessionId])["Result"]}";

				tmpResult.Context.Response.Write(string.IsNullOrEmpty(response) || string.IsNullOrWhiteSpace(response)
					? "000.00"
					: response);
				tmpResult.Context.Response.Write(tmpResult.Message);
			}

			// reset the message object
			tmpResult.Message = string.Empty;
		}

		/// <inheritdoc />
		/// <summary>
		///     In an asynchronous solution, this message wouldn't be called
		/// </summary>
		/// <param name="context"></param>
		public void ProcessRequest(System.Web.HttpContext context)
		{
			throw new NotImplementedException();
		}

		public bool IsReusable => true;

		#endregion
	}
}