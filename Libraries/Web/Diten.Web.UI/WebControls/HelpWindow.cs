#region Using Directives

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Diten.ExtensionMethods;
using Diten.Variables;
using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	#region Refrences

	#endregion

	[Meta]
	[ToolboxData("<{0}:HelpWindow runat=\"server\"></{0}:HelpWindow>")]
	public class HelpWindow : Window
	{
		public HelpWindow()
		{
			Init += HelpWindow_Init;
		}

		/// <summary>
		///     ButtonOk.
		/// </summary>
		public new Button ButtonOk
		{
			get => ViewState.GetValue<Button>(this.GetFrameName(), delegate
			{
				return new Button
				{
					Icon = Ext.Net.Icon.Accept,
					Text = @"Close"
				};
			});
			set => ViewState.SetValue<Button>(this.GetFrameName(), value);
		}

		/// <summary>
		///     HelpId.
		/// </summary>
		public string HelpId
		{
			get => ViewState.GetValue<string>(this.GetFrameName(), string.Empty);
			set => ViewState.SetValue<string>(this.GetFrameName(), value);
		}

		private void HelpWindow_Init(object sender,
			EventArgs e)
		{
			Initialize();
		}

		private void Initialize()
		{
			Title = @"Help";
			Width = Unit.Pixel(600);
			Height = Unit.Pixel(600);
			AutoRender = false;
			Collapsible = true;
			Maximizable = true;
			Hidden = true;
			Icon = Ext.Net.Icon.Help;
			Loader = new ComponentLoader
			{
				Url = $@"http://help.diten.net/default.aspx?HelpId={HelpId}",
				Mode = LoadMode.Frame,
				LoadMask =
				{
					Msg = $@"Loading help{Constants.Default.MaskDots}",
					ShowMask = true
				}
			};
			Buttons.Add(ButtonOk);
		}
	}
}