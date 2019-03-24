﻿using System.Threading.Tasks;
using BramboDashboard.Backend.DAL.Entities;

namespace BramboDashboard.Backend.DAL.Repository.Contracts
{
    public interface ICoachRepository
    {
      Task Add(CoachEntity coach);
    }
}