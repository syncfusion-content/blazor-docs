---
layout: post
title: Column Chooser in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about column chooser in the Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Column Chooser in Blazor DataGrid

The column chooser feature in the Syncfusion Blazor Grid component allows you to dynamically show or hide columns. This feature can be enabled by defining the [ShowColumnChooser](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) property as **true**.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" ShowColumnChooser="true" Toolbar=@ToolbarItems>
   
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.DateOnly" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public string[] ToolbarItems = new string[] { "ColumnChooser" };
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 10).Select(x => new Order()
            {
                OrderID = 1000 + x,
                OrderDate = new DateOnly(2023, 2, x),
                Freight = 2.1 * x,
                ShipCountry = (new string[] { "France", "Germany", "Brazil", "Belgium", "Switzerland" })[new Random().Next(5)],
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public DateOnly? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }
}
```
> The column chooser dialog displays the header text of each column by default. If the header text is not defined for a column, the corresponding column field name is displayed instead.

The following GIF represents the column chooser functionality in DataGrid

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXVAtvUsBjrMcBLf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Hide column in column chooser dialog

You can hide the column names in column chooser by defining the [ShowInColumnChooser](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ShowInColumnChooser) property as false. This feature is useful when working with a large number of columns or when you want to limit the number of columns that are available for selection in the column chooser dialog.

In this example, the [ShowInColumnChooser](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ShowInColumnChooser) property is set to false for the OrderID column. As a result, the OrderID column will not be displayed in the column chooser dialog.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" ShowColumnChooser="true" Toolbar=@ToolbarItems>
   
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" ShowInColumnChooser="false" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.DateOnly" TextAlign=" Syncfusion.Blazor.Grids.TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Visible="false" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public string[] ToolbarItems = new string[] { "ColumnChooser" };
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 10).Select(x => new Order()
            {
                OrderID = 1000 + x,
                OrderDate = new DateOnly(2023, 2, x),
                Freight = 2.1 * x,
                ShipCountry = (new string[] { "France", "Germany", "Brazil", "Belgium", "Switzerland" })[new Random().Next(5)],
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" })[new Random().Next(5)],
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public DateOnly? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
        public string ShipCity { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXhgXvACLDYtiTXl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> The `ShowInColumnChooser` property is applied to each element individually. By setting it to false, you can hide specific columns from the column chooser dialog.


## Open column chooser by external button

The Syncfusion Blazor Grid provides the flexibility to open the column chooser dialog on a web page using an external button. By default, the column chooser button is displayed in the right corner of the grid component, and clicking the button opens the column chooser dialog below it. 

Here’s an example of how to open the column chooser in the Grid using an external button:

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="Show" CssClass="e-primary" IsPrimary="true" Content="Open column chooser"></SfButton>

<SfGrid @ref="DefaultGrid" DataSource="@Orders" ShowColumnChooser="true" >
   
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" ShowInColumnChooser="false" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.DateOnly" TextAlign=" Syncfusion.Blazor.Grids.TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Visible="false" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<Order> DefaultGrid;
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 10).Select(x => new Order()
            {
                OrderID = 1000 + x,
                OrderDate = new DateOnly(2023, 2, x),
                Freight = 2.1 * x,
                ShipCountry = (new string[] { "France", "Germany", "Brazil", "Belgium", "Switzerland" })[new Random().Next(5)],
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" })[new Random().Next(5)],
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public DateOnly? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
        public string ShipCity { get; set; }
    }
    public void Show()
    {
        this.DefaultGrid.OpenColumnChooser(100, 40);
    }
}
```

The following GIF represents opening column chooser functionality in DataGrid using external button.

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNBgtFKsVBlJQBuq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize column chooser dialog size

The column chooser dialog in Syncfusion Blazor Grid comes with default size, but you can modify its height and width as per your specific needs using CSS styles.

To customize the column chooser dialog size, you can use the following CSS styles:

```csharp
<style> 
    #Grid .e-dialog.e-ccdlg {         
        max-height: 600px !important; 
        width: 300px !important; 
    } 
    #Grid .e-ccdlg .e-cc-contentdiv { 
        height: 250px !important; 
        width: 250px !important;         
    } 
</style> 
```
> Here, **!important** attribute is used to apply custom styles since the column chooser dialog position will be calculated dynamically based on content.

This can be demonstrated in the following sample:

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" DataSource="@Orders" ShowColumnChooser="true" Toolbar=@ToolbarItems>
   
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" ShowInColumnChooser="false" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.DateOnly" TextAlign=" Syncfusion.Blazor.Grids.TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Visible="false" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    #Grid .e-dialog.e-ccdlg {
        max-height: 600px !important;
        width: 300px !important;
    }

    #Grid .e-ccdlg .e-cc-contentdiv {
        height: 250px !important;
        width: 250px !important;
    }
</style>

@code {
    public string[] ToolbarItems = new string[] { "ColumnChooser" };
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 10).Select(x => new Order()
            {
                OrderID = 1000 + x,
                OrderDate = new DateOnly(2023, 2, x),
                Freight = 2.1 * x,
                ShipCountry = (new string[] { "France", "Germany", "Brazil", "Belgium", "Switzerland" })[new Random().Next(5)],
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" })[new Random().Next(5)],
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public DateOnly? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
        public string ShipCity { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNBqtbUirqVSvxog?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Change default search operator of the column chooser

The column chooser dialog in the Syncfusion Blazor Grid provides a search box that allows you to search for column names. By default, the search functionality uses the **StartsWith** operator to match columns and display the results in the column chooser dialog. However, there might be cases where you need to change the default search operator to achieve more precise data matching.

To change the default search operator of the column chooser in Syncfusion Grid, you need to use the [Operator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Operator.html) property of the [GridColumnChooserSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumnChooserSettings.html) class.

Here’s an example of how to change the default search operator of the column chooser to **Contains** in the Blazor Grid:

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" DataSource="@Orders" ShowColumnChooser="true" Toolbar=@ToolbarItems>
     <GridColumnChooserSettings Operator="Operator.Contains"></GridColumnChooserSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" ShowInColumnChooser="false" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.DateOnly" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Visible="false" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public string[] ToolbarItems = new string[] { "ColumnChooser" };
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 10).Select(x => new Order()
            {
                OrderID = 1000 + x,
                OrderDate = new DateOnly(2023, 2, x),
                Freight = 2.1 * x,
                ShipCountry = (new string[] { "France", "Germany", "Brazil", "Belgium", "Switzerland" })[new Random().Next(5)],
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" })[new Random().Next(5)],
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public DateOnly? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
        public string ShipCity { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjVgNbKsBUxBbcqa?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


## Column chooser template

Using the column chooser template, you can customize the column chooser dialog using [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumnChooserSettings.html#Syncfusion_Blazor_Grids_GridColumnChooserSettings_Template) and [FooterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumnChooserSettings.html#Syncfusion_Blazor_Grids_GridColumnChooserSettings_FooterTemplate) of the [GridColumnChooserSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumnChooserSettings.html) component. You can access the parameters passed to the templates using implicit parameter named context.

### Customize the content of column chooser

 The [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumnChooserSettings.html#Syncfusion_Blazor_Grids_GridColumnChooserSettings_Template) tag in the [GridColumnChooserSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumnChooserSettings.html) component is used to customize the content in the column chooser dialog. You can type cast the context as [ColumnChooserTemplateContext](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnChooserTemplateContext.html) to get columns inside content template.

 ```csharp
@using Syncfusion.Blazor.Grids;
@using Model

<SfGrid ID="Grid" @ref="Grid" AllowPaging="true" DataSource="@Orders" ShowColumnChooser="true" Toolbar="@ToolbarItems">
    <GridColumnChooserSettings>
        <Template>
                @{
                    var ContextData = context as ColumnChooserTemplateContext;
                    <CustomComponent @key="ContextData.Columns.Count" ColumnContext="ContextData"></CustomComponent>
                }
        </Template>
    </GridColumnChooserSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"> </GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150"> </GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Visible="false" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) Visible="false" HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.EmployeeID) Visible="false" HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="120"> </GridColumn>
        <GridColumn Field=@nameof(Order.FirstName) Visible="false" HeaderText="First Name" Width="150"> </GridColumn>
        <GridColumn Field=@nameof(Order.LastName) HeaderText="Last Name" Visible="false" Format="d" Type="ColumnType.Date" Width="130"> </GridColumn>
        <GridColumn Field=@nameof(Order.Title) HeaderText="Title" Visible="false"  Width="120"> </GridColumn>
        <GridColumn Field=@nameof(Order.HireDate) HeaderText="Hire Date" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    #Grid.e-grid .e-ccdlg .e-dlg-content {
        margin-top: 0px;
    }

    .e-list-item.e-level-1.e-checklist.e-focused {
        background-color: none;
    }

    #Grid_ccdlg .e-content {
        overflow-y: unset;
    }
</style>

@code
{
    public SfGrid<Order> Grid { get; set; }
    public string[] ToolbarItems = new string[] { "ColumnChooser" };
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 500).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
            EmployeeID = x,
            FirstName = (new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven" })[new Random().Next(5)],
            LastName = (new string[] { "Davolio", "Fuller", "Leverling", "Peacock", "Buchanan" })[new Random().Next(5)],
            Title = (new string[] { "Sales Representative", "Vice President, Sales", "Sales Manager", "Inside Sales Coordinator" })[new Random().Next(4)],
            HireDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }
}

```

> You can build reusable custom component based on your customization need as like above code example.
<br/> In the above example, Syncfusion [ListView](https://blazor.syncfusion.com/documentation/listview/getting-started) component is used as custom component in the content template to show/hide columns.

```csharp
@using Syncfusion.Blazor.Lists;
@using Syncfusion.Blazor.Inputs;
@using Model

<div class="setMargin">
    <SfTextBox Placeholder="Search" Input="@OnInput"></SfTextBox>
</div>

<SfListView @ref="ListView" Height="100%" ShowCheckBox="true" DataSource="@CloneData">
    <ListViewFieldSettings TValue="DataModel" Id="Id" Text="Text" ></ListViewFieldSettings>
    <ListViewEvents Clicked="OnClicked" Created="@(()=>OnCreated(ColumnContext.Columns))" TValue="DataModel"></ListViewEvents>
</SfListView>

<style>
    .setMargin{
        margin-bottom: 10px;
    }
</style>

@code
{
    public List<DataModel> CloneData { get; set; } = new List<DataModel>();

    [CascadingParameter]
    public SfGrid<Order> Grid { get; set; }

    [Parameter]
    public ColumnChooserTemplateContext ColumnContext { get; set; }

    public SfListView<DataModel> ListView { get; set; }

    async Task OnInput(InputEventArgs eventArgs)
    {
        CloneData = DataSource.FindAll(e => e.Text.ToLower().StartsWith(eventArgs.Value.ToLower()));
        await Task.Delay(100);
        await Preselect();
    }

    protected override async Task OnInitializedAsync()
    {
        CloneData = DataSource;
        await Task.Delay(100);
        await Preselect();
    }

    List<DataModel> DataSource = new List<DataModel>
    {
        new DataModel() { Text = "Order ID", Id = "OrderID" },
        new DataModel() { Text = "Customer ID", Id ="CustomerID"},
        new DataModel() { Text = "Employee ID", Id = "EmployeeID" },
        new DataModel() { Text = "First Name", Id = "FirstName"},
        new DataModel() { Text = "Order Date", Id = "OrderDate" },
        new DataModel() { Text = "Last Name", Id = "LastName" },
        new DataModel() { Text = "Hire Date", Id = "HireDate"},
        new DataModel() { Text = "Title", Id = "Title"},
        new DataModel() { Text = "Freight", Id = "Freight"},
    };

    public async Task Preselect()
    {
        var cols = ColumnContext.Columns.FindAll(x => x.Visible == true).ToList();
        var selectlist = new List<DataModel>();
        foreach (var column in cols)
        {
            selectlist.Add(DataSource.Where(x => x.Text == column.HeaderText).FirstOrDefault());
        }
        if (selectlist.Count > 0)
        {
            if (ListView != null)
            {
                await ListView?.CheckItemsAsync(selectlist.AsEnumerable());
            }
        }
    }

    public async Task OnCreated(List<GridColumn> args)
    {
        await Preselect();
    }

    public async Task OnClicked(ClickEventArgs<DataModel> args)
    {
        if (args.IsChecked)
        {
            await Grid.HideColumnAsync(args.Text);
        }
        else
        {
            await Grid.ShowColumnAsync(args.Text);
        }
    }
}
```

> * The model class used in the above example is enclosed in the Model.cs file.

```csharp
using System;

namespace Model
{
    public class DataModel
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
```

![Blazor DataGrid with ListView in Column Chooser](./images/blazor-datagrid-column-chooser-content-template.png)

### Customize the footer of column chooser

 The [FooterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumnChooserSettings.html#Syncfusion_Blazor_Grids_GridColumnChooserSettings_FooterTemplate) tag in the  [GridColumnChooserSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumnChooserSettings.html) component is used to customize the footer in the column chooser dialog. You can type cast the context as [ColumnChooserFooterTemplateContext](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnChooserFooterTemplateContext.html) to get columns inside FooterTemplate.

```csharp
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfGrid @ref="grid" TValue="OrdersDetails" DataSource="@GridData" ShowColumnChooser="true" Toolbar="@( new List<string>() { "ColumnChooser"})" AllowPaging="true">
    <GridColumnChooserSettings>
        <FooterTemplate>
            @{
                var ContextData = context as ColumnChooserFooterTemplateContext;
                var visibles = ContextData.Columns.Where(x => x.Visible).Select(x => x.HeaderText).ToArray();
                var hiddens = ContextData.Columns.Where(x => !x.Visible).Select(x => x.HeaderText).ToArray();
            }
            <SfButton IsPrimary="true" OnClick="@(async () => {
            await grid.ShowColumnsAsync(visibles);
            await grid.HideColumnsAsync(hiddens); })">Submit</SfButton>
            <SfButton @onclick="@(async () => await ContextData.CancelAsync())">Abort</SfButton>
        </FooterTemplate>
    </GridColumnChooserSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrdersDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" IsPrimaryKey="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.ShippedDate) HeaderText="Shipped Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.ShipCountry) HeaderText="Ship Country" Visible="false" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.ShipCity) HeaderText="Ship City" Visible="false" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<OrdersDetails> GridData { get; set; }
    SfGrid<OrdersDetails> grid { get; set; }

    protected override void OnInitialized()
    {
        GridData = Enumerable.Range(1, 75).Select(x => new OrdersDetails()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
            ShippedDate = DateTime.Now.AddDays(+x),
            ShipCountry = (new string[] { "Denmark", "Brazil", "Germany", "Austria" })[new Random().Next(4)],
            ShipCity = (new string[] { "Berlin", "Madrid", "Marseille" })[new Random().Next(3)]
        }).ToList();
    }

    public class OrdersDetails
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string ShipCountry { get; set; }
        public string ShipCity { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtBUXHrjAdKCqkdo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


