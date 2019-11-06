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
// Creation Date: 2019/07/30 4:59 PM

#region Used Directives

using System;
using System.IO;
using System.Reflection;

#endregion

namespace Diten
{
	internal class Assemblyww
	{
		//todo: Check for requirement of this class
		//public void dd()
		//{
		//    Assembly.Load()
		//}

		public void Test(object[] args)
		{
			//string dir = @"SomePath"; // different from AppDomain.CurrentDomain.BaseDirectory
			//string path = System.IO.Path.Combine(dir, "MyDll.dll");

			//AppDomainSetup setup = AppDomain.CurrentDomain.SetupInformation;
			//setup. = dir;
			//AppDomain domain = AppDomain.CreateDomain("SomeAppDomain", null, setup);

			//domain.Load(AssemblyName.GetAssemblyName(path));
			//domain.Load()
			try
			{
				if (args.Length == 0)
					throw new TargetParameterCountException(
					                                        "Expected at least one parameter containing executable path.");

				using (var fileStream = new FileStream(args[0].ToString(),
				                                       FileMode.Open))
				{
					using (var reader = new BinaryReader(fileStream))
					{
						var bin = reader.ReadBytes(Convert.ToInt32(fileStream.Length));
						var assembly = AppDomain.CurrentDomain.Load(bin); //Assembly.Load(bin);

						var method = assembly.EntryPoint;
						//if (method != null)
						//{
						//    object o = assembly.CreateInstance(method.ReflectedType?.Name);
						//    if (method.GetParameters().Length == 0)
						//        method.Invoke(o, new object[0]);
						//    else
						//    {
						//        string[] parameters = new string[args.Length - 1];
						//        for (int i = 1; i < args.Length; i++)
						//            parameters[i - 1] = args[i];
						//        method.Invoke(o, new[] { parameters });
						//    }
						//}
					}
				}
			}
			catch (Exception ex)
			{
				Console.BackgroundColor = ConsoleColor.Red;
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine();
				Console.WriteLine(ex.Message.PadRight(80));
				Console.BackgroundColor = ConsoleColor.Black;
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine(@"Hit 'd' for details. Any other key will terminate application.");
				if (Console.ReadKey(true).KeyChar == 'd')
				{
					Console.ForegroundColor = ConsoleColor.Gray;
					Console.WriteLine();
					Console.WriteLine(ex.StackTrace);
					Console.ReadKey();
				}
			}
		}

		///// <summary>Loads an assembly given its file name or path.</summary>
		///// <param name="assemblyFile">The name or path of the file that contains the manifest of the assembly. </param>
		///// <returns>The loaded assembly.</returns>
		///// <exception cref="T:System.ArgumentNullException">
		///// <paramref name="assemblyFile" /> is <see langword="null" />. </exception>
		///// <exception cref="T:System.IO.FileNotFoundException">
		///// <paramref name="assemblyFile" /> is not found, or the module you are trying to load does not specify a filename extension. </exception>
		///// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded. </exception>
		///// <exception cref="T:System.BadImageFormatException">
		///// <paramref name="assemblyFile" /> is not a valid assembly; for example, a 32-bit assembly in a 64-bit process. See the exception topic for more information. -or-Version 2.0 or later of the common language runtime is currently loaded and <paramref name="assemblyFile" /> was compiled with a later version.</exception>
		///// <exception cref="T:System.Security.SecurityException">A codebase that does not start with "file://" was specified without the required <see cref="T:System.Net.WebPermission" />. </exception>
		///// <exception cref="T:System.ArgumentException">The <paramref name="assemblyFile" /> parameter is an empty string (""). </exception>
		///// <exception cref="T:System.IO.PathTooLongException">The assembly name is longer than MAX_PATH characters.</exception>
		//[SecuritySafeCritical]
		//[MethodImpl(MethodImplOptions.NoInlining)]
		//public static Assembly LoadFrom(string assemblyFile)
		//{
		//    var stackMark = ((FieldInfo) Type.GetType("System.Threading.StackCrawlMark")?.GetMembers()
		//        .First(m => m.Name.Equals("LookForMyCaller")))?.GetValue(Assembly.GetExecutingAssembly());

		//    var ff = Type.GetType("System.Reflection.RuntimeAssembly")?.GetMethod("InternalLoadFrom").Invoke(this,);

		//    Evidence securityEvidence = (Evidence) null;

		//    AssemblyHashAlgorithm hashAlgorithm = AssemblyHashAlgorithm.None;
		//    bool forIntrospection = false;
		//    bool suppressSecurityChecks = false;
		//    byte[] hashValue = (byte[]) null;

		//    if (assemblyFile == null)
		//        throw new ArgumentNullException(nameof(assemblyFile));
		//    if (securityEvidence != null && !AppDomain.CurrentDomain.IsLegacyCasPolicyEnabled)
		//        throw new NotSupportedException(System.Environment.GetResourceString("NotSupported_RequiresCasPolicyImplicit"));
		//    AssemblyName assemblyRef = new AssemblyName();
		//    assemblyRef.CodeBase = assemblyFile;
		//    assemblyRef.SetHashControl(hashValue, hashAlgorithm);
		//    return RuntimeAssembly.InternalLoadAssemblyName(assemblyRef, securityEvidence, (RuntimeAssembly)null, ref stackMark, true, forIntrospection, suppressSecurityChecks);

		//    //System.Threading.StackCrawlMark.LookForMyCaller;
		//    return (Assembly)RuntimeAssembly.InternalLoadFrom(assemblyFile, (Evidence)null, (byte[])null, AssemblyHashAlgorithm.None, false, false, ref stackMark);

		//}

		//[SecurityCritical]
		//[MethodImpl(MethodImplOptions.NoInlining)]
		//internal static RuntimeAssembly InternalLoadFrom(string assemblyFile, Evidence securityEvidence, byte[] hashValue, AssemblyHashAlgorithm hashAlgorithm, bool forIntrospection, bool suppressSecurityChecks, ref StackCrawlMark stackMark)
		//{
		//    if (assemblyFile == null)
		//        throw new ArgumentNullException(nameof(assemblyFile));
		//    if (securityEvidence != null && !AppDomain.CurrentDomain.IsLegacyCasPolicyEnabled)
		//        throw new NotSupportedException(System.Environment.GetResourceString("NotSupported_RequiresCasPolicyImplicit"));
		//    AssemblyName assemblyRef = new AssemblyName();
		//    assemblyRef.CodeBase = assemblyFile;
		//    assemblyRef.SetHashControl(hashValue, hashAlgorithm);
		//    return RuntimeAssembly.InternalLoadAssemblyName(assemblyRef, securityEvidence, (RuntimeAssembly)null, ref stackMark, true, forIntrospection, suppressSecurityChecks);
		//}

		//[SecuritySafeCritical]
		//[MethodImpl(MethodImplOptions.NoInlining)]
		//internal static Assembly LoadImageSkipIntegrityCheck(byte[] rawAssembly, byte[] rawSymbolStore, SecurityContextSource securityContextSource)
		//{
		//    AppDomain.CheckLoadByteArraySupported();
		//    switch (securityContextSource)
		//    {
		//        case SecurityContextSource.CurrentAppDomain:
		//        case SecurityContextSource.CurrentAssembly:
		//            StackCrawlMark stackMark = System.Threading.StackCrawlMark.LookForMyCaller;
		//            return (Assembly)RuntimeAssembly.nLoadImage(rawAssembly, rawSymbolStore, (Evidence)null, ref stackMark, false, true, securityContextSource);
		//        default:
		//            throw new ArgumentOutOfRangeException(nameof(securityContextSource));
		//    }
		//    Assembly.Load()

		//}

		//[SecurityCritical]
		//internal static RuntimeAssembly InternalLoadAssemblyName(AssemblyName assemblyRef, Evidence assemblySecurity, RuntimeAssembly reqAssembly, ref StackCrawlMark stackMark, IntPtr pPrivHostBinder, bool throwOnFileNotFound, bool forIntrospection, bool suppressSecurityChecks)
		//{
		//    if (assemblyRef == null)
		//        throw new ArgumentNullException(nameof(assemblyRef));
		//    if (assemblyRef.CodeBase != null)
		//        AppDomain.CheckLoadFromSupported();
		//    assemblyRef = (AssemblyName)assemblyRef.Clone();
		//    if (assemblySecurity != null)
		//    {
		//        if (!AppDomain.CurrentDomain.IsLegacyCasPolicyEnabled)
		//            throw new NotSupportedException(System.Environment.GetResourceString("NotSupported_RequiresCasPolicyImplicit"));
		//        if (!suppressSecurityChecks)
		//            new SecurityPermission(SecurityPermissionFlag.ControlEvidence).Demand();
		//    }
		//    string str = RuntimeAssembly.VerifyCodeBase(assemblyRef.CodeBase);
		//    if (str != null && !suppressSecurityChecks)
		//    {
		//        if (string.Compare(str, 0, "file:", 0, 5, StringComparison.OrdinalIgnoreCase) != 0)
		//            RuntimeAssembly.CreateWebPermission(assemblyRef.EscapedCodeBase).Demand();
		//        else
		//            new FileIOPermission(FileIOPermissionAccess.Read | FileIOPermissionAccess.PathDiscovery, new URLString(str, true).GetFileName()).Demand();
		//    }
		//    return RuntimeAssembly.nLoad(assemblyRef, str, assemblySecurity, reqAssembly, ref stackMark, pPrivHostBinder, throwOnFileNotFound, forIntrospection, suppressSecurityChecks);
		//}
	}
}