using System;
using System.Collections.Generic;
using System.Text;
//Test
namespace Diten
{
	/// <summary>
	/// Representing the standard object in DITeN Framework that all other objects will be inherited from this object.
	/// <seealso cref="Collections.Generic.DeepObject{TObject}"/>
	/// </summary>
	public class Object: Collections.Generic.DeepObject<Object> {}
}
