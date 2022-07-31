using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportingGroupBettingService.Models
{
      public class BetComponent
      {
            public int Id { get; set; }
            public int BetId { get; set; }
            public int FixtureOddsId { get; set; }
            public double Wager { get; set; }
            public double ProfitLoss { get; set; }
            public Bet.BetStatus Status { get; set; }
            public bool Open { get; set; }
      }
}
