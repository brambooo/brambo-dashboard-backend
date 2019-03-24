using System;

namespace BramboDashboard.Backend.DAL.Entities
{
    public class WeightEntity
    {
      public int Id { get; set; }
      public decimal RegisterWeight { get; set; }
      public DateTime RegisterDate { get; set; }

      public int ClientEntityId { get; set; }
  }
}
