using System.Threading.Tasks;
using BramboDashboard.Backend.DAL.Entities;
using BramboDashboard.Backend.DAL.Repository.Contracts;

namespace BramboDashboard.Backend.DAL.Repository
{
  public class ClientRepository : IClientRepository
  {
    private readonly SportschoolVanDrunenDbContext _context;

    public ClientRepository(SportschoolVanDrunenDbContext context)
    {
      _context = context;
    }

    public async Task AddAsync(ClientEntity user)
    {
      await _context.AddAsync(user);
      await _context.SaveChangesAsync();
    }

    public async Task<ClientEntity> GetAsync(int userId)
    {
      return await _context.FindAsync<ClientEntity>(userId);
     }

    public async Task Update(ClientEntity user)
    {
      _context.ClientEntities.Update(user);
      await _context.SaveChangesAsync();
    }
  }
}
