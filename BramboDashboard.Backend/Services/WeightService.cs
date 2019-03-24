using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BramboDashboard.Backend.API.Models;
using BramboDashboard.Backend.API.Services.Contracts;
using BramboDashboard.Backend.DAL.Entities;
using BramboDashboard.Backend.DAL.Repository.Contracts;

namespace BramboDashboard.Backend.API.Services
{
  public class WeightService : IWeightService
    {
      private readonly IWeightRepository _weightRepository;
      private readonly IMapper _mapper;

      public WeightService(IWeightRepository weightRepository, IMapper mapper)
      {
        _weightRepository = weightRepository;
        _mapper = mapper;
      }

      public async Task RegisterWeight(int clientId, Weight weight)
      {
        var weightEntity = _mapper.Map<WeightEntity>(weight);
        await _weightRepository.AddAsync(clientId, weightEntity);
      }

      public async Task<IList<Weight>> GetWeights(int clientId)
      {
        var weightEntities = await _weightRepository.GetAllAsync(clientId);
        return _mapper.Map<IList<Weight>>(weightEntities);
      }
    }

}
