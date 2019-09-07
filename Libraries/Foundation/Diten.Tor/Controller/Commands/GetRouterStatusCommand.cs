#region Using Directives

using System;
using System.ComponentModel;
using System.Net;
using Diten.Tor.Helpers;

#endregion

namespace Diten.Tor.Controller
{
	/// <summary>
	///     A class containing the command to retrieve router status information.
	/// </summary>
	internal sealed class GetRouterStatusCommand : Command<GetRouterStatusResponse>
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="GetRouterStatusCommand" /> class.
		/// </summary>
		public GetRouterStatusCommand() : this(null)
		{
		}

		/// <summary>
		///     Initializes a new instance of the <see cref="GetRouterStatusCommand" /> class.
		/// </summary>
		/// <param name="identity">The router identity to retrieve status information for.</param>
		public GetRouterStatusCommand(string identity)
		{
			Identity = identity;
		}

		#region Properties

		/// <summary>
		///     Gets or sets the identity of the router.
		/// </summary>
		public string Identity { get; }

		#endregion

		#region Tor.Controller.Command<>

		/// <summary>
		///     Dispatches the command to the client control port and produces a <typeparamref name="T" /> response result.
		/// </summary>
		/// <param name="connection"></param>
		/// <returns>
		///     A <typeparamref name="T" /> object instance containing the response data.
		/// </returns>
		protected override GetRouterStatusResponse Dispatch(Connection connection)
		{
			if (Identity == null)
				return new GetRouterStatusResponse(false, null);

			var request = $"ns/id/{Identity}";

			if (connection.Write("getinfo {0}", request))
			{
				var response = connection.Read();

				if (!response.Success ||
				    !response.Responses[0].StartsWith(request, StringComparison.CurrentCultureIgnoreCase))
					return new GetRouterStatusResponse(false, null);

				Router router = null;

				foreach (var line in response.Responses)
				{
					var stripped = line.Trim();

					if (string.IsNullOrWhiteSpace(stripped))
						continue;

					if (stripped.StartsWith("r"))
					{
						var values = stripped.Split(' ');

						if (values.Length < 9)
							continue;

						var publication = DateTime.MinValue;

						if (!DateTime.TryParse($"{values[4]} {values[5]}", out publication))
							publication = DateTime.MinValue;

						var orPort = 0;

						if (!int.TryParse(values[7], out orPort))
							orPort = 0;

						var dirPort = 0;

						if (!int.TryParse(values[8], out dirPort))
							dirPort = 0;

						IPAddress ipAddress = null;

						if (!IPAddress.TryParse(values[6], out ipAddress))
							ipAddress = null;

						router = new Router();
						router.Digest = values[3];
						router.DIRPort = dirPort;
						router.Identity = values[2];
						router.IPAddress = ipAddress;
						router.Nickname = values[1];
						router.ORPort = orPort;
						router.Publication = publication;
						continue;
					}

					if (stripped.StartsWith("s") && router != null)
					{
						var values = stripped.Split(' ');

						for (int i = 1, length = values.Length; i < length; i++)
						{
							var flag = ReflectionHelper.GetEnumerator<RouterFlags, DescriptionAttribute>(attr =>
								values[i].Equals(attr.Description, StringComparison.CurrentCultureIgnoreCase));

							if (flag != RouterFlags.None)
								router.Flags |= flag;
						}

						continue;
					}

					if (stripped.StartsWith("w") && router != null)
					{
						var values = stripped.Split(' ');

						if (values.Length < 2 ||
						    !values[1].StartsWith("bandwidth=", StringComparison.CurrentCultureIgnoreCase))
							continue;

						var value = values[1].Split(new[] {'='}, 2);

						if (value.Length < 2)
							continue;

						int bandwidth;

						if (int.TryParse(value[1].Trim(), out bandwidth))
							router.Bandwidth = new Bytes(bandwidth, Bits.KB).Normalize();
					}
				}

				return new GetRouterStatusResponse(true, router);
			}

			return new GetRouterStatusResponse(false, null);
		}

		#endregion
	}

	/// <summary>
	///     A class containing the response information from a <c>getinfo ns/id/?</c> command.
	/// </summary>
	internal sealed class GetRouterStatusResponse : Response
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="GetRouterStatusResponse" /> class.
		/// </summary>
		/// <param name="success">A value indicating whether the command was received and processed successfully.</param>
		/// <param name="router">The router information retrieved from the command.</param>
		public GetRouterStatusResponse(bool success, Router router) : base(success)
		{
			Router = router;
		}

		#region Properties

		/// <summary>
		///     Gets the router information retrieved from the control connection.
		/// </summary>
		public Router Router { get; }

		#endregion
	}
}