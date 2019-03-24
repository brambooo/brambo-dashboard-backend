using System;
using System.Threading.Tasks;
using AutoMapper;
using BramboDashboard.Backend.API.Exceptions;
using BramboDashboard.Backend.API.Models;
using BramboDashboard.Backend.API.Services.Contracts;
using BramboDashboard.Backend.DAL.Entities;
using BramboDashboard.Backend.DAL.Repository;
using BramboDashboard.Backend.DAL.Repository.Contracts;

namespace BramboDashboard.Backend.API.Services
{
  public class ClientService : IClientService
  {
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;

    public ClientService(IClientRepository clientRepository, IMapper mapper)
    {
      _clientRepository = clientRepository;
      _mapper = mapper;
    }

    public async Task AddAsync(Client client)
    {
      var userEntity = _mapper.Map<ClientEntity>(client);
      await _clientRepository.AddAsync(userEntity);
    }

    public async Task<Client> GetAsync(int clientId)
    {
      var userEntity = await GetUserEntity(clientId);
      return _mapper.Map<Client>(userEntity);
    }

    private async Task<ClientEntity> GetUserEntity(int userId)
    {
      var userEntity = await _clientRepository.GetAsync(userId);
      if (userEntity == null)
      {
        throw new UserNotFoundException();
      }

      return userEntity;
    }
  }
}
