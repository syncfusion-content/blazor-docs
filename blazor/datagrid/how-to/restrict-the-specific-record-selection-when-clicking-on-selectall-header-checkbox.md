---
layout: post
title: Restrict the specific record selection when clicking on selectall header checkbox
description: Learn here all about to restrict the specific record selection when clicking on selectall header checkbox
platform: Blazor
control: DataGrid
documentation: ug
---

# Restrict the specific record selection when clicking on selectall header checkbox

This documentation explains how to restrict the selection of specific records by using the [RowSelectingEvent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.RowSelectingEventArgs-1.html#Syncfusion_Blazor_Grids_RowSelectingEventArgs_1_IsHeaderCheckboxClicked) event when the "SelectAll" checkbox is clicked.

After checking the [IsHeaderCheckboxClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.RowSelectingEventArgs-1.html#Syncfusion_Blazor_Grids_RowSelectingEventArgs_1_IsHeaderCheckboxClicked)  property from the RowSelectingEvent argument, prevent the inbuilt selection by setting args.Cancel as true and then customize the selection using [SelectRowsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SelectRowsAsync_System_Int32___) method. 

```cshtml

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfGrid DataSource="@Orders" @ref="Grid" TValue="Order" AllowSelection="true" AllowPaging="true">
     <GridPageSettings PageSize="100"></GridPageSettings>
    <GridSelectionSettings CheckboxOnly="true" Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GridSelectionSettings>
    <GridEvents RowSelecting="RowSelectingHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Type="ColumnType.CheckBox" Width="50"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey=true TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }
    SfGrid<Order>? Grid { get; set; }
    public List<int> RowIndexs { get; set; } = new List<int>();
    public bool flag { get; set; } = false;

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 17).Select(x => new Order()
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

    public async Task RowSelectingHandler(RowSelectingEventArgs<Order> args)
    {
        if (args.IsHeaderCheckboxClicked && !flag) //if header checkbox clicked
        {
            flag = true;
            args.Cancel = true;
            var len = args.RowIndexes.Count;
            for (int i = 0; i < len; i++)
            {
                if ((args.Datas[i].OrderID) > 1003)
                {
                    var value = args.Datas[i].OrderID;
                    var rowIndex = Grid.GetRowIndexByPrimaryKeyAsync(value);
                    int rvalue = Convert.ToInt32(rowIndex.Result);
                    RowIndexs.Add(rvalue); //add row index to list
                }
            }
            await Grid.SelectRowsAsync(RowIndexs.ToArray());//  select rows
            flag = false; //reset flag
        }
    }

}

```