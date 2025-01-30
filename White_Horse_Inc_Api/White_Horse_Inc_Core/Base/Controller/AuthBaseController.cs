using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace White_Horse_Inc_Core.Base.Controller
{
    public class AuthBaseController 
    {
        [ApiController]
        public abstract class BaseController() : ControllerBase
        {
        }

        [Authorize]
        public abstract class AuthBSController : ControllerBase
        {
            protected IActionResult ForbiddenResponse()
            {
                return Forbid();
            }

            protected IActionResult UnauthorizedResponse()
            {
                return Unauthorized();
            }
        }
    }
}
