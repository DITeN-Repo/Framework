#region Using Directives

using System;
using System.Drawing;
using System.Web.UI;
using Diten.ExtensionMethods;
using Diten.Variables;
using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	/// <inheritdoc />
	[Meta]
	[ToolboxData("<{0}:SplitButton runat=\"server\"></{0}:SplitButton>")]
	public sealed class SplitButton : Ext.Net.SplitButton
	{
		public SplitButton()
		{
			Init += Button_Init;
		}

		/// <summary>
		///     Custom target for click event mask.
		/// </summary>
		public string CustomTarget
		{
			get => ViewState.GetValue<string>(this.GetFrameName(), typeof(ContentPanel).Name);
			set => ViewState.SetValue(this.GetFrameName(), value);
		}

		/// <summary>
		///     Click event mask message.
		/// </summary>
		public string MaskMessage
		{
			get => ViewState.GetValue<string>(this.GetFrameName(), Dictionary.Default.Loading);
			set => ViewState.SetValue(this.GetFrameName(), value);
		}

		public new Page Page
		{
			get
			{
				try
				{
					return (Page) base.Page;
				}
				catch (InvalidCastException)
				{
					return new Page((SelfRenderingPage) base.Page);
				}
			}
		}

		/// <summary>
		///     Get or Set IconUrl.
		/// </summary>
		public Bitmap ResourceIcon
		{
			get => ViewState.GetValue<Bitmap>(this.GetFrameName(), default);
			set
			{
				IconUrl = Page.GetBitmapResourceUrl(value, this);
				ViewState.SetValue(this.GetFrameName(), value);
			}
		}

		private void Button_Init(object sender,
			EventArgs e)
		{
			DirectEvents.Click.Event += Click_Event;
			DirectEvents.Click.EventMask.Msg = Page.Translate(MaskMessage);
			DirectEvents.Click.EventMask.Target = MaskTarget.CustomTarget;
			DirectEvents.Click.EventMask.CustomTarget = $@"#{{{CustomTarget}}}";
			DirectEvents.Click.EventMask.ShowMask = true;
		}

		/// <summary>
		///     Click event handler.
		/// </summary>
		public new event EventHandler<DirectEventArgs> Click;

		/// <summary>
		///     Click event handler.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Direct event args.</param>
		private void Click_Event(object sender,
			DirectEventArgs e)
		{
			OnClick(e);
		}

		/// <summary>
		///     On click event handler.
		/// </summary>
		/// <param name="e"></param>
		private void OnClick(DirectEventArgs e)
		{
			var handler = Click;
			handler?.Invoke(this, e);
		}
	}
}