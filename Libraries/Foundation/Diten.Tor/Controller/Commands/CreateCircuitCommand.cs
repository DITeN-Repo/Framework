﻿#region Using Directives

using System;
using System.Collections.Generic;
using System.Text;
using Diten.Tor.Helpers;

#endregion

namespace Diten.Tor.Controller
{
	/// <summary>
	///     A class containing the command to create a new circuit.
	/// </summary>
	internal sealed class CreateCircuitCommand : Command<CreateCircuitResponse>
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="CreateCircuitCommand" /> class.
		/// </summary>
		public CreateCircuitCommand()
		{
			Routers = new List<string>();
		}

		/// <summary>
		///     Initializes a new instance of the <see cref="CreateCircuitCommand" /> class.
		/// </summary>
		/// <param name="routers">The collection of routers which should be part of this circuit.</param>
		public CreateCircuitCommand(IEnumerable<string> routers)
		{
			Routers = new List<string>(routers);
		}

		#region Properties

		/// <summary>
		///     Gets a collection containing the list of routers which should be comprise this circuit.
		/// </summary>
		public List<string> Routers { get; }

		#endregion

		#region Tor.Controller.Command<>

		/// <summary>
		///     Dispatches the command to the client control port and produces a <typeparamref name="T" /> response result.
		/// </summary>
		/// <param name="connection">The control connection where the command should be dispatched.</param>
		/// <returns>
		///     A <typeparamref name="T" /> object instance containing the response data.
		/// </returns>
		protected override CreateCircuitResponse Dispatch(Connection connection)
		{
			var builder = new StringBuilder("extendcircuit 0");

			foreach (var router in Routers)
			{
				builder.Append(' ');
				builder.Append(router);
			}

			if (connection.Write(builder.ToString()))
			{
				var response = connection.Read();

				if (!response.Success)
					return new CreateCircuitResponse(false, -1);

				var parts = StringHelper.GetAll(response.Responses[0], ' ');

				if (parts.Length < 2 || !"extended".Equals(parts[0], StringComparison.CurrentCultureIgnoreCase))
					return new CreateCircuitResponse(false, -1);

				int circuitID;

				if (!int.TryParse(parts[1], out circuitID))
					return new CreateCircuitResponse(false, -1);

				return new CreateCircuitResponse(true, circuitID);
			}

			return new CreateCircuitResponse(false, -1);
		}

		#endregion
	}

	/// <summary>
	///     A class containing the response information from a <c>extendcircuit 0</c> command.
	/// </summary>
	internal sealed class CreateCircuitResponse : Response
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="CreateCircuitResponse" /> class.
		/// </summary>
		/// <param name="success">A value indicating whether the command was received and processed successfully.</param>
		/// <param name="circuitID">The unique circuit identifier within the tor service.</param>
		public CreateCircuitResponse(bool success, int circuitID) : base(success)
		{
			CircuitID = circuitID;
		}

		#region Properties

		/// <summary>
		///     Gets the unique circuit identifier.
		/// </summary>
		public int CircuitID { get; }

		#endregion
	}
}