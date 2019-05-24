using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BramboDashboard.Backend.DAL.Entities;
using BramboDashboard.Backend.DAL.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BramboDashboard.Backend.DAL.Repository
{
  public class MeasurementRepository : IMeasurementRepository
  {
    private readonly BramboDashboardDbContext _context;
    private readonly IClientRepository _clientRepository;

    public MeasurementRepository(BramboDashboardDbContext context, IClientRepository clientRepository)
    {
      _context = context;
      _clientRepository = clientRepository;
    }

    public async Task<IList<MeasurementEntity>> GetAllAsync(int clientId)
    {
      return await _context.MeasurementEntities.ToListAsync();
    }

    public async Task AddAsync(int clientId, MeasurementEntity weight)
    {
      var client = await _clientRepository.GetAsync(clientId);

        client.WeightMeasurements.Add(weight);
       _context.SaveChanges();
    }

    public async Task<MeasurementEntity> GetForDateAsync(int clientId, DateTime date)
    {
      var client = await _clientRepository.GetAsync(clientId);
      return client.WeightMeasurements.FirstOrDefault(measurement => measurement.RegisterDate.Date == date);
    }

    public async Task<IList<MeasurementEntity>> GetForPeriodAsync(int clientId, DateTime startDate, DateTime endDate)
    {
      var client = await _clientRepository.GetAsync(clientId);
      return client.WeightMeasurements
        .Where(measurement => measurement.RegisterDate.Date >= startDate.Date && measurement.RegisterDate.Date <= endDate)
        .ToList();
    }

  }
}
