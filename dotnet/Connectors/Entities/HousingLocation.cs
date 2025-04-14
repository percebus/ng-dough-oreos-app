namespace Connectors.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class HousingLocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; } = -1;

        public string Name { get; set; } = null!;

        public string City { get; set; } = null!;

        public string State { get; set; } = null!;

        public string Photo { get; set; } = null!;

        public int AvailableUnits { get; set; } = 0;

        public bool Wifi { get; set; } = false;

        public bool Laundry { get; set; } = false;
    }
}
