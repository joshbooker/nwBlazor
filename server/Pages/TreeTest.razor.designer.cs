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
    public partial class TreeTestComponent : ComponentBase
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

        IEnumerable<NwBlazor.Models.Northwind.Category> _getCategoriesResult;
        protected IEnumerable<NwBlazor.Models.Northwind.Category> getCategoriesResult
        {
            get
            {
                return _getCategoriesResult;
            }
            set
            {
                if(!object.Equals(_getCategoriesResult, value))
                {
                    _getCategoriesResult = value;
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
            var northwindGetCategoriesResult = await Northwind.GetCategories(new Query() { Expand = "Products,Products.Suppliers" });
            getCategoriesResult = northwindGetCategoriesResult;
        }
    }
}
