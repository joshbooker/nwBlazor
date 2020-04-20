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
    public partial class EditOrderComponent : ComponentBase
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

        [Parameter]
        public dynamic OrderID { get; set; }

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

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var northwindGetOrderByOrderIdResult = await Northwind.GetOrderByOrderId(OrderID);
            order = northwindGetOrderByOrderIdResult;

            var northwindGetEmployeesResult = await Northwind.GetEmployees();
            getEmployeesResult = northwindGetEmployeesResult;

            var northwindGetShippersResult = await Northwind.GetShippers();
            getShippersResult = northwindGetShippersResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(NwBlazor.Models.Northwind.Order args)
        {
            try
            {
                var northwindUpdateOrderResult = await Northwind.UpdateOrder(OrderID, order);
                DialogService.Close(order);
            }
            catch (Exception northwindUpdateOrderException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to update Order");
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
