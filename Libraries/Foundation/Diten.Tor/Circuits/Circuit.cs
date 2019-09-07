#region Using Directives

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Diten.Tor.Controller;

#endregion

namespace Diten.Tor
{
	/// <summary>
	///     A class containing information regarding a circuit within the tor service.
	/// </summary>
	public sealed class Circuit : MarshalByRefObject
	{
		private readonly Client client;
		private readonly object synchronize;

		private List<string> paths;

		/// <summary>
		///     Initializes a new instance of the <see cref="Circuit" /> class.
		/// </summary>
		/// <param name="client">The client for which the circuit belongs.</param>
		/// <param name="id">The unique identifier of the circuit within the tor session.</param>
		internal Circuit(Client client, int id)
		{
			BuildFlags = CircuitBuildFlags.None;
			this.client = client;
			HSState = CircuitHSState.None;
			ID = id;
			paths = new List<string>();
			Purpose = CircuitPurpose.None;
			Reason = CircuitReason.None;
			synchronize = new object();
			TimeCreated = DateTime.MinValue;
		}

		/// <summary>
		///     Sends a request to the associated tor client to close the circuit.
		/// </summary>
		/// <returns><c>true</c> if the circuit is closed successfully; otherwise, <c>false</c>.</returns>
		public bool Close()
		{
			return client.Controller.CloseCircuit(this);
		}

		/// <summary>
		///     Sends a request to the associated tor client to extend the circuit.
		/// </summary>
		/// <param name="routers">The list of identities or nicknames to extend onto this circuit.</param>
		/// <returns><c>true</c> if the circuit is extended successfully; otherwise, <c>false</c>.</returns>
		public bool Extend(params string[] routers)
		{
			return client.Controller.ExtendCircuit(this, routers);
		}

		/// <summary>
		///     Sends a request to the associated tor client to extend the circuit.
		/// </summary>
		/// <param name="routers">The list of routers to extend onto this circuit.</param>
		/// <returns><c>true</c> if the circuit is extended successfully; otherwise, <c>false</c>.</returns>
		public bool Extend(params Router[] routers)
		{
			var nicknames = new string[routers.Length];

			for (int i = 0, length = routers.Length; i < length; i++)
				nicknames[i] = routers[i].Nickname;

			return client.Controller.ExtendCircuit(this, nicknames);
		}

		/// <summary>
		///     Gets the routers associated with the circuit.
		/// </summary>
		/// <returns>A <see cref="RouterCollection" /> object instance.</returns>
		internal RouterCollection GetRouters()
		{
			lock (synchronize)
			{
				var routers = new List<Router>();

				if (paths == null || paths.Count == 0)
				{
					Routers = new RouterCollection(routers);
					return Routers;
				}

				foreach (var path in paths)
				{
					var trimmed = path;

					if (trimmed == null)
						continue;

					if (trimmed.StartsWith("$"))
						trimmed = trimmed.Substring(1);
					if (trimmed.Contains("~"))
						trimmed = trimmed.Substring(0, trimmed.IndexOf("~"));

					if (string.IsNullOrWhiteSpace(trimmed))
						continue;

					var command = new GetRouterStatusCommand(trimmed);
					var response = command.Dispatch(client);

					if (response.Success && response.Router != null)
						routers.Add(response.Router);
				}

				Routers = new RouterCollection(routers);
				return Routers;
			}
		}

		#region Properties

		/// <summary>
		///     Gets the build flags associated with the circuit.
		/// </summary>
		public CircuitBuildFlags BuildFlags { get; internal set; }

		/// <summary>
		///     Gets the hidden-service state of the circuit.
		/// </summary>
		public CircuitHSState HSState { get; internal set; }

		/// <summary>
		///     Gets the unique identifier of the circuit in the tor session.
		/// </summary>
		public int ID { get; }

		/// <summary>
		///     Gets the purpose of the circuit.
		/// </summary>
		public CircuitPurpose Purpose { get; internal set; }

		/// <summary>
		///     Gets the reason associated with the circuit, usually assigned upon closed or failed events.
		/// </summary>
		public CircuitReason Reason { get; internal set; }

		/// <summary>
		///     Gets the routers associated with the circuit.
		/// </summary>
		public RouterCollection Routers { get; private set; }

		/// <summary>
		///     Gets the status of the circuit.
		/// </summary>
		public CircuitStatus Status { get; internal set; }

		/// <summary>
		///     Gets the date and time the circuit was created.
		/// </summary>
		public DateTime TimeCreated { get; internal set; }

		/// <summary>
		///     Gets or sets the collection containing the paths associated with the circuit.
		/// </summary>
		internal List<string> Paths
		{
			get
			{
				lock (synchronize)
				{
					return paths;
				}
			}
			set
			{
				lock (synchronize)
				{
					paths = value;
				}
			}
		}

		#endregion
	}

	/// <summary>
	///     A class containing a read-only collection of <see cref="Circuit" /> objects.
	/// </summary>
	public sealed class CircuitCollection : ReadOnlyCollection<Circuit>
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="CircuitCollection" /> class.
		/// </summary>
		/// <param name="list">The list of circuits.</param>
		internal CircuitCollection(IList<Circuit> list) : base(list)
		{
		}
	}
}