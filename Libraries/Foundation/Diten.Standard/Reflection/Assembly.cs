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
// Creation Date: 2019/09/02 12:40 AM

#region Used Directives

using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

#endregion

namespace Diten.Reflection
{
	public class Assembly: System.Reflection.Assembly
	{
		/// <inheritdoc cref="System.Reflection.Assembly.GetExecutingAssembly()" />
		public static System.String ExecutingAssemblyPath
		{
			get
			{
				var holder = GetExecutingAssembly().FullName;

				return holder.Replace(
				                      $@"{Environment.FolderDivider}{holder.Split(Environment.FolderDivider.ToCharArray()).Last()}.",
				                      string.Empty);
			}
		}

		/// <summary>
		///    Get current executed method name in <inheritdoc cref="string" />.
		/// </summary>
		/// <returns>An <inheritdoc cref="string" /> that contains name of currently executed method.</returns>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static System.String GetCurrentMethodName() { return new StackTrace().GetFrame(1).GetMethod().Name; }

		/// <summary>
		///    Get current executed property name in <inheritdoc cref="string" />.
		/// </summary>
		/// <returns>An <inheritdoc cref="string" /> that contains name of currently executed property.</returns>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static System.String GetCurrentPropertyName() { return new StackTrace().GetFrame(2).GetMethod().Name; }
	}
}