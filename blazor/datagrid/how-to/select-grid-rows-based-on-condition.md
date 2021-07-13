---
layout: post
title: How to Select Grid Rows Based On Condition in Blazor DataGrid Component | Syncfusion
description: Checkout and learn about Select Grid Rows Based On Condition in Blazor DataGrid component of Syncfusion, and more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Select datagrid rows based on certain condition

You can select specific rows in the datagrid based on some conditions by using the [`SelectRows`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SelectRows_System_Double___) method in the [`DataBound`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_DataBound) event of the DataGrid component.

This is demonstrated in the below sample code where the index value of datagrid rows with **Freight** column value greater than 10 are stored in the [`RowDataBound`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowDataBound) event and then selected in the [`DataBound`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_DataBound) event,

```csharp
@using Syncfusion.Blazor.Grids

<SfGrid @ref="DefaultGrid" DataSource="@Orders" AllowPaging="true">
    <GridSelectionSettings Type="SelectionType.Multiple"></GridSelectionSettings>
    <GridEvents RowDataBound="OnRowDataBound" DataBound="OnDataBound" TValue="Order"></GridEvents>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type=ColumnType.Date TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

    public List<Order> Orders { get; set; }

    public List<double> SelectedNodeIndex = new List<double>();

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.5 * x,
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

    public async Task  OnDataBound(object args)
    {
        // The filtered index values are selected
        await this.DefaultGrid.SelectRows(SelectedNodeIndex.ToArray());
    }

    public void OnRowDataBound(RowDataBoundEventArgs<Order> args)
    {
        // Freight values greater than 10 are filtered by comparing the primary column values
        if (args.Data.Freight > 10)
        {
            var dataSource = this.DefaultGrid.DataSource;
            var index = 0;
            foreach (var data in dataSource)
            {
                if (data.OrderID == args.Data.OrderID)
                {
                    SelectedNodeIndex.Add(index);
                    break;
                }
                index++;
            }
        }
    }
}
```
