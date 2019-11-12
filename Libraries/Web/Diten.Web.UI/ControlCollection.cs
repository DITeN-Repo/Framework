#region Using Directives

using System.Web.UI;

#endregion

namespace Diten.Web.UI
{
	public class ControlCollection : System.Web.UI.ControlCollection
	{
		public ControlCollection(Control owner) : base(owner)
		{
		}
	}
}