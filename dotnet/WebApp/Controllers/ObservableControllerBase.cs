namespace WebApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public abstract class ObservableControllerBase : ControllerBase
    {
        // TODO add Logger, Trace, etc.
    }
}
