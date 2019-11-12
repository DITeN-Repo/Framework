#region Using Directives

using System;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using Diten.ExtensionMethods;
using Diten.Variables;
using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	/// <inheritdoc cref="Ext.Net.Button" />
	[Meta]
	[ToolboxData("<{0}:Button runat=\"server\"></{0}:Button>")]
	public sealed class Button : Ext.Net.Button, IWebControlInterface
	{
		public Button()
		{
		}

		public Button(Config config) : base(config)
		{
		}

		public Button(string text) : base(text)
		{
		}

		public Button(string text, string handler) : base(text, handler)
		{
		}

		/// <summary>
		///     Custom target for click event mask.
		/// </summary>
		public string CustomTarget
		{
			get => ViewState.GetValue<string>(this.GetFrameName(), typeof(ContentPanel).ToString().ToArray().Last());
			set => ViewState.SetValue<string>(this.GetFrameName(), value);
		}

		/// <inheritdoc />
		/// <summary>
		///     Instance name of the button.
		/// </summary>
		[Category("0. About")]
		[Description("")]
		public override string InstanceOf => GetType().ToString();

		/// <summary>
		///     Click event mask message.
		/// </summary>
		public string MaskMessage
		{
			get => ViewState.GetValue<string>(this.GetFrameName(),
				$@"{Dictionary.Default.Loading}{Constants.Default.MaskDots}");
			set => ViewState.SetValue<string>(this.GetFrameName(), value);
		}

		/// <inheritdoc />
		/// <summary>
		///     XType of the button.
		/// </summary>
		[Category("0. About")]
		[Description("")]
		public override string XType
		{
			get
			{
				var memberInfo = GetType().BaseType;

				if (memberInfo != null)
					return memberInfo.ToString().Split(".".ToCharArray()).Last().ToLower();

				throw new NullReferenceException(Exceptions.Default.Diten_Web_UI_WebControls_Button_XType);
			}
		}

		/// <inheritdoc />
		/// <summary>
		///     Holder of the icon object.
		/// </summary>
		public Icon IconHolder
		{
			get => ViewState.GetValue<Icon>(this.GetFrameName(), new Icon(Icons.Default));
			private set => ViewState.SetValue(this.GetFrameName(), value);
		}

		/// <inheritdoc />
		public new Page Page => (HttpContext.Current.CurrentHandler as System.Web.UI.Page) as Page;

		/// <inheritdoc />
		/// <summary>
		///     Get or Set icon.
		/// </summary>
		public Icons DTIcon
		{
			get => IconHolder.Value;
			set
			{
				IconHolder = new Icon(value);
				IconUrl = IconHolder.ImageUrl;
			}
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

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			DirectEvents.Click.EventMask.Msg = new Page().Translate(MaskMessage);
			DirectEvents.Click.EventMask.Target = MaskTarget.CustomTarget;
			DirectEvents.Click.EventMask.CustomTarget = $@"#{{{CustomTarget}}}";
			DirectEvents.Click.EventMask.ShowMask = true;
			DirectEvents.Click.Event += Click_Event;
			IconHolder.Render();

			//todo:remove commented codes.
			//if (String.IsNullString(IconCls) && String.IsNullString(IconUrl))

			IconUrl = Page.ResourceManager.GetIconResource(DTIcon).Url;

			//Page.ClientScript.GetWebResourceUrl(typeof(ResourceManager),
			//        $@"Diten.Web.UI.Themes.{ResourceManager.Theme}.Icons.{DTIcon.ToString()}.png");

			//Page.ResourceManager.GetThemeResource(DTIcon.ToString(), true);
		}
	}
}