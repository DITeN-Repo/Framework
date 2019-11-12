#region Using Directives

using System;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	/// <inheritdoc />
	/// ContentPanel control to holding content of a WebControl.
	/// ATTENTION!! A WebControl can not have more than one ContentPanel.
	[Meta]
	[ToolboxData("<{0}:ContentPanel runat=\"server\"></{0}:ContentPanel>")]
	public class ContentPanel : Panel
	{
		/// <summary>
		///     Read only ID of content panel.
		/// </summary>
		public sealed override string ID
		{
			get
			{
				if (base.ID.Equals(string.Empty))
					base.ID = $@"{GetType().ToString().Split(".".ToCharArray()).Last()}";

				return base.ID;
			}
		}

		/// <inheritdoc />
		/// <summary>
		/// </summary>
		[Category("0. About")]
		[Description("")]
		public override string InstanceOf => GetType().ToString();

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