#region Using Directives

using System.IO;

#endregion

namespace Diten.Web.UI
{
	public static class ExStream
	{
		/// <summary>
		///     Converting an <see cref="Stream" /> that contains string into <see cref="string" />
		/// </summary>
		/// <param name="value">An <see cref="Stream" /> that contains <see cref="string" /></param>
		/// <returns>An <see cref="string" /> value that is contained in <see cref="string" /></returns>
		public static string ToString(this Stream value)
		{
			return Convert.ToString(value);
		}
	}
}