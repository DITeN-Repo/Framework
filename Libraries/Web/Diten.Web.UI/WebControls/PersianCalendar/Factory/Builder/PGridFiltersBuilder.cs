#region Using Directives

using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	public partial class PGridFilters
	{
		public PGridFilters()
		{
		}

		public PGridFilters(Config config)
		{
			Apply(config);
		}

		public new Builder ToBuilder()
		{
			return new BuilderFactory().PGridFilters(this);
		}

		public new class Builder : Builder<PGridFilters, Builder>
		{
			public Builder() : base(new PGridFilters())
			{
			}

			public Builder(PGridFilters component) : base(component)
			{
			}

			public Builder(Config config) : base(new PGridFilters(config))
			{
			}
		}

		public new class Config : GridFilters.Config
		{
			public static implicit operator Builder(Config config)
			{
				return new Builder(config);
			}
		}
	}
}