#region Using Directives

using System;
using System.ComponentModel;
using Diten.Tor.Helpers;

#endregion

namespace Diten.Tor.Events
{
	/// <summary>
	///     A class containing the logic for dispatching an OR connection changed event.
	/// </summary>
	[EventAssoc(Event.ORConnections)]
	internal sealed class ORConnectionDispatcher : Dispatcher
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
			string target;
			ORStatus status;
			var parts = StringHelper.GetAll(line, ' ');

			if (parts.Length < 2)
				return false;

			target = parts[0];
			status = ReflectionHelper.GetEnumerator<ORStatus, DescriptionAttribute>(attr =>
				parts[1].Equals(attr.Description, StringComparison.CurrentCultureIgnoreCase));

			var connection = new ORConnection();
			connection.Status = status;
			connection.Target = target;

			for (var i = 2; i < parts.Length; i++)
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
					connection.Reason = ReflectionHelper.GetEnumerator<ORReason, DescriptionAttribute>(attr =>
						value.Equals(attr.Description, StringComparison.CurrentCultureIgnoreCase));
					continue;
				}

				if ("NCIRCS".Equals(name, StringComparison.CurrentCultureIgnoreCase))
				{
					int circuits;

					if (int.TryParse(value, out circuits))
						connection.CircuitCount = circuits;

					continue;
				}

				if ("ID".Equals(name, StringComparison.CurrentCultureIgnoreCase))
				{
					int id;

					if (int.TryParse(value, out id))
						connection.ID = id;
				}
			}

			Client.Events.OnORConnectionChanged(new ORConnectionEventArgs(connection));
			return true;
		}

		#endregion
	}
}