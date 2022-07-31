using LiteDB;

namespace SportingGroupBettingService.LiteDb
{
      public interface ILiteDbContext
      {
            LiteDatabase Database { get; }
      }
}
