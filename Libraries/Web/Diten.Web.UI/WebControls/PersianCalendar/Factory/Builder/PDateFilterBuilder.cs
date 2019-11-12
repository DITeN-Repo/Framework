#region Using Directives

using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	public partial class PDateFilter
	{
		public PDateFilter()
		{
		}

		public PDateFilter(Config config)
		{
			Apply(config);
		}

		public new Builder ToBuilder()
		{
			return new BuilderFactory().PDateFilter(this);
		}

		public new class Builder : Builder<PDateFilter, Builder>
		{
			public Builder() : base(new PDateFilter())
			{
			}

			public Builder(PDateFilter component) : base(component)
			{
			}

			public Builder(Config config) : base(new PDateFilter(config))
			{
			}
		}

		public new class Config : DateFilter.Config
		{
			public static implicit operator Builder(Config config)
			{
				return new Builder(config);
			}
		}
	}
}