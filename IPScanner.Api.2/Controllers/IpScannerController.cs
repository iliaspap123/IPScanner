using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPScanner.Api._2.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class IpScannerController : ControllerBase
    {

        private readonly IIPInfoProvider _ipInfoProvider;

        public IpScannerController(IIPInfoProvider ipInfoProvider)
        {
            _ipInfoProvider = ipInfoProvider;
        }

        [HttpGet]
        [Route("{ip}")]
        public async Task<ActionResult<IPDetails>> GetIPDetails(string ip)
        {
            return await _ipInfoProvider.GetDetails(ip);
        }
    }
}
