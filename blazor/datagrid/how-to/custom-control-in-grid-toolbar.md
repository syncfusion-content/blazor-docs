---
layout: post
title: Custom control in Blazor DataGrid Component Toolbar | Syncfusion
description: Learn here all about custom control in datagrid toolbar in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Custom Control in Datagrid Toolbar in Blazor DataGrid Component

You can render custom controls inside the datagrid's toolbar area. This can be achieved by initializing the custom controls within the Template property of the Toolbar component. This toolbar component is defined inside the datagrid component.

This is demonstrated in the following sample code where Autocomplete component is rendered inside the DataGrid's toolbar and is used for performing search operation on the datagrid,

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.DropDowns

<SfGrid DataSource="@Orders" AllowPaging="true" @ref="Grid">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridEvents TValue="Order"></GridEvents>
    <SfToolbar>
        <ToolbarItems>
            <ToolbarItem Type="ItemType.Input">
                <Template>
                    <SfAutoComplete Placeholder="Search Customer Name" TItem="CustomerDetails" TValue="string" DataSource="@Customers">
                        <AutoCompleteEvents ValueChange="OnSearch" TValue="string" TItem="CustomerDetails"></AutoCompleteEvents>
                        <AutoCompleteFieldSettings Value="Name"></AutoCompleteFieldSettings>
                    </SfAutoComplete>
                </Template>
            </ToolbarItem>
        </ToolbarItems>
    </SfToolbar>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public class CustomerDetails
    {
        public string Name { get; set; }

        public int Id { get; set; }
    }

    List<CustomerDetails> Customers = new List<CustomerDetails>
    {
        new CustomerDetails() { Name = "ALFKI", Id = 1 },
        new CustomerDetails() { Name = "ANANTR", Id = 2 },
        new CustomerDetails() { Name = "ANTON", Id = 3 },
        new CustomerDetails() { Name = "BLONP", Id = 4 },
        new CustomerDetails() { Name = "BOLID", Id = 5 }
    };
    private SfGrid<Order> Grid;
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

    public async Task  OnSearch(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string,CustomerDetails> args)
    {
        await this.Grid.Search(args.Value);
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

The following GIF represents the search operation performed on the datagrid using the Autocomplete component rendered in the toolbar,

![Blazor DataGrid with Custom ToolBar](../images/blazor-datagrid-custom-toolbar.gif)
