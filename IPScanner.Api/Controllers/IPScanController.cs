using Domain.Models;
using IPScanner.Application;
using Microsoft.AspNetCore.Mvc;

namespace IPScanner.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class IPScanController : ControllerBase
    {

        [HttpGet]
        [Route("{ip}")]
        public async Task<ActionResult<IPDetails>> GetIPDetails(string ip) 
        {
            //return
            return await (new IPInfoDetails()).GetDetails(ip);
        }
    }
}
