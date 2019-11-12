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
// Creation Date: 2019/09/04 10:05 PM

namespace Diten.Windows.Forms
{
	public class ProgressBar: System.Windows.Forms.ProgressBar
	{
		public new int Maximum
		{
			get => base.Maximum;
			set => SetMaximum(value);
		}

		public string ProgressPercentage => $"{Value * 100 / Maximum}%";

		public new string Text
		{
			get => base.Text;
			set => SetText(value);
		}

		public new int Value
		{
			get => base.Value;
			set => SetValue(value);
		}

		private void SetMaximum(int value)
		{
			if (InvokeRequired)
				Invoke(new MaximumDelegate(SetMaximum),
				       value);
			else base.Maximum = value;
		}

		private void SetText(System.String value)
		{
			if (InvokeRequired)
				Invoke(new TextDelegate(SetText),
				       value);
			else base.Text = value;
		}

		private void SetValue(int value)
		{
			if (InvokeRequired)
				Invoke(new ValueDelegate(SetValue),
				       value);
			else base.Value = value;
		}

		private delegate void MaximumDelegate(int value);

		private delegate void TextDelegate(System.String value);

		private delegate void ValueDelegate(int value);
	}
}