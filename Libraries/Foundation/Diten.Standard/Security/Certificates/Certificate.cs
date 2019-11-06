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
// Creation Date: 2019/09/30 7:00 PM

#region Used Directives

using System.Collections.Generic;
using System.IO;
using Diten.Management.Hardware;
using Diten.Parameters;
using Diten.Reflection;

#endregion

namespace Diten.Security.Certificates
{
	internal static class Certificate
	{
		internal static IEnumerable<byte> Value
		{
			get
			{
				var path = $@"{Assembly.ExecutingAssemblyPath}{Environment.FolderDivider}{new Computer().Signature}" +
				           $@"{SystemParams.Default.DitenSignatureFileExtention}";

				if (File.Exists(path)) return File.ReadAllBytes(path);

				var key = new Key(Key.LengthTypes.K16384);
				File.WriteAllBytes(path,
				                   key.Value);

				return key.Value;
			}
		}
	}
}