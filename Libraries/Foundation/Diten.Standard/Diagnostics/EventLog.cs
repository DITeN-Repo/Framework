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
// Creation Date: 2019/08/16 12:45 AM

#endregion

#region Used Directives

using System.Diagnostics;

#endregion

namespace Diten.Diagnostics
{
	/// <inheritdoc />
	// ReSharper disable once ClassNeverInstantiated.Global
	public class EventLog : System.Diagnostics.EventLog
	{
		public static void WriteEventLog(string message,
			string source,
			EventLogEntryType eventLogEntryType = EventLogEntryType.Information)
		{
			if (!SourceExists(source))
				CreateEventSource(source, string.Empty);

			using (var eventLog = new System.Diagnostics.EventLog(string.Empty, System.Environment.MachineName, source))
				eventLog.WriteEntry(message, eventLogEntryType);
		}
	}
}