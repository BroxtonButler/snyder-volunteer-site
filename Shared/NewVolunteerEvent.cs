namespace snyder_volunteer_site.Shared
{
	public class NewVolunteerEvent
	{
		public NewVolunteerEvent(DateTime selectedDate)
		{
			EventDate = selectedDate;
		}
		public string EventName { get; set; }
		public string EventDescription { get; set; }
		public DateTime EventDate { get; set; }
	}
}
