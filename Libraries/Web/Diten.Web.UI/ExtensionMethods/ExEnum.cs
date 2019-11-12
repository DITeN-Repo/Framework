#region Using Directives

using System.ComponentModel;
using Diten.Web.UI.WebControls;

#endregion

namespace Diten.Web.UI
{
	/// <summary>
	///     Enum extension methods class.
	/// </summary>
	/// <inheritdoc cref="http://help.diten.net/?Cat=Framework&Type=Diten_Enum" />
	public static class ExEnum
	{
		public static int GetDimension(this Icon.Dimensions dimension)
		{
			if (!System.Enum.IsDefined(typeof(Icon.Dimensions), dimension))
				throw new InvalidEnumArgumentException(nameof(dimension), (int) dimension, typeof(Icon.Dimensions));

			return int.Parse(dimension.ToString().Replace("D", string.Empty));
		}
	}
}