using System;

namespace BramboDashboard.Backend.DAL.Entities
{
    public class ClientWeightEntity
    {
      public int Id { get; set; }
      public decimal Weight { get; set; }
      public DateTime RegisterDate { get; set; }
    }
}
