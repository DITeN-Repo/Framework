#region Using Directives

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Diten.Tor.Controller;

#endregion

namespace Diten.Tor.Status
{
	/// <inheritdoc />
	/// <summary>
	///     A class containing methods and properties for reading the status of the tor network service.
	/// </summary>
	[DebuggerStepThrough]
	public sealed class Status : MarshalByRefObject
	{
		private const int MaximumRecords = 30;

		private readonly List<Circuit> circuits;
		private readonly Client client;
		private readonly List<ORConnection> orConnections;
		private readonly List<Stream> streams;
		private readonly object synchronizeCircuits;
		private readonly object synchronizeORConnections;
		private readonly object synchronizeStreams;

		/// <inheritdoc />
		/// <summary>
		///     Initializes a new instance of the <see cref="T:Diten.Tor.Status.Status" /> class.
		/// </summary>
		/// <param name="client">The client for which this object instance belongs.</param>
		internal Status(Client client)
		{
			circuits = new List<Circuit>();
			this.client = client;
			orConnections = new List<ORConnection>();
			streams = new List<Stream>();
			synchronizeCircuits = new object();
			synchronizeORConnections = new object();
			synchronizeStreams = new object();
		}

		/// <summary>
		///     Gets a read-only collection of all ORs which the tor application has an opinion about. This method can be time,
		///     memory
		///     and CPU intensive, so should be used infrequently.
		/// </summary>
		/// <returns>
		///     A <see cref="RouterCollection" /> object instance containing the router information; otherwise, <c>null</c> if
		///     the request fails.
		/// </returns>
		public RouterCollection GetAllRouters()
		{
			var command = new GetAllRouterStatusCommand();
			var response = command.Dispatch(client);

			return response.Success ? response.Routers : null;
		}

		/// <summary>
		///     Gets a country code for an IP address. This method will not work unless a <c>geoip</c> and/or <c>geoip6</c> file
		///     has been supplied.
		/// </summary>
		/// <param name="ipAddress">The IP address which should be resolved.</param>
		/// <returns>
		///     A <see cref="System.String" /> containing the country code; otherwise, <c>null</c> if the country code could
		///     not be resolved.
		/// </returns>
		public string GetCountryCode(string ipAddress)
		{
			if (ipAddress == null)
				throw new ArgumentNullException("ipAddress");

			var command = new GetInfoCommand($"ip-to-country/{ipAddress}");
			var response = command.Dispatch(client);

			if (!response.Success) return null;
			var values = response.Values[0].Split(new[] {'='}, 2);

			return values.Length == 2 ? values[1].Trim() : null;
		}

		/// <summary>
		///     Gets a country code for a router within the tor network. This method will not work unless a <c>geoip</c> and/or
		///     <c>geoip6</c> file has been supplied.
		/// </summary>
		/// <param name="router">The router to retrieve the country code for.</param>
		/// <returns>
		///     A <see cref="System.String" /> containing the country code; otherwise, <c>null</c> if the country code could
		///     not be resolved.
		/// </returns>
		public string GetCountryCode(Router router)
		{
			if (router == null)
				throw new ArgumentNullException("router");

			var address = router.IPAddress.ToString();

			var command = new GetInfoCommand($"ip-to-country/{address}");
			var response = command.Dispatch(client);

			if (!response.Success) return null;
			var values = response.Values[0].Split(new[] {'='}, 2);

			return values.Length == 2 ? values[1].Trim() : values[0].Trim().ToUpper();
		}

		/// <summary>
		///     Gets a value indicating whether the tor software service is dormant.
		/// </summary>
		/// <returns><c>true</c> if the tor software service is dormant; otherwise, <c>false</c>.</returns>
		private bool PropertyGetIsDormant()
		{
			var command = new GetInfoCommand("dormant");
			var response = command.Dispatch(client);

			if (!response.Success)
				return false;

			if (!int.TryParse(response.Values[0], out var value))
				return false;

			return value != 0;
		}

		/// <summary>
		///     Gets an approximation of the total bytes downloaded by the tor software.
		/// </summary>
		/// <returns>A <see cref="Bytes" /> object instance containing the estimated number of bytes.</returns>
		private Bytes PropertyGetTotalBytesDownloaded()
		{
			var command = new GetInfoCommand("traffic/read");
			var response = command.Dispatch(client);

			if (!response.Success)
				return Bytes.Empty;

			return !double.TryParse(response.Values[0], out var value) ? Bytes.Empty : new Bytes(value).Normalize();
		}

		/// <summary>
		///     Gets an approximation of the total bytes uploaded by the tor software.
		/// </summary>
		/// <returns>A <see cref="Bytes" /> object instance containing the estimated number of bytes.</returns>
		private Bytes PropertyGetTotalBytesUploaded()
		{
			var command = new GetInfoCommand("traffic/written");
			var response = command.Dispatch(client);

			if (!response.Success)
				return Bytes.Empty;

			return !double.TryParse(response.Values[0], out var value) ? Bytes.Empty : new Bytes(value).Normalize();
		}

		/// <summary>
		///     Gets the version of the running tor application.
		/// </summary>
		/// <returns>A <see cref="Version" /> object instance containing the version.</returns>
		private Version PropertyGetVersion()
		{
			var command = new GetInfoCommand("version");
			var response = command.Dispatch(client);

			if (!response.Success)
				return new Version();

			var pattern =
				new Regex(@"(?<major>\d{1,})\.(?<minor>\d{1,})\.(?<build>\d{1,})\.(?<revision>\d{1,})(?:$|\s)");
			var match = pattern.Match(response.Values[0]);

			if (match.Success)
				return new Version(
					Convert.ToInt32(match.Groups["major"].Value),
					Convert.ToInt32(match.Groups["minor"].Value),
					Convert.ToInt32(match.Groups["build"].Value),
					Convert.ToInt32(match.Groups["revision"].Value)
				);

			return new Version();
		}

		/// <summary>
		///     Starts the status controller listening for changes within the tor client.
		/// </summary>
		public void Start()
		{
			client.Events.CircuitChanged += OnCircuitChanged;
			client.Events.ORConnectionChanged += OnORConnectionChanged;
			client.Events.StreamChanged += OnStreamChanged;
		}

		#region Properties

		/// <summary>
		///     Gets the current circuits configured against the tor client.
		/// </summary>
		public CircuitCollection Circuits
		{
			get
			{
				lock (synchronizeCircuits)
				{
					return new CircuitCollection(circuits);
				}
			}
		}

		/// <summary>
		///     Gets a value indicating whether the tor software service is dormant. A value of <c>true</c> indicates that
		///     the tor network has not been active for a while, or is dormant for some other reason.
		/// </summary>
		public bool IsDormant => PropertyGetIsDormant();

		/// <summary>
		///     Gets the current OR connections configured against the tor client.
		/// </summary>
		public ORConnectionCollection ORConnections
		{
			get
			{
				lock (synchronizeORConnections)
				{
					return new ORConnectionCollection(orConnections);
				}
			}
		}

		/// <summary>
		///     Gets the current streams configured against the tor client.
		/// </summary>
		public StreamCollection Streams
		{
			get
			{
				lock (synchronizeStreams)
				{
					return new StreamCollection(streams);
				}
			}
		}

		/// <summary>
		///     Gets an approximation of the total bytes downloaded by the tor software.
		/// </summary>
		public Bytes TotalBytesDownloaded => PropertyGetTotalBytesDownloaded();

		/// <summary>
		///     Gets an approximation of the total bytes uploaded by the tor software.
		/// </summary>
		public Bytes TotalBytesUploaded => PropertyGetTotalBytesUploaded();

		/// <summary>
		///     Gets the version number of the running tor application associated with this client.
		/// </summary>
		public Version Version => PropertyGetVersion();

		#endregion

		#region Events

		/// <summary>
		///     Occurs when the bandwidth download and upload values change within the tor service. These values are a report of
		///     the
		///     download and upload rates within the last second.
		/// </summary>
		public event BandwidthEventHandler BandwidthChanged
		{
			add => client.Events.BandwidthChanged += value;
			remove => client.Events.BandwidthChanged -= value;
		}

		/// <summary>
		///     Occurs when the circuits have been updated.
		/// </summary>
		public event EventHandler CircuitsChanged;

		/// <summary>
		///     Occurs when the OR connections have been updated.
		/// </summary>
		public event EventHandler ORConnectionsChanged;

		/// <summary>
		///     Occurs when the streams have been updated.
		/// </summary>
		public event EventHandler StreamsChanged;

		#endregion

		#region Tor.Events.Events

		/// <summary>
		///     Called when a circuit changes within the tor service.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="CircuitEventArgs" /> instance containing the event data.</param>
		private void OnCircuitChanged(object sender, CircuitEventArgs e)
		{
			if (e.Circuit == null)
				return;

			lock (synchronizeCircuits)
			{
				var existing = circuits.FirstOrDefault(c => c.ID == e.Circuit.ID);

				if (existing == null)
				{
					if (MaximumRecords <= circuits.Count)
					{
						var removal = circuits.FirstOrDefault(c =>
							c.Status == CircuitStatus.Closed || c.Status == CircuitStatus.Failed);

						if (removal == null)
							return;

						circuits.Remove(removal);
					}

					existing = e.Circuit;
					existing.GetRouters();
					circuits.Add(existing);
				}
				else
				{
					var update = existing.Paths.Count != e.Circuit.Paths.Count ||
					             e.Circuit.Status == CircuitStatus.Extended;

					existing.BuildFlags = e.Circuit.BuildFlags;
					existing.HSState = e.Circuit.HSState;
					existing.Paths = e.Circuit.Paths;
					existing.Purpose = e.Circuit.Purpose;
					existing.Reason = e.Circuit.Reason;
					existing.Status = e.Circuit.Status;
					existing.TimeCreated = e.Circuit.TimeCreated;

					if (update)
						existing.GetRouters();
				}
			}

			CircuitsChanged?.Invoke(client, EventArgs.Empty);
		}

		/// <summary>
		///     Called when an OR connection changes within the tor service.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="ORConnectionEventArgs" /> instance containing the event data.</param>
		private void OnORConnectionChanged(object sender, ORConnectionEventArgs e)
		{
			if (e.Connection == null)
				return;

			lock (synchronizeORConnections)
			{
				var existing = e.Connection.ID != 0
					? orConnections.FirstOrDefault(o => o.ID == e.Connection.ID)
					: orConnections.FirstOrDefault(o =>
						o.Target.Equals(e.Connection.Target, StringComparison.CurrentCultureIgnoreCase));

				if (existing == null)
				{
					if (MaximumRecords <= orConnections.Count)
					{
						var removal = orConnections.FirstOrDefault(o =>
							o.Status == ORStatus.Closed || o.Status == ORStatus.Failed);

						if (removal == null)
							return;

						orConnections.Remove(removal);
					}

					existing = e.Connection;
					orConnections.Add(existing);
				}
				else
				{
					existing.CircuitCount = e.Connection.CircuitCount;
					existing.ID = e.Connection.ID;
					existing.Reason = e.Connection.Reason;
					existing.Status = e.Connection.Status;
					existing.Target = e.Connection.Target;
				}
			}

			ORConnectionsChanged?.Invoke(client, EventArgs.Empty);
		}

		/// <summary>
		///     Called when a stream changes within the tor service.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="StreamEventArgs" /> instance containing the event data.</param>
		private void OnStreamChanged(object sender, StreamEventArgs e)
		{
			if (e.Stream == null)
				return;

			lock (synchronizeStreams)
			{
				var existing = streams.FirstOrDefault(s => s.ID == e.Stream.ID);

				if (existing == null)
				{
					if (MaximumRecords <= streams.Count)
					{
						var removal = streams.FirstOrDefault(s =>
							s.Status == StreamStatus.Closed || s.Status == StreamStatus.Failed);

						if (removal == null)
							return;

						streams.Remove(removal);
					}

					existing = e.Stream;
					streams.Add(existing);
				}
				else
				{
					existing.CircuitID = e.Stream.CircuitID;
					existing.Purpose = e.Stream.Purpose;
					existing.Reason = e.Stream.Reason;
					existing.Status = e.Stream.Status;
				}
			}

			StreamsChanged?.Invoke(client, EventArgs.Empty);
		}

		#endregion
	}
}