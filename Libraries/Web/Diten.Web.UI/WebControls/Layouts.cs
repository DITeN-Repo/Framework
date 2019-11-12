// ReSharper disable All

namespace Diten.Web.UI.WebControls
{
	public class Layouts<T>
	{
		private T _value;

		public T Value
		{
			get
			{
				// insert desired logic here
				return _value;
			}
			set
			{
				// insert desired logic here
				_value = value;
			}
		}

		public static implicit operator T(Layouts<T> value)
		{
			return value.Value;
		}

		public static implicit operator Layouts<T>(T value)
		{
			return new Layouts<T> {Value = value};
		}
	}

	/// <inheritdoc />
	public enum Layouts
	{
		None,
		Absolute,
		Accordion,
		Anchor,
		Border,
		Card,
		Center,
		Column,
		Fit,
		Form,
		HBox,
		Table,
		VBox
	}
}