#region Using Directives

using System;
using System.Collections.Generic;

#endregion

namespace Diten.Tor.Events
{
	/// <summary>
	///     A class containing information regarding configuration values changing.
	/// </summary>
	public sealed class ConfigurationChangedEventArgs : EventArgs
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="ConfigurationChangedEventArgs" /> class.
		/// </summary>
		/// <param name="configurations">The configurations which were changed.</param>
		internal ConfigurationChangedEventArgs(Dictionary<string, string> configurations)
		{
			Configurations = configurations;
		}

		#region Properties

		/// <summary>
		///     Gets the configurations which were changed.
		/// </summary>
		public Dictionary<string, string> Configurations { get; }

		#endregion
	}

	/// <summary>
	///     Represents the method that will handle a configuration changed event.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The <see cref="ConfigurationChangedEventArgs" /> instance containing the event data.</param>
	public delegate void ConfigurationChangedEventHandler(object sender, ConfigurationChangedEventArgs e);
}