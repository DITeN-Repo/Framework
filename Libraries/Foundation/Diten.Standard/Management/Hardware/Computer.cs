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

#region Used Directives

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Diten.Collections.Generic;
using Diten.Runtime;
using Diten.Security;
using Diten.Security.Cryptography;
using JetBrains.Annotations;
using MongoDB.Bson;

#endregion

namespace Diten.Management.Hardware
{
	/// <inheritdoc cref="Hardware{THardware}" />
	[SuppressMessage("ReSharper",
		"InconsistentNaming")]
	[UsedImplicitly]
	public class Computer: Hardware<Computer>,
	                       IHardware<Computer>
	{
		/// <summary>
		///    Get description of the current <see cref="Computer" />.
		/// </summary>
		public new string Description {get; set;}

		/// <summary>
		///    Get <inheritdoc cref="IEnumerable{T}" /> list of available <see cref="DiskDrive" />s on the <see cref="Computer" />.
		/// </summary>
		public static IEnumerable<DiskDrive> DiskDrives => new DiskDrive().Touch();

		/// <summary>
		///    Get <see cref="IEnumerable{T}" /> list of available <see cref="DisplayAdapter" />s.
		/// </summary>
		public static Collections.Generic.List<DisplayAdapter> DisplayAdapters => new DisplayAdapter().Touch();

		/// <inheritdoc />
		public new ImmutableDictionary<ObjectId, IObject<Computer, SHA256>> History {get;}

		/// <summary>
		///    Get name of the current <see cref="Computer" />.
		/// </summary>
		public static string MachineName => System.Environment.MachineName;

		/// <summary>
		///    Get <see cref="NetworkInterface" />s that are plugged on the <see cref="Computer" />.
		/// </summary>
		public static Collections.Generic.List<NetworkInterface> NetworkAdapters => NetworkInterface.Touch();

		/// <summary>
		///    Get <see cref="Management.OperatingSystem" /> of the <see cref="Computer" />.
		/// </summary>
		public static OperatingSystem OperatingSystem => new OperatingSystem().Touch().First();

		/// <summary>
		///    Get <see cref="Processor" />s of the <see cref="Computer" />.
		/// </summary>
		public static IEnumerable<Processor> Processors => new Processor().Touch();

		/// <summary>
		///    Get <see cref="Ram" />s that are plugged on the <see cref="Computer" />.
		/// </summary>
		public static Collections.Generic.List<Ram> Rams => new Ram().Touch();

		/// <inheritdoc />
		public new Byte Serialize => Serialization.Serialize(this).ToByte();

		/// <summary>
		///    Get <see cref="Signature" /> of the current <see cref="Computer" />.
		/// </summary>
		public new Signature<SHA256> Signature =>
			new Signature<SHA256>($@"{
					                      base.Signature
				                      }{
					                      MachineName
				                      }{
					                      Processors.Aggregate(string.Empty,
					                                           (current,
					                                            processor) =>
						                                           current +
						                                           $@"{processor.Signature};")
				                      }{
					                      DiskDrives
						                      ?.FirstOrDefault(d => d.Name.Equals(Assembly
						                                                          .GetEntryAssembly()
						                                                          ?.FullName
						                                                          .Split("\\"
							                                                                 .ToCharArray())
						                                                          .First()
						                                                          .Replace(":",
						                                                                   string
							                                                                   .Empty)))
						                      ?.Touch()
						                      ?.FirstOrDefault()
						                      ?.Signature
				                      }");
	}
}