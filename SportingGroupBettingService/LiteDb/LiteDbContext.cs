using LiteDB;
using Microsoft.Extensions.Options;

namespace SportingGroupBettingService.LiteDb
{
      public class LiteDbContext : ILiteDbContext
      {
            public LiteDatabase Database { get; }

            public LiteDbContext()
            {
                  Database = new LiteDatabase("LiteDb/LiteDbTest.db");
            }
      }
}
