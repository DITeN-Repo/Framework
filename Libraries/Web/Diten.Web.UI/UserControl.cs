#region Using Directives

using Diten.ExtensionMethods;
using Diten.Web.UI.WebControls;

#endregion

namespace Diten.Web.UI
{
	/// <inheritdoc />
	/// <summary>
	///     UserControl class.
	/// </summary>
	public class UserControl : BaseUserControl
	{
		/// <summary>
		///     Get or Set parent window ID.
		/// </summary>
		public Window Window
		{
			get => ViewState.GetValue<Window>(this.GetFrameName(), new Window());
			set => ViewState.SetValue(this.GetFrameName(), value);
		}
	}
}