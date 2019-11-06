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

#region Used Directives

using System.Windows.Forms;

#endregion

namespace Diten.Windows.Forms
{
	public partial class JobForm: UserControl
	{
		public JobForm() { InitializeComponent(); }

		public Information Information => GetInformationControl(0);

		public void AddInformationBox(int count)
		{
			for (var i = 0;
			     i < count;
			     i++)
			{
				tableLayoutPanelInformationContainer.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
				tableLayoutPanelInformationContainer.Controls.Add(new Information
				                                                  {
					                                                  Dock = DockStyle.Fill,
					                                                  Name = $@"Information{i + 1}".ToUpper()
				                                                  },
				                                                  i,
				                                                  0);
			}
		}

		public Information GetInformationControl(int index) { return (Information) tableLayoutPanelInformationContainer.Controls[index]; }
	}
}