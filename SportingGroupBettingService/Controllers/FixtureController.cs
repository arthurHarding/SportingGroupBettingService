using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportingGroupBettingService.Models;

namespace SportingGroupBettingService.Controllers
{
      [ApiController]
      [Route("[controller]")]
      public class FixtureController : ControllerBase
      {
            private readonly ILogger<FixtureController> _logger;

            public FixtureController(ILogger<FixtureController> logger)
            {
                  _logger = logger;
            }

            [HttpGet]
            public IEnumerable<Fixture> Get()
            {
                  
            }
      }
}
