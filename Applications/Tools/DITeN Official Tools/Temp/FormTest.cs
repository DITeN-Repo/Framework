using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diten.Windows.Applications.Tools.Official.Temp
{
	public partial class FormTest:Form
	{
		private char[] c;
		public FormTest()
		{
			InitializeComponent();
		}

		private void buttonA_Click(object sender, EventArgs e)
		{
			var timeHolder = DateTime.Now.Millisecond;

			c = textBoxSource.Text.ToCharArray();

			Inverse_Helper(0,
			               c.Length - 1);
			var p = 0;
			for (var i = 0;
			     i <= c.Length - 1;
			     i++)
			{
				if (c[i] == 32)
				{
					Inverse_Helper(p,
					               i - 1);
					p = i + 1;
				}
			}

			Inverse_Helper(p,
			               c.Length - 1);

			textBoxA.Text = new string(c);

			buttonA.Text = (DateTime.Now.Millisecond - timeHolder).ToString();
		}

		private void Inverse_Helper(int left,
		                            int right)
		{
			while (left < right)
			{
				var charHolder = c[left];
				c[left] = c[right];
				c[right] = charHolder;
				left++;
				right--;
			}
		}

		private void buttonB_Click(object sender,
		                           EventArgs e)
		{
			textBoxB.Text = string.Empty;

			var timeHolder = DateTime.Now.Millisecond;

			var r = textBoxSource.Text.ToCharArray().Reverse().ToList();
			var w = " ";
			var h = "";
			var i = 0;
			var k = 0;

			while (i < r.Count)
			{
				if (r[i] == 32)
				{
					r.Reverse(i,
					          k);
					k = 0;
				}

				k++;
				i++;
			}

			textBoxB.Text = new string(r.ToArray());
			buttonB.Text = (DateTime.Now.Millisecond - timeHolder).ToString();
		}

		private void buttonC_Click(object sender, EventArgs e)
		{
			textBoxC.Text = "";

			var timeHolder = DateTime.Now.Millisecond;

			//textBoxC.Text = textBoxSource.Text.ToCharArray()
			//                             .Reverse()
			//									  .Aggregate("",
			//                                        (result,
			//                                         current) => new Func<string, >()");

			buttonC.Text = (DateTime.Now.Millisecond - timeHolder).ToString();
		}
	}
}
