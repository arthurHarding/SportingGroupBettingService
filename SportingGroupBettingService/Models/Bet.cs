using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportingGroupBettingService.Models
{
      public class Bet
      {
            public enum BetResult
            {
                  Undecided,
                  Won,
                  Lost,
                  Invalid
            }

            public int Id { get; set; }
            public DateTime DateTimePlaced { get; set; }
            public BetResult Result { get; set; }
            public bool Open { get; set; }
      }
}
