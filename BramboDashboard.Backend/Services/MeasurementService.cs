using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BramboDashboard.Backend.API.Models;
using BramboDashboard.Backend.API.Services.Contracts;
using BramboDashboard.Backend.DAL.Entities;
using BramboDashboard.Backend.DAL.Repository.Contracts;

namespace BramboDashboard.Backend.API.Services
{
  public class MeasurementService : IMeasurementService
    {
      private readonly IMeasurementRepository _measurementRepository;
      private readonly IMapper _mapper;

      public MeasurementService(IMeasurementRepository measurementRepository, IMapper mapper)
      {
        _measurementRepository = measurementRepository;
        _mapper = mapper;
      }

      public async Task RegisterMeasurementAsync(int clientId, RegisterMeasurement measurement)
      {
        var measurementEntity = _mapper.Map<MeasurementEntity>(measurement);
        await _measurementRepository.AddAsync(clientId, measurementEntity);
      }

      public async Task<IList<GetMeasurement>> GetMeasurementsAsync(int clientId)
      {
        var measurementEntities = await _measurementRepository.GetAllAsync(clientId);
        return _mapper.Map<IList<GetMeasurement>>(measurementEntities);
      }

    public async Task<GetMeasurement> GetMeasurementForDateAsync(int clientId, DateTime date)
    {
      var measurementEntity = await _measurementRepository.GetForDateAsync(clientId, date);
      return _mapper.Map<GetMeasurement>(measurementEntity);
    }

    public async Task<IList<GetMeasurement>> GetMeasurementForPeriodAsync(int clientId, DateTime startDate, DateTime endDate)
    {
      var measurementEntities= await _measurementRepository.GetForPeriodAsync(clientId, startDate, endDate);
      return _mapper.Map<IList<GetMeasurement>>(measurementEntities);
    }
  }

}
