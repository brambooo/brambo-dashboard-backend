using System;

namespace BramboDashboard.Backend.DAL.Entities
{
  public class MeasurementEntity
  {
    public int Id { get; set; }
    public decimal Weight { get; set; }
    public int StrengthLevel { get; set; }
    public DateTime RegisterDate { get; set; }

    public int ClientEntityId { get; set; }
  }
}
