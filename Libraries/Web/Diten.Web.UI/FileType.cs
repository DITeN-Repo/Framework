#region Using Directives

using Diten.Collections.Generic;
using Diten.Web.UI.WebControls;

#endregion

namespace Diten.Objects
{
	public class FileType : Object<FileType>
	{
		/// <summary>
		///     Extension of the file.
		///     Like "xdoc" for Microsoft Word Document extension.
		/// </summary>
		public String Extension { get; set; }

		/// <summary>
		///     Icon of the file type.
		/// </summary>
		public Icon Icon { get; set; }

		/// <summary>
		///     Title of file type.
		///     Like "Adobe PDF".
		/// </summary>
		public String Title { get; set; }
	}
}