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
            public int FixtureResultId { get; set; }
            public Bet.BetResult Result { get; set; }
            public bool Open { get; set; }
      }
}
