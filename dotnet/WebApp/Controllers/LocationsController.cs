namespace WebApp.Controllers
{
    using Connectors;
    using Microsoft.AspNetCore.Mvc;

    [Route("[controller]")] // NOTE: The tutorial references /locations directly
    public class LocationsController : FirstAppContextControllerBase
    {
        public LocationsController(FirstAppContext context) : base(context)
        {
        }

        [HttpGet]
        public IActionResult FindLocations() // TODO add search parameters
        {
            var locations = this.Context.HousingLocations.ToList();
            return this.Ok(locations);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetLocation(int id)
        {
            var location = this.Context.HousingLocations.FirstOrDefault(l => l.Id == id);
            if (location == null)
            {
                return this.NotFound();
            }

            return this.Ok(location);
        }
    }
}
