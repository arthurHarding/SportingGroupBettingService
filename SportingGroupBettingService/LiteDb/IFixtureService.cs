using System.Collections.Generic;
using SportingGroupBettingService.Models;

namespace SportingGroupBettingService.LiteDb
{
      public interface IFixtureService
      {
            int Insert(Fixture fixture);
            Fixture Get(int id);
            List<Fixture> GetAll();
            bool Update(Fixture fixture);

            int InsertTeam(Team team);
            Team GetTeam(int id);
            List<Team> GetTeams();

            void InsertFixtureOdds(List<FixtureOdds> odds);
            List<FixtureOdds> GetFixtureOddsForFixture(int fixtureId);
            FixtureOdds GetFixtureOdds(int id);
      }
}
