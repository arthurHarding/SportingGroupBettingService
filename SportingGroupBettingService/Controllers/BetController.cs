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
      public class BetController : ControllerBase
      {
            #region Member Variables

            private readonly ILogger<BetController> _logger;
            private IBetService _betDbService;
            private IFixtureService _fixtureDbService;

            #endregion

            #region Constructor

            public BetController(ILogger<BetController> logger, IBetService betDbService, IFixtureService fixtureDbService)
            {
                  _logger = logger;
                  _betDbService = betDbService;
                  _fixtureDbService = fixtureDbService;
                  _betDbService.Insert(new Bet()
                  {
                        DateTimePlaced = DateTime.Now,
                        Open = true
                  });
            }

            #endregion

            #region API Methods

            [HttpGet]
            public ActionResult<Bet> GetOne(int id)
            {
                  DecideBetResult(id);
                  return _betDbService.Get(id);
            }

            [HttpPost]
            public ActionResult<int> Insert(List<BetComponent> components)
            {
                  var betId = InsertNewBet();

                  InsertBetComponents(components, betId);

                  return betId;
            }

            #endregion

            #region Private Methods

            private void DecideBetResult(int betId)
            {
                  UpdateBetComponentResults(betId);
                  UpdateBetResult(betId);
            }

            private void UpdateBetComponentResults(int betId)
            {
                  var rnd = new Random();
                  var components = _betDbService.GetComponentsForBet(betId);

                  foreach (var component in components)
                  {
                        component.Open = false;
                        var won = rnd.Next(1, 2) == 1;

                        if (won)
                        {
                              component.Status = Bet.BetStatus.Won;

                              var odds = _fixtureDbService.GetFixtureOdds(component.FixtureOddsId);
                              component.ProfitLoss = odds.WagerMultiplier * component.Wager;
                        }
                        else
                        {
                              component.Status = Bet.BetStatus.Lost;
                              component.ProfitLoss = -component.Wager;
                        }

                        _betDbService.UpdateBetComponent(component);
                  }
            }

            private void UpdateBetResult(int betId)
            {
                  var components = _betDbService.GetComponentsForBet(betId);
                  var bet = _betDbService.Get(betId);

                  bet.Open = false;
                  bet.Result = components.All(x => x.Status == Bet.BetStatus.Won) ? Bet.BetStatus.Won : Bet.BetStatus.Lost;
                  bet.TotalProfitLoss = components.Select(x => x.ProfitLoss).Sum();

                  _betDbService.Update(bet);
            }

            private int InsertNewBet()
            {
                  var bet = new Bet()
                  {
                        DateTimePlaced = DateTime.Now,
                        Open = true
                  };

                  return _betDbService.Insert(bet);
            }

            private void InsertBetComponents(List<BetComponent> components, int betId)
            {
                  foreach (var component in components)
                  {
                        component.BetId = betId;
                        component.Open = true;
                        component.Status = Bet.BetStatus.Undecided;
                  }

                  _betDbService.InsertBetComponents(components);
            }

            #endregion
      }
}
