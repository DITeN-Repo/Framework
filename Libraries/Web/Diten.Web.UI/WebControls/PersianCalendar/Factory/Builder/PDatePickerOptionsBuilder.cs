#region Using Directives

using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	public partial class PDatePickerOptions
	{
		public PDatePickerOptions()
		{
		}

		public PDatePickerOptions(Config config)
		{
			Apply(config);
		}

		/// <summary>
		/// </summary>
		public new Builder ToBuilder()
		{
			return Ext.Net.X.Builder.PDatePickerOptions(this);
		}

		/// <summary>
		/// </summary>
		public override IControlBuilder ToNativeBuilder()
		{
			return ToBuilder();
		}

		/// <summary>
		/// </summary>
		public new abstract class
			Builder<TPDatePickerOptions, TBuilder> : PDatePicker.Builder<TPDatePickerOptions, TBuilder>
			where TPDatePickerOptions : PDatePickerOptions
			where TBuilder : Builder<TPDatePickerOptions, TBuilder>
		{
			/*  Ctor
		        -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// </summary>
			public Builder(TPDatePickerOptions component) : base(component)
			{
			}

			/*  ConfigOptions
			 -----------------------------------------------------------------------------------------------*/

			/*  Methods
			 -----------------------------------------------------------------------------------------------*/
		}

		/// <summary>
		/// </summary>
		public new class Builder : Builder<PDatePickerOptions, Builder>
		{
			/*  Ctor
		        -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// </summary>
			public Builder() : base(new PDatePickerOptions())
			{
			}

			/// <summary>
			/// </summary>
			public Builder(PDatePickerOptions component) : base(component)
			{
			}

			/// <summary>
			/// </summary>
			public Builder(Config config) : base(new PDatePickerOptions(config))
			{
			}

			/*  Implicit Conversion
		        -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// </summary>
			public static implicit operator Builder(PDatePickerOptions component)
			{
				return component.ToBuilder();
			}
		}
	}
}