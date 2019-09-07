#region Using Directives

using System;

#endregion

namespace Diten.Tor.Events
{
	/// <summary>
	///     Specifies that a dispatcher class is associated with an event.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	internal sealed class EventAssocAttribute : Attribute
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="EventAssocAttribute" /> class.
		/// </summary>
		/// <param name="evt">The event the class is associated with.</param>
		public EventAssocAttribute(Event evt)
		{
			Event = evt;
		}

		#region Properties

		/// <summary>
		///     Gets the event the class is associated with.
		/// </summary>
		public Event Event { get; }

		#endregion
	}
}