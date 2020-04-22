using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using NwBlazor.Models.Northwind;
using Microsoft.EntityFrameworkCore;

namespace NwBlazor.Pages
{
    public partial class CustomerOrdersComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected NorthwindService Northwind { get; set; }

        protected RadzenGrid<NwBlazor.Models.Northwind.Customer> grid0;

        protected RadzenGrid<NwBlazor.Models.Northwind.Order> grid1;

        protected RadzenGrid<NwBlazor.Models.Northwind.OrderDetail> grid2;

        IEnumerable<NwBlazor.Models.Northwind.Customer> _Customers;
        protected IEnumerable<NwBlazor.Models.Northwind.Customer> Customers
        {
            get
            {
                return _Customers;
            }
            set
            {
                if(!object.Equals(_Customers, value))
                {
                    _Customers = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        IEnumerable<NwBlazor.Models.Northwind.Product> _getProductsResult;
        protected IEnumerable<NwBlazor.Models.Northwind.Product> getProductsResult
        {
            get
            {
                return _getProductsResult;
            }
            set
            {
                if(!object.Equals(_getProductsResult, value))
                {
                    _getProductsResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        NwBlazor.Models.Northwind.Customer _Customer;
        protected NwBlazor.Models.Northwind.Customer Customer
        {
            get
            {
                return _Customer;
            }
            set
            {
                if(!object.Equals(_Customer, value))
                {
                    _Customer = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        NwBlazor.Models.Northwind.Order _Order;
        protected NwBlazor.Models.Northwind.Order Order
        {
            get
            {
                return _Order;
            }
            set
            {
                if(!object.Equals(_Order, value))
                {
                    _Order = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var northwindGetCustomersResult = await Northwind.GetCustomers();
            Customers = northwindGetCustomersResult;

            var northwindGetProductsResult = await Northwind.GetProducts();
            getProductsResult = northwindGetProductsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddCustomer>("Add Customer", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowExpand(NwBlazor.Models.Northwind.Customer args)
        {
            Customer = args;

            var northwindGetOrdersResult = await Northwind.GetOrders(new Query() { Filter = $@"i => i.CustomerID == ""{args.CustomerID}""" });
            foreach(var r in northwindGetOrdersResult.ToList()){Customer.Orders.Add(r);};
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(NwBlazor.Models.Northwind.Customer args)
        {
            var result = await DialogService.OpenAsync<EditCustomer>("Edit Customer", new Dictionary<string, object>() { {"CustomerID", args.CustomerID} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var northwindDeleteCustomerResult = await Northwind.DeleteCustomer($"{data.CustomerID}");
                if (northwindDeleteCustomerResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception northwindDeleteCustomerException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete Customer");
            }
        }

        protected async System.Threading.Tasks.Task OrderAddButtonClick(MouseEventArgs args, dynamic data)
        {
            var result = await DialogService.OpenAsync<AddOrder>("Add Order", new Dictionary<string, object>() { {"CustomerID", data.CustomerID} });
              grid1.Reload();
        }

        protected async System.Threading.Tasks.Task Grid1RowExpand(NwBlazor.Models.Northwind.Order args, dynamic data)
        {
            Order = args;

            var northwindGetOrderDetailsResult = await Northwind.GetOrderDetails(new Query() { Filter = $@"i => i.OrderID == {args.OrderID}" });
            foreach(var r in northwindGetOrderDetailsResult.ToList()){Order.OrderDetails.Add(r);};
        }

        protected async System.Threading.Tasks.Task Grid1RowSelect(NwBlazor.Models.Northwind.Order args, dynamic data)
        {
            var result = await DialogService.OpenAsync<EditOrder>("Edit Order", new Dictionary<string, object>() { {"OrderID", args.OrderID} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task OrderDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var northwindDeleteOrderResult = await Northwind.DeleteOrder(data.OrderID);
                if (northwindDeleteOrderResult != null) {
                    grid1.Reload();
}
            }
            catch (Exception northwindDeleteOrderException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete Order");
            }
        }

        protected async System.Threading.Tasks.Task OrderDetailAddButtonClick(MouseEventArgs args, dynamic data)
        {
            var result = await DialogService.OpenAsync<AddOrderDetail>("Add Order Detail", new Dictionary<string, object>() { {"OrderID", data.OrderID} });
              grid2.Reload();
        }

        protected async System.Threading.Tasks.Task Grid2RowUpdate(dynamic args, dynamic data)
        {
            var northwindUpdateOrderDetailResult = await Northwind.UpdateOrderDetail(args.OrderID, args.ProductID, args);
        }

        protected async System.Threading.Tasks.Task EditButtonClick(MouseEventArgs args, dynamic data)
        {
            Console.Write("GridCount:" + this.grid2.Data.Count()); 
Console.Write("GridOID:" + data.OrderID); 
Console.Write("DataOID:" + data.Order.OrderID);this.grid2.EditRow(data);
        }

        protected async System.Threading.Tasks.Task SaveButtonClick(MouseEventArgs args, dynamic data)
        {
            this.grid2.UpdateRow(data);
        }

        protected async System.Threading.Tasks.Task CancelButtonClick(MouseEventArgs args, dynamic data)
        {
            this.grid2.CancelEditRow(data);

            var northwindCancelOrderDetailChangesResult = await Northwind.CancelOrderDetailChanges(data);
        }

        protected async System.Threading.Tasks.Task OrderDetailDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var northwindDeleteOrderDetailResult = await Northwind.DeleteOrderDetail(data.OrderID, data.ProductID);
                if (northwindDeleteOrderDetailResult != null) {
                    grid2.Reload();
}
            }
            catch (Exception northwindDeleteOrderDetailException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete OrderDetail");
            }
        }
    }
}
