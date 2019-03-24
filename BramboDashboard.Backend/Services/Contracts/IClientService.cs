using System.Threading.Tasks;
using BramboDashboard.Backend.API.Models;

namespace BramboDashboard.Backend.API.Services.Contracts
{
  public interface IClientService
  {
    Task AddAsync(Client client);
    Task<Client> GetAsync(int clientId);

  }
}