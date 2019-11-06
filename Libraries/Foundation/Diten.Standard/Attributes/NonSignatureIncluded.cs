using System;
using System.Collections.Generic;
using System.Text;

namespace Diten.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
	public class NonSignaturized: Attribute {}
}
