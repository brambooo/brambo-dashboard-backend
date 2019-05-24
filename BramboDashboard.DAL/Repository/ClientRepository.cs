using System.Threading.Tasks;
using BramboDashboard.Backend.DAL.Entities;
using BramboDashboard.Backend.DAL.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BramboDashboard.Backend.DAL.Repository
{
  public class ClientRepository : IClientRepository
  {
    private readonly BramboDashboardDbContext _context;

    public ClientRepository(BramboDashboardDbContext context)
    {
      _context = context;
    }

    public async Task AddAsync(ClientEntity user)
    {
      await _context.AddAsync(user);
      await _context.SaveChangesAsync();
    }

    public Task<ClientEntity> GetAsync(int userId)
    {
      return _context.ClientEntities.Include(client => client.WeightMeasurements).FirstOrDefaultAsync(client => client.Id == userId);
    }

    public Task Update(ClientEntity user)
    {
      _context.ClientEntities.Update(user);
      return _context.SaveChangesAsync();
    }
  }
}
