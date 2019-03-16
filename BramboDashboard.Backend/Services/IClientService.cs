using System.Threading.Tasks;
using BramboDashboard.Backend.API.Models;

namespace BramboDashboard.Backend.API.Services
{
  public interface IClientService
  {
    Task  Add(AddUserViewModel model);
    Task<GetUserViewModel> Get(int userId);
    Task RegisterWeight(int id, decimal weight);
  }
}