namespace WebApp.Controllers
{
    using Connectors;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class LocationsController : ControllerBase
    {
        protected FirstAppContext Context { get; private set; }

        public LocationsController(FirstAppContext context)
        {
            this.Context = context;
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
