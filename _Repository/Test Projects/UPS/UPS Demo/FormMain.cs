using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPS_Demo
{
	public partial class FormMain:Form
	{
		public FormMain()
		{
			InitializeComponent();
		}

		private void ButtonApply_Click(object sender, EventArgs e)
		{
			var currentValueValue = arcScaleComponentParameter.Value = 80;

			textBoxCurrentValue.Text = currentValueValue.ToString(CultureInfo.InvariantCulture);

			for (var i = 0; i < currentValueValue; i++)
			{
				textBoxCurrentValue.Text = (arcScaleComponentParameter.Value-- - 1).ToString(CultureInfo.InvariantCulture);
				Application.DoEvents();
				System.Threading.Thread.Sleep(50);
				if (Math.Abs(arcScaleComponentParameter.Value - (float) numericUpDownActionValue.Value) > 0) continue;

				MessageBox.Show(new RemoteShutdownServiceReference.ServiceClient().Shutdown(true));
				break;
			}

			MessageBox.Show(@"Operation done successfully");

			arcScaleComponentParameter.Value=80;
			textBoxCurrentValue.Text = arcScaleComponentParameter.Value.ToString(CultureInfo.InvariantCulture);

		}
	}
}
