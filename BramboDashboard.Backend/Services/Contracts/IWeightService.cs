using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BramboDashboard.Backend.API.Models;

namespace BramboDashboard.Backend.API.Services.Contracts
{
    public interface IWeightService
    {
      Task RegisterWeight(int clientId, Weight weight);
      Task<IList<Weight>> GetWeights(int clientId);
  }
}
