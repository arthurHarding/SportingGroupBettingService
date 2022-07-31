using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportingGroupBettingService.Models
{
      public class FixtureOdds
      {
            public int Id { get; set; }
            public int FixtureId { get; set; }
            public int TeamId { get; set; }
            public double WagerMultiplier { get; set; }
      }
}
