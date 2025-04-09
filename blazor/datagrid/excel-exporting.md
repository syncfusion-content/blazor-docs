---
layout: post
title: Excel Export in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Excel Export in Syncfusion Blazor DataGrid component and much more.
platform: Blazor
control: DataGrid
documentation: ug
---

<!-- markdownlint-disable MD033 -->


# Excel exporting in Blazor DataGrid

The Excel or CSV exporting feature in the Syncfusion Blazor Grid component allows you to export the Grid data to an Excel or CSV document. This can be useful when you need to share or analyze the data in a spreadsheet format.

To enable Excel export in the Grid component, you need to set the [AllowExcelExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowExcelExport) property to **true**. This property is responsible for enabling the Excel or CSV export option in the Grid.

To initiate the excel export process, you need to use the `ExportToExcelAsync` method provided by the Grid component. This method is responsible for exporting the Grid data to an Excel document.

> To initiate the CSV export process, you need to use the `ExportToCsvAsync` method provided by the Grid component. This method is responsible for exporting the Grid data to an CSV document.

The following example demonstrates how to perform a Excel or CSV export action in the grid:


{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="Grid" DataSource="@Orders" AllowPaging="true" AllowExcelExport="true" Toolbar="@(new List<string>() { "ExcelExport" ,"CsvExport" })" Height="348">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true" />
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150" />
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120" />
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150" />
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }


    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_excelexport")
        {
            await this.Grid.ExportToExcelAsync();
        }
        else if (args.Item.Id == "Grid_csvexport")
        {
            await this.Grid.ExportToCsvAsync();
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData(int orderID, string customerID, double freight, string shipCity)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.Freight = freight;
        this.ShipCity = shipCity;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 32.38, "Reims"));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, "Münster"));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, "Rio de Janeiro"));
            Orders.Add(new OrderData(10251, "VICTE", 41.34, "Lyon"));
            Orders.Add(new OrderData(10252, "SUPRD", 51.3, "Charleroi"));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, "Rio de Janeiro"));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, "Bern"));
            Orders.Add(new OrderData(10255, "RICSU", 148.33, "Genève"));
            Orders.Add(new OrderData(10256, "WELLI", 13.97, "Resende"));
            Orders.Add(new OrderData(10257, "HILAA", 81.91, "San Cristóbal"));
            Orders.Add(new OrderData(10258, "ERNSH", 140.51, "Graz"));
            Orders.Add(new OrderData(10259, "CENTC", 3.25, "México D.F."));
            Orders.Add(new OrderData(10260, "OTTIK", 55.09, "Köln"));
            Orders.Add(new OrderData(10261, "QUEDE", 3.05, "Rio de Janeiro"));
            Orders.Add(new OrderData(10262, "RATTC", 48.29, "Albuquerque"));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNrStJXuTcIPierd?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Show spinner while exporting 

Showing a spinner while exporting in the Grid enhances the experience by displaying a spinner during the export process. This feature provides a visual indication of the export progress, improving the understanding of the exporting process.

To show or hide a spinner while exporting the Grid, you can utilize the [ShowSpinnerAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ShowSpinnerAsync) and [HideSpinnerAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_HideSpinnerAsync) methods provided by the Grid within the `OnToolbarClick` event.

The [OnToolbarClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnToolbarClick) event is triggered when a toolbar item in the Grid is clicked. Within the event handler, the code checks if the clicked **item** is related with Excel or CSV export, specifically the **Grid_excelexport** or **Grid_csvexport** item. If a match is found, the `showSpinner` method is used on the Grid instance to display the spinner.

To hide the spinner after the exporting is completed, bind the [ExportComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ExportComplete) event and use the `hideSpinner` method on the Grid instance to hide the spinner.

The following example demonstrates how to show and hide the spinner during Excel export in a Grid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="Grid" DataSource="@Orders" AllowPaging="true" AllowExcelExport="true" Toolbar="@(new List<string>() { "ExcelExport" })" Height="348">
    <GridEvents ExportComplete="ExportCompleteHandler" OnToolbarClick="ToolbarClickHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true" />
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150" />
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Width="150" Format="C2" TextAlign="TextAlign.Right" />
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150" />
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_excelexport")
        {
            // Show spinner while exporting
            await this.Grid.ShowSpinnerAsync();
            await this.Grid.ExportToExcelAsync();
        }
    }

    public void ExportCompleteHandler(object args)
    {
        // Hide spinner after export completes
        this.Grid.HideSpinnerAsync().ConfigureAwait(false);
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData(int orderID, string customerID, double freight, string shipCity)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.Freight = freight;
        this.ShipCity = shipCity;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            // Generate 1000 records
            Random random = new Random();
            var customerIDs = new[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD", "CHOPS", "RICSU", "WELLI", "HILAA", "ERNSH", "CENTC", "OTTIK", "QUEDE", "RATTC" };
            var cities = new[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi", "Bern", "Genève", "Resende", "San Cristóbal", "Graz", "México D.F.", "Köln", "Rio de Janeiro", "Albuquerque" };

            for (int i = 1; i <= 20000; i++)
            {
                var orderID = i;
                var customerID = customerIDs[random.Next(customerIDs.Length)];
                var freight = Math.Round(random.NextDouble() * 100, 2); // Random freight amount between 0 and 100
                var shipCity = cities[random.Next(cities.Length)];

                Orders.Add(new OrderData(orderID, customerID, freight, shipCity));
            }
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXVeZpDueDTXjBsW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


## Binding custom data source while exporting

The Grid component provides a convenient way to export data to a Excel or CSV format. With the Excel or CSV export feature, you can define a custom data source while exporting. This allows you to export data that is not necessarily bind to the grid, which can be generated or retrieved based on your application logic.

To export data, you need to define the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property within the [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) object. This property represents the data source that will be used for the Excel or CSV export.

The following example demonstrates how to render custom dataSource during Excel export. By calling the [ExportToExcelAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToExcelAsync_Syncfusion_Blazor_Grids_ExcelExportProperties_) method and passing the `ExcelExportProperties` object through the grid instance, the grid data will be exported to a Excel using the dynamically defined data source.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="Grid" DataSource="@Orders" AllowPaging="true" AllowExcelExport="true" Toolbar="@(new List<string>() { "ExcelExport" })" Height="348">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true" />
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150" />
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150" />
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150" />
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_excelexport")
        {
            ExcelExportProperties exportProperties = new ExcelExportProperties
                {
                    DataSource = Orders
                };
            await this.Grid.ExportToExcelAsync(exportProperties);
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData(int orderID, string customerID, double freight, string shipCity, string shipName)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.Freight = freight;
        this.ShipCity = shipCity;
        this.ShipName = shipName;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 32.38, "Reims", "Vins et alcools Chevalier"));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, "Münster", "Toms Spezialitäten"));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, "Rio de Janeiro", "Hanari Carnes"));
            Orders.Add(new OrderData(10251, "VICTE", 41.34, "Lyon", "Victuailles en stock"));
            Orders.Add(new OrderData(10252, "SUPRD", 51.3, "Charleroi", "Suprêmes délices"));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, "Rio de Janeiro", "Hanari Carnes"));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, "Bern", "Chop-suey Chinese"));
            Orders.Add(new OrderData(10255, "RICSU", 148.33, "Genève", "Richter Supermarkt"));
            Orders.Add(new OrderData(10256, "WELLI", 13.97, "Resende", "Wellington Import Export"));
            Orders.Add(new OrderData(10257, "HILAA", 81.91, "San Cristóbal", "Hila Alimentos"));
            Orders.Add(new OrderData(10258, "ERNSH", 140.51, "Graz", "Ernst Handel"));
            Orders.Add(new OrderData(10259, "CENTC", 3.25, "México D.F.", "Centro comercial"));
            Orders.Add(new OrderData(10260, "OTTIK", 55.09, "Köln", "Ottilies Käseladen"));
            Orders.Add(new OrderData(10261, "QUEDE", 3.05, "Rio de Janeiro", "Que delícia"));
            Orders.Add(new OrderData(10262, "RATTC", 48.29, "Albuquerque", "Rattlesnake Canyon Grocery"));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; } 
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXVoZJXYSzVlckdF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Exporting with custom aggregate

Exporting grid data with custom aggregates allows you to include additional calculated values in the exported file based on specific requirements. This feature is highly valuable for providing a comprehensive view of the data in the exported file, incorporating specific aggregated information for analysis or reporting purposes.

In order to utilize custom aggregation, you need to specify the [type](https://ej2.syncfusion.com/angular/documentation/api/grid/aggregateColumnDirective/#type) property as **Custom** and provide the custom aggregate function in the [customAggregate](https://ej2.syncfusion.com/angular/documentation/api/grid/aggregateColumnDirective/#customaggregate) property.

Within the **customAggregateFn** function, it takes an input data that contains a result property. The function calculates the count of objects in this data where the **ShipCountry** field value is equal to **Brazil** and returns the count with a descriptive label.

The following example shows how to export the grid with a custom aggregate that shows the calculation of the **Brazil** count of the **ShipCountry** column.


{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="Grid" DataSource="@Orders" AllowExcelExport="true" Toolbar="@(new List<string>() { "ExcelExport" })" Height="348">
    <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(OrderData.ShipCountry) Type="AggregateType.Custom">
                    <FooterTemplate>
                        @{
                            <div>
                                <p>Brazil Count: @CustomAggregateFunction()</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Visible="false" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords(); // Populate the grid with initial data
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_excelexport")
        {
   
            await this.Grid.ExportToExcelAsync();
        }
    }

    private int CustomAggregateFunction()
    {
        int Count = Queryable.Count(Orders.Where(x => x.ShipCountry.Contains("Brazil")).AsQueryable());
        return Count;
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData(int orderID, string customerID, DateTime orderDate, double freight, string shipCountry)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.OrderDate = orderDate;
        this.Freight = freight;
        this.ShipCountry = shipCountry;
    }

    public static List<OrderData> GetAllRecords()
    {
        
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", new DateTime(2023, 1, 15), 32.38, "France"));
            Orders.Add(new OrderData(10249, "TOMSP", new DateTime(2023, 2, 10), 11.61, "Germany"));
            Orders.Add(new OrderData(10250, "HANAR", new DateTime(2023, 3, 5), 65.83, "Brazil"));
            Orders.Add(new OrderData(10251, "VICTE", new DateTime(2023, 4, 20), 41.34, "Brazil"));
            Orders.Add(new OrderData(10252, "SUPRD", new DateTime(2023, 5, 25), 51.30, "Belgium"));
            Orders.Add(new OrderData(10253, "HANAR", new DateTime(2023, 6, 15), 58.17, "Brazil"));
            Orders.Add(new OrderData(10254, "CHOPS", new DateTime(2023, 7, 10), 22.98, "Switzerland"));
            Orders.Add(new OrderData(10255, "RICSU", new DateTime(2023, 8, 18), 148.33, "France"));
            Orders.Add(new OrderData(10256, "WELLI", new DateTime(2023, 9, 7), 13.97, "Brazil"));
            Orders.Add(new OrderData(10257, "HILAA", new DateTime(2023, 10, 3), 81.91, "Mexico"));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime OrderDate { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

## Exporting with cell and row spanning 

Exporting data from the Grid with cell and row spanning enables you to maintain cell and row layout in the exported data. This feature is useful when you have merged cells or rows in the Grid and you want to maintain the same structure in the exported file.

To achieve this, you can utilize the [rowSpan](https://ej2.syncfusion.com/angular/documentation/api/grid/queryCellInfoEventArgs/#rowspan) and [colSpan](https://ej2.syncfusion.com/angular/documentation/api/grid/queryCellInfoEventArgs/#colspan) properties in the `queryCellInfo` event of the Grid. This event allows you to define the span values for specific cells. Additionally, you can customize the appearance of the grid cells during the export using the [excelQueryCellInfo](https://ej2.syncfusion.com/angular/documentation/api/grid/#excelquerycellinfo) event of the Grid.

The following example demonstrates how to perform export with cell and row spanning using `queryCellInfo` and `excelQueryCellInfo` events of the Grid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="Grid" DataSource="@Orders" AllowExcelExport="true" Toolbar="@(new List<string>() { "ExcelExport" })" Height="348">
    <GridEvents ExcelQueryCellInfoEvent="ExcelQueryCellInfoHandler" QueryCellInfo="QueryCellInfoHandler" OnToolbarClick="ToolbarClickHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Visible="false" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords(); // Populate the grid with initial data
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_excelexport")
        {

            await this.Grid.ExportToExcelAsync();
        }
    }

    public void ExcelQueryCellInfoHandler(ExcelQueryCellInfoEventArgs<OrderData> args)
    {
        var orderId = (args.Data).OrderID;
        switch (orderId)
        {
            case 10248:
                if ((args.Column).Field == "CustomerID")
                {
                    args.Cell.RowSpan = 2;
                }
                break;
            case 10250:
                if ((args.Column).Field == "CustomerID")
                {
                    args.Cell.ColumnSpan = 2;
                }
                break;
            case 10252:
                if (args.Column.Field == "OrderID")
                {
                    args.Cell.RowSpan = 3;
                }
                break; 
            case 10256:
                if (args.Column.Field == "CustomerID")
                {
                    args.Cell.ColumnSpan = 3;
                }
                break;
            case 10261:
                if (args.Column.Field == "Freight")
                {
                    args.Cell.ColumnSpan = 2;
                }
                break;
        }
    }

    public void QueryCellInfoHandler(Syncfusion.Blazor.Grids.QueryCellInfoEventArgs<OrderData> args)
    {
        var orderId = (args.Data).OrderID;
        switch (orderId)
        {
            case 10248:
                if (args.Column.Field == "CustomerID")
                {
                    args.RowSpan = 2;
                }
                break;
            case 10250:
                if (args.Column.Field == "CustomerID")
                {
                    args.ColSpan = 2;
                }
                break;
            case 10252:
                if (args.Column.Field == "OrderID")
                {
                    args.RowSpan = 3;
                }
                break;
            case 10256:
                if (args.Column.Field == "CustomerID")
                {
                    args.ColSpan = 3;
                }
                break;
            case 10261:
                if (args.Column.Field == "Freight")
                {
                    args.ColSpan = 2;
                }
                break;
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public OrderData(int orderID, string customerID, double freight, string shipCity, string shipCountry)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.Freight = freight;
        this.ShipCity = shipCity;
        this.ShipCountry = shipCountry;
    }
    public static List<OrderData> GetAllRecords()
    {
        return new List<OrderData>
        {
            new OrderData(10248, "VINET", 32.38, "Reims", "France"),
            new OrderData(10249, "TOMSP", 11.61, "Münster", "Germany"),
            new OrderData(10250, "HANAR", 65.83, "Rio de Janeiro", "Brazil"),
            new OrderData(10251, "VICTE", 41.34, "Lyon", "France"),
            new OrderData(10252, "SUPRD", 51.30, "Charleroi", "Belgium"),
            new OrderData(10253, "HANAR", 58.17, "Rio de Janeiro", "Brazil"),
            new OrderData(10254, "CHOPS", 22.98, "Bern", "Switzerland"),
            new OrderData(10255, "RICSU", 148.33, "Genève", "France"),
            new OrderData(10256, "WELLI", 13.97, "Resende", "Brazil"),
            new OrderData(10257, "HILAA", 81.91, "San Cristóbal", "Mexico"),
            new OrderData(10258, "ERNSH", 140.51, "Graz", "Austria"),
            new OrderData(10259, "CENTC", 3.25, "México D.F.", "Mexico"),
            new OrderData(10260, "OTTIK", 55.09, "Köln", "Germany"),
            new OrderData(10261, "QUEDE", 3.05, "Rio de Janeiro", "Brazil"),
            new OrderData(10262, "RATTC", 48.29, "Albuquerque", "USA")
        };
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

# Excel Export in Blazor DataGrid Component

The excel export allows exporting DataGrid data to Excel document. You need to use the
 **ExcelExport** method for exporting. To enable Excel export in the datagrid, set the [AllowExcelExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowExcelExport) property as true.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" Toolbar="@(new List<string>() { "ExcelExport" })" AllowExcelExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

    public List<Order> Orders { get; set; }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            await this.DefaultGrid.ExcelExport();
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
}
```

## To customize excel export

The excel export provides an option to customize mapping of the datagrid to excel document.

### Export current page

The excel export provides an option to export the current page into excel. To export current page, define **exportType** to **CurrentPage**.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" Toolbar="@(new List<string>() { "ExcelExport" })" AllowExcelExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

    public List<Order> Orders { get; set; }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            ExcelExportProperties ExportProperties = new ExcelExportProperties();
            ExportProperties.ExportType = ExportType.CurrentPage;
            await this.DefaultGrid.ExcelExport(ExportProperties);
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
}
```

### Export hidden columns

The excel export provides an option to export hidden columns of DataGrid by defining [IncludeHiddenColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_IncludeHiddenColumn) as **true**.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" Toolbar="@(new List<string>() { "ExcelExport" })" AllowExcelExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Visible="false" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

    public List<Order> Orders { get; set; }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            ExcelExportProperties ExportProperties = new ExcelExportProperties();
            ExportProperties.IncludeHiddenColumn = true;
            await this.DefaultGrid.ExcelExport(ExportProperties);
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
}
```

### Export the selected records only

The Grid has an option to export the selected records in an excel exported document. This can be achieved by using the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_DataSource) property of the [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) class and the [GetSelectedRecordsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetSelectedRecordsAsync) method of the Grid.

In the following sample, selected records will be gotten from the `GetSelectedRecordsAsync` method and provided to the `DataSource` property of `ExcelExportProperties`. Then pass this ExcelExportProperties class to the [ExportToExcelAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToExcelAsync_Syncfusion_Blazor_Grids_ExcelExportProperties_System_Nullable_System_Boolean__System_Object_System_Nullable_System_Boolean__) method to get the selected records in the exported document.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" AllowExcelExport="true" AllowPaging="true"
        Toolbar="@(new List<string>() { "ExcelExport" })" AllowSelection="true">
    <GridEvents OnToolbarClick="OnToolbarClick" TValue="Order"></GridEvents>
    <GridSelectionSettings Type="SelectionType.Multiple"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;
    public List<Order> Orders { get; set; }
    public async Task OnToolbarClick(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_excelexport") // Id is combination of Grid's ID and itemname.
        {
            ExcelExportProperties ExcelProperties = new ExcelExportProperties();
            var selectedRecord = await DefaultGrid.GetSelectedRecordsAsync();
            if(selectedRecord.Count() > 0)
            {
                ExcelProperties.DataSource = selectedRecord;
            }
            else
            {
                ExcelProperties.DataSource = Orders;
            }
            await this.DefaultGrid.ExportToExcelAsync(ExcelProperties);
        }
    }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 15).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            ShipCountry = (new string[] { "Germany", "UK", "USA", "Italy", "France" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCountry { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

### Add custom text in header/footer

You can add text and customize its styles either in the header or footer of an exported excel document by using the [Header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_Header) and [Footer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_Footer) properties of the [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) class.

The following sample code demonstrates adding custom text and customizing its styles in the header section of the exported document,

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker @ref="DateRange" TValue="DateTime?" StartDate="@StartValue" EndDate="@EndValue"></SfDateRangePicker>

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "ExcelExport" })" AllowExcelExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfDateRangePicker<DateTime?> DateRange;
    private SfGrid<Order> DefaultGrid;
    public List<Order> Orders { get; set; }
    public DateTime? StartValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28);
    public DateTime? EndValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 29);

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_excelexport")  //Id is combination of Grid's ID and itemname      
        {
            ExcelExportProperties  ExportProperties = new ExcelExportProperties ();
            ExcelHeader header = new ExcelHeader();
            header.HeaderRows = 2;
            List<ExcelCell> cell = new List<ExcelCell>
            {
                new ExcelCell() { RowSpan= 2,ColSpan=5 , Value= "PO Report from " + DateRange.StartDate.ToString() + " to " + DateRange.EndDate.ToString() + " Vendor All", Style = new ExcelStyle() { Bold = true, FontSize = 13, Italic= true }  }
            };

            List<ExcelRow> HeaderContent = new List<ExcelRow>
            {
                new ExcelRow() {  Cells = cell, Index = 1 }
            };
            header.Rows = HeaderContent;
            ExportProperties.Header = header;
            await this.DefaultGrid.ExcelExport(ExportProperties);
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
}
```

![Adding custom text in header/footer in Blazor DataGrid](./images/blazor-datagrid-custom-text-in-header.png)

<!-- Show or hide columns on exported excel

You can show a hidden column or hide a visible column while exporting the DataGrid by customizing the visibility settings.

This is demonstrated in the below sample code where initially the **CustomerID** is hidden. While exporting, we have changed CustomerID to visible column and Freight as hidden column. Then in the `ExcelExportComplete` event, we have reversed the column's visibility state back to the previous state.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton OnClick="ExcelExport" Content="Excel Export"></SfButton>
<SfGrid @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" AllowExcelExport="true" AllowPaging="true">
    <GridEvents ExcelExportComplete="OnExcelExport" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Visible=@CustomerIDVisibility Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Visible=@FreightVisibility Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

    public List<Order> Orders { get; set; }

    public bool CustomerIDVisibility = false;

    public bool FreightVisibility = true;

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

    public void ExcelExport()
    {
        CustomerIDVisibility = true;
        FreightVisibility = false;
        this.DefaultGrid.ExcelExport();
    }
    public void OnExcelExport()
    {
        CustomerIDVisibility = false;
        FreightVisibility = true;
    }
}
``` -->

### Theme

The excel export provides an option to include theme for exported excel document.

To apply theme in exported Excel, define the **theme** in export properties.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" Toolbar="@(new List<string>() { "ExcelExport" })" AllowExcelExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

    public List<Order> Orders { get; set; }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            ExcelExportProperties ExcelProperties = new ExcelExportProperties();
            ExcelTheme Theme = new ExcelTheme();
            ExcelStyle ThemeStyle = new ExcelStyle()
            {
                FontName = "Segoe UI",
                FontColor = "#666666",
                FontSize = 20
            };
            Theme.Header = ThemeStyle;
            Theme.Record = ThemeStyle;
            Theme.Caption = ThemeStyle;
            ExcelProperties.Theme = Theme;
            await this.DefaultGrid.ExcelExport(ExcelProperties);
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
}
```

N> By default, material theme is applied to exported excel document.

### Customizing the background color for a Grid in an exported Excel document

You can set the background color for a Grid in the exported document using the [Theme](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_Theme) property of [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) class.

This can be demonstrated using the following sample:

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" Toolbar="@(new List<string>() { "ExcelExport" })" AllowExcelExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;
    public List<Order> Orders { get; set; }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            ExcelExportProperties ExcelProperties = new ExcelExportProperties();
            ExcelTheme Theme = new ExcelTheme();
            ExcelStyle ThemeStyle = new ExcelStyle()
            {
                BackColor = "#C67878"
            };
            Theme.Header = ThemeStyle;
            Theme.Record = ThemeStyle;
            Theme.Caption = ThemeStyle;
            ExcelProperties.Theme = Theme;
            await this.DefaultGrid.ExcelExport(ExcelProperties);
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
}

```

![Customizing the background color for a Blazor DataGrid in an exported Excel document](./images/blazor-datagrid-customize-background-color.png)

N> [View Sample in GitHub.](https://github.com/SyncfusionExamples/blazor-datagrid-customize-background-color-for-grid-exported-excel-file)

### Customizing the background color for a particular column in an exported Excel document

You can set the background color for a particular column in the exported document. This can be achieved by the [ExcelQueryCellInfoEvent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ExcelQueryCellInfoEvent) of the Grid.

This can be demonstrated using the following sample:

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" Toolbar="@(new List<string>() { "ExcelExport" })" AllowExcelExport="true" AllowPaging="true">
    <GridEvents ExcelQueryCellInfoEvent="ExcelQueryCellInfoHandler" OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;
    public List<Order> Orders { get; set; }

    public void ExcelQueryCellInfoHandler(ExcelQueryCellInfoEventArgs<Order> args)
    {
        // Here you can customize your code
        if (args.Column.Field == "CustomerID") {
            if (args.Data.CustomerID == "ALFKI") 
            {
                args.Cell.CellStyle.BackColor = "#DC143C";
            }
            else if (args.Data.CustomerID == "ANANTR") 
            {
                args.Cell.CellStyle.BackColor = "#FF0000";
            }
            else if (args.Data.CustomerID == "ANTON")
            {
                args.Cell.CellStyle.BackColor = "#FFD700";
            }
            else if (args.Data.CustomerID == "BLONP")
            {
                args.Cell.CellStyle.BackColor = "#FFFF00";
            }
            else if (args.Data.CustomerID == "BOLID")
            {
                args.Cell.CellStyle.BackColor = "#7CFC00";
            }
        }
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            await this.DefaultGrid.ExcelExport();
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
}

```

![Customizing the background color for a particular column in an exported Excel document](./images/blazor-datagrid-customize-background-color-for-particular-column.png)

N> [View Sample in GitHub.](https://github.com/SyncfusionExamples/blazor-datagrid-customize-background-color-for-particular-column)

<!-- To add header and footer

The excel export provides an option to include header and footer content for exported excel document using the [`ExcelExportProperties`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) class.

This is demonstrated in the below sample code,

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton OnClick="ExcelExport" Content="Excel Export"></SfButton>
<SfGrid @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" AllowExcelExport="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

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

    public void ExcelExport()
    {
        ExcelExportProperties ExportProperties = new ExcelExportProperties();

        ExcelHeader Header = new ExcelHeader();

        ExcelFooter Footer = new ExcelFooter();

        List<ExcelRow> HeaderRows = new List<ExcelRow>()
        {
            new ExcelRow() {
                Cells = new List<ExcelCell>() {
                    new ExcelCell() { ColSpan = 4, Value = "Northwind Traders", Style = new ExcelStyle() {
                        FontColor = "#C67878",
                        FontSize = 20,
                        HAlign = ExcelHAlign.Center,
                        Bold = true
                    }
                    }
                }
            },
            new ExcelRow() {
                Cells = new List<ExcelCell>() {
                    new ExcelCell() { ColSpan = 4, Value = "2501 Aerial Center Parkway", Style = new ExcelStyle() {
                        FontColor = "#C67878",
                        FontSize = 15,
                        HAlign = ExcelHAlign.Center,
                        Bold = true
                    }
                    }
                }
            },
            new ExcelRow() {
                Cells = new List<ExcelCell>() {
                    new ExcelCell() { ColSpan = 4, Value = "Suite 200 Morrisville, NC 27560 USA", Style = new ExcelStyle() {
                        FontColor = "#C67878",
                        FontSize = 15,
                        HAlign = ExcelHAlign.Center,
                        Bold = true
                    }
                    }
                }
            },
            new ExcelRow() {
                Cells = new List<ExcelCell>() {
                    new ExcelCell() { ColSpan = 4, Value = "Tel +1 888.936.8638 Fax +1 919.573.0306", Style = new ExcelStyle() {
                        FontColor = "#C67878",
                        FontSize = 15,
                        HAlign = ExcelHAlign.Center,
                        Bold = true
                    }
                    }
                }
            },
            new ExcelRow() {
                Cells = new List<ExcelCell>() {
                    new ExcelCell() { ColSpan = 4, Hyperlink = new Hyperlink() { 
                        Target = "https://www.northwind.com/",
                        DisplayText = "www.northwind.com"
                    },
                        Style = new ExcelStyle() {
                        HAlign = ExcelHAlign.Center,
                    }
                    }
                }
            },
            new ExcelRow() {
                Cells = new List<ExcelCell>() {
                    new ExcelCell() { ColSpan = 4, Hyperlink = new Hyperlink() { 
                        Target = "mailto:support@northwind.com",
                        DisplayText = "Support"
                    },
                        Style = new ExcelStyle() {
                        HAlign = ExcelHAlign.Center,
                    }
                    }
                }
            }
        };
        Header.HeaderRows = 6;
        Header.Rows = HeaderRows;

        List<ExcelRow> FooterRows = new List<ExcelRow>()
        {
            new ExcelRow() {
                Cells = new List<ExcelCell>() {
                    new ExcelCell() { ColSpan = 4, Value = "Thank you for your business!", Style = new ExcelStyle() {
                        HAlign = ExcelHAlign.Center,
                        Bold = true
                    }
                    }
                }
            },
            new ExcelRow() {
                Cells = new List<ExcelCell>() {
                    new ExcelCell() { ColSpan = 4, Value = "!Visit Again!", Style = new ExcelStyle() {
                        HAlign = ExcelHAlign.Center,
                        Bold = true
                    }
                    }
                }
            }
        };
        Footer.FooterRows = 2;
        Footer.Rows = FooterRows;

        ExportProperties.Header = Header;
        ExportProperties.Footer = Footer;

        this.DefaultGrid.ExcelExport(ExportProperties);
    }
}
``` -->

### File name for exported document

You can assign the file name for the exported document by defining **fileName** property in excel export properties.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" Toolbar="@(new List<string>() { "ExcelExport" })" AllowExcelExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

    public List<Order> Orders { get; set; }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            ExcelExportProperties ExcelProperties = new ExcelExportProperties();
            ExcelProperties.FileName = "new.xlsx";
            await this.DefaultGrid.ExcelExport(ExcelProperties);
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
}
```

### Add additional worksheets to excel file while exporting

Additional worksheets can be added to the excel file while exporting using the [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html).

In the following sample, you can add the additional worksheets to excel file by creating a workbook using `ExcelExportProperties`. Additional sheets will be added along with the Grid data.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.ExcelExport

@{
    var Tool = (new List<string>() { "ExcelExport"});
}

<SfGrid @ref="DefaultGrid" DataSource="@Orders" Toolbar=@Tool AllowExcelExport="true">
   <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;
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
    public async Task ToolbarClickHandler()
    {
        ExcelExportProperties ExportProperties = new ExcelExportProperties();
        // Add a new workbook to the excel file that contains only 1 worksheet.
        ExportProperties.Workbook = new Workbook();
        // Add additional worksheets.
        ExportProperties.Workbook.Worksheets.Add();
        ExportProperties.Workbook.Worksheets.Add();
        // Define the Gridsheet index where Grid data must be exported.
        ExportProperties.GridSheetIndex = 0;
        // Export the document. 
        await this.DefaultGrid.ExcelExport(ExportProperties);
    }
}

```

## Exporting grouped records

The excel export provides outline option for grouped records which hides the detailed data for better viewing.
In datagrid, we have provided the outline option for the exported document when the data's are grouped.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" AllowGrouping="true" Toolbar="@(new List<string>() { "ExcelExport" })" AllowExcelExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridGroupSettings Columns="@(new string[] {"OrderDate"})"></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Visible="false" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

    public List<Order> Orders { get; set; }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            await this.DefaultGrid.ExcelExport();
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
}
```

### Limitations

Microsoft Excel permits up to seven nested levels in outlines. So that in the datagrid we can able to provide only up to seven nested levels and if it exceeds more than seven levels then the document will be exported without outline option. Refer the [Microsoft Limitation](https://learn.microsoft.com/en-us/sql/reporting-services/report-builder/exporting-to-microsoft-excel-report-builder-and-ssrs?view=sql-server-2017#ExcelLimitations)

## How to export the Grid with specific columns

You can export the Excel grid with specific columns instead of all columns which are defined in the Grid definition. To achieve this scenario by using [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_Columns) property of the [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) class.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" AllowExcelExport="true" AllowPaging="true" Toolbar="@(new List<string>() { "ExcelExport" })">
    <GridEvents OnToolbarClick="OnToolbarClick" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

    public List<Order> Orders { get; set; }

    public async Task OnToolbarClick(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            ExcelExportProperties ExportProperties = new ExcelExportProperties();
            List<GridColumn> ExportColumns = new List<GridColumn>();
#pragma warning disable BL0005
            ExportColumns.Add(new GridColumn() { Field = "CustomerID", HeaderText = "Customer Name", Width = "100" });
            ExportColumns.Add(new GridColumn() { Field = "OrderDate", HeaderText = "Date", Width = "120", Format = "d" });
            ExportColumns.Add(new GridColumn() { Field = "Freight", HeaderText = "Freight", Width = "120", Format = "C2", TextAlign = TextAlign.Right });
#pragma warning restore BL0005
            ExportProperties.Columns = ExportColumns;
            await this.DefaultGrid.ExcelExport(ExportProperties);
        }
    }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 15).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            ShipCountry = (new string[] { "Germany", "UK", "USA", "Italy", "France" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCountry { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

<!-- Multiple datagrid exporting

The excel export provides option to export multiple datagrid data in the same excel file.

Same sheet

The excel export provides support to export multiple grids in the same sheet. To export in same sheet, set the [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.MultipleExport.html#Syncfusion_Blazor_Grids_MultipleExport_Type) value of [`MultipleExport`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_MultipleExport) property as **AppendToSheet** in the [`ExcelExportProperties`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) class. It is possible to provide blank rows between the grids. The blank rows count can be set by defining the value in [`BlankRows`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.MultipleExport.html#Syncfusion_Blazor_Grids_MultipleExport_BlankRows) of [`MultipleExport`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_MultipleExport) property. 

This is demonstrated in the below sample code block,

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton OnClick="ExcelExport" Content="Excel Export"></SfButton>
<SfGrid @ref="FirstGrid" DataSource="@Orders1" AllowExcelExport="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
<SfGrid @ref="SecondGrid" DataSource="@Orders2" AllowExcelExport="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> FirstGrid;
    private SfGrid<Order> SecondGrid;

    public List<Order> Orders1 { get; set; }
    public List<Order> Orders2 { get; set; }

    protected override void OnInitialized()
    {
        Orders1 = Enumerable.Range(1, 15).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
        Orders2 = Enumerable.Range(1, 15).Select(x => new Order()
        {
            OrderID = 2000 + x,
            CustomerID = (new string[] { "JANET", "MARGARET", "NANCY", "STEVEN", "VINET" })[new Random().Next(5)],
            Freight = 3.1 * x,
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

    public void ExcelExport()
    {
        ExcelExportProperties ExcelProperties = new ExcelExportProperties();
        
        MultipleExport MultipleExportProperties = new MultipleExport()
        {
            Type = MultipleExportType.AppendToSheet,
            BlankRows = 2
        };

        ExcelProperties.MultipleExport = MultipleExportProperties;

        var ExportData = this.FirstGrid.ExcelExport(ExcelProperties, true);
        ExportData.ContinueWith((ExcelData) =>
        {
            this.SecondGrid.ExcelExport(ExcelProperties, false, ExcelData);
        });
    }
}
```

> By default, [`BlankRows`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.MultipleExport.html#Syncfusion_Blazor_Grids_MultipleExport_BlankRows) value is 5. -->

<!-- New sheet

The excel export provides support to export multiple grids in new sheet. To export in new sheet, set the [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.MultipleExport.html#Syncfusion_Blazor_Grids_MultipleExport_Type) value of [`MultipleExport`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_MultipleExport) property as **NewSheet** in the [`ExcelExportProperties`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) class.

This is demonstrated in the below sample code block,

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton OnClick="ExcelExport" Content="Excel Export"></SfButton>
<SfGrid @ref="FirstGrid" DataSource="@Orders1" AllowExcelExport="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
<SfGrid @ref="SecondGrid" DataSource="@Orders2" AllowExcelExport="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> FirstGrid;
    private SfGrid<Order> SecondGrid;

    public List<Order> Orders1 { get; set; }
    public List<Order> Orders2 { get; set; }

    protected override void OnInitialized()
    {
        Orders1 = Enumerable.Range(1, 15).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
        Orders2 = Enumerable.Range(1, 15).Select(x => new Order()
        {
            OrderID = 2000 + x,
            CustomerID = (new string[] { "JANET", "MARGARET", "NANCY", "STEVEN", "VINET" })[new Random().Next(5)],
            Freight = 3.1 * x,
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

    public void ExcelExport()
    {
        ExcelExportProperties ExcelProperties = new ExcelExportProperties();
        
        MultipleExport MultipleExportProperties = new MultipleExport()
        {
            Type = MultipleExportType.NewSheet
        };

        ExcelProperties.MultipleExport = MultipleExportProperties;

        var ExportData = this.FirstGrid.ExcelExport(ExcelProperties, true);
        ExportData.ContinueWith((ExcelData) =>
        {
            this.SecondGrid.ExcelExport(ExcelProperties, false, ExcelData);
        });
    }
}
``` -->

## Custom data source

Excel export provides an option to define the datasource dynamically before exporting. To export data dynamically, define it in the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_DataSource) property of the [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) class.

The following sample code demonstrates dynamically modifying the data source before exporting it,

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" AllowExcelExport="true" AllowPaging="true" Toolbar="@(new List<string>() { "ExcelExport" })">
    <GridEvents OnToolbarClick="OnToolbarClick" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

    public List<Order> Orders { get; set; }

    public async Task OnToolbarClick(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            ExcelExportProperties ExcelProperties = new ExcelExportProperties();
            ExcelProperties.DataSource = Orders;
            await this.DefaultGrid.ExcelExport(ExcelProperties);
        }
    }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 15).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            ShipCountry = (new string[] { "Germany", "UK", "USA", "Italy", "France" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCountry { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

## Customizing columns

Excel export provides an option to define the columns dynamically before exporting. You can define the dynamic columns using [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_Columns) property of the [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) class.

The following sample code demonstrates dynamically adding `ShipCountry` column in the exported excel file,

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" AllowExcelExport="true" AllowPaging="true" Toolbar="@(new List<string>() { "ExcelExport" })">
    <GridEvents OnToolbarClick="OnToolbarClick" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

    public List<Order> Orders { get; set; }

    public async Task OnToolbarClick(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            ExcelExportProperties ExportProperties = new ExcelExportProperties();
            var columns = await DefaultGrid.GetColumns();     //get the columns available in Grid
            columns.Add(new GridColumn() { Field = "ShipCountry" });      //adding additional column
            ExportProperties.Columns = columns;
            await DefaultGrid.ExcelExport(ExportProperties);
        }
    }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 15).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            ShipCountry = (new string[] { "Germany", "UK", "USA", "Italy", "France" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCountry { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

N> You can refer to our [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap5) to understand how to present and manipulate data.

<!-- Export the hierarchy datagrid

The datagrid has option to export hierarchy datagrid to the excel document. By default, datagrid exports the master datagrid with expanded child grids alone. The exporting option can be modified by using the [`HierarchyExportMode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_HierarchyExportMode) property of the [`ExcelExportProperties`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) class.

The available options are,

| Mode | Behavior |
|-------|---------|
| Expanded | Exports the master datagrid with expanded child grids.|
| All | Exports the master datagrid with all the child grids.|
| None | Exports the master datagrid alone. |

The following sample code demonstrates modifying the export options for hierarchy datagrid,

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

@{
    GridModel<object> ChildGridData = new GridModel<object>()
    {
        DataSource = Orders,
        QueryString = "EmployeeID",
        Columns = new List<GridColumn> {
            new GridColumn() { Field="OrderID", HeaderText="OrderID", Width="110" },
            new GridColumn() { Field="CustomerName", HeaderText="CustomerName", Width="110"},
            new GridColumn() { Field="ShipCountry", HeaderText="ShipCountry", Width="110" }
        }
    };
}

<SfButton OnClick="ExcelExport" Content="Excel Export"></SfButton>
<SfGrid @ref="DefaultGrid" DataSource="@Employees" ChildGrid="ChildGridData" Height="315px" AllowExcelExport="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.EmployeeID) HeaderText="EmployeeID" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(EmployeeData.FirstName) HeaderText="First Name" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(EmployeeData.City) HeaderText="Last Name" Width="110"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Country) HeaderText="Country" Width="110"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<EmployeeData> DefaultGrid;

    public List<EmployeeData> Employees { get; set; }

    public List<Order> Orders { get; set; }

    public string[] ExportMode = new string[] { "Expanded" };

    protected override void OnInitialized()
    {
        Employees = Enumerable.Range(1, 9).Select(x => new EmployeeData()
        {
            EmployeeID = x,
            FirstName = (new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven" })[new Random().Next(5)],
            City = (new string[] { "Seattle", "Tacoma", "Redmond", "Kirkland", "London" })[new Random().Next(5)],
            Country = (new string[] { "USA", "UK" })[new Random().Next(2)],
        }).ToList();

        Orders = Enumerable.Range(1, 9).Select(x => new Order()
        {
            EmployeeID = x,
            OrderID = 1000 + x,
            CustomerName = (new string[] { "Nancy", "Andrew" })[new Random().Next(2)],
            ShipCountry = (new string[] { "USA", "UK" })[new Random().Next(2)],
        }).ToList();
    }

    public class EmployeeData
    {
        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime? HireDate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    public class Order
    {
        public int? EmployeeID { get; set; }
        public int? OrderID { get; set; }
        public string CustomerName { get; set; }
        public string ShipCountry { get; set; }
    }

    public void ExcelExport()
    {
        ExcelExportProperties ExcelProperties = new ExcelExportProperties();
        ExcelProperties.HierarchyExportMode = ExportMode;
        this.DefaultGrid.ExcelExport(ExcelProperties);
    }
}
``` -->

## Exporting Grid Data as Stream

### Exporting Grid Data as Memory Stream
This section shows how to invoke a [ExportToExcelAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToExcelAsync_System_Int32_System_Int32_System_Int32_) method to export an excel workbook as a memory stream.

To obtain the export file as a memory stream, set the `asMemoryStream` parameter to true within the `ExportToExcelAsync` method.

The provided example showcases the process of exporting the file as a memory stream and sending the byte to initiate a browser download.

**Step 1**: **Create a JavaScript file to execute browser downloads and copy the code below**

```cshtml
function saveAsFile(filename, bytesBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + bytesBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}
```
**Step 2**: **Invoke the JavaScript file to carry out browser downloads using the memory stream**

```cshtml
@using Syncfusion.Blazor.Grids
@using System.IO;
@using Syncfusion.Pdf
@using Syncfusion.XlsIO
@using Syncfusion.PdfExport;
@using Syncfusion.ExcelExport;
@inject IJSRuntime JSRuntime

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "ExcelExport"})" AllowExcelExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;
    public List<Order> Orders { get; set; }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {       
        if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {           
           MemoryStream streamDoc =  await DefaultGrid.ExportToExcelAsync(asMemoryStream: true);
           await JSRuntime.InvokeVoidAsync("saveAsFile", new object[] { "ExcelStream.xlsx", Convert.ToBase64String(streamDoc.ToArray()), true });
        }
    }
    public List<Order> GetAllRecords()
    {
        List<Order> data = new List<Order>();
        int count = 1000;
        for (int i = 0; i < 15; i++)
        {
            data.Add(new Order() { OrderID = count + 1, CustomerID = "ALFKI", OrderDate = new DateTime(1995, 05, 15), Freight = 25.7 * 2 });
            data.Add(new Order() { OrderID = count + 2, CustomerID = "ANANTR", OrderDate = new DateTime(1994, 04, 04), Freight = 26.7 * 2 });
            data.Add(new Order() { OrderID = count + 3, CustomerID = "BLONP", OrderDate = new DateTime(1993, 03, 10), Freight = 27.7 * 2 });
            data.Add(new Order() { OrderID = count + 4, CustomerID = "ANTON", OrderDate = new DateTime(1992, 02, 14), Freight = 28.7 * 2 });
            data.Add(new Order() { OrderID = count + 5, CustomerID = "BOLID", OrderDate = new DateTime(1991, 01, 18), Freight = 29.7 * 2 });
            count += 5;
        }
        return data;
    }
    protected override void OnInitialized()
    {
        Orders = GetAllRecords();
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

### Converting Memory Stream to File Stream for Excel Export

This section explains the process of converting a memory stream obtained from the `ExportToExcelAsync` method into a file stream to export excel workbook.

The example provided demonstrates this process of exporting the excel workboox from the file stream.

 ```cshtml
@using Syncfusion.Blazor.Grids
@using System.IO;
@using Syncfusion.Pdf
@using Syncfusion.XlsIO
@using Syncfusion.PdfExport;
@using Syncfusion.ExcelExport;
@inject IJSRuntime JSRuntime

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "ExcelExport"})" AllowExcelExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;
    public List<Order> Orders { get; set; }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {       
        if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            MemoryStream streamDoc =  await DefaultGrid.ExportToExcelAsync(asMemoryStream: true);
            
            //Create a copy of streamDoc1 to read the memory stream
            MemoryStream copyOfStreamDoc1 = new MemoryStream(streamDoc.ToArray());

            //For creating the exporting location with file name, for this need to specify the physical exact path of the file
            string filePaths = "C:Users/abc/Downloads/SampleTestExcel.xlsx";

            // Create a FileStream to write the memoryStream contents to a file
            using (FileStream fileStream = File.Create(filePaths))
            {
                // Copy the MemoryStream data to the FileStream
                copyOfStreamDoc1.CopyTo(fileStream);
            }
        }
    }
    public List<Order> GetAllRecords()
    {
        List<Order> data = new List<Order>();
        int count = 1000;
        for (int i = 0; i < 15; i++)
        {
            data.Add(new Order() { OrderID = count + 1, CustomerID = "ALFKI", OrderDate = new DateTime(1995, 05, 15), Freight = 25.7 * 2 });
            data.Add(new Order() { OrderID = count + 2, CustomerID = "ANANTR", OrderDate = new DateTime(1994, 04, 04), Freight = 26.7 * 2 });
            data.Add(new Order() { OrderID = count + 3, CustomerID = "BLONP", OrderDate = new DateTime(1993, 03, 10), Freight = 27.7 * 2 });
            data.Add(new Order() { OrderID = count + 4, CustomerID = "ANTON", OrderDate = new DateTime(1992, 02, 14), Freight = 28.7 * 2 });
            data.Add(new Order() { OrderID = count + 5, CustomerID = "BOLID", OrderDate = new DateTime(1991, 01, 18), Freight = 29.7 * 2 });
            count += 5;
        }
        return data;
    }
    protected override void OnInitialized()
    {
        Orders = GetAllRecords();
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

### Merging Two Excel Memory Streams

This section explains the process of combining two memory stream files and exporting the resulting merged file as a excel workbook, To copy a worksheet between workbooks or within the same workbook, utilize the capabilities of the package  [Syncfusion.Blazor.XlslO](https://www.nuget.org/packages/Syncfusion.XlsIO.Net.Core/).

The example below demonstrates how to merge two memory streams and export that merged memory stream for browser download.

In this example, there are two memory streams: *streamDoc1* and *streamDoc2*. streamDoc1 represents the normal grid memory stream, while streamDoc2 contains the memory stream of a customized grid using the [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) class. The merging process combines the contents of streamDoc1 with streamDoc2, resulting in a combined workbook saved as a memory stream. This merged memory stream is then utilized to initiate the browser download.

 ```cshtml
@using Syncfusion.Blazor.Grids
@using System.IO;
@using Syncfusion.Pdf
@using Syncfusion.XlsIO
@using Syncfusion.PdfExport;
@using Syncfusion.ExcelExport;
@inject IJSRuntime JSRuntime

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "ExcelExport"})" AllowExcelExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;
    public List<Order> Orders { get; set; }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {       
        if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            //Merging two memory stream for excel export
            MemoryStream mergedStream = new MemoryStream();

            MemoryStream streamDoc1 = await DefaultGrid.ExportToExcelAsync(asMemoryStream: true);
            //Create a copy of streamDoc1 to access the memory stream
            MemoryStream copyOfStreamDoc1 = new MemoryStream(streamDoc1.ToArray());
            
            //Cusotmized grid memory stream
            ExcelExportProperties ExcelProperties = new ExcelExportProperties();
            ExcelTheme Theme = new ExcelTheme();
            ExcelStyle ThemeStyle = new ExcelStyle()
            {
                BackColor = "#C67878"
            };
            Theme.Header = ThemeStyle;
            Theme.Record = ThemeStyle;
            ExcelProperties.Theme = Theme;
            MemoryStream streamDoc2 = await DefaultGrid.ExportToExcelAsync(asMemoryStream: true, ExcelProperties);
            //Create a copy of streamDoc2 to access the memory stream
            MemoryStream copyOfStreamDoc2 = new MemoryStream(streamDoc2.ToArray());

            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;
                IWorkbook workbook1 = application.Workbooks.Open(copyOfStreamDoc1);
                IWorkbook workbook2 = application.Workbooks.Open(copyOfStreamDoc2);

                //Copy first worksheet from the workbook1 workbook to the workbook2 workbook
                workbook2.Worksheets.AddCopy(workbook1.Worksheets[0]);
                workbook2.ActiveSheetIndex = 1;

                //Saving merged workbook as memorystream
                workbook2.SaveAs(mergedStream);
            }

            await JSRuntime.InvokeVoidAsync("saveAsFile", new object[] { "MemoryStreamMerge.xlsx", Convert.ToBase64String(mergedStream.ToArray()), true });
        }
    }
    public List<Order> GetAllRecords()
    {
        List<Order> data = new List<Order>();
        int count = 1000;
        for (int i = 0; i < 15; i++)
        {
            data.Add(new Order() { OrderID = count + 1, CustomerID = "ALFKI", OrderDate = new DateTime(1995, 05, 15), Freight = 25.7 * 2 });
            data.Add(new Order() { OrderID = count + 2, CustomerID = "ANANTR", OrderDate = new DateTime(1994, 04, 04), Freight = 26.7 * 2 });
            data.Add(new Order() { OrderID = count + 3, CustomerID = "BLONP", OrderDate = new DateTime(1993, 03, 10), Freight = 27.7 * 2 });
            data.Add(new Order() { OrderID = count + 4, CustomerID = "ANTON", OrderDate = new DateTime(1992, 02, 14), Freight = 28.7 * 2 });
            data.Add(new Order() { OrderID = count + 5, CustomerID = "BOLID", OrderDate = new DateTime(1991, 01, 18), Freight = 29.7 * 2 });
            count += 5;
        }
        return data;
    }
    protected override void OnInitialized()
    {
        Orders = GetAllRecords();
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


## See also
* [How to import data from Excel sheet and bind to Blazor Grid?](https://www.syncfusion.com/kb/13131/how-to-import-data-from-excel-sheet-and-bind-to-blazor-grid)
* [Export data from Grid to Excel in different worksheets in Blazor](https://www.syncfusion.com/forums/175479/export-data-to-excel-in-different-worksheets)

