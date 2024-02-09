---
layout: post
title: Custom Binding in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Custom Binding in Syncfusion Blazor DataGrid component and much more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Custom Binding in Blazor DataGrid Component

The [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) has custom adaptor support which allows you to perform manual operations on the data. This can be utilized for implementing custom data binding and editing operations in the DataGrid component.

For implementing custom data binding in DataGrid, the **DataAdaptor** class is used. This abstract class acts as a base class for the custom adaptor.

The **DataAdaptor** abstract class has both synchronous and asynchronous method signatures which can be overridden in the custom adaptor. Following are the method signatures present in this class,

```csharp
public abstract class DataAdaptor
{
    /// <summary>
    /// Performs data Read operation synchronously.
    /// </summary>
    public virtual object Read(DataManagerRequest dataManagerRequest, string key = null)

    /// <summary>
    /// Performs data Read operation asynchronously.
    /// </summary>
    public virtual Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)

    /// <summary>
    /// Performs Insert operation synchronously.
    /// </summary>
    public virtual object Insert(DataManager dataManager, object data, string key)
    /// <summary>
    /// Performs Insert operation asynchronously.
    /// </summary>
    public virtual Task<object> InsertAsync(DataManager dataManager, object data, string key)

    /// <summary>
    /// Performs Remove operation synchronously.
    /// </summary>
    public virtual object Remove(DataManager dataManager, object data, string keyField, string key)

    /// <summary>
    /// Performs Remove operation asynchronously.
    /// </summary>
    public virtual Task<object> RemoveAsync(DataManager dataManager, object data, string keyField, string key)

    /// <summary>
    /// Performs Update operation synchronously.
    /// </summary>
    public virtual object Update (DataManager dataManager, object data, string keyField, string key)

    /// <summary>
    /// Performs Update operation asynchronously.
    /// </summary>
    public virtual Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)

    /// <summary>
    /// Performs Batch CRUD operations synchronously.
    /// </summary>
    public virtual object BatchUpdate(DataManager dataManager, object changedRecords, object addedRecords, object deletedRecords, string keyField, string key, int? dropIndex)

    /// <summary>
    /// Performs Batch CRUD operations asynchronously.
    /// </summary>
    public virtual Task<object> BatchUpdateAsync(DataManager dataManager, object changedRecords, object addedRecords, object deletedRecords, string keyField, string key, int? dropIndex)
}
```

## Data binding

The custom data binding can be performed in the DataGrid component by providing the custom adaptor class and overriding the **Read** or **ReadAsync** method of the **DataAdaptor** abstract class.

The following sample code demonstrates implementing custom data binding using custom adaptor,

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" ID="Grid" AllowSorting="true" AllowFiltering="true" AllowPaging="true">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" Width="140"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public static List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
        }).ToList();
    }

    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
    }

    // Implementing custom adaptor by extending the DataAdaptor class
    public class CustomAdaptor : DataAdaptor
    {
        // Performs data Read operation
        public override object Read(DataManagerRequest dm, string key = null)
        {
            IEnumerable<Order> DataSource = Orders;
            if (dm.Search != null && dm.Search.Count > 0)
            {
                // Searching
                DataSource = DataOperations.PerformSearching(DataSource, dm.Search);
            }
            if (dm.Sorted != null && dm.Sorted.Count > 0)
            {
                // Sorting
                DataSource = DataOperations.PerformSorting(DataSource, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0)
            {
                // Filtering
                DataSource = DataOperations.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
            }
            int count = DataSource.Cast<Order>().Count();
            if (dm.Skip != 0)
            {
                //Paging
                DataSource = DataOperations.PerformSkip(DataSource, dm.Skip);
            }
            if (dm.Take != 0)
            {
                DataSource = DataOperations.PerformTake(DataSource, dm.Take);
            }
            DataResult DataObject = new DataResult();
            if (dm.Aggregates != null) // Aggregation
            {
                DataObject.Result = DataSource;
                DataObject.Count = count;
                DataObject.Aggregates = DataUtil.PerformAggregation(DataSource, dm.Aggregates);

                return dm.RequiresCounts ? DataObject : (object)DataSource;
            }
            return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
        }
    }
}
```

N> If the **DataManagerRequest.RequiresCounts** value is **true**, then the Read/ReadAsync return value must be of **DataResult** with properties **Result** whose value is a collection of records and **Count** whose value is the total number of records. If the **DataManagerRequest.RequiresCounts** is **false**, then simply send the collection of records.

The following image shows the custom bound data displayed in the DataGrid component,

![Custom Binding in Blazor DataGrid](./images/blazor-datagrid-custom-binding.png)

N> If the Read/ReadAsync method is not overridden in the custom adaptor, then it will be handled by the default read handler.

## Inject service into Custom Adaptor

If you want to inject some of your service into Custom Adaptor and use the service, then you can achieve your requirement by using below way.

Initially, you need to add CustomAdaptor class as AddScoped in `Program.cs` file.

```csharp

builder.Services.AddSingleton<OrderDataAccessLayer>();
builder.Services.AddScoped<CustomAdaptor>();
builder.Services.AddScoped<ServiceClass>();

```

The following sample code demonstrates injecting service into Custom Adaptor,

```cshtml
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor

<SfGrid TValue="Order" ID="Grid" AllowSorting="true" AllowFiltering="true" AllowPaging="true">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" Width="140"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{

    public class CustomAdaptor : DataAdaptor
    {
        //Here, you can inject your service
        public OrderDataAccessLayer context { get; set; };
        public CustomAdaptor(OrderDataAccessLayer _context)
        {
            context = _context;
        }
        // Performs data Read operation
        public override object Read(DataManagerRequest dm, string key = null)
        {
            IEnumerable<Order> DataSource = context.GetAllOrders();
            if (dm.Search != null && dm.Search.Count > 0)
            {
                // Searching
                DataSource = DataOperations.PerformSearching(DataSource, dm.Search);
            }
            if (dm.Sorted != null && dm.Sorted.Count > 0)
            {
                // Sorting
                DataSource = DataOperations.PerformSorting(DataSource, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0)
            {
                // Filtering
                DataSource = DataOperations.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
            }
            int count = DataSource.Cast<Order>().Count();
            if (dm.Skip != 0)
            {
                //Paging
                DataSource = DataOperations.PerformSkip(DataSource, dm.Skip);
            }
            if (dm.Take != 0)
            {
                DataSource = DataOperations.PerformTake(DataSource, dm.Take);
            }
            return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
        }
    }
}
```

## Custom adaptor as Component

Custom Adaptor can be created as a component when `DataAdaptor` is extended from `OwningComponentBase`. You can create Custom Adaptor from any of the two versions of the class, `DataAdaptor` and `DataAdaptor<T>`.

Ensure to register your service in **Program.cs** file.

```csharp
builder.Services.AddScoped<Order>();
```

The following sample code demonstrates creating Custom Adaptor as a component,

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" ID="Grid" AllowSorting="true" AllowFiltering="true" AllowPaging="true">
    <SfDataManager Adaptor="Adaptors.CustomAdaptor">
        <CustomAdaptorComponent></CustomAdaptorComponent>
    </SfDataManager>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" Width="140"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" TextAlign="@TextAlign.Center" Width="140"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public static List<Order> Orders { get; set; }
    public class Order
    {
        public List<Order> GetAllRecords()
        {
            Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
                Freight = 2.1 * x,
            }).ToList();
            return Orders;
        }
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
    }
}
```

The following sample code demonstrates `DataAdaptor` extended from `OwningComponentBase<T>`. This provides a single service of type T. You can access this service by using the `Service` property.

```csharp
[CustomAdaptorComponent.razor]

@using Syncfusion.Blazor;
@using Syncfusion.Blazor.Data;
@using Newtonsoft.Json
@using static BlazorApp1.Pages.Index;

@inherits DataAdaptor<Order>

<CascadingValue Value="@this">
    @ChildContent
</CascadingValue>

@code {
    [Parameter]
    [JsonIgnore]
    public RenderFragment ChildContent { get; set; }

    // Performs data Read operation
    public override object Read(DataManagerRequest dm, string key = null)
    {
        IEnumerable<Order> DataSource = (IEnumerable<Order>)Service.GetAllRecords();
        if (dm.Search != null && dm.Search.Count > 0)
        {
            // Searching
            DataSource = DataOperations.PerformSearching(DataSource, dm.Search);
        }
        if (dm.Sorted != null && dm.Sorted.Count > 0)
        {
            // Sorting
            DataSource = DataOperations.PerformSorting(DataSource, dm.Sorted);
        }
        if (dm.Where != null && dm.Where.Count > 0)
        {
            // Filtering
            DataSource = DataOperations.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
        }
        int count = DataSource.Cast<Order>().Count();
        if (dm.Skip != 0)
        {
            //Paging
            DataSource = DataOperations.PerformSkip(DataSource, dm.Skip);
        }
        if (dm.Take != 0)
        {
            DataSource = DataOperations.PerformTake(DataSource, dm.Take);
        }
        return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
    }
}
```

The following sample code demonstrates `DataAdaptor` extended from `OwningComponentBase`. This provides the possibility to request multiple services.

```csharp
[CustomAdaptorComponent.razor]

@using Syncfusion.Blazor;
@using Syncfusion.Blazor.Data;
@using static BlazorApp1.Pages.Index
@using Newtonsoft.Json

@inherits DataAdaptor

<CascadingValue Value="@this">
    @ChildContent
</CascadingValue>

@code {
    [Parameter]
    [JsonIgnore]
    public RenderFragment ChildContent { get; set; }
    Order orderdata;
    public override object Read(DataManagerRequest dm, string key = null)
    {
        orderdata = (Order)ScopedServices.GetService(typeof(Order));
        IEnumerable<Order> DataSource = (IEnumerable<Order>)orderdata.GetAllRecords().Take(10);
        if (dm.Search != null && dm.Search.Count > 0)
        {
            // Searching
            DataSource = DataOperations.PerformSearching(DataSource, dm.Search);
        }
        if (dm.Sorted != null && dm.Sorted.Count > 0)
        {
            // Sorting
            DataSource = DataOperations.PerformSorting(DataSource, dm.Sorted);
        }
        if (dm.Where != null && dm.Where.Count > 0)
        {
            // Filtering
            DataSource = DataOperations.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
        }
        int count = DataSource.Cast<Order>().Count();
        if (dm.Skip != 0)
        {
            //Paging
            DataSource = DataOperations.PerformSkip(DataSource, dm.Skip);
        }
        if (dm.Take != 0)
        {
            DataSource = DataOperations.PerformTake(DataSource, dm.Take);
        }
        return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
    }
}
```

## Handling Editing in Custom Adaptor

The CRUD operations for the custom bound data in the DataGrid component can be implemented by overriding the following CRUD methods of the **DataAdaptor** abstract class,

* **Insert/InsertAsync**
* **Remove/RemoveAsync**
* **Update/UpdateAsync**
* **BatchUpdate/BatchUpdateAsync**

N> While using batch editing in DataGrid, use BatchUpdate/BatchUpdateAsync method to handle the corresponding CRUD operation.

The following sample code demonstrates implementing CRUD operations for the custom bound data,

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" ID="Grid" AllowSorting="true" AllowFiltering="true" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Delete", "Update", "Cancel" })">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="@EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" Width="140"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public static List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
        }).ToList();
    }

    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
    }

    // Implementing custom adaptor by extending the DataAdaptor class
    public class CustomAdaptor : DataAdaptor
    {
        // Performs data Read operation
        public override object Read(DataManagerRequest dm, string key = null)
        {
            IEnumerable<Order> DataSource = Orders;
            if (dm.Search != null && dm.Search.Count > 0)
            {
                // Searching
                DataSource = DataOperations.PerformSearching(DataSource, dm.Search);
            }
            if (dm.Sorted != null && dm.Sorted.Count > 0)
            {
                // Sorting
                DataSource = DataOperations.PerformSorting(DataSource, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0)
            {
                // Filtering
                DataSource = DataOperations.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
            }
            int count = DataSource.Cast<Order>().Count();
            if (dm.Skip != 0)
            {
                //Paging
                DataSource = DataOperations.PerformSkip(DataSource, dm.Skip);
            }
            if (dm.Take != 0)
            {
                DataSource = DataOperations.PerformTake(DataSource, dm.Take);
            }
            return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
        }

        // Performs Insert operation
        public override object Insert(DataManager dm, object value, string key)
        {
            Orders.Insert(0, value as Order);
            return value;
        }

        // Performs Remove operation
        public override object Remove(DataManager dm, object value, string keyField, string key)
        {
            Orders.Remove(Orders.Where(or => or.OrderID == int.Parse(value.ToString())).FirstOrDefault());
            return value;
        }

        // Performs Update operation
        public override object Update(DataManager dm, object value, string keyField, string key)
        {
            var data = Orders.Where(or => or.OrderID == (value as Order).OrderID).FirstOrDefault();
            if (data != null)
            {
                data.OrderID = (value as Order).OrderID;
                data.CustomerID = (value as Order).CustomerID;
                data.Freight = (value as Order).Freight;
            }
            return value;
        }

        // Performs BatchUpdate operation
        public override object BatchUpdate(DataManager dm, object Changed, object Added, object Deleted, string KeyField, string Key, int? dropIndex)
        {
            if (Changed != null)
            {
                foreach (var rec in (IEnumerable<Order>)Changed)
                {
                    Order val = Orders.Where(or => or.OrderID == rec.OrderID).FirstOrDefault();
                    val.OrderID = rec.OrderID;
                    val.CustomerID = rec.CustomerID;
                    val.Freight = rec.Freight;
                }

            }
            if (Added != null)
            {
                foreach (var rec in (IEnumerable<Order>)Added)
                {
                    Orders.Add(rec);
                }

            }
            if (Deleted != null)
            {
                foreach (var rec in (IEnumerable<Order>)Deleted)
                {
                    Orders.Remove(Orders.Where(or => or.OrderID == rec.OrderID).FirstOrDefault());
                }

            }
            return Orders;
        }
    }
}
```

The following GIF displays the CRUD operations performed on the custom bound data displayed in the DataGrid component,

![Editing Custom Data in Blazor DataGrid](./images/blazor-datagrid-editing-custom-data.gif)

N> You can refer to the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap5) to understand how to present and manipulate data.

## Handling Aggregates in Custom Adaptor

When using Custom Adaptor, the aggregates must be handled in the Read/ReadAsync method of Custom adaptor.

The following sample code demonstrates implementing the aggregates for the custom bound data,

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor

<SfGrid TValue="Order" AllowPaging="true">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(Order.Freight) Type="AggregateType.Sum" Format="C2">
                    <FooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Sum: @aggregate.Sum</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(Order.Freight) Type="AggregateType.Average" Format="C2">
                    <FooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Average: @aggregate.Average</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public static List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
    public class CustomAdaptor : DataAdaptor
    {
        // Performs data Read operation
        public override object Read(DataManagerRequest dm, string key = null)
        {
            IEnumerable<Order> DataSource = Orders;
            int count = DataSource.Cast<Order>().Count();
            if (dm.Skip != 0)
            {
                //Paging
                DataSource = DataOperations.PerformSkip(DataSource, dm.Skip);
            }
            if (dm.Take != 0)
            {
                DataSource = DataOperations.PerformTake(DataSource, dm.Take);
            }
            DataResult DataObject = new DataResult();
            if (dm.Aggregates != null) // Aggregation
            {
                DataObject.Result = DataSource;
                DataObject.Count = count;
                DataObject.Aggregates = DataUtil.PerformAggregation(DataSource, dm.Aggregates);

                return dm.RequiresCounts ? DataObject : (object)DataSource;
            }
            return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
        }
    }
}
```

## Handling Grouping in Custom Adaptor

When using Custom Adaptor, the grouping operation has to be handled in the Read/ReadAsync method of Custom adaptor.

The following sample code demonstrates implementing the grouping operation for the custom bounded data,

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using System.Collections

<SfGrid TValue="Order" ID="Grid" AllowPaging="true" AllowGrouping="true">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" Width="140"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public static List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
        }).ToList();
    }

    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
    }

    // Implementing custom adaptor by extending the DataAdaptor class
    public class CustomAdaptor : DataAdaptor
    {
        // Performs data Read operation
        public override object Read(DataManagerRequest dm, string key = null)
        {
            IEnumerable<Order> DataSource = Orders;
            int count = DataSource.Cast<Order>().Count();
            if (dm.Skip != 0)
            {
                //Paging
                DataSource = DataOperations.PerformSkip(DataSource, dm.Skip);
            }
            if (dm.Take != 0)
            {
                DataSource = DataOperations.PerformTake(DataSource, dm.Take);
            }
            DataResult DataObject = new DataResult();
            if (dm.Group != null)
            {
                IEnumerable ResultData = DataSource.ToList();
                // Grouping
                foreach (var group in dm.Group)
                {
                    ResultData = DataUtil.Group<Order>(ResultData, group, dm.Aggregates, 0, dm.GroupByFormatter);
                }
                DataObject.Result = ResultData;
                DataObject.Count = count;
                return dm.RequiresCounts ? DataObject : (object)ResultData;
            }
            return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
        }
    }
}
```

## Handling Filtering in Custom Adaptor

When using a custom adaptor, the filtering operation has to be handled by overriding the Read/ReadAsync method of the DataAdaptor abstract class. In the DataManagerRequest class, you can get the grid action details as shown in the below image.

![Handling Filtering in Custom Adaptor](./images/blazor-datagrid-filtering-in-custom-adaptor.png)

Based on these grid action details, a custom data source can be filtered using the built-in `PerformFiltering` method of the `DataOperations` class.

N> Also, you can use your own method to do the filtering operation and bind the resultant data to the grid.

The following sample code demonstrates implementing the filtering operation for the custom bounded data,

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using System.Collections

<SfGrid TValue="Order" ID="Grid" AllowFiltering="true" AllowPaging="true">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" Width="140"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public static List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
        }).ToList();
    }

    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
    }

    // Implementing custom adaptor by extending the DataAdaptor class
    public class CustomAdaptor : DataAdaptor
    {
        // Performs data Read operation
        public override object Read(DataManagerRequest dm, string key = null)
        {
            IEnumerable<Order> DataSource = Orders;
            if (dm.Where != null && dm.Where.Count > 0)
            {
                // Filtering
                DataSource = DataOperations.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
            }
            int count = DataSource.Cast<Order>().Count();
            if (dm.Skip != 0)
            {
                //Paging
                DataSource = DataOperations.PerformSkip(DataSource, dm.Skip);
            }
            if (dm.Take != 0)
            {
                DataSource = DataOperations.PerformTake(DataSource, dm.Take);
            }
            return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
        }
    }
}

```


N> [View Sample in GitHub.](https://github.com/SyncfusionExamples/blazor-datagrid-filtering-with-custom-adaptor)

## Handling Sorting in Custom Adaptor

When using a custom adaptor, the sorting operation has to be handled by overriding the Read/ReadAsync method of the DataAdaptor abstract class. In the DataManagerRequest class, you can get the grid action details as shown in the below image.

![Handling Sorting in Custom Adaptor](./images/blazor-datagrid-sorting-in-custom-adaptor.png)

Based on these grid action details, a custom data source can be sorted using the built-in `PerformSorting` method of the `DataOperations` class.

N> Also, you can use your own method to do the sorting operation and bind the resultant data to the grid.

The following sample code demonstrates implementing the sorting operation for the custom bounded data,

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using System.Collections

<SfGrid TValue="Order" ID="Grid" AllowSorting="true" AllowPaging="true">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" Width="140"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public static List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
        }).ToList();
    }

    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
    }

    // Implementing custom adaptor by extending the DataAdaptor class
    public class CustomAdaptor : DataAdaptor
    {
        // Performs data Read operation
        public override object Read(DataManagerRequest dm, string key = null)
        {
            IEnumerable<Order> DataSource = Orders;
            if (dm.Sorted != null && dm.Sorted.Count > 0)
            {
                // Sorting
                DataSource = DataOperations.PerformSorting(DataSource, dm.Sorted);
            }
            int count = DataSource.Cast<Order>().Count();
            if (dm.Skip != 0)
            {
                //Paging
                DataSource = DataOperations.PerformSkip(DataSource, dm.Skip);
            }
            if (dm.Take != 0)
            {
                DataSource = DataOperations.PerformTake(DataSource, dm.Take);
            }
            return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
        }
    }
}
```

N> [View Sample in GitHub.](https://github.com/SyncfusionExamples/blazor-datagrid-sorting-with-custom-adaptor)

## How to pass additional parameters to custom adaptor

To send an additional parameter to the data request, use the AddParams method of Query class. Assign the Query object with additional parameters to the DataGrid’s Query property.

The following sample code demonstrates sending additional parameters to the custom adaptor using the [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Query) property of Grid.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" ID="Grid" AllowSorting="true" AllowFiltering="true" AllowPaging="true" Query="@Query">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" Width="140"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public static List<Order> Orders { get; set; }
    public Query Query = new Query().AddParams("Code", 10);

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
        }).ToList();
    }

    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
    }

    // Implementing custom adaptor by extending the DataAdaptor class
    public class CustomAdaptor : DataAdaptor
    {
        // Performs data Read operation
        public override object Read(DataManagerRequest dm, string key = null)
        {
            IEnumerable<Order> DataSource = Orders;
            if (dm.Params != null && dm.Params.Count > 0)
            {
                var val = dm.Params;
            }
            if (dm.Search != null && dm.Search.Count > 0)
            {
                // Searching
                DataSource = DataOperations.PerformSearching(DataSource, dm.Search);
            }
            if (dm.Sorted != null && dm.Sorted.Count > 0)
            {
                // Sorting
                DataSource = DataOperations.PerformSorting(DataSource, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0)
            {
                // Filtering
                DataSource = DataOperations.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
            }
            int count = DataSource.Cast<Order>().Count();
            if (dm.Skip != 0)
            {
                //Paging
                DataSource = DataOperations.PerformSkip(DataSource, dm.Skip);
            }
            if (dm.Take != 0)
            {
                DataSource = DataOperations.PerformTake(DataSource, dm.Take);
            }
            DataResult DataObject = new DataResult();
            if (dm.Aggregates != null) // Aggregation
            {
                DataObject.Result = DataSource;
                DataObject.Count = count;
                DataObject.Aggregates = DataUtil.PerformAggregation(DataSource, dm.Aggregates);
                return dm.RequiresCounts ? DataObject : (object)DataSource;
            }
            return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
        }
    }
}

```

![Passing Additional Parameters to Custom Adaptor in Blazor DataGrid](./images/blazor-datagrid-passing-additional-parameter-to-custom-adaptor.gif)

## DataTable binding

DataTable represents a table with data rows and columns. Data binding of the DataTable can be achieved in the DataGrid component by providing the **CustomAdaptor** class and overriding the `Read` or `ReadAsync` method of the `DataAdaptor` abstract class.

To bind DataTable to the datagrid, you can assign `TValue` to the **ExpandoObject**. 

Refer to the following code example for how to bind the DataTable using custom adaptor.

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using System.Dynamic;
@using System.Data;

<SfGrid TValue="ExpandoObject" ID="Grid" AllowSorting="true" AllowPaging="true" AllowFiltering="true" Toolbar="@(new List<string>() { "Search" })">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true, Number=true})" Width="120"></GridColumn>
        <GridColumn Field="CustomerID" HeaderText="Customer Name" ValidationRules="@(new ValidationRules { Required=true})" Width="150"></GridColumn>
        <GridColumn Field="OrderDate" HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="130"></GridColumn>
        <GridColumn Field="EmployeeID" HeaderText="Employee ID" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public static DataTable dataTable { get; set; }
    public static IQueryable DataSource;

    protected override void OnInitialized()
    {
        dataTable = GetData();
        DataSource = ToQueryableCollection(dataTable);      // Convert DataTable to IQueryable ExpandoObject list
    }

    // Implementing custom adaptor by extending the DataAdaptor class
    public class CustomAdaptor : DataAdaptor
    {
        // Performs data Read operation
        public override object Read(DataManagerRequest dm, string key = null)
        {
            // Performs Searching, Sorting, Filtering
            DataSource = PerformDataOperation(dataTable, dm);

            int count = DataSource.Cast<ExpandoObject>().Count();
            if (dm.Skip != 0)
            {
                //Paging
                DataSource = QueryableOperation.PerformSkip<object>((IQueryable<object>)DataSource, dm.Skip);
            }
            if (dm.Take != 0)
            {
                DataSource = QueryableOperation.PerformTake<object>((IQueryable<object>)DataSource, dm.Take);
            }

            return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
        }
    }

    // Performs data operations like Searching, Sorting, and Filtering
    public static IQueryable PerformDataOperation(DataTable dt, DataManagerRequest dm)
    {
        // Convert DataTable to IQueryable collection of datasource
        DataSource = ToQueryableCollection(dt);
        if (dm.Search != null && dm.Search.Count > 0)
        {
            // Searching
            DataSource = DynamicObjectOperation.PerformSearching(DataSource, dm.Search);
        }
        if (dm.Where != null && dm.Where.Count > 0)
        {
            // Filtering
            DataSource = DynamicObjectOperation.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
        }
        if (dm.Sorted != null && dm.Sorted.Count > 0)
        {
            // Sorting
            DataSource = DynamicObjectOperation.PerformSorting(DataSource, dm.Sorted);
        }
        return DataSource;
    }

    // This method converts the DataTable data source into an IQueryable collection data source.
    public static IQueryable ToQueryableCollection(DataTable dt)
    {
        List<ExpandoObject> expandoList = new List<ExpandoObject>();
        foreach (DataRow row in dt.Rows)
        {
            var expandoDict = new ExpandoObject() as IDictionary<String, Object>;
            foreach (DataColumn col in dt.Columns)
            {
                var colValue = row[col.ColumnName];
                colValue = (colValue == DBNull.Value) ? null : colValue;
                expandoDict.Add(col.ToString(), colValue);
            }
            expandoList.Add((ExpandoObject)expandoDict);
        }
        return expandoList.AsQueryable();
    }

    public DataTable GetData()
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[4] { new DataColumn("OrderID", typeof(long)),
                                                new DataColumn("CustomerID", typeof(string)),
                                                new DataColumn("EmployeeID",typeof(int)),
                                                new DataColumn("OrderDate",typeof(DateTime))
    });

        int code = 1000;
        int id = 0;
        for (int i = 1; i <= 15; i++)
        {
            dt.Rows.Add(code + 1, "ALFKI", id + 1, new DateTime(1991, 05, 15));
            dt.Rows.Add(code + 2, "ANATR", id + 2, new DateTime(1990, 04, 04));
            dt.Rows.Add(code + 3, "ANTON", id + 3, new DateTime(1957, 11, 30));
            dt.Rows.Add(code + 4, "BLONP", id + 4, new DateTime(1930, 10, 22));
            dt.Rows.Add(code + 5, "BOLID", id + 5, new DateTime(1953, 02, 18));
            code += 5;
            id += 5;
        }
        return dt;
    }
}
```
In the above example, DataTable is passed to the `ToQueryableCollection` method, which converts the DataTable datasource into an **IQueryable** collection datasource.

You can perform data operations like **searching**, **sorting** and **filtering** using the `PerformDataOperation` method. This method takes a DataTable and a DataManagerRequest object as parameters, processes the data operations, and then returns an IQueryable data source.

Refer to the following code example for how to implement **grouping** and **aggregates** in a DataTable using a custom adaptor.

```cshtml
    // Implementing custom adaptor by extending the DataAdaptor class
    public class CustomAdaptor : DataAdaptor
    {
        // Performs data Read operation
        public override object Read(DataManagerRequest dm, string key = null)
        {
            // Convert DataTable to IQueryable ExpandoObject list
            DataSource = ToQueryableCollection(dataTable);

            int count = DataSource.Cast<ExpandoObject>().Count();
            if (dm.Skip != 0)
            {
                //Paging
                DataSource = QueryableOperation.PerformSkip<object>((IQueryable<object>)DataSource, dm.Skip);
            }
            if (dm.Take != 0)
            {
                DataSource = QueryableOperation.PerformTake<object>((IQueryable<object>)DataSource, dm.Take);
            }

            // Aggregation
            IDictionary<string, object> aggregates = new Dictionary<string, object>();
            if (dm.Aggregates != null)
            {
                aggregates = DataUtil.PerformAggregation(DataSource, dm.Aggregates);
            }

            // Grouping
            DataResult DataObject = new DataResult();
            if (dm.Group != null)
            {
                IEnumerable result = (IEnumerable)DataSource;
                foreach (var group in dm.Group)
                {
                    result = DataUtil.Group<ExpandoObject>(result, group, dm.Aggregates, 0, dm.GroupByFormatter);
                }
                return dm.RequiresCounts ? new DataResult() { Result = result, Count = count, Aggregates = aggregates } : (object)DataSource;
            }
            return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count, Aggregates = aggregates } : (object)DataSource;
        }
    }
```
### DataTable with CRUD operations

To perform CRUD operations for a DataTable, can be implemented by overriding the CRUD methods of the **DataAdaptor** abstract class.

* **Insert/InsertAsync**
* **Remove/RemoveAsync**
* **Update/UpdateAsync**
* **BatchUpdate/BatchUpdateAsync**

While using batch editing in DataGrid, use the BatchUpdate/BatchUpdateAsync method to handle the corresponding CRUD operations.

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using System.Dynamic;
@using System.Data;

<SfGrid TValue="ExpandoObject" ID="Grid" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Delete", "Update", "Cancel" })">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="@EditMode.Normal"></GridEditSettings>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true, Number=true})" Width="120"></GridColumn>
        <GridColumn Field="CustomerID" HeaderText="Customer Name" ValidationRules="@(new ValidationRules { Required=true})" Width="150"></GridColumn>
        <GridColumn Field="OrderDate" HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="130"></GridColumn>
        <GridColumn Field="EmployeeID" HeaderText="Employee ID" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public static DataTable dataTable { get; set; }
    public static IQueryable DataSource;

    protected override void OnInitialized()
    {
        dataTable = GetData();
        DataSource = ToQueryableCollection(dataTable);         // Convert DataTable to IQueryable ExpandoObject list
    }

    // Implementing custom adaptor by extending the DataAdaptor class
    public class CustomAdaptor : DataAdaptor
    {
        // Performs data Read operation
        public override object Read(DataManagerRequest dm, string key = null)
        {
            // Performs Searching, Sorting, Filtering
            DataSource = PerformDataOperation(dataTable, dm);
            int count = DataSource.Cast<ExpandoObject>().Count();
            if (dm.Skip != 0)
            {
                //Paging
                DataSource = QueryableOperation.PerformSkip<object>((IQueryable<object>)DataSource, dm.Skip);
            }
            if (dm.Take != 0)
            {
                DataSource = QueryableOperation.PerformTake<object>((IQueryable<object>)DataSource, dm.Take);
            }

            return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
        }

        //Performs Insert operation
        public override object Insert(DataManager dm, object value, string key)
        {
            DataRow newRow = dataTable.NewRow();
            var data = (ExpandoObject)value;
            foreach (var item in data)
            {
                newRow[item.Key] = item.Value ?? DBNull.Value;
            }
            dataTable.Rows.InsertAt(newRow, 0);

            return value;
        }

        //Performs Remove operation
        public override object Remove(DataManager dm, object value, string keyField, string key)
        {
            DataRow? rowToRemove = null;

            foreach (DataRow row in dataTable.Rows)
            {
                if (row[keyField].Equals(value))
                {
                    rowToRemove = row;
                    break;
                }
            }

            if (rowToRemove != null)
            {
                dataTable.Rows.Remove(rowToRemove);
            }
            return value;
        }

        // Performs Update operation
        public override object Update(DataManager dm, object value, string keyField, string key)
        {
            var data = (IDictionary<string, object>)value;
            var rowToUpdate = dataTable.Rows
                .Cast<DataRow>()
                .FirstOrDefault(row => row[keyField].Equals(data[keyField]));

            if (rowToUpdate != null)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    var columnName = column.ColumnName;
                    var newValue = data[column.ColumnName] ?? column.DefaultValue;
                    rowToUpdate[columnName] = newValue;
                }
            }
            return value;
        }

        // Performs BatchUpdate operation
        public override object BatchUpdate(DataManager dm, object Changed, object Added, object Deleted, string KeyField, string Key, int? dropIndex)
        {
            if (Changed != null)
            {
                var changedRecords = (IEnumerable<IDictionary<string, object>>)Changed;
                foreach (var record in changedRecords)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row[KeyField].Equals(record[KeyField]))
                        {
                            foreach (DataColumn column in dataTable.Columns)
                            {
                                row[column.ColumnName] = record[column.ColumnName] ?? column.DefaultValue;
                            }
                        }
                    }
                }
            }

            if (Added != null)
            {
                var addedRecords = (IEnumerable<IDictionary<string, object>>)Added;

                foreach (var record in addedRecords)
                {
                    DataRow newRow = dataTable.NewRow();
                    foreach (var item in record)
                    {
                        newRow[item.Key] = item.Value ?? DBNull.Value;
                    }
                    dataTable.Rows.Add(newRow);
                }
            }

            if (Deleted != null)
            {
                var deletedRecords = (IEnumerable<IDictionary<string, object>>)Deleted;
                List<DataRow> rowsToRemove = new List<DataRow>();
                foreach (var record in deletedRecords)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row[KeyField].Equals(record[KeyField]))
                        {
                            rowsToRemove.Add(row);
                        }
                    }
                }
                foreach (DataRow rowToRemove in rowsToRemove)
                {
                    dataTable.Rows.Remove(rowToRemove);
                }
            }
            return dataTable;
        }
    }

    // Performs data operations like Searching, Sorting, and Filtering
    public static IQueryable PerformDataOperation(DataTable dt, DataManagerRequest dm)
    {
        // Convert DataTable to IQueryable collection of datasource
        DataSource = ToQueryableCollection(dt);
        if (dm.Search != null && dm.Search.Count > 0)
        {
            // Searching
            DataSource = DynamicObjectOperation.PerformSearching(DataSource, dm.Search);
        }
        if (dm.Where != null && dm.Where.Count > 0)
        {
            // Filtering
            DataSource = DynamicObjectOperation.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
        }
        if (dm.Sorted != null && dm.Sorted.Count > 0)
        {
            // Sorting
            DataSource = DynamicObjectOperation.PerformSorting(DataSource, dm.Sorted);
        }
        return DataSource;
    }

    // This method converts the DataTable data source into an IQueryable collection data source.
    public static IQueryable ToQueryableCollection(DataTable dt)
    {
        List<ExpandoObject> expandoList = new List<ExpandoObject>();
        foreach (DataRow row in dt.Rows)
        {
            var expandoDict = new ExpandoObject() as IDictionary<String, Object>;
            foreach (DataColumn col in dt.Columns)
            {
                var colValue = row[col.ColumnName];
                colValue = (colValue == DBNull.Value) ? null : colValue;
                expandoDict.Add(col.ToString(), colValue);
            }
            expandoList.Add((ExpandoObject)expandoDict);
        }
        return expandoList.AsQueryable();
    }

    public DataTable GetData()
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[4] { new DataColumn("OrderID", typeof(long)),
                                                new DataColumn("CustomerID", typeof(string)),
                                                new DataColumn("EmployeeID",typeof(int)),
                                                new DataColumn("OrderDate",typeof(DateTime))
    });

        int code = 1000;
        int id = 0;
        for (int i = 1; i <= 15; i++)
        {
            dt.Rows.Add(code + 1, "ALFKI", id + 1, new DateTime(1991, 05, 15));
            dt.Rows.Add(code + 2, "ANATR", id + 2, new DateTime(1990, 04, 04));
            dt.Rows.Add(code + 3, "ANTON", id + 3, new DateTime(1957, 11, 30));
            dt.Rows.Add(code + 4, "BLONP", id + 4, new DateTime(1930, 10, 22));
            dt.Rows.Add(code + 5, "BOLID", id + 5, new DateTime(1953, 02, 18));
            code += 5;
            id += 5;
        }
        return dt;
    }
}
```
