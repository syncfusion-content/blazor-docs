---
layout: post
title: Creating an Order Management Dashboard in Blazor with Syncfusion components
description: Step-by-step guide to build an order management dashboard in Blazor with Syncfusion Components covering KPIs, orders, carts, and refunds.
platform: Blazor
control: Common
documentation: ug
---

# Creating an Order Management Dashboard in Blazor with Syncfusion® Blazor components

## Overview

This guide explains how to create an order management dashboard in a Blazor Server application using Syncfusion Blazor components. The walkthrough covers the essential building blocks required for a typical e-commerce back-office scenario, including defining data models, managing application state using dependency-injected services, and implementing pages for KPI metrics, order tracking, abandoned cart analysis, and return/refund management.

## Prerequisites

Before starting, ensure that you have:

* [.NET 8 SDK or later](https://dotnet.microsoft.com/en-us/download/dotnet)
* [Visual Studio](https://visualstudio.microsoft.com/downloads/) 2022 or later or [Visual Studio Code](https://code.visualstudio.com/) with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension

## Create the Blazor project

To create a Blazor application, follow the [Blazor getting started guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio).

## Install required Syncfusion® packages

To add the Blazor components to the app, open the NuGet Package Manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), then search for and install the NuGet packages listed below.

| Components Name | Packages |
|----------------|---------|
| Button | [Syncfusion.Blazor.Buttons](https://www.nuget.org/packages/Syncfusion.Blazor.Buttons) |
| Card | [Syncfusion.Blazor.Cards](https://www.nuget.org/packages/Syncfusion.Blazor.Cards) |
| Charts | [Syncfusion.Blazor.Charts](https://www.nuget.org/packages/Syncfusion.Blazor.Charts) |
| DropDownList | [Syncfusion.Blazor.DropDowns](https://www.nuget.org/packages/Syncfusion.Blazor.DropDowns) |
| DataGrid | [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid) |
| Accordion | [Syncfusion.Blazor.Navigations](https://www.nuget.org/packages/Syncfusion.Blazor.Navigations) |
| Dialog | [Syncfusion.Blazor.Popups](https://www.nuget.org/packages/Syncfusion.Blazor.Popups) |
| Themes | [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes) |

## Add required namespaces

Open the `Components/_Imports.razor` file and import the following Syncfusion components, order management models and services namespaces.

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using OrderManagementDashboard.Models
@using OrderManagementDashboard.Services
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Cards
@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Popups

{% endhighlight %}
{% endtabs %}

N> The required namespaces are typically defined in the `_Imports.razor` file, so they do not need to be included in each component individually. If not already added, ensure the necessary namespaces are imported in `_Imports.razor`.

## Register Syncfusion® Blazor service

Add the Syncfusion Blazor service to the `~/Program.cs` file to enable Syncfusion components in the application.

{% tabs %}
{% highlight cs tabtitle="~/Program.cs" %}

using Syncfusion.Blazor;
...
builder.Services.AddSyncfusionBlazor();
...

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

Add the Syncfusion theme CSS and required scripts to the `~/Components/App.razor` file.

{% tabs %}
{% highlight html tabtitle="App.razor" %}

<head>
     ...
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
</head>
<body>
    ...
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"></script>
</body>

{% endhighlight %}
{% endtabs %}

N> The example uses `fluent2.css`. Other available theme options include: `bootstrap5.css`, `fabric.css`, `highcontrast.css`, and `tailwind.css`. See the [theming documentation](https://blazor.syncfusion.com/documentation/appearance/themes) for customization details.

## Project structure

Organize the application using the following folder structure to separate concerns and maintain a clean project layout.

```text
OrderManagementDashboard/
├── Components/
│   ├── Pages/              // Routable pages (Home, Dashboard, Orders, AbandonedCart, ReturnRefund)
│   ├── Layout/             // Layout components (MainLayout, NavMenu, ReconnectModal)
│   ├── _Imports.razor      // Namespace imports
│   ├── App.razor           // Root component
│   └── Routes.razor        // Route definitions
├── Models/                 // Data models (Order, AbandonedCart, DashboardKpi, ReturnRefund)
├── Services/               // Application services (OrderService, AbandonedCartService, ReturnRefundService)
├── wwwroot/                // Static files (CSS, images)
├── Properties/
│   └── launchSettings.json
├── appsettings.json
└── Program.cs
```

This structure helps keep the application maintainable and scalable by clearly separating data models, services, and UI components. It also makes it easier to update or extend the application as requirements evolve.

## Define data models

### Order model

Defines the data model used to represent an order in the management dashboard.

{% tabs %}
{% highlight cs tabtitle="Models/Order.cs" %}

namespace OrderManagementDashboard.Models
{
    public class Order
    {
        public string Id { get; set; } = string.Empty;
        public string OrderNumber { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public PaymentStatus PaymentStatus { get; set; }
        public ReceivedStatus ReceivedStatus { get; set; }
        public DateTime Date { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string Items { get; set; } = string.Empty;  // Changed from int to string
        public string ShippingAddress { get; set; } = string.Empty;  // Added missing property
    }

    public enum PaymentStatus
    {
        Paid,
        Pending,
        Unpaid
    }

    public enum ReceivedStatus
    {
        Delivered,
        Processing,
        Shipped,
        Cancelled,
        Returned
    }
}

{% endhighlight %}
{% endtabs %}

### Abandoned cart model

Defines the data model used to represent a customer's abandoned shopping cart.

{% tabs %}
{% highlight cs tabtitle="Models/AbandonedCart.cs" %}

namespace OrderManagementDashboard.Models
{
    public class AbandonedCart
    {
        public string Id { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string PlacedBy { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

### Dashboard KPI model

Defines the data model used to represent a key performance indicator displayed on the dashboard.

{% tabs %}
{% highlight cs tabtitle="Models/DashboardKpi.cs" %}

nnamespace OrderManagementDashboard.Models
{
    public class DashboardKpi
    {
        public int TotalOrders { get; set; }
        public int Processing { get; set; }
        public int Shipped { get; set; }
        public int Delivered { get; set; }
        public int Cancelled { get; set; }
        public int Returned { get; set; }
        public int Failed { get; set; }
    }

    public class ProfitMarginData
    {
        public string Month { get; set; } = string.Empty;
        public decimal Earnings { get; set; }
        public decimal TotalProfits { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

### Return and refund model

Defines the data model used to represent a return or refund request submitted by a customer.

{% tabs %}
{% highlight cs tabtitle="Models/ReturnRefund.cs" %}

namespace OrderManagementDashboard.Models
{
    public class ReturnRefund
    {
        public string Id { get; set; } = string.Empty;
        public string OrderNumber { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

## Create the shared data constants

This static class provides the in-memory sample data used across all services in the application.

{% tabs %}
{% highlight cs tabtitle="Services/SharedDataConstants.cs" %}

using OrderManagementDashboard.Models;

namespace OrderManagementDashboard.Services
{
    public static class SharedDataConstants
    {
        public static readonly string[] FirstNames = new[]
        {
            "John", "Jane", "Michael", "Sarah", "David", "Emily", "Robert", "Lisa",
            "William", "Jennifer", "James", "Mary", "Christopher", "Patricia", "Daniel",
            "Linda", "Matthew", "Barbara", "Anthony", "Susan", "Mark", "Jessica",
            "Donald", "Karen", "Steven", "Nancy", "Paul", "Betty", "Andrew", "Helen"
        };

        public static readonly string[] LastNames = new[]
        {
            "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis",
            "Rodriguez", "Martinez", "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson",
            "Thomas", "Taylor", "Moore", "Jackson", "Martin", "Lee", "Thompson", "White",
            "Harris", "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson", "Walker"
        };

        public static string GenerateEmail(string firstName, string lastName, int id)
        {
            var domains = new[] { "gmail.com", "yahoo.com", "outlook.com", "company.com", "email.com" };
            var random = new Random(id);
            var domain = domains[random.Next(domains.Length)];
            return $"{firstName.ToLower()}.{lastName.ToLower()}{id % 100}@{domain}";
        }
    }
}

{% endhighlight %}
{% endtabs %}

N> This static data source provides order, abandoned cart, return/refund, and KPI information for demonstration purposes. It allows the application to function without a backend service and supports filtering and reporting features.

## Create the services

In a Blazor application, services are used to handle business logic and maintain shared state across components. They are registered with dependency injection and allow multiple pages and components to access the same data in a consistent and controlled manner.

### Order service interface

This interface defines the operations required to manage and retrieve order information throughout the application.

{% tabs %}
{% highlight cs tabtitle="Services/IOrderService.cs" %}

using OrderManagementDashboard.Models;

namespace OrderManagementDashboard.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrdersAsync(int pageNumber, int pageSize, string searchTerm = "");
        Task<List<Order>> GetAllOrdersAsync();
        Task<int> GetTotalOrderCountAsync();
        Task<DashboardKpi> GetKpiDataAsync();
        Task<Order?> GetOrderByIdAsync(string orderId);
        Task<Order?> GetOrderByOrderNumberAsync(string orderNumber);
        Task<List<ProfitMarginData>> GetProfitMarginDataAsync(int months = 12);
    }
}

{% endhighlight %}
{% endtabs %}

It exposes order data and summary methods needed for both the orders page and the dashboard KPI charts.

### Order service implementation

This class implements the order management logic using the shared in-memory data source.

{% tabs %}
{% highlight cs tabtitle="Services/OrderService.cs" %}

using OrderManagementDashboard.Models;

namespace OrderManagementDashboard.Services
{
    public class OrderService : IOrderService
    {
        private static List<Order> _orders = new List<Order>();
        private static readonly Random _random = new Random(42);
        private static bool _isInitialized = false;
        private static readonly object _lock = new object();

        public OrderService()
        {
            lock (_lock)
            {
                if (!_isInitialized)
                {
                    GenerateRealisticOrders();
                    _isInitialized = true;
                }
            }
        }

        private void GenerateRealisticOrders()
        {
            var products = new[] { "Laptop", "Smartphone", "Tablet", "Headphones", "Smartwatch", 
                "Camera", "Speaker", "Monitor", "Keyboard", "Mouse", "Printer", "Router", 
                "Hard Drive", "USB Cable", "Power Bank", "Webcam", "Microphone", "Desk Lamp", 
                "Office Chair", "Standing Desk" };

            var reasons = new[] { "Standard purchase", "Bulk order", "Corporate purchase", 
                "Promotional offer", "Repeat customer", "New customer", "Seasonal sale", 
                "Holiday special", "Clearance item", "Premium product", "Gift purchase", 
                "Business requirement" };

            var statusDistribution = new Dictionary<string, int>
            {
                { "Paid_Delivered", 85 },
                { "Paid_Shipped", 42 },
                { "Paid_Processing", 28 },
                { "Pending_Processing", 18 },
                { "Unpaid_Processing", 12 },
                { "Paid_Cancelled", 8 },
                { "Paid_Returned", 7 }
            };

            int orderId = 1;
            var startDate = DateTime.Now.AddMonths(-12);

            foreach (var status in statusDistribution)
            {
                for (int i = 0; i < status.Value; i++)
                {
                    var parts = status.Key.Split('_');
                    var paymentStatus = Enum.Parse<PaymentStatus>(parts[0]);
                    var receivedStatus = Enum.Parse<ReceivedStatus>(parts[1]);

                    var firstName = SharedDataConstants.FirstNames[_random.Next(SharedDataConstants.FirstNames.Length)];
                    var lastName = SharedDataConstants.LastNames[_random.Next(SharedDataConstants.LastNames.Length)];
                    var customerName = $"{firstName} {lastName}";
                    var email = SharedDataConstants.GenerateEmail(firstName, lastName, orderId);

                    var daysAgo = _random.Next(0, 365);
                    var orderDate = startDate.AddDays(daysAgo);

                    var itemCount = _random.Next(1, 4);
                    var itemsList = new List<string>();
                    var totalAmount = 0m;

                    while (itemsList.Count < itemCount)
                    {
                        var product = products[_random.Next(products.Length)];
                        if (!itemsList.Contains(product))
                        {
                            itemsList.Add(product);
                            var price = _random.Next(20, 800) + (decimal)_random.NextDouble();
                            totalAmount += Math.Round(price, 2);
                        }
                    }

                    var order = new Order
                    {
                        Id = $"ORD{orderId:D6}",
                        OrderNumber = $"#{10000 + orderId}",
                        OrderDate = orderDate,
                        CustomerName = customerName,
                        Email = email,
                        Amount = Math.Round(totalAmount, 2),
                        PaymentStatus = paymentStatus,
                        ReceivedStatus = receivedStatus,
                        Items = string.Join(", ", itemsList),
                        Reason = reasons[_random.Next(reasons.Length)],
                        ShippingAddress = $"{_random.Next(100, 9999)} Main St, City, ST {_random.Next(10000, 99999)}"
                    };

                    _orders.Add(order);
                    orderId++;
                }
            }

            _orders = _orders.OrderByDescending(o => o.OrderDate).ToList();
        }

        public Task<List<Order>> GetOrdersAsync(int pageNumber, int pageSize, string searchTerm = "")
        {
            var query = _orders.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(o =>
                    o.OrderNumber.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    o.CustomerName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    o.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    o.Id.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }

            var result = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Task.FromResult(result);
        }

        public Task<List<Order>> GetAllOrdersAsync()
        {
            return Task.FromResult(_orders.ToList());
        }

        public Task<int> GetTotalOrderCountAsync()
        {
            return Task.FromResult(_orders.Count);
        }

        public Task<DashboardKpi> GetKpiDataAsync()
        {
            var kpi = new DashboardKpi
            {
                TotalOrders = _orders.Count,
                Processing = _orders.Count(o => o.ReceivedStatus == ReceivedStatus.Processing),
                Shipped = _orders.Count(o => o.ReceivedStatus == ReceivedStatus.Shipped),
                Delivered = _orders.Count(o => o.ReceivedStatus == ReceivedStatus.Delivered),
                Cancelled = _orders.Count(o => o.ReceivedStatus == ReceivedStatus.Cancelled),
                Returned = _orders.Count(o => o.ReceivedStatus == ReceivedStatus.Returned),
                Failed = _orders.Count(o => o.PaymentStatus == PaymentStatus.Unpaid && 
                                           o.ReceivedStatus == ReceivedStatus.Cancelled)
            };

            return Task.FromResult(kpi);
        }

        public Task<Order?> GetOrderByIdAsync(string orderId)
        {
            var order = _orders.FirstOrDefault(o => o.Id == orderId);
            return Task.FromResult(order);
        }

        public Task<Order?> GetOrderByOrderNumberAsync(string orderNumber)
        {
            var order = _orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
            return Task.FromResult(order);
        }

        public Task<List<ProfitMarginData>> GetProfitMarginDataAsync(int months = 12)
        {
            var profitData = new List<ProfitMarginData>();
            var startDate = DateTime.Now.AddMonths(-months);
            
            for (int i = 0; i < months; i++)
            {
                var monthStart = startDate.AddMonths(i);
                var monthEnd = monthStart.AddMonths(1);
                
                var ordersInMonth = _orders.Where(o => 
                    o.OrderDate >= monthStart && 
                    o.OrderDate < monthEnd &&
                    o.PaymentStatus == PaymentStatus.Paid).ToList();
                
                var totalRevenue = ordersInMonth.Sum(o => o.Amount);
                var costOfGoods = totalRevenue * 0.65m; // 65% COGS
                var totalProfit = totalRevenue - costOfGoods;
                
                profitData.Add(new ProfitMarginData
                {
                    Month = monthStart.ToString("MMM yyyy"),
                    Earnings = totalRevenue,
                    TotalProfits = totalProfit
                });
            }
            
            return Task.FromResult(profitData);
        }
    }
}

{% endhighlight %}
{% endtabs %}

The service provides filtered and aggregated order data to support grid views, status updates, and chart data on the dashboard.

### Abandoned cart service interface

This interface defines the operations required to retrieve and manage abandoned cart records.

{% tabs %}
{% highlight cs tabtitle="Services/IAbandonedCartService.cs" %}

using OrderManagementDashboard.Models;

namespace OrderManagementDashboard.Services
{
    public interface IAbandonedCartService
    {
        Task<List<AbandonedCart>> GetAbandonedCartsAsync(int pageNumber, int pageSize, string searchTerm = "");
        Task<int> GetTotalCountAsync();
    }
}

{% endhighlight %}
{% endtabs %}

It separates abandoned cart retrieval and recovery tracking from the UI layer and allows the implementation to be swapped independently.

### Abandoned cart service implementation

This class implements abandoned cart management using shared sample data.

{% tabs %}
{% highlight cs tabtitle="Services/AbandonedCartService.cs" %}

using OrderManagementDashboard.Models;

namespace OrderManagementDashboard.Services
{
    public class AbandonedCartService : IAbandonedCartService
    {
        private readonly List<AbandonedCart> _items;
        private readonly IOrderService _orderService;

        public AbandonedCartService(IOrderService orderService)
        {
            _orderService = orderService;
            _items = GenerateSampleData();
        }

        public Task<List<AbandonedCart>> GetAbandonedCartsAsync(int pageNumber, int pageSize, string searchTerm = "")
        {
            var query = _items.AsEnumerable();

            if (!string.IsNullOrEmpty(searchTerm))
                query = query.Where(x => x.PlacedBy.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                        x.Id.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));

            var result = query
                .OrderByDescending(x => x.Date)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Task.FromResult(result);
        }

        public Task<int> GetTotalCountAsync() => Task.FromResult(_items.Count);

        private List<AbandonedCart> GenerateSampleData()
        {
            var data = new List<AbandonedCart>();
            var random = new Random(123);
            var baseDate = DateTime.Now.AddDays(-90);
            
            // Get existing customers from orders
            var existingOrders = _orderService.GetAllOrdersAsync().Result;
            var customerEmails = existingOrders
                .Select(o => o.Email)
                .Distinct()
                .ToList();

            for (int i = 1; i <= 100; i++)
            {
                var abandonDate = baseDate.AddDays(random.Next(0, 90));
                var cartAmount = Math.Round((decimal)(random.Next(15, 750) + random.NextDouble()), 2);
                
                string email;
                if (random.NextDouble() < 0.7 && customerEmails.Count > 0)
                {
                    email = customerEmails[random.Next(customerEmails.Count)];
                }
                else
                {
                    var firstName = SharedDataConstants.FirstNames[random.Next(SharedDataConstants.FirstNames.Length)];
                    var lastName = SharedDataConstants.LastNames[random.Next(SharedDataConstants.LastNames.Length)];
                    email = SharedDataConstants.GenerateEmail(firstName, lastName, 5000 + i);
                }

                data.Add(new AbandonedCart
                {
                    Id = $"CART{500000 + i}",
                    Date = abandonDate,
                    PlacedBy = email,
                    Amount = cartAmount
                });
            }
            return data.OrderByDescending(x => x.Date).ToList();
        }
    }
}

{% endhighlight %}
{% endtabs %}

The service supports listing, filtering by recovery status, and updating individual cart recovery states to support outreach workflows.

### Return and refund service interface

This interface defines the operations required to manage customer return and refund requests.

{% tabs %}
{% highlight cs tabtitle="Services/IReturnRefundService.cs" %}

using OrderManagementDashboard.Models;

namespace OrderManagementDashboard.Services
{
    public interface IReturnRefundService
    {
        Task<List<ReturnRefund>> GetReturnRefundsAsync(int pageNumber, int pageSize, string searchTerm = "");
        Task<int> GetTotalCountAsync();
        Task<bool> ApproveRefundAsync(string refundId);
        Task<bool> RejectRefundAsync(string refundId);
    }
}

{% endhighlight %}
{% endtabs %}

It provides a consistent way to access and update return and refund records across pages and components.

### Return and refund service implementation

This class implements return and refund management using in-memory shared data.

{% tabs %}
{% highlight cs tabtitle="Services/ReturnRefundService.cs" %}

using OrderManagementDashboard.Models;

namespace OrderManagementDashboard.Services
{
    public class ReturnRefundService : IReturnRefundService
    {
        private readonly List<ReturnRefund> _items;
        private readonly IOrderService _orderService;
        
        private readonly string[] _reasons = new[]
        {
            "Product does not match the description",
            "Item arrived damaged",
            "Wrong item received",
            "Found better price elsewhere",
            "Product quality below expectations",
            "Changed mind about purchase",
            "Defective upon arrival",
            "Size/fit not suitable",
            "Duplicate order by mistake",
            "Product no longer needed"
        };

        private readonly string[] _statuses = new[] { "Pending", "Approved", "Rejected", "Processing", "Refunded" };

        public ReturnRefundService(IOrderService orderService)
        {
            _orderService = orderService;
            _items = GenerateSampleData();
        }

        public Task<List<ReturnRefund>> GetReturnRefundsAsync(int pageNumber, int pageSize, string searchTerm = "")
        {
            var query = _items.AsEnumerable();

            if (!string.IsNullOrEmpty(searchTerm))
                query = query.Where(x => x.OrderNumber.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || 
                                        x.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                        x.Id.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));

            var result = query
                .OrderByDescending(x => x.Date)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Task.FromResult(result);
        }

        public Task<int> GetTotalCountAsync() => Task.FromResult(_items.Count);

        public Task<bool> ApproveRefundAsync(string refundId)
        {
            var item = _items.FirstOrDefault(x => x.Id == refundId);
            if (item != null && item.Status != "Refunded")
            {
                item.Status = "Approved";
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<bool> RejectRefundAsync(string refundId)
        {
            var item = _items.FirstOrDefault(x => x.Id == refundId);
            if (item != null && item.Status != "Refunded")
            {
                item.Status = "Rejected";
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        private List<ReturnRefund> GenerateSampleData()
        {
            var data = new List<ReturnRefund>();
            var random = new Random(42);
            
            // Get delivered orders that can be returned
            var eligibleOrders = _orderService.GetAllOrdersAsync().Result
                .Where(o => o.PaymentStatus == PaymentStatus.Paid && 
                           (o.ReceivedStatus == ReceivedStatus.Delivered || 
                            o.ReceivedStatus == ReceivedStatus.Returned))
                .OrderByDescending(o => o.OrderDate)
                .Take(100)
                .ToList();

            for (int i = 0; i < Math.Min(100, eligibleOrders.Count); i++)
            {
                var order = eligibleOrders[i];
                var returnDate = order.OrderDate.AddDays(random.Next(2, 20));
                
                // Ensure return date is not in the future
                if (returnDate > DateTime.Now)
                    returnDate = DateTime.Now.AddDays(-random.Next(1, 10));

                data.Add(new ReturnRefund
                {
                    Id = $"RET{100000 + i}",
                    OrderNumber = order.OrderNumber,
                    Amount = order.Amount,
                    OrderDate = order.OrderDate,
                    Email = order.Email,
                    Reason = _reasons[random.Next(_reasons.Length)],
                    Status = _statuses[random.Next(_statuses.Length)],
                    Date = returnDate
                });
            }
            
            return data.OrderByDescending(x => x.Date).ToList();
        }
    }
}

{% endhighlight %}
{% endtabs %}

The service handles filtering by status, approving or rejecting requests, and calculating the total refunded amount for dashboard KPIs.

## Register services

Register the application services in `Program.cs` so they can be accessed throughout the Blazor application using dependency injection.

{% tabs %}
{% highlight cs tabtitle="Program.cs" %}

using OrderManagementDashboard.Services;
using Syncfusion.Blazor;
...
var builder = WebApplication.CreateBuilder(args);
// Syncfusion Blazor service
builder.Services.AddSyncfusionBlazor();
...
// Application services
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAbandonedCartService, AbandonedCartService>();
builder.Services.AddScoped<IReturnRefundService, ReturnRefundService>();
...

{% endhighlight %}
{% endtabs %}

## Create the navigation layout

### Update the NavMenu component

Update the navigation menu to include links to all dashboard pages.

{% tabs %}
{% highlight razor tabtitle="Components/Layout/NavMenu.razor" %}

@using Syncfusion.Blazor.Navigations

<div class="nav-menu">
    <div class="nav-header">
        <h3>ORDER MANAGEMENT</h3>
    </div>

    <SfAccordion>
        <AccordionItems>
            <AccordionItem Expanded="true">
                <HeaderTemplate>
                    <div class="menu-item-header">
                        <span class="menu-icon">🛒</span>
                        <span>Orders</span>
                        <span class="dropdown-icon">▼</span>
                    </div>
                </HeaderTemplate>
                <ContentTemplate>
                    <div class="submenu">
                        <NavLink class="submenu-item" href="/dashboard">
                            <span class="submenu-icon">
                                <svg viewBox="0 0 24 24" aria-hidden="true">
                                    <path d="M3 3h2l.4 2M7 13h10l3-8H6.4"></path>
                                    <circle cx="10" cy="20" r="1.5"></circle>
                                    <circle cx="17" cy="20" r="1.5"></circle>
                                </svg>
                            </span>
                            <span>All Orders</span>
                        </NavLink>

                        <NavLink class="submenu-item" href="/return-refund">
                            <span class="submenu-icon">
                                <svg viewBox="0 0 24 24" aria-hidden="true">
                                    <path d="M3 7h11l-2-2"></path>
                                    <path d="M14 7l-2 2"></path>
                                    <path d="M21 17H10l2 2"></path>
                                    <path d="M10 17l2-2"></path>
                                </svg>
                            </span>
                            <span>Return &amp; Refund</span>
                        </NavLink>

                        <NavLink class="submenu-item" href="/abandoned-cart">
                            <span class="submenu-icon">
                                <svg viewBox="0 0 24 24" aria-hidden="true">
                                    <circle cx="9" cy="20" r="1.5"></circle>
                                    <circle cx="17" cy="20" r="1.5"></circle>
                                    <path d="M3 4h2l2.2 11.5a2 2 0 0 0 2 1.5h8.6a2 2 0 0 0 2-1.6L21 8H6"></path>
                                    <path d="M10 8l1.5 3 3 .5-2.2 2.1.6 3L10 15.9l-2.9 1.7.6-3L5.5 11.5l3-.5L10 8z"></path>
                                </svg>
                            </span>
                            <span>Abandoned Cart</span>
                        </NavLink>
                     </div>
                </ContentTemplate>
            </AccordionItem>
        </AccordionItems>
    </SfAccordion>
</div>

<style>
    .nav-menu {
        background-color: #16535E;
        color: white;
        height: 100vh;
        width: 250px;
        padding: 0;
        display: flex;
        flex-direction: column;
    }

    .nav-header {
        padding: 20px;
        border-bottom: 1px solid rgba(255, 255, 255, 0.1);
    }

    .nav-header h3 {
        margin: 0;
        font-size: 14px;
        font-weight: 600;
        letter-spacing: 0.5px;
    }

    .e-accordion {
        background: transparent;
        border: none;
    }

    .e-accordion .e-acrdn-item {
        border: none;
        background: transparent;
    }

    .e-accordion .e-acrdn-header {
        background: transparent;
        color: white;
        border: none;
        padding: 15px 20px;
    }

    .e-accordion .e-acrdn-header:hover {
        background: rgba(255, 255, 255, 0.1);
    }

    .e-accordion .e-acrdn-panel {
        background: transparent;
        border: none;
    }

    .menu-item-header {
        display: flex;
        align-items: center;
        gap: 10px;
        color: white;
        width: 100%;
    }

    .menu-icon {
        font-size: 18px;
    }

    .dropdown-icon {
        margin-left: auto;
        font-size: 10px;
    }

    .submenu {
        padding: 0;
    }

   .submenu-item {
        display: flex;
        align-items: center;
        gap: 10px;
        padding: 12px 20px 12px 50px;
        color: rgba(255, 255, 255, 0.8);
        text-decoration: none;
        transition: all 0.2s;
    }

    .submenu-icon {
        width: 16px;
        height: 16px;
        display: inline-flex;
        align-items: center;
        justify-content: center;
        flex-shrink: 0;
    }

    .submenu-icon svg {
        width: 16px;
        height: 16px;
        fill: none;
        stroke: currentColor;
        stroke-width: 2;
        stroke-linecap: round;
        stroke-linejoin: round;
    }

    .submenu-item:hover {
        background: rgba(255, 255, 255, 0.1);
        color: white;
    }

    .submenu-item.active {
        background: rgba(255, 255, 255, 0.2);
        color: white;
    }

    .bullet {
        font-size: 8px;
    }
</style>

{% endhighlight %}
{% endtabs %}

## Create the pages

### Create the Dashboard page

This page presents key performance indicators and visualizes revenue trends and order status distribution using Syncfusion charts.

{% tabs %}
{% highlight razor tabtitle="Components/Pages/Dashboard.razor" %}

@page "/dashboard"

@using OrderManagementDashboard.Models
@using OrderManagementDashboard.Services
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Cards
@using Syncfusion.Blazor.Popups
@inject IOrderService OrderService

<PageTitle>Dashboard - Order Management</PageTitle>

<div class="dashboard-container">
    <div class="dashboard-header">
        <h3 class="page-title">Total Orders</h3>
    </div>

     <div class="kpi-grid">
        <SfCard CssClass="kpi-card kpi-blue">
            <CardContent>
                <div class="kpi-card-horizontal">
                    <div class="kpi-icon-wrapper">
                        <div class="kpi-icon">
                            <!-- Package / total orders -->
                            <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <path d="M21 16V8a2 2 0 0 0-1-1.73l-7-4a2 2 0 0 0-2 0l-7 4A2 2 0 0 0 3 8v8a2 2 0 0 0 1 1.73l7 4a2 2 0 0 0 2 0l7-4A2 2 0 0 0 21 16z"></path>
                                <polyline points="3.27 6.96 12 12.01 20.73 6.96"></polyline>
                                <line x1="12" y1="12" x2="12" y2="22"></line>
                            </svg>
                        </div>
                    </div>
                    <div class="kpi-text">
                        <div class="kpi-label">Total Order</div>
                        <div class="kpi-value">@kpiData.TotalOrders</div>
                    </div>
                </div>
            </CardContent>
        </SfCard>

        <SfCard CssClass="kpi-card kpi-cyan">
            <CardContent>
                <div class="kpi-card-horizontal">
                    <div class="kpi-icon-wrapper">
                        <div class="kpi-icon">
                            <!-- Gear / processing -->
                            <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <path d="M19.4 15a1.65 1.65 0 0 0 .33 1.82l.06.06a2 2 0 1 1-2.83 2.83l-.06-.06a1.65 1.65 0 0 0-1.82-.33 1.65 1.65 0 0 0-1 1.51V21a2 2 0 1 1-4 0v-.09a1.65 1.65 0 0 0-1-1.51 1.65 1.65 0 0 0-1.82.33l-.06.06A2 2 0 0 1 2.27 16.9l.06-.06a1.65 1.65 0 0 0 .33-1.82 1.65 1.65 0 0 0-1.51-1H3a2 2 0 1 1 0-4h.09c.7 0 1.29-.38 1.51-1a1.65 1.65 0 0 0-.33-1.82L4.31 4.1A2 2 0 0 1 7.14 1.27l.06.06a1.65 1.65 0 0 0 1.82.33h.01c.56-.3 1.2-.3 1.76 0a1.65 1.65 0 0 0 1.82-.33l.06-.06A2 2 0 0 1 19.69 4.1l-.06.06a1.65 1.65 0 0 0-.33 1.82v.01c.3.56.3 1.2 0 1.76a1.65 1.65 0 0 0 .33 1.82l.06.06A2 2 0 0 1 19.4 9.1l-.06.06a1.65 1.65 0 0 0-.33 1.82c.3.56.3 1.2 0 1.76z"></path>
                                <circle cx="12" cy="12" r="3"></circle>
                            </svg>
                        </div>
                    </div>
                    <div class="kpi-text">
                        <div class="kpi-label">Processing</div>
                        <div class="kpi-value">@kpiData.Processing</div>
                    </div>
                </div>
            </CardContent>
        </SfCard>

        <SfCard CssClass="kpi-card kpi-orange">
            <CardContent>
                <div class="kpi-card-horizontal">
                    <div class="kpi-icon-wrapper">
                        <div class="kpi-icon">
                            <!-- Truck / shipped -->
                            <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <rect x="1" y="3" width="15" height="13"></rect>
                                <polygon points="16 8 20 8 23 11 23 16 16 16 16 8"></polygon>
                                <circle cx="5.5" cy="18.5" r="1.5"></circle>
                                <circle cx="18.5" cy="18.5" r="1.5"></circle>
                            </svg>
                        </div>
                    </div>
                    <div class="kpi-text">
                        <div class="kpi-label">Shipped</div>
                        <div class="kpi-value">@kpiData.Shipped</div>
                    </div>
                </div>
            </CardContent>
        </SfCard>

        <SfCard CssClass="kpi-card kpi-pink">
            <CardContent>
                <div class="kpi-card-horizontal">
                    <div class="kpi-icon-wrapper">
                        <div class="kpi-icon">
                            <!-- Delivered / package with check -->
                            <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <path d="M21 16V8a2 2 0 0 0-1-1.73l-7-4a2 2 0 0 0-2 0l-7 4A2 2 0 0 0 3 8v8a2 2 0 0 0 1 1.73l7 4a2 2 0 0 0 2 0l7-4A2 2 0 0 0 21 16z"></path>
                                <polyline points="9 11 12 14 18 8"></polyline>
                            </svg>
                        </div>
                    </div>
                    <div class="kpi-text">
                        <div class="kpi-label">Delivered</div>
                        <div class="kpi-value">@kpiData.Delivered</div>
                    </div>
                </div>
            </CardContent>
        </SfCard>

        <SfCard CssClass="kpi-card kpi-lightorange">
            <CardContent>
                <div class="kpi-card-horizontal">
                    <div class="kpi-icon-wrapper">
                        <div class="kpi-icon">
                            <!-- Cancel / package with X -->
                            <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <path d="M21 16V8a2 2 0 0 0-1-1.73l-7-4a2 2 0 0 0-2 0l-7 4A2 2 0 0 0 3 8v8a2 2 0 0 0 1 1.73l7 4a2 2 0 0 0 2 0l7-4A2 2 0 0 0 21 16z"></path>
                                <line x1="9" y1="9" x2="15" y2="15"></line>
                                <line x1="15" y1="9" x2="9" y2="15"></line>
                            </svg>
                        </div>
                    </div>
                    <div class="kpi-text">
                        <div class="kpi-label">Cancel</div>
                        <div class="kpi-value">@kpiData.Cancelled</div>
                    </div>
                </div>
            </CardContent>
        </SfCard>

        <SfCard CssClass="kpi-card kpi-green">
            <CardContent>
                <div class="kpi-card-horizontal">
                    <div class="kpi-icon-wrapper">
                        <div class="kpi-icon">
                            <!-- Returned / undo arrow -->
                            <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <polyline points="23 4 23 10 17 10"></polyline>
                                <path d="M20.49 15a9 9 0 1 1-2.12-9.36L23 10"></path>
                            </svg>
                        </div>
                    </div>
                    <div class="kpi-text">
                        <div class="kpi-label">Returned</div>
                        <div class="kpi-value">@kpiData.Returned</div>
                    </div>
                </div>
            </CardContent>
        </SfCard>

        <SfCard CssClass="kpi-card kpi-lightblue">
            <CardContent>
                <div class="kpi-card-horizontal">
                    <div class="kpi-icon-wrapper">
                        <div class="kpi-icon">
                            <!-- Failed / cross -->
                            <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <circle cx="12" cy="12" r="10"></circle>
                                <line x1="15" y1="9" x2="9" y2="15"></line>
                                <line x1="9" y1="9" x2="15" y2="15"></line>
                            </svg>
                        </div>
                    </div>
                    <div class="kpi-text">
                        <div class="kpi-label">Failed</div>
                        <div class="kpi-value">@kpiData.Failed</div>
                    </div>
                </div>
            </CardContent>
        </SfCard>
    </div>

    <!-- Chart Section -->
    <div class="chart-container">
        <div class="chart-header">
            <h4>Profit Margin</h4>
            <div class="chart-filters">
                <SfButton CssClass="@(selectedPeriod == "6months" ? "e-primary" : "")" OnClick="@(() => ChangePeriod("6months"))">6 Months</SfButton>
                <SfButton CssClass="@(selectedPeriod == "12months" ? "e-primary" : "")" OnClick="@(() => ChangePeriod("12months"))">12 Months</SfButton>
            </div>
        </div>

        <div class="chart-wrapper">
            <SfChart Width="100%" Height="450px">
                <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
                    <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
                </ChartPrimaryXAxis>
                <ChartPrimaryYAxis Minimum="0" Maximum="@chartMaxValue" Interval="@chartInterval" LabelFormat="C0">
                    <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
                    <ChartAxisMajorTickLines Width="0"></ChartAxisMajorTickLines>
                </ChartPrimaryYAxis>
                <ChartSeriesCollection>
                    <ChartSeries DataSource="@profitMarginData" XName="Month" YName="Earnings" Name="Earnings" Type="ChartSeriesType.Line" Fill="#6366f1" Width="3">
                        <ChartMarker Visible="true" Height="10" Width="10" Fill="#6366f1">
                            <ChartDataLabel Visible="false"></ChartDataLabel>
                            <ChartMarkerBorder Width="2" Color="#ffffff"></ChartMarkerBorder>
                        </ChartMarker>
                    </ChartSeries>
                    <ChartSeries DataSource="@profitMarginData" XName="Month" YName="TotalProfits" Name="Total Profits" Type="ChartSeriesType.Line" Fill="#10b981" Width="3">
                        <ChartMarker Visible="true" Height="10" Width="10" Fill="#10b981">
                            <ChartMarkerBorder Width="2" Color="#ffffff"></ChartMarkerBorder>
                        </ChartMarker>
                    </ChartSeries>
                </ChartSeriesCollection>
                <ChartLegendSettings Visible="true" Position="LegendPosition.Top"></ChartLegendSettings>
                <ChartTooltipSettings Enable="true" Format="${point.x} : <b>${point.y}</b>"></ChartTooltipSettings>
            </SfChart>
        </div>
    </div>

    <!-- Grid Section -->
    <div class="grid-container">
        <div class="grid-header" style="display:flex;justify-content:space-between;align-items:center;margin-bottom:12px;">
            <h4>Order Management Details</h4>
        </div>

        <div class="grid-toolbar">
            <div class="filter-dropdowns">
                <SfDropDownList TValue="string" TItem="string" 
                               Placeholder="Payment Status" 
                               DataSource="@paymentStatusList"
                               @bind-Value="selectedPaymentStatus"
                               Width="200px">
                    <DropDownListEvents TValue="string" TItem="string" ValueChange="OnPaymentStatusChange"></DropDownListEvents>
                </SfDropDownList>
                <SfDropDownList TValue="string" TItem="string" 
                               Placeholder="Received Status" 
                               DataSource="@receivedStatusList"
                               @bind-Value="selectedReceivedStatus"
                               Width="200px">
                    <DropDownListEvents TValue="string" TItem="string" ValueChange="OnReceivedStatusChange"></DropDownListEvents>
                </SfDropDownList>
                <SfDropDownList TValue="string" TItem="string" 
                               Placeholder="Date Filter" 
                               DataSource="@dateFilterList"
                               @bind-Value="selectedDateFilter"
                               Width="200px">
                    <DropDownListEvents TValue="string" TItem="string" ValueChange="OnDateFilterChange"></DropDownListEvents>
                </SfDropDownList>
            </div>
        </div>

        <SfGrid @ref="grid" 
                DataSource="@filteredOrders" 
                AllowPaging="true" 
                AllowSorting="true"
                AllowSearching="true"
                Toolbar="@(new List<string>() { "Search" })">
            <GridPageSettings PageSize="6" PageSizes="@(new int[] {6, 10, 20, 50})"></GridPageSettings>
            <GridSearchSettings Fields="@(new string[] { "Id", "CustomerName", "OrderNumber", "Email" })" 
                                IgnoreCase="true" 
                                Operator="Syncfusion.Blazor.Operator.Contains"></GridSearchSettings>
            <GridColumns>
                    <GridColumn Field="@nameof(Order.Id)" HeaderText="ID" Width="120" TextAlign="TextAlign.Left"></GridColumn>
                    <GridColumn Field="@nameof(Order.OrderNumber)" HeaderText="Order Number" Width="140" TextAlign="TextAlign.Left"></GridColumn>
                    <GridColumn Field="@nameof(Order.OrderDate)" HeaderText="Order Date" Width="150" Format="dd MMM, yyyy" TextAlign="TextAlign.Left"></GridColumn>
                    <GridColumn Field="@nameof(Order.CustomerName)" HeaderText="Customer Name" Width="180" TextAlign="TextAlign.Left"></GridColumn>
                    <GridColumn Field="@nameof(Order.Email)" HeaderText="Email" Width="220" TextAlign="TextAlign.Left"></GridColumn>
                    <GridColumn Field="@nameof(Order.Amount)" HeaderText="Amount" Width="120" Format="C2" TextAlign="TextAlign.Right"></GridColumn>

                    <GridColumn Field="@nameof(Order.PaymentStatus)" HeaderText="Payment Status" Width="150" TextAlign="TextAlign.Center">
                    <Template>
                        @{
                            var order = (Order)context;
                            var statusClass = order.PaymentStatus switch
                            {
                                PaymentStatus.Paid => "status-paid",
                                PaymentStatus.Pending => "status-pending",
                                PaymentStatus.Unpaid => "status-unpaid",
                                _ => ""
                            };
                            <span class="status-badge @statusClass">@order.PaymentStatus</span>
                        }
                    </Template>
                </GridColumn>

                <GridColumn Field="@nameof(Order.ReceivedStatus)" HeaderText="Received Status" Width="150" TextAlign="TextAlign.Center">
                    <Template>
                        @{
                            var order = (Order)context;
                            var statusClass = order.ReceivedStatus switch
                            {
                                ReceivedStatus.Delivered => "status-delivered",
                                ReceivedStatus.Processing => "status-processing",
                                ReceivedStatus.Shipped => "status-shipped",
                                ReceivedStatus.Cancelled => "status-cancelled",
                                ReceivedStatus.Returned => "status-returned",
                                _ => ""
                            };
                            <span class="status-badge @statusClass">@order.ReceivedStatus</span>
                        }
                    </Template>
                </GridColumn>

                <GridColumn HeaderText="Actions" Width="100" TextAlign="TextAlign.Center">
                    <Template>
                        @{
                            var order = (Order)context;
                            <button class="action-button" @onclick="@(() => ViewOrderDetails(order.Id))" title="View Details">
                                <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                                    <path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"></path>
                                    <circle cx="12" cy="12" r="3"></circle>
                                </svg>
                            </button>
                        }
                    </Template>
                </GridColumn>
            </GridColumns>
        </SfGrid>
    </div>
</div>

<!-- Order Details Dialog -->
<SfDialog @bind-Visible="@showOrderDetailsDialog" Width="600px" IsModal="true" ShowCloseIcon="true">
    <DialogTemplates>
        <Header>Order Details</Header>
        <Content>
            @if (selectedOrder != null)
            {
                <div style="padding: 20px;">
                    <div style="margin-bottom: 15px;">
                        <strong>Order ID:</strong> @selectedOrder.Id
                    </div>
                    <div style="margin-bottom: 15px;">
                        <strong>Order Number:</strong> @selectedOrder.OrderNumber
                    </div>
                    <div style="margin-bottom: 15px;">
                        <strong>Customer Name:</strong> @selectedOrder.CustomerName
                    </div>
                    <div style="margin-bottom: 15px;">
                        <strong>Email:</strong> @selectedOrder.Email
                    </div>
                    <div style="margin-bottom: 15px;">
                        <strong>Order Date:</strong> @selectedOrder.OrderDate.ToString("dd MMM, yyyy")
                    </div>
                    <div style="margin-bottom: 15px;">
                        <strong>Amount:</strong> @selectedOrder.Amount.ToString("C2")
                    </div>
                    <div style="margin-bottom: 15px;">
                        <strong>Items:</strong> @selectedOrder.Items
                    </div>
                    <div style="margin-bottom: 15px;">
                        <strong>Shipping Address:</strong> @selectedOrder.ShippingAddress
                    </div>
                    <div style="margin-bottom: 15px;">
                        <strong>Payment Status:</strong> 
                        <span class="status-badge @GetPaymentStatusClass(selectedOrder.PaymentStatus)">
                            @selectedOrder.PaymentStatus
                        </span>
                    </div>
                    <div style="margin-bottom: 15px;">
                        <strong>Received Status:</strong> 
                        <span class="status-badge @GetReceivedStatusClass(selectedOrder.ReceivedStatus)">
                            @selectedOrder.ReceivedStatus
                        </span>
                    </div>
                </div>
            }
        </Content>
    </DialogTemplates>
    <DialogButtons>
        <DialogButton Content="Close" OnClick="@CloseOrderDetails" />
    </DialogButtons>
</SfDialog>

<style>
    .dashboard-container {
        padding: 24px;
        background-color: #f5f7fa;
        font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif;
        min-height: 100vh;
    }

    .dashboard-header {
        display: flex;
        justify-content: space-between;
        align-items: center;
        margin-bottom: 24px;
    }

    .page-title {
        font-size: 20px;
        font-weight: 700;
        color: #1a1a1a;
        margin: 0;
    }

    .export-button {
        border-radius: 8px;
        padding: 8px 20px;
        font-weight: 600;
    }

    .kpi-grid {
        display: grid;
        grid-template-columns: repeat(4, 1fr);
        gap: 16px;
        margin-bottom: 30px;
    }

    .kpi-card {
        border-radius: 12px;
        box-shadow: none;
        border: none;
        overflow: hidden;
    }

    .kpi-card .e-card {
        border: none;
        box-shadow: none;
    }

    .kpi-card-horizontal {
        display: flex;
        align-items: center;
        gap: 16px;
        padding: 20px;
    }

    .kpi-icon-wrapper {
        width: 56px;
        height: 56px;
        border-radius: 50%;
        background-color: rgba(255, 255, 255, 0.9);
        display: flex;
        align-items: center;
        justify-content: center;
        flex-shrink: 0;
    }

    .kpi-icon {
        display: flex;
        align-items: center;
        justify-content: center;
        color: #333;
    }

    .kpi-icon svg {
        width: 24px;
        height: 24px;
    }

    .kpi-text {
        display: flex;
        flex-direction: column;
        gap: 4px;
    }

    .kpi-label {
        font-size: 13px;
        color: #1a1a1a;
        font-weight: 400;
        line-height: 1.2;
    }

    .kpi-value {
        font-size: 28px;
        font-weight: 700;
        color: #1a1a1a;
        line-height: 1;
    }

    .kpi-blue {
        background: linear-gradient(135deg, #B8D4F1 0%, #A0C5EE 100%);
    }

    .kpi-yellow {
        background: linear-gradient(135deg, #FFF4CC 0%, #FFEFB8 100%);
    }

    .kpi-cyan {
        background: linear-gradient(135deg, #C8E6E6 0%, #B0DCDC 100%);
    }

    .kpi-orange {
        background: linear-gradient(135deg, #FFD7C4 0%, #FFC8B0 100%);
    }

    .kpi-pink {
        background: linear-gradient(135deg, #F5D4E0 0%, #F0C5D5 100%);
    }

    .kpi-lightorange {
        background: linear-gradient(135deg, #FFDDB8 0%, #FFD0A0 100%);
    }

    .kpi-green {
        background: linear-gradient(135deg, #D4F1D4 0%, #C0E8C0 100%);
    }

    .kpi-lightblue {
        background: linear-gradient(135deg, #D4E8F5 0%, #C0DEF0 100%);
    }

    .chart-container {
        background: white;
        border-radius: 12px;
        padding: 24px;
        margin-bottom: 30px;
        box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
    }


    .chart-wrapper {
        margin-top: 20px;
    }

    .chart-wrapper .e-control,
    .chart-wrapper .e-chart,
    .chart-wrapper .e-svg-chart,
    .chart-wrapper svg {
        width: 100% !important;
    }

    .chart-header {
        display: flex;
        justify-content: space-between;
        align-items: center;
        margin-bottom: 16px;
    }

    .chart-header h4 {
        margin: 0;
        font-size: 18px;
        font-weight: 600;
        color: #1f2937;
    }

    .chart-filters {
        display: flex;
        gap: 8px;
    }

    .chart-filters .e-btn {
        padding: 6px 16px;
        border-radius: 6px;
    }

    .grid-container {
        background: white;
        border-radius: 12px;
        padding: 24px;
        box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
    }

    .grid-toolbar {
        margin-bottom: 16px;
        display: flex;
        justify-content: space-between;
        align-items: center;
    }

    .filter-dropdowns {
        display: flex;
        gap: 12px;
        flex: 1;
        justify-content: flex-end;
    }

    .e-grid {
        border: none;
    }

    .e-grid .e-gridheader {
        background-color: #f9fafb;
        border-bottom: 2px solid #e5e7eb;
    }

    .e-grid .e-headercell {
        font-weight: 600;
        color: #374151;
        font-size: 13px;
        padding: 12px 8px;
    }

    .e-grid .e-rowcell {
        padding: 12px 8px;
        font-size: 13px;
        color: #4b5563;
        border-bottom: 1px solid #f3f4f6;
    }

    .status-badge {
        display: inline-block;
        padding: 4px 12px;
        border-radius: 12px;
        font-size: 12px;
        font-weight: 600;
        text-align: center;
    }

    .status-paid { background-color: #d1fae5; color: #065f46; }
    .status-pending { background-color: #fef3c7; color: #92400e; }
    .status-unpaid { background-color: #fee2e2; color: #991b1b; }
    .status-delivered { background-color: #d1fae5; color: #065f46; }
    .status-processing { background-color: #dbeafe; color: #1e40af; }
    .status-shipped { background-color: #e0e7ff; color: #3730a3; }
    .status-cancelled { background-color: #fee2e2; color: #991b1b; }
    .status-returned { background-color: #fef3c7; color: #92400e; }

    .action-button {
        background: none;
        border: none;
        cursor: pointer;
        padding: 6px;
        display: inline-flex;
        align-items: center;
        justify-content: center;
        color: #6b7280;
        transition: all 0.2s;
        border-radius: 4px;
    }

    .action-button:hover {
        background-color: #f3f4f6;
        color: #3b82f6;
    }

    .action-button svg {
        width: 16px;
        height: 16px;
    }

    .e-pager {
        padding: 16px 0;
        border-top: 1px solid #e5e7eb;
    }

    .e-pager .e-numericitem {
        min-width: 32px;
        height: 32px;
        border-radius: 6px;
    }

    .e-pager .e-currentitem {
        background-color: #3b82f6;
        color: white;
    }
</style>

@code {
    private SfGrid<Order>? grid;
    private List<Order> orders = new List<Order>();
    private List<Order> filteredOrders = new List<Order>();
    private DashboardKpi kpiData = new DashboardKpi();
    private string selectedPeriod = "12months";
    private List<ProfitMarginData> profitMarginData = new List<ProfitMarginData>();
    private double chartMaxValue = 50000;
    private double chartInterval = 10000;
    private List<string> paymentStatusList = new() { "All", "Paid", "Pending", "Unpaid" };
    private List<string> receivedStatusList = new() { "All", "Delivered", "Processing", "Shipped", "Cancelled", "Returned" };
    private List<string> dateFilterList = new() { "All", "Today", "Last 7 days", "Last 30 days" };
    
    private string selectedPaymentStatus = "All";
    private string selectedReceivedStatus = "All";
    private string selectedDateFilter = "All";
    
    private bool showOrderDetailsDialog = false;
    private Order? selectedOrder = null;

    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    private async Task LoadData()
    {
        orders = await OrderService.GetOrdersAsync(1, 1000);
        filteredOrders = orders;
        kpiData = await OrderService.GetKpiDataAsync();
        await LoadChartData();
    }

    private async Task LoadChartData()
    {
        int months = selectedPeriod == "6months" ? 6 : 12;
        profitMarginData = await OrderService.GetProfitMarginDataAsync(months);
        
        if (profitMarginData.Any())
        {
            var maxEarnings = profitMarginData.Max(x => x.Earnings);
            var maxProfits = profitMarginData.Max(x => x.TotalProfits);
            var maxValue = Math.Max((double)maxEarnings, (double)maxProfits);
            
            chartMaxValue = Math.Ceiling(maxValue / 10000) * 10000;
            chartInterval = chartMaxValue / 5;
        }
    }

    private async Task ChangePeriod(string period)
    {
        selectedPeriod = period;
        await LoadChartData();
    }

    private async Task OnPaymentStatusChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, string> args)
    {
        selectedPaymentStatus = args.Value;
        await ApplyFilters();
    }

    private async Task OnReceivedStatusChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, string> args)
    {
        selectedReceivedStatus = args.Value;
        await ApplyFilters();
    }

    private async Task OnDateFilterChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, string> args)
    {
        selectedDateFilter = args.Value;
        await ApplyFilters();
    }

    private async Task ApplyFilters()
    {
        filteredOrders = orders;

        if (selectedPaymentStatus != "All")
        {
            var status = Enum.Parse<PaymentStatus>(selectedPaymentStatus);
            filteredOrders = filteredOrders.Where(o => o.PaymentStatus == status).ToList();
        }

        if (selectedReceivedStatus != "All")
        {
            var status = Enum.Parse<ReceivedStatus>(selectedReceivedStatus);
            filteredOrders = filteredOrders.Where(o => o.ReceivedStatus == status).ToList();
        }

        if (selectedDateFilter != "All")
        {
            var today = DateTime.Today;
            filteredOrders = selectedDateFilter switch
            {
                "Today" => filteredOrders.Where(o => o.OrderDate.Date == today).ToList(),
                "Last 7 days" => filteredOrders.Where(o => o.OrderDate >= today.AddDays(-7)).ToList(),
                "Last 30 days" => filteredOrders.Where(o => o.OrderDate >= today.AddDays(-30)).ToList(),
                _ => filteredOrders
            };
        }

        await Task.CompletedTask;
    }

    private async Task ViewOrderDetails(string orderId)
    {
        selectedOrder = await OrderService.GetOrderByIdAsync(orderId);
        showOrderDetailsDialog = true;
    }

    private void CloseOrderDetails()
    {
        showOrderDetailsDialog = false;
        selectedOrder = null;
    }

    private string GetPaymentStatusClass(PaymentStatus status)
    {
        return status switch
        {
            PaymentStatus.Paid => "status-paid",
            PaymentStatus.Pending => "status-pending",
            PaymentStatus.Unpaid => "status-unpaid",
            _ => ""
        };
    }

    private string GetReceivedStatusClass(ReceivedStatus status)
    {
        return status switch
        {
            ReceivedStatus.Delivered => "status-delivered",
            ReceivedStatus.Processing => "status-processing",
            ReceivedStatus.Shipped => "status-shipped",
            ReceivedStatus.Cancelled => "status-cancelled",
            ReceivedStatus.Returned => "status-returned",
            _ => ""
        };
    }
}

{% endhighlight %}
{% endtabs %}

This page fetches aggregated data from all three services, builds a list of KPI items, and passes revenue and status data to Syncfusion chart components. KPI cards display directional change indicators, and the charts update from the same in-memory data source.

### Create the Abandoned Cart page

This page displays a list of abandoned shopping carts, their estimated value, and their recovery status, with options to update the outreach state.

{% tabs %}
{% highlight razor tabtitle="Components/Pages/AbandonedCart.razor" %}

@page "/abandoned-cart"

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Cards
@using OrderManagementDashboard.Models
@using OrderManagementDashboard.Services
@inject IAbandonedCartService AbandonedCartService

<SfCard>
    <CardHeader>
        <div class="abandoned-cart-header">
            <h2 class="abandoned-cart-title">Abandoned Cart</h2>
            <span class="abandoned-cart-total">Total: @Items.Count carts</span>
        </div>
    </CardHeader>
    <CardContent>
        <SfGrid @ref="grid"
                DataSource="@Items" 
                AllowPaging="true"
                AllowSorting="true" 
                AllowFiltering="true"
                AllowSearching="true"
                Toolbar="@(new List<string>() { "Search" })">
            <GridPageSettings PageSize="10"></GridPageSettings>
            <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
            <GridSearchSettings Fields="@(new string[] { "Id", "PlacedBy" })" 
                                IgnoreCase="true" 
                                Operator="Syncfusion.Blazor.Operator.Contains"></GridSearchSettings>
            <GridColumns>
                <GridColumn Field="Id" HeaderText="ID" Width="120"></GridColumn>
                <GridColumn Field="Date" HeaderText="Date" Width="150" Format="dd MMM, yyyy"></GridColumn>
                <GridColumn Field="PlacedBy" HeaderText="Placed By" Width="250"></GridColumn>
                <GridColumn Field="Amount" HeaderText="Amount" Width="120" Format="C2"></GridColumn>
            </GridColumns>
        </SfGrid>
    </CardContent>
</SfCard>

<style>
    .abandoned-cart-header {
        display: flex;
        align-items: center;
        justify-content: space-between;
        gap: 16px;
        width: 100%;
    }

    .abandoned-cart-title {
        margin: 0;
        line-height: 1.2;
    }

    .abandoned-cart-total {
        color: #6b7280;
        font-size: 14px;
        white-space: nowrap;
    }
</style>

@code {
    private SfGrid<Models.AbandonedCart>? grid;
    private List<Models.AbandonedCart> Items = new();

    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    private async Task LoadData()
    {
        // Load all items for client-side paging
        var totalCount = await AbandonedCartService.GetTotalCountAsync();
        Items = await AbandonedCartService.GetAbandonedCartsAsync(1, totalCount);
    }
}

{% endhighlight %}
{% endtabs %}

This page retrieves abandoned cart data and displays it in a sortable and filterable grid. Inline recovery status controls allow support teams to track and update outreach progress directly in the table.

### Create the Return and Refund page

This page lists all return and refund requests and allows administrators to review details and update request statuses.

{% tabs %}
{% highlight razor tabtitle="Components/Pages/ReturnRefund.razor" %}

@page "/return-refund"

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Cards
@using OrderManagementDashboard.Models
@using OrderManagementDashboard.Services
@inject IReturnRefundService ReturnRefundService
@inject IOrderService OrderService

<SfCard>
    <CardHeader>
        <div class="return-refund-header">
            <h2 class="return-refund-title">Return &amp; Refund</h2>
            <span class="return-refund-total">Total: @Items.Count requests</span>
        </div>
    </CardHeader>
    <CardContent>

        <SfGrid @ref="grid"
                DataSource="@Items" 
                AllowPaging="true"
                AllowSorting="true" 
                AllowFiltering="true"
                AllowSearching="true"
                Toolbar="@(new List<string>() { "Search" })">
            <GridPageSettings PageSize="10"></GridPageSettings>
            <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
            <GridSearchSettings Fields="@(new string[] { "Id", "OrderNumber", "Email" })" 
                                IgnoreCase="true" 
                                Operator="Syncfusion.Blazor.Operator.Contains"></GridSearchSettings>
            <GridColumns>
                <GridColumn Field="Id" HeaderText="ID" Width="120"></GridColumn>
                <GridColumn Field="OrderNumber" HeaderText="Order Number" Width="140"></GridColumn>
                <GridColumn Field="Amount" HeaderText="Amount" Width="120" Format="C2"></GridColumn>
                <GridColumn Field="OrderDate" HeaderText="Order Date" Width="140" Format="dd MMM, yyyy"></GridColumn>
                <GridColumn Field="Email" HeaderText="Email" Width="220"></GridColumn>
                <GridColumn Field="Reason" HeaderText="Reason" Width="250"></GridColumn>
                <GridColumn Field="Status" HeaderText="Status" Width="120">
                    <Template>
                        @{
                            var item = (Models.ReturnRefund)context;
                            var statusClass = GetStatusClass(item.Status);
                            <span class="status-badge @statusClass">
                                @item.Status
                            </span>
                        }
                    </Template>
                </GridColumn>
                <GridColumn Field="Date" HeaderText="Return Date" Width="140" Format="dd MMM, yyyy"></GridColumn>
                <GridColumn HeaderText="Action" Width="140">
                    <Template>
                        @{
                            var item = (Models.ReturnRefund)context;
                            <div style="display: flex; gap: 5px;">
                                @if (item.Status != "Approved" && item.Status != "Refunded" && item.Status != "Rejected")
                                {
                                    <SfButton CssClass="e-small e-success" Content="✓" OnClick="@(() => ApproveRefund(item.Id))" />
                                    <SfButton CssClass="e-small e-danger" Content="✕" OnClick="@(() => RejectRefund(item.Id))" />
                                }
                                else
                                {
                                    <span style="color: #6b7280; font-size: 12px;">@item.Status</span>
                                }
                            </div>
                        }
                    </Template>
                </GridColumn>
            </GridColumns>
        </SfGrid>

    </CardContent>
</SfCard>

<style>
   .return-refund-header {
        display: flex;
        align-items: center;
        justify-content: space-between;
        gap: 16px;
        width: 100%;
    }

    .return-refund-title {
        margin: 0;
        line-height: 1.2;
    }

    .return-refund-total {
        color: #6b7280;
        font-size: 14px;
        white-space: nowrap;
    }
    .status-badge {
        display: inline-block;
        padding: 4px 12px;
        border-radius: 12px;
        font-size: 12px;
        font-weight: 600;
        text-align: center;
    }

    .status-pending { background-color: #fef3c7; color: #92400e; }
    .status-approved { background-color: #d1fae5; color: #065f46; }
    .status-rejected { background-color: #fee2e2; color: #991b1b; }
    .status-processing { background-color: #dbeafe; color: #1e40af; }
    .status-refunded { background-color: #e0e7ff; color: #3730a3; }
</style>

@code {
    private SfGrid<Models.ReturnRefund>? grid;
    private List<Models.ReturnRefund> Items = new();

    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    private async Task LoadData()
    {
        // Load all items for client-side paging
        var totalCount = await ReturnRefundService.GetTotalCountAsync();
        Items = await ReturnRefundService.GetReturnRefundsAsync(1, totalCount);
    }

    private async Task ApproveRefund(string refundId)
    {
        var success = await ReturnRefundService.ApproveRefundAsync(refundId);
        if (success)
        {
            await LoadData();
            StateHasChanged();
        }
    }

    private async Task RejectRefund(string refundId)
    {
        var success = await ReturnRefundService.RejectRefundAsync(refundId);
        if (success)
        {
            await LoadData();
            StateHasChanged();
        }
    }

    private string GetStatusClass(string status)
    {
        return status.ToLower() switch
        {
            "pending" => "status-pending",
            "approved" => "status-approved",
            "rejected" => "status-rejected",
            "processing" => "status-processing",
            "refunded" => "status-refunded",
            _ => ""
        };
    }
}

{% endhighlight %}
{% endtabs %}

This page retrieves return and refund records from the service and presents them in a sortable, filterable grid. Status badges provide an at-a-glance view of each request, and inline dropdowns allow administrators to approve, reject, or update records without navigating away.

## Run the application

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application.

**Expected behavior**

* The application launches and displays the home page with navigation cards linking to each dashboard section.
* The dashboard page loads KPI cards showing totals for orders, revenue, abandoned carts, and refunds, along with a monthly revenue column chart and an order status donut chart.
* The orders page displays all orders in a paginated, sortable grid with status badges; inline dropdowns allow status updates without navigating away.
* The abandoned carts page lists all carts with estimated values and recovery states; inline dropdowns let support staff update outreach status per cart.
* The returns and refunds page displays all requests with type, reason, and status badges; administrators can approve, reject, or update each record inline, and the total refunded amount updates accordingly.

**Output**

![Blazor Order Management Dashboard sample](./order-dashboard.webp)

## See also

* [Getting started with Syncfusion Blazor DataGrid](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app)
* [Getting started with Syncfusion Blazor Charts](https://blazor.syncfusion.com/documentation/chart/getting-started-with-server-app)
* [Getting started with Blazor Accumulation Chart](https://blazor.syncfusion.com/documentation/accumulation-chart/getting-started-with-server-app)
* [Getting started with Blazor Card](https://blazor.syncfusion.com/documentation/card/getting-started-with-server-app)
* [Getting started with Blazor Buttons](https://blazor.syncfusion.com/documentation/button/getting-started-with-server-app)
* [Getting started with Blazor ComboBox](https://blazor.syncfusion.com/documentation/combobox/getting-started-with-server-app)
* [Getting started with Blazor Spinner](https://blazor.syncfusion.com/documentation/spinner/getting-started-webapp)