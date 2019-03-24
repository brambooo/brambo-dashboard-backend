using System.Threading.Tasks;
using BramboDashboard.Backend.DAL.Entities;

namespace BramboDashboard.Backend.DAL.Repository.Contracts
{
  public interface IClientRepository
  {
    Task<ClientEntity> GetAsync(int userId);
    Task AddAsync(ClientEntity user);
    Task Update(ClientEntity user);
  }
}