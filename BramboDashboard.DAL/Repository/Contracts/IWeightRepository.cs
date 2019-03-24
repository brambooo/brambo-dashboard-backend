using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BramboDashboard.Backend.DAL.Entities;

namespace BramboDashboard.Backend.DAL.Repository.Contracts
{
    public interface IWeightRepository
    {
      Task<IList<WeightEntity>> GetAllAsync(int clientId);
      Task AddAsync(int clientId, WeightEntity weight);
  }
}
