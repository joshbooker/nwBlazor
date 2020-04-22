using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NwBlazor.Models.Northwind
{
  public partial class CustomerCustomerDemo
  {
    [NotMapped]
    public string CustomerDesc
    {
      get;
      set;
    }
  }
}
