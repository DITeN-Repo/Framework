#region Using Directives

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#endregion

namespace Diten.Tor.Controller
{
	/// <summary>
	///     A class containing the command to get network information from the tor service.
	/// </summary>
	internal sealed class GetInfoCommand : Command<GetInfoResponse>
	{
		private readonly string request;

		/// <summary>
		///     Initializes a new instance of the <see cref="GetInfoCommand" /> class.
		/// </summary>
		public GetInfoCommand()
		{
			request = null;
		}

		/// <summary>
		///     Initializes a new instance of the <see cref="GetInfoCommand" /> class.
		/// </summary>
		/// <param name="request">The request to send with the <c>getinfo</c> command.</param>
		public GetInfoCommand(string request)
		{
			this.request = request;
		}

		#region Tor.Controller.Command<>

		/// <summary>
		///     Dispatches the command to the client control port and produces a <typeparamref name="T" /> response result.
		/// </summary>
		/// <param name="connection">The control connection where the command should be dispatched.</param>
		/// <returns>
		///     A <typeparamref name="T" /> object instance containing the response data.
		/// </returns>
		protected override GetInfoResponse Dispatch(Connection connection)
		{
			if (request == null)
				return new GetInfoResponse(false);

			if (connection.Write("getinfo {0}", request))
			{
				var response = connection.Read();

				if (!response.Success ||
				    !response.Responses[0].StartsWith(request, StringComparison.CurrentCultureIgnoreCase))
					return new GetInfoResponse(false);

				var values = new List<string>(response.Responses.Count);

				if (response.Responses.Count == 1)
				{
					var parts = response.Responses[0].Split(new[] {'='}, 2);
					values.Add(parts.Length == 1 ? null : parts[1]);
				}
				else
				{
					for (var i = 1; i < response.Responses.Count; i++)
					{
						if (".".Equals(response.Responses[i]))
							break;

						values.Add(response.Responses[i]);
					}
				}

				return new GetInfoResponse(true, values.AsReadOnly());
			}

			return new GetInfoResponse(false);
		}

		#endregion
	}

	/// <summary>
	///     A class containing the response values for a <c>getinfo</c> command.
	/// </summary>
	internal sealed class GetInfoResponse : Response
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="GetInfoResponse" /> class.
		/// </summary>
		/// <param name="success">A value indicating whether the command was received and processed successfully.</param>
		public GetInfoResponse(bool success) : base(success)
		{
			Values = new List<string>().AsReadOnly();
		}

		/// <summary>
		///     Initializes a new instance of the <see cref="GetInfoResponse" /> class.
		/// </summary>
		/// <param name="success">A value indicating whether the command was received and processed successfully.</param>
		/// <param name="values">The values returned from the control connection.</param>
		public GetInfoResponse(bool success, ReadOnlyCollection<string> values) : base(success)
		{
			Values = values;
		}

		#region Properties

		/// <summary>
		///     Gets a read-only collection of the values returned from the control connection.
		/// </summary>
		public ReadOnlyCollection<string> Values { get; }

		#endregion
	}
}