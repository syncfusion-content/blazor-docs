---
layout: post
title: PDF Export Options in Blazor DataGrid | Syncfusion
description: Checkout and learn here all about PDF Export Options in Syncfusion Blazor DataGrid and much more.
platform: Blazor
control: DataGrid
documentation: ug
---

# PDF export options in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to customize the PDF export options functionality. This flexibility enables you to have greater control over the exported content and layout to meet your specific requirements.

The PDF export action can be customized based on your requirements using the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) property. By using the `PdfExportProperties` property, you can export the current page records, selected records, or filtered records, exclude or include hidden column, export with custom data source and change the file name. Additionally, you can customize the page alignments using the `PdfExportProperties` property.

## Export current page records

Exporting the current page in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid to a PDF document provides the ability to export the currently displayed page records. This feature allows for generating PDF documents that specifically include the content from the current page of the Grid. 

To export the current page of the Grid to a PDF document, you need to specify the [ExportType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_ExportType) property. This property allows you to define which records you want to export. You can choose between two options:

1. **CurrentPage**: Exports only the records on the current Grid page.
2. **AllPages**: Exports all the records from the Grid.

The following example demonstrates how to export current page to a PDF document when a toolbar item is clicked, using the  [OnToolbarClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnToolbarClick) event and the [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToPdfAsync_Syncfusion_Blazor_Grids_PdfExportProperties_) method.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<div style="display: flex; align-items: center; margin-bottom: 15px;font-weight: bold">
    <label style="padding-right: 10px;">Change export type:</label>
    <SfDropDownList TValue="string" TItem="DropDownOrder" @bind-Value="SelectedExportType" DataSource="@DropDownValue" Width="150px">
        <DropDownListFieldSettings Text="Text" Value="Value" />
    </SfDropDownList>
</div>

<SfGrid ID="Grid" @ref="Grid" DataSource="@Orders" AllowPaging="true" AllowPdfExport="true" Toolbar="@(new List<string>() { "PdfExport" })" Height="300">
    <GridEvents TValue="EmployeeData" OnToolbarClick="ToolbarClickHandler"></GridEvents>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.EmployeeID) HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true" />
        <GridColumn Field=@nameof(EmployeeData.FirstName) HeaderText="First Name" Width="150" />
        <GridColumn Field=@nameof(EmployeeData.LastName) HeaderText="Last Name" Width="150" />
        <GridColumn Field=@nameof(EmployeeData.City) HeaderText="City" Width="150" />
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<EmployeeData> Grid;
    public List<EmployeeData> Orders { get; set; }
    private string SelectedExportType = "CurrentPage";
    List<DropDownOrder> DropDownValue = new List<DropDownOrder>
    {
        new DropDownOrder { Text = "CurrentPage", Value = "CurrentPage" },
        new DropDownOrder { Text = "AllPages", Value = "AllPages" },
    };

    protected override void OnInitialized()
    {
        Orders = EmployeeData.GetAllRecords();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_pdfexport") //Id is combination of Grid's ID and itemname.
        {
            var exportProperties = new PdfExportProperties
                {
                    ExportType = SelectedExportType == "AllPages" ? ExportType.AllPages : ExportType.CurrentPage
                };
            await Grid.ExportToPdfAsync(exportProperties);
        }
    }

    public class DropDownOrder
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }

}

{% endhighlight %}
{% highlight c# tabtitle="EmployeeData.cs" %}

 public class EmployeeData
 {
     public static List<EmployeeData> Employees = new List<EmployeeData>();

     public EmployeeData(int employeeID, string firstName, string lastName, string city)
     {
         this.EmployeeID = employeeID;
         this.FirstName = firstName;
         this.LastName = lastName;
         this.City = city;
     }

     public static List<EmployeeData> GetAllRecords()
     {
         if (Employees.Count == 0)
         {
             Employees.Add(new EmployeeData(1001, "Nancy", "Davolio", "Seattle"));
             Employees.Add(new EmployeeData(1002, "Andrew", "Fuller", "Tacoma"));
             Employees.Add(new EmployeeData(1003, "Janet", "Leverling", "Kirkland"));
             Employees.Add(new EmployeeData(1004, "Margaret", "Peacock", "Redmond"));
             Employees.Add(new EmployeeData(1005, "Steven", "Buchanan", "London"));
             Employees.Add(new EmployeeData(1006, "Michael", "Suyama", "London"));
             Employees.Add(new EmployeeData(1007, "Robert", "King", "London"));
             Employees.Add(new EmployeeData(1008, "Laura", "Callahan", "Seattle"));
             Employees.Add(new EmployeeData(1009, "Anne", "Dodsworth", "London"));
         }
         return Employees;
     }

     public int EmployeeID { get; set; }
     public string FirstName { get; set; }
     public string LastName { get; set; }
     public string City { get; set; }
 }

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjBeNzMWgoxPClQM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Export selected records

Exporting only the selected records from the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows generating PDF document that include only the desired data from the Grid. This feature provides the flexibility to export specific records that are relevant to the needs, enabling more focused and targeted PDF exports.

To export the selected records from the Grid to a PDF document, you can follow these steps:

1. Handle the [OnToolbarClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnToolbarClick) event of the Grid and retrieve the selected records using the [GetSelectedRecordsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetSelectedRecordsAsync) method.

2. Assign the selected data to the [ExportProperties.DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_DataSource) property.

3. Trigger the export operation using the [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToPdfAsync_Syncfusion_Blazor_Grids_PdfExportProperties_) method.

The following example demonstrates how to export the selected records to a PDF document when a toolbar item is clicked.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="Grid" DataSource="@Orders" AllowPaging="true" AllowPdfExport="true" Toolbar="@(new List<string>() { "PdfExport" })" Height="348">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="OrderData"></GridEvents>
    <GridSelectionSettings EnableSimpleMultiRowSelection="true" Type="SelectionType.Multiple"></GridSelectionSettings>
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
        if (args.Item.Id == "Grid_pdfexport") //Id is combination of Grid's ID and itemname.
        {
            var selectedRecords = await Grid.GetSelectedRecordsAsync();
            PdfExportProperties exportProperties = new PdfExportProperties
                {
                    DataSource = selectedRecords
                };
            await this.Grid.ExportToPdfAsync(exportProperties);
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtLyZJWignXqmlaL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Export filtered records

Exporting only the filtered records from the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to generate PDF document that include only the data that matches your applied filters. This feature is useful when you want to export a subset of data based on specific criteria.

This can be achieved by defining the filtered data in the [ExportProperties.DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_DataSource) property before initiating the export.

To export only the filtered data from the Grid to a PDF document, you can follow these steps:

1. Apply the desired filter to the Grid data by enabling [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering) property.

2. Get the filtered data using the [GetFilteredRecordsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetFilteredRecordsAsync_System_Boolean_) method.

3. Assign the filtered data to the `ExportProperties.DataSource` property.

4. Trigger the export operation using the [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToPdfAsync_Syncfusion_Blazor_Grids_PdfExportProperties_) method.

The following example demonstrates how to export the filtered records to a PDF document.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="Grid" DataSource="@Orders" AllowFiltering="true" AllowPaging="true" AllowPdfExport="true" Toolbar="@(new List<string>() { "PdfExport" })" Height="348">
    <GridPageSettings PageSize="5" PageCount="5"></GridPageSettings>
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
        if (args.Item.Id == "Grid_pdfexport") //Id is combination of Grid's ID and itemname.
        {
        var FilterdRecords = (IEnumerable<OrderData>)await Grid.GetFilteredRecordsAsync();
        PdfExportProperties exportProperties = new PdfExportProperties
            {
                DataSource = FilterdRecords
            };
        await this.Grid.ExportToPdfAsync(exportProperties);
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtVINzMpVxeuzFVM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Export with hidden columns

Exporting hidden columns in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to include hidden columns in the exported PDF document. This feature is useful when you have columns that are hidden in the UI but still need to be included in the exported document.

To export hidden columns of the Grid to a PDF document, you need to set the [IncludeHiddenColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_IncludeHiddenColumn) property as **true** in the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) property.

The following example demonstrates how to export hidden columns to a PDF document using the [OnToolbarClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnToolbarClick) event and the [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToPdfAsync_Syncfusion_Blazor_Grids_PdfExportProperties_) method. In this example, the **ShipCity** column, which is not visible in the UI, is exported to the PDF document. You can also export the Grid by changing the `PdfExportProperties.IncludeHiddenColumn` property based on the switch toggle using the `bind-Checked` property of the [Blazor Toggle Switch Button](https://blazor.syncfusion.com/documentation/toggle-switch-button/getting-started-webapp).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="display: flex; align-items: center; gap: 10px; margin-bottom: 15px;">
    <label style="font-weight: bold">Include or exclude hidden columns</label>
    <SfSwitch @bind-Checked="IncludeHiddenColumns"></SfSwitch>
</div>

<SfGrid ID="Grid" @ref="Grid" DataSource="@Orders" AllowPaging="true" AllowPdfExport="true" Toolbar="@(new List<string>() { "PdfExport" })" Height="348">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true" />
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150" />
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120" />
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150" Visible="false" />
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="150" />
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }

    public bool IncludeHiddenColumns { get; set; } = false;

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_pdfexport") //Id is combination of Grid's ID and itemname.
        {
            PdfExportProperties exportProperties = new PdfExportProperties
                {
                    IncludeHiddenColumn = IncludeHiddenColumns
                };

            await Grid.ExportToPdfAsync(exportProperties);
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData(int orderID, string customerID, double freight, string shipCity, string shipName, string shipCountry)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.Freight = freight;
        this.ShipCity = shipCity;
        this.ShipName = shipName;
        this.ShipCountry = shipCountry;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 32.38, "Reims", "Vins et alcools Chevalier", "France"));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, "Münster", "Toms Spezialitäten", "Germany"));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, "Rio de Janeiro", "Hanari Carnes", "Brazil"));
            Orders.Add(new OrderData(10251, "VICTE", 41.34, "Lyon", "Victuailles en stock", "France"));
            Orders.Add(new OrderData(10252, "SUPRD", 51.3, "Charleroi", "Suprêmes délices", "Belgium"));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, "Rio de Janeiro", "Hanari Carnes", "Brazil"));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, "Bern", "Chop-suey Chinese", "Switzerland"));
            Orders.Add(new OrderData(10255, "RICSU", 148.33, "Genève", "Richter Supermarkt", "Switzerland"));
            Orders.Add(new OrderData(10256, "WELLI", 13.97, "Resende", "Wellington Import Export", "Brazil"));
            Orders.Add(new OrderData(10257, "HILAA", 81.91, "San Cristóbal", "Hila Alimentos", "Venezuela"));
            Orders.Add(new OrderData(10258, "ERNSH", 140.51, "Graz", "Ernst Handel", "Austria"));
            Orders.Add(new OrderData(10259, "CENTC", 3.25, "México D.F.", "Centro comercial", "Mexico"));
            Orders.Add(new OrderData(10260, "OTTIK", 55.09, "Köln", "Ottilies Käseladen", "Germany"));
            Orders.Add(new OrderData(10261, "QUEDE", 3.05, "Rio de Janeiro", "Que delícia", "Brazil"));
            Orders.Add(new OrderData(10262, "RATTC", 48.29, "Albuquerque", "Rattlesnake Canyon Grocery", "USA"));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZhoNJWiAnvCslzK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Show or hide columns while exporting

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides the functionality to show or hide columns dynamically during the export process. This feature allows you to selectively display or hide specific columns based on your requirements.

To show or hide columns based on user interaction during the export process, you can follow these steps:

1. Handle the [OnToolbarClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnToolbarClick) event of the Grid and update the visibility of the desired columns by setting the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Visible) property of the column to **true** or **false**.

2. Export the Grid to PDF document.

3. Handle the [ExportComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ExportComplete) event to restore the column visibility to its original state.

In the following example, the **CustomerID** is initially a hidden column in the Grid. However, during the export process, the **CustomerID** column is made visible, while the **ShipCity** column is hidden.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="Grid" DataSource="@Orders"  AllowPdfExport="true"
Toolbar="@(new List<string>() { "PdfExport" })" Height="348">
    <GridEvents OnToolbarClick="ToolbarClickHandler" ExportComplete="ExportCompleteHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true" />
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Visible="@isCustomerIDVisible" Width="150" />
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120" />
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Visible="@isShipCityVisible" Width="150" />
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="150" />
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
    public bool isCustomerIDVisible { get; set; } = false;
    public bool isShipCityVisible { get; set; } = true;

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_pdfexport") //Id is combination of Grid's ID and itemname.
        {
            isCustomerIDVisible = true;
            isShipCityVisible=false;
            await Grid.ExportToPdfAsync();
        }
    }

    public void ExportCompleteHandler(object args)
    {
        isCustomerIDVisible = false;
        isShipCityVisible=true;
    }
}
{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData(int orderID, string customerID, double freight, string shipCity, string shipName, string shipCountry)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.Freight = freight;
        this.ShipCity = shipCity;
        this.ShipName = shipName;
        this.ShipCountry = shipCountry;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 32.38, "Reims", "Vins et alcools Chevalier", "France"));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, "Münster", "Toms Spezialitäten", "Germany"));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, "Rio de Janeiro", "Hanari Carnes", "Brazil"));
            Orders.Add(new OrderData(10251, "VICTE", 41.34, "Lyon", "Victuailles en stock", "France"));
            Orders.Add(new OrderData(10252, "SUPRD", 51.3, "Charleroi", "Suprêmes délices", "Belgium"));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, "Rio de Janeiro", "Hanari Carnes", "Brazil"));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, "Bern", "Chop-suey Chinese", "Switzerland"));
            Orders.Add(new OrderData(10255, "RICSU", 148.33, "Genève", "Richter Supermarkt", "Switzerland"));
            Orders.Add(new OrderData(10256, "WELLI", 13.97, "Resende", "Wellington Import Export", "Brazil"));
            Orders.Add(new OrderData(10257, "HILAA", 81.91, "San Cristóbal", "Hila Alimentos", "Venezuela"));
            Orders.Add(new OrderData(10258, "ERNSH", 140.51, "Graz", "Ernst Handel", "Austria"));
            Orders.Add(new OrderData(10259, "CENTC", 3.25, "México D.F.", "Centro comercial", "Mexico"));
            Orders.Add(new OrderData(10260, "OTTIK", 55.09, "Köln", "Ottilies Käseladen", "Germany"));
            Orders.Add(new OrderData(10261, "QUEDE", 3.05, "Rio de Janeiro", "Que delícia", "Brazil"));
            Orders.Add(new OrderData(10262, "RATTC", 48.29, "Albuquerque", "Rattlesnake Canyon Grocery", "USA"));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNByZTBaJDQfXHAZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Change page orientation

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to change the page orientation of the exported PDF document from the default portrait mode to landscape mode. This feature provides the flexibility to adjust the layout and presentation of the exported PDF document according to your needs.

To change the page orientation to landscape for the exported document, you can set the [PageOrientation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_PageOrientation) property of the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) property. 

The supported `PageOrientation` options are:

1. **Landscape**: Exports the Grid with a landscape PDF page orientation.

2. **Portrait**: Exports the Grid with a portrait PDF page orientation.

The following example demonstrates how to export the Grid into PDF document by setting the `PdfExportProperties.PageOrientation` property using the [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Value) property of the [DropDownList](https://blazor.syncfusion.com/documentation/dropdown-list).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Navigations
@using System.Collections.Generic

<div style="display: flex; align-items: center; margin-bottom: 10px;">
    <label style="padding: 10px 10px 26px 0">Change the page orientation property:</label>
    <SfDropDownList TValue="string" TItem="OrientationItem" @bind-Value="SelectedOrientation" DataSource="@Orientations" Placeholder="Select Orientation" PopupHeight="150px" Width="120px">
        <DropDownListFieldSettings Text="Text" Value="Value"></DropDownListFieldSettings>
    </SfDropDownList>
</div>

<SfGrid ID="Grid" @ref="Grid" DataSource="@Data" AllowPaging="true" AllowPdfExport="true" Toolbar="@(new List<string>() { "PdfExport" })" Height="272">
    <GridEvents TValue="OrderData" OnToolbarClick="ToolbarClickHandler"></GridEvents>
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" Width="90" TextAlign="TextAlign.Right" />
        <GridColumn Field="CustomerID" HeaderText="Customer ID" Width="100" />
        <GridColumn Field="ShipCity" HeaderText="Ship City" Width="120" />
        <GridColumn Field="ShipName" HeaderText="Ship Name" Width="100" />
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Data { get; set; }

    public class OrientationItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }

    public string SelectedOrientation { get; set; } = "Portrait";

    public List<OrientationItem> Orientations = new List<OrientationItem>
    {
        new OrientationItem { Text = "Portrait", Value = "Portrait" },
        new OrientationItem { Text = "Landscape", Value = "Landscape" }
    };

    protected override void OnInitialized()
    {
        Data = OrderData.GetAllRecords(); 
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id.Contains("pdfexport", StringComparison.OrdinalIgnoreCase))
        {
            var exportProps = new PdfExportProperties
            {
                PageOrientation = SelectedOrientation == "Landscape" ? PageOrientation.Landscape : PageOrientation.Portrait
            };
            await Grid.ExportToPdfAsync(exportProps);
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData(int orderID, string customerID, double freight, string shipCity, string shipName, string shipCountry)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.Freight = freight;
        this.ShipCity = shipCity;
        this.ShipName = shipName;
        this.ShipCountry = shipCountry;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 32.38, "Reims", "Vins et alcools Chevalier", "France"));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, "Münster", "Toms Spezialitäten", "Germany"));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, "Rio de Janeiro", "Hanari Carnes", "Brazil"));
            Orders.Add(new OrderData(10251, "VICTE", 41.34, "Lyon", "Victuailles en stock", "France"));
            Orders.Add(new OrderData(10252, "SUPRD", 51.3, "Charleroi", "Suprêmes délices", "Belgium"));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, "Rio de Janeiro", "Hanari Carnes", "Brazil"));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, "Bern", "Chop-suey Chinese", "Switzerland"));
            Orders.Add(new OrderData(10255, "RICSU", 148.33, "Genève", "Richter Supermarkt", "Switzerland"));
            Orders.Add(new OrderData(10256, "WELLI", 13.97, "Resende", "Wellington Import Export", "Brazil"));
            Orders.Add(new OrderData(10257, "HILAA", 81.91, "San Cristóbal", "Hila Alimentos", "Venezuela"));
            Orders.Add(new OrderData(10258, "ERNSH", 140.51, "Graz", "Ernst Handel", "Austria"));
            Orders.Add(new OrderData(10259, "CENTC", 3.25, "México D.F.", "Centro comercial", "Mexico"));
            Orders.Add(new OrderData(10260, "OTTIK", 55.09, "Köln", "Ottilies Käseladen", "Germany"));
            Orders.Add(new OrderData(10261, "QUEDE", 3.05, "Rio de Janeiro", "Que delícia", "Brazil"));
            Orders.Add(new OrderData(10262, "RATTC", 48.29, "Albuquerque", "Rattlesnake Canyon Grocery", "USA"));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZLeNzVKUaStvZne?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Change page size

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to customize the page size of the exported PDF document according to your requirements. This feature provides the flexibility to adjust the layout and PDF document to fit different paper sizes or printing needs. 

To customize the page size for the exported document, you can set the [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_PageSize) property of the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) property to the desired [PdfPageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfPageSize.html). 

Supported [PdfPageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfPageSize.html#fields) are:
* Letter
* Note
* Legal
* A0
* A1
* A2
* A3
* A4
* A5
* A6
* A7
* A8
* A9
* B0
* B1
* B2
* B3
* B4
* B5
* Archa
* Archb
* Archc
* Archd
* Arche
* Flsa
* HalfLetter
* Letter11x17
* Ledger

The following example demonstrates how to export the Grid into PDF document by setting the `PdfExportProperties.PageSize` property by using [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Value) property of the [DropDownList](https://blazor.syncfusion.com/documentation/dropdown-list).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor

<div style="display: flex; align-items: center; margin-bottom: 15px; font-weight: bold">
    <label style="padding-right: 10px;">Change the page size:</label>
    <SfDropDownList TValue="string" TItem="PageSizeOption" @bind-Value="SelectedPageSize" DataSource="@PageSizes" Width="150px">
        <DropDownListFieldSettings Text="Text" Value="Value" />
    </SfDropDownList>
</div>

<SfGrid @ref="Grid" ID="Grid" DataSource="@Orders" AllowPaging="true" AllowPdfExport="true" Toolbar="@(new List<string>() { "PdfExport" })" Height="300">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" Width="90" TextAlign="TextAlign.Right" />
        <GridColumn Field="CustomerID" HeaderText="Customer ID" Width="100" />
        <GridColumn Field="ShipCity" HeaderText="Ship City" Width="100" />
        <GridColumn Field="ShipName" HeaderText="Ship Name" Width="120" />
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }

    private string SelectedPageSize = "A4";

    public List<PageSizeOption> PageSizes = new()
    {
        new PageSizeOption { Text = "Letter", Value = "Letter" },
        new PageSizeOption { Text = "Note", Value = "Note" },
        new PageSizeOption { Text = "Legal", Value = "Legal" },
        new PageSizeOption { Text = "A0", Value = "A0" },
        new PageSizeOption { Text = "A1", Value = "A1" },
        new PageSizeOption { Text = "A2", Value = "A2" },
        new PageSizeOption { Text = "A3", Value = "A3" },
        new PageSizeOption { Text = "A4", Value = "A4" },
        new PageSizeOption { Text = "A5", Value = "A5" },
        new PageSizeOption { Text = "A6", Value = "A6" },
        new PageSizeOption { Text = "B4", Value = "B4" },
        new PageSizeOption { Text = "B5", Value = "B5" },
        new PageSizeOption { Text = "Flsa", Value = "Flsa" },
        new PageSizeOption { Text = "HalfLetter", Value = "HalfLetter" },
        new PageSizeOption { Text = "Ledger", Value = "Ledger" },
        new PageSizeOption { Text = "Letter11x17", Value = "Letter11x17" },
        new PageSizeOption { Text = "ArchC", Value = "ArchC" },
        new PageSizeOption { Text = "ArchD", Value = "ArchD" },
        new PageSizeOption { Text = "ArchE", Value = "ArchE" },
    };

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_pdfexport") //Id is combination of Grid's ID and itemname.
        {
            var exportProps = new PdfExportProperties
            {
                PageSize = Enum.TryParse<PdfPageSize>(SelectedPageSize, out var size) ? size : PdfPageSize.A4
            };
            await Grid.ExportToPdfAsync(exportProps);
        }
    }

    public class PageSizeOption
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }  
}
{% endhighlight %}

{% highlight c# tabtitle="OrderDetails.cs" %}

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDhoNIXoheMzaxjw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Define file name

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to specify a custom file name for the exported PDF document. This feature enables you to provide a meaningful and descriptive name for the exported file, making it easier to identify and manage the exported data.

To assign a custom file name for the exported document, you can set the [FileName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_FileName) property of the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html) property in the [OnToolbarClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnToolbarClick) event and pass it to the [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToPdfAsync_Syncfusion_Blazor_Grids_PdfExportProperties_) method.

The following example demonstrates how to define a file name using `PdfExportProperties.FileName` property when exporting to PDF document, based on the entered value as the file name.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Height="315" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="OrderDetails"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText="Ship Name" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderDetails> DefaultGrid;
    public List<OrderDetails> Orders { get; set; }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_pdfexport")  //Id is combination of Grid's ID and itemname.
        {
            PdfExportProperties ExportProperties = new PdfExportProperties();
            ExportProperties.FileName = "New.pdf";
            await this.DefaultGrid.PdfExport(ExportProperties);
        }
    }
    protected override void OnInitialized()
    {
        Orders = OrderDetails.GetAllRecords();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerId, string ShipCity, string ShipName)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.ShipCity = ShipCity;
        this.ShipName = ShipName;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", "Reims", "Vins et alcools Chevalier"));
            order.Add(new OrderDetails(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            order.Add(new OrderDetails(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            order.Add(new OrderDetails(10251, "VICTE", "Lyon", "Victuailles en stock"));
            order.Add(new OrderDetails(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            order.Add(new OrderDetails(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            order.Add(new OrderDetails(10254, "CHOPS", "Bern", "Chop-suey Chinese"));
            order.Add(new OrderDetails(10255, "RICSU", "Genève", "Richter Supermarkt"));
            order.Add(new OrderDetails(10256, "WELLI", "Resende", "Wellington Importadora"));
            order.Add(new OrderDetails(10257, "HILAA", "San Cristóbal", "HILARION-Abastos"));
            order.Add(new OrderDetails(10258, "ERNSH", "Graz", "Ernst Handel"));
            order.Add(new OrderDetails(10259, "CENTC", "México D.F.", "Centro comercial Moctezuma"));
            order.Add(new OrderDetails(10260, "OTTIK", "Köln", "Ottilies Käseladen"));
            order.Add(new OrderDetails(10261, "QUEDE", "Rio de Janeiro", "Que Delícia"));
            order.Add(new OrderDetails(10262, "RATTC", "Albuquerque", "Rattlesnake Canyon Grocery"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDByjpMMziSSVgoO?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Enabling horizontal overflow

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to display all defined Grid columns on a single page even when the number of columns exceeds the maximum limits for columns in the exported PDF document. This ensures that your exported PDF document maintains its readability and comprehensiveness.

You can achieve this by utilizing the [PdfExportProperties.AllowHorizontalOverflow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_AllowHorizontalOverflow) property of the Grid.

In the following example, the [Blazor Toggle Switch Button](https://blazor.syncfusion.com/documentation/toggle-switch-button/getting-started-webapp) is added to enable and disable the `PdfExportProperties.AllowHorizontalOverflow` property. Based on the switch toggle, the `PdfExportProperties.AllowHorizontalOverflow` property is updated using the `Checked` property, and the export action is performed accordingly when the toolbar is clicked.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<div style="margin-bottom: 15px;">
    <label style="padding-right: 10px;">Enable or disable Horizontal Overflow property</label>
    <SfSwitch @bind-Checked="DisableHorizontalOverflow" />
</div>

<SfGrid ID="Grid" @ref="Grid" DataSource="@Orders" AllowPaging="true" AllowPdfExport="true" Toolbar="@(new List<string>() { "PdfExport" })" Height="348">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" Width="90" TextAlign="TextAlign.Right" />
        <GridColumn Field="CustomerID" HeaderText="Customer ID" Width="100" />
        <GridColumn Field="ShipCity" HeaderText="Ship City" Width="100" />
        <GridColumn Field="ShipName" HeaderText="Ship Name" Width="120" />
        <GridColumn Field="ShipAddress" HeaderText="Ship Address" Width="130" />
        <GridColumn Field="ShipRegion" HeaderText="Ship Region" Width="90" />
        <GridColumn Field="ShipPostalCode" HeaderText="Ship Postal Code" Width="90" />
        <GridColumn Field="ShipCountry" HeaderText="Ship Country" Width="100" />
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    private bool DisableHorizontalOverflow = false;

    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_pdfexport") //Id is combination of Grid's ID and itemname.
        {
            var pdfExportProps = new PdfExportProperties
                {
                    AllowHorizontalOverflow = !DisableHorizontalOverflow
                };
            await Grid.ExportToPdfAsync(pdfExportProps);
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

 public class OrderData
 {
     public static List<OrderData> Orders = new();

     public OrderData(int orderID, string customerID, string shipCity, string shipName, string shipAddress, string shipRegion, string shipPostalCode, string shipCountry)
     {
         OrderID = orderID;
         CustomerID = customerID;
         ShipCity = shipCity;
         ShipName = shipName;
         ShipAddress = shipAddress;
         ShipRegion = shipRegion;
         ShipPostalCode = shipPostalCode;
         ShipCountry = shipCountry;
     }

     public static List<OrderData> GetAllRecords()
     {
         if (Orders.Count == 0)
         {
             Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevalier", "59 rue de l'Abbaye", "", "51100", "France"));
             Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten", "Luisenstr. 48", "", "44087", "Germany"));
             Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes", "Rua do Paço, 67", "RJ", "05454-876", "Brazil"));
             Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock", "2, rue du Commerce", "", "69004", "France"));
             Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices", "Boulevard Tirou, 255", "", "B-6000", "Belgium"));
             Orders.Add(new OrderData(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes", "Rua do Paço, 67", "RJ", "05454-876", "Brazil"));
             Orders.Add(new OrderData(10254, "CHOPS", "Bern", "Chop-suey Chinese", "Hauptstr. 31", "", "3012", "Switzerland"));
             Orders.Add(new OrderData(10255, "RICSU", "Genève", "Richter Supermarkt", "Starenweg 5", "", "1204", "Switzerland"));
             Orders.Add(new OrderData(10256, "WELLI", "Resende", "Wellington Importadora", "Rua do Mercado, 12", "SP", "08737-363", "Brazil"));
             Orders.Add(new OrderData(10257, "HILAA", "San Cristóbal", "HILARION-Abastos", "Carrera 22 con Ave. Carlos Soublette #8-35", "Táchira", "5022", "Venezuela"));
         }

         return Orders;
     }

     public int OrderID { get; set; }
     public string CustomerID { get; set; } = string.Empty;
     public string ShipCity { get; set; } = string.Empty;
     public string ShipName { get; set; } = string.Empty;
     public string ShipAddress { get; set; } = string.Empty;
     public string ShipRegion { get; set; } = string.Empty;
     public string ShipPostalCode { get; set; } = string.Empty;
     public string ShipCountry { get; set; } = string.Empty;
 }

{% endhighlight %}
{% endtabs %}

![Enabling horizontal overflow](./images/Enabling-horizontal-overflow.gif)

> You can find a complete sample on [GitHub](https://github.com/SyncfusionExamples/exporting-blazor-datagrid/tree/master/Exporting-PDF-Datagrid/Horizontal_overflow).

## Customizing columns on export

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to customize the appearance of Grid columns in your exported PDF documents. This feature empowers you to tailor specific column attributes such as field, header text, and text alignment, ensuring that your exported PDFs align perfectly with your design and reporting requirements.

To customize the Grid columns, you can follow these steps:

1. Handle the [OnToolbarClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnToolbarClick) event, and access the [PdfExportProperties.Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_Columns) property of the Grid.

2. Define new list of GridColumn objects with the desired properties such as Field, HeaderText, TextAlign, Format, and Width for each column to be exported.

3. Assign this list to the `Columns` property of the `PdfExportProperties` object, then pass it to the [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToPdfAsync_Syncfusion_Blazor_Grids_PdfExportProperties_) to apply the customizations during export.

The following example demonstrates how to customize the Grid columns when exporting a document. In this scenario, the attributes for different columns have been customized: **OrderID** with `HeaderText` set to **Order Number**, **CustomerID** with headerText as **Customer Name**, and **Freight** with a center-aligned `TextAlign` property, which is not rendered in the Grid columns:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="Grid" DataSource="@Orders" AllowPdfExport="true" Toolbar="@(new List<string>() { "PdfExport" })" Height="348">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true" />
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150" />
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150" />
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="150" />
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
        if (args.Item.Id == "Grid_pdfexport") //Id is combination of Grid's ID and itemname.
        {
            List<GridColumn> ExportColumns = new List<GridColumn>();
            ExportColumns.Add(new GridColumn() { Field = "OrderID", HeaderText = "Order Number", Width = "120" });
            ExportColumns.Add(new GridColumn() { Field = "CustomerID", HeaderText = "Customer Name", Width = "120" });
            ExportColumns.Add(new GridColumn() { Field = "Freight", HeaderText = "Freight", Width = "120", Format = "C2", TextAlign = TextAlign.Center });

            var exportProperties = new PdfExportProperties
            {
                Columns = ExportColumns
            };
            await Grid.ExportToPdfAsync(exportProperties);
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderDetails.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData(int orderID, string customerID, double freight, string shipCity, string shipName, string shipCountry)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.Freight = freight;
        this.ShipCity = shipCity;
        this.ShipName = shipName;
        this.ShipCountry = shipCountry;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 32.38, "Reims", "Vins et alcools Chevalier", "France"));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, "Münster", "Toms Spezialitäten", "Germany"));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, "Rio de Janeiro", "Hanari Carnes", "Brazil"));
            Orders.Add(new OrderData(10251, "VICTE", 41.34, "Lyon", "Victuailles en stock", "France"));
            Orders.Add(new OrderData(10252, "SUPRD", 51.3, "Charleroi", "Suprêmes délices", "Belgium"));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, "Rio de Janeiro", "Hanari Carnes", "Brazil"));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, "Bern", "Chop-suey Chinese", "Switzerland"));
            Orders.Add(new OrderData(10255, "RICSU", 148.33, "Genève", "Richter Supermarkt", "Switzerland"));
            Orders.Add(new OrderData(10256, "WELLI", 13.97, "Resende", "Wellington Import Export", "Brazil"));
            Orders.Add(new OrderData(10257, "HILAA", 81.91, "San Cristóbal", "Hila Alimentos", "Venezuela"));
            Orders.Add(new OrderData(10258, "ERNSH", 140.51, "Graz", "Ernst Handel", "Austria"));
            Orders.Add(new OrderData(10259, "CENTC", 3.25, "México D.F.", "Centro comercial", "Mexico"));
            Orders.Add(new OrderData(10260, "OTTIK", 55.09, "Köln", "Ottilies Käseladen", "Germany"));
            Orders.Add(new OrderData(10261, "QUEDE", 3.05, "Rio de Janeiro", "Que delícia", "Brazil"));
            Orders.Add(new OrderData(10262, "RATTC", 48.29, "Albuquerque", "Rattlesnake Canyon Grocery", "USA"));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXLeNzWspWvjNiOp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Customize column width in exported PDF document

The PDF export provides an option to customize the column being exported to a PDF format using the [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_Columns) property of the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) class. While defining the column, we can change its width as per the requirement.

The following example demonstrates how to customize the column widths of the exported PDF document by enabling the[DisableAutoFitWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_DisableAutoFitWidth) property of the `PdfExportProperties`.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton OnClick="PdfExport" Content="Pdf Export"></SfButton>
<SfGrid @ref="DefaultGrid" DataSource="@Orders" AllowPdfExport="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<OrderData> DefaultGrid;
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
    public async Task PdfExport()
    {
        PdfExportProperties ExportProperties = new PdfExportProperties();
        ExportProperties.DisableAutoFitWidth = true;
        ExportProperties.Columns = new List<GridColumn>()
        {
                new GridColumn(){ Field="OrderID", HeaderText="Order ID", TextAlign=TextAlign.Left, Width="300"},
                new GridColumn(){ Field="CustomerID", HeaderText="Customer Name", TextAlign=TextAlign.Left, Width="100"},
                new GridColumn(){ Field="OrderDate", HeaderText=" Order Date", Type=ColumnType.Date, Format="d", TextAlign=TextAlign.Left, Width="80"}
        };
        await this.DefaultGrid.ExportToPdfAsync(ExportProperties);
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData() { }

    public OrderData(int OrderID, string CustomerID, DateTime? OrderDate)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.OrderDate = OrderDate;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
        Orders.Add(new OrderData { OrderID = 10248, CustomerID = "VINET", OrderDate = new DateTime(1996, 7, 4) });
        Orders.Add(new OrderData { OrderID = 10249, CustomerID = "TOMSP", OrderDate = new DateTime(1996, 7, 5) });
        Orders.Add(new OrderData { OrderID = 10250, CustomerID = "HANAR", OrderDate = new DateTime(1996, 7, 6) });
        Orders.Add(new OrderData { OrderID = 10251, CustomerID = "VINET", OrderDate = new DateTime(1996, 7, 7) });
        Orders.Add(new OrderData { OrderID = 10252, CustomerID = "SUPRD", OrderDate = new DateTime(1996, 7, 8) });
        Orders.Add(new OrderData { OrderID = 10253, CustomerID = "HANAR", OrderDate = new DateTime(1996, 7, 9) });
        Orders.Add(new OrderData { OrderID = 10254, CustomerID = "CHOPS", OrderDate = new DateTime(1996, 7, 10) });
        Orders.Add(new OrderData { OrderID = 10255, CustomerID = "VINET", OrderDate = new DateTime(1996, 7, 11) });
        Orders.Add(new OrderData { OrderID = 10256, CustomerID = "HANAR", OrderDate = new DateTime(1996, 7, 12) });
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime? OrderDate { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtVetyXEWnovmFoM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Font and color customization

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides the ability to customize the font in the exported PDF document. This feature allows you to control the appearance and styling of the text in the exported file, ensuring consistency with your application's design.

To apply a theme to the exported PDF document, you can define the [Theme](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_Theme) property within the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html). This property allows you to specify the `Theme` to be used in the exported PDF document, including styles for the caption, header, and record content. You can define this property in the [OnToolbarClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnToolbarClick) event and pass it to the [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToPdfAsync_Syncfusion_Blazor_Grids_PdfExportProperties_) method.

[Caption](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfTheme.html#Syncfusion_Blazor_Grids_PdfTheme_Caption): This property defines the theme style for the caption content in the exported PDF document. The caption is the title or description that appears at the top of the exported PDF document.

[Header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfTheme.html#Syncfusion_Blazor_Grids_PdfTheme_Header): This property is used to defines the style for the header content in the exported PDF document. The header corresponds to the column headers in the Grid.

[Record](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfTheme.html#Syncfusion_Blazor_Grids_PdfTheme_Record): This property defines the theme style for the record content in the exported PDF document. The record represents the data rows in the Grid that are exported to PDF document.

N> By default, material theme is applied to exported PDF document.

### Default fonts

By default, the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid uses the **Helvetica** font in the exported document. However, you can change the default font by utilizing the [PdfExportProperties.Theme](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfTheme.html) property. The available default fonts that you can choose from are:

* Helvetica
* TimesRoman
* Courier
* Symbol
* ZapfDingbats

To change the default font in the exported PDF document, set the `Theme` property with your desired font in the `PdfExportProperties` before triggering the export operation.

The following example demonstrates, how to change the default font, font color, font size and border style when exporting a PDF document.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="Grid" DataSource="@Orders" AllowPdfExport="true" AllowGrouping="true" Toolbar="@(new List<string>() { "PdfExport" })" Height="348">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="OrderData"></GridEvents>
    <GridGroupSettings Columns="@Initial"></GridGroupSettings>

    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true" />
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150" />
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120" />
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150" />
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150" />
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;

    public List<OrderData> Orders { get; set; }
    public string fontFamily { get; set; } = "TimesRoman";
    public string[] Initial = (new string[] { "CustomerID", "ShipCity" });
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_pdfexport") //Id is combination of Grid's ID and itemname.
        {
            var exportProps = new PdfExportProperties
                {
                    Theme = new PdfTheme
                    {
                        Header = new PdfThemeStyle
                        {
                            Font = new PdfGridFont { FontFamily = "@fontFamily", FontSize = 11 },
                            FontColor = "#000080",
                            Bold = true,
                            Border = new PdfBorder { Color = "#5A5A5A", DashStyle = PdfDashStyle.Solid }
                        },
                        Caption = new PdfThemeStyle
                        {
                            Font = new PdfGridFont { FontFamily = "@fontFamily", FontSize = 9 },
                            FontColor = "#0B6623",
                            Bold = true
                        },
                        Record = new PdfThemeStyle
                        {
                            Font = new PdfGridFont { FontFamily = "@fontFamily", FontSize = 10 },
                            FontColor = "#B22222",
                            Bold = true
                        }
                    }
                };
            await Grid.ExportToPdfAsync(exportProps);
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderDetails.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData(int orderID, string customerID, double freight, string shipCity, string shipName, string shipCountry)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.Freight = freight;
        this.ShipCity = shipCity;
        this.ShipName = shipName;
        this.ShipCountry = shipCountry;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 32.38, "Reims", "Vins et alcools Chevalier", "France"));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, "Münster", "Toms Spezialitäten", "Germany"));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, "Rio de Janeiro", "Hanari Carnes", "Brazil"));
            Orders.Add(new OrderData(10251, "VICTE", 41.34, "Lyon", "Victuailles en stock", "France"));
            Orders.Add(new OrderData(10252, "SUPRD", 51.3, "Charleroi", "Suprêmes délices", "Belgium"));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, "Rio de Janeiro", "Hanari Carnes", "Brazil"));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, "Bern", "Chop-suey Chinese", "Switzerland"));
            Orders.Add(new OrderData(10255, "RICSU", 148.33, "Genève", "Richter Supermarkt", "Switzerland"));
            Orders.Add(new OrderData(10256, "WELLI", 13.97, "Resende", "Wellington Import Export", "Brazil"));
            Orders.Add(new OrderData(10257, "HILAA", 81.91, "San Cristóbal", "Hila Alimentos", "Venezuela"));
            Orders.Add(new OrderData(10258, "ERNSH", 140.51, "Graz", "Ernst Handel", "Austria"));
            Orders.Add(new OrderData(10259, "CENTC", 3.25, "México D.F.", "Centro comercial", "Mexico"));
            Orders.Add(new OrderData(10260, "OTTIK", 55.09, "Köln", "Ottilies Käseladen", "Germany"));
            Orders.Add(new OrderData(10261, "QUEDE", 3.05, "Rio de Janeiro", "Que delícia", "Brazil"));
            Orders.Add(new OrderData(10262, "RATTC", 48.29, "Albuquerque", "Rattlesnake Canyon Grocery", "USA"));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXrIjIjeLyPqfijX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Add custom font

In addition to changing the default font, the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to use a custom font for the Grid header, content, and caption cells in the exported document. This can be achieved by utilizing the [PdfExportProperties.Theme](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfTheme.html) property.

When using a custom font, it's important to provide the font in a format that can be easily embedded in the exported document. This is typically done by encoding the font file into a base64 string. This base64 encoded font data can then be used within the export settings to ensure the custom font is applied to the exported PDF document.

The following example demonstrates how to use the custom **Algeria** font for exporting the Grid. The **base64AlgeriaFont** variable contains the base64 encoded string representing the **Algeria** font file. This encoded font data is used in the PDF export properties to specify the custom font.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="Grid" DataSource="@Orders" AllowPdfExport="true" AllowGrouping="true" Toolbar="@(new List<string>() { "PdfExport" })" Height="348">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="OrderData"></GridEvents>
    <GridGroupSettings Columns="@Initial"></GridGroupSettings>

    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true" />
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150" />
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120" />
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150" />
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150" />
    </GridColumns>
</SfGrid>

@code {

    private SfGrid<OrderData> Grid;
    public string fontFamily { get; set; } = "AAEAAAANAIAAAwBQRFNJRw5vA.....";

    public List<OrderData> Orders { get; set; }

    public string[] Initial = (new string[] { "ShipCity" });
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_pdfexport") //Id is combination of Grid's ID and itemname.
        {
            var exportProps = new PdfExportProperties
                {
                    Theme = new PdfTheme
                    {
                        Header = new PdfThemeStyle
                        {
                            Font = new PdfGridFont { FontFamily = "@fontFamily", FontSize = 11 },
                            FontColor = "#000080",
                            Bold = true,
                            Border = new PdfBorder { Color = "#5A5A5A", DashStyle = PdfDashStyle.Solid }
                        },
                        Caption = new PdfThemeStyle
                        {
                            Font = new PdfGridFont { FontFamily = "@fontFamily", FontSize = 9 },
                            FontColor = "#0B6623",
                            Bold = true
                        },
                        Record = new PdfThemeStyle
                        {
                            Font = new PdfGridFont { FontFamily = "@fontFamily", FontSize = 10 },
                            FontColor = "#B22222",
                            Bold = true
                        }
                    }
                };
            await Grid.ExportToPdfAsync(exportProps);
        }
    }

}

{% endhighlight %}

{% highlight c# tabtitle="OrderDetails.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData(int orderID, string customerID, double freight, string shipCity, string shipName, string shipCountry)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.Freight = freight;
        this.ShipCity = shipCity;
        this.ShipName = shipName;
        this.ShipCountry = shipCountry;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 32.38, "Reims", "Vins et alcools Chevalier", "France"));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, "Münster", "Toms Spezialitäten", "Germany"));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, "Rio de Janeiro", "Hanari Carnes", "Brazil"));
            Orders.Add(new OrderData(10251, "VICTE", 41.34, "Lyon", "Victuailles en stock", "France"));
            Orders.Add(new OrderData(10252, "SUPRD", 51.3, "Charleroi", "Suprêmes délices", "Belgium"));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, "Rio de Janeiro", "Hanari Carnes", "Brazil"));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, "Bern", "Chop-suey Chinese", "Switzerland"));
            Orders.Add(new OrderData(10255, "RICSU", 148.33, "Genève", "Richter Supermarkt", "Switzerland"));
            Orders.Add(new OrderData(10256, "WELLI", 13.97, "Resende", "Wellington Import Export", "Brazil"));
            Orders.Add(new OrderData(10257, "HILAA", 81.91, "San Cristóbal", "Hila Alimentos", "Venezuela"));
            Orders.Add(new OrderData(10258, "ERNSH", 140.51, "Graz", "Ernst Handel", "Austria"));
            Orders.Add(new OrderData(10259, "CENTC", 3.25, "México D.F.", "Centro comercial", "Mexico"));
            Orders.Add(new OrderData(10260, "OTTIK", 55.09, "Köln", "Ottilies Käseladen", "Germany"));
            Orders.Add(new OrderData(10261, "QUEDE", 3.05, "Rio de Janeiro", "Que delícia", "Brazil"));
            Orders.Add(new OrderData(10262, "RATTC", 48.29, "Albuquerque", "Rattlesnake Canyon Grocery", "USA"));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjByXSXoVxArjAFT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Rotate a header text in the exported PDF document

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides support for customize the column header and content styles, such as changing text orientation, the font color, the width of the header and content text, and so on in the exported PDF document. To achieve this requirement, you can use the [BeginCellLayout](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_BeginCellLayout) event of the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) class along with a custom event handler.

To rotate a column header text in a PDF document, follow these steps:

1. The [PdfHeaderQueryCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_PdfHeaderQueryCellInfoEvent) event is triggered when creating a column header for the PDF document to be exported. In this event, you can collect the column header details and handle customizations.

2. In the `BeginCellLayout` event handler, you can use the `Graphics.DrawString` method to rotate the header text to the desired degree, will be triggered when creating a column header for the PDF document to be exported. Collect the column header details in this event and handle the custom in the `BeginCellLayout` event handler.

In the following demo, the [DrawString](https://help.syncfusion.com/cr/document-processing/Syncfusion.Pdf.Graphics.PdfGraphics.html#Syncfusion_Pdf_Graphics_PdfGraphics_DrawString_System_String_Syncfusion_Pdf_Graphics_PdfFont_Syncfusion_Pdf_Graphics_PdfBrush_System_Drawing_PointF_) method from the [Graphics](https://help.syncfusion.com/cr/document-processing/Syncfusion.Pdf.Graphics.PdfGraphics.html) is used to rotate the header text of the column header inside the `BeginCellLayout` event handler.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Pdf.Graphics
@using Syncfusion.PdfExport
@using System.Drawing
@using Syncfusion.Pdf

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" GridLines="GridLine.Both" Toolbar="@(new List<string>() {"PdfExport" })" AllowPdfExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" PdfHeaderQueryCellInfoEvent="PdfHeaderQueryCellInfoHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" TextAlign="TextAlign.Center" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="ShipCity" TextAlign="TextAlign.Center" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>


@code {
    public SfGrid<OrderData> DefaultGrid;
    public List<OrderData> Orders { get; set; }
    List<string> headerValues = new List<string>();

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_pdfexport")  // Id is combination of Grid's ID and itemname.
        {
            PdfExportProperties ExportProperties = new PdfExportProperties();
            ExportProperties.BeginCellLayout = new PdfGridBeginCellLayoutEventHandler(BeginCellEvent);
            ExportProperties.FileName = "test.pdf";
            ExportProperties.IsRepeatHeader = true;
            await this.DefaultGrid.PdfExport(ExportProperties);
        }
    }

    // Handles custom drawing for each cell (used here for header rotation).
    public void BeginCellEvent(object sender, PdfGridBeginCellLayoutEventArgs args)
    {
        PdfGrid grid = (PdfGrid)sender;

        // Apply gray brush for header text.
        var brush = new Syncfusion.PdfExport.PdfSolidBrush(new Syncfusion.PdfExport.PdfColor(Color.DimGray));
        args.Graphics.Save();

        // Translate the origin for rotated text.
        args.Graphics.TranslateTransform(args.Bounds.X + 50, args.Bounds.Height + 40);

        // Rotate text (e.g., -60 degrees).
        args.Graphics.RotateTransform(-60);

        // Draw the text at particular bounds.
        args.Graphics.DrawString(headerValues[args.CellIndex], new Syncfusion.PdfExport.PdfStandardFont(Syncfusion.PdfExport.PdfFontFamily.Helvetica, 10), brush, new PointF(0, 0));

        // Clear default header text so rotated version is used.
        if (args.IsHeaderRow)
        {
            grid.Headers[0].Cells[args.CellIndex].Value = string.Empty;
        }
        args.Graphics.Restore();
    }

    public void PdfHeaderQueryCellInfoHandler(PdfHeaderQueryCellInfoEventArgs args)
    {
        headerValues.Add(args.Column.HeaderText);
        var longestString = headerValues.Where(s => s.Length == headerValues.Max(m => m.Length)).
                            First();
        Syncfusion.PdfExport.PdfFont font = new Syncfusion.PdfExport.PdfStandardFont(Syncfusion.PdfExport.PdfFontFamily.Helvetica, 6);
        SizeF size = font.MeasureString(longestString);

        // Adjust header height to accommodate rotated text.
        args.PdfGridColumn.Grid.Headers[0].Height = size.Width * 2;
    }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
}
<style>
    .e-grid .e-header {
        font-weight: bold !important;
    }

    .e-grid .e-columnheader .e-headercell {
        height: 100px;
        transform: rotate(-60deg); // This is used to rotate the header text.
    }
</style>

{% endhighlight %}

{% highlight c# tabtitle="OrderDetails.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData(int orderID, string customerID, double freight, string shipCity, string shipName, string shipCountry)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.Freight = freight;
        this.ShipCity = shipCity;
        this.ShipName = shipName;
        this.ShipCountry = shipCountry;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 32.38, "Reims", "Vins et alcools Chevalier", "France"));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, "Münster", "Toms Spezialitäten", "Germany"));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, "Rio de Janeiro", "Hanari Carnes", "Brazil"));
            Orders.Add(new OrderData(10251, "VICTE", 41.34, "Lyon", "Victuailles en stock", "France"));
            Orders.Add(new OrderData(10252, "SUPRD", 51.3, "Charleroi", "Suprêmes délices", "Belgium"));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, "Rio de Janeiro", "Hanari Carnes", "Brazil"));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, "Bern", "Chop-suey Chinese", "Switzerland"));
            Orders.Add(new OrderData(10255, "RICSU", 148.33, "Genève", "Richter Supermarkt", "Switzerland"));
            Orders.Add(new OrderData(10256, "WELLI", 13.97, "Resende", "Wellington Import Export", "Brazil"));
            Orders.Add(new OrderData(10257, "HILAA", 81.91, "San Cristóbal", "Hila Alimentos", "Venezuela"));
            Orders.Add(new OrderData(10258, "ERNSH", 140.51, "Graz", "Ernst Handel", "Austria"));
            Orders.Add(new OrderData(10259, "CENTC", 3.25, "México D.F.", "Centro comercial", "Mexico"));
            Orders.Add(new OrderData(10260, "OTTIK", 55.09, "Köln", "Ottilies Käseladen", "Germany"));
            Orders.Add(new OrderData(10261, "QUEDE", 3.05, "Rio de Janeiro", "Que delícia", "Brazil"));
            Orders.Add(new OrderData(10262, "RATTC", 48.29, "Albuquerque", "Rattlesnake Canyon Grocery", "USA"));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

![PDF Exported Grid Cell Customization in Blazor DataGrid](./images/blazor-datagrid-pdf-exported-grid-cell-customization.png)

> You can find a complete sample on [GitHub](https://github.com/SyncfusionExamples/exporting-blazor-datagrid/tree/master/Exporting-PDF-Datagrid/Rotate_header).

## Exporting Blazor DataGrid data as stream

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows exporting Grid data as a memory stream, enabling programmatic handling before saving or processing. The following sections cover how to export Grid data as a memory stream, merge multiple memory streams into one, and convert the memory stream to a file stream for saving the exported file.

### Exporting Blazor DataGrid data as memory stream

The export to memory stream feature allows you to export data from a Grid to a memory stream instead of saving it to a file directly on the server. This can be particularly useful when you want to generate and serve the file directly to the client without saving it on the server, ensuring a smooth and efficient download process.

To achieve this functionality, you can utilize the [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToPdfAsync_Syncfusion_Blazor_Grids_PdfExportProperties_) method along with the `asMemoryStream` parameter set to **true** within the [OnToolbarClick](https://blazor.syncfusion.com/documentation/datagrid/events#ontoolbarclick) event. This method will export an PDF document as a memory stream, which can then be sent to the browser for download.

The provided example showcases the process of exporting the file as a memory stream and sending the byte to initiate a browser download.

**Step 1**: **Add JavaScript for file download**

Create a JavaScript file named **saveAsFile.js** under the **wwwroot** directory and include the following function to trigger browser download:

{% tabs %}
{% highlight razor tabtitle="saveAsFile.js" %}

function saveAsFile(filename, bytesBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + bytesBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

{% endhighlight %}
{% endtabs %}

**Step 2**:**Register the JavaScript file**

Include the script reference inside your **App.razor** (or **index.html** in Blazor WebAssembly):

{% tabs %}
{% highlight razor tabtitle="App.razor" %}

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <base href="/" />
    <link rel="stylesheet" href="bootstrap/bootstrap.min.css" />
    <link rel="stylesheet" href="app.css" />
    <link rel="stylesheet" href="BlazorApp1.styles.css" />
    <link rel="icon" type="image/png" href="favicon.png" />
    <script src="saveAsFile.js"></script>
    <HeadOutlet @rendermode="InteractiveServer" />
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>
<body>
    <Routes @rendermode="InteractiveServer" />
    <script src="_framework/blazor.web.js"></script>
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
</html>

{% endhighlight %}
{% endtabs %}

**Step 3: Invoke the JavaScript function to perform the browser download using the memory stream**

In the **Index.razor** file, the Grid is set up, the export operation is triggered, and the `saveAsFile` function is invoked to handle the browser download.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids;
@using Syncfusion.Blazor.Navigations;
@using System.IO;
@using Syncfusion.Pdf
@using Syncfusion.PdfExport;
@inject IJSRuntime JSRuntime

<SfGrid ID="Grid" @ref="Grid" DataSource="@Orders" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true" />
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150" />
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120" />
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150" />
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150" />
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {       
        if (args.Item.Id == "Grid_pdfexport") //Id is combination of Grid's ID and itemname.
        {
            MemoryStream streamDoc = await Grid.ExportToPdfAsync(asMemoryStream: true);
            await JSRuntime.InvokeVoidAsync("saveAsFile", new object[] {"PdfMemoryStream.pdf", Convert.ToBase64String(streamDoc.ToArray()), true });
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

> You can find a complete sample on [GitHub](https://github.com/SyncfusionExamples/exporting-blazor-datagrid/tree/master/Exporting-PDF-Datagrid/Blazor_Memory_Stream).

### Converting memory stream to file stream for PDF export

The PDF Export feature in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to converting a memory stream obtained from the [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToPdfAsync_Syncfusion_Blazor_Grids_PdfExportProperties_) method into a file stream to export PDF document.

To know about exporting Grid as a Stream to a PDF document in Grid, you can check this video.

{% youtube "youtube:https://www.youtube.com/watch?v=H5rqB_hBpUM"%}

To achieve this, you can use the [OnToolbarClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnToolbarClick) event in conjunction with the `ExportToPdfAsync` method. The `ExportToPdfAsync` method generates the PDF document as a `MemoryStream`. You can then convert this memory stream into a `FileStream` and save the file to a specified location.

The example below demonstrates how to achieve this by converting the memory stream into a file stream for saving the exported PDF document:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using System.IO;
@using Syncfusion.Pdf
@using Syncfusion.PdfExport;
@inject IJSRuntime JSRuntime

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> DefaultGrid;
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {       
       if (args.Item.Id == "Grid_pdfexport") //Id is combination of Grid's ID and itemname.
        {
            // Memory stream to file stream exporting. 
            MemoryStream streamDoc1 = await DefaultGrid.ExportToPdfAsync(asMemoryStream: true);

            // Create a copy of streamDoc1. 
            MemoryStream copyOfStreamDoc1 = new MemoryStream(streamDoc1.ToArray());

            // For creating the exporting location with file name, for this need to specify the physical exact path of the file. 
            string filePaths = "C:Users/abc/Downloads/SampleTestPdf.pdf";

            // Create a file stream to write the memory stream contents to a file.
            using (FileStream fileStream = File.Create(filePaths))
            {
                 // Copy the memory stream data to the file stream.
                 copyOfStreamDoc1.CopyTo(fileStream);
            }
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

 public class OrderData
 {
     public static List<OrderData> Orders = new List<OrderData>();
     public OrderData() { }
     public OrderData(int OrderID, string CustomerID, double Freight, DateTime? OrderDate)
     {
         this.OrderID = OrderID;
         this.CustomerID = CustomerID;
         this.Freight = Freight;
         this.OrderDate = OrderDate;
     }

     public static List<OrderData> GetAllRecords()
     {
         if (Orders.Count == 0)
         {
             Orders.Add(new OrderData { OrderID = 10248, CustomerID = "VINET", Freight = 32.38, OrderDate = new DateTime(1996, 7, 4) });
             Orders.Add(new OrderData { OrderID = 10249, CustomerID = "TOMSP", Freight = 11.61, OrderDate = new DateTime(1996, 7, 5) });
             Orders.Add(new OrderData { OrderID = 10250, CustomerID = "HANAR", Freight = 65.83, OrderDate = new DateTime(1996, 7, 6) });
             Orders.Add(new OrderData { OrderID = 10251, CustomerID = "VINET", Freight = 41.34, OrderDate = new DateTime(1996, 7, 7) });
             Orders.Add(new OrderData { OrderID = 10252, CustomerID = "SUPRD", Freight = 151.30, OrderDate = new DateTime(1996, 7, 8) });
             Orders.Add(new OrderData { OrderID = 10253, CustomerID = "HANAR", Freight = 58.17, OrderDate = new DateTime(1996, 7, 9) });
             Orders.Add(new OrderData { OrderID = 10254, CustomerID = "CHOPS", Freight = 22.98, OrderDate = new DateTime(1996, 7, 10) });
             Orders.Add(new OrderData { OrderID = 10255, CustomerID = "VINET", Freight = 148.33, OrderDate = new DateTime(1996, 7, 11) });
             Orders.Add(new OrderData { OrderID = 10256, CustomerID = "HANAR", Freight = 13.97, OrderDate = new DateTime(1996, 7, 12) });
         }
         return Orders;
     }

     public int OrderID { get; set; }
     public string CustomerID { get; set; }
     public double? Freight { get; set; }
     public DateTime? OrderDate { get; set; }
 }

{% endhighlight %}
{% endtabs %}

> You can find a complete sample on [GitHub](https://github.com/SyncfusionExamples/exporting-blazor-datagrid/tree/master/Exporting-PDF-Datagrid/PDF_Converting_Memory_Stream).

### Merging two PDF memory streams

When merging two PDF memory stream files and exporting the resulting merged file as a PDF document. To accomplish this, you can use the PDF documents [Merge](https://help.syncfusion.com/cr/document-processing/Syncfusion.Pdf.PdfDocumentBase.html?#Syncfusion_Pdf_PdfDocumentBase_Merge_Syncfusion_Pdf_PdfDocumentBase_Syncfusion_Pdf_Parsing_PdfLoadedDocument_) method available in the [PdfDocumentBase](https://help.syncfusion.com/cr/document-processing/Syncfusion.Pdf.PdfDocumentBase.html) class, class. To achieve this functionality, you can utilize the [Syncfusion.Blazor.Pdf](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core) package.

The provided example demonstrates the merging of two memory streams and exporting the resulting merged memory stream for browser download.

In this example, there are two memory streams: *streamDoc1* and *streamDoc2*. streamDoc1 represents the normal Grid memory stream, while streamDoc2 contains the memory stream of a customized Grid using the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) class. The merging process combines these streams into a new PDF document, converting it into a memory stream. This merged memory stream is then utilized to initiate the browser download.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using System.IO;
@using Syncfusion.Pdf;
@using Syncfusion.PdfExport;
@inject IJSRuntime JSRuntime

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> DefaultGrid;
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_pdfexport") //Id is combination of Grid's ID and itemname.
        {
            //Merging two memory stream.
            MemoryStream mergedStream = new MemoryStream();

            //Creates a PDF document.
            Syncfusion.Pdf.PdfDocument finalDoc = new Syncfusion.Pdf.PdfDocument();
            MemoryStream streamDoc1 = await DefaultGrid.ExportToPdfAsync(asMemoryStream: true);

            //Create a copy of streamDoc1 to access the memory stream.
            MemoryStream copyOfStreamDoc1 = new MemoryStream(streamDoc1.ToArray());

            //Customized Grid for memory stream export.
            PdfExportProperties ExportProperties = new PdfExportProperties();
            PdfTheme Theme = new PdfTheme();
            PdfBorder HeaderBorder = new PdfBorder();
            HeaderBorder.Color = "#000000";

            PdfThemeStyle HeaderThemeStyle = new PdfThemeStyle()
            {
                FontColor = "#6A5ACD",
                FontName = "Comic Sans MS",
                FontSize = 17,
                Bold = true,
                Border = HeaderBorder
            };
            Theme.Header = HeaderThemeStyle;

            PdfThemeStyle RecordThemeStyle = new PdfThemeStyle()
            {
                FontColor = "#800080",
                FontName = "Comic Sans MS",
                FontSize = 14,
                Border = HeaderBorder
            };
            Theme.Record = RecordThemeStyle;

            ExportProperties.Theme = Theme;
            MemoryStream streamDoc2 = await DefaultGrid.ExportToPdfAsync(asMemoryStream: true, ExportProperties);

            // Create a copy of streamDoc2 to access the memory stream.
            MemoryStream copyOfStreamDoc2 = new MemoryStream(streamDoc2.ToArray());

            // Creates a PDF stream for merging.
            Stream[] streams = { copyOfStreamDoc1, copyOfStreamDoc2 };
            Syncfusion.Pdf.PdfDocument.Merge(finalDoc, streams);
            finalDoc.Save(mergedStream);
            await JSRuntime.InvokeVoidAsync("saveAsFile", new object[] { "MemoryStreamMerge.pdf", Convert.ToBase64String(mergedStream.ToArray()), true });
        }
    }
}

{% endhighlight %}

{% highlight js tabtitle="wwwroot/saveAsFile.js" %}

function saveAsFile(filename, bytesBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + bytesBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData() { }

    public OrderData(int OrderID, string CustomerID,  double Freight, DateTime? OrderDate)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData { OrderID = 10248, CustomerID = "VINET", Freight = 32.38, OrderDate = new DateTime(1996, 7, 4) });
            Orders.Add(new OrderData { OrderID = 10249, CustomerID = "TOMSP", Freight = 11.61, OrderDate = new DateTime(1996, 7, 5) });
            Orders.Add(new OrderData { OrderID = 10250, CustomerID = "HANAR", Freight = 65.83, OrderDate = new DateTime(1996, 7, 6) });
            Orders.Add(new OrderData { OrderID = 10251, CustomerID = "VINET", Freight = 41.34, OrderDate = new DateTime(1996, 7, 7) });
            Orders.Add(new OrderData { OrderID = 10252, CustomerID = "SUPRD", Freight = 151.30, OrderDate = new DateTime(1996, 7, 8) });
            Orders.Add(new OrderData { OrderID = 10253, CustomerID = "HANAR", Freight = 58.17, OrderDate = new DateTime(1996, 7, 9) });
            Orders.Add(new OrderData { OrderID = 10254, CustomerID = "CHOPS", Freight = 22.98, OrderDate = new DateTime(1996, 7, 10) });
            Orders.Add(new OrderData { OrderID = 10255, CustomerID = "VINET", Freight = 148.33, OrderDate = new DateTime(1996, 7, 11) });
            Orders.Add(new OrderData { OrderID = 10256, CustomerID = "HANAR", Freight = 13.97, OrderDate = new DateTime(1996, 7, 12) });
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
}

{% endhighlight %}
{% endtabs %}

> You can find a complete sample on [GitHub](https://github.com/SyncfusionExamples/exporting-blazor-datagrid/tree/master/Exporting-PDF-Datagrid/Merging_Two_PDF_Memory_Stream).