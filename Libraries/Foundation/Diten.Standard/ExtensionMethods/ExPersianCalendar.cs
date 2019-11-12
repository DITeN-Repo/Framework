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
// Creation Date: 2019/08/15 4:42 PM

#region Used Directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Diten.Globalization;
using JetBrains.Annotations;

#endregion

namespace Diten
{
	public static class ExPersianCalendar
	{
		/// <summary>
		///    Generation types of the generator method.
		/// </summary>
		public enum Generations
		{
			Weekdays,
			Months
		}

		/// <summary>
		///    Ordering days types.
		/// </summary>
		public enum Orders
		{
			Standard,
			Gregorian
		}

		private const string MonthNamesStringCollection =
			",فروردین,اردیبهشت,خرداد,تیر,مرداد,شهریور,مهر,آبان,آذر,دی,بهمن,اسفند";

		private const string WeekdaysStringCollection = ",شنبه,یکشنبه,دوشنبه,ﺳﻪشنبه,چهارشنبه,پنجشنبه,جمعه";

		private static List<Weekday> Generator(Orders order,
		                                       Generations generation)
		{
			var _return = new List<Weekday>();

			//Inline Function
			List<System.String> tmpFunction1()
			{
				switch (generation)
				{
					case Generations.Weekdays: return WeekdaysStringCollection.Split(",".ToCharArray()).ToList();
					case Generations.Months: return MonthNamesStringCollection.Split(",".ToCharArray()).ToList();
					default:
						throw new ArgumentOutOfRangeException(nameof(generation),
						                                      generation,
						                                      null);
				}
			}

			var holder = tmpFunction1();

			for (var index = 0;
			     index < holder.Count;
			     index++)
				switch (order)
				{
					case Orders.Standard:
						_return.Add(new Weekday(index,
						                        holder[index],
						                        holder[index].ToCharArray().FirstOrDefault().ToString()));

						break;
					case Orders.Gregorian:
						switch (index)
						{
							case 0: continue;
							case 6:
								_return.Add(new Weekday(0,
								                        holder[0],
								                        holder[0].ToCharArray().FirstOrDefault().ToString()));

								break;
							default:
								_return.Add(new Weekday(index,
								                        holder[index],
								                        holder[index].ToCharArray().FirstOrDefault().ToString()));

								break;
						}

						break;
					default:
						throw new ArgumentOutOfRangeException(nameof(order),
						                                      order,
						                                      null);
				}

			return _return;
		}

		/// <summary>
		///    Get list of the days in a week.
		/// </summary>
		/// <param name="calendar">Calendar instance that must be used for operations.</param>
		/// <param name="order">
		///    Ordering days in persian standard (first day of the week is saturday) or gregorian standard (first
		///    dat of the week is monday)
		/// </param>
		/// <returns>A <see cref="List{T}" /> of <see cref="Diten.Globalization.Weekday" /></returns>
		public static List<Weekday> GetDaysInWeek([NotNull] this PersianCalendar calendar,
		                                          Orders order = Orders.Standard)
		{
			if (calendar == null) throw new ArgumentNullException(nameof(calendar));

			return Generator(order,
			                 Generations.Weekdays);
		}

		/// <summary>
		///    Get <see cref="IEnumerable{T}" /> of the day names in a week.
		/// </summary>
		/// <param name="calendar">Calendar instance that must be used for operations.</param>
		/// <param name="order">
		///    Ordering days in persian standard (first day of the week is saturday) or gregorian standard (first
		///    dat of the week is monday).
		/// </param>
		/// <returns>A <see cref="IEnumerable{T}" /> of weekdays names.</returns>
		public static IEnumerable<System.String> GetDaysNameInWeek([NotNull] this PersianCalendar calendar,
		                                                    Orders order = Orders.Standard)
		{
			if (calendar == null) throw new ArgumentNullException(nameof(calendar));
			if (!System.Enum.IsDefined(typeof(Orders),
			                           order))
				throw new InvalidEnumArgumentException(nameof(order),
				                                       (int) order,
				                                       typeof(Orders));

			return WeekdaysStringCollection.Split(",".ToCharArray());
		}

		/// <summary>
		///    Get <see cref="IEnumerable{T}" /> of the day names in a week.
		/// </summary>
		/// <param name="calendar">Calendar instance that must be used for operations.</param>
		/// <param name="order">
		///    Ordering days in persian standard (first day of the week is saturday) or gregorian standard (first
		///    dat of the week is monday).
		/// </param>
		/// <returns>A <see cref="IEnumerable{T}" /> of short weekdays names.</returns>
		public static IEnumerable<System.String> GetDaysShortNameInWeek(this PersianCalendar calendar,
		                                                         Orders order = Orders.Standard)
		{
			if (!System.Enum.IsDefined(typeof(Orders),
			                           order))
				throw new InvalidEnumArgumentException(nameof(order),
				                                       (int) order,
				                                       typeof(Orders));

			return GetDaysNameInWeek(calendar)
			       .Aggregate(System.String.Empty,
			                  (next,
			                   day) => $",{next.PadRight(1)}")
			       .Split(",".ToCharArray());
		}

		public static List<Weekday> GetMonthsInYear([NotNull] this PersianCalendar calendar,
		                                            Orders order = Orders.Standard)
		{
			if (calendar == null) throw new ArgumentNullException(nameof(calendar));

			return Generator(order,
			                 Generations.Months);
		}

		/// <summary>
		///    Get <see cref="IEnumerable{T}" /> of the months names in a year.
		/// </summary>
		/// <param name="calendar">Calendar instance that must be used for operations.</param>
		/// <param name="order">
		///    Ordering days in persian standard (first day of the week is saturday) or gregorian standard (first
		///    dat of the week is monday).
		/// </param>
		/// <returns>A <see cref="IEnumerable{T}" /> of months names.</returns>
		public static IEnumerable<System.String> GetMonthsNameInYear([NotNull] this PersianCalendar calendar,
		                                                      Orders order = Orders.Standard)
		{
			if (calendar == null) throw new ArgumentNullException(nameof(calendar));
			if (!System.Enum.IsDefined(typeof(Orders),
			                           order))
				throw new InvalidEnumArgumentException(nameof(order),
				                                       (int) order,
				                                       typeof(Orders));

			return MonthNamesStringCollection.Split(",".ToCharArray());
		}

		/// <summary>
		///    Get <see cref="IEnumerable{T}" /> of the months names in a year.
		/// </summary>
		/// <param name="calendar">Calendar instance that must be used for operations.</param>
		/// <param name="order">
		///    Ordering days in persian standard (first day of the week is saturday) or gregorian standard (first
		///    dat of the week is monday).
		/// </param>
		/// <returns>A <see cref="IEnumerable{T}" /> of short months names.</returns>
		public static IEnumerable<System.String> GetMonthsShortNameInYear(this PersianCalendar calendar,
		                                                           Orders order = Orders.Standard)
		{
			if (!System.Enum.IsDefined(typeof(Orders),
			                           order))
				throw new InvalidEnumArgumentException(nameof(order),
				                                       (int) order,
				                                       typeof(Orders));

			return GetMonthsNameInYear(calendar)
			       .Aggregate(System.String.Empty,
			                  (next,
			                   day) => $",{next.PadRight(2)}")
			       .Split(",".ToCharArray());
		}
	}
}