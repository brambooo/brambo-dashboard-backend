using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BramboDashboard.Backend.API.Models
{
  public class GetMeasurement
  {
    public int Id { get; set; }
    public decimal Weight { get; set; }
    public int StrenghtLevel { get; set; }
    public DateTime RegisterDate { get; set; }
  }
}
