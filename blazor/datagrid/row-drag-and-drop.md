---
layout: post
title: Row Drag and Drop in Blazor DataGrid | Syncfusion
description: Learn how to enable row drag and drop in Syncfusion Blazor DataGrid, including reordering, cross-grid dragging, custom drops, and event handling.
platform: Blazor
control: DataGrid
documentation: ug
---

# Row Drag and Drop in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports built-in row drag-and-drop functionality. Rows can be reordered within the grid, moved between grids, or dropped into custom components.

Enable row drag and drop by setting [AllowRowDragAndDrop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowRowDragAndDrop) to true. Configure the drop target using the [TargetID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridRowDropSettings.html#Syncfusion_Blazor_Grids_GridRowDropSettings_TargetID) property in [RowDropSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridRowDropSettings.html).

> - Row selection must be enabled to perform row drag and drop.  
> - To drag multiple rows, set [GridSelectionSettings.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Type) to Multiple.

## Drag and drop within DataGrid

The drag and drop feature enables reordering of rows within the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid using the drag handle. Set the [AllowRowDragAndDrop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowRowDragAndDrop) property to `true` to enable this feature. By default, the value is `false`.

Here is an example that enables row drag and drop within the grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" ID="Grid" AllowSelection="true" AllowRowDragAndDrop="true">
    <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" Width="120" IsPrimaryKey="true"> </GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Width="100" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderData> Orders { get; set; }
    public List<OrderData> SecondGrid { get; set; } = new List<OrderData>();
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

    public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData() { }
        public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, int employeeID)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.ShipName = ShipName;
            this.Freight = Freight;
            this.OrderDate = OrderDate;
            this.ShippedDate = ShippedDate;
            this.IsVerified = IsVerified;
            this.ShipCity = ShipCity;
            this.ShipCountry = ShipCountry;
            this.EmployeeID = employeeID; 
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count == 0)
            {
                Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", 1));
                Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", 2));
                Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "Brazil", 3));
                Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", 1));
                Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", 2));
                Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", 3));
                Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", 2));
                Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "Brazil", 1));
                Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", 3));
            }
            return Orders;
        }

        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipName { get; set; }
        public double? Freight { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public bool? IsVerified { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public int EmployeeID { get; set; } 
    }

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNrzWWrtWInIGJbg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Drag and drop to DataGrid


The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports dragging rows from one grid and dropping them into another. Enable this feature by setting the [AllowRowDragAndDrop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowRowDragAndDrop) property to `true` on both grids. To specify the target grid, configure the [RowDropSettings.TargetID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridRowDropSettings.html#Syncfusion_Blazor_Grids_GridRowDropSettings_TargetID) property with the target grid's ID.

The following example enables row drag and drop between two grids:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" ID="Grid" AllowSelection="true" AllowRowDragAndDrop="true">
    <GridRowDropSettings TargetID="DestGrid"></GridRowDropSettings>
    <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" Width="120" IsPrimaryKey="true"> </GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
<br>
<SfGrid DataSource="@SecondGridData" ID="DestGrid" AllowRowDragAndDrop="true" AllowSelection="true">
    <GridRowDropSettings TargetID="Grid"></GridRowDropSettings>
    <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" Width="120" IsPrimaryKey="true"> </GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderData> Orders { get; set; }
    public List<OrderData> SecondGridData { get; set; } = new List<OrderData>();
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

  public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();

        public OrderData() { }

        public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, int employeeID)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.ShipName = ShipName;
            this.Freight = Freight;
            this.OrderDate = OrderDate;
            this.ShippedDate = ShippedDate;
            this.IsVerified = IsVerified;
            this.ShipCity = ShipCity;
            this.ShipCountry = ShipCountry;
            this.EmployeeID = employeeID; 
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count == 0)
            {
                Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", 1));
                Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", 2));
                Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "Brazil", 3));
                Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", 1));
                Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", 2));
                Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", 3));
                Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", 2));
                Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "Brazil", 1));
                Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", 3));
            }
            return Orders;
        }

        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipName { get; set; }
        public double? Freight { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public bool? IsVerified { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public int EmployeeID { get; set; } 
    }

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjBfWirtinCYhFlS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Drag and drop in empty area

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports dropping rows in empty content areas. By default, the `AllowEmptyAreaDrop` setting is enabled, allowing rows to be dropped anywhere within the grid content. Rows dropped in an empty area are appended to the end of the data. This applies to both within-grid and between-grid scenarios.

To display the drop indicator only when hovering over rows, disable the AllowEmptyAreaDrop property in the RowDropSettings configuration.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid id="Grid" DataSource="@FirstGridData" AllowRowDragAndDrop="true" AllowSelection="true" AllowPaging="true">
    <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GridSelectionSettings>
    <GridPageSettings PageCount="1" PageSize="12"></GridPageSettings>
    <GridRowDropSettings TargetID="DestGrid"></GridRowDropSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrdersDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.CustomerID) HeaderText="Customer ID" Width="135"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.OrderDate) HeaderText="Order Date" Format="d" TextAlign="TextAlign.Right" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>
<SfGrid id="DestGrid" DataSource="@SecondGridData" AllowRowDragAndDrop="true" AllowSelection="true" AllowPaging="true" Height="350">
    <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GridSelectionSettings>
    <GridPageSettings PageCount="1" PageSize="12"></GridPageSettings>
    <GridRowDropSettings TargetID="Grid"></GridRowDropSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrdersDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.CustomerID) HeaderText="Customer ID" Width="135"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.OrderDate) HeaderText="Order Date" Format="d" TextAlign="TextAlign.Right" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrdersDetails> FirstGridData { get; set; }
    public List<OrdersDetails> SecondGridData { get; set; } = new List<OrdersDetails>();
    protected override void OnInitialized()
    {
        FirstGridData = OrdersDetails.GetAllRecords();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrdersDetails.cs" %}

public class OrdersDetails
{
    public static List<OrdersDetails> Orders = new List<OrdersDetails>();

    public OrdersDetails() { }

    public OrdersDetails(int orderID, string customerID, DateTime? orderDate)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.OrderDate = orderDate;
    }

    public static List<OrdersDetails> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrdersDetails(10248, "VINET", new DateTime(1996, 7, 4)));
            Orders.Add(new OrdersDetails(10249, "TOMSP", new DateTime(1996, 7, 5)));
            Orders.Add(new OrdersDetails(10250, "HANAR", new DateTime(1996, 7, 6)));
            Orders.Add(new OrdersDetails(10251, "VINET", new DateTime(1996, 7, 7)));
            Orders.Add(new OrdersDetails(10252, "SUPRD", new DateTime(1996, 7, 8)));
            Orders.Add(new OrdersDetails(10253, "HANAR", new DateTime(1996, 7, 9)));
            Orders.Add(new OrdersDetails(10254, "CHOPS", new DateTime(1996, 7, 10)));
            Orders.Add(new OrdersDetails(10255, "VINET", new DateTime(1996, 7, 11)));
            Orders.Add(new OrdersDetails(10256, "HANAR", new DateTime(1996, 7, 12)));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime? OrderDate { get; set; }
}

{% endhighlight %}
{% endtabs %}

## Drag and drop to custom component

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports dragging rows into custom components. Enable [AllowRowDragAndDrop] and set [RowDropSettings.TargetID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridRowDropSettings.html#Syncfusion_Blazor_Grids_GridRowDropSettings_TargetID) to the `ID` of the target component.

In the following example, selected grid rows are dropped into a TreeGrid using the [RowDropped](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowDropped) event. After the drop, the corresponding rows are removed from the source grid and added to the target:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids;
@using Syncfusion.Blazor.TreeGrid;

<div>
    <SfGrid @ref="grid" ID="Grid" DataSource="@GridData" AllowRowDragAndDrop="true" AllowSelection="true">
        <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GridSelectionSettings>
        <GridRowDropSettings TargetID="DestGrid"></GridRowDropSettings>
        <GridEvents TValue="WrapData" RowDropped="OnRowDrop"></GridEvents>
        <GridColumns>
            <GridColumn Field="TaskID" HeaderText="Task ID" Width="80" IsPrimaryKey="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GridColumn>
            <GridColumn Field="TaskName" HeaderText="Task Name" Width="160"></GridColumn>
            <GridColumn Field="Description" HeaderText="Description" TextAlign="TextAlign.Left" Width="180"></GridColumn>
            <GridColumn Field="Category" HeaderText="Category" TextAlign="TextAlign.Left" Width="180"></GridColumn>
            <GridColumn Field="StartDate" HeaderText="StartDate" TextAlign="TextAlign.Left" Format="d" Type="ColumnType.Date" Width="160"></GridColumn>
            <GridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GridColumn>
        </GridColumns>
    </SfGrid>
</div>
<div>
    <SfTreeGrid @ref="treegrid" ID="DestGrid" DataSource="@TreeGridData" AllowRowDragAndDrop="true" AllowSelection="true" IdMapping="TaskID" ChildMapping="Subtasks" TreeColumnIndex="1">
        <TreeGridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></TreeGridSelectionSettings>
        <TreeGridRowDropSettings TargetID="Grid"></TreeGridRowDropSettings>
        <TreeGridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true" />
        <TreeGridColumns>
            <TreeGridColumn Field="TaskID" HeaderText="Task ID" Width="90" IsPrimaryKey="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
            <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="180" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Left"></TreeGridColumn>
            <TreeGridColumn Field="StartDate" HeaderText="Start Date" Format="d" Type="ColumnType.Date" Width="90" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
            <TreeGridColumn Field="Duration" HeaderText="Duration" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        </TreeGridColumns>
    </SfTreeGrid>
</div>
@code {
    public List<WrapData> TreeGridData { get; set; } = new();
    public List<WrapData> GridData { get; set; } = new();
    SfTreeGrid<WrapData> treegrid;
    SfGrid<WrapData> grid;

    protected override void OnInitialized()
    {
        GridData = WrapData.GetSampleData();
    }

    public async Task OnRowDrop(RowDroppedEventArgs<WrapData> args)
    {
        if (args.Data != null && args.Data.Count > 0)
        {
            foreach (var item in args.Data)
            {
                await treegrid.AddRecordAsync(item);
                GridData.Remove(item);
                await grid.Refresh();
                await treegrid.RefreshAsync();
            }
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="WrapData.cs" %}

public class WrapData
{
    public int TaskID { get; set; }
    public string TaskName { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? Duration { get; set; }
    public int Progress { get; set; }
    public string Priority { get; set; }
    public bool Approved { get; set; }
    public int Resources { get; set; }
    public int? ParentId { get; set; }
    public string Description { get; set; }
    public string Category { get; set; } 
    public List<WrapData> Subtasks { get; set; } 

    public static List<WrapData> GetSampleData()
    {
        return new List<WrapData>
        {
            new WrapData
            {
              TaskID = 1,
              TaskName = "Planning",
              StartDate = new DateTime(2017, 2, 3),
              EndDate = new DateTime(2017, 2, 7),
              Duration = 5,
              Progress = 100,
              Priority = "Normal",
              Approved = false,
              Description = "Task description 1",
              Category = "Task category 1",
              Subtasks = new List<WrapData>
              {
                new WrapData
                {
                    TaskID = 2,
                    TaskName = "Plan timeline",
                    StartDate = new DateTime(2017, 2, 3),
                    EndDate = new DateTime(2017, 2, 7),
                    Duration = 5,
                    Progress = 100,
                    Priority = "Normal",
                    Approved = false
                },
                new WrapData
                {
                    TaskID = 3,
                    TaskName = "Plan budget",
                    StartDate = new DateTime(2017, 2, 3),
                    EndDate = new DateTime(2017, 2, 7),
                    Duration = 5,
                    Progress = 100,
                    Priority = "Low",
                    Approved = true
                },
                new WrapData
                {
                    TaskID = 4,
                    TaskName = "Allocate resources",
                    StartDate = new DateTime(2017, 2, 3),
                    EndDate = new DateTime(2017, 2, 7),
                    Duration = 5,
                    Progress = 100,
                    Priority = "Critical",
                    Approved = false
                },
                new WrapData
                {
                    TaskID = 5,
                    TaskName = "Planning complete",
                    StartDate = new DateTime(2017, 2, 7),
                    EndDate = new DateTime(2017, 2, 7),
                    Duration = 0,
                    Progress = 0,
                    Priority = "Low",
                    Approved = true
                }
              }
            },
           new WrapData
           {
             TaskID = 6,
             TaskName = "Design",
             StartDate = new DateTime(2017, 2, 10),
             EndDate = new DateTime(2017, 2, 14),
             Duration = 3,
             Progress = 86,
             Priority = "High",
             Approved = false,
             Description = "Task description 2",
             Category = "Task category 2",
             Subtasks = new List<WrapData>
             {
                new WrapData
                {
                    TaskID = 7,
                    TaskName = "Software Specification",
                    StartDate = new DateTime(2017, 2, 10),
                    EndDate = new DateTime(2017, 2, 12),
                    Duration = 3,
                    Progress = 60,
                    Priority = "Normal",
                    Approved = false
                },
                new WrapData
                {
                    TaskID = 8,
                    TaskName = "Develop prototype",
                    StartDate = new DateTime(2017, 2, 10),
                    EndDate = new DateTime(2017, 2, 12),
                    Duration = 3,
                    Progress = 100,
                    Priority = "Critical",
                    Approved = false
                }
             }
            },
            new WrapData
            {
              TaskID = 9,
              TaskName = "Implementation",
              StartDate = new DateTime(2017, 2, 15),
              EndDate = new DateTime(2017, 2, 20),
              Duration = 5,
              Progress = 50,
              Priority = "High",
              Approved = false,
              Description = "Task description 3",
              Category = "Task category 3",
              Subtasks = new List<WrapData>
              {
                new WrapData
                {
                    TaskID = 10,
                    TaskName = "Develop code",
                    StartDate = new DateTime(2017, 2, 15),
                    EndDate = new DateTime(2017, 2, 17),
                    Duration = 3,
                    Progress = 70,
                    Priority = "High",
                    Approved = false
                },
                new WrapData
                {
                    TaskID = 11,
                    TaskName = "Code review",
                    StartDate = new DateTime(2017, 2, 18),
                    EndDate = new DateTime(2017, 2, 20),
                    Duration = 2,
                    Progress = 30,
                    Priority = "Normal",
                    Approved = false
                }
              }
            },
           new WrapData
           {
              TaskID = 12,
              TaskName = "Testing",
              StartDate = new DateTime(2017, 2, 21),
              EndDate = new DateTime(2017, 2, 25),
              Duration = 4,
              Progress = 40,
              Priority = "Medium",
              Approved = false,
              Description = "Task description 4",
              Category = "Task category 4",
              Subtasks = new List<WrapData>
              {
                new WrapData
                {
                    TaskID = 13,
                    TaskName = "Unit testing",
                    StartDate = new DateTime(2017, 2, 21),
                    EndDate = new DateTime(2017, 2, 22),
                    Duration = 2,
                    Progress = 50,
                    Priority = "High",
                    Approved = false
                },
                new WrapData
                {
                    TaskID = 14,
                    TaskName = "Integration testing",
                    StartDate = new DateTime(2017, 2, 23),
                    EndDate = new DateTime(2017, 2, 25),
                    Duration = 2,
                    Progress = 30,
                    Priority = "Medium",
                    Approved = false
                }
              }
            },
            new WrapData
            {
              TaskID = 15,
              TaskName = "Deployment",
              StartDate = new DateTime(2017, 2, 26),
              EndDate = new DateTime(2017, 2, 28),
              Duration = 3,
              Progress = 10,
              Priority = "Critical",
              Approved = false,
              Description = "Task description 5",
              Category = "Task category 5",
              Subtasks = new List<WrapData>
              {
                new WrapData
                {
                    TaskID = 16,
                    TaskName = "Prepare deployment environment",
                    StartDate = new DateTime(2017, 2, 26),
                    EndDate = new DateTime(2017, 2, 27),
                    Duration = 2,
                    Progress = 40,
                    Priority = "High",
                    Approved = false
                },
                new WrapData
                {
                    TaskID = 17,
                    TaskName = "Deploy to production",
                    StartDate = new DateTime(2017, 2, 28),
                    EndDate = new DateTime(2017, 2, 28),
                    Duration = 1,
                    Progress = 0,
                    Priority = "Critical",
                    Approved = false
                }
             }
            },
            new WrapData
            {
              TaskID = 18,
              TaskName = "Maintenance",
              StartDate = new DateTime(2017, 3, 1),
              EndDate = new DateTime(2017, 3, 5),
              Duration = 5,
              Progress = 20,
              Priority = "Low",
              Approved = false,
              Description = "Task description 6",
              Category = "Task category 6",
              Subtasks = new List<WrapData>
              {
                new WrapData
                {
                    TaskID = 19,
                    TaskName = "Monitor system",
                    StartDate = new DateTime(2017, 3, 1),
                    EndDate = new DateTime(2017, 3, 3),
                    Duration = 3,
                    Progress = 50,
                    Priority = "Normal",
                    Approved = false
                },
                new WrapData
                {
                    TaskID = 20,
                    TaskName = "Fix bugs",
                    StartDate = new DateTime(2017, 3, 4),
                    EndDate = new DateTime(2017, 3, 5),
                    Duration = 2,
                    Progress = 10,
                    Priority = "Low",
                    Approved = false
                }
              }
            },
            new WrapData
            {
              TaskID = 21,
              TaskName = "Documentation",
              StartDate = new DateTime(2017, 3, 6),
              EndDate = new DateTime(2017, 3, 8),
              Duration = 3,
              Progress = 70,
              Priority = "Normal",
              Approved = true,
              Description = "Task description 7",
              Category = "Task category 7",
              Subtasks = new List<WrapData>
              {
                new WrapData
                {
                    TaskID = 22,
                    TaskName = "Write user guide",
                    StartDate = new DateTime(2017, 3, 6),
                    EndDate = new DateTime(2017, 3, 7),
                    Duration = 2,
                    Progress = 80,
                    Priority = "Normal",
                    Approved = true
                },
                new WrapData
                {
                    TaskID = 23,
                    TaskName = "Write API documentation",
                    StartDate = new DateTime(2017, 3, 7),
                    EndDate = new DateTime(2017, 3, 8),
                    Duration = 2,
                    Progress = 60,
                    Priority = "Normal",
                    Approved = true
                }
             }
           }
       };
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZBJCrZpfJngbJCc?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Drag and drop events 

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid exposes events to customize and track drag-and-drop operations:

- [RowDragStarting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowDragStarting) – Triggered when dragging starts.
- [RowDropping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowDropping) – Triggered while dragged rows are being dropped on the target; can be canceled.
- [RowDropped](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowDropped) – Triggered after rows are dropped on the target.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<p>@message</p>
<SfGrid @ref="Grid" DataSource="@Orders" ID="Grid" AllowSelection="true" AllowRowDragAndDrop="true">
    <GridEvents RowDragStarting="RowDragStartingHandler" RowDropping="RowDroppingHandler" RowDropped="RowDroppedHandler" TValue="OrderData"></GridEvents>
    <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" Width="120" IsPrimaryKey="true"> </GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Width="100" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>
<style>
    p{
        color: red;
        text-align:center;
    }
</style>
@code {
    SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
    private string message = "";
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
    public void RowDragStartingHandler(RowDragStartingEventArgs<OrderData> Args)
    {
        message = "RowDragStart event triggered";
    }
    public void RowDroppingHandler(RowDroppingEventArgs<OrderData> Args)
    {
        message = "RowDropping event triggered";
        if (Args.Data.FirstOrDefault()?.OrderID == 10249)
        {
            Args.Cancel = true;
            message = "Row dropping cancelled for OrderID 10249";
        }
    }
    public void RowDroppedHandler(RowDroppedEventArgs<OrderData> Args)
    {
        message = "RowDropped event triggered";
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData() { }
    public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, int employeeID)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
        this.EmployeeID = employeeID; 
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", 1));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", 2));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "Brazil", 3));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", 1));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", 2));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", 3));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", 2));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "Brazil", 1));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", 3));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public int EmployeeID { get; set; } 
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZrpWVNeByBihtpL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> To perform row drag and drop, define at least one column as a primary key using the [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKey) property.

## Limitations

- Multiple rows can be dragged and dropped based on the current selection.
- A single row can be dragged and dropped within the same grid even if multiple selection is not enabled.
- Row drag and drop does not have built-in support when combined with sorting, filtering, hierarchy grid, or row template features.
- Row drag and drop with grouping does not support lazy-load grouping.
- Drag and drop within the same group key is not supported. Dragging multiple rows from different grouped collections is not supported.