#region Using Directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Web.UI;
using Ext.Net;
using Ext.Net.Utilities;

#endregion

namespace Diten.Web.UI.WebControls
{
	[Meta]
	[ToolboxData("<{0}:PDatePicker runat=\"server\"></{0}:PDatePicker>")]
	public partial class PDatePicker : DatePicker
	{
		/// <summary>
		/// </summary>
		[ConfigOption("ariaTitleDateFormat")]
		[DefaultValue("F d, Y")]
		[Description("")]
		protected new string AriaTitleDateFormatProxy
		{
			get
			{
				var ci = Thread.CurrentThread.CurrentCulture;

				return DateTimeUtils.ConvertNetToPHP(AriaTitleDateFormat, ci);
			}
		}

		/// <summary>
		/// </summary>
		[ConfigOption("disabledDates", JsonMode.Raw)]
		[DefaultValue("")]
		[Description("")]
		protected new string DisabledDatesProxy =>
			DisabledDates.ToString(Format.IsEmpty() ? "yyyy-MM-dd\\Thh:mm:ss" : Format,
				Thread.CurrentThread.CurrentCulture);

		/// <summary>
		///     The fields null value.
		/// </summary>
		[Meta]
		[Category("5. Field")]
		[Description("The fields null value.")]
		public new virtual object EmptyValue
		{
			get => State.Get<object>("EmptyValue", new DateTime(0001, 01, 01));
			set => State.Set("EmptyValue", value);
		}

		/// <summary>
		/// </summary>
		[ConfigOption("format")]
		[DefaultValue("")]
		[Description("")]
		protected new string FormatProxy
		{
			get
			{
				var ci = Thread.CurrentThread.CurrentCulture;

				return DateTimeUtils.ConvertNetToPHP(Format, ci);
			}
		}

		/// <summary>
		/// </summary>
		[Category("0. About")]
		[Description("")]
		public override string InstanceOf => "Ext.picker.PDate";

		/// <summary>
		/// </summary>
		[ConfigOption("longDayFormat")]
		[DefaultValue("")]
		[Description("")]
		protected new string LongDayFormatProxy
		{
			get
			{
				var ci = Thread.CurrentThread.CurrentCulture;

				return
					DateTimeUtils.ConvertNetToPHP(LongDayFormat.IsEmpty()
						? ci.DateTimeFormat.LongDatePattern
						: LongDayFormat);
			}
		}

		/// <summary>
		/// </summary>
		[ConfigOption("monthYearFormat")]
		[DefaultValue("F Y")]
		[Description("")]
		protected new string MonthYearFormatProxy
		{
			get
			{
				var ci = Thread.CurrentThread.CurrentCulture;

				return DateTimeUtils.ConvertNetToPHP(MonthYearFormat, ci);
			}
		}

		/// <summary>
		/// </summary>
		[Description("")]
		protected override List<ResourceItem> Resources
		{
			get
			{
				var baseList = base.Resources;
				baseList.Capacity += 3;

				baseList.Add(new ClientScriptItem(typeof(PDatePicker),
					"Diten.Web.UI.WebControls.PersianCalendar.PDate.pdate.js", ""));
				baseList.Add(new ClientScriptItem(typeof(PDatePicker),
					"Diten.Web.UI.WebControls.PersianCalendar.PDate.picker.PMonth.js",
					""));
				baseList.Add(new ClientScriptItem(typeof(PDatePicker),
					"Diten.Web.UI.WebControls.PersianCalendar.PDate.picker.PDate.js",
					""));

				return baseList;
			}
		}

		/// <summary>
		///     Gets or sets the current selected date of the DatePicker. Accepts and returns a DateTime object.
		/// </summary>
		[Meta]
		[Category("4. DatePicker")]
		[DefaultValue(typeof(DateTime), "0001-01-01")]
		[Bindable(true, BindingDirection.TwoWay)]
		[Description("Gets or sets the current selected date of the DatePicker. Accepts and returns a DateTime object.")
		]
		public new virtual DateTime SelectedDate
		{
			get
			{
				var obj = Value;

				return (DateTime?) obj ?? (DateTime) EmptyValue;
			}
			set => Value = value.Date;
		}

		/// <summary>
		/// </summary>
		[Meta]
		[Category("4. DatePicker")]
		[Bindable(true, BindingDirection.TwoWay)]
		[Description("Gets or sets the current selected date of the DatePicker.")]
		public new virtual object SelectedValue
		{
			get => IsEmpty ? EmptyValue : SelectedDate;
			set
			{
				var init = value;

				if (init is DateTime)
					SelectedDate = (DateTime) init;
				else if (init == null || init is DBNull)
					SelectedDate = (DateTime) EmptyValue;
				else
					try
					{
						SelectedDate = DateTime.Parse(init.ToString(),
							Thread.CurrentThread.CurrentCulture.DateTimeFormat);
					}
					catch (FormatException)
					{
						SelectedDate = (DateTime) EmptyValue;
					}
			}
		}

		/// <summary>
		/// </summary>
		[Meta]
		[ConfigOption(typeof(CtorDateTimeJsonConverter))]
		[DirectEventUpdate(MethodName = "SetValueProxy")]
		[DefaultValue(null)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		public new virtual object Value
		{
			get => State.Get<object>("Value", null);
			set
			{
				if (SafeResourceManager == null)
				{
					Init += delegate { Value = State.Get<object>("Value", null); };
					State.Set("Value", value);

					return;
				}

				EmptyValue = new DateTime(0001, 01, 01);

				var obj = (DateTime) EmptyValue;

				var s = value as string;

				if (s != null)
					try
					{
						obj = DateTime.ParseExact(s, Format, Thread.CurrentThread.CurrentCulture);
					}
					catch
					{
						try
						{
							obj = DateTime.Parse(s, Thread.CurrentThread.CurrentCulture);
						}
						catch
						{
							// ignored
						}
					}
				else if (value is DateTime)
					obj = (DateTime) value;

				State.Set("Value", obj);
			}
		}

		/// <summary>
		/// </summary>
		[Category("0. About")]
		[Description("")]
		public override string XType => "pdatepicker";

		/// <summary>
		///     Replaces any existing disabled dates with new values and refreshes the DatePicker.
		/// </summary>
		public new void UpdateDisabledDates()
		{
			Call("setDisabledDates",
				new JRawValue(DisabledDates.ToString(Format, Thread.CurrentThread.CurrentCulture)));
		}
	}
}