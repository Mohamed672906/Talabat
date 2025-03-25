    using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.ABIS.Errors;

namespace Talabat.ABIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi =true)]
    public class ErrorsController : ControllerBase
    {

        public IActionResult Error(int code)
        {

            return NotFound(new ApiResponce(code));

        }








    }
}
