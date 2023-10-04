---
layout: post
title: Toolbar Items in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Toolbar Items in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Toolbar items in Blazor DataGrid component

The Syncfusion Blazor Grid offers a flexible toolbar that enables the addition of custom Toolbar Items or modification of existing ones. This customizable toolbar is positioned above the grid, providing a convenient way to access various actions and functionalities.

## Built-in Toolbar item

Built-in toolbar items in the Syncfusion Blazor Grid component involves utilizing pre-defined actions to perform standard operations within the Grid.

These items can be added by defining the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar) property as a collection of built-in items. Each item is rendered as a button with an icon and text. The following table lists the built-in Toolbar Items and their respective actions.

| Built-in Toolbar Items | Actions |
|------------------------|---------|
| Add | Adds a new record.|
| Edit | Edits the selected record.|
| Update | Updates the edited record.|
| Delete | Deletes the selected record.|
| Cancel | Cancels the edit state.|
| Search | Searches the records by the given key.|
| Print | Prints the datagrid.|
| ExcelExport | Exports the datagrid to Excel.|
| PdfExport | Exports the datagrid to PDF.|
| CsvExport | Exports the datagrid to CSV.|

The following example demonstrates how to enable built-in Toolbar items such as **Print** and **Search** in the grid.

```csharp
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" Height="200" Toolbar=@Tool>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipName) HeaderText="Ship Name" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<string> Tool = new List<string>() { "Search", "Print" };
    public List<Order> Orders { get; set; }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "SUPRD", "CHOPS" })[new Random().Next(5)],
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" })[new Random().Next(5)],
                ShipName = (new string[] { "Toms Spezialitäten", "Hanari Carnes", "Suprêmes délices", "Ernst Handel", "HILARION-Abastos" })[new Random().Next(5)],
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VDrUDaBuqFMoVFsx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Show only icons in built-in Toolbar Items

Showing only icons in the built-in Toolbar Items of the Grid involves customizing the appearance of the toolbar to display icons without text.

To display only icons in the built-in Toolbar Items of the Grid, you can use CSS to hide the text portion of the buttons using the following CSS style.

```csharp
.e-grid .e-toolbar .e-tbar-btn-text, 
.e-grid .e-toolbar .e-toolbar-items .e-toolbar-item .e-tbar-btn-text {
    display: none;   
}
```
This is demonstrated in the following sample:

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" Height="200" Toolbar=@Tool>
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right"  IsPrimaryKey="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipName) HeaderText="Ship Name" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
<style>
    .e-grid .e-toolbar .e-tbar-btn-text,
    .e-grid .e-toolbar .e-toolbar-items .e-toolbar-item .e-tbar-btn-text {
        display: none;
    }
</style>

@code {
    public List<string> Tool = new List<string>() { "Add", "Edit" ,"Delete","Update","Cancel"};
    public List<Order> Orders { get; set; }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "SUPRD", "CHOPS" })[new Random().Next(5)],
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" })[new Random().Next(5)],
                ShipName = (new string[] { "Toms Spezialitäten", "Hanari Carnes", "Suprêmes délices", "Ernst Handel", "HILARION-Abastos" })[new Random().Next(5)],
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LNBqNOrYKbyHFYZF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Custom Toolbar Items

Adding custom Toolbar Items to the Syncfusion Blazor DataGrid involves incorporating personalized functionality into the Toolbar.

Custom Toolbar Items can be added to the DataGrid component by defining the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar) property as a collection of [ItemModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ItemModel.html#Syncfusion_Blazor_Navigations_ItemModel__ctor) objects. These objects define the custom items and their corresponding actions. The actions for the customized toolbar items are defined in the [OnToolbarClick](https://blazor.syncfusion.com/documentation/datagrid/events#ontoolbarclick) event.

By default, custom Toolbar Items are positioned on the **left** side of the Toolbar. However, you can change the position by using the [Align](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ItemModel.html#Syncfusion_Blazor_Navigations_ItemModel_Align) property of the `ItemModel`. The following example demonstrates how to apply the `Align` property with the value **Right** for the **Collapse All** Toolbar Item.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<SfGrid DataSource="@Orders" @ref="Grid" AllowGrouping="true" Height="200" Toolbar=@Toolbaritems>
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridGroupSettings Columns=@Tool></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right"  IsPrimaryKey="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipName) HeaderText="Ship Name" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<Order> Grid;
    private List<ItemModel> Toolbaritems = new List<ItemModel>();
    public List<Order> Orders { get; set; }
    private string[] Tool = (new string[] { "CustomerID" });
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "SUPRD", "CHOPS" })[new Random().Next(5)],
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" })[new Random().Next(5)],
                ShipName = (new string[] { "Toms Spezialitäten", "Hanari Carnes", "Suprêmes délices", "Ernst Handel", "HILARION-Abastos" })[new Random().Next(5)],
            }).ToList();

        Toolbaritems.Add(new ItemModel() { Text = "Expand all", TooltipText = "Expand all", PrefixIcon = "e-expand" });
        Toolbaritems.Add(new ItemModel() { Text = "Collapse all", TooltipText = "Collapse all", PrefixIcon = "e-collapse-2", Align = (Syncfusion.Blazor.Navigations.ItemAlign.Right) });
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
    }
    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Text == "Expand all")
        {
            await this.Grid.GroupExpandAll();
        }
        if (args.Item.Text == "Collapse all")
        {
            await this.Grid.GroupCollapseAll();
        }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rtVANEhazCKoKgBn?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Both built-in and custom items in Toolbar

Built-in and custom items in a Toolbar within the Syncfusion Blazor Grid provides the flexibility to create a customized toolbar with a combination of standard actions and custom actions.

To use both types of toolbar items, you can define the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar) property of the Grid as an array that includes both built-in and custom items. The built-in items are specified as strings, while the custom items are defined as objects with properties such as [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_Text), [PrefixIcon](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_PrefixIcon), and [Id](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_Id) within the toolbar component.

The following example demonstrates, how to use both built-in and custom toolbar items in the grid. The built-in toolbar items includes **Add**, **Edit**, **Delete**, **Update**, and **Cancel**, while the custom toolbar item is **Click**.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<div style="margin-left:180px"><p style="color:red;" id="message">@message</p></div>

<SfGrid DataSource="@Orders" @ref="Grid" AllowGrouping="true" Height="200" Toolbar=@Toolbaritems>
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridGroupSettings Columns=@Tool></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" IsPrimaryKey="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipName) HeaderText="Ship Name" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<Order> Grid;
    public string message;
    private List<Object> Toolbaritems = new List<Object>() { "Add", "Delete", "Edit", "Update", "Cancel",new ItemModel() { Text = "Click", TooltipText = "Click", PrefixIcon = "e-click", Id = "Click" } };
    public List<Order> Orders { get; set; }
    private string[] Tool = (new string[] { "CustomerID" });
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "SUPRD", "CHOPS" })[new Random().Next(5)],
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" })[new Random().Next(5)],
                ShipName = (new string[] { "Toms Spezialitäten", "Hanari Carnes", "Suprêmes délices", "Ernst Handel", "HILARION-Abastos" })[new Random().Next(5)],
            }).ToList();

    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
    }
    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Text == "Click")
        {
             message = "Custom Toolbar Clicked";
            //You can customize your code here.
        }

    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXhqtuLkfVRcbnhe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Custom Toolbar Items in a specific position

Customizing the position of a custom toolbar within the Syncfusion Blazor Grid involves modifying the default placement of the custom Toolbar Items. This enables you to precisely control the positioning of each custom Toolbar item according to your specific requirements and desired layout within the DataGrid.

By default, custom Toolbar Items in DataGrid component are aligned on the left side of the toolbar. However, you have the ability to modify the position of the custom toolbar items by utilizing the [Align](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ItemModel.html#Syncfusion_Blazor_Navigations_ItemModel_Align) property of the  [ItemModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ItemModel.html#Syncfusion_Blazor_Navigations_ItemModel__ctor).

In the following sample, the **Collapse All** Toolbar item is positioned on the **Right**, the **Expand All** Toolbar item is positioned on the **Left**, and the **Search** Toolbar item is positioned at the **Center**.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<SfGrid @ref="Grid" DataSource="@Orders" AllowGrouping="true" Toolbar="@Toolbaritems" Height="315">
     <GridEvents OnToolbarClick="ToolbarClickHandler"  TValue="Order"></GridEvents>
    <GridGroupSettings Columns=@Tool></GridGroupSettings>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Batch"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.EmployeeID) HeaderText="Employee ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" ValidationRules="@(new ValidationRules { Required = true })" Type="ColumnType.Number" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.FirstName) HeaderText="First Name" ValidationRules="@(new ValidationRules{ Required=true})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.Country) HeaderText="Country" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.PostalCode) HeaderText="PostalCode" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .e-expand::before {
        content: '\e82e';
    }

    .e-collapse::before {
        content: '\e834';
    }
</style>

@code {
    private SfGrid<Order> Grid;
    public List<Order> Orders { get; set; }
    private List<Object> Toolbaritems = new List<Object>() { "Search", new ItemModel() { Text = "Expand all", TooltipText = "Expand all", PrefixIcon = "e-expand", Align = (Syncfusion.Blazor.Navigations.ItemAlign.Left) }, new ItemModel() { Text = "Collapse all", TooltipText = "Collapse all", PrefixIcon = "e-collapse", Align = (Syncfusion.Blazor.Navigations.ItemAlign.Right) } };
    private string[] Tool = (new string[] { "FirstName" });

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 12).Select(x => new Order()
            {
                EmployeeID = x,
                FirstName = (new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven" })[new Random().Next(5)],
                PostalCode = (new string[] { "98122", "98401", "98033", "SW1 8JR", "EC2 7JR" })[new Random().Next(5)],
                Country = (new string[] { "USA", "UK" })[new Random().Next(2)],

            }).ToList();

       
    }

    public class Order
    {
        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
       
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Text == "Expand all")
        {
            await this.Grid.GroupExpandAll();
        }
        if (args.Item.Text == "Collapse all")
        {
            await this.Grid.GroupCollapseAll();
        }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXhKMNXKhRPOCyLS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
