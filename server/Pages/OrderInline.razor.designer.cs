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
    public partial class OrderInlineComponent : ComponentBase
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

        protected RadzenGrid<NwBlazor.Models.Northwind.Order> grid0;

        IEnumerable<NwBlazor.Models.Northwind.Customer> _getCustomersResult;
        protected IEnumerable<NwBlazor.Models.Northwind.Customer> getCustomersResult
        {
            get
            {
                return _getCustomersResult;
            }
            set
            {
                if(!object.Equals(_getCustomersResult, value))
                {
                    _getCustomersResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        IEnumerable<NwBlazor.Models.Northwind.Employee> _getEmployeesResult;
        protected IEnumerable<NwBlazor.Models.Northwind.Employee> getEmployeesResult
        {
            get
            {
                return _getEmployeesResult;
            }
            set
            {
                if(!object.Equals(_getEmployeesResult, value))
                {
                    _getEmployeesResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        IEnumerable<NwBlazor.Models.Northwind.Shipper> _getShippersResult;
        protected IEnumerable<NwBlazor.Models.Northwind.Shipper> getShippersResult
        {
            get
            {
                return _getShippersResult;
            }
            set
            {
                if(!object.Equals(_getShippersResult, value))
                {
                    _getShippersResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        NwBlazor.Models.Northwind.Order _order;
        protected NwBlazor.Models.Northwind.Order order
        {
            get
            {
                return _order;
            }
            set
            {
                if(!object.Equals(_order, value))
                {
                    _order = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        IEnumerable<NwBlazor.Models.Northwind.Order> _getOrdersResult;
        protected IEnumerable<NwBlazor.Models.Northwind.Order> getOrdersResult
        {
            get
            {
                return _getOrdersResult;
            }
            set
            {
                if(!object.Equals(_getOrdersResult, value))
                {
                    _getOrdersResult = value;
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
            getCustomersResult = northwindGetCustomersResult;

            var northwindGetEmployeesResult = await Northwind.GetEmployees();
            getEmployeesResult = northwindGetEmployeesResult;

            var northwindGetShippersResult = await Northwind.GetShippers();
            getShippersResult = northwindGetShippersResult;

            order = new NwBlazor.Models.Northwind.Order();

            var northwindGetOrdersResult = await Northwind.GetOrders();
            getOrdersResult = northwindGetOrdersResult;
        }

        protected async System.Threading.Tasks.Task Grid0RowUpdate(dynamic args)
        {
            var northwindUpdateOrderResult = await Northwind.UpdateOrder(args.OrderID, args);
        }

        protected async System.Threading.Tasks.Task EditButtonClick(MouseEventArgs args, dynamic data)
        {
            this.grid0.EditRow(data);
        }

        protected async System.Threading.Tasks.Task SaveButtonClick(MouseEventArgs args, dynamic data)
        {
            this.grid0.UpdateRow(data);
        }

        protected async System.Threading.Tasks.Task CancelButtonClick(MouseEventArgs args, dynamic data)
        {
            this.grid0.CancelEditRow(data);

            var northwindCancelOrderChangesResult = await Northwind.CancelOrderChanges(data);
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var northwindDeleteOrderResult = await Northwind.DeleteOrder(data.OrderID);
                if (northwindDeleteOrderResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception northwindDeleteOrderException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete Order");
            }
        }
    }
}
