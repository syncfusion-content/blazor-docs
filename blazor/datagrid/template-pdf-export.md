---
layout: post
title: Pdf Export with Templates in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Template Pdf Export in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Exporting grid with templates in Blazor DataGrid Component

The grid offers the option to export the column, detail, and caption templates to a PDF document. The template contains images, hyperlinks, and customized text.

## Exporting with column template

The PDF export functionality allows you to export Grid columns that include images, hyperlinks, and custom text to a PDF document. Export the template columns of the DataGrid by defining the [IncludeTemplateColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_IncludeTemplateColumn) of [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) as **true**.

In the following sample, the **CustomerID** column is a template column. The template values cannot be directly exported into the cells. To customize the values of template columns in the PDF document, you must use [PdfQueryCellInfoEvent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_PdfQueryCellInfoEvent).

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true" AllowPaging="true">
    <GridEvents PdfQueryCellInfoEvent="PdfQueryCellInfoHandler" OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150">
            <Template>
                @{
                    var con = (context as Order);
                }
                <span>Mr.@con.CustomerID</span>
            </Template>
        </GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;
    public List<Order> Orders { get; set; }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_pdfexport")  //Id is combination of Grid's ID and itemname
        {
            PdfExportProperties ExportProperties = new PdfExportProperties();
            ExportProperties.IncludeTemplateColumn = true;
            await this.DefaultGrid.ExportToPdfAsync(ExportProperties);
        }
    }
    public void PdfQueryCellInfoHandler(PdfQueryCellInfoEventArgs<Order> args)
    {
        if (args.Column.Field == "CustomerID")
        {
            args.Cell.Value = "Mr." + args.Data.CustomerID;
        }
    }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "Alfki", "Anantr", "Anton", "Blonp", "Bolid" })[new Random().Next(5)],
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

## Exporting with group caption template

The PDF export feature enables exporting of Grid with a caption template to an PDF document.

The example below demonstrates how to customize the caption text in the PDF using the [PdfGroupCaptionTemplateInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_PdfGroupCaptionTemplateInfo) event.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<SfGrid ID="Grid" @ref="Grid" DataSource="@GridData" AllowGrouping="true" Height="315px" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" PdfGroupCaptionTemplateInfo="PdfGroupCaptionInfoHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Name" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="value" Width="80"></GridColumn>
    </GridColumns>
    <GridGroupSettings Columns=@(new string[] { "CustomerID" })>
        <CaptionTemplate>
            @{
                var order = (context as CaptionTemplateContext);
                <span>@order.Key - @order.Count Records : @order.HeaderText</span>
            }
        </CaptionTemplate>
    </GridGroupSettings>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }

    public SfGrid<OrderData> Grid { get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    public async Task ToolbarClickHandler(ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_pdfexport")
        {
            await Grid.ExportToPdfAsync();
        }
    }

    public void PdfGroupCaptionInfoHandler(PdfCaptionTemplateArgs args)
    {
        args.Cell.Value = args.Key + "-" + args.Count + " Records: " + args.HeaderText;       //customize the caption cell value here
    }
    public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();

        public OrderData()
        {

        }
        public OrderData(int? OrderID, string CustomerID, string ShipCity, double? Freight)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.Freight = Freight;
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", "Reims", 3.25));
                    Orders.Add(new OrderData(10249, "TOMSP", "Münster", 22.98));
                    Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", 140.51));
                    Orders.Add(new OrderData(10251, "VICTE", "Lyon", 65.83));
                    Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", 58.17));
                    Orders.Add(new OrderData(10253, "HANAR", "Lyon", 81.91));
                    Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", 3.05));
                    Orders.Add(new OrderData(10255, "RICSU", "Münster", 55.09));
                    Orders.Add(new OrderData(10256, "WELLI", "Reims", 48.29));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public double? Freight { get; set; }
    }
}
```

## Exporting with detail template

By default, the Grid exports the parent grid along with expanded detail rows only. To modify the exporting behavior, utilize the [PdfExportProperties.PdfDetailRowMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfDetailRowMode.html) property. The available options include:

| Mode | Behavior |
|-------|----------|
| Expand | Exports the parent grid with expanded detail rows.
| None | Exports the parent grid alone.

The detail rows in the exported PDF can be customized or formatted using the [PdfDetailTemplateExporting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_PdfDetailTemplateExporting) event. In this event, the detail rows of the PDF document are formatted in accordance with their parent row details.

In the provided example, detail row content is formatted by specifying the [ColumnCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfDetailTemplateRowSettings.html#Syncfusion_Blazor_Grids_PdfDetailTemplateRowSettings_ColumnCount), [Headers](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfDetailTemplateRowSettings.html#Syncfusion_Blazor_Grids_PdfDetailTemplateRowSettings_Headers), [Rows](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfDetailTemplateRowSettings.html#Syncfusion_Blazor_Grids_PdfDetailTemplateRowSettings_Rows) using parent row details, facilitating the creation of detail rows within the PDF. Additionally, custom styles can be applied to specific cells using the [Style](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfDetailTemplateCell.html#Syncfusion_Blazor_Grids_PdfDetailTemplateCell_Style) property.

>If [ColumnCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfDetailTemplateRowSettings.html#Syncfusion_Blazor_Grids_PdfDetailTemplateRowSettings_ColumnCount) is not provided or is less than the number of cells in the first row of Headers/Rows, the columns in the detail row of the PDF grid will be generated based on the count of cells in the first row of Headers/Rows.


```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor

<SfGrid @ref="DefaultGrid" ID="Grid" DataSource="@Employees" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true" Height="450px">
    <GridTemplates>
        <DetailTemplate>
            @{
                var employee = (context as Product);
                <table class="detailtable" width="100%">
                    <colgroup>
                        <col width="40%" />
                        <col width="60%" />
                    </colgroup>
                    <thead>
                        <tr>
                            <th colspan="2" style="font-weight: 500;text-align: center;background-color: #ADD8E6;">
                                Product Details
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td style="text-align: center;">
                                <span>@employee.ProductDesc</span>
                            </td>
                            <td>
                                <span class="link">
                                    Contact: <a href="mailto:${@employee.Contact}">@employee.Contact</a>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;">
                                <span style="font-weight: 500;"> @employee.Cost</span>
                            </td>
                            <td>
                                <span>Available: @employee.Available </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;">
                                <span class="${Status}" style="font-weight: 500;"> @employee.Status</span>
                            </td>
                            <td>
                                <span>@employee.ReturnPolicy</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;">
                                <span style="font-weight: 500;color: #0a76ff;">Offers: @employee.Offers </span>
                            </td>

                            <td>
                                <span>@employee.Cancellation</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;">
                                <span style="font-weight: 500;color: #0a76ff;"> Ratings: @employee.Ratings</span>
                            </td>
                            <td>
                                <span style="font-weight: 500;color: #0a76ff;">@employee.Delivery</span>
                            </td>
                        </tr>
                    </tbody>
                </table>

            }
        </DetailTemplate>
    </GridTemplates>
    <GridEvents PdfDetailTemplateExporting="PdfDetailTemplateHandler" OnToolbarClick="ToolbarClickHandler" TValue="Product"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Product.Category) HeaderText="Category" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(Product.ProductID) HeaderText="Product ID" Width="160"> </GridColumn>
        <GridColumn Field=@nameof(Product.Status) HeaderText="Status" Width="180"></GridColumn>
    </GridColumns>
</SfGrid>

<style type="text/css" class="cssStyles">
    .detailtable td {
        font-size: 13px;
        padding: 4px;
        max-width: 0;
        overflow: hidden;
        text-overflow: ellipsis;
        white-space: nowrap;
        font-weight: normal;
    }
</style>

@code {

    SfGrid<Product> DefaultGrid;
    public List<Product> Employees { get; set; }
    public async Task ToolbarClickHandler(ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_pdfexport")  // Id is the combination of Grid's ID and item name.
        {
            PdfExportProperties PdfExportProperties = new PdfExportProperties();
            PdfExportProperties.PdfDetailRowMode = PdfDetailRowMode.Expand;
            await this.DefaultGrid.ExportToPdfAsync(PdfExportProperties);
        }
    }

    public void PdfDetailTemplateHandler(PdfDetailTemplateEventArgs<Product> args)
    {
        var pdfRows = new List<PdfDetailTemplateRow>();
        var data = args.ParentRow.Data;
        args.RowInfo.ColumnCount = 2;
        args.RowInfo.Headers = new List<PdfDetailTemplateRow>() { new PdfDetailTemplateRow() { Cells = new List<PdfDetailTemplateCell>() { new PdfDetailTemplateCell() { Index = 0, CellValue = "Product Details", ColumnSpan = 2, Style = new PdfThemeStyle() { Bold = true, FontColor = "#0A76FF", FontSize = 13 } } } } };
        pdfRows.Add(new PdfDetailTemplateRow()
            {
                Cells = new List<PdfDetailTemplateCell>()
        {
            new PdfDetailTemplateCell()
            {
                CellValue = data.ProductDesc, Index = 0
            },
            new PdfDetailTemplateCell()
            {
                Index = 1, Hyperlink = new Hyperlink() { DisplayText = data.Contact, Target = data.Contact }
            }
        }
            });
        pdfRows.Add(
            new PdfDetailTemplateRow()
                {
                    Cells = new List<PdfDetailTemplateCell>()
                            {
            new PdfDetailTemplateCell()
            {
                CellValue = data.Cost, Index = 0
            },
            new PdfDetailTemplateCell()
            {
                Index = 1, CellValue = "Available :" + data.Available }
                            }
                });
        pdfRows.Add(new PdfDetailTemplateRow()
            {
                Cells = new List<PdfDetailTemplateCell>()
            {
            new PdfDetailTemplateCell()
            {
                CellValue = data.Status, Index = 0
            },
            new PdfDetailTemplateCell()
            {
                Index = 1, CellValue = data.ReturnPolicy }
            }
            });
        pdfRows.Add(new PdfDetailTemplateRow()
            {
                Cells = new List<PdfDetailTemplateCell>()
            {
            new PdfDetailTemplateCell()
            {
                CellValue = "Offers :" + data.Offers, Index = 0, Style = new PdfThemeStyle()
                {
                  FontColor = "#0A76FF", FontSize = 12
                }
            },
            new PdfDetailTemplateCell()
            {
                Index = 1, CellValue = data.Cancellation }
            }
            });
        pdfRows.Add(new PdfDetailTemplateRow()
            {
                Cells = new List<PdfDetailTemplateCell>()
            {
            new PdfDetailTemplateCell()
            {
                CellValue = "Ratings: " + data.Ratings, Index = 0, Style = new PdfThemeStyle()
                {
                  FontColor = "#0A76FF", FontSize = 12
                }
            },
            new PdfDetailTemplateCell()
            {
                Index = 1, CellValue = data.Delivery, Style = new PdfThemeStyle()
                {
                  FontColor = "#0A76FF", FontSize = 12
                }
            }
            }
            });
        args.RowInfo.Rows = pdfRows;
    }

    protected override void OnInitialized()
    {
        Employees = new List<Product>
        {
            new Product() {Category = "Suits/Slim", Offers="5%", Cost ="199.99$", Available = "10", ItemID="Suit-001",ProductID="EJ-SU-01", Contact="nancy@domain.com", Status = "Available", ProductDesc = "Slim Fit Suit", ReturnPolicy = "No Returns Applicable", Delivery = "** FREE Delivery **", Cancellation = "Cancellation upto 12 hrs", Ratings ="4.5" },
            new Product() {Category = "Suits/Classic", Offers="12%", Cost ="249.99$", Available = "8", ItemID="Suit-002",ProductID="EJ-SU-02", Contact="nancy@domain.com", Status = "Available", ProductDesc = "Classic Fit Suit", ReturnPolicy = "No Returns Applicable", Delivery = "** FREE Delivery **", Cancellation = "Cancellation upto 24 hrs", Ratings ="4.8" },
            new Product() {Category = "Suits/Formal", Offers="5%", Cost ="149.99$", Available = "15", ItemID="Suit-003",ProductID="EJ-SU-03", Contact="nancy@domain.com", Status = "Available", ProductDesc = "Formal Fit Suit", ReturnPolicy = "No Returns Applicable", Delivery = "** FREE Delivery **", Cancellation = "Cancellation upto 12 hrs", Ratings ="4.7" },
            new Product() {Category = "Phants/Slim", Offers="10%", Cost ="19.99$", Available = "50", ItemID="Phant-001",ProductID="EJ-PH-01", Contact="nancy@domain.com", Status = "Available", ProductDesc = "Slim Fit Phant", ReturnPolicy = "Returns Applicable upto 2 days", Delivery = "** FREE Delivery **", Cancellation = "No Cancellation", Ratings ="4.5" },
            new Product() {Category = "Phants/Classic", Offers="10%", Cost ="24.99$", Available = "45", ItemID="Phant-002",ProductID="EJ-PH-02", Contact="nancy@domain.com", Status = "Available", ProductDesc = "Classic Fit Phant", ReturnPolicy = "No Returns Applicable", Delivery = "** FREE Delivery **", Cancellation = "No Cancellation", Ratings ="4.6" },
            new Product() {Category = "Shirts/Slim", Offers="8%", Cost ="19.99$", Available = "30", ItemID="Shirt-001",ProductID="EJ-SH-01", Contact="nancy@domain.com", Status = "Available", ProductDesc = "Slim Fit Shirt", ReturnPolicy = "No Returns Applicable", Delivery = "** FREE Delivery **", Cancellation = "No Cancellation", Ratings ="4.5" },
            new Product() {Category = "Shirts/Formal", Offers="10%", Cost ="14.99$", Available = "30", ItemID="Shirt-002",ProductID="EJ-SH-02", Contact="nancy@domain.com", Status = "Available", ProductDesc = "Formal Shirt", ReturnPolicy = "No Returns Applicable", Delivery = "** FREE Delivery **", Cancellation = "No Cancellation", Ratings ="4.0" },
            new Product() {Category = "Shirts/Classic", Offers="5%", Cost ="249.99$", Available = "25", ItemID="Shirt-003",ProductID="EJ-SH-03", Contact="nancy@domain.com", Status = "Available", ProductDesc = "Slim Fit Classic", ReturnPolicy = "No Returns Applicable", Delivery = "** FREE Delivery **", Cancellation = "Cancellation upto 12 hrs", Ratings ="4.8" },
            new Product() {Category = "Shirts/Slim", Offers="10%", Cost ="14.99$", Available = "30", ItemID="Shirt-001",ProductID="EJ-SH-01", Contact="nancy@domain.com", Status = "Available", ProductDesc = "Slim Fit Shirt", ReturnPolicy = "No Returns Applicable", Delivery = "** FREE Delivery **", Cancellation = "No Cancellation", Ratings ="4.5" },
        };
    }

    public class Product
    {
        public string Category { get; set; }
        public string Offers { get; set; }
        public string Cost { get; set; }
        public string Available { get; set; }
        public string ItemID { get; set; }
        public string ProductID { get; set; }
        public string Contact { get; set; }
        public string Status { get; set; }
        public string ProductImg { get; set; }
        public string ProductDesc { get; set; }
        public string ReturnPolicy { get; set; }
        public string Delivery { get; set; }
        public string Cancellation { get; set; }
        public string Ratings { get; set; }
    }
}
```

## Exporting hierarchical grid using detail template

The Grid have an option to export the hierarchical grid to PDF document using detail template feature. The detail rows in the exported PDF can be customized or formatted using the [PdfDetailTemplateExporting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_PdfDetailTemplateExporting) event. In this event, the detail rows of the PDF document are formatted in accordance with their parent row details.

In the provided example, detail row content is formatted by specifying the [Headers](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfDetailTemplateRowSettings.html#Syncfusion_Blazor_Grids_PdfDetailTemplateRowSettings_Headers), [Rows](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfDetailTemplateRowSettings.html#Syncfusion_Blazor_Grids_PdfDetailTemplateRowSettings_Rows) using parent row details. Additionaly, this achieves a nested level of children using the [ChildRowInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfDetailTemplateRow.html#Syncfusion_Blazor_Grids_PdfDetailTemplateRow_ChildRowInfo) property.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Data

<SfGrid @ref="DefaultGrid" ID="Grid" DataSource="@Employees" AllowPdfExport="true" Toolbar="@(new List<string>() { "PdfExport" })">
    <GridTemplates>
        <DetailTemplate>
            @{
                var employee = (context as EmployeeData);
            }
            <SfGrid DataSource="@Orders" Query="@(new Query().Where("EmployeeID", "equal", employee.EmployeeID))">
                <GridTemplates>
                    <DetailTemplate Context="CustomerContext">
                        @{
                            var customer = (CustomerContext as Order);
                        }
                        <SfGrid DataSource="@OrderInfo" TValue="OrderDetails" Query="@(new Query().Where("OrderID", "equal", customer.OrderID))">
                            <GridColumns>
                                <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" TextAlign="TextAlign.Right" Width="110"> </GridColumn>
                                <GridColumn Field=@nameof(OrderDetails.Title) HeaderText="Title" Width="110"></GridColumn>
                                <GridColumn Field=@nameof(OrderDetails.Address) HeaderText="Address" TextAlign="TextAlign.Right" Width="90" Format="C2"></GridColumn>
                                <GridColumn Field=@nameof(OrderDetails.Country) HeaderText="Country" Width="110"></GridColumn>
                            </GridColumns>
                        </SfGrid>
                    </DetailTemplate>
                </GridTemplates>
                <GridColumns>
                    <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="110"> </GridColumn>
                    <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="110"></GridColumn>
                    <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" Width="90" Format="C2"></GridColumn>
                    <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="110"></GridColumn>
                </GridColumns>
            </SfGrid>
        </DetailTemplate>
    </GridTemplates>
    <GridEvents PdfDetailTemplateExporting="PdfDetailTemplateHandler" OnToolbarClick="ToolbarClickHandler" TValue="EmployeeData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.EmployeeID) HeaderText="EmployeeID" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(EmployeeData.FirstName) HeaderText="First Name" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Title) HeaderText="Title" Width="110"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Country) HeaderText="Country" Width="110"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    SfGrid<EmployeeData> DefaultGrid;
    public List<EmployeeData> Employees { get; set; }
    public List<OrderDetails> OrderInfo { get; set; }
    public static List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Employees = new List<EmployeeData>
        {
            new EmployeeData() {EmployeeID = 1, FirstName="Nancy",  Title="Sales Representative",City="Texas", Country="USA"},
            new EmployeeData() {EmployeeID = 2, FirstName="Andrew",  Title="Vice President",City="London", Country="UK"},
            new EmployeeData() {EmployeeID = 3, FirstName="Janet",  Title="Sales",City="London", Country="UK"},
            new EmployeeData() {EmployeeID = 4, FirstName="Margaret",  Title="Sales Manager",City="London", Country="UK"},
            new EmployeeData() {EmployeeID = 5, FirstName="Steven",  Title="Inside Sales Coordinator",City="Vegas", Country="USA"},
            new EmployeeData() {EmployeeID = 6, FirstName="Smith",  Title="HR Manager",City="Dubai", Country="UAE"},
            new EmployeeData() {EmployeeID = 7, FirstName="Steven",  Title="Inside Sales Coordinator",City="Paris", Country="France"},
            new EmployeeData() {EmployeeID = 8, FirstName="Smith",  Title="HR Manager",City="Mumbai", Country="India"},
            new EmployeeData() {EmployeeID = 9, FirstName="Smith",  Title="HR Manager",City="Chennai", Country="India"},
        };
        Orders = new List<Order>
        {
            new Order() {EmployeeID = 1, OrderID=1001, CustomerID="Nancy", ShipCity="Texas", Freight=2.1*1 },
            new Order() {EmployeeID = 2, OrderID=1002, CustomerID="Andrew", ShipCity="London", Freight=2.1*2},
            new Order() {EmployeeID = 3, OrderID=1003, CustomerID="Janet", ShipCity="London", Freight=2.1*3},
            new Order() {EmployeeID = 4, OrderID=1004, CustomerID="Margaret", ShipCity="London", Freight= 2.1*4},
            new Order() {EmployeeID = 5, OrderID=1005, CustomerID="Steven", ShipCity="Vegas", Freight=2.1*5},
            new Order() {EmployeeID = 6, OrderID=1006, CustomerID="Smith", ShipCity="Dubai", Freight=2.1*6},
            new Order() {EmployeeID = 7, OrderID=1007, CustomerID="Steven", ShipCity="Paris", Freight=2.1*7},
            new Order() {EmployeeID = 8, OrderID=1008, CustomerID="Smith", ShipCity="Mumbai", Freight=2.1*8},
            new Order() {EmployeeID = 9, OrderID=1009, CustomerID="Smith", ShipCity="Chennai", Freight=2.1*9},
            new Order() {EmployeeID = 2, OrderID=1010, CustomerID="Smith", ShipCity="Chennai", Freight=2.1*9},
            new Order() {EmployeeID = 3, OrderID=1011, CustomerID="Smith", ShipCity="Chennai", Freight=2.1*9},
            new Order() {EmployeeID = 3, OrderID=1012, CustomerID="Smith", ShipCity="Chennai", Freight=2.1*9},
        };

        OrderInfo = new List<OrderDetails>
        {
            new OrderDetails() { OrderID=1001, Title="Sales Representative", CustomerID="Nancy", Country="Germany", Address="Obere Str. 57" },
            new OrderDetails() { OrderID=1002, Title="HR Manager", CustomerID="Andrew", Country="Mexico", Address="Avda. de la Constitución 2222"},
            new OrderDetails() { OrderID=1003, Title="Vice President", CustomerID="Janet", Country="Mexico", Address="Mataderos 2312"},
            new OrderDetails() { OrderID=1004, Title="Inside Sales Coordinator", CustomerID="Margaret", Country="Mexico", Address="Mataderos 2312"},
            new OrderDetails() { OrderID=1005, Title="HR Manager", CustomerID="Steven", Country="Spain", Address="C/ Araquil, 67"},
            new OrderDetails() { OrderID=1006, Title="Vice President", CustomerID="Smith", Country="Mexico", Address="Avda. de la Constitución 2222"},
            new OrderDetails() { OrderID=1007, Title="Sales", CustomerID="Steven", Country="France", Address="24, place Kléber"},
            new OrderDetails() { OrderID=1008, Title="HR Manager", CustomerID="Smith", Country="Spain", Address="C/ Araquil, 67"},
            new OrderDetails() { OrderID=1009, Title="Sales", CustomerID="Smith", Country="Mexico", Address="Mataderos 2312"},
            new OrderDetails() { OrderID=1010, Title="Vice President", CustomerID="Smith", Country="Spain", Address="C/ Araquil, 67"},
            new OrderDetails() { OrderID=1011, Title="Inside Sales Coordinator", CustomerID="Smith", Country="Mexico", Address="Mataderos 2312"},
            new OrderDetails() { OrderID=1012, Title="HR Manager", CustomerID="Smith", Country="India", Address="45A "},
        };
    }

    public async Task ToolbarClickHandler(ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_pdfexport")  // Id is the combination of Grid's ID and item name.
        {
            PdfExportProperties PdfExportProperties = new PdfExportProperties();
            PdfExportProperties.PdfDetailRowMode = PdfDetailRowMode.Expand;
            await this.DefaultGrid.ExportToPdfAsync(PdfExportProperties);
        }
    }

    public void PdfDetailTemplateHandler(PdfDetailTemplateEventArgs<EmployeeData> args)
    {
        var pdfRows = new List<PdfDetailTemplateRow>();
        var data = Orders.ToList().Where(_ => _.EmployeeID == args.ParentRow.Data.EmployeeID).ToList();
        for (var i = 0; i < data.Count(); i++)
        {
            var row = data[i];
            var childData = OrderInfo.ToList().Where(_ => _.OrderID == row.OrderID).ToList();
            var pdfchildRows = new List<PdfDetailTemplateRow>();
            var pdfRow = ProcessPdfRow(new List<string>() { row.OrderID.ToString(), row.CustomerID.ToString(), row.Freight.ToString(), row.ShipCity });
            for (var j = 0; j < childData.Count; j++)
            {
                var childRow = childData[j];
                pdfchildRows.Add(ProcessPdfRow(new List<string>() { childRow.CustomerID.ToString(), childRow.Title.ToString(), childRow.Address.ToString(), childRow.Country }));
            }
            pdfRow.ChildRowInfo = new PdfDetailTemplateRowSettings() { Headers = new List<PdfDetailTemplateRow>() { ProcessPdfRow(new List<string>() { "Customer Name", "Title", "Address", "Country" }) }, Rows = pdfchildRows };
            pdfRows.Add(pdfRow);
        }
        args.RowInfo.Headers = new List<PdfDetailTemplateRow>() { ProcessPdfRow(new List<string>() { "Order ID", "Customer ID", "Freight", "Ship City" }) };
        args.RowInfo.Rows = pdfRows;
    }

    PdfDetailTemplateRow ProcessPdfRow(List<string> value)
    {
        var cells = new List<PdfDetailTemplateCell>();
        for (var j = 0; j < value.Count(); j++)
        {
            cells.Add(new PdfDetailTemplateCell { CellValue = $"{value[j]}", Index = j });
        }
        return new PdfDetailTemplateRow { Cells = cells };
    }

    public class EmployeeData
    {
        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
    public class Order
    {
        public int OrderID { get; set; }
        public int? EmployeeID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
        public string ShipCity { get; set; }
    }

    public class OrderDetails
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
    }
}
```
