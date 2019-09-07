#region DITeN Registration Info

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
// Creation Date: 2019/08/15 8:37 PM

#endregion

#region Used Directives

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Diten.Collections.Generic;
using Diten.Security.Cryptography;
using JetBrains.Annotations;

#endregion


namespace Diten.Management.Hardware
{
	/// <inheritdoc cref="Hardware{THardware}" />
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	[UsedImplicitly]
	public class Computer : Hardware<Computer>, IHardware<Computer, SHA1>
	{
		public string Description { get; set; }
		public static IEnumerable<DiskDrive> DiskDrives => new DiskDrive().Touch();
		public static Collections.Generic.List<DisplayAdapter> DisplayAdapters => new DisplayAdapter().Touch();
		public static string MachineName => System.Environment.MachineName;
		public static Collections.Generic.List<NetworkInterface> NetworkAdapters => new NetworkInterface().Touch();
		public static OperatingSystem OperatingSystem => new OperatingSystem().Touch().First();
		public static IEnumerable<Processor> Processors => new Processor().Touch();
		public static Collections.Generic.List<Ram> Rams => new Ram().Touch();

		public new static string Key
		{
			get
			{
				var drive = DiskDrives
					?.FirstOrDefault(d => d.Name.Equals(Assembly
						.GetEntryAssembly()
						.FullName
						.Split("\\"
							.ToCharArray())
						.First()
						.Replace(":",
							string
								.Empty)))
					?.Touch()?.FirstOrDefault();

				return SHA1.Encrypt($@"{MachineName}{Processors.Aggregate(string.Empty,
					(current,
							processor) =>
						current +
						$@"{processor.Key.ToString()};")}{drive?.Key}");
			}
		}
	}
}