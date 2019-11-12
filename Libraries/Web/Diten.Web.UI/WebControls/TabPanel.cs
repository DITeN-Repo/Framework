#region Using Directives

using System;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using Diten.ExtensionMethods;
using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	[Meta]
	[ToolboxData("<{0}:TabPanel runat=\"server\"></{0}:TabPanel>")]
	public class TabPanel : Ext.Net.TabPanel
	{
		/// <inheritdoc />
		/// <summary>
		/// </summary>
		[Category("0. About")]
		[Description("")]
		public override string InstanceOf => GetType().ToString();

		/// <summary>
		///     Get or Set window layout.
		/// </summary>
		public new Layouts Layout
		{
			get => ViewState.GetValue<Layouts>(this.GetFrameName(), Layouts.None);
			set
			{
				base.Layout = value.ToString();
				ViewState.SetValue(this.GetFrameName(), value);
			}
		}

		/// <inheritdoc />
		/// <summary>
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

				throw new NullReferenceException("Base type is null. This component is not inherited form an object.");
			}
		}
	}
}