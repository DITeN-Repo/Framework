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
	/// <inheritdoc />
	[Meta]
	[ToolboxData("<{0}:ButtonGroup runat=\"server\"></{0}:ButtonGroup>")]
	public class ButtonGroup : Ext.Net.ButtonGroup
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
			set => ViewState.SetValue<Layouts>(this.GetFrameName(), delegate
			{
				base.Layout = value.ToString();
				return value;
			});
		}


		/// <summary>
		///     Get a reference to Diten.Web.UI.Page instance that contains server control.
		/// </summary>
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