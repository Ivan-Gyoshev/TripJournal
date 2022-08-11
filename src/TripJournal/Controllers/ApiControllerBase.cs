using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TripJournal.Web.Controllers
{
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
    }

    [Authorize]
    public class AuthorizedApiController : ApiControllerBase
    {
    }
}
