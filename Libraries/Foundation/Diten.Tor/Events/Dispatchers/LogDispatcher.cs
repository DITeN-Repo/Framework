#region Using Directives

using System;

#endregion

namespace Diten.Tor.Events
{
	/// <summary>
	///     A class containing the logic for parsing a log message event.
	/// </summary>
	[EventAssoc(Event.LogDebug | Event.LogError | Event.LogInfo | Event.LogNotice | Event.LogWarn)]
	internal sealed class LogDispatcher : Dispatcher
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
			var lines = line.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);

			if (lines.Length == 0)
				return false;

			foreach (var value in lines)
			{
				var trimmed = value.Trim();

				if (trimmed.Length == 0 || trimmed.Equals("."))
					continue;
				if (trimmed.StartsWith("250"))
					continue;

				Client.Events.OnLogReceived(new LogEventArgs(trimmed), CurrentEvent);
			}

			return true;
		}

		#endregion
	}
}