using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BramboDashboard.Backend.API.Models
{
    public class Weight
    {
      public int Id { get; set; }
      public decimal RegisterWeight { get; set; }
      public DateTime RegisterDate { get; set; }
  }
}
