---
layout: post
title: Create an Order Management Dashboard in Blazor | Syncfusion
description: Step-by-step guide to build a Blazor order management dashboard using Blazor components with models, services, grids, charts, KPIs, carts, and refunds.
platform: Blazor
control: Common
documentation: ug
---

# Create an Order Management Dashboard in Blazor

## Overview

This guide explains how to create an order management dashboard using [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid), [Blazor Button](https://www.syncfusion.com/blazor-components/blazor-button), [Blazor Card](https://www.syncfusion.com/blazor-components/blazor-card), [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts), [Blazor DropDown List](https://www.syncfusion.com/blazor-components/blazor-dropdown-list), [Blazor Accordion](https://www.syncfusion.com/blazor-components/blazor-accordion) and [Blazor Dialog](https://www.syncfusion.com/blazor-components/blazor-modal-dialog) components. It walks through the core building blocks for a typical e-commerce back-office application, including defining data models, managing application state with dependency-injected services, and building pages for KPI metrics, order tracking, abandoned cart analysis, and return and refund management.

## Prerequisites

* [.NET 8 SDK or later](https://dotnet.microsoft.com/en-us/download/dotnet)
* [Visual Studio Code](https://code.visualstudio.com/) with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension

## Create the Blazor project

To create a Blazor application, follow the [Blazor Server App getting started guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio?tabcontent=visual-studio-code).

### Install required Blazor packages

To install the required Blazor packages, open a terminal in your project root and run the following commands.

| Component | Package |
|----------------|---------|
| Button | [Syncfusion.Blazor.Buttons](https://www.nuget.org/packages/Syncfusion.Blazor.Buttons) |
| Card | [Syncfusion.Blazor.Cards](https://www.nuget.org/packages/Syncfusion.Blazor.Cards) |
| Charts | [Syncfusion.Blazor.Charts](https://www.nuget.org/packages/Syncfusion.Blazor.Charts) |
| DropDownList | [Syncfusion.Blazor.DropDowns](https://www.nuget.org/packages/Syncfusion.Blazor.DropDowns) |
| DataGrid | [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid) |
| Accordion | [Syncfusion.Blazor.Navigations](https://www.nuget.org/packages/Syncfusion.Blazor.Navigations) |
| Dialog | [Syncfusion.Blazor.Popups](https://www.nuget.org/packages/Syncfusion.Blazor.Popups) |
| Themes | [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes) |

{% tabs %}
{% highlight bash tabtitle="Terminal" %}

dotnet add package Syncfusion.Blazor.Buttons --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Cards --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Charts --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.DropDowns --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Grid --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Navigations --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Popups --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes --version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

For the complete list of available packages, refer to the [Blazor NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages).

### Add required namespaces

Open the `Components/_Imports.razor` file and import the following Blazor components, order management models and services namespaces.

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
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Popups

{% endhighlight %}
{% endtabs %}

### Register Blazor service

Add the Blazor service to the `~/Program.cs` file to enable Blazor components in the application.

{% tabs %}
{% highlight cs tabtitle="~/Program.cs" hl_lines="1 8" %}

using Syncfusion.Blazor;
...
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register Blazor service
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
...

{% endhighlight %}
{% endtabs %}

### Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the [stylesheet](https://blazor.syncfusion.com/documentation/appearance/themes) and [script references](https://blazor.syncfusion.com/documentation/common/adding-script-references) in the **App.razor** file.

{% tabs %}
{% highlight html tabtitle="App.razor" %}

<head>
    ...
    <!-- Blazor theme stylesheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
</head>
<body>
    ...
    <!-- Blazor core script (required for UI components) -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"></script>
</body>

{% endhighlight %}
{% endtabs %}

## Configure routing

The application uses `Routes.razor` for routing and `App.razor` to apply the `InteractiveServer` render mode across routed pages.

### Routes component

The `Routes.razor` file contains a default `Router` component that matches URLs to page components. To ensure users always start at the dashboard, you need to add custom logic in the `@code` block that redirects requests from the root path (`/`) to `/dashboard`.

Add the following code to the `@code` section of `Routes.razor`.

{% tabs %}
{% highlight razor tabtitle="Components/Routes.razor" %}

...
@code {
    [Inject] private NavigationManager Navigation { get; set; } = default!;
    
    protected override void OnInitialized()
    {
        if (Navigation?.Uri?.EndsWith("/") == true)
        {
            Navigation.NavigateTo("/dashboard");
        }
    }
}

{% endhighlight %}
{% endtabs %}

### App root component

The `App.razor` file renders the `Routes` component and applies the `InteractiveServer` render mode attribute. This render mode enables interactive server-side rendering for all routed pages, allowing real-time user interactions and dynamic updates throughout the application.

Update the `App.razor` to include the `@rendermode` attribute on the `Routes` component.

{% tabs %}
{% highlight html tabtitle="App.razor" hl_lines="3" %}

...
<body>
    <Routes @rendermode="InteractiveServer" />
    <ReconnectModal />
    <script src="@Assets["_framework/blazor.web.js"]"></script>
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"></script>
</body>

{% endhighlight %}
{% endtabs %}

## Project structure

Organize the application using the following folder structure to separate concerns and maintain a clean project layout.

```text
OrderManagementDashboard/
├── Components/
│   ├── Pages/              # Routable pages (Dashboard, AbandonedCart, ReturnRefund)
│   ├── Layout/             # Layout components (MainLayout, NavMenu)
│   ├── _Imports.razor      # Namespace imports
│   ├── App.razor           # Root component
│   └── Routes.razor        # Route definitions
├── Models/                 # Data models (Order, AbandonedCart, DashboardKpi, ReturnRefund)
├── Services/               # Application services (OrderService, AbandonedCartService, ReturnRefundService, SharedDataConstants)
├── wwwroot/                # Static files (CSS, images)
├── Properties/
│   └── launchSettings.json
├── appsettings.json
└── Program.cs
```

This structure helps keep the application maintainable and scalable by clearly separating data models, services, and UI components. It also makes it easier to update or extend the application as requirements evolve.

## Define data models

### `Order` model

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
        public string Items { get; set; } = string.Empty;
        public string ShippingAddress { get; set; } = string.Empty;
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

### `Abandoned cart` model

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

### `Dashboard KPI` model

Defines the data model used to represent a key performance indicator displayed on the dashboard.

{% tabs %}
{% highlight cs tabtitle="Models/DashboardKpi.cs" %}

namespace OrderManagementDashboard.Models
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

### `Return and refund` model

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

N> This static data source provides sample data for demonstration purposes only. It allows the application to function without a backend service. **For production applications**, replace these services with actual database implementations using Entity Framework Core or another data access technology. Note that the static collections are initialized once and shared across scoped service instances, with thread-safe initialization ensured by the initialization lock.

## Create the services

In a Blazor application, services are used to handle business logic and maintain shared state across components. They are registered with dependency injection and allow multiple pages and components to access the same data in a consistent and controlled manner.

The application uses three scoped services to provide in-memory sample data and business logic for orders, abandoned carts, and return/refund requests. Each service below contains both the service interface and its implementation.

### Order service

Provides paged and searchable order data and delivers aggregated KPI and profit margin time series for dashboard charts while exposing methods to retrieve individual orders.

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
                var costOfGoods = totalRevenue * 0.65m;
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

### Abandoned cart service

Provides paged, searchable access to generated abandoned-cart sample data and reuses existing customer emails to generate realistic demo entries.

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

### Return and refund service

Manages paged and searchable return and refund requests and supports approve and reject operations while calculating refunded totals for dashboard KPIs.

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

...
using Syncfusion.Blazor;

...
// Register Blazor service
builder.Services.AddSyncfusionBlazor();

// Application services
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAbandonedCartService, AbandonedCartService>();
builder.Services.AddScoped<IReturnRefundService, ReturnRefundService>();

var app = builder.Build();
...

{% endhighlight %}
{% endtabs %}

## Create the navigation layout

### Update the NavMenu component

Update the navigation menu to include links to all dashboard pages.

{% tabs %}
{% highlight razor tabtitle="Components/Layout/NavMenu.razor" %}

<div class="nav-menu">
    <div class="nav-header">
        <h3>ORDER MANAGEMENT</h3>
    </div>

    <SfAccordion>
        <AccordionItems>
            <AccordionItem Expanded="true">
                <HeaderTemplate>
                    <div class="menu-item-header">
                        <span class="menu-icon" aria-hidden="true">
                            <svg viewBox="0 0 24 24" focusable="false" role="img">
                                <path d="M3 3h2l.4 2M7 13h10l3-8H6.4"></path>
                                <circle cx="10" cy="20" r="1.5"></circle>
                                <circle cx="17" cy="20" r="1.5"></circle>
                            </svg>
                        </span>
                        <span>Orders</span>
                        <span class="dropdown-icon" aria-hidden="true">
                            <svg viewBox="0 0 24 24" focusable="false" role="img">
                                <path d="M6 9l6 6 6-6"></path>
                            </svg>
                        </span>
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
        line-height: 1;
    }

    .menu-icon,
    .dropdown-icon,
    .submenu-icon {
        display: inline-flex;
        align-items: center;
        justify-content: center;
        flex-shrink: 0;
    }

    .menu-icon {
        width: 18px;
        height: 18px;
    }

    .menu-icon svg,
    .dropdown-icon svg,
    .submenu-icon svg {
        width: 100%;
        height: 100%;
        fill: none;
        stroke: currentColor;
        stroke-width: 2;
        stroke-linecap: round;
        stroke-linejoin: round;
    }

    .dropdown-icon {
        margin-left: auto;
        width: 14px;
        height: 14px;
        opacity: 0.9;
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
        line-height: 1;
    }

    .submenu-icon {
        width: 16px;
        height: 16px;
    }

    .submenu-item:hover {
        background: rgba(255, 255, 255, 0.1);
        color: white;
    }

    .submenu-item.active {
        background: rgba(255, 255, 255, 0.2);
        color: white;
    }
</style>

{% endhighlight %}
{% endtabs %}

## Create the application pages

### Create the `Dashboard` page

This page demonstrates how the Dashboard page integrates multiple Blazor components to present an interactive overview of order data. It displays key performance indicators using **[Blazor Card](https://www.syncfusion.com/blazor-components/blazor-card)**, visualizes earnings and total profit trends using **[Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts)**, and renders a comprehensive order list using **[Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid)** with built-in filtering and search.

The page binds data collections and state variables to these components, enabling dynamic updates, filtering options, and detailed order views. This provides a single, interactive view of order performance, profit trends, and order details.

{% tabs %}
{% highlight razor tabtitle="Components/Pages/Dashboard.razor" %}

@page "/dashboard"

@using OrderManagementDashboard.Models
@using OrderManagementDashboard.Services
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
                            <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <path d="M21 16V8a2 2 0 0 0-1-1.73l-7-4a2 2 0 0 0-2 0l-7 4A2 2 0 0 0 3 8v8a2 2 0 0 0 1 1.73l7 4a2 2 0 0 0 2 0l7-4A2 2 0 0 0 21 16z"></path>
                                <line x1="9" y1="9" x2="15" y2="15"></line>
                                <line x1="15" y1="9" x2="9" y2="15"></line>
                            </svg>
                        </div>
                    </div>
                    <div class="kpi-text">
                        <div class="kpi-label">Cancelled</div>
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

    <div class="chart-container">
        <div class="chart-header">
            <h3 class="page-title">Profit Margin</h3>
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

    <div class="grid-container">
        <div class="grid-header">
            <h3 class="page-title">Order Management Details</h3>
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
            <GridPageSettings PageSize="10" PageSizes="@(new int[] {10, 20, 50, 100})"></GridPageSettings>
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
    
    .kpi-blue {
        background: linear-gradient(135deg, #B8D4F1 0%, #A0C5EE 100%);
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
{% highlight css tabtitle="Components/Pages/Dashboard.razor.css" %}

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

.kpi-grid {
    display: grid;
    grid-template-columns: repeat(4, 1fr);
    gap: 16px;
    margin-bottom: 30px;
}

.kpi-card-horizontal {
    display: flex;
    align-items: center;
    gap: 16px;
    padding: 20px;
}

.kpi-value {
    font-size: 28px;
    font-weight: 700;
    color: #1a1a1a;
    line-height: 1;
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

.grid-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 12px;
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

{% endhighlight %}
{% endtabs %}

### Create the `Abandoned Cart` page

This page demonstrates how the Abandoned Cart page uses Blazor components to present a searchable and filterable list of abandoned shopping carts. It displays the cart data in a **[Blazor Card](https://www.syncfusion.com/blazor-components/blazor-card)** layout and renders the records in a **[Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid)** with paging, sorting, filtering, and search support.

The page binds the abandoned cart collection to the grid, allowing users to search by cart ID or customer email, view cart dates, and review estimated cart amounts in a structured format.

{% tabs %}
{% highlight razor tabtitle="Components/Pages/AbandonedCart.razor" %}

@page "/abandoned-cart"

@using OrderManagementDashboard.Models
@using OrderManagementDashboard.Services
@inject IAbandonedCartService AbandonedCartService

<SfCard>
    <CardHeader>
        <div class="abandoned-cart-header">
            <h3 class="page-card-title">Abandoned Cart</h3>
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
                <GridColumn Field="PlacedBy" HeaderText="Placed By" Width="230"></GridColumn>
                <GridColumn Field="Amount" HeaderText="Amount" Width="120" Format="C2" TextAlign="TextAlign.Right"></GridColumn>
            </GridColumns>
        </SfGrid>
    </CardContent>
</SfCard>

@code {
    private SfGrid<Models.AbandonedCart>? grid;
    private List<Models.AbandonedCart> Items = new();

    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    private async Task LoadData()
    {
        var totalCount = await AbandonedCartService.GetTotalCountAsync();
        Items = await AbandonedCartService.GetAbandonedCartsAsync(1, totalCount);
    }
}

{% endhighlight %}
{% highlight css tabtitle="Components/Pages/AbandonedCart.razor.css" %}

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

.page-card-title {
    font-size: 20px;
    font-weight: 700;
    color: #1a1a1a;
    margin: 0;
}

{% endhighlight %}
{% endtabs %}

### Create the `Return and Refund` page

This page demonstrates how the Return and Refund page uses Blazor components to manage customer return and refund requests. It displays the requests in a **[Blazor Card](https://www.syncfusion.com/blazor-components/blazor-card)** layout and renders them in a **[Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid)** with paging, sorting, filtering, and search support.

The page binds return and refund records to the grid, showing order details, request reasons, status badges, and return dates. It also provides approve and reject actions for pending requests, enabling administrators to update request statuses directly from the page.

{% tabs %}
{% highlight razor tabtitle="Components/Pages/ReturnRefund.razor" %}

@page "/return-refund"

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
                <GridColumn Field="Amount" HeaderText="Amount" Width="120" Format="C2" TextAlign="TextAlign.Right"></GridColumn>
                <GridColumn Field="OrderDate" HeaderText="Order Date" Width="140" Format="dd MMM, yyyy"></GridColumn>
                <GridColumn Field="Email" HeaderText="Email" Width="220"></GridColumn>
                <GridColumn Field="Reason" HeaderText="Reason" Width="250"></GridColumn>
                <GridColumn Field="Status" HeaderText="Status" Width="120" TextAlign="TextAlign.Center">
                    <Template>
                        @{
                            var item = (Models.ReturnRefund)context;
                            var statusClass = GetStatusClass(item.Status);
                            <span class="status-badge @statusClass">@item.Status</span>
                        }
                    </Template>
                </GridColumn>
                <GridColumn Field="Date" HeaderText="Return Date" Width="140" Format="dd MMM, yyyy"></GridColumn>
                <GridColumn HeaderText="Action" Width="140">
                    <Template>
                        @{
                            var item = (Models.ReturnRefund)context;
                            <div class="action-buttons">
                                @if (item.Status != "Approved" && item.Status != "Refunded" && item.Status != "Rejected")
                                {
                                    <SfButton CssClass="e-small e-success action-button"
                                            IconCss="e-icons e-check"
                                            Title="Approve"
                                            OnClick="@(() => ApproveRefund(item.Id))" />
                                    <SfButton CssClass="e-small e-danger action-button"
                                            IconCss="e-icons e-close"
                                            Title="Reject"
                                            OnClick="@(() => RejectRefund(item.Id))" />
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

@code {
    private SfGrid<Models.ReturnRefund>? grid;
    private List<Models.ReturnRefund> Items = new();

    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    private async Task LoadData()
    {
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
{% highlight css tabtitle="Components/Pages/ReturnRefund.razor.css" %}

.return-refund-header {
    display: flex;
    align-items: center;
    justify-content: space-between;
    gap: 16px;
    width: 100%;
}

.return-refund-title {
    font-size: 20px;
    font-weight: 700;
    color: #1a1a1a;
    margin: 0;
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
    line-height: 1;
}

.status-pending { background-color: #fef3c7; color: #92400e; }
.status-approved { background-color: #d1fae5; color: #065f46; }
.status-rejected { background-color: #fee2e2; color: #991b1b; }
.status-processing { background-color: #dbeafe; color: #1e40af; }
.status-refunded { background-color: #e0e7ff; color: #3730a3; }

.action-buttons {
    display: flex;
    align-items: center;
    gap: 6px;
}

.action-button {
    min-width: 30px;
    width: 30px;
    height: 30px;
    padding: 0;
    display: inline-flex;
    align-items: center;
    justify-content: center;
}

.action-button .e-btn-icon,
.action-button .e-icons {
    margin: 0;
    font-size: 14px;
    line-height: 1;
}

{% endhighlight %}
{% endtabs %}

## Run the Application

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application.

Alternatively, run the application using the following .NET CLI command from the project root directory.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet run

{% endhighlight %}
{% endtabs %}

**Expected behavior**

* The application launches and displays the navigation menu on the left side with expandable order management sections.
* The application redirects to `/dashboard` and displays the **All Orders** dashboard page, showing:
  - Seven KPI cards showing order status metrics (Total Orders, Processing, Shipped, Delivered, Cancelled, Returned, Failed)
  - A profit margin line chart with toggleable 6-month and 12-month views
  - A comprehensive data grid showing all orders with filtering options for payment status, received status, and date ranges
  - Search functionality to find orders by ID, customer name, order number, or email
  - A "View Details" action button that opens a dialog showing complete order information
* The Abandoned Carts page displays all abandoned carts in a filterable, searchable grid with ID, date, customer email, and cart amount.
* The Returns and Refunds page displays all return requests with approve/reject action buttons and status badges.
* All grids support pagination, sorting, filtering, and searching.
* The application uses in-memory data services, so no backend database is required for demonstration purposes.

**Output**

![Blazor Order Management Dashboard sample](./images/order-management-dashboard.webp)

## See also

* [Getting started with Blazor DataGrid](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app)
* [Getting started with Blazor Charts](https://blazor.syncfusion.com/documentation/chart/getting-started)
* [Getting started with Blazor Card](https://blazor.syncfusion.com/documentation/card/getting-started-with-server-app)
* [Getting started with Blazor Button](https://blazor.syncfusion.com/documentation/button/getting-started-with-server-app)
* [Getting started with Blazor DropDown List](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started-with-server-app)
* [Getting started with Blazor Accordion](https://blazor.syncfusion.com/documentation/accordion/getting-started-with-server-app)
* [Getting started with Blazor Dialog](https://blazor.syncfusion.com/documentation/dialog/getting-started-with-server-app)
