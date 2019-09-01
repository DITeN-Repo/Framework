#region DITeN Registration Info

// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/15 4:42 PM

#endregion

#region Used Directives

using MongoDB.Bson.Serialization.Attributes;

#endregion

namespace Diten.Collections.Generic
{
	public interface IEntity<T>
	{
		String Name { get; set; }
		String Description { get; set; }
	}

	[BsonIgnoreExtraElements]
	public class Entity<T>:Object<T>, IEntity<T>
	{
		public String Name { get; set; }
		public String Description { get; set; }
	}
}