#region Using Directives

using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

#endregion

namespace WindowsFormsApp
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		public string Msg => StackTraceFirstFrameName;

		protected string StackTraceFirstFrameName
		{
			get
			{
				var _return = new StackTrace().GetFrame(1).GetMethod().Name;

				if (_return.StartsWith("get_")) return _return.TrimStart("get_".ToCharArray());
				return _return.StartsWith("set_") ? _return.TrimStart("set_".ToCharArray()) : _return;
			}
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			//var arabic = Encoding.GetEncoding(1256);
			var result = string.Empty;
			var base64 =
				System.Convert.FromBase64String("eJwztU7Ni09LtDa0sNAzN9WzMNIzNbA28i6KLE7JLDaKjEjK8svMM/JxNQMA80kMDg==");

			foreach (var encodingInfo in Encoding.GetEncodings())
			{
				var tmp = encodingInfo.GetEncoding().GetString(base64);

				var holder = tmp.ToCharArray().Aggregate(string.Empty,
					(current, VARIABLE) => current + $@"{((int) VARIABLE).ToString()};");
				dataSet1.Tables[0].Rows.Add(encodingInfo.DisplayName, tmp, holder);
				//textBox1.Text +=
				//	$@"{Environment.NewLine}Encoding: {encodingInfo.DisplayName} {Environment.NewLine} Characters: {Environment.NewLine}{holder}{Environment.NewLine} Value:{tmp} {Environment.NewLine}";
				Application.DoEvents();

			}

			//MessageBox.Show(result);
			return;
			
			MessageBox.Show(Msg);
			MessageBox.Show(StackTraceFirstFrameName);
		}
	}
}