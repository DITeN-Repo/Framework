#region Using Directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Diten.Tor.Helpers;

#endregion

namespace Diten.Tor.Events
{
	/// <summary>
	///     A class containing the logic for parsing a circuit-status event.
	/// </summary>
	[EventAssoc(Event.Circuits)]
	internal sealed class CircuitDispatcher : Dispatcher
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
			var index = 0;
			var circuitID = 0;
			var parts = StringHelper.GetAll(line, ' ');
			Circuit circuit = null;
			var routers = new List<string>();

			if (parts == null || parts.Length < 2)
				return false;

			if (!int.TryParse(parts[0], out circuitID))
				return false;

			circuit = new Circuit(Client, circuitID);
			circuit.Status = ReflectionHelper.GetEnumerator<CircuitStatus, DescriptionAttribute>(attr =>
				parts[1].Equals(attr.Description, StringComparison.CurrentCultureIgnoreCase));

			for (int i = 2, length = parts.Length; i < length; i++)
			{
				var data = parts[i];

				index += data.Length + 1;
				data = data.Trim();

				if (!data.Contains("="))
				{
					routers.AddRange(data.Split(','));
					continue;
				}

				var values = data.Split(new[] {'='}, 2);
				var name = values[0].Trim();
				var value = values[1].Trim();

				if (name.Equals("BUILD_FLAGS"))
				{
					var flags = value.Split(',');

					foreach (var flag in flags)
						circuit.BuildFlags |=
							ReflectionHelper.GetEnumerator<CircuitBuildFlags, DescriptionAttribute>(attr =>
								flag.Equals(attr.Description, StringComparison.CurrentCultureIgnoreCase));
				}
				else
				{
					switch (name)
					{
						case "HS_STATE":
							circuit.HSState = ReflectionHelper.GetEnumerator<CircuitHSState, DescriptionAttribute>(
								attr => value.Equals(attr.Description, StringComparison.CurrentCultureIgnoreCase));
							break;
						case "PURPOSE":
							circuit.Purpose = ReflectionHelper.GetEnumerator<CircuitPurpose, DescriptionAttribute>(
								attr => value.Equals(attr.Description, StringComparison.CurrentCultureIgnoreCase));
							break;
						case "REASON":
							circuit.Reason = ReflectionHelper.GetEnumerator<CircuitReason, DescriptionAttribute>(attr =>
								value.Equals(attr.Description, StringComparison.CurrentCultureIgnoreCase));
							break;
						case "TIME_CREATED":
							DateTime timeCreated;
							if (DateTime.TryParse(value, out timeCreated))
								circuit.TimeCreated = timeCreated;
							else
								circuit.TimeCreated = DateTime.MinValue;
							break;
					}
				}
			}

			circuit.Paths = routers;

			Events.OnCircuitChanged(new CircuitEventArgs(circuit));

			return true;
		}

		#endregion
	}
}