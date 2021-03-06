﻿#region Using Directives

using System;

#endregion

namespace Diten.Tor
{
	/// <summary>
	///     A class containing information regarding a log message received from a client.
	/// </summary>
	public sealed class LogEventArgs : EventArgs
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="LogEventArgs" /> class.
		/// </summary>
		/// <param name="message">The message which was received.</param>
		public LogEventArgs(string message)
		{
			Message = message;
		}

		#region Properties

		/// <summary>
		///     Gets the message which was received.
		/// </summary>
		public string Message { get; }

		#endregion
	}

	/// <summary>
	///     Represents the method that will handle a log message event.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The <see cref="LogEventArgs" /> instance containing the event data.</param>
	public delegate void LogEventHandler(object sender, LogEventArgs e);
}