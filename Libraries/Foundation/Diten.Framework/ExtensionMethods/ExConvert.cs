#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 8:22 PM

#endregion

#region Used Directives

using System;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using Diten.Parameters;

// ReSharper disable UnusedParameter.Global

// ReSharper disable UnusedMember.Global

#endregion

namespace Diten
{
	/// <summary>
	///    Conversion tools in diten framework.
	/// </summary>
	public static class ExConvert
	{
		/// <summary>
		///    Converting html template into <see cref="ITemplate" />.
		/// </summary>
		/// <param name="value">The string value that contains HTM Template.</param>
		/// <param name="htmlTemplate">Html template to convert.</param>
		/// <returns>An ITemplate.</returns>
		public static ITemplate ToITemplate(this string value, string htmlTemplate)
		{
			var page = HttpContext.Current.Handler as Page;
			var memberInfo = Type.GetType(Names.Default.Type_VirtualPath);

			if (memberInfo == null) return null;

			var createMethod = memberInfo.GetMethods(BindingFlags.Static | BindingFlags.Public)
				.FirstOrDefault(m => m.Name == "Create" && m.GetParameters().Length == 1);

			if (createMethod == null) return null;
			var virtualPath = (string) createMethod.Invoke(null, new object[]
			{
				page?.AppRelativeVirtualPath
			});

			return TemplateParser.ParseTemplate(htmlTemplate, virtualPath, true);
		}
	}
}