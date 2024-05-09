namespace snyder_volunteer_site.Data
{
	public class CalendarDay
	{
		public CalendarDay(DateTime date, IEnumerable<VolunteerEvent> volunteerEvents)
				=> (Date, VolunteerEvents) = (date, volunteerEvents);

		public DateTime Date { get; }
		public IEnumerable<VolunteerEvent> VolunteerEvents { get; }
	}
}
