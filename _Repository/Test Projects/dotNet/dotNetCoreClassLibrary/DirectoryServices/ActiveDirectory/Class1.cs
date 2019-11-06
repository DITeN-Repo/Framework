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
// Creation Date: 2019/09/02 12:08 PM

#region Used Directives

using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;

#endregion

namespace dotNetCoreClassLibrary.DirectoryServices.ActiveDirectory
{
	public class AppContext: HttpApplicationState

	public class HttpContexta: HttpContext
	{
		private readonly HttpContext _httpContextImplementation = new DefaultHttpContext();

		/// <summary>Aborts the connection underlying this request.</summary>
		public override void Abort()
		{
			_httpContextImplementation.Request.HttpContext.Session.

			throw new NotImplementedException();
		}

		/// <summary>
		///    Gets the collection of HTTP features provided by the server and middleware available on this request.
		/// </summary>
		public override Features.IFeatureCollection Features {get;}

		/// <summary>
		///    Gets the <see cref="T:Microsoft.AspNetCore.Http.HttpRequest" /> object for this request.
		/// </summary>
		public override HttpRequest Request {get;}

		/// <summary>
		///    Gets the <see cref="T:Microsoft.AspNetCore.Http.HttpResponse" /> object for this request.
		/// </summary>
		public override HttpResponse Response {get;}

		/// <summary>
		///    Gets information about the underlying connection for this request.
		/// </summary>
		public override ConnectionInfo Connection {get;}

		/// <summary>
		///    Gets an object that manages the establishment of WebSocket connections for this request.
		/// </summary>
		public override WebSocketManager WebSockets {get;}

		/// <summary>
		///    This is obsolete and will be removed in a future version.
		///    The recommended alternative is to use Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.
		///    See https://go.microsoft.com/fwlink/?linkid=845470.
		/// </summary>
		[Obsolete]
		public override AuthenticationManager Authentication {get;}

		/// <summary>Gets or sets the user for this request.</summary>
		public override ClaimsPrincipal User {get; set;}

		/// <summary>
		///    Gets or sets a key/value collection that can be used to share data within the scope of this request.
		/// </summary>
		public override IDictionary<object, object> Items {get; set;}

		/// <summary>
		///    Gets or sets the <see cref="T:System.IServiceProvider" /> that provides access to the request's service container.
		/// </summary>
		public override IServiceProvider RequestServices {get; set;}

		/// <summary>
		///    Notifies when the connection underlying this request is aborted and thus request operations should be
		///    cancelled.
		/// </summary>
		public override CancellationToken RequestAborted {get; set;}

		/// <summary>
		///    Gets or sets a unique identifier to represent this request in trace logs.
		/// </summary>
		public override string TraceIdentifier {get; set;}

		/// <summary>
		///    Gets or sets the object used to manage user session data for this request.
		/// </summary>
		public override ISession Session
		{
			get => throw new NotImplementedException();
			set => throw new NotImplementedException();
		}
	}
}