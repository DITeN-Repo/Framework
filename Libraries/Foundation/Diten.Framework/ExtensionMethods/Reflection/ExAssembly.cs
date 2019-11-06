// Copyright alright reserved by DITeN™ ©® 2003 - 2019
// ----------------------------------------------------------------------------------------------
// Agreement:
// 
// All developers could modify or developing this code but changing the architecture of
// the product is not allowed.
// 
// DITeN Research & Development
// ----------------------------------------------------------------------------------------------
// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/09/02 12:45 AM

#region Used Directives

using System.Collections.Generic;

#endregion

namespace Diten.Reflection
{
	public static class ExAssembly
	{
		/// <summary>
		///    Get assemblies from repository.
		/// </summary>
		/// <param name="value">Current assembly object.</param>
		/// <returns>An <see cref="IEnumerable{T}" /> of <see cref="System.Reflection.Assembly" /></returns>
		public static IEnumerable<System.Reflection.Assembly> GetAssemblies(this Assembly value)
		{
			var holder = new Collections.Generic.List<System.Reflection.Assembly>();
			//ToDo: Check Commented code.
			//foreach (var assName in Convert.ToList(Constants.no.AssemblyNames)
			//	.Select(assemblyName => assemblyName.Trim()).Where(assName => assName.ToUpper().EndsWith(".dll".ToUpper())))
			//	if (assName.Contains("*"))
			//		holder.AddRange(new DirectoryInfo(HttpRuntime.BinDirectory).GetFiles(assName)
			//			.ToDictionary(info => info.Name, info => System.Reflection.Assembly.LoadFrom(info.FullName))
			//			.Select(keyValuePair => keyValuePair.Value));
			//	else
			//		holder.Add(System.Reflection.Assembly.LoadFrom(Path.Combine(HttpRuntime.BinDirectory, assName)));

			return holder;
		}
	}
}