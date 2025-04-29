---
layout: post
title: Lazy Load Grouping in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Lazy Load Grouping in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

## Managing spinner visibility during data loading

Showing a spinner during data loading in the Syncfusion Blazor DataGrid enhances the experience by providing a visual indication of the loading progress. This feature helps to understand that data is being fetched or processed.

To show or hide a spinner during data loading in the Grid, you can utilize the [ShowSpinnerAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ShowSpinnerAsync) and [HideSpinnerAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_HideSpinnerAsync) methods provided by the Grid.

The following example demonstrates how to show and hide the spinner during data loading using external buttons in a Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data
@using Syncfusion.Blazor.Buttons

<div Style="margin-bottom:15px">
    <SfButton CssClass="e-outline" OnClick="@(() => OnLoadData())" Content="Load Data"></SfButton>
    <SfButton CssClass="e-outline" Style="margin-left:5px" OnClick="@(() => ShowHideSpinner("showButton"))" Content="Show Spinner"></SfButton>
    <SfButton CssClass="e-outline" Style="margin-left:5px" OnClick="@(() => ShowHideSpinner("hideButton"))" Content="Hide Spinner"></SfButton>
</div>
<SfGrid @ref="Grid" TValue="OrderData" AllowPaging="true">
    <GridColumns>
        <GridColumn Field="@nameof(OrderData.OrderID)" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field="@nameof(OrderData.CustomerID)" HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrderData.ProductName)" HeaderText="Product Name" Width="110"></GridColumn>
        <GridColumn Field="@nameof(OrderData.Quantity)" HeaderText="Quantity" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    private async Task OnLoadData()
    {
        await Grid.ShowSpinnerAsync();
        Grid.DataSource = Orders;
        await Grid.HideSpinnerAsync();
    }

    // Method to show/hide the spinner based on button click
    private async Task ShowHideSpinner(string buttonId)
    {
        if (buttonId == "showButton")
        {
            await Grid.ShowSpinnerAsync();
        }
        else if (buttonId == "hideButton")
        {
            await Grid.HideSpinnerAsync();
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData(int orderID, string customerID, string productName, int quantity)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.ProductName = productName;
        this.Quantity = quantity;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Random random = new Random();
            var customerIDs = new[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD", "CHOPS", "RICSU", "WELLI", "HILAA", "ERNSH", "CENTC", "OTTIK", "QUEDE", "RATTC" };
            var productNames = new[] { "Apple", "Orange", "Banana", "Grapes", "Pineapple", "Peach", "Mango", "Strawberry", "Blueberry", "Watermelon" };

            for (int i = 1; i <= 20000; i++)
            {
                var orderID = i;
                var customerID = customerIDs[random.Next(customerIDs.Length)];
                var productName = productNames[random.Next(productNames.Length)];
                var quantity = random.Next(1, 100); // Random quantity between 1 and 100

                Orders.Add(new OrderData(orderID, customerID, productName, quantity));
            }
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZVSXfVYgqFBPutf?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %}

## Binding data from Excel document

The Syncfusion Blazor DataGrid allows you to import data from Excel files into your web application for display and manipulation within the Grid. This feature streamlines the process of transferring Excel data to a web-based environment. You can achieve this by using the `ValueChange` event of the **File Upload**.

To import Excel data into Grid, you can follow these steps:

1. Use the [File Upload](https://blazor.syncfusion.com/documentation/file-upload/getting-started-with-web-app) to upload the Excel file.

2. Parse the file using the [Syncfusion.XlslO](https://www.nuget.org/packages/Syncfusion.XlsIO.Net.Core/) library.

3. Convert the parsed data into a list of `ExpandoObject`.

4. Bind the list to the Blazor Grid.

The following example demonstrates how an Excel document is uploaded, parsed, converted into a list of ``ExpandoObject`, and then bound to the Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.XlsIO;
@using System.IO;
@using Syncfusion.Blazor.Grids;
@using Syncfusion.Blazor.Inputs;
@using System.Data;
@using System.Dynamic;
@using Microsoft.AspNetCore.Hosting;
@using Syncfusion.Blazor.Popups

<label style="padding:20px 0px 20px 0px;font-weight: bold">Browse excel file to load and return Grid</label>
<div id="target">
    <SfUploader>
        <UploaderEvents OnRemove="OnRemove" ValueChange="OnChange"></UploaderEvents>
    </SfUploader>
</div>
@if (CustomerList != null && CustomerList.Count > 0)
{
    <SfGrid @ref="Grid" DataSource="@CustomerList" AllowPaging="true" Height="340px">
    </SfGrid>
}
<SfDialog @ref="dialog" ID="dialog" Target="#target" Visible="false" ShowCloseIcon="true" Header="Alert">
</SfDialog>

<style>
    #target {
        position: relative;
    }
    .dialog {
        max-height: 107px;
    }
</style>

@code {
    SfGrid<ExpandoObject> Grid;
    SfDialog dialog;
    public DataTable table = new DataTable();
    [Inject] private IWebHostEnvironment HostEnvironment { get; set; }

    private async void OnChange(UploadChangeEventArgs args)
    {
        if (args.Files[0].FileInfo.Type == "xlsx")
        {
            foreach (var file in args.Files)
            {
                var path = GetPath(file.FileInfo.Name);
                ExcelEngine excelEngine = new ExcelEngine();
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2016;

                // Create new file stream at the generated path.
                FileStream openFileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                await file.File.OpenReadStream(long.MaxValue).CopyToAsync(openFileStream);
                openFileStream.Close();

                // Open file stream from saved path.
                FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                IWorkbook workbook = application.Workbooks.Open(fileStream);
                IWorksheet worksheet = workbook.Worksheets[0];
                table = worksheet.ExportDataTable(worksheet.UsedRange, ExcelExportDataTableOptions.ColumnNames);
                GenerateListFromTable(table);
            }

        }
        else
        {
            dialog.Content = "Please upload only .xlsx format";
            dialog.ShowAsync(true);
        }
    }

    private async Task OnRemove(RemovingEventArgs args)
    {
        CustomerList = new List<ExpandoObject>();  // Clear data.
        Columns = null;
    }

    private string GetPath(string filename)
    {
        return Path.Combine(HostEnvironment.WebRootPath, filename);
    }

    string[] Columns;
    public List<ExpandoObject> CustomerList = new List<ExpandoObject>();

    public void GenerateListFromTable(DataTable input)
    {
        // Check if at least one cell has meaningful data.
        bool hasData = input.Rows.Cast<DataRow>()
            .Any(row => row.ItemArray.Any(cell => cell != null && !string.IsNullOrWhiteSpace(cell.ToString())));

        if (!hasData)
        {
            dialog.Content = "The uploaded Excel file contains only blank rows or invalid data.";
            dialog.ShowAsync();
            return; // Exit if the data is invalid.
        }

        var list = new List<ExpandoObject>();
        Columns = input.Columns.Cast<DataColumn>()
                             .Select(x => x.ColumnName)
                             .ToArray();
        foreach (DataRow row in input.Rows)
        {
            System.Dynamic.ExpandoObject e = new System.Dynamic.ExpandoObject();
            foreach (DataColumn col in input.Columns)
                e.TryAdd(col.ColumnName, row.ItemArray[col.Ordinal]);
            list.Add(e);
        }
        CustomerList = list;
        StateHasChanged();
    }
}

{% endhighlight %}
{% endtabs %}

[!Binding data from Excel document](./images/excel-import-data.gif)