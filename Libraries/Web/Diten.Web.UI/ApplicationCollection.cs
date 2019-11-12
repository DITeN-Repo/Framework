#region Using Directives

using Diten.Web.UI.WebControls;

#endregion

namespace Diten.Web.UI
{
	public class ApplicationCollection : ControlCollection
	{
		public ApplicationCollection(Desktop desktop) : base(desktop)
		{
		}

		public void Add(Application application)
		{
			base.Add(application);
		}
	}
}