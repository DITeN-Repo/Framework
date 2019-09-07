#region Using Directives

using System.Collections.Generic;
using System.Collections.ObjectModel;

#endregion

namespace Diten.Tor.Controller
{
	/// <summary>
	///     A class containing information regarding a response received back from a control connection.
	/// </summary>
	internal sealed class ConnectionResponse
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="ConnectionResponse" /> class.
		/// </summary>
		/// <param name="code">The status code returned by the control connection.</param>
		public ConnectionResponse(StatusCode code)
		{
			StatusCode = code;
			Responses = new List<string>().AsReadOnly();
		}

		/// <summary>
		///     Initializes a new instance of the <see cref="ConnectionResponse" /> class.
		/// </summary>
		/// <param name="code">The status code returned by the control connection.</param>
		/// <param name="responses">The responses received back from the control connection.</param>
		public ConnectionResponse(StatusCode code, IList<string> responses)
		{
			StatusCode = code;
			Responses = new ReadOnlyCollection<string>(responses);
		}

		#region Properties

		/// <summary>
		///     Gets a read-only collection of responses received from the control connection.
		/// </summary>
		public ReadOnlyCollection<string> Responses { get; }

		/// <summary>
		///     Gets the status code returned with the response.
		/// </summary>
		public StatusCode StatusCode { get; }

		/// <summary>
		///     Gets a value indicating whether the response was successful feedback.
		/// </summary>
		public bool Success => StatusCode == StatusCode.OK;

		#endregion
	}
}