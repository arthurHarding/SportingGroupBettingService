using System.Collections.Generic;
using SportingGroupBettingService.Models;

namespace SportingGroupBettingService.LiteDb
{
      public interface IBetService
      {
            int Insert(Bet bet);
            Bet Get(int id);
            bool Update(Bet bet);

            void InsertBetComponents(List<BetComponent> components);
            List<BetComponent> GetComponentsForBet(int betId);
            List<BetComponent> GetBetComponentsForFixtureOdds(int fixtureOddsId);
            bool UpdateBetComponent(BetComponent component);
      }
}
