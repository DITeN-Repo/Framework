// Copyright alright reserved by DITeN™ ©® 2003 - 2019
// ----------------------------------------------------------------------------------------------
// Agreement:
// 
// All developers could modify or developing this code but changing the architecture of
// the product is not allowed.
// 
// DITeN Research & Development
// ----------------------------------------------------------------------------------------------
// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/16 12:16 AM

#region Used Directives

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

#endregion

namespace Diten.Globalization
{
	/// <summary>
	///    <Author>Aref Bozorgmehr</Author>
	/// </summary>
	public sealed class PersianCulture: CultureInfo
	{
		public PersianCulture(): this("fa-IR",
		                              true) {}

		/// <param name="cultureName">fa-IR</param>
		/// <param name="useUserOverride">true</param>
		public PersianCulture(System.String cultureName,
		                      bool useUserOverride): base(cultureName,
		                                                  useUserOverride)
		{
			var persianCalendar = new PersianCalendar();
			CultureName = cultureName;

			//Temporary Value for cal.
			Calendar = base.OptionalCalendars[0];

			//populating new list of optional calendars.
			var optionalCalendarsList = new List<Calendar>();
			optionalCalendarsList.AddRange(base.OptionalCalendars);
			optionalCalendarsList.Insert(0,
			                             persianCalendar);

			var dateTimeFormatInfoType = typeof(DateTimeFormatInfo);
			var calendarType = typeof(Calendar);

			var propertyInfo = calendarType.GetProperty("ID",
			                                            BindingFlags.Instance | BindingFlags.NonPublic);
			var fieldInfo = dateTimeFormatInfoType.GetField("optionalCalendars",
			                                                BindingFlags.Instance | BindingFlags.NonPublic);

			//populating new list of optional calendar ids
			var optionalCalendarIDs = new int[optionalCalendarsList.Count];
			int i;
			for (i = 0;
			     i < optionalCalendarIDs.Length;
			     i++)
				if (propertyInfo != null)
					optionalCalendarIDs[i] = (int) propertyInfo.GetValue(optionalCalendarsList[i],
					                                                     null);

			if (fieldInfo != null)
				fieldInfo.SetValue(DateTimeFormat,
				                   optionalCalendarIDs);

			OptionalCalendars = optionalCalendarsList.ToArray();
			Calendar = OptionalCalendars[0];
			DateTimeFormat.Calendar = OptionalCalendars[0];

			DateTimeFormat.MonthNames = DateTimeFormat.MonthGenitiveNames = DateTimeFormat.AbbreviatedMonthNames =
				                                                                DateTimeFormat.AbbreviatedMonthGenitiveNames =
					                                                                persianCalendar.GetMonthsNameInYear().ToArray();

			var dayShortNames = persianCalendar.GetDaysShortNameInWeek(ExPersianCalendar.Orders.Gregorian).ToArray();

			DateTimeFormat.AbbreviatedDayNames = dayShortNames;
			DateTimeFormat.ShortestDayNames = dayShortNames;

			DateTimeFormat.DayNames = persianCalendar.GetDaysNameInWeek(ExPersianCalendar.Orders.Gregorian).ToArray();

			DateTimeFormat.AMDesignator = "ق.ظ";
			DateTimeFormat.PMDesignator = "ب.ظ";

			/*
			DateTimeFormat.ShortDatePattern = "yyyy/MM/dd";
			DateTimeFormat.LongDatePattern = "yyyy/MM/dd";
			
			DateTimeFormat.SetAllDateTimePatterns(new[] {"yyyy/MM/dd"}, 'd');
			DateTimeFormat.SetAllDateTimePatterns(new[] {"dddd, dd MMMM yyyy"}, 'D');
			DateTimeFormat.SetAllDateTimePatterns(new[] {"yyyy MMMM"}, 'y');
			DateTimeFormat.SetAllDateTimePatterns(new[] {"yyyy MMMM"}, 'Y');
			 */
		}

		public override Calendar Calendar {get;}

		/// <summary>
		///    Get culture name.
		/// </summary>
		public System.String CultureName {get;}

		public override Calendar[] OptionalCalendars {get;}
	}

	/// <summary>
	///    Specifies the date and time format
	/// </summary>
	public enum PersianDateTimeFormat
	{
		Date = 0,
		DateTime = 1,
		LongDate = 2,
		LongDateLongTime = 3,
		FullDate = 4,
		FullDateLongTime = 5,
		FullDateFullTime = 6,
		DateShortTime = 7,
		ShortDateShortTime = 8,
		LongDateFullTime = 9
	}

	/// <summary>
	///    Specifies the persian date and time mode to determining the PersianDateTime.Now.
	/// </summary>
	public enum PersianDateTimeMode
	{
		/// <summary>
		///    Using the current time zone.
		/// </summary>
		System,

		/// <summary>
		///    Using the persian time zone.
		/// </summary>
		PersianTimeZoneInfo,

		/// <summary>
		///    Using the UTC date and time with custom daylight saving time.
		/// </summary>
		UtcOffset
	}
}