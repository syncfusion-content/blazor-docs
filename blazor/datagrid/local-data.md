---
layout: post
title: Local Data in Blazor DataGrid | Syncfusion
description: Checkout and learn here all about Local Data in Syncfusion Blazor DataGrid and much more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Local data in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid offers a straightforward way to bind local data, such as arrays or JSON objects, to the Grid. This feature allows you to display and manipulate data within the Grid without the need for external server calls, making it particularly useful for scenarios where you're working with static or locally stored data.

To achieve this, you can assign a JavaScript object array to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property. Additionally, you have an option to provide the local data source using an instance of the **DataManager**.

The following example demonstrates how to utilize the local data binding feature in the Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>    
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>    
    </GridColumns>
</SfGrid>

@code {
    private List<OrderDetails> OrderData;
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
}

{% endhighlight %}

{% highlight cs tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();

    public OrderDetails() { }

    public OrderDetails(int OrderID, string CustomerId, string ShipCity, string ShipName)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.ShipCity = ShipCity;
        this.ShipName = ShipName;
    }

    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", "Reims", "Vins et alcools Chevalier"));
            order.Add(new OrderDetails(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            order.Add(new OrderDetails(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            order.Add(new OrderDetails(10251, "VICTE", "Lyon", "Victuailles en stock"));
            order.Add(new OrderDetails(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            order.Add(new OrderDetails(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            order.Add(new OrderDetails(10254, "CHOPS", "Bern", "Chop-suey Chinese"));
            order.Add(new OrderDetails(10255, "RICSU", "Genève", "Richter Supermarkt"));
            order.Add(new OrderDetails(10256, "WELLI", "Resende", "Wellington Importadora"));
            order.Add(new OrderDetails(10257, "HILAA", "San Cristóbal", "HILARION-Abastos"));
            order.Add(new OrderDetails(10258, "ERNSH", "Graz", "Ernst Handel"));
            order.Add(new OrderDetails(10259, "CENTC", "México D.F.", "Centro comercial Moctezuma"));
            order.Add(new OrderDetails(10260, "OTTIK", "Köln", "Ottilies Käseladen"));
            order.Add(new OrderDetails(10261, "QUEDE", "Rio de Janeiro", "Que Delícia"));
            order.Add(new OrderDetails(10262, "RATTC", "Albuquerque", "Rattlesnake Canyon Grocery"));
        }
        return order;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BthSXpBAUaAyeguK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Data binding with SignalR 

The syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides support for real-time data binding using SignalR, allowing you to update the grid automatically as data changes on the server-side. This feature is particularly useful for applications requiring live updates and synchronization across multiple clients.

To achieve real-time data binding with SignalR in your Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, follow the steps below:

**Step 1:** Install the SignalR server package:

To add the SignalR server package to the app, open the NuGet Package Manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search for, and install the [Microsoft.AspNetCore.SignalR.Client](https://www.nuget.org/packages/Microsoft.AspNetCore.SignalR.Client) package.

**Step 2:** Create a **Hubs** folder and add the following **ChatHub** class (**Hubs/ChatHub.cs**):

```cs

using Microsoft.AspNetCore.SignalR;

namespace SignalRDataGrid.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage()
    {
        await Clients.All.SendAsync("ReceiveMessage");
    }
}

```

**Step 3:** Configure the SignalR server to route requests to the SignalR hub. In the **Program.cs** file, include the following code:

```cs

using SignalRDataGrid.Hubs;

var app = builder.Build();

app.UseRouting();
app.UseAntiforgery();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/chathub");
    endpoints.MapFallbackToFile("/_Host");
});
app.Run();

```

**Step 4:** Create a simple Grid by following the [Getting Started](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app) documentation link.

**Step 5:** Create a **Data** folder and add Data Controller (**OrderDetails.cs**) in your project to handle CRUD operations for the Grid: 

{% tabs %}
{% highlight cs tabtitle="OrderDetails.cs" %}

namespace SignalRDataGrid.Data
{
    public class OrderDetails
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipName { get; set; }

        public static List<OrderDetails> OrderList = new List<OrderDetails>();

        private static readonly string[] CustomerIDs = new[]
        {
        "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD", "CHOPS", "RICSU", "WELLI", "HILAA", "ERNSH", "CENTC", "OTTIK", "QUEDE", "RATTC"
        };

        private static readonly string[] ShipNames = new[]
        {
        "Vins et alcools Chevalier", "Toms Spezialitäten", "Hanari Carnes", "Victuailles en stock", "Suprêmes délices",
        "Chop-suey Chinese", "Richter Supermarkt", "Wellington Importadora", "HILARION-Abastos", "Ernst Handel",
        "Centro comercial Moctezuma", "Ottilies Käseladen", "Que Delícia", "Rattlesnake Canyon Grocery"
        };

        public static Task<List<OrderDetails>> GetOrdersAsync()
        {
            var rng = new Random();
            if (OrderList.Count == 0)
            {
                OrderList = Enumerable.Range(10248, 75).Select(index => new OrderDetails
                {
                    OrderID = index,
                    CustomerID = CustomerIDs[rng.Next(CustomerIDs.Length)],
                    ShipName = ShipNames[rng.Next(ShipNames.Length)]
                }).ToList();
            }

            return Task.FromResult(OrderList);
        }

        public Task<OrderDetails> UpdateAsync(OrderDetails model)
        {
            var ord = OrderList.Where(x => x.OrderID == model.OrderID).FirstOrDefault();
            ord.CustomerID = model.CustomerID;
            ord.ShipName = model.ShipName;
            return Task.FromResult(model);
        }

        public List<OrderDetails> DeleteAsync(OrderDetails model)
        {
            var ord = OrderList.Remove(model);

            return OrderList;
        }
    }
}

{% endhighlight %}
{% endtabs %}

**Step 5:** In your **Home.razor** file, establish a connection to the SignalR hub and configure the grid data.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Grids
@using Microsoft.AspNetCore.SignalR.Client
@inject NavigationManager NavigationManager
@using SignalRDataGrid.Data
@inject OrderDetails OrderService
@implements IAsyncDisposable

<SfGrid @ref="Grid" DataSource="@OrderData" AllowSorting="true" AllowFiltering="true" EnablePersistence="true" ID="GridDemo" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })">
    <GridEvents OnActionComplete="ActionComplete" TValue="OrderDetails"></GridEvents>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText=" Ship Name" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    SfGrid<OrderDetails> Grid { get; set; }
    private HubConnection hubConnection;
    public List<OrderDetails> OrderData = new List<OrderDetails>();
    protected override async Task OnInitializedAsync()
    {
        hubConnection = new HubConnectionBuilder()
        .WithUrl(NavigationManager.ToAbsoluteUri("/chathub"))
        .Build();
        hubConnection.On("ReceiveMessage", () =>
        {
            CallLoadData();
        });
        await hubConnection.StartAsync();
        await LoadData();
    }
    public async Task ActionComplete(ActionEventArgs<OrderDetails> Args)
    {
        if (Args.RequestType == Syncfusion.Blazor.Grids.Action.Save)
        {
            await OrderService.UpdateAsync(Args.Data);
            if (IsConnected) await Send();
        }
        if (Args.RequestType == Syncfusion.Blazor.Grids.Action.Delete)
        {
            OrderData = OrderService.DeleteAsync(Args.Data);
            if (IsConnected) await Send();
        }
    }
    private void CallLoadData()
    {
        Grid.Refresh();
    }
    protected async Task LoadData()
    {
        OrderData = await OrderDetails.GetOrdersAsync();
    }
    async Task Send() =>
        await hubConnection.SendAsync("SendMessage");

        public bool IsConnected => hubConnection.State == HubConnectionState.Connected;

        public async ValueTask DisposeAsync()
        {
            if (hubConnection is not null)
            {
                await hubConnection.DisposeAsync();
            }
        }
}

{% endhighlight %}
{% endtabs %}

This code demonstrates how to connect to a SignalR hub and refresh the Grid data in real time when updates are received.

**Step 6:** Adding the `OrderService` reference:

To include the `OrderService` reference, update the following line in your `Program.cs` file:

```csharp
builder.Services.AddSingleton<OrderDetails>();
```

The following screenshot illustrates the addition, editing, and deletion operations performed, with changes reflected across all client sides.

![SignalR Data](./images/signalR.gif)
