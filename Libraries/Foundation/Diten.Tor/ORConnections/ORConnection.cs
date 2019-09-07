#region Using Directives

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#endregion

namespace Diten.Tor
{
	/// <summary>
	///     A class containing information regarding an OR connection within the tor service.
	/// </summary>
	[Serializable]
	public sealed class ORConnection
	{
		private int circuitCount;
		private int id;
		private ORReason reason;
		private ORStatus status;
		private string target;

		/// <summary>
		///     Initializes a new instance of the <see cref="ORConnection" /> class.
		/// </summary>
		internal ORConnection()
		{
			circuitCount = 0;
			id = 0;
			reason = ORReason.None;
			status = ORStatus.None;
			target = "";
		}

		#region Properties

		/// <summary>
		///     Gets the number of established and pending circuits.
		/// </summary>
		public int CircuitCount
		{
			get => circuitCount;
			internal set => circuitCount = value;
		}

		/// <summary>
		///     Gets the unique identifier of the connection. This value is only provided in version 0.2.5.2-alpha.
		/// </summary>
		public int ID
		{
			get => id;
			internal set => id = value;
		}

		/// <summary>
		///     Gets the reason for an <c>ORStatus.Closed</c> or <c>ORStatus.Failed</c> state.
		/// </summary>
		public ORReason Reason
		{
			get => reason;
			internal set => reason = value;
		}

		/// <summary>
		///     Gets the status of the connection.
		/// </summary>
		public ORStatus Status
		{
			get => status;
			internal set => status = value;
		}

		/// <summary>
		///     Gets the target of the connection.
		/// </summary>
		public string Target
		{
			get => target;
			internal set => target = value;
		}

		#endregion
	}

	/// <summary>
	///     A class containing a read-only collection of <see cref="ORConnection" /> objects.
	/// </summary>
	public sealed class ORConnectionCollection : ReadOnlyCollection<ORConnection>
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="ORConnectionCollection" /> class.
		/// </summary>
		/// <param name="list">The list of OR connections.</param>
		internal ORConnectionCollection(IList<ORConnection> list) : base(list)
		{
		}
	}
}