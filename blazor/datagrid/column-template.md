---
layout: post
title: Column Template in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about column template in the Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Column Template in Blazor DataGrid

DataGrid component provides a [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) option that allows you to display custom elements in a column instead of the field value. This can be useful when you need to display images, buttons, or other custom content within a column.

> Before adding column template to the DataGrid, it is recommended to go through the [template](./templates/#templates) section topic to configure the template.

To know about **Column Template** in Blazor DataGrid Component, you can check this video.

{% youtube
"youtube:https://www.youtube.com/watch?v=9YF9HnFY5Ew"%}

> When using template columns, they are primarily meant for rendering custom content and may not provide built-in support for datagrid actions like sorting, filtering, editing. It is must to define the `Field` property of the column to perform any datagrid actions.

## Render image in a column

To render an image in a grid column, you need to define a [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) for the column using the template property.The `Template` property expects an HTML string or a function that returns an HTML string.

The following example demonstrates how to define a `Template` for the **Employee Image** field that displays an image element.The `Template` property is set to an HTML string that contains an image tag. You have utilized the `src` and `alt` attributes to the image tag.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Employees">
    <GridColumns>
        <GridColumn HeaderText="Employee Image" TextAlign="TextAlign.Center" Width="120">
            <Template>
                @{
                    var employee = (context as EmployeeData);
                    <div class="image">
                        <img src="@($"scripts/Images/Employees/{employee.EmployeeID}.png")" alt="@employee.EmployeeID" />
                    </div>
                }
            </Template>
        </GridColumn>
        <GridColumn Field=@nameof(EmployeeData.FirstName) HeaderText="First Name" Width="130"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.LastName) HeaderText="Last Name" Width="130"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.City) HeaderText="City" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .image img {
        height: 55px;
        width: 55px;
        border-radius: 50px;
        box-shadow: inset 0 0 1px #e0e0e0, inset 0 0 14px rgba(0, 0, 0, 0.2);
    }
</style>

@code {
    public List<EmployeeData> Employees { get; set; }

    protected override void OnInitialized()
    {
        Employees = Enumerable.Range(1, 9).Select(x => new EmployeeData()
            {
                EmployeeID = x,
                FirstName = (new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Laura" })[new Random().Next(5)],
                LastName = (new string[] { "Davolio", "Fuller", "Leverling", "Peacock", "Buchanan" })[new Random().Next(5)],
                City = (new string[] { "Seattle", "Tacoma", "Kirkland",
                                    "Redmond" })[new Random().Next(4)],
                HireDate = DateTime.Now.AddDays(-x),
            }).ToList();
    }

    public class EmployeeData
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjVANuBbsFDShTfP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> The [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) option allows to define any HTML content within a column.


## Render other components in a column

The column template has options to render a custom component in a DataGrid column instead of a field value.

### Render DropDownList component in a column

To render a custom component in a grid column, you need to define a [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) for the column using the column `Template` property. In the following code, we rendered the [DropDownList](https://ej2.syncfusion.com/angular/documentation/drop-down-list/getting-started) component in the **Order Status** column by defining the `Template` property.

```csharp
 <SfDropDownList TValue="string" Placeholder="Order Placed" PopupWidth="150" PopupHeight="150" TItem="EmployeeNames" DataSource="@EmployeeDetails">
                    <DropDownListFieldSettings Value="Status"></DropDownListFieldSettings>
 </SfDropDownList>
```

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<SfGrid DataSource="@Orders">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) TextAlign="TextAlign.Right" HeaderText="Employee ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderStatus) HeaderText="Order Status" TextAlign="TextAlign.Right" Width="150">
            <Template>
                <SfDropDownList TValue="string" Placeholder="Order Placed" PopupWidth="150" PopupHeight="150" TItem="EmployeeNames" DataSource="@EmployeeDetails">
                    <DropDownListFieldSettings Value="Status"></DropDownListFieldSettings>
                </SfDropDownList>
            </Template>
        </GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }
    public List<EmployeeNames> EmployeeDetails { get; set; }


    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 5).Select(x => new Order()
            {
                OrderID = x,
                CustomerID = (new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven" })[new Random().Next(5)],
                Freight=2.1*x,
                Title = (new string[] { "Sales Representative", "Vice President, Sales", "Sales Manager",
                                    "Inside Sales Coordinator" })[new Random().Next(4)],
                OrderStatus = (new string[]{"Order Placed","Processing","Delivered"})[new Random().Next(3)]
            }).ToList();

        EmployeeDetails = Enumerable.Range(1, 3).Select(x => new EmployeeNames()
            {
                Id = x,
                Status = (new string[] { "Order Placed", "Processing", "Delivered" })[new Random().Next(3)]
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
        public string Title { get; set; }
        public string OrderStatus { get; set; }
    }

    public class EmployeeNames
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjhKNOVlVUAsxFps?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Using condition template

The conditional column [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) allows you to display template elements based on specific conditions.


In the following code, checkbox is rendered based on **Discontinued** field value in the datasource. This data can be accessed inside the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) using the implicit named parameter **context**.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Employees">
    <GridColumns>
        <GridColumn HeaderText="Discontinued" TextAlign="TextAlign.Center" Width="120">
            <Template>
                @{
                    var employee = (context as EmployeeData);
                    <div class="template_checkbox">
                        @if (employee.Discontinued)
                        {
                            <input type="checkbox" checked>
                        }
                        else
                        {
                            <input type="checkbox">
                        }
                    </div>
                }
            </Template>
        </GridColumn>
        <GridColumn Field=@nameof(EmployeeData.ProductID) TextAlign="TextAlign.Center" HeaderText="Employee ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.CategoryName) HeaderText="Category Name" Width="130"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.ProductName) HeaderText="Product Name" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<EmployeeData> Employees { get; set; }

    protected override void OnInitialized()
    {
        Employees = Enumerable.Range(1, 9).Select(x => new EmployeeData()
            {
                ProductID = x,
                CategoryName = "Beverages",
                ProductName = (new string[] { "Chai", "Chang", "Aniseed Syrup",
                                    "Mishi Kobe Niku" })[new Random().Next(4)],
                Discontinued = (new Boolean[] { true, false })[new Random().Next(2)]
            }).ToList();
    }

    public class EmployeeData
    {
        public int? ProductID { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
       public Boolean Discontinued { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDrgjErPUrDqccPz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Using hyperlink column and performing routing on click

The Column template property can be used to provide routing links inside the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) property of the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html). For routing, [UriHelper](https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/routing?view=aspnetcore-7.0&viewFallbackFrom=aspnetcore-3.0#uri-and-navigation-state-helpers) can be utilized.

This can be achieved by initially defining an anchor tag inside the column template and binding click event to it. In this event, the DataGrid data **context** is passed on to its function.

```cshtml
@inject NavigationManager UriHelper
@using Syncfusion.Blazor.Grids

<SfGrid  DataSource="@Employees">
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.EmployeeID) TextAlign="TextAlign.Center" HeaderText="Employee ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Name) HeaderText="First Name" Width="130"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Title) HeaderText="Title" Width="120"></GridColumn>
        <GridColumn HeaderText="User profile" TextAlign="TextAlign.Center" Width="120">
            <Template>
                @{
                    var Employee = (context as EmployeeData);
                    <div><a href="#" @onclick="@(() => Navigate(Employee))">View</a></div>
                }
            </Template>
        </GridColumn>
    </GridColumns>
</SfGrid>

@code{

    List<EmployeeData> Employees = new List<EmployeeData>
    {
        new EmployeeData() { EmployeeID = 1, Name = "Nancy Fuller", Link = "nancy_fuller", Title = "Vice President" },
        new EmployeeData() { EmployeeID = 2, Name = "Steven Buchanan", Link = "steven_buchanan", Title = "Sales Manager" },
        new EmployeeData() { EmployeeID = 3, Name = "Janet Leverling", Link = "janet_leverling", Title = "Sales Representative" },
        new EmployeeData() { EmployeeID = 4, Name = "Andrew Davolio", Link = "andrew_davolio", Title = "Inside Sales Coordinator" }
    };

    public class EmployeeData
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
    }
    private void Navigate(EmployeeData Employee)
    {
        UriHelper.NavigateTo($"{ Employee.Link}/{Employee.EmployeeID.ToString()}/{Employee.Name}/{ Employee.Title}");
    }
}
```

In the above code, the url to be navigated is specified in the Link variable of the DataGrid data. Based on this, the page is routed to the corresponding url.

After that, add new razor page for routing with routing url along with the parameters to be received, and initialize it with the required details.

```cshtml
@page "/nancy_fuller/{EmpID}/{Name}/{Title}"

<h2>Hello @Name!</h2>
<br>
<h4><u>Employee Details</u></h4>
<br>
<div><b>Employee ID:</b><div class="details">@EmpID</div></div>
<div><b>Position:</b><div class="details">@Title</div></div>

@code {
    [Parameter]
    public string EmpID { get; set; }
    [Parameter]
    public string Name { get; set; }
    [Parameter]
    public string Title { get; set; }
}
```

The following GIF represents template routing in DataGrid
![Blazor DataGrid with Routing Template](./images/blazor-datagrid-template-routing.gif)

## See also

* [FileUpload in Grid Column Template](https://www.syncfusion.com/forums/151021/fileupload-in-grid-column-template)