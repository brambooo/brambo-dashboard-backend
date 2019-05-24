using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BramboDashboard.Backend.DAL.Entities;

namespace BramboDashboard.Backend.DAL.Repository.Contracts
{
  public interface IMeasurementRepository
  {
    Task<IList<MeasurementEntity>> GetAllAsync(int clientId);
    Task AddAsync(int clientId, MeasurementEntity weight);
    Task<MeasurementEntity> GetForDateAsync(int clientId, DateTime date);
    Task<IList<MeasurementEntity>> GetForPeriodAsync(int clientId, DateTime startDate, DateTime endDate);
  }
}
