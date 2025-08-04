---
layout: post
title: Excel Export in Blazor DataGrid | Syncfusion
description: Checkout and learn here all about Excel Export in Syncfusion Blazor DataGrid Component and much more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Excel exporting in Blazor DataGrid

The Excel or CSV exporting feature in the Syncfusion Blazor DataGrid allows you to export the Grid data to an Excel or CSV document. This can be useful when you need to share or analyze the data in a spreadsheet format.

To enable Excel export in the Grid, you need to set the [AllowExcelExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowExcelExport) property to **true**. This property is responsible for enabling the Excel or CSV export option in the Grid.

To initiate the Excel export process, you need to use the [ExportToExcelAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToExcelAsync_System_Boolean_Syncfusion_Blazor_Grids_ExcelExportProperties_) method provided by the Grid. This method is responsible for exporting the Grid data to an Excel document.

> To initiate the CSV export process, you need to use the [ExportToCsvAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToCsvAsync_System_Boolean_Syncfusion_Blazor_Grids_ExcelExportProperties_) method provided by the Grid. This method is responsible for exporting the Grid data to an CSV document.

The following example demonstrates how to perform a Excel or CSV export action in the Grid:

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
        if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname.
        {
            await Grid.ExportToExcelAsync();
        }
        else if (args.Item.Id == "Grid_csvexport")
        {
            await Grid.ExportToCsvAsync();
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

Showing a spinner while exporting in the Syncfusion Blazor DataGrid enhances the experience by displaying a spinner during the export process. This feature provides a visual indication of the export progress, improving the understanding of the exporting process.

To show or hide a spinner while exporting the Grid, you can utilize the [ShowSpinnerAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ShowSpinnerAsync) and [HideSpinnerAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_HideSpinnerAsync) methods provided by the Grid within the `OnToolbarClick` event.

The [OnToolbarClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnToolbarClick) event is triggered when a toolbar item in the Grid is clicked. Within the event handler, the code checks if the clicked **item** is related with Excel or CSV export, specifically the **Grid_excelexport** or **Grid_csvexport** item. If a match is found, the `ShowSpinnerAsync` method is used on the Grid instance to display the spinner.

To hide the spinner after the exporting is completed, bind the [ExportComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ExportComplete) event and use the `HideSpinnerAsync` method on the Grid instance to hide the spinner.

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
        if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname.
        {
            // Show spinner while exporting.
            await Grid.ShowSpinnerAsync();
            await Grid.ExportToExcelAsync();
        }
    }

    public void ExportCompleteHandler(object args)
    {
        // Hide spinner after export completes.
        Grid.HideSpinnerAsync();
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjLetTiMCmRvgSSs?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Binding custom data source while exporting

The Syncfusion Blazor DataGrid provides a convenient way to export data to a Excel or CSV format. With the Excel or CSV export feature, you can define a custom data source while exporting. This allows you to export data that is not necessarily bind to the Grid, which can be generated or retrieved based on your application logic.

To export data, you need to define the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_DataSource) property within the [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) object. This property represents the data source that will be used for the Excel or CSV export.

The following example demonstrates how to use a custom data source during Excel export. In the [OnToolbarClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnToolbarClick) event handler, by calling [ExportToExcelAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToExcelAsync_Syncfusion_Blazor_Grids_ExcelExportProperties_) and passing an `ExcelExportProperties` object to the Grid instance, the Grid data will be exported to Excel using the dynamically defined data source:

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
        if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname.
        {
            var filteredData = Orders.Where(x => x.OrderID <= 10255).ToList();
            ExcelExportProperties exportProperties = new ExcelExportProperties
            {
                DataSource = filteredData
            };
            await Grid.ExportToExcelAsync(exportProperties);
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData(int orderID, string customerID, string shipCity, string shipName)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.ShipCity = shipCity;
        this.ShipName = shipName;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevalier"));
            Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
            Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            Orders.Add(new OrderData(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Orders.Add(new OrderData(10254, "CHOPS", "Bern", "Chop-suey Chinese"));
            Orders.Add(new OrderData(10255, "RICSU", "Genève", "Richter Supermarkt"));
            Orders.Add(new OrderData(10256, "WELLI", "Resende", "Wellington Import Export"));
            Orders.Add(new OrderData(10257, "HILAA", "San Cristóbal", "Hila Alimentos"));
            Orders.Add(new OrderData(10258, "ERNSH", "Graz", "Ernst Handel"));
            Orders.Add(new OrderData(10259, "CENTC", "México D.F.", "Centro comercial"));
            Orders.Add(new OrderData(10260, "OTTIK", "Köln", "Ottilies Käseladen"));
            Orders.Add(new OrderData(10261, "QUEDE", "Rio de Janeiro", "Que delícia"));
            Orders.Add(new OrderData(10262, "RATTC", "Albuquerque", "Rattlesnake Canyon Grocery"));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNhotfhJUHIXUNlC?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Exporting with custom aggregate

Exporting Syncfusion Blazor DataGrid data with custom aggregates allows you to include additional calculated values in the exported file based on specific requirements. This feature is highly valuable for providing a comprehensive view of the data in the exported file, incorporating specific aggregated information for analysis or reporting purposes.

In order to utilize custom aggregation, you need to specify the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_Type) property as **Custom** and provide the custom aggregate function in the `CustomAggregate` property.

Within the **CustomAggregateFunction** function, it takes an input data that contains a result property. The function calculates the count of objects in this data where the **ShipCountry** field value is equal to **Brazil** and returns the count with a descriptive label.

The [ExcelAggregateTemplateInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ExcelAggregateTemplateInfo) event is used to handle custom aggregates during the export process. Within this event, the custom aggregate value is applied to the `args.Cell.Value` property, allowing you to include the custom aggregation in the exported Excel document.

The following example shows how to export the Grid with a custom aggregate that shows the calculation of the **Brazil** count of the **ShipCountry** column.


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
    <GridEvents OnToolbarClick="ToolbarClickHandler" ExcelAggregateTemplateInfo="ExcelAggregateTemplateInfoHandler" TValue="OrderData"></GridEvents>
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
        Orders = OrderData.GetAllRecords();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname.
        {
            await Grid.ExportToExcelAsync();
        }
    }

    private int CustomAggregateFunction()
    {
        return Orders.Count(x => x.ShipCountry.Contains("Brazil"));
    } 

    public void ExcelAggregateTemplateInfoHandler(ExcelAggregateEventArgs args)
    {
        if (args.Column.Field == "ShipCountry")
        {
            args.Cell.Value = $"Brazil Count: {CustomAggregateFunction()}";
        }
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtretpMNVVBLBlTI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Exporting with custom date format

The exporting functionality in the Syncfusion Blazor DataGrid allows you to export Grid data, including custom date format. This feature is useful when you need to export Grid data with customized date values.

To apply a custom date format to Grid columns during the export, you can utilize the [Columns.Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Format) property. This property allows you to define a custom format using format options.

The following example demonstrates how to export the Grid with a custom date format . In this example, the `Format` property is used for the **OrderDate** column. This custom date `Format` displays the date in the format of day-of-the-week, month abbreviation, day, and 2-digit year (e.g., Sun, Jan 15, 23). The [ExportToExcelAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToExcelAsync_Syncfusion_Blazor_Grids_ExcelExportProperties_) method is called in the [OnToolbarClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnToolbarClick) event to export the data to Excel document.


{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="Grid" DataSource="@Orders" AllowExcelExport="true" Toolbar="@(new List<string>() { "ExcelExport" })" Height="348">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="ddd, MMM d, ''yy" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Visible="false" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
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
        if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname.
        {
            await Grid.ExportToExcelAsync();
        }
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjVeDfWXVMQonozp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Passing additional parameters to the server when exporting

Passing additional parameters to the server when exporting data in the Syncfusion Blazor DataGrid involves providing flexibility to include extra information or customize the export process based on specific requirements.

You can achieve this by utilizing the [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.Query.html) property and the [OnToolbarClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnToolbarClick) event. Within the `Query` property, you can invoke the [AddParams](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.Query.html#Syncfusion_Blazor_Data_Query_AddParams_System_String_System_Object_) method to add parameters to the request.

The following example demonstrates how to pass additional parameters to the server when Excel exporting within the `OnToolbarClick` event. Within the event, the additional parameters, specifically **recordcount** as **15**, are passed using the `AddParams` method and displayed as a message.  Additionally, the [ExportComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ExportComplete) event is used to reset the query state after the export is completed.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data

<p>@message</p>
<SfGrid ID="Grid" @ref="Grid" DataSource="@Orders" AllowExcelExport="true" Toolbar="@(new List<string>() { "ExcelExport" })" Height="348">
    <GridEvents OnToolbarClick="ToolbarClickHandler" ExportComplete="ExportCompleteHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true" />
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150" />
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150" />
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150" />
    </GridColumns>
</SfGrid>
<style>
    p{
        color: red;
        text-align:center;
    }
</style>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
    private string message = "";
    private Query queryClone;

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname.
        {
            queryClone = this.Grid?.Query;
            Grid!.Query = new Query().AddParams("recordcount", "15");

            if (Grid!.Query.Queries.Params?.Count > 0)
            {
                var param = Grid.Query.Queries.Params.First();
                message = $"Key: {param.Key} and Value: {param.Value?.ToString()} on {args.Item.Text}";
            }

            await Grid.ExportToExcelAsync();
        }
    }

    public void ExportCompleteHandler(object args)
    {
        if (queryClone != null)
        {
            Grid!.Query = queryClone;
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData(int orderID, string customerID, string shipCity, string shipName)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.ShipCity = shipCity;
        this.ShipName = shipName;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevalier"));
            Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
            Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            Orders.Add(new OrderData(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Orders.Add(new OrderData(10254, "CHOPS", "Bern", "Chop-suey Chinese"));
            Orders.Add(new OrderData(10255, "RICSU", "Genève", "Richter Supermarkt"));
            Orders.Add(new OrderData(10256, "WELLI", "Resende", "Wellington Import Export"));
            Orders.Add(new OrderData(10257, "HILAA", "San Cristóbal", "Hila Alimentos"));
            Orders.Add(new OrderData(10258, "ERNSH", "Graz", "Ernst Handel"));
            Orders.Add(new OrderData(10259, "CENTC", "México D.F.", "Centro comercial"));
            Orders.Add(new OrderData(10260, "OTTIK", "Köln", "Ottilies Käseladen"));
            Orders.Add(new OrderData(10261, "QUEDE", "Rio de Janeiro", "Que delícia"));
            Orders.Add(new OrderData(10262, "RATTC", "Albuquerque", "Rattlesnake Canyon Grocery"));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNryZJitJZwsZqkm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}