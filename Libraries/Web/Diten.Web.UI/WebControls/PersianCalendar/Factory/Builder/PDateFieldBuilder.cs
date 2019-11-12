#region Using Directives

using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	public partial class PDateField
	{
		public PDateField()
		{
		}

		public PDateField(Config config)
		{
			Apply(config);
		}

		public new Builder ToBuilder()
		{
			return new BuilderFactory().PDateField(this);
		}

		public new class Builder : Builder<PDateField, Builder>
		{
			public Builder() : base(new PDateField())
			{
			}

			public Builder(PDateField component) : base(component)
			{
			}

			public Builder(Config config) : base(new PDateField(config))
			{
			}
		}

		public new class Config : DateField.Config
		{
			public static implicit operator Builder(Config config)
			{
				return new Builder(config);
			}
		}
	}
}