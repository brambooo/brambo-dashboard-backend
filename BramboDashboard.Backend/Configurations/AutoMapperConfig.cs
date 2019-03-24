using AutoMapper;
using BramboDashboard.Backend.API.Models;
using BramboDashboard.Backend.DAL.Entities;

namespace BramboDashboard.Backend.API.Configurations
{
  public static  class AutoMapperConfig
    {
      public static MapperConfiguration GetConfiguration()
      {
        return new MapperConfiguration(cfg =>
        {
          cfg.CreateMap<Coach, CoachEntity>();
          cfg.CreateMap<Client, ClientEntity>().ReverseMap();
          cfg.CreateMap<Weight, WeightEntity>().ReverseMap();
        });
      }
    }
}
