﻿#region Using Directives

using System;
using System.Collections.Generic;

#endregion

namespace Diten.Tor.Events
{
	/// <summary>
	///     A class containing the logic for parsing a config-changed event.
	/// </summary>
	[EventAssoc(Event.ConfigChanged)]
	internal sealed class ConfigChangedDispatcher : Dispatcher
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

			var configurations = new Dictionary<string, string>(lines.Length);

			foreach (var part in lines)
			{
				var trimmed = part.Trim();

				if (trimmed.Length == 0)
					continue;

				if (trimmed.StartsWith("650"))
					trimmed = trimmed.Substring(3);
				if (trimmed.Length > 0 && trimmed[0] == '-')
					trimmed = trimmed.Substring(1);

				if (trimmed.Length == 0)
					continue;

				var values = trimmed.Split(new[] {'='}, 2);

				if (values.Length == 1)
					configurations[values[0].Trim()] = null;
				else
					configurations[values[0].Trim()] = values[1].Trim();
			}

			Client.Events.OnConfigurationChanged(new ConfigurationChangedEventArgs(configurations));

			return false;
		}

		#endregion
	}
}