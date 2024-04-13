using Microsoft.AspNetCore.Mvc;

namespace bookstore.Controllers;
[Route("api/[controller]")]
[ApiController]
public abstract class BookstoreBaseController : ControllerBase
{
    [HttpGet("healthy")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public virtual IActionResult Healthy()
    {
        return Ok("Endpoint is working");
    }
}
