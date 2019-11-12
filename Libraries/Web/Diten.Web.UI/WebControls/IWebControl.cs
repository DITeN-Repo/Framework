#region Using Directives

using System.Diagnostics.CodeAnalysis;

#endregion

namespace Diten.Web.UI.WebControls
{
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public interface IWebControlInterface
	{
		/// <summary>
		///     Get or Set icon.
		/// </summary>
		// ReSharper disable once InconsistentNaming
		Icons DTIcon { get; set; }

		/// <summary>
		///     Holder of the icon object.
		/// </summary>
		Icon IconHolder { get; }

		/// <summary>
		///     Get a reference to the <inheritdoc cref="Page" /> instance that contains the server control.
		/// </summary>
		Page Page { get; }
	}
}