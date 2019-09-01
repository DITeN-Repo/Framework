#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/09/02 12:45 AM

#endregion

#region Used Directives

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Diten.Parameters;

#endregion

namespace Diten.Reflection
{
	public static class ExAssembly
	{
		public static IEnumerable<System.Reflection.Assembly> GetAssemblies(this Assembly value)
		{
			var holder = new Collections.Generic.List<System.Reflection.Assembly>();

			foreach (var assName in Convert.ToList(Constants.Application.AssemblyNames)
				.Select(assemblyName => assemblyName.Trim()).Where(assName => assName.ToUpper().EndsWith(".dll".ToUpper())))
				if (assName.Contains("*"))
					holder.AddRange(new DirectoryInfo(HttpRuntime.BinDirectory).GetFiles(assName)
						.ToDictionary(info => info.Name, info => System.Reflection.Assembly.LoadFrom(info.FullName))
						.Select(keyValuePair => keyValuePair.Value));
				else
					holder.Add(System.Reflection.Assembly.LoadFrom(Path.Combine(HttpRuntime.BinDirectory, assName)));

			return holder;
		}
	}
}