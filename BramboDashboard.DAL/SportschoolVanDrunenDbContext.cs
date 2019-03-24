using BramboDashboard.Backend.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BramboDashboard.Backend.DAL
{
  public class SportschoolVanDrunenDbContext : DbContext
  {
    public SportschoolVanDrunenDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<CoachEntity> CoachEntities { get; set; }
    public DbSet<ClientEntity> ClientEntities { get; set; }
    public DbSet<WeightEntity> WeightEntities { get; set; }
  }
}
