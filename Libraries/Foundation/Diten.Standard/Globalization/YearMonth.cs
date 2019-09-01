#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/16 12:16 AM

#endregion

namespace Diten.Globalization
{
	public class YearMonth
	{
		public YearMonth()
		{
		}

		public YearMonth(int number, string name, string shortName)
		{
			Name=name;
			ShortName=shortName;
			Number=number;
		}

		/// <summary>
		///    Name of the month in the year.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		///    Short name of the month in the year.
		/// </summary>
		public string ShortName { get; set; }

		/// <summary>
		///    Number of the month in the year.
		/// </summary>
		public int Number { get; set; }
	}
}