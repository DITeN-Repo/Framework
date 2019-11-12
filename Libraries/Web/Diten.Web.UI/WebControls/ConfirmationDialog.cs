#region Using Directives

using System;
using System.Collections.Generic;
using System.Web.UI;
using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	/// <inheritdoc />
	[Meta]
	[ToolboxData("<{0}:ConfirmationDialog runat=\"server\"></{0}:ConfirmationDialog>")]
	public sealed class ConfirmationDialog : UserControl
	{
		/// <summary>
		///     Do confirm process and show confirmation dialog.
		/// </summary>
		/// <param name="title">Title of dialog.</param>
		/// <param name="message">Message that must be displayed in confirmation dialog.</param>
		/// <param name="doYesParameters">Parameters that must passed to Yes event handler.</param>
		/// <param name="doNoParameters">Parameters that must passed to No event handler.</param>
		public void DoConfirm(string title,
			string message,
			Dictionary<string, string> doYesParameters = null,
			Dictionary<string, string> doNoParameters = null)
		{
			var doYesParametersCsv = doYesParameters != null
				? Page.Encrypt(Convert.ToSplittedData(doYesParameters))
				: string.Empty;

			var doNoParametersCsv = doYesParameters != null
				? Page.Encrypt(Convert.ToSplittedData(doNoParameters))
				: string.Empty;

			Ext.Net.X.Msg.Confirm(title,
					message,
					new MessageBoxButtonsConfig
					{
						Yes = new MessageBoxButtonConfig
						{
							Handler = $@"App.direct.{ClientID}.DoYes('{doYesParametersCsv}')",
							Text = Page.Translate("بله")
						},
						No = new MessageBoxButtonConfig
						{
							Handler = $@"App.direct.{ClientID}.DoNo('{doNoParametersCsv}')",
							Text = Page.Translate("خیر")
						}
					})
				.Show();
		}

		#region Yes event

		/// <summary>
		///     DoYes event args.
		/// </summary>
		public class YesEventArgs : EventArgs
		{
			/// <summary>
			///     Parameters of event.
			/// </summary>
			public Dictionary<string, string> Parameters { get; set; }
		}

		/// <summary>
		///     DoYes event handler.
		/// </summary>
		public event EventHandler<YesEventArgs> Yes;

		/// <summary>
		///     On DoYes
		/// </summary>
		/// <param name="e">DoYes event args.</param>
		private void OnYes(YesEventArgs e)
		{
			var handler = Yes;
			handler?.Invoke(this, e);
		}

		/// <summary>
		///     DoYes method.
		/// </summary>
		[DirectMethod]
		// ReSharper disable once UnusedMember.Global
		public void DoYes(string parameters)
		{
			var args = new YesEventArgs
			{
				Parameters = Page.Decrypt(parameters).ToDictionary()
			};

			OnYes(args);
		}

		#endregion

		#region No event

		/// <summary>
		///     No event args.
		/// </summary>
		public class NoEventArgs : EventArgs
		{
			/// <summary>
			///     Parameters of event.
			/// </summary>
			public Dictionary<string, string> Parameters { get; set; }
		}

		/// <summary>
		///     No event handler.
		/// </summary>
		public event EventHandler<NoEventArgs> No;

		/// <summary>
		///     On No
		/// </summary>
		/// <param name="e">No event args.</param>
		private void OnNo(NoEventArgs e)
		{
			var handler = No;
			handler?.Invoke(this, e);
		}

		/// <summary>
		///     DoNo method.
		/// </summary>
		[DirectMethod]
		public void DoNo(string parameters)
		{
			var args = new NoEventArgs
			{
				Parameters = Page.Decrypt(parameters).ToDictionary()
			};

			OnNo(args);
		}

		#endregion
	}
}