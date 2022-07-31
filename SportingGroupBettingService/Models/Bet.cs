using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportingGroupBettingService.Models
{
      public class Bet
      {
            public enum BetStatus
            {
                  Undecided,
                  Won,
                  Lost
            }

            public int Id { get; set; }
            public DateTime DateTimePlaced { get; set; }
            public BetStatus Result { get; set; }
            public double TotalProfitLoss { get; set; }
            public bool Open { get; set; }
      }
}
