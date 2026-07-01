---
layout: post
title: Integrating Blazor DataGrid with Fluxor | Syncfusion
description: Step by step guide to integrate Blazor DataGrid with the Fluxor state management library in a .NET 10 Blazor Web App (Interactive Server) with full CRUD operations.
platform: Blazor
control: Common
documentation: ug
---

# Integrating Blazor DataGrid with Fluxor

This article explains how to integrate the **[Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid)** with **[Fluxor](https://github.com/mrpmorris/Fluxor)**, a zero-boilerplate Flux/Redux state management library for .NET, in a Blazor Web App targeting .NET 10 with Interactive Server rendering.

Fluxor provides a unidirectional data flow architecture where all application state lives in a single, immutable store. Actions describe what happened, reducers compute the new state, and effects handle asynchronous side operations such as API calls. The DataGrid subscribes to the Fluxor store and automatically re-renders whenever the state changes.

## Prerequisites

* [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
* [Visual Studio](https://visualstudio.microsoft.com/downloads/) 2022 or later or [Visual Studio Code](https://code.visualstudio.com/) with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension

## Create a Blazor Web App

Create a new **Blazor Web App** with Interactive Server rendering using the .NET CLI.

{% tabs %}
{% highlight bash tabtitle="Terminal" %}

dotnet new blazor -o FluxorBlazorDataGrid --interactivity Server
cd FluxorBlazorDataGrid

{% endhighlight %}
{% endtabs %}

## Install required NuGet packages

Install the Fluxor state management library and Blazor components for Grid, Dialog, Inputs, DatePicker, and DropDowns.

{% tabs %}
{% highlight bash tabtitle="Terminal" %}

dotnet add package Fluxor.Blazor.Web --version 6.9.0
dotnet add package Syncfusion.Blazor.Grid --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Popups --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Inputs --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Calendars --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.DropDowns --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Buttons --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes --version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

## Add required namespaces

Open the `~/Components/_Imports.razor` file and add the Syncfusion, Fluxor, and application namespaces.

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using Fluxor.Blazor.Web.Components
@using FluxorBlazorDataGrid.Models
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Calendars
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Buttons

{% endhighlight %}
{% endtabs %}

## Create the data model

Create a `Models` folder at the project root and add the `Order.cs` file.

{% tabs %}
{% highlight c# tabtitle="Models/Order.cs" %}

using System.ComponentModel.DataAnnotations;

namespace FluxorBlazorDataGrid.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer name is required.")]
        [StringLength(100, ErrorMessage = "Customer name cannot exceed 100 characters.")]
        public string? CustomerName { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, ErrorMessage = "Product name cannot exceed 100 characters.")]
        public string? ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public DateTime OrderDate { get; set; }

        public string? Status { get; set; }

        public Order()
        {
            OrderDate = DateTime.Now;
            Status = "Pending";
        }
    }
}

{% endhighlight %}
{% endtabs %}

## Create the order service

Create a `Services` folder at the project root and add `OrderService.cs`. This service is **completely stateless** — it only simulates asynchronous I/O. All application state lives exclusively in the Fluxor store.

{% tabs %}
{% highlight c# tabtitle="Services/OrderService.cs" %}

using FluxorBlazorDataGrid.Models;

namespace FluxorBlazorDataGrid.Services
{
    public class OrderService
    {
        private static int _nextId = 1;

        // Static constructor initializes _nextId to the max ID in seed data.
        // Set to max (not max + 1) because Interlocked.Increment increments
        // the value before returning it, so the first new ID will be max + 1.
        static OrderService()
        {
            var seedData = GetSeedData();
            if (seedData.Any())
                _nextId = seedData.Max(o => o.Id);
        }

        private static List<Order> GetSeedData()
        {
            return new List<Order>
            {
                new Order { Id =  1, CustomerName = "John Doe",        ProductName = "Laptop",              Quantity = 1, Price = 1200.00m, OrderDate = DateTime.Now.AddDays(-20), Status = "Completed"  },
                new Order { Id =  2, CustomerName = "Jane Smith",      ProductName = "Mouse",               Quantity = 2, Price = 25.50m,   OrderDate = DateTime.Now.AddDays(-19), Status = "Pending"    },
                new Order { Id =  3, CustomerName = "Bob Johnson",     ProductName = "Keyboard",            Quantity = 1, Price = 75.00m,   OrderDate = DateTime.Now.AddDays(-18), Status = "Processing" },
                new Order { Id =  4, CustomerName = "Alice Brown",     ProductName = "Monitor",             Quantity = 2, Price = 350.00m,  OrderDate = DateTime.Now.AddDays(-17), Status = "Shipped"    },
                new Order { Id =  5, CustomerName = "Charlie Wilson",  ProductName = "Webcam",              Quantity = 1, Price = 85.00m,   OrderDate = DateTime.Now.AddDays(-16), Status = "Pending"    },
                new Order { Id =  6, CustomerName = "Diana Prince",    ProductName = "Headphones",          Quantity = 3, Price = 120.00m,  OrderDate = DateTime.Now.AddDays(-15), Status = "Shipped"    },
                new Order { Id =  7, CustomerName = "Ethan Hunt",      ProductName = "USB Hub",             Quantity = 2, Price = 45.00m,   OrderDate = DateTime.Now.AddDays(-14), Status = "Completed"  },
                new Order { Id =  8, CustomerName = "Fiona Green",     ProductName = "Desk Chair",          Quantity = 1, Price = 299.00m,  OrderDate = DateTime.Now.AddDays(-13), Status = "Processing" },
                new Order { Id =  9, CustomerName = "George Harris",   ProductName = "Standing Desk",       Quantity = 1, Price = 499.00m,  OrderDate = DateTime.Now.AddDays(-12), Status = "Pending"    },
                new Order { Id = 10, CustomerName = "Hannah Lee",      ProductName = "Laptop Stand",        Quantity = 2, Price = 60.00m,   OrderDate = DateTime.Now.AddDays(-11), Status = "Shipped"    },
                new Order { Id = 11, CustomerName = "Ivan Petrov",     ProductName = "SSD Drive",           Quantity = 1, Price = 110.00m,  OrderDate = DateTime.Now.AddDays(-10), Status = "Completed"  },
                new Order { Id = 12, CustomerName = "Julia Roberts",   ProductName = "Printer",             Quantity = 1, Price = 220.00m,  OrderDate = DateTime.Now.AddDays(-9),  Status = "Cancelled"  },
                new Order { Id = 13, CustomerName = "Kevin Nguyen",    ProductName = "Ink Cartridge",       Quantity = 5, Price = 18.00m,   OrderDate = DateTime.Now.AddDays(-8),  Status = "Completed"  },
                new Order { Id = 14, CustomerName = "Laura Martinez",  ProductName = "Ethernet Cable",      Quantity = 3, Price = 12.00m,   OrderDate = DateTime.Now.AddDays(-7),  Status = "Shipped"    },
                new Order { Id = 15, CustomerName = "Mark Thompson",   ProductName = "Graphics Card",       Quantity = 1, Price = 650.00m,  OrderDate = DateTime.Now.AddDays(-6),  Status = "Processing" },
                new Order { Id = 16, CustomerName = "Nina Patel",      ProductName = "RAM Module",          Quantity = 2, Price = 95.00m,   OrderDate = DateTime.Now.AddDays(-5),  Status = "Pending"    },
                new Order { Id = 17, CustomerName = "Oscar Wilde",     ProductName = "Power Supply",        Quantity = 1, Price = 130.00m,  OrderDate = DateTime.Now.AddDays(-4),  Status = "Shipped"    },
                new Order { Id = 18, CustomerName = "Paula Scott",     ProductName = "Cooling Pad",         Quantity = 2, Price = 40.00m,   OrderDate = DateTime.Now.AddDays(-3),  Status = "Completed"  },
                new Order { Id = 19, CustomerName = "Quinn Adams",     ProductName = "Mechanical Keyboard", Quantity = 1, Price = 145.00m,  OrderDate = DateTime.Now.AddDays(-2),  Status = "Processing" },
                new Order { Id = 20, CustomerName = "Rachel Kim",      ProductName = "Wireless Mouse",      Quantity = 2, Price = 55.00m,   OrderDate = DateTime.Now.AddDays(-1),  Status = "Pending"    }
            };
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            await Task.Delay(500);
            return GetSeedData();
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            await Task.Delay(300);
            order.Id = Interlocked.Increment(ref _nextId);
            return order;
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            await Task.Delay(300);
            return order;
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            await Task.Delay(300);
            return true;
        }
    }
}

{% endhighlight %}
{% endtabs %}

## Set up the Fluxor store

The Fluxor store is organized in a `Store/OrderState/` folder with the following structure:

```
Store/
└── OrderState/
    ├── OrderState.cs
    ├── OrderFeature.cs
    ├── Actions/
    │   └── OrderActions.cs
    ├── Reducers/
    │   └── OrderReducers.cs
    └── Effects/
        └── OrderEffects.cs
```

### Define the state

`OrderState` is an immutable C# record. The `init` property accessors and `with` expressions in reducers enforce immutability as required by Fluxor.

{% tabs %}
{% highlight c# tabtitle="Store/OrderState/OrderState.cs" %}

using FluxorBlazorDataGrid.Models;

namespace FluxorBlazorDataGrid.Store.OrderState
{
    public record OrderState
    {
        public List<Order> Orders { get; init; } = new();
        public bool IsLoading { get; init; }
        public string? ErrorMessage { get; init; }
    }
}

{% endhighlight %}
{% endtabs %}

### Define the feature

`OrderFeature` registers the `OrderState` with Fluxor and provides the initial state when the application starts.

{% tabs %}
{% highlight c# tabtitle="Store/OrderState/OrderFeature.cs" %}

using Fluxor;

namespace FluxorBlazorDataGrid.Store.OrderState
{
    public class OrderFeature : Feature<OrderState>
    {
        public override string GetName() => nameof(OrderState);

        protected override OrderState GetInitialState()
        {
            return new OrderState
            {
                Orders = new List<Models.Order>(),
                IsLoading = false,
                ErrorMessage = null
            };
        }
    }
}

{% endhighlight %}
{% endtabs %}

### Define the actions

Actions are plain C# records. Each action describes an event. Success/Failure pairs are used for every async operation.

{% tabs %}
{% highlight c# tabtitle="Store/OrderState/Actions/OrderActions.cs" %}

using FluxorBlazorDataGrid.Models;

namespace FluxorBlazorDataGrid.Store.OrderState.Actions
{
    // Load Actions
    public record LoadOrdersAction;
    public record LoadOrdersSuccessAction(List<Order> Orders);
    public record LoadOrdersFailureAction(string ErrorMessage);

    // Add Actions
    public record AddOrderAction(Order Order);
    public record AddOrderSuccessAction(Order Order);
    public record AddOrderFailureAction(string ErrorMessage);

    // Update Actions
    public record UpdateOrderAction(Order Order);
    public record UpdateOrderSuccessAction(Order Order);
    public record UpdateOrderFailureAction(string ErrorMessage);

    // Delete Actions
    public record DeleteOrderAction(int OrderId);
    public record DeleteOrderSuccessAction(int OrderId);
    public record DeleteOrderFailureAction(string ErrorMessage);
}

{% endhighlight %}
{% endtabs %}

### Define the reducers

Reducers are **pure, static functions** decorated with `[ReducerMethod]`. They receive the current state and an action, and return a new state using `record with` expressions. Reducers must never produce side effects.

{% tabs %}
{% highlight c# tabtitle="Store/OrderState/Reducers/OrderReducers.cs" %}

using Fluxor;
using FluxorBlazorDataGrid.Store.OrderState.Actions;

namespace FluxorBlazorDataGrid.Store.OrderState.Reducers
{
    public static class OrderReducers
    {
        // Load Reducers
        [ReducerMethod]
        public static OrderState ReduceLoadOrdersAction(OrderState state, LoadOrdersAction action)
            => state with { IsLoading = true, ErrorMessage = null };

        [ReducerMethod]
        public static OrderState ReduceLoadOrdersSuccessAction(OrderState state, LoadOrdersSuccessAction action)
            => state with { Orders = action.Orders, IsLoading = false, ErrorMessage = null };

        [ReducerMethod]
        public static OrderState ReduceLoadOrdersFailureAction(OrderState state, LoadOrdersFailureAction action)
            => state with { IsLoading = false, ErrorMessage = action.ErrorMessage };

        // Add Reducers
        [ReducerMethod]
        public static OrderState ReduceAddOrderAction(OrderState state, AddOrderAction action)
            => state with { IsLoading = true, ErrorMessage = null };

        [ReducerMethod]
        public static OrderState ReduceAddOrderSuccessAction(OrderState state, AddOrderSuccessAction action)
        {
            var updatedOrders = new List<Models.Order>(state.Orders) { action.Order };
            return state with { Orders = updatedOrders, IsLoading = false, ErrorMessage = null };
        }

        [ReducerMethod]
        public static OrderState ReduceAddOrderFailureAction(OrderState state, AddOrderFailureAction action)
            => state with { IsLoading = false, ErrorMessage = action.ErrorMessage };

        // Update Reducers
        [ReducerMethod]
        public static OrderState ReduceUpdateOrderAction(OrderState state, UpdateOrderAction action)
            => state with { IsLoading = true, ErrorMessage = null };

        [ReducerMethod]
        public static OrderState ReduceUpdateOrderSuccessAction(OrderState state, UpdateOrderSuccessAction action)
        {
            var updatedOrders = state.Orders
                .Select(o => o.Id == action.Order.Id ? action.Order : o)
                .ToList();
            return state with { Orders = updatedOrders, IsLoading = false, ErrorMessage = null };
        }

        [ReducerMethod]
        public static OrderState ReduceUpdateOrderFailureAction(OrderState state, UpdateOrderFailureAction action)
            => state with { IsLoading = false, ErrorMessage = action.ErrorMessage };

        // Delete Reducers
        [ReducerMethod]
        public static OrderState ReduceDeleteOrderAction(OrderState state, DeleteOrderAction action)
            => state with { IsLoading = true, ErrorMessage = null };

        [ReducerMethod]
        public static OrderState ReduceDeleteOrderSuccessAction(OrderState state, DeleteOrderSuccessAction action)
        {
            var updatedOrders = state.Orders.Where(o => o.Id != action.OrderId).ToList();
            return state with { Orders = updatedOrders, IsLoading = false, ErrorMessage = null };
        }

        [ReducerMethod]
        public static OrderState ReduceDeleteOrderFailureAction(OrderState state, DeleteOrderFailureAction action)
            => state with { IsLoading = false, ErrorMessage = action.ErrorMessage };
    }
}

{% endhighlight %}
{% endtabs %}

### Define the effects

Effects handle all asynchronous operations. They are decorated with `[EffectMethod]`, receive an action and `IDispatcher`, call the service, and dispatch a success or failure action.

{% tabs %}
{% highlight c# tabtitle="Store/OrderState/Effects/OrderEffects.cs" %}

using Fluxor;
using FluxorBlazorDataGrid.Services;
using FluxorBlazorDataGrid.Store.OrderState.Actions;

namespace FluxorBlazorDataGrid.Store.OrderState.Effects
{
    public class OrderEffects
    {
        private readonly OrderService _orderService;

        public OrderEffects(OrderService orderService)
        {
            _orderService = orderService;
        }

        [EffectMethod]
        public async Task HandleLoadOrdersAction(LoadOrdersAction action, IDispatcher dispatcher)
        {
            try
            {
                var orders = await _orderService.GetOrdersAsync();
                dispatcher.Dispatch(new LoadOrdersSuccessAction(orders));
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new LoadOrdersFailureAction(ex.Message));
            }
        }

        [EffectMethod]
        public async Task HandleAddOrderAction(AddOrderAction action, IDispatcher dispatcher)
        {
            try
            {
                var addedOrder = await _orderService.AddOrderAsync(action.Order);
                dispatcher.Dispatch(new AddOrderSuccessAction(addedOrder));
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new AddOrderFailureAction(ex.Message));
            }
        }

        [EffectMethod]
        public async Task HandleUpdateOrderAction(UpdateOrderAction action, IDispatcher dispatcher)
        {
            try
            {
                var updatedOrder = await _orderService.UpdateOrderAsync(action.Order);
                dispatcher.Dispatch(new UpdateOrderSuccessAction(updatedOrder));
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new UpdateOrderFailureAction(ex.Message));
            }
        }

        [EffectMethod]
        public async Task HandleDeleteOrderAction(DeleteOrderAction action, IDispatcher dispatcher)
        {
            try
            {
                var success = await _orderService.DeleteOrderAsync(action.OrderId);
                if (success)
                    dispatcher.Dispatch(new DeleteOrderSuccessAction(action.OrderId));
                else
                    dispatcher.Dispatch(new DeleteOrderFailureAction("Failed to delete order."));
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new DeleteOrderFailureAction(ex.Message));
            }
        }
    }
}

{% endhighlight %}
{% endtabs %}

## Register services

Open `~/Program.cs` and register the Syncfusion service, `OrderService`, and Fluxor with `ScanAssemblies`. The `ScanAssemblies` call automatically discovers all Features, Reducers, and Effects in the assembly.

{% tabs %}
{% highlight c# tabtitle="Program.cs" hl_lines="2 3 4 12 16 19 20 21 22" %}

using FluxorBlazorDataGrid.Components;
using Fluxor;
using FluxorBlazorDataGrid.Services;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add Syncfusion Blazor service
builder.Services.AddSyncfusionBlazor();

// OrderService is stateless — all state lives in the Fluxor store.
// Scoped lifetime is appropriate for server-side Blazor.
builder.Services.AddScoped<OrderService>();

// Fluxor: ScanAssemblies automatically discovers all Features, Reducers, and Effects.
builder.Services.AddFluxor(options =>
{
    options.ScanAssemblies(typeof(Program).Assembly);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

{% endhighlight %}
{% endtabs %}

## Add stylesheet, script, and StoreInitializer

Open `~/Components/App.razor` and add the Syncfusion theme stylesheet, the Syncfusion script, and the Fluxor script. Also add the `StoreInitializer` component with `@rendermode="InteractiveServer"`.

N> The `StoreInitializer` component **must** have `@rendermode="InteractiveServer"`. In a .NET 10 Blazor Web App, `App.razor` runs as Static SSR by default. Without an explicit render mode, `StoreInitializer` also runs as Static SSR, which means Fluxor's JavaScript bridge is never established and state changes will never trigger a UI re-render.

The following snippet shows the relevant additions inside the existing `App.razor` file:

{% tabs %}
{% highlight html tabtitle="Components/App.razor" hl_lines="3 8 11 12 13" %}

<head>
    ...
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
    <HeadOutlet @rendermode="InteractiveServer" />
</head>

<body>
    <Fluxor.Blazor.Web.StoreInitializer @rendermode="InteractiveServer" />
    <Routes @rendermode="InteractiveServer" />
    <ReconnectModal />
    <script src="@Assets["_framework/blazor.web.js"]"></script>
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
    <script src="_content/Fluxor.Blazor.Web/scripts/index.js"></script>
</body>

{% endhighlight %}
{% endtabs %}

## Add the Order Management page

Create `~/Components/Pages/OrderManagement.razor`. This component:

* Inherits `FluxorComponent` to enable automatic re-renders when state changes.
* Injects `IState<OrderState>` to read the current state.
* Injects `IDispatcher` to dispatch actions.
* Dispatches `LoadOrdersAction` in `OnAfterRenderAsync` on first render (after the Interactive Server circuit is established) to load initial data.
* Uses `GridEditSettings` to enable the toolbar Add button and command column Edit/Delete buttons. All edit triggers (toolbar Add, row double-click, F2 key, Edit button) route to the same custom `SfDialog` via event handlers, disabling the grid's built-in inline editing completely.
* Wraps the dialog form content in `@if (DialogVisible)` to prevent an `ObjectDisposedException` from Syncfusion component JS interop callbacks when the dialog closes before an async effect completes.

{% tabs %}
{% highlight razor tabtitle="Components/Pages/OrderManagement.razor" %}

@page "/orders"
@using Fluxor
@using Fluxor.Blazor.Web.Components
@using FluxorBlazorDataGrid.Store.OrderState
@using FluxorBlazorDataGrid.Store.OrderState.Actions
@inherits FluxorComponent
@inject IState<OrderState> OrderState
@inject IDispatcher Dispatcher

<PageTitle>Order Management</PageTitle>

<h3>Order Management with Fluxor</h3>

@if (OrderState.Value.IsLoading)
{
    <div class="alert alert-info" role="status">Loading orders...</div>
}

@if (!string.IsNullOrEmpty(OrderState.Value.ErrorMessage))
{
    <div class="alert alert-danger" role="alert">
        @OrderState.Value.ErrorMessage
    </div>
}

<div class="control-section">
    <SfGrid DataSource="@OrderState.Value.Orders"
            Toolbar="@(new List<string>() { "Add" })"
            AllowPaging="true"
            AllowSorting="true"
            AllowFiltering="true">
        <GridPageSettings PageSize="10"></GridPageSettings>
        <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
        <GridEvents TValue="Order"
                    OnActionBegin="ActionBeginHandler"
                    CommandClicked="CommandClickHandler" />
        <GridColumns>
            <GridColumn Field="@nameof(Order.Id)"
                        HeaderText="Order ID"
                        IsPrimaryKey="true"
                        TextAlign="TextAlign.Right"
                        HeaderTextAlign="TextAlign.Right"
                        Width="110"></GridColumn>

            <GridColumn Field="@nameof(Order.CustomerName)"
                        HeaderText="Customer Name"
                        TextAlign="TextAlign.Left"
                        Width="150"></GridColumn>

            <GridColumn Field="@nameof(Order.ProductName)"
                        HeaderText="Product Name"
                        TextAlign="TextAlign.Left"
                        Width="150"></GridColumn>

            <GridColumn Field="@nameof(Order.Quantity)"
                        HeaderText="Quantity"
                        TextAlign="TextAlign.Center"
                        HeaderTextAlign="TextAlign.Center"
                        Width="100"></GridColumn>

            <GridColumn Field="@nameof(Order.Price)"
                        HeaderText="Price"
                        Format="C2"
                        TextAlign="TextAlign.Right"
                        HeaderTextAlign="TextAlign.Right"
                        Width="120"></GridColumn>

            <GridColumn Field="@nameof(Order.OrderDate)"
                        HeaderText="Order Date"
                        Format="d"
                        Type="ColumnType.Date"
                        TextAlign="TextAlign.Center"
                        HeaderTextAlign="TextAlign.Center"
                        Width="130"></GridColumn>

            <GridColumn Field="@nameof(Order.Status)"
                        HeaderText="Status"
                        TextAlign="TextAlign.Center"
                        HeaderTextAlign="TextAlign.Center"
                        Width="120"></GridColumn>

            <GridColumn HeaderText="Actions"
                        TextAlign="TextAlign.Center"
                        HeaderTextAlign="TextAlign.Center"
                        Width="150">
                <GridCommandColumns>
                    <GridCommandColumn Type="CommandButtonType.Edit"
                        ButtonOption="@(new CommandButtonOptions() { CssClass = "e-flat", IconCss = "e-edit e-icons" })">
                    </GridCommandColumn>
                    <GridCommandColumn Type="CommandButtonType.Delete"
                        ButtonOption="@(new CommandButtonOptions() { CssClass = "e-flat", IconCss = "e-delete e-icons" })">
                    </GridCommandColumn>
                </GridCommandColumns>
            </GridColumn>
        </GridColumns>
    </SfGrid>
</div>

<!-- Add/Edit Dialog -->
<SfDialog @bind-Visible="@DialogVisible"
          IsModal="true"
          Width="500px"
          ShowCloseIcon="true">
    <DialogTemplates>
        <Header>@DialogTitle</Header>
        <Content>
            @if (DialogVisible)
            {
                <EditForm Model="@CurrentEditOrder" OnValidSubmit="SaveOrder">
                    <DataAnnotationsValidator />
                    <div class="form-group mb-3">
                        <label>Customer Name:</label>
                        <SfTextBox @bind-Value="@CurrentEditOrder.CustomerName"
                                   Placeholder="Enter customer name">
                        </SfTextBox>
                        <ValidationMessage For="@(() => CurrentEditOrder.CustomerName)" />
                    </div>
                    <div class="form-group mb-3">
                        <label>Product Name:</label>
                        <SfTextBox @bind-Value="@CurrentEditOrder.ProductName"
                                   Placeholder="Enter product name">
                        </SfTextBox>
                        <ValidationMessage For="@(() => CurrentEditOrder.ProductName)" />
                    </div>
                    <div class="form-group mb-3">
                        <label>Quantity:</label>
                        <SfNumericTextBox TValue="int"
                                          @bind-Value="CurrentEditOrder.Quantity"
                                          Min="1"
                                          Format="N0">
                        </SfNumericTextBox>
                    </div>
                    <div class="form-group mb-3">
                        <label>Price:</label>
                        <SfNumericTextBox TValue="decimal"
                                          @bind-Value="CurrentEditOrder.Price"
                                          Min="0.01m"
                                          Format="C2">
                        </SfNumericTextBox>
                    </div>
                    <div class="form-group mb-3">
                        <label>Order Date:</label>
                        <SfDatePicker TValue="DateTime"
                                      @bind-Value="CurrentEditOrder.OrderDate"
                                      Format="MM/dd/yyyy"
                                      Placeholder="Select order date">
                        </SfDatePicker>
                    </div>
                    <div class="form-group mb-3">
                        <label>Status:</label>
                        <SfDropDownList TValue="string" TItem="string"
                                        @bind-Value="CurrentEditOrder.Status"
                                        DataSource="@StatusList"
                                        Placeholder="Select status">
                        </SfDropDownList>
                    </div>
                    <div class="form-group d-flex justify-content-end gap-2">
                        <SfButton Type="ButtonType.Submit" CssClass="e-primary">Save</SfButton>
                        <SfButton Type="ButtonType.Button" CssClass="e-flat" OnClick="CloseDialog">Cancel</SfButton>
                    </div>
                </EditForm>
            }
        </Content>
    </DialogTemplates>
</SfDialog>

@code {
    private bool DialogVisible { get; set; }
    private string DialogTitle { get; set; } = "Add Order";
    private Order CurrentEditOrder { get; set; } = new Order();
    private bool IsAddMode { get; set; }
    private List<string> StatusList = new() { "Pending", "Processing", "Shipped", "Completed", "Cancelled" };

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        // Always call base first. FluxorComponent.OnAfterRenderAsync subscribes
        // to state change notifications on the first render. Calling base last
        // would cause the initial dispatch to fire before the subscription is
        // active, meaning the grid would never receive the loaded data.
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender && !OrderState.Value.IsLoading && !OrderState.Value.Orders.Any())
        {
            Dispatcher.Dispatch(new LoadOrdersAction());
        }
    }

    private void ActionBeginHandler(ActionEventArgs<Order> args)
    {
        if (args.RequestType == Syncfusion.Blazor.Grids.Action.Add)
        {
            // Toolbar Add button clicked — open the custom dialog.
            IsAddMode = true;
            DialogTitle = "Add New Order";
            CurrentEditOrder = new Order();
            DialogVisible = true;
            // Cancel the default grid inline add-row behavior so the
            // custom SfDialog handles the form submission instead.
            args.Cancel = true;
        }
        else if (args.RequestType == Syncfusion.Blazor.Grids.Action.BeginEdit)
        {
            // Row double-clicked, F2 key pressed, or command column Edit button clicked.
            if (args.Data != null)
            {
                IsAddMode = false;
                DialogTitle = "Edit Order";
                // Create a copy so edits do not mutate the immutable Fluxor state directly.
                CurrentEditOrder = new Order
                {
                    Id           = args.Data.Id,
                    CustomerName = args.Data.CustomerName,
                    ProductName  = args.Data.ProductName,
                    Quantity     = args.Data.Quantity,
                    Price        = args.Data.Price,
                    OrderDate    = args.Data.OrderDate,
                    Status       = args.Data.Status
                };
                DialogVisible = true;
                // Cancel the default grid inline edit-row behavior so the
                // custom SfDialog handles the form submission instead.
                args.Cancel = true;
            }
        }
    }

    private void CommandClickHandler(CommandClickEventArgs<Order> args)
    {
        // The Edit command raises Action.BeginEdit which is handled in ActionBeginHandler.
        // Handle Delete here because it has no corresponding ActionBegin event.
        if (args.CommandColumn?.Type == CommandButtonType.Delete && args.RowData != null)
        {
            Dispatcher.Dispatch(new DeleteOrderAction(args.RowData.Id));
        }
    }

    private void SaveOrder()
    {
        if (IsAddMode)
            Dispatcher.Dispatch(new AddOrderAction(CurrentEditOrder));
        else
            Dispatcher.Dispatch(new UpdateOrderAction(CurrentEditOrder));

        CloseDialog();
    }

    private void CloseDialog()
    {
        DialogVisible = false;
        CurrentEditOrder = new Order();
    }
}

{% endhighlight %}
{% endtabs %}

## Add navigation link

Open `~/Components/Layout/NavMenu.razor` and add a link to the Order Management page.

{% tabs %}
{% highlight razor tabtitle="Components/Layout/NavMenu.razor" %}

<div class="nav-item px-3">
    <NavLink class="nav-link" href="orders">
        <span class="bi bi-table" aria-hidden="true"></span> Orders
    </NavLink>
</div>

{% endhighlight %}
{% endtabs %}

## Run the application

Run the application using the .NET CLI.

{% tabs %}
{% highlight bash tabtitle="Terminal" %}

dotnet run

{% endhighlight %}
{% endtabs %}

Navigate to `https://localhost:{port}/orders` in a browser. The DataGrid loads with twenty seed orders and supports full CRUD operations through the Fluxor store.

## How it works

The following diagram shows the unidirectional data flow between the DataGrid, Fluxor store, and the order service.

* **Load**: On first render, `LoadOrdersAction` is dispatched → the `LoadOrders` effect calls `GetOrdersAsync()` → dispatches `LoadOrdersSuccessAction` → the reducer updates `Orders` in state → `FluxorComponent` triggers `StateHasChanged()` → the DataGrid re-renders with data.
* **Add**: The toolbar **Add** button opens an `SfDialog` → on submit, `AddOrderAction` is dispatched → the `AddOrder` effect calls `AddOrderAsync()` → dispatches `AddOrderSuccessAction` with the server-assigned order → the reducer appends it to `Orders`.
* **Edit**: The command column **Edit** button opens the dialog pre-populated with the selected row's data → on submit, `UpdateOrderAction` is dispatched → the effect calls `UpdateOrderAsync()` → the reducer replaces the matching record in `Orders`.
* **Delete**: The command column **Delete** button dispatches `DeleteOrderAction` immediately → the effect calls `DeleteOrderAsync()` → the reducer removes the record from `Orders` by ID.

## Key implementation notes

* **`@inherits FluxorComponent`**: Automatically subscribes to state changes and calls `StateHasChanged()` when any Fluxor state in the component changes. This is what causes the DataGrid to re-render after every action.

* **`StoreInitializer @rendermode="InteractiveServer"`**: Required in `App.razor`. Without this, Fluxor's JavaScript bridge is never established in a Blazor Web App because `App.razor` renders as Static SSR by default. State changes will not trigger UI re-renders without this.

* **`OnAfterRenderAsync` with `await base` first**: Dispatch the initial load action in `OnAfterRenderAsync(firstRender)` and always call `await base.OnAfterRenderAsync(firstRender)` before dispatching. The `FluxorComponent` base implementation sets up the state subscription on first render. Dispatching before the base call means the subscription is not yet active, and the grid will remain empty.

* **`@if (DialogVisible)` guard in dialog content**: Wrapping the `SfDialog` content in `@if (DialogVisible)` prevents an `ObjectDisposedException`. When `SaveOrder()` is called, it dispatches an async Effect and immediately calls `CloseDialog()`. Blazor re-renders and removes the Syncfusion input components from the render tree, disposing their `DotNetObjectReference` JS interop callbacks. Approximately 300ms later, the Effect completes and Fluxor calls `StateHasChanged()`. Without the guard, Blazor encounters the disposed references. With the guard, when `DialogVisible` is `false`, the components are never in the render tree and no disposal conflict occurs.

* **Copying state before edit**: In `ActionBeginHandler`, `CurrentEditOrder` is populated by copying each field from `args.Data` into a new `Order` instance. This ensures that form edits do not mutate the immutable Fluxor store directly, preserving the unidirectional data flow guarantee.

* **Stateless `OrderService`**: The service holds no in-memory order list. All state lives in the Fluxor store. This means any number of service instances can be created without diverging state, and Scoped lifetime works correctly with Fluxor Effects.

* **`args.Cancel = true` in `ActionBeginHandler`**: Cancels the DataGrid's built-in inline edit/add row when the toolbar Add or command column Edit is triggered, allowing the custom `SfDialog` form to handle the operation instead.

## See also

* [Getting Started with Blazor DataGrid in Blazor Web App](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app)
* [Integrating Blazor DataGrid with GitHub Codespaces](https://blazor.syncfusion.com/documentation/common/integration/blazor-with-github-codespaces)
* [Integrating Blazor DataGrid with PDF Viewer](https://blazor.syncfusion.com/documentation/common/integration/blazor-with-pdf-viewer)
* [Integrating Blazor DataGrid with Spreadsheet](https://blazor.syncfusion.com/documentation/common/integration/blazor-grid-with-spreadsheet)
* [Integrating Blazor DataGrid with Bold Report Viewer](https://blazor.syncfusion.com/documentation/common/integration/blazor-datagrid-boldreports)