﻿#region Using Directives

using System.Collections.Generic;
using System.Text;

#endregion

namespace Diten.Tor.Controller
{
	/// <summary>
	///     A class containing the command responsible for extending a circuit.
	/// </summary>
	internal class ExtendCircuitCommand : Command<Response>
	{
		private readonly Circuit circuit;

		/// <summary>
		///     Initializes a new instance of the <see cref="ExtendCircuitCommand" /> class.
		/// </summary>
		/// <param name="circuit">The circuit which should be the target of extension. A <c>null</c> value indicates a new circuit.</param>
		public ExtendCircuitCommand(Circuit circuit)
		{
			this.circuit = circuit;
			Routers = new List<string>();
		}

		#region Properties

		/// <summary>
		///     Gets a collection containing the list of routers which should be extended onto this circuit.
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
		protected override Response Dispatch(Connection connection)
		{
			if (Routers.Count == 0)
				return new Response(false);

			var circuitID = 0;

			if (circuit != null)
				circuitID = circuit.ID;

			var builder = new StringBuilder("extendcircuit");
			builder.AppendFormat(" {0}", circuitID);

			foreach (var router in Routers)
				builder.AppendFormat(" {0}", router);

			if (connection.Write(builder.ToString()))
			{
				var response = connection.Read();
				return new Response(response.Success);
			}

			return new Response(false);
		}

		#endregion
	}
}