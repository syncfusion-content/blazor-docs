---
layout: post
title: Excel Exporting with Templates in Blazor Grid Component | Syncfusion
description: Checkout and learn here all about Template Excel Export in Syncfusion Blazor DataGrid component and much more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Exporting grid with templates in Syncfusion Blazor DataGrid

The Syncfusion Blazor DataGrid offers the option to export the column, detail, and caption templates to an Excel document. The template contains images, hyperlinks, and customized text.

## Exporting with column template

The Excel export functionality allows you to export Grid columns that include images, hyperlinks, and custom text to an Excel document. The Excel export provides an option to export template columns of the DataGrid by defining the [IncludeTemplateColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_IncludeTemplateColumn) of [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) as **true**.

In the following sample, the **CustomerID** column is a template column. The template values cannot be directly exported into the cells. To customize the values of the template columns in Excel file, you must use [ExcelQueryCellInfoEvent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ExcelQueryCellInfoEvent).

> Excel Export supports base64 string to export the images.


{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "ExcelExport" })" AllowExcelExport="true" AllowPaging="true">
    <GridEvents ExcelQueryCellInfoEvent="ExcelQueryCellInfoHandler" OnToolbarClick="ToolbarClickHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150">
            <Template>
                @{
                    var con = (context as OrderData);
                }
                <span>Mr.@con.CustomerID</span>
            </Template>
        </GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    private SfGrid<OrderData> DefaultGrid;
    public List<OrderData> Orders { get; set; }
    public bool OrderDateVisible { get; set; } = false;
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_excelexport")  // Id is the combination of Grid's ID and item name.
        {
            ExcelExportProperties ExportProperties = new ExcelExportProperties();
            ExportProperties.IncludeTemplateColumn = true;
            await this.DefaultGrid.ExportToExcelAsync(ExportProperties);
        }
    }

    public void ExcelQueryCellInfoHandler(ExcelQueryCellInfoEventArgs<OrderData> args)
    {
        if (args.Column.Field == "CustomerID")
        {
            args.Cell.Value = "Mr." + args.Data.CustomerID;
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData(int orderID, string customerID, DateTime orderDate, double freight)
    {
        OrderID = orderID;
        CustomerID = customerID;
        OrderDate = orderDate;
        Freight = freight;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", new DateTime(2023, 1, 15), 32.38));
            Orders.Add(new OrderData(10249, "TOMSP", new DateTime(2023, 2, 10), 11.61));
            Orders.Add(new OrderData(10250, "HANAR", new DateTime(2023, 3, 5), 65.83));
            Orders.Add(new OrderData(10251, "VICTE", new DateTime(2023, 4, 20), 41.34));
            Orders.Add(new OrderData(10252, "SUPRD", new DateTime(2023, 5, 25), 51.30));
            Orders.Add(new OrderData(10253, "HANAR", new DateTime(2023, 6, 15), 58.17));
            Orders.Add(new OrderData(10254, "CHOPS", new DateTime(2023, 7, 10), 22.98));
            Orders.Add(new OrderData(10255, "RICSU", new DateTime(2023, 8, 18), 148.33));
            Orders.Add(new OrderData(10256, "WELLI", new DateTime(2023, 9, 7), 13.97));
            Orders.Add(new OrderData(10257, "HILAA", new DateTime(2023, 10, 3), 81.91));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime OrderDate { get; set; }
    public double Freight { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDrStTCAyrjIiJqY?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


## Exporting with group caption template

The Syncfusion Blazor Grid allows you to export the Grid data along with a custom caption template into an Excel document. This feature can be useful when you want to provide meaningful group captions (e.g., count of records) in the exported Excel file.

To customize the caption text in the exported Excel file, you can handle the [ExcelGroupCaptionTemplateInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ExcelGroupCaptionTemplateInfo) event. This event provides you with the necessary information to set the group caption in the exported Excel file, such as the group key, record count, and header text. Within the event, you can set a customized group caption using `args.Cell.Value` property.

The following example demonstrates how the Grid is grouped by the **CustomerID** field and exports the grid data to Excel with a custom group caption template, utilizing the `OnToolbarClick` event and the `ExportToExcelAsync` method.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="Grid" DataSource="@GridData" AllowGrouping="true" Height="315px" Toolbar="@(new List<string>() { "ExcelExport" })" AllowExcelExport="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" ExcelGroupCaptionTemplateInfo="ExcelGroupCaptionInfoHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Width="80"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
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
    private SfGrid<OrderData> Grid;
    public List<OrderData> GridData { get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords(); // Replace with your actual data logic.
    }


    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_excelexport")  // Id is the combination of Grid's ID and item name.
        {
            if (args.Item.Id == "Grid_excelexport")
            {
                await Grid.ExportToExcelAsync();
            }
        }
    }

    public void ExcelGroupCaptionInfoHandler(ExcelCaptionTemplateArgs args)
    {
        args.Cell.Value = args.Key + "-" + args.Count + " Records: " + args.HeaderText; 
    } 
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public OrderData(int orderID, string customerID, double freight, string shipCity)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.Freight = freight;
        this.ShipCity = shipCity;
    }

    public static List<OrderData> GetAllRecords()
    {
        return new List<OrderData>
        {
            new OrderData(10248, "VINET", 32.38, "Reims"),
            new OrderData(10249, "TOMSP", 11.61, "Münster"),
            new OrderData(10250, "HANAR", 65.83, "Rio de Janeiro"),
            new OrderData(10251, "VICTE", 41.34, "Lyon"),
            new OrderData(10252, "SUPRD", 51.30, "Charleroi"),
            new OrderData(10253, "HANAR", 58.17, "Rio de Janeiro"),
            new OrderData(10254, "CHOPS", 22.98, "Bern"),
            new OrderData(10255, "RICSU", 148.33, "Genève"),
            new OrderData(10256, "WELLI", 13.97, "Resende"),
            new OrderData(10257, "HILAA", 81.91, "San Cristóbal"),
            new OrderData(10258, "ERNSH", 140.51, "Graz"),
            new OrderData(10259, "CENTC", 3.25, "México D.F."),
            new OrderData(10260, "OTTIK", 55.09, "Köln"),
            new OrderData(10261, "QUEDE", 3.05, "Rio de Janeiro"),
            new OrderData(10262, "RATTC", 48.29, "Albuquerque"),
            new OrderData(10263, "ERNSH", 76.56, "Graz"),
            new OrderData(10264, "FOLKO", 67.10, "Bräcke"),
            new OrderData(10265, "BLONP", 36.65, "Strasbourg"),
            new OrderData(10266, "WARTH", 27.19, "Stavanger"),
            new OrderData(10267, "FRANK", 65.83, "München")
        };
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/rDhSjfifINuSYyye" %}

## Exporting with detail template

By default, the Grid exports the parent Grid along with expanded detail rows only. To modify the exporting behavior, utilize the [ExcelExportProperties.ExcelDetailRowMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelDetailRowMode.html) property. The available options include:

| Mode | Behavior |
|-------|----------|
| Expand | Exports the parent Grid with expanded detail rows.
| Collapse | Exports the parent Grid with collapsed detail rows.
| None | Exports the parent Grid alone.

You can customize and format the detail rows in the exported Excel document using the [ExcelDetailTemplateExporting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ExcelDetailTemplateExporting) event. In this event, the detail rows of the Excel document are formatted in accordance with their parent row details.

In the provided example, detail row content is formatted by specifying the [Headers](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelDetailTemplateRowSettings.html#Syncfusion_Blazor_Grids_ExcelDetailTemplateRowSettings_Headers), [Rows](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelDetailTemplateRowSettings.html#Syncfusion_Blazor_Grids_ExcelDetailTemplateRowSettings_Rows) using parent row details, facilitating the creation of detail rows within the Excel. Additionally, custom styles can be applied to specific cells using the [Style](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelDetailTemplateCell.html#Syncfusion_Blazor_Grids_ExcelDetailTemplateCell_Style) property.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" ID="Grid" DataSource="@Employees" Toolbar="@(new List<string>() { "ExcelExport" })" AllowExcelExport="true" Height="450px">
    <GridTemplates>
        <DetailTemplate>
            @{
                var employee = (context as ProductData);
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
                                <span class="@((employee.Status == "Available") ? "available" : "unavailable")" style="font-weight: 500;"> @employee.Status</span>
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
    <GridEvents ExcelDetailTemplateExporting="ExcelDetailTemplateHandler" OnToolbarClick="ToolbarClickHandler" TValue="ProductData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(ProductData.Category) HeaderText="Category" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(ProductData.ProductID) HeaderText="Product ID" Width="160"> </GridColumn>
        <GridColumn Field=@nameof(ProductData.Status) HeaderText="Status" Width="180"></GridColumn>
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

    .unavailable {
        color: #FF0000;
    }

    .available {
        color: #00FF00;
    }
</style>



@code {
    private SfGrid<ProductData> Grid;
    public List<ProductData> Employees { get; set; }

    protected override void OnInitialized()
    {
        Employees = ProductData.GetAllRecords();
    }


    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_excelexport")  // Id is the combination of Grid's ID and item name.
        {
            ExcelExportProperties ExportProperties = new ExcelExportProperties();
            ExportProperties.ExcelDetailRowMode = ExcelDetailRowMode.Expand;
            await Grid.ExportToExcelAsync(ExportProperties);
        }
    }

    public void ExcelDetailTemplateHandler(ExcelDetailTemplateEventArgs<ProductData> args)
    {
        var excelRows = new List<ExcelDetailTemplateRow>();
        var data = args.ParentRow.Data;
        args.RowInfo.Headers = new List<ExcelDetailTemplateRow>() { 
            new ExcelDetailTemplateRow() { 
                Cells = new List<ExcelDetailTemplateCell>() { 
                    new ExcelDetailTemplateCell() { 
                        Index = 0, 
                        CellValue = "Product Details", 
                        ColumnSpan = 2,
                        Style = new ExcelStyle() { 
                        Bold = true, BackColor = "#ADD8E6" 
                        } 
                    } 
                } 
            } 
        };
        excelRows.Add(new ExcelDetailTemplateRow()
        {
            Cells = new List<ExcelDetailTemplateCell>()
            {
                new ExcelDetailTemplateCell()
                {
                    CellValue = data.ProductDesc, Index = 0
                },
                new ExcelDetailTemplateCell()
                {
                    Index = 1, Hyperlink = new Hyperlink() { DisplayText = data.Contact, Target = data.Contact }
                }
            }
        });
        excelRows.Add( new ExcelDetailTemplateRow()
        {
            Cells = new List<ExcelDetailTemplateCell>()
            {
                new ExcelDetailTemplateCell()
                {
                    CellValue = data.Cost, Index = 0
                },
                new ExcelDetailTemplateCell()
                {
                    Index = 1, CellValue = "Available :" + data.Available 
                }
            }
        });
        excelRows.Add(new ExcelDetailTemplateRow()
        {
            Cells = new List<ExcelDetailTemplateCell>()
            {
                new ExcelDetailTemplateCell()
                {
                    CellValue = data.Status, Index = 0,
                    Style = new ExcelStyle()
                    {
                        FontColor = data.Status == "Available" ? "#00FF00" : "#FF0000"
                    }
                },
                new ExcelDetailTemplateCell()
                {
                    Index = 1, CellValue = data.ReturnPolicy 
                }
            }
        });
        excelRows.Add(new ExcelDetailTemplateRow()
        {
            Cells = new List<ExcelDetailTemplateCell>()
            {
                new ExcelDetailTemplateCell()
                {
                    CellValue = "Offers :" + data.Offers, Index = 0, Style = new ExcelStyle()
                    {
                        FontColor = "#0A76FF", FontSize = 12
                    }
                },
                new ExcelDetailTemplateCell()
                {
                    Index = 1, CellValue = data.Cancellation
                }
            }
        });
        excelRows.Add(new ExcelDetailTemplateRow()
        {
            Cells = new List<ExcelDetailTemplateCell>()
            {
                new ExcelDetailTemplateCell()
                {
                    CellValue = "Ratings: " + data.Ratings, Index = 0, Style = new ExcelStyle()
                    {
                      FontColor = "#0A76FF", FontSize = 12
                    }
                },
                new ExcelDetailTemplateCell()
                {
                    Index = 1, CellValue = data.Delivery, Style = new ExcelStyle()
                    {
                      FontColor = "#0A76FF", FontSize = 12
                    }
                }
            }
        });
        args.RowInfo.Rows = excelRows;
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class ProductData
{
    public static List<ProductData> Products = new List<ProductData>();

    public ProductData(string category, string offers, string cost, string available, string itemID, string productID,
                       string contact, string status, string productDesc, string returnPolicy,
                       string delivery, string cancellation, string ratings)
    {
        Category = category;
        Offers = offers;
        Cost = cost;
        Available = available;
        ItemID = itemID;
        ProductID = productID;
        Contact = contact;
        Status = status;
        ProductDesc = productDesc;
        ReturnPolicy = returnPolicy;
        Delivery = delivery;
        Cancellation = cancellation;
        Ratings = ratings;
    }

    public string Category { get; set; }
    public string Offers { get; set; }
    public string Cost { get; set; }
    public string Available { get; set; }
    public string ItemID { get; set; }
    public string ProductID { get; set; }
    public string Contact { get; set; }
    public string Status { get; set; }
    public string ProductDesc { get; set; }
    public string ReturnPolicy { get; set; }
    public string Delivery { get; set; }
    public string Cancellation { get; set; }
    public string Ratings { get; set; }

    public static List<ProductData> GetAllRecords()
    {
        if (Products.Count == 0)
        {
            Products.Add(new ProductData("Suits/Slim", "5%", "199.99$", "10", "Suit-001", "EJ-SU-01", "nancy@domain.com", "Available", "Slim Fit Suit", "No Returns Applicable", "** FREE Delivery **", "Cancellation upto 12 hrs", "4.5"));
            Products.Add(new ProductData("Suits/Classic", "12%", "249.99$", "8", "Suit-002", "EJ-SU-02", "andrew@domain.com", "Available", "Classic Fit Suit", "No Returns Applicable", "** FREE Delivery **", "Cancellation upto 24 hrs", "4.8"));
            Products.Add(new ProductData("Suits/Formal", "5%", "149.99$", "15", "Suit-003", "EJ-SU-03", "janet@domain.com", "Available", "Formal Fit Suit", "No Returns Applicable", "** FREE Delivery **", "Cancellation upto 12 hrs", "4.7"));
            Products.Add(new ProductData("Pants/Slim", "10%", "19.99$", "50", "Pant-001", "EJ-PA-01", "margaret@domain.com", "Available", "Slim Fit Pants", "No Returns Applicable", "** FREE Delivery **", "Cancellation upto 12 hrs", "4.2"));
            Products.Add(new ProductData("Pants/Casual", "15%", "25.99$", "35", "Pant-002", "EJ-PA-02", "steven@domain.com", "Available", "Casual Cotton Pants", "Return within 7 days", "** FREE Delivery **", "Cancellation upto 24 hrs", "4.4"));
            Products.Add(new ProductData("Shirts/Formal", "8%", "39.99$", "20", "Shirt-001", "EJ-SH-01", "michael@domain.com", "Available", "Formal Cotton Shirt", "No Returns Applicable", "** FREE Delivery **", "Cancellation upto 24 hrs", "4.6"));
            Products.Add(new ProductData("Shirts/Casual", "10%", "29.99$", "60", "Shirt-002", "EJ-SH-02", "robert@domain.com", "Available", "Casual Check Shirt", "Return within 15 days", "** FREE Delivery **", "Cancellation upto 48 hrs", "4.3"));
            Products.Add(new ProductData("Shirts/Denim", "6%", "49.99$", "25", "Shirt-003", "EJ-SH-03", "laura@domain.com", "Available", "Denim Shirt", "Return within 10 days", "** FREE Delivery **", "Cancellation upto 24 hrs", "4.1"));
            Products.Add(new ProductData("Jackets/Leather", "18%", "199.99$", "5", "Jacket-001", "EJ-JA-01", "anne@domain.com", "Available", "Leather Jacket", "No Returns Applicable", "** FREE Delivery **", "Cancellation upto 6 hrs", "4.9"));
            Products.Add(new ProductData("Jackets/Bomber", "20%", "129.99$", "12", "Jacket-002", "EJ-JA-02", "paul@domain.com", "Available", "Bomber Jacket", "Return within 7 days", "** FREE Delivery **", "Cancellation upto 12 hrs", "4.6"));

            Products.Add(new ProductData("T-Shirts/Graphic", "10%", "19.99$", "80", "TShirt-001", "EJ-TS-01", "nancy@domain.com", "Available", "Graphic Tee", "Return within 15 days", "** FREE Delivery **", "Cancellation upto 24 hrs", "4.5"));
            Products.Add(new ProductData("T-Shirts/Plain", "5%", "14.99$", "90", "TShirt-002", "EJ-TS-02", "andrew@domain.com", "Available", "Plain T-Shirt", "Return within 10 days", "** FREE Delivery **", "Cancellation upto 24 hrs", "4.2"));
            Products.Add(new ProductData("T-Shirts/Sports", "12%", "24.99$", "70", "TShirt-003", "EJ-TS-03", "janet@domain.com", "Available", "Sports Tee", "Return within 7 days", "** FREE Delivery **", "Cancellation upto 12 hrs", "4.7"));
            Products.Add(new ProductData("Jeans/Skinny", "15%", "59.99$", "30", "Jeans-001", "EJ-JE-01", "margaret@domain.com", "Available", "Skinny Fit Jeans", "Return within 15 days", "** FREE Delivery **", "Cancellation upto 24 hrs", "4.6"));
            Products.Add(new ProductData("Jeans/Straight", "8%", "54.99$", "40", "Jeans-002", "EJ-JE-02", "steven@domain.com", "Available", "Straight Cut Jeans", "Return within 10 days", "** FREE Delivery **", "Cancellation upto 24 hrs", "4.4"));
            Products.Add(new ProductData("Sweaters/Wool", "10%", "34.99$", "18", "Sweater-001", "EJ-SW-01", "michael@domain.com", "Available", "Woolen Sweater", "No Returns Applicable", "** FREE Delivery **", "Cancellation upto 6 hrs", "4.3"));
            Products.Add(new ProductData("Sweaters/Cotton", "7%", "29.99$", "22", "Sweater-002", "EJ-SW-02", "robert@domain.com", "Available", "Cotton Sweater", "Return within 10 days", "** FREE Delivery **", "Cancellation upto 12 hrs", "4.2"));
            Products.Add(new ProductData("Blazers/Formal", "14%", "89.99$", "10", "Blazer-001", "EJ-BL-01", "laura@domain.com", "Available", "Formal Blazer", "Return within 5 days", "** FREE Delivery **", "Cancellation upto 6 hrs", "4.7"));
            Products.Add(new ProductData("Blazers/Casual", "10%", "79.99$", "14", "Blazer-002", "EJ-BL-02", "anne@domain.com", "Available", "Casual Blazer", "No Returns Applicable", "** FREE Delivery **", "Cancellation upto 12 hrs", "4.5"));
            Products.Add(new ProductData("Hoodies/Zip", "0%", "39.99$", "0", "Hoodie-001", "EJ-HO-01", "paul@domain.com", "Unavailable", "Zip-up Hoodie", "Return within 10 days", "** FREE Delivery **", "Cancellation upto 24 hrs", "4.6"));
        }

        return Products;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/hDVoZTCpzaSIZraq" %}

## Exporting hierarchical grid using detail template

The Syncfusion Blazor DataGrid allows you to export hierarchical Grid data to Excel using the detail template feature. This is particularly useful for scenarios where data is nested within parent rows (such as employee details and their related orders), and you need to export both the parent and child records to a single Excel document.

You can customize and format the detail rows in the exported Excel document using the [ExcelDetailTemplateExporting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ExcelDetailTemplateExporting) event. In this event, the detail rows of the Excel document are formatted in accordance with their parent row details.

In the provided example, detail row content is formatted by specifying the [Headers](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelDetailTemplateRowSettings.html#Syncfusion_Blazor_Grids_ExcelDetailTemplateRowSettings_Headers), [Rows](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelDetailTemplateRowSettings.html#Syncfusion_Blazor_Grids_ExcelDetailTemplateRowSettings_Rows) using parent row details. Additionaly, this achieves a nested level of children using the [ChildRowInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelDetailTemplateRow.html#Syncfusion_Blazor_Grids_ExcelDetailTemplateRow_ChildRowInfo) property.


{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data

<SfGrid @ref="Grid" ID="Grid" DataSource="@Employees" AllowExcelExport="true" Toolbar="@(new List<string>() { "ExcelExport"})">
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
    <GridEvents ExcelDetailTemplateExporting="ExcelDetailTemplateHandler" OnToolbarClick="ToolbarClickHandler" TValue="EmployeeData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.EmployeeID) HeaderText="EmployeeID" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(EmployeeData.FirstName) HeaderText="First Name" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Title) HeaderText="Title" Width="110"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Country) HeaderText="Country" Width="110"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<EmployeeData> Grid;
    public List<EmployeeData> Employees { get; set; }
    public List<OrderDetails> OrderInfo { get; set; }
    public static List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Employees = EmployeeData.GetAllRecords();
        Orders = Order.GetAllRecords();
        OrderInfo = OrderDetails.GetAllRecords();
    }


    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_excelexport")  // Id is the combination of Grid's ID and item name.
        {
            if (args.Item.Id == "Grid_excelexport")
            {
                ExcelExportProperties ExportProperties = new ExcelExportProperties();
                ExportProperties.ExcelDetailRowMode = ExcelDetailRowMode.Expand;
                await Grid.ExportToExcelAsync(ExportProperties);
            }
        }
    }

    public void ExcelDetailTemplateHandler(ExcelDetailTemplateEventArgs<EmployeeData> args)
    {
        var excelRows = new List<ExcelDetailTemplateRow>();
        var data = Orders.ToList().Where(_ => _.EmployeeID == args.ParentRow.Data.EmployeeID).ToList();
        for (var i = 0; i < data.Count(); i++)
        {
            var row = data[i];
            var childData = OrderInfo.ToList().Where(_ => _.OrderID == row.OrderID).ToList();
            var excelchildRows = new List<ExcelDetailTemplateRow>();
            var excelRow = ProcessExcelRow(new List<string>() { row.OrderID.ToString(), row.CustomerID.ToString(), row.Freight.ToString(), row.ShipCity });
            for (var j = 0; j < childData.Count; j++)
            {
                var childRow = childData[j];
                excelchildRows.Add(ProcessExcelRow(new List<string>() { childRow.CustomerID.ToString(), childRow.Title.ToString(), childRow.Address.ToString(), childRow.Country }));
            }
            excelRow.ChildRowInfo = new ExcelDetailTemplateRowSettings() { Headers = new List<ExcelDetailTemplateRow>() { ProcessExcelRow(new List<string>() { "Customer Name", "Title", "Address", "Country" }) }, Rows = excelchildRows };
            excelRows.Add(excelRow);
        }
        args.RowInfo.Headers = new List<ExcelDetailTemplateRow>() { ProcessExcelRow(new List<string>() { "Order ID", "Customer ID", "Freight", "Ship City" }) };
        args.RowInfo.Rows = excelRows;
    }

    ExcelDetailTemplateRow ProcessExcelRow(List<string> value)
    {
        var cells = new List<ExcelDetailTemplateCell>();
        for (var j = 0; j < value.Count(); j++)
        {
            cells.Add(new ExcelDetailTemplateCell { CellValue = $"{value[j]}", Index = j });
        }
        return new ExcelDetailTemplateRow { Cells = cells };
    }
}

{% endhighlight %}

{% highlight c# tabtitle="EmployeeData.cs" %}

public class EmployeeData
{
    public EmployeeData(int employeeID, string firstName, string title, string city, string country)
    {
        this.EmployeeID = employeeID;
        this.FirstName = firstName;
        this.Title = title;
        this.City = city;
        this.Country = country;
    }

    public static List<EmployeeData> GetAllRecords()
    {
        return new List<EmployeeData>
        {
            new EmployeeData(1, "Nancy", "Sales Representative", "Texas", "USA"),
            new EmployeeData(2, "Andrew", "Vice President", "London", "UK"),
            new EmployeeData(3, "Janet", "Sales", "London", "UK"),
            new EmployeeData(4, "Margaret", "Sales Manager", "London", "UK"),
            new EmployeeData(5, "Steven", "Inside Sales Coordinator", "Vegas", "USA"),
            new EmployeeData(6, "Smith", "HR Manager", "Dubai", "UAE"),
            new EmployeeData(7, "Steven", "Inside Sales Coordinator", "Paris", "France"),
            new EmployeeData(8, "Smith", "HR Manager", "Mumbai", "India"),
            new EmployeeData(9, "Smith", "HR Manager", "Chennai", "India")
        };
    }

    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string Title { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}

{% endhighlight %}

{% highlight c# tabtitle="Order.cs" %}

public class Order
{
    public Order(int employeeID, int orderID, string customerID, string shipCity, double freight)
    {
        this.EmployeeID = employeeID;
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.ShipCity = shipCity;
        this.Freight = freight;
    }

    public static List<Order> GetAllRecords()
    {
        return new List<Order>
    {
        new Order(1, 1001, "Nancy", "Texas", 2.1 * 1),
        new Order(2, 1002, "Andrew", "London", 2.1 * 2),
        new Order(3, 1003, "Janet", "London", 2.1 * 3),
        new Order(4, 1004, "Margaret", "London", 2.1 * 4),
        new Order(5, 1005, "Steven", "Vegas", 2.1 * 5),
        new Order(6, 1006, "Smith", "Dubai", 2.1 * 6),
        new Order(7, 1007, "Steven", "Paris", 2.1 * 7),
        new Order(8, 1008, "Smith", "Mumbai", 2.1 * 8),
        new Order(9, 1009, "Smith", "Chennai", 2.1 * 9),
        new Order(2, 1010, "Smith", "Chennai", 2.1 * 9),
        new Order(3, 1011, "Smith", "Chennai", 2.1 * 9),
        new Order(3, 1012, "Smith", "Chennai", 2.1 * 9)
    };
    }

    public int EmployeeID { get; set; }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public double Freight { get; set; }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderDetails.cs" %}


public class OrderDetails
{
    public OrderDetails(int orderID, string title, string customerID, string country, string address)
    {
        this.OrderID = orderID;
        this.Title = title;
        this.CustomerID = customerID;
        this.Country = country;
        this.Address = address;
    }

    public static List<OrderDetails> GetAllRecords()
    {
        return new List<OrderDetails>
        {
            new OrderDetails(1001, "Sales Representative", "Nancy", "Germany", "Obere Str. 57"),
            new OrderDetails(1002, "HR Manager", "Andrew", "Mexico", "Avda. de la Constitución 2222"),
            new OrderDetails(1003, "Vice President", "Janet", "Mexico", "Mataderos 2312"),
            new OrderDetails(1004, "Inside Sales Coordinator", "Margaret", "Mexico", "Mataderos 2312"),
            new OrderDetails(1005, "HR Manager", "Steven", "Spain", "C/ Araquil, 67"),
            new OrderDetails(1006, "Vice President", "Smith", "Mexico", "Avda. de la Constitución 2222"),
            new OrderDetails(1007, "Sales", "Steven", "France", "24, place Kléber"),
            new OrderDetails(1008, "HR Manager", "Smith", "Spain", "C/ Araquil, 67"),
            new OrderDetails(1009, "Sales", "Smith", "Mexico", "Mataderos 2312"),
            new OrderDetails(1010, "Vice President", "Smith", "Spain", "C/ Araquil, 67"),
            new OrderDetails(1011, "Inside Sales Coordinator", "Smith", "Mexico", "Mataderos 2312"),
            new OrderDetails(1012, "HR Manager", "Smith", "India", "45A")
        };
    }

    public int OrderID { get; set; }
    public string Title { get; set; }
    public string CustomerID { get; set; }
    public string Country { get; set; }
    public string Address { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/VNLINpCfyLFRJyFJ" %}