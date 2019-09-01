#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/16 12:20 AM

#endregion

#region Used Directives

using System;

#endregion

namespace Diten.Net
{
	/// <summary>
	///    Provides data for the RouteCompleted event of Tracert
	/// </summary>
	public class RouteNodeFoundEventArgs:EventArgs
	{
		protected internal RouteNodeFoundEventArgs(TracertNode node,
			bool isDone)
		{
			Node=node;
			IsLastNode=isDone;
		}

		/// <summary>
		///    Indicates whether the value of the Node propert is the last node
		///    found by Tracert
		/// </summary>
		public bool IsLastNode { get; }

		/// <summary>
		///    A node encountered during the route tracing.
		/// </summary>
		public TracertNode Node { get; }
	}
}