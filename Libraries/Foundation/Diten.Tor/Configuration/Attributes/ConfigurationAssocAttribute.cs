#region Using Directives

using System;

#endregion

namespace Diten.Tor.Config
{
	/// <summary>
	///     Specifies the associated tor configuration name against an enumerator value.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field)]
	internal sealed class ConfigurationAssocAttribute : Attribute
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="ConfigurationAssocAttribute" /> class.
		/// </summary>
		/// <param name="name">The name of the configuration within the tor <c>torrc</c> configuration file.</param>
		public ConfigurationAssocAttribute(string name)
		{
			Default = null;
			Name = name;
			Type = null;
			Validation = ConfigurationValidation.None;
		}

		#region Properties

		/// <summary>
		///     Gets or sets the default value of the configuration.
		/// </summary>
		public object Default { get; set; }

		/// <summary>
		///     Gets the name of the configuration within the tor <c>torrc</c> configuration file.
		/// </summary>
		public string Name { get; }

		/// <summary>
		///     Gets or sets the type of value expected for the configuration.
		/// </summary>
		public Type Type { get; set; }

		/// <summary>
		///     Gets or sets the validation to perform against the configuration value.
		/// </summary>
		public ConfigurationValidation Validation { get; set; }

		#endregion
	}
}