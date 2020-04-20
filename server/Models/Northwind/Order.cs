using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NwBlazor.Models.Northwind
{
  [Table("Orders", Schema = "dbo")]
  public partial class Order
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderID
    {
      get;
      set;
    }


    public ICollection<OrderDetail> OrderDetails { get; set; }
    public string CustomerID
    {
      get;
      set;
    }
    public Customer Customer { get; set; }
    public int? EmployeeID
    {
      get;
      set;
    }
    public Employee Employee { get; set; }
    public DateTime? OrderDate
    {
      get;
      set;
    }
    public DateTime? RequiredDate
    {
      get;
      set;
    }
    public DateTime? ShippedDate
    {
      get;
      set;
    }
    public int? ShipVia
    {
      get;
      set;
    }
    public Shipper Shipper { get; set; }
    public decimal? Freight
    {
      get;
      set;
    }
    public string ShipName
    {
      get;
      set;
    }
    public string ShipAddress
    {
      get;
      set;
    }
    public string ShipCity
    {
      get;
      set;
    }
    public string ShipRegion
    {
      get;
      set;
    }
    public string ShipPostalCode
    {
      get;
      set;
    }
    public string ShipCountry
    {
      get;
      set;
    }
  }
}
