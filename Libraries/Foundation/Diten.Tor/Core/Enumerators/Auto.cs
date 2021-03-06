﻿#region Using Directives

using System.ComponentModel;

#endregion

namespace Diten.Tor
{
	/// <summary>
	///     An enumerator which extends the <see cref="bool" /> primitive type to accept an automatic state.
	/// </summary>
	public enum Auto
	{
		/// <summary>
		///     The value should be determined automatically.
		/// </summary>
		[Description("auto")] Auto = -1,

		/// <summary>
		///     The value is <c>false</c>.
		/// </summary>
		[Description("0")] False = 0,

		/// <summary>
		///     The value is <c>true</c>.
		/// </summary>
		[Description("1")] True = 1
	}
}