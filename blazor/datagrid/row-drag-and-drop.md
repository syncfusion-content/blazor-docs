---
layout: post
title: Row Drag and Drop in Blazor DataGrid | Syncfusion
description: Checkout and learn here all about Row Drag and Drop in Syncfusion Blazor DataGrid and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Row Drag and Drop in Blazor DataGrid

The Syncfusion Blazor DataGrid provides built-in support for row drag and drop functionality. This feature allows you to easily rearrange rows within the Grid by dragging and dropping them to new positions. Additionally, you can also drag and drop rows from one Grid to another Grid, as well as drag and drop rows to custom components.

To enable row drag and drop, set the [AllowRowDragAndDrop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowRowDragAndDrop) to **true**. The target component where the Grid rows are to be dropped can be set by using the [TargetID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridRowDropSettings.html#Syncfusion_Blazor_Grids_GridRowDropSettings_TargetID).

> * Selection feature must be enabled for row drag and drop.
> * Multiple rows can be selected by clicking and dragging inside the Grid. For multiple row selection, the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Type) property must be set to multiple.

## Drag and drop within DataGrid

The drag and drop feature allows you to rearrange rows within the Syncfusion Blazor DataGrid by dragging them using a drag icon. This feature can be enabled by setting the [AllowRowDragAndDrop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowRowDragAndDrop) property to **true**. This property is a boolean value that determines whether row drag and drop is enabled or not. By default, it is set to **false**, which means that row drag and drop is disabled.

Here’s an example of how to enable drag and drop within the Grid:

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

The Syncfusion Blazor DataGrid row drag and drop allows you to drag Grid rows and drop to another Grid. This feature can be enabled by setting the [AllowRowDragAndDrop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowRowDragAndDrop) property to **true** in the Grid. This property specifies whether to enable or disable the row drag and drop feature in the Grid. By default, this property is set to **false**, which means that row drag and drop functionality is not enabled.

To specify the target component where the Grid rows should be dropped, use the [TargetID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridRowDropSettings.html#Syncfusion_Blazor_Grids_GridRowDropSettings_TargetID) property of the [RowDropSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridRowDropSettings.html) object. The `TargetID` property takes the [ID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ID) of the target component as its value.

Here’s an example code snippet that demonstrates how to enable Row drag and drop another Grid:

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

The Syncfusion Blazor DataGrid supports drag and drop functionality. By default, the `AllowEmptyAreaDrop` property is enabled, enhancing the user experience by allowing rows to be dropped anywhere within the DataGrid content. Whenever rows are dropped in an empty area, they are placed at the end of the DataGrid. This applies to both within the same Grid and between different DataGrids.
 
If you prefer to show the drop indicator only when hovering over rows, you can disable the `AllowEmptyAreaDrop` property to achieve this.

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

The Syncfusion Blazor DataGrid provides the feature to drag and drop Grid rows to any custom component. This feature allows you to easily move rows from one component to another without having to manually copy and paste data. To enable row drag and drop, you need to set the [AllowRowDragAndDrop] property to **true** and defining the custom component [ID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ID) in the [TargetID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridRowDropSettings.html#Syncfusion_Blazor_Grids_GridRowDropSettings_TargetID) property of the [RowDropSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridRowDropSettings.html) object. The `ID` provided in `TargetID` should correspond to the `ID` of the target component where the rows are to be dropped.

In the below example, the selected Grid row is dragged and dropped in to the [TreeGrid](https://blazor.syncfusion.com/documentation/treegrid/getting-started-webapp) by using [RowDropped](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowDropped) event. Once the row is dropped into the TreeGrid, removed the corresponding Grid row from Grid and its data inserted in custom component:

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

The Syncfusion Blazor DataGrid provides a set of events that are triggered during drag and drop operations on Grid rows. These events allow you to customize the drag element, track the progress of the dragging operation, and perform actions when a row is dropped on a target element. The following events are available:

* [RowDragStarting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowDragStarting)  - This event is triggered when the dragging of a Grid row starts.
* [RowDropping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowDropping) - This event triggered when the dragged elements are being dropped on the target element.
* [RowDropped](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowDropped)  - This event is triggered when a drag element is dropped onto a target element.

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

> For performing row drag and drop action on the Grid, any one of the columns should be defined as a primary key using the [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKey) property.

## Drag and drop between two Grids with different TValues

The Syncfusion Blazor DataGrid supports row drag and drop functionality between two Grids, even when they are bound to different data models (**TValue**). This is particularly useful when you need to transfer data between Grids that represent different views or formats of the same underlying data.

To implement this functionality, handle the `RowDropped` event. This event provides access to the dropped records, allowing you to transform and insert them into the target Grid’s datasource according to its specific TValue.

The following example demonstrates how to implement drag and drop between two Grid with different TValue types:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="OriginGrid" DataSource="@OriginDataSource" ID="OriginGrid" AllowSelection="true" Width="700" AllowRowDragAndDrop="true">
    <GridRowDropSettings TargetID="DestGrid"></GridRowDropSettings>
    <GridEvents RowDropped="OrderDropped" TValue="OrderData"></GridEvents>
    <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" IsPrimaryKey="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="Syncfusion.Blazor.Grids.ColumnType.Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShippedDate) HeaderText="Shipped Date" Format="d" Type="Syncfusion.Blazor.Grids.ColumnType.Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Visible="false" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Visible="false" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
<br>
<SfGrid @ref="DestGrid" DataSource="@DestDataSource" ID="DestGrid" AllowRowDragAndDrop="true" Width="700" AllowSelection="true">
    <GridRowDropSettings TargetID="OriginGrid"></GridRowDropSettings>
    <GridEvents RowDropped="EmployeeDropped" TValue="OrdersDetails"></GridEvents>
    <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrdersDetails.ID) HeaderText="ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="110" IsPrimaryKey="true"> </GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.Name) HeaderText="Name" Width="110"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.OrderDate) HeaderText="Date" Format="d" Type="Syncfusion.Blazor.Grids.ColumnType.Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="110"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.Freight) HeaderText="Shipment" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Format="C2" Width="110"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.ShippedDate) HeaderText="ShipedDate" Format="d" Width="110" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Type="Syncfusion.Blazor.Grids.ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.City) HeaderText="City" Visible="false" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.Country) HeaderText="Country" Visible="false" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    SfGrid<OrderData> OriginGrid { get; set; }
    SfGrid<OrdersDetails> DestGrid { get; set; }
    public List<OrderData> OriginDataSource { get; set; }
    public List<OrdersDetails> DestDataSource { get; set; } = new List<OrdersDetails>();

    protected override void OnInitialized()
    {
        OriginDataSource = OrderData.GetAllRecords();
    }

    public async Task OrderDropped(RowDroppedEventArgs<OrderData> Args)
    {
        foreach (var val in Args.Data)
        {
            DestDataSource.Add(new OrdersDetails() { ID = val.OrderID, Name = val.CustomerID, Freight = val.Freight, OrderDate = val.OrderDate, City = val.ShipCity, ShippedDate = val.ShippedDate, Country = val.ShipCountry });
        }
        await DestGrid.Refresh();
    }
    public async Task EmployeeDropped(RowDroppedEventArgs<OrdersDetails> Args)
    {
        foreach (var val in Args.Data)
        {
            OriginDataSource.Add(new OrderData() { OrderID = val.ID, CustomerID = val.Name, Freight = val.Freight, OrderDate = val.OrderDate, ShipCity = val.City, ShipCountry = val.Country, ShippedDate = val.ShippedDate });
        }
        await OriginGrid.Refresh();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData()
    {

    }
    public OrderData(int? OrderID, string CustomerID, string ShipCountry, double Freight, DateTime OrderDate, DateTime ShippedDate, string ShipCity)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipCountry = ShipCountry;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.ShipCity = ShipCity;
    }
     public static List<OrderData> GetAllRecords()
     {
        if (Orders.Count() == 0)
        {
            int code = 10;
            for (int i = 1; i < 2; i++)
            {
                Orders.Add(new OrderData(10248, "ALFKI", "France", 33.33, new DateTime(1996, 07, 07), new DateTime(1996, 08, 07), "Reims"));
                Orders.Add(new OrderData(10249, "ANANTR", "Germany", 89.76, new DateTime(1996, 07, 12), new DateTime(1996, 08, 08), "Münster"));
                Orders.Add(new OrderData(10250, "ANTON", "Brazil", 78.67, new DateTime(1996, 07, 13), new DateTime(1996, 08, 09), "Rio de Janeiro"));
                Orders.Add(new OrderData(10251, "BLONP", "Belgium", 55.65, new DateTime(1996, 07, 14), new DateTime(1996, 08, 10), "Lyon"));
                Orders.Add(new OrderData(10252, "BOLID", "Venezuela", 11.09, new DateTime(1996, 07, 15), new DateTime(1996, 08, 11), "Charleroi"));
                Orders.Add(new OrderData(10253, "BLONP", "Venezuela", 98.98, new DateTime(1996, 07, 16), new DateTime(1996, 08, 12), "Lyon"));
                Orders.Add(new OrderData(10254, "ANTON", "Belgium", 78.75, new DateTime(1996, 07, 17), new DateTime(1996, 08, 13), "Rio de Janeiro"));
                Orders.Add(new OrderData(10255, "ANANTR", "Germany", 44.07, new DateTime(1996, 07, 18), new DateTime(1996, 08, 14), "Münster"));
                Orders.Add(new OrderData(10256, "ALFKI", "France", 67.74, new DateTime(1996, 07, 19), new DateTime(1996, 08, 15), "Reims"));
                code += 5;
            }
        }
        return Orders;
    }
    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public string ShipCountry { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
}

{% endhighlight %}

{% highlight c# tabtitle="OrdersDetails.cs" %}

public class OrdersDetails
{
    public OrdersDetails()
    {

    }
    public OrdersDetails(int? ID, string Name, double Freight, DateTime OrderDate, DateTime ShippedDate, string City, string Country)
    {
        this.ID = ID;
        this.Name = Name;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.City = City;
        this.Country = Country;
    }
    public int? ID { get; set; }
    public string Name { get; set; }
    public double Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNhIZcrYpCnuChMK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Limitations

* Multiple rows can be drag and drop in the row selections basis.
* Single row is able to drag and drop in same Grid without enable the row selection.
* Row drag and drop feature is not having built in support with sorting, filtering, hierarchy Grid and row template features of Grid.
* The row drag-and-drop feature for grouping currently lacks support for lazy load grouping.
* Drag and drop within the same group key is not supported. Grid does not support the drag-and-drop functionality for multiple rows originating from different grouped collections.