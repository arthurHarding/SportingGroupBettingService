using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportingGroupBettingService.Models
{
      public class Fixture
      {
            public enum AvailableSports
            {
                  Squash,
                  Tennis
            }

            public int Id { get; set; }
            public AvailableSports Sport { get; set; }
            public string Title { get; set; }
            public int Team1Id { get; set; }
            public int Team2Id { get; set; }
            public int WinningTeamId { get; set; }
            public List<FixtureOdds> Odds { get; set; }
      }
}
