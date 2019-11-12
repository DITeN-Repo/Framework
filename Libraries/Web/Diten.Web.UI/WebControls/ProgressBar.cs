#region Using Directives

using System;
using System.Web.UI;
using Diten.ExtensionMethods;
using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	/// <inheritdoc />
	[Meta]
	[ToolboxData("<{0}:ProgressBar runat=\"server\"></{0}:ProgressBar>")]
	public sealed class ProgressBar : Ext.Net.ProgressBar
	{
		public ProgressBar()
		{
			Init += ProgressBar_Init;
		}

		public bool AutoRun
		{
			get => TaskManager.Tasks[0].AutoRun;
			set => TaskManager.Tasks[0].AutoRun = value;
		}

		public int Interval
		{
			get => TaskManager.Tasks[0].Interval;
			set => TaskManager.Tasks[0].Interval = value;
		}

		/// <summary>
		///     Get or Set Maximum.
		/// </summary>
		public float Maximum
		{
			get => ViewState.GetValue<float>(this.GetFrameName(), 100f);
			set => ViewState.SetValue(this.GetFrameName(), value);
		}

		/// <summary>
		///     Get or Set Minimum.
		/// </summary>
		public float Minimum
		{
			get => ViewState.GetValue<float>(this.GetFrameName(), 0f);
			set => ViewState.SetValue(this.GetFrameName(), value);
		}

		public string OnStart
		{
			get => TaskManager.Tasks[0].OnStart;
			set => TaskManager.Tasks[0].OnStart = value;
		}

		public string OnStop
		{
			get => TaskManager.Tasks[0].OnStop;
			set => TaskManager.Tasks[0].OnStop = value;
		}

		public new Page Page => base.Page as Page;

		public string TaskId => TaskManager.Tasks[0].TaskID;

		/// <summary>
		///     Get or Set TaskManager.
		/// </summary>
		public TaskManager TaskManager
		{
			get => ViewState.GetValue<TaskManager>(this.GetFrameName(), delegate
			{
				var taskManager = new TaskManager {ID = $@"{ID}TaskManager"};
				var task = new Task {TaskID = $@"{ID}TaskHopActionProgress"};

				task.DirectEvents.Update.Event += Update_Event;
				taskManager.Tasks.Add(task);
				return taskManager;
			});
			set => ViewState.SetValue(this.GetFrameName(), value);
		}

		private void ProgressBar_Init(object sender,
			EventArgs e)
		{
			ContentControls.Add(TaskManager);
		}

		#region Update event

		/// <summary>
		///     Update event.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Direct event args.</param>
		private void Update_Event(object sender,
			DirectEventArgs e)
		{
			if (!Value.Equals(Maximum))
			{
				UpdateProgress((int) Value / Maximum, $"{ProgressPercentage}");
			}
			else
			{
				Page.ResourceManager.AddScript("{0}.stopTask('" + TaskId + "');",
					TaskManager.ClientID);
				UpdateProgress(0, $@"{Page.Translate("All finished")}!");
			}

			var args = new UpdateEventArgs
			{
				ProgressPercentage = ProgressPercentage,
				Value = Value,
				Maximum = Maximum,
				Minimum = Minimum
			};

			OnUpdate(args);
		}

		public string ProgressPercentage => $@"{Value * 100 / Maximum:F0}%";

		private const string SessionValue = "SessionValue";

		/// <summary>
		///     Get or Set Value.
		/// </summary>
		public new float Value
		{
			get
			{
				if (Page.Session[$@"{ID}{SessionValue}"] == null)
					Page.Session[$@"{ID}{SessionValue}"] = 0f;

				return (float) Page.Session[$@"{ID}{SessionValue}"];
			}
			set => Page.Session[$@"{ID}{SessionValue}"] = value;
		}

		public void Start()
		{
			Page.ResourceManager.AddScript("{0}.startTask('" + TaskId + "');", TaskManager.ClientID);
		}

		/// <summary>
		///     On window Update
		/// </summary>
		/// <param name="e">Window Update event args.</param>
		private void OnUpdate(UpdateEventArgs e)
		{
			var handler = Update;
			handler?.Invoke(this, e);
		}

		/// <summary>
		///     Window Update event handler.
		/// </summary>
		public new event EventHandler<UpdateEventArgs> Update;

		/// <inheritdoc />
		/// <summary>
		///     Window Update event args.
		/// </summary>
		public class UpdateEventArgs : EventArgs
		{
			public float Maximum { get; set; }
			public float Minimum { get; set; }
			public string ProgressPercentage { get; set; }
			public float Value { get; set; }
		}

		#endregion
	}
}