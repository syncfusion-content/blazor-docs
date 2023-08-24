---
layout: post
title: Toolbar in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Toolbar in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Toolbar in Blazor DataGrid Component

The DataGrid provides toolbar support to handle datagrid actions. The [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar) property accepts either the collection of built-in toolbar items and [ItemModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ItemModel.html#Syncfusion_Blazor_Navigations_ItemModel__ctor)

## Built-in Toolbar item

The DataGrid provides toolbar support to handle datagrid actions. The [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar) is a collection of built-in items. It renders the button with icon and text.

The following table shows built-in toolbar items and their actions.

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

```csharp

@using Syncfusion.Blazor.Grids

@{
    var Tool = (new List<string>() { "Search","Print"});
}
<SfGrid DataSource="@Orders" AllowPaging="true" Height="200" Toolbar=@Tool>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order>Orders{ get; set; }
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
}

```

The following screenshots represent a datagrid with Built-in toolbar,

![Blazor DataGrid with Built in ToolBar](./images/blazor-datagrid-with-built-in-toolbar.PNG)

## Custom Toolbar Items

Custom toolbar items can be added by defining the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar). Custom toolbar items can be achieved by using Expand all and Collapse all functions.

```csharp

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

 <SfGrid DataSource="@Orders" @ref="Grid" AllowGrouping="true" AllowPaging="true" Height="200" Toolbar="Toolbaritems">
     <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
     <GridGroupSettings Columns=@Tool></GridGroupSettings>
     <GridColumns>
         <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
         <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
         <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
         <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
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

 @code{
     SfGrid<Order> Grid;
     public List<Order>Orders{ get; set; }
     private List<ItemModel> Toolbaritems = new List<ItemModel>();
     private string[] Tool = (new string[] { "OrderID" });
     protected override void OnInitialized()
     {
         Orders = Enumerable.Range(1, 75).Select(x => new Order()
         {
             OrderID = 1000 + x,
             CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
             Freight = 2.1 * x,
             OrderDate = DateTime.Now.AddDays(-x),
         }).ToList();

          Toolbaritems.Add(new ItemModel() { Text = "Expand all", TooltipText = "Expand all", PrefixIcon = "e-expand" });
          Toolbaritems.Add(new ItemModel() { Text = "Collapse all", TooltipText = "Collapse all", PrefixIcon = "e-collapse", Align = (Syncfusion.Blazor.Navigations.ItemAlign.Right) });
         }

     public class Order
     {
         public int? OrderID { get; set; }
         public string CustomerID { get; set; }
         public DateTime? OrderDate { get; set; }
         public double? Freight { get; set; }
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

The following screenshots represent a datagrid with Custom toolbar items,

![Blazor DataGrid with Custom ToolBar Items](./images/blazor-datagrid-custom-toolbar-items.PNG)

## Built-in and custom items in Toolbar

DataGrid have an option to use both built-in and custom tool bar items at same time.

In the following example, `Add`, `Edit`, `Delete`, `Update`, `Cancel` are built-in toolbar items and `Click` is a custom toolbar item.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<SfGrid DataSource="@Orders" AllowPaging="true" Height="200" Toolbar="Toolbaritems">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" IsPrimaryKey="true" ValidationRules="new ValidationRules() { Required = true }" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" ValidationRules="new ValidationRules() { Required = true }" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" ValidationRules="new ValidationRules() { Required = true }" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
<style>
    .e-click::before {
        content: '\e525';
    }
</style>

@code{

    public List<Order> Orders { get; set; }
    private List<Object> Toolbaritems = new List<Object>() { "Add", "Edit", "Delete", "Update", "Cancel", new ItemModel() { Text = "Click", TooltipText = "Click", PrefixIcon = "e-click", Id = "Click" } };
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

        if (args.Item.Id == "Click")
        {
            //You can customize your code here.
        }
    }
}
```

The following screenshots represent a datagrid with Built-in and custom items in toolbar,

![Blazor DataGrid displays Built-in and Custom Items in ToolBar](./images/blazor-datagrid-built-in-toolbar.PNG)

## Custom Toolbar

Custom toolbar items can be added by defining the [Toolbar Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar). Custom toolbar can be placed inside datagrid using [ToolbarTemplate`] as below.

```csharp

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<SfGrid DataSource="@Orders" AllowPaging="true" Height="200" @ref="Grid" AllowGrouping="true">
    <GridTemplates>
        <ToolbarTemplate>
            <SfToolbar>
                <ToolbarEvents Clicked="ToolbarClickHandler"></ToolbarEvents>
                <ToolbarItems>
                    <ToolbarItem Type="@ItemType.Button" PrefixIcon="e-icons e-collapse" Id="collapseall" TooltipText="Collapse"></ToolbarItem>
                </ToolbarItems>
            </SfToolbar>
        </ToolbarTemplate>
    </GridTemplates>

    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridGroupSettings Columns=@Tool></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order D ate" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .e-collapse::before {
        content: '\e834';
    }
</style>

@code{
    SfGrid<Order> Grid;

    public List<Order> Orders { get; set; }

    private string[] Tool = (new string[] { "OrderID" });

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

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       await this.Grid.GroupCollapseAll();
    }
}


```

The following screenshots represent a datagrid with Custom toolbar,

![Blazor DataGrid with Custom ToolBar](./images/blazor-datagrid-custom-toolbar.PNG)

N> The custom toolbar can be placed inside datagrid using Toolbar template component. The contents in the DataGrid can be collapsed by clicking the Collapse icon button.

### Custom Toolbar with dropdown list

Dropdown list can be added by using dropdown list in the toolbar section.

```csharp

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.DropDowns


<SfGrid DataSource="@Orders" AllowPaging="true" Height="200" @ref="Grid">
    <GridEvents TValue="Order"></GridEvents>
    <SfToolbar>
        <ToolbarItems>
            <ToolbarItem Type="ItemType.Input">
                <Template>
                    <SfDropDownList TValue="string" TItem="Select" DataSource=@LocalData Width="200">
                        <DropDownListFieldSettings Text="text" Value="text"> </DropDownListFieldSettings>
                        <DropDownListEvents TValue="string" TItem="Select" ValueChange="OnChange"> </DropDownListEvents>
                    </SfDropDownList>
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

    SfGrid<Order> Grid;
    public List<Order> Orders { get; set; }
    public class Select
    {
        public string text { get; set; }
    }
    List<Select> LocalData = new List<Select>
{
            new Select() { text = "0"},
            new Select() { text = "1"},
            new Select() { text = "2"},
            new Select() { text = "3"},
            new Select() { text = "4"},
            new Select() { text = "5"},
            new Select() { text = "6"},
            new Select() { text = "7"},
            new Select() { text = "8"},
            new Select() { text = "9"},
    };
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 10).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }
    public async Task OnChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, Select> args)
    {
        await this.Grid.SelectRow(int.Parse(args.Value));
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

The following screenshots represent a datagrid with Custom toolbar dropdown list,

![Blazor DataGrid with Custom Toolbar Dropdown List](./images/blazor-datagrid-custom-toolbar-dropdownlist.PNG)

## Enable/Disable Toolbar items

You can enable/disable toolbar items by using the [EnableToolbarItems method](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfToolbar.html#Syncfusion_Blazor_Navigations_SfToolbar_EnableItems_System_Collections_Generic_List_System_Int32__System_Nullable_System_Boolean__).

```csharp

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div>
    <div style="float:left;">
        <SfButton id="Enable" Content="Enable" @onclick="enable"></SfButton>
    </div>
    <div style="padding-left: 90px">
        <SfButton id="Disable" Content="Disable" @onclick="disable"></SfButton>
    </div>
</div>

@{
    var Tool = (new string[] { "Expand", "Collapse" });
}
<SfGrid id="Grid" DataSource="@Orders" AllowPaging="true" Height="200" @ref="Grid" AllowGrouping="true" Toolbar=@Tool>

    <GridGroupSettings Columns=@GroupCol></GridGroupSettings>
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
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

@code{

    SfGrid<Order> Grid;
    public List<Order> Orders { get; set; }
    private string[] GroupCol = (new string[] { "OrderID" });
    public async Task enable()
    {
        await this.Grid.EnableToolbarItems(new List<string>() { "Grid_Expand", "Grid_Collapse" }, true);
    }

    public async Task disable()
    {
        await this.Grid.EnableToolbarItems(new List<string>() { "Grid_Expand", "Grid_Collapse" }, false);
    }

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

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Text == "Expand")
        {
            await this.Grid.GroupExpandAll();
        }
        if (args.Item.Text == "Collapse")
        {
            await this.Grid.GroupCollapseAll();
        }
    }
}

```

The following screenshots represent a datagrid with Enable/disable toolbar items,

![Enabling or Disabling ToolBar Items in Blazor DataGrid](./images/blazor-datagrid-enable-disable-toolbar-items.gif)

## Customize Toolbar text

You can able to customize the toolbar text by using the [ItemModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ItemModel.html#Syncfusion_Blazor_Navigations_ItemModel__ctor) properties.

```csharp

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<SfGrid ID="Grid" DataSource="@Orders" AllowPaging="true" Toolbar=@ToolbarItems>
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) IsPrimaryKey="true" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }
    private List<object> ToolbarItems = new List<object>() {
        new ItemModel() { Text = "Add Record", PrefixIcon = "e-add", Id = "Grid_add"},//Here Grid is SfGrid ID
        new ItemModel(){ Text = "Edit Record", PrefixIcon= "e-edit", Id="Grid_edit"},
        new ItemModel(){ Text = "Delete Record", PrefixIcon= "e-delete", Id="Grid_delete"},
        new ItemModel(){ Text = "Update Record", PrefixIcon= "e-update", Id="Grid_update"},
        new ItemModel(){ Text = "Cancel Changes", PrefixIcon= "e-cancel", Id="Grid_cancel"}
    };
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
}

```

The following screenshots represent a datagrid by customizing toolbar text.

![Customize ToolBar Text in Blazor DataGrid](./images/blazor-datagrid-toolbar-text-customization.jpg)

## Customize toolbar styles

You can able to customize the toolbar styles by using the toolbar class (`.e-toolbar-item .e-tbar-btn`)

```csharp

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true})" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .e-toolbar-item .e-tbar-btn {
        background-color: powderblue;
    }
</style>

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
            ShipCountry = (new string[] { "USA", "UK", "CHINA", "RUSSIA", "INDIA" })[new Random().Next(5)]
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }
}

```

The following screenshots represent a datagrid by customizing toolbar styles.

![Customizing ToolBar Styles in Blazor DataGrid](./images/blazor-datagrid-toolbar-style-customization.png)

## Customizing the toolbar items tooltip text

You can customize the toolbar items tooltip text by adding toolbar items externally by setting [ItemModel.TooltipText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ItemModel.html#Syncfusion_Blazor_Navigations_ItemModel__ctor) property.

```csharp

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<SfGrid ID="Grid" DataSource="@Orders" @ref="DefaultGrid" AllowPaging="true" ShowColumnChooser="true"  AllowExcelExport="true" AllowPdfExport="true" Toolbar=@ToolbarItems>
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) IsPrimaryKey="true" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }
    SfGrid<Order> DefaultGrid;
    
    private List<object> ToolbarItems = new List<object>() {
        new ItemModel() { Text = "Excel",TooltipText="Export to Excel", PrefixIcon = "e-excelexport", Id = "Grid_excelexport"}, //Here Grid is SfGrid ID
        new ItemModel(){ Text = "Pdf",TooltipText="Export to PDF", PrefixIcon= "e-pdfexport", Id="Grid_pdfexport"},
        new ItemModel(){ Text = "CSV",TooltipText="Export to CSV", PrefixIcon= "e-csvexport", Id="Grid_csvexport"},
    };
    
    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            await this.DefaultGrid.ExcelExport();
        }
        else if (args.Item.Id == "Grid_pdfexport")  //Id is combination of Grid's ID and itemname
        {
            await this.DefaultGrid.PdfExport();
        }
        
        else
        {
           await this.DefaultGrid.CsvExport();
        }
    }
    
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
```

![Customizing Toolbar items tooltip text in Blazor DataGrid](./images/blazor-datagrid-toolbar-tooltip-customization.png)

[View Sample in GitHub](https://github.com/SyncfusionExamples/Customizing-the-toolbar-items-tooltip-text-in-Blazor-Grid)

N> You can refer to our [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap4) to understand how to present and manipulate data.
