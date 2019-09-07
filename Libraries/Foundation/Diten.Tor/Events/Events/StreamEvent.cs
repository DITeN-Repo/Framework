#region Using Directives

using System;

#endregion

namespace Diten.Tor
{
	/// <summary>
	///     A class containing information regarding a stream status changing.
	/// </summary>
	public sealed class StreamEventArgs : EventArgs
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="StreamEventArgs" /> class.
		/// </summary>
		/// <param name="stream">The stream which was changed.</param>
		public StreamEventArgs(Stream stream)
		{
			Stream = stream;
		}

		#region Properties

		/// <summary>
		///     Gets the stream which was changed.
		/// </summary>
		public Stream Stream { get; }

		#endregion
	}

	/// <summary>
	///     Represents the method that will handle a stream changed event.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The <see cref="StreamEventArgs" /> instance containing the event data.</param>
	public delegate void StreamEventHandler(object sender, StreamEventArgs e);
}