#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/16 12:16 AM

#endregion

namespace Diten.Globalization
{
	public class Weekday
	{
		public Weekday()
		{
		}

		public Weekday(int number, string name, string shortName)
		{
			Name=name;
			ShortName=shortName;
			Number=number;
		}

		/// <summary>
		///    Name of the day in the week.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		///    Short name of the day in the week.
		/// </summary>
		public string ShortName { get; set; }

		/// <summary>
		///    Number of the day in the week.
		/// </summary>
		public int Number { get; set; }
	}
}