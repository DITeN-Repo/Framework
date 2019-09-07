#region Using Directives

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using Diten.Diagnostics;
using Diten.ExtensionMethods;
using HC = Diten.Web.HttpContext;

#endregion

namespace Diten.Web
{
	/// <inheritdoc />
	/// <summary>
	///     Assembly resource virtual file class.
	/// </summary>
	internal class ResourceVirtualFile : VirtualFile
	{
		/// <inheritdoc />
		/// <summary>
		///     Constructor.
		/// </summary>
		/// <param name="virtualPath">DLL virtual path.</param>
		public ResourceVirtualFile(string virtualPath) : base(virtualPath)
		{
			ManifestResourcePath = VirtualPathUtility.ToAppRelative($@"{virtualPath}").Split('/').Last();
			//($"{path}_ManifestResourceStream", path);
		}

		/// <summary>
		///     Holder dictionary for assemblies.
		/// </summary>
		public static IEnumerable<Assembly> Assemblies =>
			HC.Application.GetValue<IEnumerable<Assembly>>(StackTrace.GetFrameName(),
				Reflection.Assembly.GetAssemblies());


		/// <summary>
		///     Path of the resource.
		/// </summary>
		private string ManifestResourcePath { get; }

		/// <summary>
		///     Holder dictionary for resource MemoryStreams.
		/// </summary>
		public static Dictionary<string, object> ManifestResourceStreams =>
			HC.Application.GetValue<Dictionary<string, object>>(StackTrace.GetFrameName(),
				new Dictionary<string, object>());

		/// <inheritdoc />
		/// <summary>
		///     Opening an <see cref="Stream" /> that is embedded in manifest.
		/// </summary>
		/// <exception cref="InvalidOperationException">Will be raised when resource not found.</exception>
		/// <returns>An <see cref="Stream" />.</returns>
		public override Stream Open()
		{
			//todo: serious problem!! Some times the Compiler will ignore condition.

			if (ManifestResourceStreams.ContainsKey(ManifestResourcePath))
				return (UnmanagedMemoryStream) ManifestResourceStreams[ManifestResourcePath];
			
			try
			{
				ManifestResourceStreams.Add(ManifestResourcePath,
					Assemblies.FirstOrDefault(a => a.GetManifestResourceNames().Contains(ManifestResourcePath))
						?.GetManifestResourceStream(ManifestResourcePath));
			}
			catch (ArgumentException e)
			{
				e.ToException();
			}

			return (UnmanagedMemoryStream) ManifestResourceStreams[ManifestResourcePath];
		}
	}
}