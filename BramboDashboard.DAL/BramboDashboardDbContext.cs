using BramboDashboard.Backend.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BramboDashboard.Backend.DAL
{
  public class BramboDashboardDbContext : DbContext
  {
    public BramboDashboardDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ClientEntity> ClientEntities { get; set; }
    public DbSet<MeasurementEntity> MeasurementEntities { get; set; }
  }
}
