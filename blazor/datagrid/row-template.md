---
layout: post
title: Row Template in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Row Template in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Row Template in Blazor DataGrid Component

The row template feature in Grid allows you to customize the appearance and layout of rows in the grid. This feature is useful when you want to display custom content, such as images, buttons, or other controls, within the rows.

To enable the row template feature, you need to set the [RowTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridTemplates.html#Syncfusion_Blazor_Grids_GridTemplates_RowTemplate) property of the Grid component. This property accepts a custom HTML template that defines the layout for each row.

N> Before adding row template to the datagrid, it is recommended to go through the [template](./templates/#templates) section topic to configure the template.

To know about **Row Template** in Blazor DataGrid Component, you can check this video.

{% youtube
"youtube:https://www.youtube.com/watch?v=Dft0kerEGUQ"%}

The **RowTemplate** should be wrapped around a component named [GridTemplates](./templates/#gridtemplates-component) as follows. The **RowTemplate** content must be **TD** elements and the number of **TD** elements must match the number of datagrid columns.

In the following example, Employee Information with Employee Photo is presented in the first column and employee details like Name, Address, etc., are presented in the second column.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Employees" Height="335px">
    <GridTemplates>
        <RowTemplate Context="emp">
            @{
                var employee = (emp as EmployeeData);
                <td class="photo">
                    <img src="@($" scripts/Images/Employees/{employee.EmployeeID}.png")" alt="@employee.EmployeeID" />
                </td>
                <td class="details">
                    <table class="CardTable" cellpadding="3" cellspacing="2">
                        <colgroup>
                            <col width="50%">
                            <col width="50%">
                        </colgroup>
                        <tbody>
                            <tr>
                                <td class="CardHeader">First Name </td>
                                <td>@employee.FirstName </td>
                            </tr>
                            <tr>
                                <td class="CardHeader">Last Name</td>
                                <td>@employee.LastName </td>
                            </tr>
                            <tr>
                                <td class="CardHeader">
                                    Title
                                </td>
                                <td>
                                    @employee.Title
                                </td>
                            </tr>
                            <tr>
                                <td class="CardHeader">
                                    Country
                                </td>
                                <td>
                                    @employee.Country
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            }
        </RowTemplate>
    </GridTemplates>
    <GridColumns>
        <GridColumn HeaderText="Employee Image" Width="250" TextAlign="TextAlign.Center"> </GridColumn>
        <GridColumn HeaderText="Employee Details" Width="300" TextAlign="TextAlign.Left"></GridColumn>
    </GridColumns>
</SfGrid>

<style type="text/css" class="cssStyles">
    .photo img {
        width: 100px;
        height: 100px;
        border-radius: 50px;
        box-shadow: inset 0 0 1px #e0e0e0, inset 0 0 14px rgba(0, 0, 0, 0.2);
    }

    .photo,
    .details {
        border-color: #e0e0e0;
        border-style: solid;
    }

    .photo {
        border-width: 1px 0px 0px 0px;
        text-align: center;
    }

    .details {
        border-width: 1px 0px 0px 0px;
        padding-left: 18px;
    }

    .e-bigger .details {
        padding-left: 25px;
    }

    .e-device .details {
        padding-left: 8px;
    }

    .details > table {
        width: 100%;
    }

    .CardHeader {
        font-weight: 600;
    }

    td {
        padding: 2px 2px 3px 4px;
    }
</style>


@code {
    public List<EmployeeData> Employees { get; set; }

    protected override void OnInitialized()
    {
        Employees = Enumerable.Range(1, 9).Select(x => new EmployeeData()
        {
            EmployeeID = x,
            FirstName = (new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven" })[new Random().Next(5)],
            LastName = (new string[] { "Davolio", "Fuller", "Leverling", "Peacock", "Buchanan" })[new Random().Next(5)],
            Title = (new string[] { "Sales Representative", "Vice President, Sales", "Sales Manager",
                                    "Inside Sales Coordinator" })[new Random().Next(4)],
            Country = (new string[] { "USA", "UK", "UAE", "NED",
                                    "BER" })[new Random().Next(4)],
        }).ToList();
    }

    public class EmployeeData
    {
        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
    }
}

```


![Rows in Blazor DataGrid](./images/blazor-datagrid-rows.png)

## Row template with formatting

The row template feature in Syncfusion Grid allows you to customize the layout of rows in the grid. This is useful when you want to display images, buttons, or other custom content within the rows of a grid.

By default, Syncfusion Grid provides the  [Columns.Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnModel.html#Syncfusion_Blazor_Grids_ColumnModel_Format) property to format the values displayed in each column. However, when using the [RowTemplate](./templates/#gridtemplates-component), the `Columns.Format` property cannot be directly applied to format the values inside the template.

To format the values within the row template, you can define a global function that handles the formatting logic. This function can be invoked inside the template to format the corresponding values.

Here is an example of how to define a [Custom DateTime](https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings) formatting function for a date column and use it inside a RowTemplate:

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Employees" Height="335px">
    <GridTemplates>
        <RowTemplate>
            @{
                var employee = (context as EmployeeData);
                <td class="photo">
                    <img src="@($" scripts/Images/Employees/{employee.EmployeeID}.png")" alt="@employee.EmployeeID" />
                </td>
                <td class="details">
                    <table class="CardTable" cellpadding="3" cellspacing="2">
                        <colgroup>
                            <col width="50%">
                            <col width="50%">
                        </colgroup>
                        <tbody>
                            <tr>
                                <td class="CardHeader">First Name </td>
                                <td>@employee.FirstName </td>
                            </tr>
                            <tr>
                                <td class="CardHeader">Last Name</td>
                                <td>@employee.LastName </td>
                            </tr>
                            <tr>
                                <td class="CardHeader">
                                    Title
                                </td>
                                <td>
                                    @employee.Title
                                </td>
                            </tr>
                            <tr>
                                <td class="CardHeader">
                                    Birth Date
                                </td>
                                <td>
                                    @employee.HireDate.Value.ToString("MM/dd/yyyy")
                                </td>
                            </tr>
                            <tr>
                                <td class="CardHeader">
                                    Country
                                </td>
                                <td>
                                    @employee.Country
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            }
        </RowTemplate>
    </GridTemplates>
    <GridColumns>
        <GridColumn HeaderText="Employee Image" Width="250" TextAlign="TextAlign.Center"> </GridColumn>
        <GridColumn HeaderText="Employee Details" Width="300" TextAlign="TextAlign.Left"></GridColumn>
    </GridColumns>
</SfGrid>

<style type="text/css" class="cssStyles">
    .photo img {
        width: 100px;
        height: 100px;
        border-radius: 50px;
        box-shadow: inset 0 0 1px #e0e0e0, inset 0 0 14px rgba(0, 0, 0, 0.2);
    }

    .photo,
    .details {
        border-color: #e0e0e0;
        border-style: solid;
    }

    .photo {
        border-width: 1px 0px 0px 0px;
        text-align: center;
    }

    .details {
        border-width: 1px 0px 0px 0px;
        padding-left: 18px;
    }

    .e-bigger .details {
        padding-left: 25px;
    }

    .e-device .details {
        padding-left: 8px;
    }

    .details > table {
        width: 100%;
    }

    .CardHeader {
        font-weight: 600;
    }

    td {
        padding: 2px 2px 3px 4px;
    }
</style>


@code {
    public List<EmployeeData> Employees { get; set; }

    protected override void OnInitialized()
    {
        Employees = Enumerable.Range(1, 9).Select(x => new EmployeeData()
        {
            EmployeeID = x,
            FirstName = (new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven" })[new Random().Next(5)],
            LastName = (new string[] { "Davolio", "Fuller", "Leverling", "Peacock", "Buchanan" })[new Random().Next(5)],
            Title = (new string[] { "Sales Representative", "Vice President, Sales", "Sales Manager",
                                    "Inside Sales Coordinator" })[new Random().Next(4)],
            HireDate = DateTime.Now.AddDays(-x),
            Country = (new string[] { "USA", "UK", "USA", "UK", "USA" })[new Random().Next(5)],
        }).ToList();
    }

    public class EmployeeData
    {
        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime? HireDate { get; set; }
        public string Country { get; set; }
    }
}
```



![Row Formatting in Blazor DataGrid](./images/blazor-datagrid-row-format.png)

> When using the `RowTemplate` feature in Syncfusion Grid, keep in mind that any formatting applied to columns using the `Columns.Format` property will not work inside the template.

## Render syncfusion control in row template

The Grid allows you to render custom Syncfusion controls within the rows of the grid. This feature is helpful as it enables you to display interactive Syncfusion controls instead of field values in the grid.

To enable a Syncfusion control in a row template, you need to set the  [RowTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridTemplates.html#Syncfusion_Blazor_Grids_GridTemplates_RowTemplate) property of the Grid component. This property accepts a custom HTML template that defines the layout for each row.

Here is an example that demonstrates rendering Syncfusion controls within a row template :

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Calendars


<SfGrid @ref="Grid" DataSource="@Orders"  AllowPaging="true">
    <GridPageSettings PageSize="5"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.Quality) HeaderText="Quality" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipAddress) HeaderText="Ship Address" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.DateOnly" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderStatus) HeaderText="Order Status" Type="ColumnType.TimeOnly" TextAlign="TextAlign.Right" Width="130"></GridColumn>      
    </GridColumns>
    <GridTemplates>
        <RowTemplate Context="order">
            @{
                var value = (order as Order);
                <td>
                    <SfNumericTextBox Width="150" Value="value.OrderID"></SfNumericTextBox>
                </td>
                <td >
                <SfNumericTextBox Width="150" Value="value.Quality"></SfNumericTextBox>
                </td>
                <td>
                    <SfTextBox Width="150" Value="value.ShipAddress"></SfTextBox>
                </td>
                <td >
                <SfDatePicker Width="100" Value="value.OrderDate" ></SfDatePicker>
                </td>
                 <td >
                    <SfDropDownList  Value="value.OrderStatus" DataSource="@OrderDetails">
                   
                    </SfDropDownList>
                 </td>
            }
        </RowTemplate>
    </GridTemplates>
</SfGrid>

@code {
    private SfGrid<Order> Grid;
    public List<Order> Orders { get; set; }
    public List<string> OrderDetails = new List<string>() { "Order Placed", "Processing", "Delivered" };

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 10).Select(x => new Order()
            {
                OrderID = 1000 + x,
                ShipAddress = (new string[] { "US", "UK", "Australia", "London", "Mexico" })[new Random().Next(5)],
                Quality = 2 * x,
                OrderDate = new DateOnly(2023, 2, x),
                OrderStatus = (new string[] { "Order Placed", "Processing", "Delivered"})[new Random().Next(3)],
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string ShipAddress { get; set; }
        public DateOnly? OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public double? Quality { get; set; }
    }
  
}
```
## Limitations

Row template feature is not compatible with all the features which are available in the grid, and it has limited features support. The features that are incompatible with the row template feature are listed below.

* Filtering
* Paging
* Sorting
* Scrolling
* Searching
* Rtl
* Export
* Context Menu
* State Persistence