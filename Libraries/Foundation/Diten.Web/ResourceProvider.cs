#region Using Directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Web.Caching;
using System.Web.Hosting;
using Diten.ExtensionMethods;
using Diten.Variables;
using static System.Web.VirtualPathUtility;
using HC = Diten.Web.HttpContext;

#endregion

namespace Diten.Web
{
	/// <inheritdoc />
	/// <summary>
	///     The resource provider.
	/// </summary>
	public class ResourceProvider : VirtualPathProvider
	{
		/// <summary>
		///     The assemblies.
		/// </summary>
		public static IEnumerable<Assembly> Assemblies => ResourceVirtualFile.Assemblies;

		/// <summary>
		///     The <see cref="MemoryStream" /> resources in manifests.
		/// </summary>
		public static Dictionary<string, object> Resources => ResourceVirtualFile.ManifestResourceStreams;

		/// <inheritdoc />
		/// <summary>
		///     Check is file exist.
		/// </summary>
		/// <param name="virtualPath">DLL virtual path.</param>
		/// <returns>True if the virtual path is exist.</returns>
		public override bool FileExists(string virtualPath)
		{
			return IsAppResourcePath(virtualPath) || base.FileExists(virtualPath);
		}

		/// <inheritdoc />
		/// <summary>
		///     Get cache dependency.
		/// </summary>
		/// <param name="virtualPath">DLL virtual path.</param>
		/// <param name="virtualPathDependencies">DLL virtual path dependencies.</param>
		/// <param name="utcStart">UTC start time.</param>
		/// <returns>Cache dependency.</returns>
		public override CacheDependency
			GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
		{
			return IsAppResourcePath(virtualPath)
				? null
				: HC.Current.Application.GetValue<CacheDependency>(
					$@"{virtualPath}{Names.Default.CacheDependency.ToSuffix()}",
					base.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart));
		}

		/// <inheritdoc cref="VirtualPathProvider" />
		/// <summary>
		///     Get virtual file of virtual path.
		/// </summary>
		/// <param name="virtualPath">DLL virtual path.</param>
		/// <returns>Virtual file.</returns>
		public override VirtualFile GetFile(string virtualPath)
		{
			try
			{
				return IsAppResourcePath(virtualPath)
					? new ResourceVirtualFile(virtualPath)
					: base.GetFile(virtualPath);
			}
			catch (Exception e)
			{
				throw new NullReferenceException(
					string.Format(Exceptions.Default.Diten_Web_ResourceProvider_GetFile, virtualPath), e);
			}
		}

		/// <summary>
		///     Check is app resource path.
		/// </summary>
		/// <param name="virtualPath">DLL virtual path.</param>
		/// <returns>True if the virtual path is app resource path.</returns>
		private static bool IsAppResourcePath(string virtualPath)
		{
			return ToAppRelative($@"{virtualPath}").Contains($@"/{Constants.Application.ResourcesPath}/");
		}
	}
}