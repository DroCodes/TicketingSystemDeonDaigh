namespace TicketingSystem.Models
{
    public class Filters
    {
        public Filters(string filterstring)
        {
            FilterString = filterstring ?? "all-all-all-all";
            string[] filters = FilterString.Split('-');
            Name = filters[0];
            StatusId = filters[1];
            SprintNum = filters[2];
            Point = filters[3];
        }
        public string FilterString { get; }
        public string Name { get; }
        public string StatusId { get; }
        public string SprintNum { get; }
        public string Point { get; }

        public bool HasName => Name.ToLower() != "all";
        public bool HasStatus => StatusId.ToLower() != "all";
        public bool HasSprintNumber => SprintNum != "all";
        public bool HasPointValue => Point.ToLower() != "all";
    }
}
