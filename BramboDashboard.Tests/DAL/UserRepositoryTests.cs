using System;
using System.Collections.Generic;
using BramboDashboard.Backend.DAL;
using BramboDashboard.Backend.DAL.Entities;
using BramboDashboard.Backend.DAL.Repository;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace BramboDashboard.Backend.Tests.DAL
{
    public class UserRepositoryTests
    {
      [TestClass]
      public class CoachRepositoryTests
      {
        private SqliteConnection _connection;
        private DbContextOptions<SportschoolVanDrunenDbContext> _options;
        private ClientRepository _sut;

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

          _sut = new ClientRepository(new SportschoolVanDrunenDbContext(_options));
        }

        [TestCleanup]
        public void Cleanup()
        {
          _connection.Close();
        }

        [TestMethod]
        public void UserRepository_AddAndGetUser()
        {
          var userEntity = SetupUserEntity();
          var expectedUserId = 1;

          _sut.AddAsync(userEntity).Wait();
          var result = _sut.GetAsync(expectedUserId).Result;

          result.Id.ShouldBe(userEntity.Id);
          result.Firstname.ShouldBe(userEntity.Firstname);
          result.Lastname.ShouldBe(userEntity.Lastname);
          result.Password.ShouldBe(userEntity.Password);
        }

        [TestMethod]
        public void UserRepository_AddAndGetUserWithWeight()
        {
          var userEntity = SetupUserEntity();
          var expectedUserId = 1;
          var userWeightEntity = new ClientWeightEntity
          {
            Id = 1,
            Weight = 85.5M,
            RegisterDate = new DateTime(2018, 05, 31)
          };
          userEntity.UserWeightEntities = new List<ClientWeightEntity>();
          userEntity.UserWeightEntities.Add(userWeightEntity);

          _sut.AddAsync(userEntity).Wait();
          var result = _sut.GetAsync(expectedUserId).Result;

            result.Id.ShouldBe(userEntity.Id);
            result.Firstname.ShouldBe(userEntity.Firstname);
            result.Lastname.ShouldBe(userEntity.Lastname);
            result.Password.ShouldBe(userEntity.Password);
            result.UserWeightEntities.Count.ShouldBe(1);
            result.UserWeightEntities[0].Weight.ShouldBe(userWeightEntity.Weight);
            result.UserWeightEntities[0].RegisterDate.ShouldBe(userWeightEntity.RegisterDate);
        }

        [TestMethod]
        public void UserRepository_UpdateUser()
        {
          var userEntity = SetupUserEntity();
          var expectedUserId = 1;
          var userWeightEntity = new ClientWeightEntity
          {
            Weight = 85.5M,
            RegisterDate = new DateTime(2018, 05, 31)
          };

          var userWeightEntity2 = new ClientWeightEntity
          {
            Weight = 86.5M,
            RegisterDate = new DateTime(2018, 06, 01)
          };

          userEntity.UserWeightEntities = new List<ClientWeightEntity>();
          userEntity.UserWeightEntities.Add(userWeightEntity);

          _sut.AddAsync(userEntity).Wait();
          var result = _sut.GetAsync(expectedUserId).Result;

          // Update email and register new weight
          result.Email = "keesjansen@outlook.com";
          result.UserWeightEntities.Add(userWeightEntity2);

          _sut.Update(userEntity).Wait();
          var updatedUserEntity = _sut.GetAsync(expectedUserId).Result;

          updatedUserEntity.Email.ShouldBe("keesjansen@outlook.com");
          updatedUserEntity.UserWeightEntities.Count.ShouldBe(2);
          updatedUserEntity.UserWeightEntities[1].Id.ShouldBe(userWeightEntity2.Id);
          updatedUserEntity.UserWeightEntities[1].Weight.ShouldBe(userWeightEntity2.Weight);
          updatedUserEntity.UserWeightEntities[1].RegisterDate.ShouldBe(userWeightEntity2.RegisterDate);
        }

      #region Test Helpers

      private ClientEntity SetupUserEntity()
        {
          return new ClientEntity
          {
            Firstname = "Kees",
            Lastname = "Jansen",
            Password = "123456",
            Email = "keesjansen@gmail.com"
          };
        }
        #endregion
      }
    }
}
