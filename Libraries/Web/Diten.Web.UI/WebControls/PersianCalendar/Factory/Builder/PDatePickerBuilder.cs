#region Using Directives

using System;
using Ext.Net;

#endregion

namespace Diten.Web.UI.WebControls
{
	public partial class PDatePicker
	{
		/// <summary>
		/// </summary>
		public PDatePicker()
		{
		}

		/// <summary>
		/// </summary>
		public PDatePicker(Config config)
		{
			Apply(config);
		}

		/*  Implicit DatePicker.Config Conversion to DatePicker
		  -----------------------------------------------------------------------------------------------*/

		/// <summary>
		/// </summary>
		public static implicit operator PDatePicker(Config config)
		{
			return new PDatePicker(config);
		}

		/// <summary>
		/// </summary>
		public new Builder ToBuilder()
		{
			return Ext.Net.X.Builder.PDatePicker(this);
		}

		/// <summary>
		/// </summary>
		public override IControlBuilder ToNativeBuilder()
		{
			return ToBuilder();
		}

		/// <summary>
		/// </summary>
		public new abstract class Builder<TPDatePicker, TBuilder> : ComponentBase.Builder<TPDatePicker, TBuilder>
			where TPDatePicker : PDatePicker
			where TBuilder : Builder<TPDatePicker, TBuilder>
		{
			/*  Ctor
		        -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// </summary>
			public Builder(TPDatePicker component) : base(component)
			{
			}

			/// <summary>
			///     Server-side Ajax Event Handlers
			/// </summary>
			/// <param name="action">The action delegate</param>
			/// <returns>An instance of TBuilder</returns>
			public virtual TBuilder DirectEvents(Action<DatePickerDirectEvents> action)
			{
				action(ToComponent().DirectEvents);

				return this as TBuilder;
			}

			/// <summary>
			///     An array of \"dates\" to disable, as strings. These strings will be used to build a dynamic regular expression so
			///     they are very powerful.
			/// </summary>
			/// <param name="action">The action delegate</param>
			/// <returns>An instance of TBuilder</returns>
			public virtual TBuilder DisabledDates(Action<DisabledDateCollection> action)
			{
				action(ToComponent().DisabledDates);

				return this as TBuilder;
			}

			/// <summary>
			///     The fields null value.
			/// </summary>
			/// <param name="action">The action delegate</param>
			/// <returns>An instance of TBuilder</returns>
			public virtual TBuilder EmptyValue(Action<object> action)
			{
				action(ToComponent().EmptyValue);

				return this as TBuilder;
			}

			/// <summary>
			///     Client-side JavaScript Event Handlers
			/// </summary>
			/// <param name="action">The action delegate</param>
			/// <returns>An instance of TBuilder</returns>
			public virtual TBuilder Listeners(Action<DatePickerListeners> action)
			{
				action(ToComponent().Listeners);

				return this as TBuilder;
			}

			/// <summary>
			///     Gets or sets the current selected date of the DatePicker.
			/// </summary>
			/// <param name="action">The action delegate</param>
			/// <returns>An instance of TBuilder</returns>
			public virtual TBuilder SelectedValue(Action<object> action)
			{
				action(ToComponent().SelectedValue);

				return this as TBuilder;
			}
		}

		/// <summary>
		/// </summary>
		public new class Builder : Builder<PDatePicker, Builder>
		{
			/*  Ctor
		        -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// </summary>
			public Builder() : base(new PDatePicker(new Config()))
			{
			}

			/// <summary>
			/// </summary>
			public Builder(PDatePicker component) : base(component)
			{
			}

			/// <summary>
			/// </summary>
			public Builder(Config config) : base(new PDatePicker(config))
			{
			}

			/*  Implicit Conversion
		        -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// </summary>
			public static implicit operator Builder(PDatePicker component)
			{
				return component.ToBuilder();
			}
		}
	}
}