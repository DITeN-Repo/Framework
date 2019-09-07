#region Using Directives

using System;
using System.Threading;

#endregion

namespace Diten.Web
{
	public class AsyncResult : IAsyncResult
	{
		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="context">The session's HttpContext</param>
		/// <param name="callback">The AsyncCallback from the handler</param>
		/// <param name="sessionId">The session's SessionID</param>
		// ReSharper disable once NotNullMemberIsNotInitialized
		public AsyncResult(System.Web.HttpContext context, AsyncCallback callback, string sessionId)
		{
			Callback = callback;
			Context = context;
			SessionId = sessionId;
		}

		/// <summary>
		///     The session's SessionID is used to uniquely identify every session
		/// </summary>
		public string SessionId { get; set; }

		/// <summary>
		///     The message that is sent to this session
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		///     The HttpContext that holds the Response object, which we need when sending the message to the recipient
		/// </summary>
		public System.Web.HttpContext Context { get; set; }

		/// <summary>
		///     The callback that is triggered when a message is sent
		/// </summary>
		public AsyncCallback Callback { get; set; }

		/// <summary>
		///     This sets the AsyncResult to completed and triggers the callback
		/// </summary>
		/// <param name="isCompleted"></param>
		public void SetCompleted(bool isCompleted)
		{
			IsCompleted = isCompleted;

			if (isCompleted)
				Callback?.Invoke(this);
		}

		#region IAsyncResult Members

		// ReSharper disable once UnusedAutoPropertyAccessor.Local
		public object AsyncState { get; private set; }

		public WaitHandle AsyncWaitHandle { get; set; }

		public bool CompletedSynchronously => false;

		public bool IsCompleted { get; private set; }

		#endregion
	}
}