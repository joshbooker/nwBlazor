using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NwBlazor.Models.Northwind
{
  public partial class OrderDetail
  {
    [NotMapped]
    public string ProductName
    {
      get;
      set;
    }
  }
}
