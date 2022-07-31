using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using SportingGroupBettingService.Models;

namespace SportingGroupBettingService.LiteDb
{
      public class BetService : IBetService
      {
            private LiteDatabase _liteDb;

            public BetService(ILiteDbContext dbContext)
            {
                  _liteDb = dbContext.Database;
            }

            public int Insert(Bet bet)
            {
                  return _liteDb.GetCollection<Bet>("Bets").Insert(bet);
            }

            public Bet Get(int id)
            {
                  return _liteDb.GetCollection<Bet>("Bets").FindOne(x => x.Id == id);
            }

            public bool Update(Bet bet)
            {
                  return _liteDb.GetCollection<Bet>("Bets").Update(bet);
            }

            public void InsertBetComponents(List<BetComponent> components)
            {
                  _liteDb.GetCollection<BetComponent>("Bet Components").InsertBulk(components);
            }

            public List<BetComponent> GetComponentsForBet(int betId)
            {
                  return _liteDb.GetCollection<BetComponent>("Bet Components").Find(x => x.BetId == betId).ToList();
            }

            public List<BetComponent> GetBetComponentsForFixtureOdds(int fixtureOddsId)
            {
                  return _liteDb.GetCollection<BetComponent>("Bet Components").Find(x => x.FixtureOddsId == fixtureOddsId).ToList();
            }

            public bool UpdateBetComponent(BetComponent component)
            {
                  return _liteDb.GetCollection<BetComponent>("Bet Components").Update(component);
            }
      }
}
