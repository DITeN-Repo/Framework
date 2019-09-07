#region Using Directives

using System;
using System.ComponentModel;
using Diten.Tor.Helpers;

#endregion

namespace Diten.Tor.Events
{
	/// <summary>
	///     A class containing the logic for processing a stream-status event.
	/// </summary>
	[EventAssoc(Event.Streams)]
	internal sealed class StreamDispatcher : Dispatcher
	{
		#region Tor.Events.Dispatcher

		/// <summary>
		///     Dispatches the event, parsing the content of the line and raising the relevant event.
		/// </summary>
		/// <param name="line">The line which was received from the control connection.</param>
		/// <returns>
		///     <c>true</c> if the event is parsed and dispatched successfully; otherwise, <c>false</c>.
		/// </returns>
		public override bool Dispatch(string line)
		{
			int streamID;
			int circuitID;
			int port;
			StreamStatus status;
			Host target;
			var parts = StringHelper.GetAll(line, ' ');

			if (parts.Length < 4)
				return false;

			if ("Tor_internal".Equals(parts[3], StringComparison.CurrentCultureIgnoreCase))
				return false;

			if (!int.TryParse(parts[0], out streamID))
				return false;

			if (!int.TryParse(parts[2], out circuitID))
				return false;

			var targetParts = parts[3].Split(new[] {':'}, 2);

			if (targetParts.Length < 2)
				return false;

			if (!int.TryParse(targetParts[1], out port))
				return false;

			status = ReflectionHelper.GetEnumerator<StreamStatus, DescriptionAttribute>(attr =>
				parts[1].Equals(attr.Description, StringComparison.CurrentCultureIgnoreCase));
			target = new Host(targetParts[0], port);

			var stream = new Stream(Client, streamID, target);
			stream.CircuitID = circuitID;
			stream.Status = status;

			for (var i = 4; i < parts.Length; i++)
			{
				var data = parts[i].Trim();

				if (!data.Contains("="))
					continue;

				var values = data.Split(new[] {'='}, 2);

				if (values.Length < 2)
					continue;

				var name = values[0].Trim();
				var value = values[1].Trim();

				if ("REASON".Equals(name, StringComparison.CurrentCultureIgnoreCase))
				{
					stream.Reason = ReflectionHelper.GetEnumerator<StreamReason, DescriptionAttribute>(attr =>
						value.Equals(attr.Description, StringComparison.CurrentCultureIgnoreCase));
					continue;
				}

				if ("PURPOSE".Equals(name, StringComparison.CurrentCultureIgnoreCase))
					stream.Purpose = ReflectionHelper.GetEnumerator<StreamPurpose, DescriptionAttribute>(attr =>
						value.Equals(attr.Description, StringComparison.CurrentCultureIgnoreCase));
			}

			Events.OnStreamChanged(new StreamEventArgs(stream));
			return true;
		}

		#endregion
	}
}