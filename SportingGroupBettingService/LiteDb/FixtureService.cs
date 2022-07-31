using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using SportingGroupBettingService.Models;

namespace SportingGroupBettingService.LiteDb
{
      public class FixtureService : IFixtureService
      {
            private LiteDatabase _liteDb;

            public FixtureService(ILiteDbContext dbContext)
            {
                  _liteDb = dbContext.Database;
            }

            public int Insert(Fixture fixture)
            {
                  return _liteDb.GetCollection<Fixture>("Fixtures").Insert(fixture);
            }

            public Fixture Get(int id)
            {
                  return _liteDb.GetCollection<Fixture>("Fixtures").FindOne(x => x.Id == id);
            }

            public List<Fixture> GetAll()
            {
                  return _liteDb.GetCollection<Fixture>("Fixtures").FindAll().ToList();
            }

            public bool Update(Fixture fixture)
            {
                  return _liteDb.GetCollection<Fixture>("Fixtures").Update(fixture);
            }
            
            public int InsertTeam(Team team)
            {
                  return _liteDb.GetCollection<Team>("Teams").Insert(team);
            }

            public Team GetTeam(int id)
            {
                  return _liteDb.GetCollection<Team>("Teams").FindOne(x => x.Id == id);
            }

            public List<Team> GetTeams()
            {
                  return _liteDb.GetCollection<Team>("Teams").FindAll().ToList();
            }
             
            public void InsertFixtureOdds(List<FixtureOdds> odds)
            {
                  _liteDb.GetCollection<FixtureOdds>("Fixture Odds").InsertBulk(odds);
            }

            public List<FixtureOdds> GetFixtureOddsForFixture(int fixtureId)
            {
                  return _liteDb.GetCollection<FixtureOdds>("Fixture Odds").Find(x => x.FixtureId == fixtureId).ToList();
            }

            public FixtureOdds GetFixtureOdds(int id)
            {
                  return _liteDb.GetCollection<FixtureOdds>("Fixture Odds").FindOne(x => x.Id == id);
            }
      }
}
