using System.Threading.Tasks;
using BramboDashboard.Backend.DAL.Entities;

namespace BramboDashboard.Backend.DAL.Repository
{
    public class CoachRepository : ICoachRepository
    {
      private readonly SportschoolVanDrunenDbContext _context;

      public CoachRepository(SportschoolVanDrunenDbContext context)
      {
        _context = context;
      }

      public async Task Add(CoachEntity coach)
      {
        await _context.AddAsync(coach);
        await _context.SaveChangesAsync();
      }
  }
}
