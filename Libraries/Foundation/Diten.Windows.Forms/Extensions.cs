// Copyright alright reserved by DITeN� �� 2003 - 2019
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

using System;
using System.Windows.Forms;

#endregion

namespace Diten.Windows.Forms
{
	public static class Extensions
	{
		public static void Invoke<TControlType>(this TControlType control,
		                                        Action<TControlType> del)
			where TControlType: Control
		{
			if (control.InvokeRequired) control.Invoke(new Action(() => del(control)));
			else del(control);
		}
	}
}