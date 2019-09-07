#region Using Directives

using System;

#endregion

namespace Diten.Tor
{
	/// <summary>
	///     A class containing information regarding bandwidth values changing.
	/// </summary>
	[Serializable]
	public sealed class BandwidthEventArgs : EventArgs
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="BandwidthEventArgs" /> class.
		/// </summary>
		/// <param name="downloaded">The bytes downloaded.</param>
		/// <param name="uploaded">The bytes uploaded.</param>
		public BandwidthEventArgs(Bytes downloaded, Bytes uploaded)
		{
			Downloaded = downloaded;
			Uploaded = uploaded;
		}

		#region Properties

		/// <summary>
		///     Gets the bytes downloaded.
		/// </summary>
		public Bytes Downloaded { get; }

		/// <summary>
		///     Gets the bytes uploaded.
		/// </summary>
		public Bytes Uploaded { get; }

		#endregion
	}

	/// <summary>
	///     Represents the method that will handle a bandwidth changed event.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The <see cref="BandwidthEventArgs" /> instance containing the event data.</param>
	public delegate void BandwidthEventHandler(object sender, BandwidthEventArgs e);
}