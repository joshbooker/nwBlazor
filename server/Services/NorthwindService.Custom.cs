using Radzen;
using System;
using System.Web;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using NwBlazor.Data;

namespace NwBlazor
{
    public partial class NorthwindService
    {
        partial void OnOrderDetailsRead(ref IQueryable<Models.Northwind.OrderDetail> items)
        {
            // Populate additional property
            foreach (var item in items)
            {   Console.WriteLine("PName:" + item.Product.ProductName);
                item.ProductName = item.Product.ProductName;
                //item.ProductName = item.Product != null ?  item.Product.ProductName : null;
            }
        }
    }
}
