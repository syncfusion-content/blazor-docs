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


## ExpandoObject binding

The Syncfusion Blazor DataGrid is a generic component typically bound to a specific model type. However, there are scenarios where the model type is unknown during compile time. In such cases, you can bind data to the Grid using a list of **ExpandoObject**. This allows for dynamic data structures that can adapt to various data shapes without a predefined schema.

To know about **ExpandoObject** data binding in Blazor Grid, you can check on this video.

{% youtube
"youtube:https://www.youtube.com/watch?v=Xhaw3DdHmJk"%}

To bind an ExpandoObject to the Grid, you need to assign it to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property. The Grid supports various data operations such as sorting, filtering, and editing when using ExpandoObject.

The following sample demonstrates **ExpandoObject** binding:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using System.Dynamic

<SfGrid DataSource="@Orders" AllowPaging="true" Toolbar="@ToolbarItems">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="CustomerID" HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field="Freight" HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="OrderDate" HeaderText=" Order Date" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field="ShipCountry" HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
        <GridColumn Field="Verified" HeaderText="Active" DisplayAsCheckBox="true" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<ExpandoObject> Orders { get; set; } = new List<ExpandoObject>();
    private List<string> ToolbarItems = new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" };

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select((x) =>
        {
            dynamic d = new ExpandoObject();
            d.OrderID = 1000 + x;
            d.CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)];
            d.Freight = (new double[] { 2, 1, 4, 5, 3 })[new Random().Next(5)] * x;
            d.OrderDate = (new DateTime[] { new DateTime(2010, 11, 5), new DateTime(2018, 10, 3), new DateTime(1995, 9, 9), new DateTime(2012, 8, 2), new DateTime(2015, 4, 11) })[new Random().Next(5)];
            d.ShipCountry = (new string[] { "USA", "UK" })[new Random().Next(2)];
            d.Verified = (new bool[] { true, false })[new Random().Next(2)];

            return d;
        }).Cast<ExpandoObject>().ToList<ExpandoObject>();

    }
}

{% endhighlight %}
{% endtabs %}

### ExpandoObject Complex data binding

This feature is useful for binding complex data structures to the Syncfusion Blazor DataGrid. You can achieve complex data binding with ExpandoObject by using the dot (.) operator in the `Column.Field` property. This allows you to access nested properties within the **ExpandoObject**.

In the following example, the fields `CustomerID.Name` and `ShipCountry.Country` represent complex data bound to the Grid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using System.Dynamic

<SfGrid DataSource="@Orders" AllowPaging="true" AllowFiltering="true" AllowSorting="true" AllowGrouping="true" Toolbar="@ToolbarItems">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="CustomerID.Name" HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field="Freight" HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="OrderDate" HeaderText=" Order Date" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field="ShipCountry.Country" HeaderText="Ship Country"  Width="150"></GridColumn>
        <GridColumn Field="Verified" HeaderText="Active" DisplayAsCheckBox="true" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<ExpandoObject> Orders { get; set; } = new List<ExpandoObject>();
    private List<string> ToolbarItems = new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" };

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select((x) =>
        {
            dynamic d = new ExpandoObject();
            dynamic customerName = new ExpandoObject();
            dynamic countryName = new ExpandoObject();
            d.OrderID = 1000 + x;
            customerName.Name = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)];
            d.CustomerID = customerName;
            d.Freight = (new double[] { 2, 1, 4, 5, 3 })[new Random().Next(5)] * x;
            d.OrderDate = (new DateTime[] { new DateTime(2010, 11, 5), new DateTime(2018, 10, 3), new DateTime(1995, 9, 9), new DateTime(2012, 8, 2), new DateTime(2015, 4, 11) })[new Random().Next(5)];
            countryName.Country = (new string[] { "USA", "UK" })[new Random().Next(2)];
            d.ShipCountry = countryName;
            d.Verified = (new bool[] { true, false })[new Random().Next(2)];

            return d;
        }).Cast<ExpandoObject>().ToList<ExpandoObject>();
    }
}

{% endhighlight %}
{% endtabs %}

N> You can perform the Data operations and CRUD operations for Complex **ExpandoObject** binding fields too.

The following image represents **ExpandoObject** complex data binding,

![Binding ExpandObject with Complex Data in Blazor DataGrid](./images/blazor-datagrid-expand-complex-data.png)

## DynamicObject binding

The Syncfusion Blazor DataGrid is a generic component which is strongly bound to a model type. However, there are scenarios where the model type is unknown during compile time. In such cases, you can bind data to the Grid using a list of **ExpandoObject**. This allows for dynamic data structures that can adapt to various data shapes without a predefined schema.

To bind an **ExpandoObject** to the Grid, you need to assign it to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property. This enables the Grid to perform various supported data operations and editing on the **DynamicObject**.

To know about **DynamicObject** data binding in Blazor Grid, you can check on this video.

{% youtube
"youtube:https://www.youtube.com/watch?v=Xhaw3DdHmJk"%}

N> The [GetDynamicMemberNames](https://learn.microsoft.com/en-us/dotnet/api/system.dynamic.dynamicobject.getdynamicmembernames?view=net-8.0) method of **DynamicObject** class must be overridden and return the property names to perform data operation and editing while using **DynamicObject**.

Here’s an example of how to bind a list of DynamicObject to the Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using System.Dynamic

<SfGrid DataSource="@Orders" AllowPaging="true" Toolbar="@ToolbarItems">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="CustomerID" HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field="OrderDate" HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" EditType="EditType.DatePickerEdit" Width="130"></GridColumn>
        <GridColumn Field="Freight" HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private List<string> ToolbarItems = new List<string>(){ "Add","Edit","Delete","Update","Cancel"};
    public List<DynamicDictionary> Orders = new List<DynamicDictionary>() { };
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 1075).Select((x) =>
        {
            dynamic d = new DynamicDictionary();
            d.OrderID = 1000 + x;
            d.CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)];
            d.Freight = (new double[] { 2, 1, 4, 5, 3 })[new Random().Next(5)] * x;
            d.OrderDate = DateTime.Now.AddDays(-x);
            return d;
        }).Cast<DynamicDictionary>().ToList<DynamicDictionary>();
    }
    public class DynamicDictionary : DynamicObject
    {
        Dictionary<string, object> dictionary = new Dictionary<string, object>();

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string name = binder.Name;
            return dictionary.TryGetValue(name, out result);
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            dictionary[binder.Name] = value;
            return true;
        }

        public override System.Collections.Generic.IEnumerable<string> GetDynamicMemberNames()
        {
            return this.dictionary?.Keys;
        }
    }
}

{% endhighlight %}
{% endtabs %}

#### DynamicObject Complex data binding

You can achieve complex data binding with **DynamicObject** in the Syncfusion Blazor DataGrid by using the dot (.) operator in the `Column.Field` property. This allows you to access and bind to nested properties within the **DynamicObject**, enabling the display of structured data in the Grid.

In the following example, `CustomerID.Name` and `ShipCountry.Country` are considered complex data fields that are bound to the Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using System.Dynamic

<SfGrid DataSource="@Orders" AllowPaging="true" AllowFiltering="true" AllowSorting="true" AllowGrouping="true" Toolbar="@ToolbarItems">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="CustomerID.Name" HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field="OrderDate" HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" EditType="EditType.DatePickerEdit" Width="130"></GridColumn>
        <GridColumn Field="Freight" HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="ShipCountry.Country" HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private List<string> ToolbarItems = new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" };
    public List<DynamicDictionary> Orders = new List<DynamicDictionary>() { };
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 1075).Select((x) =>
        {
            dynamic d = new DynamicDictionary();
            dynamic combo = new DynamicDictionary();
            dynamic countryName = new DynamicDictionary();
            d.OrderID = 1000 + x;
            combo.Name = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)];
            d.CustomerID = combo;
            d.Freight = (new double[] { 2, 1, 4, 5, 3 })[new Random().Next(5)] * x;
            d.OrderDate = DateTime.Now.AddDays(-x);
            countryName.Country = (new string[] { "USA", "UK" })[new Random().Next(2)];
            d.ShipCountry = countryName;
            return d;
        }).Cast<DynamicDictionary>().ToList<DynamicDictionary>();
    }
    public class DynamicDictionary : DynamicObject
    {
        Dictionary<string, object> dictionary = new Dictionary<string, object>();

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string name = binder.Name;
            return dictionary.TryGetValue(name, out result);
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            dictionary[binder.Name] = value;
            return true;
        }

        public override System.Collections.Generic.IEnumerable<string> GetDynamicMemberNames()
        {
            return this.dictionary?.Keys;
        }
    }
}

{% endhighlight %}
{% endtabs %}

N> * you can perform the Data operations and CRUD operations for Complex **DynamicObject** binding fields too.

The following image represents **DynamicObject** complex data binding

![Binding DynamicObject with Complex Data in Blazor DataGrid](./images/blazor-datagrid-dynamic-complex-data.png)

N> While binding the Grid datasource dynamically in the form of a list of IEnumerable collections, you need to call the [Refresh](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Refresh_System_Boolean_) method of the Grid to reflect the changes externally. Because tracking items of IEnumerable for changes made externally is avoided for performance considerations.

## HTTP client

It is possible to call web api from the Blazor WebAssembly(client-side) app. This can be used for sending HTTP requests to fetch data from web api and bind them in the DataGrid's data source. The requests are sent using [HttpClient](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-3.0) service.

This can be achieved by initially injecting the `HttpClient` instance in the app.

```cshtml
@using System.Net.Http
@inject HttpClient Http
```

After that the data to be fetched is defined in the api controller of the Blazor WebAssembly app.

{% tabs %}
{% highlight cs tabtitle="EmployeeController.cs" %}

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    List<Employee> employee = new List<Employee>();
    [HttpGet]
    public object Get()
    {
        employee.Add(new Employee { EmployeeID = 1, FirstName = "Andrew", LastName = "Fuller", Title = "Branch Manager" });
        employee.Add(new Employee { EmployeeID = 2, FirstName = "Nancy", LastName = "Leverling", Title = "Product Manager" });
        employee.Add(new Employee { EmployeeID = 3, FirstName = "Anne", LastName = "Dodsworth", Title = "Team Lead" });
        employee.Add(new Employee { EmployeeID = 4, FirstName = "Laura", LastName = "Callahan", Title = "Product Manager" });
        employee.Add(new Employee { EmployeeID = 5, FirstName = "Michael", LastName = "Suyama", Title = "Team Lead" });
        employee.Add(new Employee { EmployeeID = 6, FirstName = "Robert", LastName = "King", Title = "Developer" });
        employee.Add(new Employee { EmployeeID = 7, FirstName = "Janet", LastName = "Peacock", Title = "Developer" });
        employee.Add(new Employee { EmployeeID = 8, FirstName = "Steven", LastName = "Buchanan", Title = "Developer" });
        employee.Add(new Employee { EmployeeID = 9, FirstName = "Margaret", LastName = "Davolio", Title = "Developer" });
        return employee;
    }
}

public class Employee
{
    public int? EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
}

{% endhighlight %}
{% endtabs %}

Then using the `GetFromJsonAsync` method request is sent to the api controller for fetching data which is bounded to the DataGrid's data source

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@inject HttpClient Http

<SfGrid DataSource="@Employees" AllowPaging="true">
    <GridPageSettings PageSize="7"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Employee.EmployeeID) HeaderText="Employee ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Employee.FirstName) HeaderText="First Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Employee.LastName) HeaderText="Last Name" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Employee.Title) HeaderText="Title" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Employee> Employees { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Employees = await Http.GetFromJsonAsync<List<Employee>>("https://localhost:XXXX/api/Employee");
    }

    public class Employee
    {
        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

N> The above steps are processed in the Blazor WebAssembly app which has the pre-configured `HttpClient` service. For Blazor server apps, web api calls are created using [IHttpClientFactory](https://learn.microsoft.com/en-gb/dotnet/api/system.net.http.ihttpclientfactory?view=dotnet-plat-ext-7.0). More information on making requests using `IHttpClientFactory` is available in this [link](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-3.0).

## Observable collection

An Observable collection is a special type of collection in .NET that automatically notifies any subscribers (such as the UI or other components) when changes are made to the collection. This is particularly useful in data-binding scenarios, where you want the UI to reflect changes in the underlying data model without having to manually update the view.

This [ObservableCollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1?view=netframework-4.8)(dynamic data collection) provides notifications when items added, removed and moved. The implement [INotifyCollectionChanged](https://learn.microsoft.com/en-us/dotnet/api/system.collections.specialized.inotifycollectionchanged?view=netframework-4.8) notifies when dynamic changes of add,remove, move and clear the collection. The implement [INotifyPropertyChanged](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=netframework-4.8) notifies when property value has changed in client side.

Here, Order class implements the interface of **INotifyPropertyChanged** and it raises the event when CustomerID property value was changed.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data
@using Syncfusion.Blazor.Buttons
@using System.Collections.ObjectModel


<div Style="margin-bottom:15px">
    <SfButton CssClass="e-outline" OnClick="@(() => AddRecords())" Content="Add Data"></SfButton>
    <SfButton CssClass="e-outline" Style="margin-left:5px" OnClick="@(() => DelRecords())" Content="Delete Data"></SfButton>
    <SfButton CssClass="e-outline" Style="margin-left:5px" OnClick="@(() => UpdateRecords())" Content="Update Data"></SfButton>
</div>

<SfGrid DataSource="@GridData" AllowReordering="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrdersDetailsObserveData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" HeaderTextAlign="@TextAlign.Center" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetailsObserveData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetailsObserveData.Freight) HeaderText="Freight" EditType="EditType.NumericEdit" Format="C2" Width="140" TextAlign="@TextAlign.Right" HeaderTextAlign="@TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetailsObserveData.OrderDate) HeaderText="Order Date" EditType="EditType.DatePickerEdit" Format="d" Type="ColumnType.Date" Width="160"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetailsObserveData.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>


@code {

    public ObservableCollection<OrdersDetailsObserveData> GridData { get; set; }
    public int Count = 32341;

    protected override void OnInitialized()
    {
        GridData = OrdersDetailsObserveData.GetRecords();
    }

    public void AddRecords()
    {
        GridData.Add(new OrdersDetailsObserveData(Count++, "ALFKI", 4343, 2.3 * 43, false, new DateTime(1991, 05, 15), "Berlin", "Simons bistro", "Denmark", new DateTime(1996, 7, 16), "Kirchgasse 6"));
    }

    public void DelRecords()
    {
        GridData.Remove(GridData.First());
    }

    public void UpdateRecords()
    {
        var a = GridData.First();
        a.CustomerID = "Update";
    }
}

{% endhighlight %}

{% highlight cs tabtitle="OrdersDetailsObserveData.cs" %}

using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BlazorApp1.Data
{
    public class OrdersDetailsObserveData : INotifyPropertyChanged
    {
        public OrdersDetailsObserveData()
        {
        }
        public OrdersDetailsObserveData(int OrderID, string CustomerId, int EmployeeId, double Freight, bool Verified, DateTime OrderDate, string ShipCity, string ShipName, string ShipCountry, DateTime ShippedDate, string ShipAddress)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerId;
            this.EmployeeID = EmployeeId;
            this.Freight = Freight;
            this.ShipCity = ShipCity;
            this.Verified = Verified;
            this.OrderDate = OrderDate;
            this.ShipName = ShipName;
            this.ShipCountry = ShipCountry;
            this.ShippedDate = ShippedDate;
            this.ShipAddress = ShipAddress;
        }
        public static ObservableCollection<OrdersDetailsObserveData> GetRecords()
        {
            ObservableCollection<OrdersDetailsObserveData> order = new ObservableCollection<OrdersDetailsObserveData>();
            int code = 10000;
            for (int i = 1; i < 2; i++)
            {
                order.Add(new OrdersDetailsObserveData(code + 1, "ALFKI", i + 0, 2.3 * i, false, new DateTime(1991, 05, 15), "Berlin", "Simons bistro", "Denmark", new DateTime(1996, 7, 16), "Kirchgasse 6"));
                order.Add(new OrdersDetailsObserveData(code + 2, "ANATR", i + 2, 3.3 * i, true, new DateTime(1990, 04, 04), "Madrid", "Queen Cozinha", "Brazil", new DateTime(1996, 9, 11), "Avda. Azteca 123"));
                order.Add(new OrdersDetailsObserveData(code + 3, "ANTON", i + 1, 4.3 * i, true, new DateTime(1957, 11, 30), "Cholchester", "Frankenversand", "Germany", new DateTime(1996, 10, 7), "Carrera 52 con Ave. Bol�var #65-98 Llano Largo"));
                order.Add(new OrdersDetailsObserveData(code + 4, "BLONP", i + 3, 5.3 * i, false, new DateTime(1930, 10, 22), "Marseille", "Ernst Handel", "Austria", new DateTime(1996, 12, 30), "Magazinweg 7"));
                order.Add(new OrdersDetailsObserveData(code + 5, "BOLID", i + 4, 6.3 * i, true, new DateTime(1953, 02, 18), "Tsawassen", "Hanari Carnes", "Switzerland", new DateTime(1997, 12, 3), "1029 - 12th Ave. S."));
                code += 5;
            }
            return order;
        }

        public int OrderID { get; set; }
        public string CustomerID
        {
            get { return customerID; }
            set
            {
                customerID = value;
                NotifyPropertyChanged("CustomerID");
            }
        }
        public string customerID { get; set; }
        public int? EmployeeID { get; set; }
        public double? Freight { get; set; }
        public string ShipCity { get; set; }
        public bool Verified { get; set; }
        public DateTime? OrderDate { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ShipName { get; set; }

        public string ShipCountry { get; set; }

        public DateTime ShippedDate { get; set; }
        public string ShipAddress { get; set; }

        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

{% endhighlight %}
{% endtabs %}

The following screenshot represents the DataGrid with **Observable Collection**.

![Blazor DataGrid with ObservableCollection](./images/b)

N> While using an Observable collection, the added, removed, and changed records are reflected in the UI. But while updating the Observable collection using external actions like timers, events, and other notifications, you need to call the StateHasChanged method to reflect the changes in the UI.

## Troubleshoot: DataGrid renders without data even though server returns with correct data

In ASP.NET Core, by default the JSON results are returned in **camelCase** format. So datagrid field names are also changed in **camelCase**.

To avoid this problem, you need to add [DefaultContractResolver](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.serialization.datacontractresolver?view=net-7.0) in **Startup.cs** file.

```csharp
public void ConfigureServices(IServiceCollection services)
{
  services.AddRazorPages();
  services.AddServerSideBlazor().AddCircuitOptions();
  services.AddSingleton<WeatherForecastService>();
  services.AddMvc().AddNewtonsoftJson(options =>
  {
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
  });
}
```

## Handling exceptions

Exceptions occurred during  Syncfusion Blazor Grid actions can be handled without stopping application.  You can capture these error messages or exception details using the [OnActionFailure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnActionFailure) event of the Grid. This event provides an argument containing the error details returned from the server.

N> We recommend you to bind **OnActionFailure** event during your application development phase, this helps you to find any exceptions. You can pass these exception details to our support team to get solution as early as possible.

The following sample code demonstrates how to notify when a server-side exception occurs during a data operation:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data

<div class="error-container">
    <span class="error">@ErrorDetails</span>
</div>
<SfGrid TValue="Order" AllowPaging="true">
    <GridEvents TValue="Order" OnActionFailure="@ActionFailure"></GridEvents>
    <GridPageSettings PageSize="10"></GridPageSettings>
    <SfDataManager Url="https://some.com/invalidUrl" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .error-container {
        display: flex;
        justify-content: center;
        margin-bottom: 20px;
    }

    .error {
        color: red;
        font-weight: bold;
    }
</style>


@code{
    public string ErrorDetails = "";
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }

    public void ActionFailure(FailureEventArgs args)
    {
        this.ErrorDetails = "Server exception: 404 Not found";
        StateHasChanged();
    }
}

{% endhighlight %}
{% endtabs %}
