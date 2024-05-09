namespace snyder_volunteer_site.Data
{
	public class VolunteerEvent
	{
		public VolunteerEvent() 
		{
		
		}
		public VolunteerEvent(Guid eventId, string name, string description, DateTime eventDate)
			=> (EventId, EventName, EventDescription, EventDate) = (eventId, name, description, eventDate);

		public Guid EventId { get; }
		public string EventName { get; }
		public string EventDescription { get; }
		public DateTime EventDate { get; }
	}
}
