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
        private readonly NorthwindContext context;
        private readonly NavigationManager navigationManager;

        public NorthwindService(NorthwindContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public async Task ExportCategoriesToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/categories/excel") : "export/northwind/categories/excel", true);
        }

        public async Task ExportCategoriesToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/categories/csv") : "export/northwind/categories/csv", true);
        }

        partial void OnCategoriesRead(ref IQueryable<Models.Northwind.Category> items);

        public async Task<IQueryable<Models.Northwind.Category>> GetCategories(Query query = null)
        {
            var items = context.Categories.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCategoriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCategoryCreated(Models.Northwind.Category item);

        public async Task<Models.Northwind.Category> CreateCategory(Models.Northwind.Category category)
        {
            OnCategoryCreated(category);

            context.Categories.Add(category);
            context.SaveChanges();

            return category;
        }
        public async Task ExportCustomersToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/customers/excel") : "export/northwind/customers/excel", true);
        }

        public async Task ExportCustomersToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/customers/csv") : "export/northwind/customers/csv", true);
        }

        partial void OnCustomersRead(ref IQueryable<Models.Northwind.Customer> items);

        public async Task<IQueryable<Models.Northwind.Customer>> GetCustomers(Query query = null)
        {
            var items = context.Customers.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCustomersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCustomerCreated(Models.Northwind.Customer item);

        public async Task<Models.Northwind.Customer> CreateCustomer(Models.Northwind.Customer customer)
        {
            OnCustomerCreated(customer);

            context.Customers.Add(customer);
            context.SaveChanges();

            return customer;
        }
        public async Task ExportCustomerCustomerDemosToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/customercustomerdemos/excel") : "export/northwind/customercustomerdemos/excel", true);
        }

        public async Task ExportCustomerCustomerDemosToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/customercustomerdemos/csv") : "export/northwind/customercustomerdemos/csv", true);
        }

        partial void OnCustomerCustomerDemosRead(ref IQueryable<Models.Northwind.CustomerCustomerDemo> items);

        public async Task<IQueryable<Models.Northwind.CustomerCustomerDemo>> GetCustomerCustomerDemos(Query query = null)
        {
            var items = context.CustomerCustomerDemos.AsQueryable();

            items = items.Include(i => i.Customer);

            items = items.Include(i => i.CustomerDemographic);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCustomerCustomerDemosRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCustomerCustomerDemoCreated(Models.Northwind.CustomerCustomerDemo item);

        public async Task<Models.Northwind.CustomerCustomerDemo> CreateCustomerCustomerDemo(Models.Northwind.CustomerCustomerDemo customerCustomerDemo)
        {
            OnCustomerCustomerDemoCreated(customerCustomerDemo);

            context.CustomerCustomerDemos.Add(customerCustomerDemo);
            context.SaveChanges();

            return customerCustomerDemo;
        }
        public async Task ExportCustomerDemographicsToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/customerdemographics/excel") : "export/northwind/customerdemographics/excel", true);
        }

        public async Task ExportCustomerDemographicsToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/customerdemographics/csv") : "export/northwind/customerdemographics/csv", true);
        }

        partial void OnCustomerDemographicsRead(ref IQueryable<Models.Northwind.CustomerDemographic> items);

        public async Task<IQueryable<Models.Northwind.CustomerDemographic>> GetCustomerDemographics(Query query = null)
        {
            var items = context.CustomerDemographics.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCustomerDemographicsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCustomerDemographicCreated(Models.Northwind.CustomerDemographic item);

        public async Task<Models.Northwind.CustomerDemographic> CreateCustomerDemographic(Models.Northwind.CustomerDemographic customerDemographic)
        {
            OnCustomerDemographicCreated(customerDemographic);

            context.CustomerDemographics.Add(customerDemographic);
            context.SaveChanges();

            return customerDemographic;
        }
        public async Task ExportEmployeesToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/employees/excel") : "export/northwind/employees/excel", true);
        }

        public async Task ExportEmployeesToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/employees/csv") : "export/northwind/employees/csv", true);
        }

        partial void OnEmployeesRead(ref IQueryable<Models.Northwind.Employee> items);

        public async Task<IQueryable<Models.Northwind.Employee>> GetEmployees(Query query = null)
        {
            var items = context.Employees.AsQueryable();

            items = items.Include(i => i.Employee1);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnEmployeesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEmployeeCreated(Models.Northwind.Employee item);

        public async Task<Models.Northwind.Employee> CreateEmployee(Models.Northwind.Employee employee)
        {
            OnEmployeeCreated(employee);

            context.Employees.Add(employee);
            context.SaveChanges();

            return employee;
        }
        public async Task ExportEmployeeTerritoriesToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/employeeterritories/excel") : "export/northwind/employeeterritories/excel", true);
        }

        public async Task ExportEmployeeTerritoriesToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/employeeterritories/csv") : "export/northwind/employeeterritories/csv", true);
        }

        partial void OnEmployeeTerritoriesRead(ref IQueryable<Models.Northwind.EmployeeTerritory> items);

        public async Task<IQueryable<Models.Northwind.EmployeeTerritory>> GetEmployeeTerritories(Query query = null)
        {
            var items = context.EmployeeTerritories.AsQueryable();

            items = items.Include(i => i.Employee);

            items = items.Include(i => i.Territory);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnEmployeeTerritoriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEmployeeTerritoryCreated(Models.Northwind.EmployeeTerritory item);

        public async Task<Models.Northwind.EmployeeTerritory> CreateEmployeeTerritory(Models.Northwind.EmployeeTerritory employeeTerritory)
        {
            OnEmployeeTerritoryCreated(employeeTerritory);

            context.EmployeeTerritories.Add(employeeTerritory);
            context.SaveChanges();

            return employeeTerritory;
        }
        public async Task ExportOrdersToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/orders/excel") : "export/northwind/orders/excel", true);
        }

        public async Task ExportOrdersToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/orders/csv") : "export/northwind/orders/csv", true);
        }

        partial void OnOrdersRead(ref IQueryable<Models.Northwind.Order> items);

        public async Task<IQueryable<Models.Northwind.Order>> GetOrders(Query query = null)
        {
            var items = context.Orders.AsQueryable();

            items = items.Include(i => i.Customer);

            items = items.Include(i => i.Employee);

            items = items.Include(i => i.Shipper);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnOrdersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnOrderCreated(Models.Northwind.Order item);

        public async Task<Models.Northwind.Order> CreateOrder(Models.Northwind.Order order)
        {
            OnOrderCreated(order);

            context.Orders.Add(order);
            context.SaveChanges();

            return order;
        }
        public async Task ExportOrderDetailsToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/orderdetails/excel") : "export/northwind/orderdetails/excel", true);
        }

        public async Task ExportOrderDetailsToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/orderdetails/csv") : "export/northwind/orderdetails/csv", true);
        }

        partial void OnOrderDetailsRead(ref IQueryable<Models.Northwind.OrderDetail> items);

        public async Task<IQueryable<Models.Northwind.OrderDetail>> GetOrderDetails(Query query = null)
        {
            var items = context.OrderDetails.AsQueryable();

            items = items.Include(i => i.Order);

            items = items.Include(i => i.Product);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnOrderDetailsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnOrderDetailCreated(Models.Northwind.OrderDetail item);

        public async Task<Models.Northwind.OrderDetail> CreateOrderDetail(Models.Northwind.OrderDetail orderDetail)
        {
            OnOrderDetailCreated(orderDetail);

            context.OrderDetails.Add(orderDetail);
            context.SaveChanges();

            return orderDetail;
        }
        public async Task ExportProductsToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/products/excel") : "export/northwind/products/excel", true);
        }

        public async Task ExportProductsToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/products/csv") : "export/northwind/products/csv", true);
        }

        partial void OnProductsRead(ref IQueryable<Models.Northwind.Product> items);

        public async Task<IQueryable<Models.Northwind.Product>> GetProducts(Query query = null)
        {
            var items = context.Products.AsQueryable();

            items = items.Include(i => i.Supplier);

            items = items.Include(i => i.Category);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnProductsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProductCreated(Models.Northwind.Product item);

        public async Task<Models.Northwind.Product> CreateProduct(Models.Northwind.Product product)
        {
            OnProductCreated(product);

            context.Products.Add(product);
            context.SaveChanges();

            return product;
        }
        public async Task ExportRegionsToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/regions/excel") : "export/northwind/regions/excel", true);
        }

        public async Task ExportRegionsToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/regions/csv") : "export/northwind/regions/csv", true);
        }

        partial void OnRegionsRead(ref IQueryable<Models.Northwind.Region> items);

        public async Task<IQueryable<Models.Northwind.Region>> GetRegions(Query query = null)
        {
            var items = context.Regions.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnRegionsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnRegionCreated(Models.Northwind.Region item);

        public async Task<Models.Northwind.Region> CreateRegion(Models.Northwind.Region region)
        {
            OnRegionCreated(region);

            context.Regions.Add(region);
            context.SaveChanges();

            return region;
        }
        public async Task ExportShippersToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/shippers/excel") : "export/northwind/shippers/excel", true);
        }

        public async Task ExportShippersToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/shippers/csv") : "export/northwind/shippers/csv", true);
        }

        partial void OnShippersRead(ref IQueryable<Models.Northwind.Shipper> items);

        public async Task<IQueryable<Models.Northwind.Shipper>> GetShippers(Query query = null)
        {
            var items = context.Shippers.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnShippersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnShipperCreated(Models.Northwind.Shipper item);

        public async Task<Models.Northwind.Shipper> CreateShipper(Models.Northwind.Shipper shipper)
        {
            OnShipperCreated(shipper);

            context.Shippers.Add(shipper);
            context.SaveChanges();

            return shipper;
        }
        public async Task ExportSuppliersToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/suppliers/excel") : "export/northwind/suppliers/excel", true);
        }

        public async Task ExportSuppliersToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/suppliers/csv") : "export/northwind/suppliers/csv", true);
        }

        partial void OnSuppliersRead(ref IQueryable<Models.Northwind.Supplier> items);

        public async Task<IQueryable<Models.Northwind.Supplier>> GetSuppliers(Query query = null)
        {
            var items = context.Suppliers.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnSuppliersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSupplierCreated(Models.Northwind.Supplier item);

        public async Task<Models.Northwind.Supplier> CreateSupplier(Models.Northwind.Supplier supplier)
        {
            OnSupplierCreated(supplier);

            context.Suppliers.Add(supplier);
            context.SaveChanges();

            return supplier;
        }
        public async Task ExportTerritoriesToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/territories/excel") : "export/northwind/territories/excel", true);
        }

        public async Task ExportTerritoriesToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/northwind/territories/csv") : "export/northwind/territories/csv", true);
        }

        partial void OnTerritoriesRead(ref IQueryable<Models.Northwind.Territory> items);

        public async Task<IQueryable<Models.Northwind.Territory>> GetTerritories(Query query = null)
        {
            var items = context.Territories.AsQueryable();

            items = items.Include(i => i.Region);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTerritoriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTerritoryCreated(Models.Northwind.Territory item);

        public async Task<Models.Northwind.Territory> CreateTerritory(Models.Northwind.Territory territory)
        {
            OnTerritoryCreated(territory);

            context.Territories.Add(territory);
            context.SaveChanges();

            return territory;
        }

        partial void OnCategoryDeleted(Models.Northwind.Category item);

        public async Task<Models.Northwind.Category> DeleteCategory(int? categoryId)
        {
            var item = context.Categories
                              .Where(i => i.CategoryID == categoryId)
                              .Include(i => i.Products)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCategoryDeleted(item);

            context.Categories.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnCategoryGet(Models.Northwind.Category item);

        public async Task<Models.Northwind.Category> GetCategoryByCategoryId(int? categoryId)
        {
            var items = context.Categories
                              .AsNoTracking()
                              .Where(i => i.CategoryID == categoryId);

            var item = items.FirstOrDefault();

            OnCategoryGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.Northwind.Category> CancelCategoryChanges(Models.Northwind.Category item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnCategoryUpdated(Models.Northwind.Category item);

        public async Task<Models.Northwind.Category> UpdateCategory(int? categoryId, Models.Northwind.Category category)
        {
            OnCategoryUpdated(category);

            var item = context.Categories
                              .Where(i => i.CategoryID == categoryId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(category);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return category;
        }

        partial void OnCustomerDeleted(Models.Northwind.Customer item);

        public async Task<Models.Northwind.Customer> DeleteCustomer(string customerId)
        {
            var item = context.Customers
                              .Where(i => i.CustomerID == customerId)
                              .Include(i => i.CustomerCustomerDemos)
                              .Include(i => i.Orders)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCustomerDeleted(item);

            context.Customers.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnCustomerGet(Models.Northwind.Customer item);

        public async Task<Models.Northwind.Customer> GetCustomerByCustomerId(string customerId)
        {
            var items = context.Customers
                              .AsNoTracking()
                              .Where(i => i.CustomerID == customerId);

            var item = items.FirstOrDefault();

            OnCustomerGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.Northwind.Customer> CancelCustomerChanges(Models.Northwind.Customer item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnCustomerUpdated(Models.Northwind.Customer item);

        public async Task<Models.Northwind.Customer> UpdateCustomer(string customerId, Models.Northwind.Customer customer)
        {
            OnCustomerUpdated(customer);

            var item = context.Customers
                              .Where(i => i.CustomerID == customerId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(customer);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return customer;
        }

        partial void OnCustomerCustomerDemoDeleted(Models.Northwind.CustomerCustomerDemo item);

        public async Task<Models.Northwind.CustomerCustomerDemo> DeleteCustomerCustomerDemo(string customerId, string customerTypeId)
        {
            var item = context.CustomerCustomerDemos
                              .Where(i => i.CustomerID == customerId && i.CustomerTypeID == customerTypeId)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCustomerCustomerDemoDeleted(item);

            context.CustomerCustomerDemos.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnCustomerCustomerDemoGet(Models.Northwind.CustomerCustomerDemo item);

        public async Task<Models.Northwind.CustomerCustomerDemo> GetCustomerCustomerDemoByCustomerIdAndCustomerTypeId(string customerId, string customerTypeId)
        {
            var items = context.CustomerCustomerDemos
                              .AsNoTracking()
                              .Where(i => i.CustomerID == customerId && i.CustomerTypeID == customerTypeId);

            items = items.Include(i => i.Customer);

            items = items.Include(i => i.CustomerDemographic);

            var item = items.FirstOrDefault();

            OnCustomerCustomerDemoGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.Northwind.CustomerCustomerDemo> CancelCustomerCustomerDemoChanges(Models.Northwind.CustomerCustomerDemo item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnCustomerCustomerDemoUpdated(Models.Northwind.CustomerCustomerDemo item);

        public async Task<Models.Northwind.CustomerCustomerDemo> UpdateCustomerCustomerDemo(string customerId, string customerTypeId, Models.Northwind.CustomerCustomerDemo customerCustomerDemo)
        {
            OnCustomerCustomerDemoUpdated(customerCustomerDemo);

            var item = context.CustomerCustomerDemos
                              .Where(i => i.CustomerID == customerId && i.CustomerTypeID == customerTypeId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(customerCustomerDemo);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return customerCustomerDemo;
        }

        partial void OnCustomerDemographicDeleted(Models.Northwind.CustomerDemographic item);

        public async Task<Models.Northwind.CustomerDemographic> DeleteCustomerDemographic(string customerTypeId)
        {
            var item = context.CustomerDemographics
                              .Where(i => i.CustomerTypeID == customerTypeId)
                              .Include(i => i.CustomerCustomerDemos)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCustomerDemographicDeleted(item);

            context.CustomerDemographics.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnCustomerDemographicGet(Models.Northwind.CustomerDemographic item);

        public async Task<Models.Northwind.CustomerDemographic> GetCustomerDemographicByCustomerTypeId(string customerTypeId)
        {
            var items = context.CustomerDemographics
                              .AsNoTracking()
                              .Where(i => i.CustomerTypeID == customerTypeId);

            var item = items.FirstOrDefault();

            OnCustomerDemographicGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.Northwind.CustomerDemographic> CancelCustomerDemographicChanges(Models.Northwind.CustomerDemographic item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnCustomerDemographicUpdated(Models.Northwind.CustomerDemographic item);

        public async Task<Models.Northwind.CustomerDemographic> UpdateCustomerDemographic(string customerTypeId, Models.Northwind.CustomerDemographic customerDemographic)
        {
            OnCustomerDemographicUpdated(customerDemographic);

            var item = context.CustomerDemographics
                              .Where(i => i.CustomerTypeID == customerTypeId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(customerDemographic);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return customerDemographic;
        }

        partial void OnEmployeeDeleted(Models.Northwind.Employee item);

        public async Task<Models.Northwind.Employee> DeleteEmployee(int? employeeId)
        {
            var item = context.Employees
                              .Where(i => i.EmployeeID == employeeId)
                              .Include(i => i.Employees1)
                              .Include(i => i.EmployeeTerritories)
                              .Include(i => i.Orders)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEmployeeDeleted(item);

            context.Employees.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnEmployeeGet(Models.Northwind.Employee item);

        public async Task<Models.Northwind.Employee> GetEmployeeByEmployeeId(int? employeeId)
        {
            var items = context.Employees
                              .AsNoTracking()
                              .Where(i => i.EmployeeID == employeeId);

            items = items.Include(i => i.Employee1);

            var item = items.FirstOrDefault();

            OnEmployeeGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.Northwind.Employee> CancelEmployeeChanges(Models.Northwind.Employee item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnEmployeeUpdated(Models.Northwind.Employee item);

        public async Task<Models.Northwind.Employee> UpdateEmployee(int? employeeId, Models.Northwind.Employee employee)
        {
            OnEmployeeUpdated(employee);

            var item = context.Employees
                              .Where(i => i.EmployeeID == employeeId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(employee);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return employee;
        }

        partial void OnEmployeeTerritoryDeleted(Models.Northwind.EmployeeTerritory item);

        public async Task<Models.Northwind.EmployeeTerritory> DeleteEmployeeTerritory(int? employeeId, string territoryId)
        {
            var item = context.EmployeeTerritories
                              .Where(i => i.EmployeeID == employeeId && i.TerritoryID == territoryId)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEmployeeTerritoryDeleted(item);

            context.EmployeeTerritories.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnEmployeeTerritoryGet(Models.Northwind.EmployeeTerritory item);

        public async Task<Models.Northwind.EmployeeTerritory> GetEmployeeTerritoryByEmployeeIdAndTerritoryId(int? employeeId, string territoryId)
        {
            var items = context.EmployeeTerritories
                              .AsNoTracking()
                              .Where(i => i.EmployeeID == employeeId && i.TerritoryID == territoryId);

            items = items.Include(i => i.Employee);

            items = items.Include(i => i.Territory);

            var item = items.FirstOrDefault();

            OnEmployeeTerritoryGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.Northwind.EmployeeTerritory> CancelEmployeeTerritoryChanges(Models.Northwind.EmployeeTerritory item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnEmployeeTerritoryUpdated(Models.Northwind.EmployeeTerritory item);

        public async Task<Models.Northwind.EmployeeTerritory> UpdateEmployeeTerritory(int? employeeId, string territoryId, Models.Northwind.EmployeeTerritory employeeTerritory)
        {
            OnEmployeeTerritoryUpdated(employeeTerritory);

            var item = context.EmployeeTerritories
                              .Where(i => i.EmployeeID == employeeId && i.TerritoryID == territoryId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(employeeTerritory);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return employeeTerritory;
        }

        partial void OnOrderDeleted(Models.Northwind.Order item);

        public async Task<Models.Northwind.Order> DeleteOrder(int? orderId)
        {
            var item = context.Orders
                              .Where(i => i.OrderID == orderId)
                              .Include(i => i.OrderDetails)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnOrderDeleted(item);

            context.Orders.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnOrderGet(Models.Northwind.Order item);

        public async Task<Models.Northwind.Order> GetOrderByOrderId(int? orderId)
        {
            var items = context.Orders
                              .AsNoTracking()
                              .Where(i => i.OrderID == orderId);

            items = items.Include(i => i.Customer);

            items = items.Include(i => i.Employee);

            items = items.Include(i => i.Shipper);

            var item = items.FirstOrDefault();

            OnOrderGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.Northwind.Order> CancelOrderChanges(Models.Northwind.Order item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnOrderUpdated(Models.Northwind.Order item);

        public async Task<Models.Northwind.Order> UpdateOrder(int? orderId, Models.Northwind.Order order)
        {
            OnOrderUpdated(order);

            var item = context.Orders
                              .Where(i => i.OrderID == orderId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(order);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return order;
        }

        partial void OnOrderDetailDeleted(Models.Northwind.OrderDetail item);

        public async Task<Models.Northwind.OrderDetail> DeleteOrderDetail(int? orderId, int? productId)
        {
            var item = context.OrderDetails
                              .Where(i => i.OrderID == orderId && i.ProductID == productId)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnOrderDetailDeleted(item);

            context.OrderDetails.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnOrderDetailGet(Models.Northwind.OrderDetail item);

        public async Task<Models.Northwind.OrderDetail> GetOrderDetailByOrderIdAndProductId(int? orderId, int? productId)
        {
            var items = context.OrderDetails
                              .AsNoTracking()
                              .Where(i => i.OrderID == orderId && i.ProductID == productId);

            items = items.Include(i => i.Order);

            items = items.Include(i => i.Product);

            var item = items.FirstOrDefault();

            OnOrderDetailGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.Northwind.OrderDetail> CancelOrderDetailChanges(Models.Northwind.OrderDetail item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnOrderDetailUpdated(Models.Northwind.OrderDetail item);

        public async Task<Models.Northwind.OrderDetail> UpdateOrderDetail(int? orderId, int? productId, Models.Northwind.OrderDetail orderDetail)
        {
            OnOrderDetailUpdated(orderDetail);

            var item = context.OrderDetails
                              .Where(i => i.OrderID == orderId && i.ProductID == productId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(orderDetail);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return orderDetail;
        }

        partial void OnProductDeleted(Models.Northwind.Product item);

        public async Task<Models.Northwind.Product> DeleteProduct(int? productId)
        {
            var item = context.Products
                              .Where(i => i.ProductID == productId)
                              .Include(i => i.OrderDetails)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProductDeleted(item);

            context.Products.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnProductGet(Models.Northwind.Product item);

        public async Task<Models.Northwind.Product> GetProductByProductId(int? productId)
        {
            var items = context.Products
                              .AsNoTracking()
                              .Where(i => i.ProductID == productId);

            items = items.Include(i => i.Supplier);

            items = items.Include(i => i.Category);

            var item = items.FirstOrDefault();

            OnProductGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.Northwind.Product> CancelProductChanges(Models.Northwind.Product item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnProductUpdated(Models.Northwind.Product item);

        public async Task<Models.Northwind.Product> UpdateProduct(int? productId, Models.Northwind.Product product)
        {
            OnProductUpdated(product);

            var item = context.Products
                              .Where(i => i.ProductID == productId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(product);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return product;
        }

        partial void OnRegionDeleted(Models.Northwind.Region item);

        public async Task<Models.Northwind.Region> DeleteRegion(int? regionId)
        {
            var item = context.Regions
                              .Where(i => i.RegionID == regionId)
                              .Include(i => i.Territories)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnRegionDeleted(item);

            context.Regions.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnRegionGet(Models.Northwind.Region item);

        public async Task<Models.Northwind.Region> GetRegionByRegionId(int? regionId)
        {
            var items = context.Regions
                              .AsNoTracking()
                              .Where(i => i.RegionID == regionId);

            var item = items.FirstOrDefault();

            OnRegionGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.Northwind.Region> CancelRegionChanges(Models.Northwind.Region item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnRegionUpdated(Models.Northwind.Region item);

        public async Task<Models.Northwind.Region> UpdateRegion(int? regionId, Models.Northwind.Region region)
        {
            OnRegionUpdated(region);

            var item = context.Regions
                              .Where(i => i.RegionID == regionId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(region);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return region;
        }

        partial void OnShipperDeleted(Models.Northwind.Shipper item);

        public async Task<Models.Northwind.Shipper> DeleteShipper(int? shipperId)
        {
            var item = context.Shippers
                              .Where(i => i.ShipperID == shipperId)
                              .Include(i => i.Orders)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnShipperDeleted(item);

            context.Shippers.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnShipperGet(Models.Northwind.Shipper item);

        public async Task<Models.Northwind.Shipper> GetShipperByShipperId(int? shipperId)
        {
            var items = context.Shippers
                              .AsNoTracking()
                              .Where(i => i.ShipperID == shipperId);

            var item = items.FirstOrDefault();

            OnShipperGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.Northwind.Shipper> CancelShipperChanges(Models.Northwind.Shipper item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnShipperUpdated(Models.Northwind.Shipper item);

        public async Task<Models.Northwind.Shipper> UpdateShipper(int? shipperId, Models.Northwind.Shipper shipper)
        {
            OnShipperUpdated(shipper);

            var item = context.Shippers
                              .Where(i => i.ShipperID == shipperId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(shipper);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return shipper;
        }

        partial void OnSupplierDeleted(Models.Northwind.Supplier item);

        public async Task<Models.Northwind.Supplier> DeleteSupplier(int? supplierId)
        {
            var item = context.Suppliers
                              .Where(i => i.SupplierID == supplierId)
                              .Include(i => i.Products)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSupplierDeleted(item);

            context.Suppliers.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnSupplierGet(Models.Northwind.Supplier item);

        public async Task<Models.Northwind.Supplier> GetSupplierBySupplierId(int? supplierId)
        {
            var items = context.Suppliers
                              .AsNoTracking()
                              .Where(i => i.SupplierID == supplierId);

            var item = items.FirstOrDefault();

            OnSupplierGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.Northwind.Supplier> CancelSupplierChanges(Models.Northwind.Supplier item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnSupplierUpdated(Models.Northwind.Supplier item);

        public async Task<Models.Northwind.Supplier> UpdateSupplier(int? supplierId, Models.Northwind.Supplier supplier)
        {
            OnSupplierUpdated(supplier);

            var item = context.Suppliers
                              .Where(i => i.SupplierID == supplierId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(supplier);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return supplier;
        }

        partial void OnTerritoryDeleted(Models.Northwind.Territory item);

        public async Task<Models.Northwind.Territory> DeleteTerritory(string territoryId)
        {
            var item = context.Territories
                              .Where(i => i.TerritoryID == territoryId)
                              .Include(i => i.EmployeeTerritories)
                              .FirstOrDefault();

            if (item == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTerritoryDeleted(item);

            context.Territories.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTerritoryGet(Models.Northwind.Territory item);

        public async Task<Models.Northwind.Territory> GetTerritoryByTerritoryId(string territoryId)
        {
            var items = context.Territories
                              .AsNoTracking()
                              .Where(i => i.TerritoryID == territoryId);

            items = items.Include(i => i.Region);

            var item = items.FirstOrDefault();

            OnTerritoryGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.Northwind.Territory> CancelTerritoryChanges(Models.Northwind.Territory item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTerritoryUpdated(Models.Northwind.Territory item);

        public async Task<Models.Northwind.Territory> UpdateTerritory(string territoryId, Models.Northwind.Territory territory)
        {
            OnTerritoryUpdated(territory);

            var item = context.Territories
                              .Where(i => i.TerritoryID == territoryId)
                              .FirstOrDefault();
            if (item == null)
            {
               throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(territory);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return territory;
        }
    }
}
