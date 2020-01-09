using System;
using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations.Schema;

namespace Shelter.Shared
{
  public class BaseDbClass
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
  }
}