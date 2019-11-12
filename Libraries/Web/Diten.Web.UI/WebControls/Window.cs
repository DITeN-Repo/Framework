#region Using Directives

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI;
using System.Web.UI.WebControls;
using Diten.ExtensionMethods;
using Ext.Net;
using Parameter = Ext.Net.Parameter;

#endregion

namespace Diten.Web.UI.WebControls
{
	/// <inheritdoc />
	[Meta]
	[ToolboxData("<{0}:Window runat=\"server\"></{0}:Window>")]
	[SuppressMessage("ReSharper", "UnusedMember.Local")]
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public class Window : Ext.Net.Window
	{
		/// <summary>
		///     Window buttons types.
		/// </summary>
		public enum WindowButtonsTypes
		{
			None,
			ApplyCancelOk,
			CancelOk,
			Ok
		}

		public Window()
		{
			DirectEvents.Restore.ExtraParams.Add(new Parameter
			{
				Name = "Width",
				Value = "this.getWidth()",
				Mode = ParameterMode.Raw
			});
			DirectEvents.Restore.ExtraParams.Add(new Parameter
			{
				Name = "Height",
				Value = "this.getHeight()",
				Mode = ParameterMode.Raw
			});
			DirectEvents.Restore.Event += Restore_Event;

			Init += Window_Init;
		}

		/// <summary>
		///     Apply button.
		/// </summary>
		public Button ButtonApply =>
			ViewState.GetValue<Button>(this.GetFrameName(), new Button
			{
				ID = "ButtonApply",
				Icon = Ext.Net.Icon.Accept,
				Text = @"Apply"
			});

		/// <summary>
		///     Cancel button.
		/// </summary>
		public Button ButtonCancel =>
			ViewState.GetValue<Button>(this.GetFrameName(), new Button
			{
				ID = "ButtonCancel",
				Icon = Ext.Net.Icon.Cancel,
				Text = @"Cancel"
			});

		/// <summary>
		///     Ok button.
		/// </summary>
		public Button ButtonOk =>
			ViewState.GetValue<Button>(this.GetFrameName(), new Button
			{
				ID = "ButtonOk",
				Icon = Ext.Net.Icon.Cancel,
				Text = @"Ok"
			});

		/// <summary>
		///     Get or Set window layout.
		/// </summary>
		public new string Layout
		{
			get => ViewState.GetValue<Layouts>(this.GetFrameName(), Layouts.None).ToString();
			set => ViewState.SetValue<Layouts>(this.GetFrameName(), delegate
			{
				base.Layout = System.Enum.Parse(typeof(Layouts), value).ToString();
				return value;
			});
		}

		//
		// return ViewState.GetValue<>(this.GetFirstFrameName(), Layouts.None;


		/// <summary>
		///     Return values from window to caller object.
		/// </summary>
		public Dictionary<string, string> ReturnValues
		{
			get => ViewState.GetValue<Dictionary<string, string>>(this.GetFrameName(), null);
			set => ViewState.SetValue(this.GetFrameName(), value);
		}

		/// <summary>
		///     Get or Set window buttons type.
		/// </summary>
		public WindowButtonsTypes WindowButtons
		{
			get => ViewState.GetValue<WindowButtonsTypes>(this.GetFrameName(), WindowButtonsTypes.None);
			set => ViewState.SetValue(this.GetFrameName(), value);
		}

		private void Window_Init(object sender,
			EventArgs e)
		{
			AutoUpdateLayout = true;
			Hidden = true;

			switch (WindowButtons)
			{
				case WindowButtonsTypes.ApplyCancelOk:
					Buttons.Add(ButtonApply);
					Buttons.Add(ButtonCancel);
					Buttons.Add(ButtonOk);

					break;
				case WindowButtonsTypes.CancelOk:
					Buttons.Add(ButtonCancel);
					Buttons.Add(ButtonOk);

					break;
				case WindowButtonsTypes.Ok:
					Buttons.Add(ButtonOk);

					break;
				case WindowButtonsTypes.None:
					Buttons.Clear();

					break;
				default:

					throw new ArgumentOutOfRangeException();
			}
		}

		#region WindowRestore event

		/// <summary>
		///     Resize event.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Direct event args.</param>
		private void Restore_Event(object sender,
			DirectEventArgs e)
		{
			var args = new WindowRestoreEventArgs
			{
				Width = Unit.Parse(e.ExtraParams["Width"]),
				Height = Unit.Parse(e.ExtraParams["Height"])
			};

			OnWindowRestore(args);
		}

		/// <summary>
		///     On window resize
		/// </summary>
		/// <param name="e">Window resize event args.</param>
		private void OnWindowRestore(WindowRestoreEventArgs e)
		{
			var handler = Restore;
			handler?.Invoke(this, e);
		}

		/// <summary>
		///     Window resize event handler.
		/// </summary>
		public new event EventHandler<WindowRestoreEventArgs> Restore;

		/// <summary>
		///     Window resize event args.
		/// </summary>
		public class WindowRestoreEventArgs : EventArgs
		{
			/// <summary>
			///     Height of window.
			/// </summary>
			public Unit Height { get; set; }

			/// <summary>
			///     Width of window.
			/// </summary>
			public Unit Width { get; set; }
		}

		#endregion
	}
}