---
layout: post
title: Integrate Syncfusion Blazor DataGrid with Bold Report Viewer
description: Step-by-step guide to integrate the Syncfusion Blazor DataGrid component and the Bold Reports Report Viewer in a Blazor application.
platform: Blazor
control: Common
documentation: ug
---

# Integrating Syncfusion® Blazor DataGrid with Bold Report Viewer

This guide explains how to integrate the [Syncfusion® Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) with the [Bold Report Viewer](https://www.boldreports.com/) to display grid data inside RDLC/RDL reports. This enables scenarios such as exporting grid data, generating printable reports, and providing data‑driven visualizations directly from a Blazor application.

A common use case for this integration is when applications require users to interact with data and then generate a corresponding report. Users can filter, sort, or edit records in the DataGrid and immediately view a matching RDLC/RDL report. This is especially useful in scenarios like **order processing**, **inventory management**, **CRM**, or **financial reviews**. It allows teams to produce invoices, summaries, or audit-ready documents directly from the same screen without additional tools or data re‑entry.

If you haven't created your Blazor app yet, follow the [Blazor getting started guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio) to create a project.

## Prerequisites
Make sure your development environment meets the [system requirements](https://blazor.syncfusion.com/documentation/system-requirements) for Syncfusion Blazor components.

## Install required NuGet packages

Use NuGet Package Manager (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*) and install the following packages:

* [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid)
* [Syncfusion.Blazor.Buttons](https://www.nuget.org/packages/Syncfusion.Blazor.Buttons)
* [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes)
* [BoldReports.Net.Core](https://www.nuget.org/packages/BoldReports.Net.Core)
* [Microsoft.AspNetCore.Mvc.NewtonsoftJson](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson/)
* [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient)

## Add required namespaces

Open the `~Components/_Imports.razor` file and import the `Syncfusion.Blazor`, `Syncfusion.Blazor.Grids`, `Syncfusion.Blazor.Buttons` namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

{% endhighlight %}
{% endtabs %}

## Register Syncfusion Blazor Service

Register the Syncfusion Blazor Service in the `Program.cs` file of the Blazor Server App.

{% tabs %}
{% highlight razor tabtitle="~/Program.cs" hl_lines="1 7 8 9 12 16 17 18" %}


using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSyncfusionBlazor();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddMemoryCache();

// HttpClient for server-side calls
builder.Services.AddHttpClient();

var app = builder.Build();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapControllers(); 
app.Run();

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

Add the Syncfusion theme CSS and required scripts to the `~/Components/App.razor` file. The Bold Report Viewer requires its specific script in addition to the core script. 

{% tabs %}
{% highlight html  %}

<head>
     <!-- Syncfusion theme style sheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
    <!-- Bold Report Viewer CSS -->
    <link href="https://cdn.boldreports.com/12.2.6/content/v2.0/tailwind-light/bold.report-viewer.min.css" rel="stylesheet" />

</head>

<body>
    <!-- Syncfusion Blazor DataGrid component's script reference -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"></script>
    <!-- Syncfusion Blazor Bold Report Viewer script reference-->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://cdn.boldreports.com/12.2.6/scripts/v2.0/common/bold.reports.common.min.js"></script>
    <script src="https://cdn.boldreports.com/12.2.6/scripts/v2.0/common/bold.reports.widgets.min.js"></script>
    <script src="https://cdn.boldreports.com/12.2.6/scripts/v2.0/bold.report-viewer.min.js"></script>
    <!-- Interop -->
    <script src="@Assets["scripts/boldreports-interop.js"]" ></script>
</body>

{% endhighlight %}
{% endtabs %}

N> Syncfusion provides multiple theme variants, allowing selection of the theme that best aligns with the application's UI design. Additional theme options and customization details are available in the [theming documentation](https://blazor.syncfusion.com/documentation/appearance/themes).

## Add a sample report

### Create interop file

Create an interop JS (in this example used as `bold-reports-interop.js` file name) inside the `wwwroot/scripts` folder and use the following code snippet to invoke the Bold Report Viewer.

{% tabs %}
{% highlight js tabtitle="boldreports-interop.js"  %}

window.BoldReports = {
    renderViewer: function (elementId, options) {
        $("#" + elementId).boldReportViewer({
            reportServiceUrl: options.serviceUrl,
            processingMode: "Local",
            reportPath: options.reportPath
        });
    },
    postDataAndRender: async function (orders, serviceUrl, reportPath, elementId) {
        try {
            const resp = await fetch('/api/BoldReportsAPI/SetReportData', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ dataSources: orders })
            });
            if (!resp.ok) throw new Error('POST failed: ' + resp.status);

            $("#" + elementId).empty();
            $("#" + elementId).boldReportViewer({
                reportServiceUrl: serviceUrl,
                processingMode: "Local",
                reportPath: reportPath
            });
        } catch (e) {
          throw e;
        }
    }
};

{% endhighlight %}
{% endtabs %}

### Add the RDLC report

Create a new folder inside the `wwwroot` folder in your application to store the RDL reports. Then, add any previously created RDL reports to this newly created folder or use the below `rdl` file.

{% tabs %}
{% highlight xml tabtitle="Orders.rdlc"  %}

<?xml version="1.0" encoding="utf-8"?>
<Report xmlns:rd="http://schemas.microsoft.com/SQLServer/reporting/reportdesigner" xmlns="http://schemas.microsoft.com/sqlserver/reporting/2016/01/reportdefinition">
  <AutoRefresh>0</AutoRefresh>
  <ReportSections>
    <ReportSection>
      <Body>
        <ReportItems>
          <Textbox Name="ReportTitle">
            <CanGrow>true</CanGrow>
            <KeepTogether>true</KeepTogether>
            <Paragraphs>
              <Paragraph>
                <TextRuns>
                  <TextRun>
                    <Value>Orders Report</Value>
                    <Style>
                      <FontSize>14pt</FontSize>
                      <FontWeight>Bold</FontWeight>
                    </Style>
                  </TextRun>
                </TextRuns>
                <Style />
              </Paragraph>
            </Paragraphs>
            <Top>0in</Top>
            <Left>0in</Left>
            <Height>0.35in</Height>
            <Width>7.5in</Width>
            <ZIndex>1</ZIndex>
            <Style>
              <TextAlign>Center</TextAlign>
            </Style>
          </Textbox>

          <Tablix Name="OrdersTable">
            <TablixBody>
              <TablixColumns>
                <TablixColumn><Width>1.2in</Width></TablixColumn>
                <TablixColumn><Width>1.8in</Width></TablixColumn>
                <TablixColumn><Width>1.8in</Width></TablixColumn>
                <TablixColumn><Width>1.2in</Width></TablixColumn>
              </TablixColumns>
              <TablixRows>
                <TablixRow>
                  <Height>0.28in</Height>
                  <TablixCells>
                    <TablixCell><CellContents><Textbox Name="Hdr_OrderID"><CanGrow>true</CanGrow><KeepTogether>true</KeepTogether><Paragraphs><Paragraph><TextRuns><TextRun><Value>Order ID</Value><Style><FontWeight>Bold</FontWeight></Style></TextRun></TextRuns><Style /></Paragraph></Paragraphs><Style><BackgroundColor>#F2F2F2</BackgroundColor><Border><Style>Solid</Style></Border><PaddingLeft>4pt</PaddingLeft><PaddingRight>4pt</PaddingRight><PaddingTop>2pt</PaddingTop><PaddingBottom>2pt</PaddingBottom></Style></Textbox></CellContents></TablixCell>
                    <TablixCell><CellContents><Textbox Name="Hdr_CustomerID"><CanGrow>true</CanGrow><KeepTogether>true</KeepTogether><Paragraphs><Paragraph><TextRuns><TextRun><Value>Customer ID</Value><Style><FontWeight>Bold</FontWeight></Style></TextRun></TextRuns><Style /></Paragraph></Paragraphs><Style><BackgroundColor>#F2F2F2</BackgroundColor><Border><Style>Solid</Style></Border><PaddingLeft>4pt</PaddingLeft><PaddingRight>4pt</PaddingRight><PaddingTop>2pt</PaddingTop><PaddingBottom>2pt</PaddingBottom></Style></Textbox></CellContents></TablixCell>
                    <TablixCell><CellContents><Textbox Name="Hdr_OrderDate"><CanGrow>true</CanGrow><KeepTogether>true</KeepTogether><Paragraphs><Paragraph><TextRuns><TextRun><Value>Order Date</Value><Style><FontWeight>Bold</FontWeight></Style></TextRun></TextRuns><Style /></Paragraph></Paragraphs><Style><BackgroundColor>#F2F2F2</BackgroundColor><Border><Style>Solid</Style></Border><PaddingLeft>4pt</PaddingLeft><PaddingRight>4pt</PaddingRight><PaddingTop>2pt</PaddingTop><PaddingBottom>2pt</PaddingBottom></Style></Textbox></CellContents></TablixCell>
                    <TablixCell><CellContents><Textbox Name="Hdr_Freight"><CanGrow>true</CanGrow><KeepTogether>true</KeepTogether><Paragraphs><Paragraph><TextRuns><TextRun><Value>Freight</Value><Style><FontWeight>Bold</FontWeight></Style></TextRun></TextRuns><Style /></Paragraph></Paragraphs><Style><BackgroundColor>#F2F2F2</BackgroundColor><Border><Style>Solid</Style></Border><PaddingLeft>4pt</PaddingLeft><PaddingRight>4pt</PaddingRight><PaddingTop>2pt</PaddingTop><PaddingBottom>2pt</PaddingBottom></Style></Textbox></CellContents></TablixCell>
                  </TablixCells>
                </TablixRow>
                <TablixRow>
                  <Height>0.26in</Height>
                  <TablixCells>
                    <TablixCell><CellContents><Textbox Name="Val_OrderID"><CanGrow>true</CanGrow><KeepTogether>true</KeepTogether><Paragraphs><Paragraph><TextRuns><TextRun><Value>=Fields!OrderID.Value</Value><Style /></TextRun></TextRuns><Style /></Paragraph></Paragraphs><Style><Border><Style>Solid</Style></Border><PaddingLeft>4pt</PaddingLeft><PaddingRight>4pt</PaddingRight><PaddingTop>2pt</PaddingTop><PaddingBottom>2pt</PaddingBottom></Style></Textbox></CellContents></TablixCell>
                    <TablixCell><CellContents><Textbox Name="Val_CustomerID"><CanGrow>true</CanGrow><KeepTogether>true</KeepTogether><Paragraphs><Paragraph><TextRuns><TextRun><Value>=Fields!CustomerID.Value</Value><Style /></TextRun></TextRuns><Style /></Paragraph></Paragraphs><Style><Border><Style>Solid</Style></Border><PaddingLeft>4pt</PaddingLeft><PaddingRight>4pt</PaddingRight><PaddingTop>2pt</PaddingTop><PaddingBottom>2pt</PaddingBottom></Style></Textbox></CellContents></TablixCell>
                    <TablixCell><CellContents><Textbox Name="Val_OrderDate"><CanGrow>true</CanGrow><KeepTogether>true</KeepTogether><Paragraphs><Paragraph><TextRuns><TextRun><Value>=Fields!OrderDate.Value</Value><Style><Format>dd-MMM-yyyy</Format></Style></TextRun></TextRuns><Style /></Paragraph></Paragraphs><Style><Border><Style>Solid</Style></Border><PaddingLeft>4pt</PaddingLeft><PaddingRight>4pt</PaddingRight><PaddingTop>2pt</PaddingTop><PaddingBottom>2pt</PaddingBottom></Style></Textbox></CellContents></TablixCell>
                    <TablixCell><CellContents><Textbox Name="Val_Freight"><CanGrow>true</CanGrow><KeepTogether>true</KeepTogether><Paragraphs><Paragraph><TextRuns><TextRun><Value>=Fields!Freight.Value</Value><Style><Format>C2</Format></Style></TextRun></TextRuns><Style /></Paragraph></Paragraphs><Style><Border><Style>Solid</Style></Border><PaddingLeft>4pt</PaddingLeft><PaddingRight>4pt</PaddingRight><PaddingTop>2pt</PaddingTop><PaddingBottom>2pt</PaddingBottom><TextAlign>Right</TextAlign></Style></Textbox></CellContents></TablixCell>
                  </TablixCells>
                </TablixRow>
              </TablixRows>
            </TablixBody>
            <TablixColumnHierarchy>
              <TablixMembers>
                <TablixMember />
                <TablixMember />
                <TablixMember />
                <TablixMember />
              </TablixMembers>
            </TablixColumnHierarchy>
            <TablixRowHierarchy>
              <TablixMembers>
                <TablixMember>
                  <KeepWithGroup>After</KeepWithGroup>
                  <RepeatOnNewPage>true</RepeatOnNewPage>
                </TablixMember>
                <TablixMember>
                  <Group Name="Detail" />
                </TablixMember>
              </TablixMembers>
            </TablixRowHierarchy>
            <Top>0.5in</Top>
            <Left>0in</Left>
            <Height>0.54in</Height>
            <Width>6.0in</Width>
            <ZIndex>2</ZIndex>
            <DataSetName>OrdersDataSet</DataSetName>
            <Style />
          </Tablix>
        </ReportItems>
        <Height>2in</Height>
        <Style />
      </Body>
      <Width>7.5in</Width>
      <Page>
        <PageHeight>11in</PageHeight>
        <PageWidth>8.5in</PageWidth>
        <LeftMargin>1in</LeftMargin>
        <RightMargin>1in</RightMargin>
        <TopMargin>1in</TopMargin>
        <BottomMargin>1in</BottomMargin>
        <Style />
      </Page>
    </ReportSection>
  </ReportSections>

  <DataSources>
    <DataSource Name="DummyDataSource">
      <ConnectionProperties>
        <DataProvider>System.Data.DataSet</DataProvider>
        <ConnectString>/* Local RDLC Business Object */</ConnectString>
      </ConnectionProperties>
      <rd:DataSourceID>2BA47F3B-787C-4EF9-9A18-FC9405C53C7B</rd:DataSourceID>
    </DataSource>
  </DataSources>

  <DataSets>
    <DataSet Name="OrdersDataSet">
      <Fields>
        <Field Name="OrderID">
          <DataField>OrderID</DataField>
          <rd:TypeName>System.Int32</rd:TypeName>
        </Field>
        <Field Name="CustomerID">
          <DataField>CustomerID</DataField>
          <rd:TypeName>System.String</rd:TypeName>
        </Field>
        <Field Name="OrderDate">
          <DataField>OrderDate</DataField>
          <rd:TypeName>System.DateTime</rd:TypeName>
        </Field>
        <Field Name="Freight">
          <DataField>Freight</DataField>
          <rd:TypeName>System.Double</rd:TypeName>
        </Field>
      </Fields>
      <Query>
        <DataSourceName>DummyDataSource</DataSourceName>
        <CommandText>/* Local RDLC */</CommandText>
      </Query>
    </DataSet>
  </DataSets>

  <rd:ReportUnitType>Inch</rd:ReportUnitType>
  <rd:ReportID>2BA47F3B-787C-4EF9-9A18-FC9405C53C7B</rd:ReportID>
</Report>

{% endhighlight %}
{% endtabs %}

### Configure the Web API

The Blazor Report Viewer requires a Web API service to process the RDL, RDLC, and SSRS report files.

**Add Web API Controller**

* Right-click the project and select **Add > New** Item from the context menu.

* In the Add New Item dialog, select **API Controller Empty** class and name it as `BoldReportsAPIController.cs`.

* Click Add.

* Open the **BoldReportsAPIController** and add the following code to implement the Bold Reports `IReportController` for handling report requests.

The Report Viewer requires data in a **DataSet** format. In the following example, API converts the posted DataGrid data (JSON) into a `DataSet` named `OrdersDataSet` that matches the `RDLC` file.

{% tabs %}
{% highlight c# tabtitle="BoldReportsAPIController.cs"  %}

using System.Collections.Generic;
using System.Data;
using System.IO;
using BoldReports.Web; // Added for ReportDataSource & ReportDataSourceCollection
using BoldReports.Web.ReportViewer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

[ApiController]
[Route("api/[controller]/[action]")]
public class BoldReportsAPIController : Controller, IReportController
{
    private readonly IMemoryCache _cache;
    private readonly IWebHostEnvironment _env;
    private static List<Order>? _sharedOrders;
    private static DataSet? _reportDataSet;

    public BoldReportsAPIController(IMemoryCache cache, IWebHostEnvironment env)
    {
        _cache = cache;
        _env = env;
    }

    [HttpPost]
    public object PostReportAction([FromBody] Dictionary<string, object> json)
        => ReportHelper.ProcessReport(json, this, _cache);

    [HttpPost]
    public object PostFormReportAction()
        => ReportHelper.ProcessReport(null, this, _cache);

    [HttpGet]
    public object GetResource([FromQuery] ReportResource resource)
        => ReportHelper.GetResource(resource, this, _cache);

    [HttpPost]
    public IActionResult SetReportData([FromBody] ReportDataModel dataModel)
    {
        try
        {
            if (dataModel?.DataSources != null && dataModel.DataSources.Count > 0)
            {
                _sharedOrders = dataModel.DataSources;

                // Convert List<Order> to DataSet with DataTable
                DataSet ds = new();
                DataTable dt = new("OrdersDataSet");

                // Add columns matching the RDLC report
                dt.Columns.Add("OrderID", typeof(int));
                dt.Columns.Add("CustomerID", typeof(string));
                dt.Columns.Add("OrderDate", typeof(DateTime));
                dt.Columns.Add("Freight", typeof(double));

                // Add rows from orders
                foreach (var order in _sharedOrders)
                {
                    dt.Rows.Add(order.OrderID, order.CustomerID, order.OrderDate, order.Freight);
                }

                ds.Tables.Add(dt);
                _reportDataSet = ds;
                _cache.Set("ReportDataSet", ds, TimeSpan.FromMinutes(10));

                return Ok(new { success = true, message = "Data set successfully" });
            }
            return BadRequest(new { success = false, message = "No data provided" });
        }
        catch (Exception ex)
        {
           return BadRequest(new { success = false, message = ex.Message });
        }
    }

    [NonAction]
    public void OnInitReportOptions(ReportViewerOptions options)
    {
        try
        {
            options.ReportModel.ProcessingMode = ProcessingMode.Local;

            var path = Path.Combine(_env.WebRootPath, "Reports", "Orders.rdlc");
            
            if (!System.IO.File.Exists(path))
            {
                throw new FileNotFoundException($"RDLC file not found at: {path}");
            }

            var stream = new MemoryStream();
            using (var fs = System.IO.File.OpenRead(path))
            {
                fs.CopyTo(stream);
            }
            stream.Position = 0;

            options.ReportModel.Stream = stream;
            options.ReportModel.ReportPath = "Orders.rdlc";
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"[OnInitReportOptions] Error: {ex.Message}");
        }
    }

    [NonAction]
    public void OnReportLoaded(ReportViewerOptions options)
    {
        try
        {
            // Retrieve the DataSet from cache or static variable
            DataSet? ds = null;
            if (_cache.TryGetValue("ReportDataSet", out object? cachedData) && cachedData is DataSet cachedDs)
            {
                ds = cachedDs;
            }
            else if (_reportDataSet != null)
            {
                ds = _reportDataSet;
            }

            if (ds != null && ds.Tables.Contains("OrdersDataSet"))
            {
                var table = ds.Tables["OrdersDataSet"];
                options.ReportModel.DataSources = new ReportDataSourceCollection
                {
                    new ReportDataSource("OrdersDataSet", table)
                };
            }
            else
            {
                System.Console.WriteLine("[OnReportLoaded] No DataSet/Table named 'OrdersDataSet' found");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"[OnReportLoaded] Error: {ex.Message}");
        }
    }
    
    public class ReportDataModel
    {
        public List<Order> DataSources { get; set; } = [];
    }
}

{% endhighlight %}
{% endtabs %}

## Integrating DataGrid and Report Viewer

Create or update any `.razor` page (e.g., Pages/Home.razor) to host both the DataGrid and the Report Viewer.

Inject **IJSRuntime**, render the DataGrid and invoke the JavaScript interop with the `Orders.rdlc` report and the created BoldReportsAPI URL in the `Components/Pages/Index.razor` file to visualize the report using the viewer.

{% tabs %}
{% highlight razor tabtitle="Home.razor"  %}

@page "/"

@using Syncfusion.Blazor.Grids
@inject IJSRuntime JS
@inject HttpClient Http
@inject NavigationManager Nav

<div class="container mt-5">
    <h2>Orders Data Grid & Bold Reports Integration</h2>
        
    <SfButton CssClass="e-primary mt-3" IsPrimary="true" OnClick="@OpenReport">
        Open RDLC Report
    </SfButton>
    
    <SfGrid DataSource="@Orders">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
    </SfGrid>
    
    <div id="viewer" style="height:80vh; margin-top:20px;"></div>
</div>

@code{
    public List<Order> Orders { get; set; } = [];
   
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 10).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)] ?? "ALFKI",
            Freight = 2 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }
    
    public async Task OpenReport()
    {  
        
        try
        {
              
            // Step 1: Send the grid data to the server API
            var dataModel = new { DataSources = Orders };
            var baseUrl = Nav.BaseUri.TrimEnd('/');
            var url = $"{baseUrl}/api/BoldReportsAPI/SetReportData".Replace("//api", "/api");
            var response = await Http.PostAsJsonAsync(url, dataModel);
                       
            // Step 2: Render the viewer with the data
            var viewerOptions = new
            {
                serviceUrl = "/api/BoldReportsAPI",
                reportPath = "Orders.rdlc"
            };

            await JS.InvokeVoidAsync("BoldReports.renderViewer", "viewer", viewerOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex}");
        }
       
    }

    public class Order {
        public int? OrderID { get; set; }
        public string? CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

## Run the application

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. 

**Expected behavior**
* DataGrid renders with sample records.
* Clicking **Open RDLC Report** sends the grid data to the Web API.
* The Bold Report Viewer loads and displays the report.

**Output:**
![Blazor DataGrid with Bold Report Viewer](./images/data-grid-boldreport.webp)

## See also

* [How to use the Bold Reports Report Viewer in a Blazor WebAssembly App](https://help.boldreports.com/embedded-reporting/javascript-reporting/report-viewer/how-to/use-javascript-reportviewer-in-blazor-web-assembly-application/)
* [How to use the Bold Reports Report Viewer in a Blazor Server App](https://help.boldreports.com/embedded-reporting/javascript-reporting/report-viewer/how-to/use-javascript-reportviewer-in-blazor-server-application/)
* [Explore the Blazor reporting components available in Bold Reports](https://www.boldreports.com/blog/blazor-reporting-components)
* [Getting started with Syncfusion Blazor DataGrid](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app) 
