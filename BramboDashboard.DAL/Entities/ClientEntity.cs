using System.Collections.Generic;

namespace BramboDashboard.Backend.DAL.Entities
{
  public class ClientEntity
  {
    private List<WeightEntity> _userWeightEntities;

    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }

    public List<WeightEntity> WeightMeasurements
    {
      get => _userWeightEntities ?? (_userWeightEntities = new List<WeightEntity>());
      set => _userWeightEntities = value;
    }
  }
}