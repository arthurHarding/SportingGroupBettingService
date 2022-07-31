using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportingGroupBettingService.Models;
using SportingGroupBettingService.LiteDb;

namespace SportingGroupBettingService.Controllers
{
      [ApiController]
      [Route("[controller]")]
      public class FixtureController : ControllerBase
      {
            #region Member Variables

            private readonly ILogger<FixtureController> _logger;
            private IFixtureService _fixtureDbService;

            #endregion

            #region Constructor

            public FixtureController(ILogger<FixtureController> logger, IFixtureService fixtureDbService)
            {
                  _logger = logger;
                  _fixtureDbService = fixtureDbService;
                  _fixtureDbService.Insert(new Fixture
                  {
                        Sport = Fixture.AvailableSports.Squash,
                        Team1Id = 1,
                        Team2Id = 2,
                        Title = "Test Match"
                  });
            }

            #endregion

            #region API Methods

            [HttpGet]
            public IEnumerable<Fixture> Get()
            {
                  return _fixtureDbService.GetAll();
            }

            [HttpGet]
            public ActionResult<Fixture> GetOne(int id)
            {
                  return _fixtureDbService.Get(id);
            }

            [HttpGet]
            public IEnumerable<FixtureOdds> GetFixtureOdds(int fixtureId)
            {
                  return _fixtureDbService.GetFixtureOddsForFixture(fixtureId);
            }

            [HttpPost]
            public ActionResult<int> Insert(Fixture dto)
            {
                  var fixtureId = _fixtureDbService.Insert(dto);

                  InsertFixtureOdds(dto.Odds, fixtureId);

                  return fixtureId;
            }

            [HttpGet]
            public IEnumerable<Team> GetTeams()
            {
                  return _fixtureDbService.GetTeams();
            }

            #endregion

            #region Private Methods

            private void InsertFixtureOdds(List<FixtureOdds> odds, int fixtureId)
            {
                  foreach (var odd in odds)
                  {
                        odd.FixtureId = fixtureId;
                  }

                  _fixtureDbService.InsertFixtureOdds(odds);
            }

            #endregion
      }
}
