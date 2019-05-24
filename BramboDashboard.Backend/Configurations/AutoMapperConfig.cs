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
          cfg.CreateMap<Client, ClientEntity>().ReverseMap();
          cfg.CreateMap<RegisterMeasurement, MeasurementEntity>().ReverseMap();
          cfg.CreateMap<GetMeasurement, MeasurementEntity>().ReverseMap();
        });
      }
    }
}
