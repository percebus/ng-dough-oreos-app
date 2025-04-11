namespace Domain
{
    public class HousingLocation
    {
        public int? Id { get; set; } = null;

        public string? Name { get; set; } = null;

        public string? City { get; set; } = null;

        public string? State { get; set; } = null;

        public string? Photo { get; set; } = null;

        public int? AvailableUnits { get; set; } = null;

        public bool? Wifi { get; set; } = null;

        public bool? Laundry { get; set; } = null;
    }
}
