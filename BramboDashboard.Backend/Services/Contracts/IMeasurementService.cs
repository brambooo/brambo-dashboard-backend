using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BramboDashboard.Backend.API.Models;

namespace BramboDashboard.Backend.API.Services.Contracts
{
    public interface IMeasurementService
    {
      Task RegisterMeasurementAsync(int clientId, RegisterMeasurement measurement);
      Task<IList<GetMeasurement>> GetMeasurementsAsync(int clientId);
      Task<GetMeasurement> GetMeasurementForDateAsync(int clientId, DateTime date);
      Task<IList<GetMeasurement>> GetMeasurementForPeriodAsync(int clientId, DateTime startDate, DateTime endDate);

  }
}
