using BramboDashboard.Backend.DAL;
using BramboDashboard.Backend.DAL.Entities;
using BramboDashboard.Backend.DAL.Repository;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace BramboDashboard.Backend.Tests.DAL
{
  [TestClass]
  public class CoachRepositoryTests
  {
    private SqliteConnection _connection;
    private DbContextOptions<SportschoolVanDrunenDbContext> _options;
    private CoachRepository _sut;

    [TestInitialize]
    public void Initialize()
    {
      _connection = new SqliteConnection("DataSource=:memory:");
      _connection.Open();

      _options = new DbContextOptionsBuilder<SportschoolVanDrunenDbContext>()
        .UseSqlite(_connection)
        .Options;

      using (var c = new SportschoolVanDrunenDbContext(_options))
      {
        c.Database.EnsureCreated();
      }

      _sut = new CoachRepository(new SportschoolVanDrunenDbContext(_options));
    }

    [TestCleanup]
    public void Cleanup()
    {
      _connection.Close();
    }

    [TestMethod]
    public void CoachRepository_AddCoach()
    {
      var coachEntity = GetCoachEntity();
      _sut.Add(coachEntity).Wait();

      using (var context = new SportschoolVanDrunenDbContext(_options))
      {
        var result = context.CoachEntities.FindAsync(coachEntity.Id).Result;
        result.Id.ShouldBe(coachEntity.Id);
        result.Firstname.ShouldBe(coachEntity.Firstname);
        result.Lastname.ShouldBe(coachEntity.Lastname);
      }
    }

    #region Test Helpers

    private CoachEntity GetCoachEntity()
    {
      return new CoachEntity
      {
        Id = 1,
        Firstname = "Matt",
        Lastname = "Kieboom"
      };
    }
    #endregion
  }
}