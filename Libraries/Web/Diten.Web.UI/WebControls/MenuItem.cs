#region Using Directives

using System;
using System.Linq;
using System.Web.UI;
using Diten.ExtensionMethods;
using Diten.Variables;
using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	/// <inheritdoc />
	[Meta]
	[ToolboxData("<{0}:MenuItem runat=\"server\"></{0}:MenuItem>")]
	public sealed class MenuItem : Ext.Net.MenuItem
	{
		public MenuItem()
		{
			Init += MenuItem_Init;
		}

		/// <summary>
		///     Custom target for click event mask.
		/// </summary>
		public string CustomTarget
		{
			get => ViewState.GetValue<string>(this.GetFrameName(),
				typeof(ContentPanel).ToString().Split(".".ToCharArray()).Last());
			set => ViewState.SetValue(this.GetFrameName(), value);
		}

		/// <summary>
		///     Get or Set icon.
		/// </summary>
		public Icons DTIcon
		{
			get => IconHolder.Value;
			set => IconHolder = new Icon(value);
		}

		/// <summary>
		///     Holder of the icon object.
		/// </summary>
		public Icon IconHolder
		{
			get => ViewState.GetValue<Icon>(this.GetFrameName(), new Icon(Icons.Default));
			private set => ViewState.SetValue(this.GetFrameName(), value);
		}

		/// <summary>
		///     Click event mask message.
		/// </summary>
		public string MaskMessage
		{
			get => ViewState.GetValue<string>(this.GetFrameName(), Dictionary.Default.Loading);
			set => ViewState.SetValue(this.GetFrameName(), value);
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
		///     Initialize
		/// </summary>
		private void Initialize()
		{
			DirectEvents.Click.Event += Click_Event;
			DirectEvents.Click.EventMask.Msg = new Page().Translate(MaskMessage);
			DirectEvents.Click.EventMask.Target = MaskTarget.CustomTarget;
			DirectEvents.Click.EventMask.CustomTarget = $@"#{{{CustomTarget}}}";
			DirectEvents.Click.EventMask.ShowMask = true;

			if (String.IsNullString(IconCls) && String.IsNullString(IconUrl))
				IconUrl = Page.ClientScript.GetWebResourceUrl(typeof(ResourceManager),
					$@"Diten.Web.UI.Themes.{ResourceManager.Theme}.Icons.{DTIcon.ToString()}.png");
		}

		private void MenuItem_Init(object sender,
			EventArgs e)
		{
			Initialize();
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