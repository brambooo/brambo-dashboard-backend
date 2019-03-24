using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BramboDashboard.Backend.DAL.Entities;
using BramboDashboard.Backend.DAL.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BramboDashboard.Backend.DAL.Repository
{
  public class WeightRepository : IWeightRepository
  {
    private readonly SportschoolVanDrunenDbContext _context;
    private readonly IClientRepository _clientRepository;

    public WeightRepository(SportschoolVanDrunenDbContext context, IClientRepository clientRepository)
    {
      _context = context;
      _clientRepository = clientRepository;
    }

    public async Task<IList<WeightEntity>> GetAllAsync(int clientId)
    {
      return await _context.WeightEntities.ToListAsync();
    }

    public async Task AddAsync(int clientId, WeightEntity weight)
    {
      var client = await _clientRepository.GetAsync(clientId);

      client.WeightMeasurements.Add(weight);
      _context.SaveChanges();
    }
  }
}
