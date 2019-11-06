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
// Creation Date: 2019/08/15 4:35 PM

#region Used Directives

using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Diten.Parameters;
using Diten.Text;
using EventLog = Diten.Diagnostics.EventLog;
using EX = System.Exception;
using StackTrace = Diten.Diagnostics.StackTrace;

#endregion

namespace Diten
{
	/// <inheritdoc />
	public sealed class Exception: EX
	{
		/// <inheritdoc />
		public Exception(string message,
		                 EX innerException = null): base(message,
		                                                 innerException)
		{
			var assembly = Assembly.GetExecutingAssembly();
			var stackTrace = new StackTrace();
			var frame = stackTrace.GetFrame(1);
			var date = DateTime.Now;
			var index = 0;

			message = Tools.DesignMessage("StackTrace",
			                              StackTrace.IsNull("Nothing")) +
			          #if !DEBUG
			          Tools.DesignMessage("Environment StackTrace", System.Environment.StackTrace.IsNull("Nothing")) +
			          #endif
			          Tools.DesignMessage("Date",
			                              date.ToString(CultureInfo.InvariantCulture)) +
			          Tools.DesignMessage("Path",
			                              $"{Environment.UserDomainName}\\{Environment.MachineName}\\{Environment.UserName}\\{frame?.GetFileName()}\\{frame?.GetMethod().Name}\\{frame?.GetFileLineNumber().ToString()}") +
			          Tools.DesignMessage("TargetSite.Name",
			                              TargetSite?.Name.Trim()) +
			          Tools.DesignMessage("TargetSite.MethodHandle.Value",
			                              TargetSite?.MethodHandle.Value.ToString().Trim()) +
			          Tools.DesignMessage("HResult",
			                              HResult.ToString().Trim()) +
			          Tools.DesignMessage("HelpLink",
			                              HelpLink?.Trim()) +
			          Environment.NewLine +
			          Tools.DesignMessage("Message",
			                              message,
			                              0,
			                              true) +
			          Environment.NewLine +
			          Tools.DesignMessage("Frames in StackTrace",
			                              new Func<string>(() => (stackTrace.GetFrames() ??
			                                                      throw new
				                                                      InvalidOperationException(
				                                                                                Exceptions.Default
				                                                                                          .Diten_Exception_Exception)
			                                                     )
				                                               .Aggregate(
				                                                          string.Empty,
				                                                          (current,
				                                                           stackFrame) => current +
				                                                                          new Func<int, string>(i =>
				                                                                                                {
					                                                                                                i++;
					                                                                                                index = i;

					                                                                                                return Tools.DesignMessage(
					                                                                                                                           $"[{i}]:->ILOffset({stackFrame.GetILOffset().ToString()})",
					                                                                                                                           $"{stackFrame.GetMethod().Name}()",
					                                                                                                                           1);
				                                                                                                }).Invoke(index))).Invoke(),
			                              0,
			                              true);

			message = Data.Cast<DictionaryEntry>()
			              .Aggregate(message,
			                         (current,
			                          dictionaryEntry) =>
				                         current +
				                         $"{Tools.DesignMessage(dictionaryEntry.Key.ToString().Trim(), dictionaryEntry.Value.ToString().Trim())}");

			EventLog.WriteEventLog(message,
			                       $"{Constants.Default.DITeNFramework} [{assembly.GetName().Name} - {assembly.ImageRuntimeVersion}]",
			                       EventLogEntryType.Error);
			#if DEBUG
			Debug.WriteLine(message);
			#endif
		}

		/// <inheritdoc cref="EX.InnerException" />
		public new Exception InnerException =>
			base.InnerException != null
				? new Exception(base.InnerException.Message,
				                base.InnerException)
				: null;
	}
}