#region Using Directives

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#endregion

namespace Diten.Tor
{
	/// <summary>
	///     A class containing information about an active or inactive stream within the tor network service.
	/// </summary>
	public sealed class Stream : MarshalByRefObject
	{
		private readonly Client client;

		/// <summary>
		///     Initializes a new instance of the <see cref="Stream" /> class.
		/// </summary>
		/// <param name="client">The client for which the stream belongs.</param>
		/// <param name="id">The unique identifier of the stream within the tor session.</param>
		/// <param name="target">The target of the stream.</param>
		internal Stream(Client client, int id, Host target)
		{
			CircuitID = 0;
			this.client = client;
			ID = id;
			Purpose = StreamPurpose.None;
			Reason = StreamReason.None;
			Status = StreamStatus.None;
			Target = target;
		}

		/// <summary>
		///     Closes the stream.
		/// </summary>
		/// <returns><c>true</c> if the stream is closed successfully; otherwise, <c>false</c>.</returns>
		public bool Close()
		{
			return client.Controller.CloseStream(this, StreamReason.Misc);
		}

		#region Properties

		/// <summary>
		///     Gets the unique identifier of the circuit which owns this stream. This will be zero if the stream has been
		///     detached.
		/// </summary>
		public int CircuitID { get; internal set; }

		/// <summary>
		///     Gets the unique identifier of the stream in the tor session.
		/// </summary>
		public int ID { get; }

		/// <summary>
		///     Gets the purpose for the stream. This will be <c>StreamPurpose.None</c> unless extended events are enabled.
		/// </summary>
		public StreamPurpose Purpose { get; internal set; }

		/// <summary>
		///     Gets the reason for the stream being closed, failed or detached. This will be <c>StreamReason.None</c> until the
		///     stream
		///     has reached either of the aforementioned states.
		/// </summary>
		public StreamReason Reason { get; internal set; }

		/// <summary>
		///     Gets the status of the stream.
		/// </summary>
		public StreamStatus Status { get; internal set; }

		/// <summary>
		///     Gets the target of the stream.
		/// </summary>
		public Host Target { get; }

		#endregion
	}

	/// <summary>
	///     A class containing a read-only collection of <see cref="Stream" /> objects.
	/// </summary>
	public sealed class StreamCollection : ReadOnlyCollection<Stream>
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="StreamCollection" /> class.
		/// </summary>
		/// <param name="list">The list of streams.</param>
		internal StreamCollection(IList<Stream> list) : base(list)
		{
		}
	}
}