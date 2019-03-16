using System;
using System.Threading.Tasks;
using AutoMapper;
using BramboDashboard.Backend.API.Exceptions;
using BramboDashboard.Backend.API.Models;
using BramboDashboard.Backend.DAL.Entities;
using BramboDashboard.Backend.DAL.Repository;

namespace BramboDashboard.Backend.API.Services
{
  public class ClientService : IClientService
  {
    private readonly IClientRepository _userRepository;
    private readonly IMapper _mapper;

    public ClientService(IClientRepository userRepository, IMapper mapper)
    {
      _userRepository = userRepository;
      _mapper = mapper;
    }

    public async Task Add(AddUserViewModel model)
    {
      var userEntity = _mapper.Map<ClientEntity>(model);
      await _userRepository.AddAsync(userEntity);
    }

    public async Task<GetUserViewModel> Get(int userId)
    {
      var userEntity = await GetUserEntity(userId);
      return _mapper.Map<GetUserViewModel>(userEntity);
    }

    public async Task RegisterWeight(int id, decimal weight)
    {
      var userEntity = await GetUserEntity(id);
      var userWeightEntity = new ClientWeightEntity
      {
        Weight = weight,
        RegisterDate = DateTime.Now
      };
      userEntity.UserWeightEntities.Add(userWeightEntity);
      await _userRepository.Update(userEntity);
    }

    private async Task<ClientEntity> GetUserEntity(int userId)
    {
      var userEntity = await _userRepository.GetAsync(userId);
      if (userEntity == null)
      {
        throw new UserNotFoundException();
      }
      return userEntity;
    }
  }
}
