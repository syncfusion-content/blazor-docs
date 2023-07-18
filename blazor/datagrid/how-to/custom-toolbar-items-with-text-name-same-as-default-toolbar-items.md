---
layout: post
title: Custom toolbar items in Blazor DataGrid Component | Syncfusion
description: Learn here all about Custom toolbar items with text name same as default toolbar items in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Custom Toolbar Items with Text Name Same as Default Toolbar Items

You can create the Custom toolbar items with text name same as default toolbar items (Add, Edit, Delete, etc.). But while creating them, they will be considered as default toolbar items which will cause some issues while clicking on them. To overcome this behavior, define the **Id** property for custom toolbar items.

This is demonstrated in the following sample code where there are custom toolbar items with text same as **Add** and **Delete** buttons. These toolbar buttons will be enabled only when GridEditSettings is defined in DataGrid. So custom toolbar will be disabled state considering it as default toolbar item. We have overcome that behavior by defining the Id property.

```cshtml
@using Syncfusion.Blazor.Grids

@{
    List<Syncfusion.Blazor.Navigations.ItemModel> Toolbaritems = new List<Syncfusion.Blazor.Navigations.ItemModel>();
    Toolbaritems.Add(new Syncfusion.Blazor.Navigations.ItemModel() { Text = "Add", Id = "add", TooltipText = "Add Record", PrefixIcon = "add" });
    Toolbaritems.Add(new Syncfusion.Blazor.Navigations.ItemModel() { Text = "Delete", Id = "delete", TooltipText = "Delete Record", PrefixIcon = "delete" });
}

<SfGrid DataSource="@Orders" @ref="Grid" AllowGrouping="true" AllowPaging="true" Height="200" Toolbar="Toolbaritems">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    SfGrid<Order> Grid;
    public List<Order> Orders { get; set; }
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

    public void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Text == "Add")
        {
            //perform your actions here
        }
        if (args.Item.Text == "Delete")
        {
            //perform your actions here
        }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjrADnLQKmlaqQFB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}