using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SaaSBillingSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/saasbilling")]
    public class SaaBillingController : ControllerBase
    {
        [HttpGet("prueba")]
        public IActionResult GetPrueba()
        {
            return StatusCode(200,"Todo bien");
        }
    }
}