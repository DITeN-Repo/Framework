﻿#region Using Directives

using System.ComponentModel;

#endregion

namespace Diten.Tor
{
	/// <summary>
	///     An enumerator containing the different units of bytes.
	/// </summary>
	public enum Bits
	{
		/// <summary>
		///     The unit is bytes.
		/// </summary>
		[Description("bytes")] B = 0,

		/// <summary>
		///     The unit is kilo-bytes.
		/// </summary>
		[Description("KBytes")] KB = 1,

		/// <summary>
		///     The unit is mega-bytes.
		/// </summary>
		[Description("MBytes")] MB = 2,

		/// <summary>
		///     The unit is giga-bytes.
		/// </summary>
		[Description("GBytes")] GB = 3,

		/// <summary>
		///     The unit is tera-bytes.
		/// </summary>
		[Description("TBytes")] TB = 4
	}
}