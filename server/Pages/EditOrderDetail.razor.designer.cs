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
    public partial class EditOrderDetailComponent : ComponentBase
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

        [Parameter]
        public dynamic ProductID { get; set; }

        NwBlazor.Models.Northwind.OrderDetail _orderdetail;
        protected NwBlazor.Models.Northwind.OrderDetail orderdetail
        {
            get
            {
                return _orderdetail;
            }
            set
            {
                if(!object.Equals(_orderdetail, value))
                {
                    _orderdetail = value;
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

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var northwindGetOrderDetailByOrderIdAndProductIdResult = await Northwind.GetOrderDetailByOrderIdAndProductId(OrderID, ProductID);
            orderdetail = northwindGetOrderDetailByOrderIdAndProductIdResult;

            var northwindGetOrdersResult = await Northwind.GetOrders();
            getOrdersResult = northwindGetOrdersResult;

            var northwindGetProductsResult = await Northwind.GetProducts();
            getProductsResult = northwindGetProductsResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(NwBlazor.Models.Northwind.OrderDetail args)
        {
            try
            {
                var northwindUpdateOrderDetailResult = await Northwind.UpdateOrderDetail(OrderID, ProductID, orderdetail);
                DialogService.Close(orderdetail);
            }
            catch (Exception northwindUpdateOrderDetailException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to update OrderDetail");
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
