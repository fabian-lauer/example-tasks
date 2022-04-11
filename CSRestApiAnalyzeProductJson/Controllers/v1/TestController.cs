using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSRestApiAnalyzeProductJson.Models;
using CSRestApiAnalyzeProductJson.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CSRestApiAnalyzeProductJson.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class TestController : ControllerBase
    {     
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [MapToApiVersion("1.0")]
        [HttpGet]        
        public IEnumerable<SimpleProduct> Get()
        {
            return SimpleProductService.FromUrl("https://raw.githubusercontent.com/fabian-lauer/example-tasks/main/CSRestApiAnalyzeProductJson/Docs/ProductData.json");
        }
    }
}
