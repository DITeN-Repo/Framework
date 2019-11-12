#region Using Directives

using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Diten.Web.UI.WebControls;
using Ext.Net;
using DateColumn = Diten.Web.UI.WebControls.DateColumn;

#endregion

namespace Diten.Web.UI
{
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public static class ExBuilderFactory
	{
		#region DateColumn

		public static DateColumn.Builder DateColumn(this BuilderFactory factory)
		{
			return DateColumn(factory, new DateColumn
			{
				Renderer = new Renderer("return Ext.PDate.format(value, 'Y/m/d')")
			});
		}

		public static DateColumn.Builder DateColumn(this BuilderFactory factory,
			DateColumn component)
		{
			return new DateColumn.Builder(component);
		}

		#endregion

		#region PDateField

		public static PDateField.Builder PDateField(this BuilderFactory factory)
		{
#if MVC
            return PDateField(factory, new WebControls.PDateField(
            { 
                ViewContext = factory.DateField(). != null ? factory.HtmlHelper.ViewContext : null
            });
#else
			return PDateField(factory, new PDateField());
#endif
		}

		public static PDateField.Builder PDateField(this BuilderFactory factory,
			PDateField component)
		{
#if MVC
            component.ViewContext = factory.HtmlHelper != null ? factory.HtmlHelper.ViewContext : null;
#endif

			return new PDateField.Builder(component);
		}

		public static DateField.Builder DateField()
		{
#if MVC
			return this.DateField(new DateField { ViewContext =
 this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return DateField(new DateField());
#endif
		}

		/// <summary>
		/// </summary>
		public static DateField.Builder DateField(DateField component)
		{
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif
			return new DateField.Builder(component);
		}

		/// <summary>
		/// </summary>
		public static DateField.Builder DateField(DateField.Config config)
		{
#if MVC
			return new DateField.Builder(new DateField(config) { ViewContext =
this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new DateField.Builder(new DateField(config));
#endif
		}

#if MVC
        public static PDateField.Builder PDateFieldFor<TModel, TProperty>(this BuilderFactory factory,
            Expression<Func<TModel, TProperty>> expression, bool setId = false, Func<object, object> convert = null,
            string format = null)
        {
            return factory.InitFieldForBuilder<PDateField, PDateField.Builder, TProperty>(expression, setId, convert, format);
        }
#endif

		#endregion

		#region PDateFilter

		public static PDateFilter.Builder PDateFilter(this BuilderFactory factory)
		{
			return PDateFilter(factory, new PDateFilter
			{
				OnText = @"برابر با",
				BeforeText = "پیش از",
				AfterText = "پس از"
			}.SetViewContext(factory));
		}

		public static PDateFilter.Builder PDateFilter(this BuilderFactory factory,
			PDateFilter component)
		{
			return new PDateFilter.Builder(component.SetViewContext(factory));
		}

		private static PDateFilter SetViewContext(this PDateFilter component,
			BuilderFactory factory)
		{
			component.SetViewContext(factory);
			component.GetType()
				.GetProperty("ViewContext", BindingFlags.Instance
				                            | BindingFlags.NonPublic)
				.SetValue(component, factory);

			return component;
		}

		#endregion

		#region PDatePicker

		public static PDatePicker.Builder PDatePicker(this BuilderFactory factory)
		{
#if MVC
            return PDatePicker(factory, new PDatePickerOptions(
            {
                ViewContext = factory.HtmlHelper != null ? factory.HtmlHelper.ViewContext : null
            });
#else
			return PDatePicker(factory, new PDatePickerOptions());
#endif
		}

		public static PDatePicker.Builder PDatePicker(this BuilderFactory factory,
			PDatePicker component)
		{
			component.ViewModel = factory.ViewItem();
#if MVC
            component.ViewContext = factory.HtmlHelper != null ? factory.HtmlHelper.ViewContext : null;
#else
			return new PDatePicker.Builder(component);
#endif
		}

		/// <summary>
		/// </summary>
		public static PDatePicker.Builder PDatePicker()
		{
#if MVC
			return this.PDatePicker(new PDatePicker { ViewContext =
this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return PDatePicker(new PDatePicker());
#endif
		}

		/// <summary>
		/// </summary>
		public static PDatePicker.Builder PDatePicker(PDatePicker component)
		{
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif
			return new PDatePicker.Builder(component);
		}

		/// <summary>
		/// </summary>
		public static PDatePicker.Builder PDatePicker(DatePicker.Config config)
		{
#if MVC
			return new PDatePicker.Builder(new PDatePicker(config) { ViewContext =
this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new PDatePicker.Builder(new PDatePicker(config));
#endif
		}

		#endregion

		#region PDatePickerOptions

		public static PDatePickerOptions.Builder PDatePickerOptions(this BuilderFactory factory)
		{
			return PDatePickerOptions(factory, new PDatePickerOptions());

			//{    
			//    ViewContext = factory.HtmlHelper != null ? factory.HtmlHelper.ViewContext : null
			//});
		}

		public static PDatePickerOptions.Builder PDatePickerOptions(this BuilderFactory factory,
			PDatePickerOptions component)
		{
			component.ViewModel = factory.ViewItem();

			//component.ViewContext = factory.HtmlHelper != null ? factory.HtmlHelper.ViewContext : null;
			return new PDatePickerOptions.Builder(component);
		}

		/// <summary>
		/// </summary>
		public static PDatePickerOptions.Builder PDatePickerOptions()
		{
#if MVC
			return this.DatePickerOptions(new DatePickerOptions { ViewContext =
this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return PDatePickerOptions(new PDatePickerOptions());
#endif
		}

		/// <summary>
		/// </summary>
		public static PDatePickerOptions.Builder PDatePickerOptions(PDatePickerOptions component)
		{
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif
			return new PDatePickerOptions.Builder(component);
		}

		/// <summary>
		/// </summary>
		public static PDatePickerOptions.Builder PDatePickerOptions(DatePicker.Config config)
		{
#if MVC
			return new DatePickerOptions.Builder(new DatePickerOptions(config) { ViewContext =
this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new PDatePickerOptions.Builder(new PDatePickerOptions(config));
#endif
		}

		#endregion

		#region PGridFilters

		public static PGridFilters.Builder PGridFilters(this BuilderFactory factory)
		{
#if MVC
            return PGridFilters(factory, new PGridFilters(
            {
                ViewContext
 = factory.HtmlHelper != null ? factory.HtmlHelper.ViewContext : null
            });
#else
			return PGridFilters(factory, new PGridFilters());
#endif
		}

		public static PGridFilters.Builder PGridFilters(this BuilderFactory factory,
			PGridFilters component)
		{
#if MVC
            component.ViewContext = factory.HtmlHelper != null ? factory.HtmlHelper.ViewContext : null;
#endif
			return new PGridFilters.Builder(component);
		}

		#endregion
	}
}