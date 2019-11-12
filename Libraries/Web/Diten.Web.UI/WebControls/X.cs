#region Using Directives

using System;
using System.Diagnostics.CodeAnalysis;
using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	[SuppressMessage("ReSharper", "UnusedMember.Local")]
	[SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
	[SuppressMessage("ReSharper", "MemberCanBeMadeStatic.Local")]
	public class X : Ext.Net.X
	{
		/// <inheritdoc />
		private sealed class ProgressBox : MessageBox
		{
			public ProgressBox()
			{
				var tt = new TaskManager {ID = "TaskManager", Interval = 1000};
				var ttt = new Task {TaskID = "Task1", Interval = 1000, AutoRun = false};

				ttt.DirectEvents.Update.Event += Update_Event;
				tt.Tasks.Add(ttt);
				Page?.Controls.Add(tt);
			}

			//todo: hiding member in Ext.Net.X
			public static MessageBox MessageBox
			{
				get
				{
					if (HttpContext.Current.Items["ExtNet.MessageBox"] == null)
						HttpContext.Current.Items["ExtNet.MessageBox"] = new MessageBox();

					return HttpContext.Current.Items["ExtNet.MessageBox"] as MessageBox;
				}
			}

			private void Update_Event(object sender,
				DirectEventArgs e)
			{
				throw new NotImplementedException();
			}
		}
	}
}