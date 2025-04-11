namespace Domain.Models
{
    public class HousingLocation
    {
        // XXX? DDD "should NOT have 'Id's"
        public int? Id { get; set; } = null;

        public string? Name { get; set; } = null;

        // TODO Group Citi/State
        public string? City { get; set; } = null;

        public string? State { get; set; } = null;

        public string? Photo { get; set; } = null;

        public int? AvailableUnits { get; set; } = null;

        public bool? Wifi { get; set; } = null;

        public bool? Laundry { get; set; } = null;
    }
}
