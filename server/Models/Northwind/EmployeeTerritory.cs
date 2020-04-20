using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NwBlazor.Models.Northwind
{
  [Table("EmployeeTerritories", Schema = "dbo")]
  public partial class EmployeeTerritory
  {
    [Key]
    public int EmployeeID
    {
      get;
      set;
    }
    public Employee Employee { get; set; }
    [Key]
    public string TerritoryID
    {
      get;
      set;
    }
    public Territory Territory { get; set; }
  }
}
