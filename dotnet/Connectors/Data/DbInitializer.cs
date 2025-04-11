namespace Connectors.Data
{
    using System.Linq;
    using Connectors.Entities;

    // SRC: https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-9.0
    public static class DbInitializer
    {
        public static void Initialize(FirstAppContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.HousingLocations.Any())
            {
                return;   // DB has been seeded
            }


            var housingLocations = new HousingLocation[]
            {
                new HousingLocation { Id = 0, Name = "Acme Fresh Start Housing", City = "Chicago", State = "IL", Wifi = true, Laundry = true, AvailableUnits = 4, Photo = "https://angular.dev/assets/images/tutorials/common/bernard-hermant-CLKGGwIBTaY-unsplash.jpg" },
                new HousingLocation { Id = 1, Name = "A113 Transitional Housing", City = "Santa Monica", State = "CA", Wifi = false, Laundry = true, AvailableUnits = 0, Photo = "https://angular.dev/assets/images/tutorials/common/brandon-griggs-wR11KBaB86U-unsplash.jpg" },
                new HousingLocation { Id = 2, Name = "Warm Beds Housing Support", City = "Juneau", State = "AK", Wifi = false, Laundry = false, AvailableUnits = 1, Photo = "https://angular.dev/assets/images/tutorials/common/i-do-nothing-but-love-lAyXdl1-Wmc-unsplash.jpg" },
                new HousingLocation { Id = 3, Name = "Homesteady Housing", City = "Chicago", State = "IL", Wifi = true, Laundry = false, AvailableUnits = 1, Photo = "https://angular.dev/assets/images/tutorials/common/ian-macdonald-W8z6aiwfi1E-unsplash.jpg" },
                new HousingLocation { Id = 4, Name = "Happy Homes Group", City = "Gary", State = "IN", Wifi = true, Laundry = false, AvailableUnits = 1, Photo = "https://angular.dev/assets/images/tutorials/common/krzysztof-hepner-978RAXoXnH4-unsplash.jpg" },
                new HousingLocation { Id = 5, Name = "Hopeful Apartment Group", City = "Oakland", State = "CA", Wifi = true, Laundry = true, AvailableUnits = 2, Photo = "https://angular.dev/assets/images/tutorials/common/r-architecture-JvQ0Q5IkeMM-unsplash.jpg" },
                new HousingLocation { Id = 6, Name = "Seriously Safe Towns", City = "Oakland", State = "CA", Wifi = true, Laundry = true, AvailableUnits = 5, Photo = "https://angular.dev/assets/images/tutorials/common/phil-hearing-IYfp2Ixe9nM-unsplash.jpg" },
                new HousingLocation { Id = 7, Name = "Hopeful Housing Solutions", City = "Oakland", State = "CA", Wifi = true, Laundry = true, AvailableUnits = 2, Photo = "https://angular.dev/assets/images/tutorials/common/r-architecture-GGupkreKwxA-unsplash.jpg" },
                new HousingLocation { Id = 8, Name = "Seriously Safe Towns", City = "Oakland", State = "CA", Wifi = false, Laundry = false, AvailableUnits = 10, Photo = "https://angular.dev/assets/images/tutorials/common/saru-robert-9rP3mxf8qWI-unsplash.jpg" },
                new HousingLocation { Id = 9, Name = "Capital Safe Towns", City = "Portland", State = "OR", Wifi = true, Laundry = true, AvailableUnits = 6, Photo = "https://angular.dev/assets/images/tutorials/common/webaliser-_TPTXZd9mOo-unsplash.jpg" }
            };

            foreach (HousingLocation entry in housingLocations)
            {
                context.HousingLocations.Add(entry);
            }

            context.SaveChanges();
        }
    }
}
