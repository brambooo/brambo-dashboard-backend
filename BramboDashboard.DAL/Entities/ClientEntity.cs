using System.Collections.Generic;

namespace BramboDashboard.Backend.DAL.Entities
{
  public class ClientEntity
  {
    private List<ClientWeightEntity> _userWeightEntities;
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

    public List<ClientWeightEntity> UserWeightEntities
    {
      get => _userWeightEntities ?? (_userWeightEntities = new List<ClientWeightEntity>());
      set => _userWeightEntities = value;
    }
  }
}