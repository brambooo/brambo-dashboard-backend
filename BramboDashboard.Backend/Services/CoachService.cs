using AutoMapper;
using BramboDashboard.Backend.API.Models;
using BramboDashboard.Backend.API.Services.Contracts;
using BramboDashboard.Backend.DAL.Entities;

namespace BramboDashboard.Backend.API.Services
{
  public class CoachService : ICoachService
  {

    private IMapper _mapper;

    public CoachService(IMapper mapper)
    {
      _mapper = mapper;
    }

    public void Add(Coach coach)
    {
      var coachEntity = _mapper.Map<CoachEntity>(coach);
      throw new System.NotImplementedException();
    }
  }
}