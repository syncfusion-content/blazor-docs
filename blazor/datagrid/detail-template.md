---
layout: post
title: Detail Template in Blazor DataGrid | Syncfusion
description: Checkout and learn here all about Detail Template in Syncfusion Blazor DataGrid and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Detail Template in Blazor DataGrid

The Detail Template feature in the Syncfusion Blazor DataGrid allows you to display expanded or collapsible sections for each row to show additional, context-specific information. This is particularly useful for scenarios where rows contain nested or supplementary data that would otherwise clutter the main Grid view. You can use the [DetailTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridTemplates.html#Syncfusion_Blazor_Grids_GridTemplates_DetailTemplate) property to define an HTML template for the detail row, which can include any HTML element, Syncfusion component, or custom Blazor component.

> Before adding detail template to the Grid, it is recommended to go through the [Template](https://blazor.syncfusion.com/documentation/datagrid/templates) section topic to configure the template.

To know about **Detail Template** in Grid, you can check this video.

{% youtube
"youtube:https://www.youtube.com/watch?v=Dft0kerEGUQ"%}

To integrate the Detail Template in the Grid:

1. Add the <DetailTemplate> element within the <GridTemplates> component to specify the content of the detail row.
2. Use any HTML structure or additional Blazor components within the DetailTemplate to define custom content for each expanded row.
3. Optionally, bind data to the template to display information that corresponds to the specific row being expanded.

Here's an example to demonstrate use of `DetailTemplate` to display extra details for each row:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@page "/"
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid @ref="Grid" DataSource="@Employees">
    <GridTemplates>
        <DetailTemplate>
            @{
                var employee = (context as EmployeeData);
                <table class="detailtable" width="100%">
                    <colgroup>
                        <col width="35%">
                        <col width="35%">
                        <col width="30%">
                    </colgroup>
                    <tbody>
                        <tr>
                            <td rowspan="4" style="text-align: center;">
                                <img class="photo" src="@($" scripts/Images/Employees/{employee.EmployeeID}.png")" alt="@employee.EmployeeID" />
                            </td>
                            <td>
                                <span style="font-weight: 500;">Employee ID: </span> @employee.FirstName
                            </td>
                            <td>
                                <span style="font-weight: 500;">Hire Date: </span> @employee.HireDate.ToShortDateString()
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span style="font-weight: 500;">Last Name: </span> @employee.LastName
                            </td>
                            <td>
                                <span style="font-weight: 500;">City: </span> @employee.City
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span style="font-weight: 500;">Title: </span> @employee.Title
                            </td>
                            <td>
                                <span style="font-weight: 500;">Country: </span> @employee.Country
                            </td>
                        </tr>
                    </tbody>
                </table>
            }
        </DetailTemplate>
    </GridTemplates>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.FirstName) HeaderText="First Name" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(EmployeeData.LastName) HeaderText="Last Name" Width="110"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Title) HeaderText="Title" Width="110"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Country) HeaderText="Country" Width="110"></GridColumn>
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
    }
    .photo {
        width: 100px;
        height: 100px;
        border-radius: 50px;
        box-shadow: inset 0 0 1px #e0e0e0, inset 0 0 14px rgba(0,0,0,0.2);
    }
</style>

@code {
    private SfGrid<EmployeeData> Grid;
    public List<EmployeeData> Employees { get; set; }

    protected override void OnInitialized()
    {
        Employees = EmployeeData.GetAllRecords();
    }

}
{% endhighlight %}
{% highlight c# tabtitle="EmployeeData.cs" %}
namespace BlazorApp1.Data
{
public class EmployeeData
{
public static List<EmployeeData> Employees = new List<EmployeeData>();

        public EmployeeData() { }

        public EmployeeData(int EmployeeID, string FirstName, string LastName, string Title, string Country, string City, DateTime HireDate)
        {
            this.EmployeeID = EmployeeID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Title = Title;
            this.Country = Country;
            this.City = City;
            this.HireDate = HireDate;
        }

        public static List<EmployeeData> GetAllRecords()
        {
            if (Employees.Count == 0)
            {
                var firstNames = new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven" };
                var lastNames = new string[] { "Davolio", "Fuller", "Leverling", "Peacock", "Buchanan" };
                var titles = new string[] { "Sales Representative", "Vice President, Sales", "Sales Manager", "Inside Sales Coordinator" };
                var countries = new string[] { "USA", "UK", "UAE", "NED", "BER" };
                var cities = new string[] { "New York", "London", "Dubai", "Amsterdam", "Berlin" };

                Random random = new Random();
                for (int i = 1; i <= 5; i++)
                {
                    Employees.Add(new EmployeeData(
                        i,
                        firstNames[random.Next(firstNames.Length)],
                        lastNames[random.Next(lastNames.Length)],
                        titles[random.Next(titles.Length)],
                        countries[random.Next(countries.Length)],
                        cities[random.Next(cities.Length)],
                        DateTime.Now.AddDays(-random.Next(1000, 5000)) // Random hire date between 3-14 years ago
                    ));
                }
            }
            return Employees;
        }

        public int EmployeeID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; } // New City property
        public DateTime HireDate { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

![Blazor DataGrid with Detail Template](./images/blazor-datagrid-detail-template.png)

## Expand detail DataGrid initially

Expanding the detail Grid initially in the Syncfusion Blazor DataGrid is useful when you want the detail rows to be displayed by default upon Grid load. This can be beneficial in scenarios where you want to provide immediate visibility into related or nested data without requiring you to manually expand each detail row.

To achieve this, you can use the [ExpandCollapseDetailRowAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExpandCollapseDetailRowAsync_System_String_System_Object_) method with the specified field name and row data value in the [DataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_DataBound) event of the Grid.

>* You can also use the `ExpandCollapseDetailRowAsync` method with the specified row data in the `DataBound` event.

In the following example, the record with **EmployeeID** as 1 is expanded using the `ExpandCollapseDetailRowAsync` method within the `DataBound` event.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data

<SfGrid @ref="grid" DataSource="@Employees" Height="265px">
    <GridEvents DataBound="DataBoundHandler" TValue="EmployeeData"></GridEvents>
    <GridTemplates>
        <DetailTemplate>
            @{
                var employee = (context as EmployeeData);
            }
            <SfGrid DataSource="@Orders" Query="@(new Query().Where("EmployeeID", "equal", employee.EmployeeID))">
                <GridColumns>
                    <GridColumn Field="@nameof(OrderData.OrderID)" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="110" />
                    <GridColumn Field="@nameof(OrderData.CustomerID)" HeaderText="Customer ID" Width="110" />
                    <GridColumn Field="@nameof(OrderData.ShipCity)" HeaderText="Ship City" Width="110" />
                    <GridColumn Field="@nameof(OrderData.ShipName)" HeaderText="Ship Name" Width="110" />
                </GridColumns>
            </SfGrid>
        </DetailTemplate>
    </GridTemplates>
    <GridColumns>
        <GridColumn Field="@nameof(EmployeeData.EmployeeID)" HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="110" />
        <GridColumn Field="@nameof(EmployeeData.FirstName)" HeaderText="First Name" Width="110" />
        <GridColumn Field="@nameof(EmployeeData.LastName)" HeaderText="Last Name" Width="110" />
        <GridColumn Field="@nameof(EmployeeData.Country)" HeaderText="Country" Width="110" />
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<EmployeeData> grid;
    public List<OrderData> Orders { get; set; }
    public List<EmployeeData> Employees { get; set; }

    protected override void OnInitialized()
    {
        Employees = EmployeeData.GetAllRecords();
        Orders = OrderData.GetAllRecords();
    }

    public async Task DataBoundHandler()
    {
        await grid.ExpandCollapseDetailRowAsync("EmployeeID", 1);

    }
}

{% endhighlight %}

{% highlight c# tabtitle="EmployeeData.cs" %}

public class EmployeeData
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Country { get; set; }

    public static List<EmployeeData> GetAllRecords()
    {
        return new List<EmployeeData>
        {
            new EmployeeData { EmployeeID = 1, FirstName = "Nancy", LastName = "Davolio", Country = "USA" },
            new EmployeeData { EmployeeID = 2, FirstName = "Andrew", LastName = "Fuller", Country = "UK" },
            new EmployeeData { EmployeeID = 3, FirstName = "Janet", LastName = "Leverling", Country = "USA" },
            new EmployeeData { EmployeeID = 4, FirstName = "Margaret", LastName = "Peacock", Country = "Canada" },
            new EmployeeData { EmployeeID = 5, FirstName = "Steven", LastName = "Buchanan", Country = "USA" },
            new EmployeeData { EmployeeID = 6, FirstName = "Michael", LastName = "Suyama", Country = "Japan" },
            new EmployeeData { EmployeeID = 7, FirstName = "Robert", LastName = "King", Country = "UK" },
            new EmployeeData { EmployeeID = 8, FirstName = "Laura", LastName = "Callahan", Country = "USA" },
            new EmployeeData { EmployeeID = 9, FirstName = "Anne", LastName = "Dodsworth", Country = "Germany" },
            new EmployeeData { EmployeeID = 10, FirstName = "Paul", LastName = "Henriot", Country = "France" },
            new EmployeeData { EmployeeID = 11, FirstName = "Thomas", LastName = "Hardy", Country = "UK" },
            new EmployeeData { EmployeeID = 12, FirstName = "Maria", LastName = "Anders", Country = "Germany" }
        };
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
    public int EmployeeID { get; set; }
    public static List<OrderData> GetAllRecords()
    {
        return new List<OrderData>
        {
            new OrderData { OrderID = 10248, CustomerID = "VINET", ShipCity = "Reims", ShipName = "Vins et alcools Chevalier", EmployeeID = 5 },
            new OrderData { OrderID = 10249, CustomerID = "TOMSP", ShipCity = "Münster", ShipName = "Toms Spezialitäten", EmployeeID = 6 },
            new OrderData { OrderID = 10250, CustomerID = "HANAR", ShipCity = "Rio de Janeiro", ShipName = "Hanari Carnes", EmployeeID = 4 },
            new OrderData { OrderID = 10251, CustomerID = "VICTE", ShipCity = "Lyon", ShipName = "Victuailles en stock", EmployeeID = 3 },
            new OrderData { OrderID = 10252, CustomerID = "SUPRD", ShipCity = "Charleroi", ShipName = "Suprêmes délices", EmployeeID = 2 },
            new OrderData { OrderID = 10253, CustomerID = "HANAR", ShipCity = "Rio de Janeiro", ShipName = "Hanari Carnes", EmployeeID = 7 },
            new OrderData { OrderID = 10254, CustomerID = "CHOPS", ShipCity = "Bern", ShipName = "Chop-suey Chinese", EmployeeID = 5 },
            new OrderData { OrderID = 10255, CustomerID = "RICSU", ShipCity = "Genève", ShipName = "Richter Supermarkt", EmployeeID = 9 },
            new OrderData { OrderID = 10256, CustomerID = "WELLI", ShipCity = "Resende", ShipName = "Wellington Importadora", EmployeeID = 3 },
            new OrderData { OrderID = 10257, CustomerID = "HILAA", ShipCity = "San Cristóbal", ShipName = "HILARION-Abastos", EmployeeID = 4 },
            new OrderData { OrderID = 10258, CustomerID = "ERNSH", ShipCity = "Graz", ShipName = "Ernst Handel", EmployeeID = 1 },
            new OrderData { OrderID = 10259, CustomerID = "CENTC", ShipCity = "México D.F.", ShipName = "Centro comercial Moctezuma", EmployeeID = 4 },
            new OrderData { OrderID = 10260, CustomerID = "OTTIK", ShipCity = "Köln", ShipName = "Ottilies Käseladen", EmployeeID = 4 },
            new OrderData { OrderID = 10261, CustomerID = "QUEDE", ShipCity = "Rio de Janeiro", ShipName = "Que Delícia", EmployeeID = 4 },
            new OrderData { OrderID = 10262, CustomerID = "RATTC", ShipCity = "Albuquerque", ShipName = "Rattlesnake Canyon Grocery", EmployeeID = 8 }
        };
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXBotJBVqIGMRxXj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Creating custom component/Hierarchical DataGrid 

The Syncfusion Blazor DataGrid provides a powerful feature that allows you to render custom components inside the detail row. This feature is helpful when you need to add additional information or functionality for a specific row in the Grid. Additionally, you can customize or build a hierarchical structure by placing nested Grids inside the detail row of the parent Grid. 

To render a custom component or create a Hierarchical Grid inside the detail row,  you can define the template in the [DetailTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridTemplates.html#Syncfusion_Blazor_Grids_GridTemplates_DetailTemplate) within the `GridTemplates` section. The Hierarchy DataGrid is used to display table data in hierarchical structure that can be expanded or collapsed by clicking the expand or collapse button or else you can display custom components such as HTML element etc.

In the following sample, the detail template feature of the Grid is used to display parent-child relationship data in a hierarchical structure with multiple levels (Employee → Orders → Customers):

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data

<SfGrid DataSource="@Employees" Height="315px" TValue="EmployeeData">
    <GridTemplates>
        <DetailTemplate Context="employeeContext">
            @{
                var employee = (EmployeeData)employeeContext;
            }
            <SfGrid DataSource="@Orders" Query="@(new Query().Where(nameof(OrderData.EmployeeID), "equal", employee.EmployeeID))" TValue="OrderData">
                <GridTemplates>
                    <DetailTemplate Context="orderContext">
                        @{
                            var order = (OrderData)orderContext;
                        }
                        <SfGrid DataSource="@Customers" Query="@(new Query().Where(nameof(CustomerDetails.CustomerID), "equal", order.CustomerID))" TValue="CustomerDetails">
                            <GridColumns>
                                <GridColumn Field=@nameof(CustomerDetails.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
                                <GridColumn Field=@nameof(CustomerDetails.ContactTitle) HeaderText="Title" Width="120"></GridColumn>
                                <GridColumn Field=@nameof(CustomerDetails.Address) HeaderText="Address" Width="150"></GridColumn>
                                <GridColumn Field=@nameof(CustomerDetails.Country) HeaderText="Country" Width="100"></GridColumn>
                            </GridColumns>
                        </SfGrid>
                    </DetailTemplate>
                </GridTemplates>
                <GridColumns>
                    <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GridColumn>
                    <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
                    <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="120"></GridColumn>
                    <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150"></GridColumn>
                </GridColumns>
            </SfGrid>
        </DetailTemplate>
    </GridTemplates>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.EmployeeID) HeaderText="Employee ID" Width="120" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.FirstName) HeaderText="First Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.LastName) HeaderText="Last Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Country) HeaderText="Country" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<EmployeeData> Employees { get; set; }
    public List<OrderData> Orders { get; set; }
    public List<CustomerDetails> Customers { get; set; }

    protected override void OnInitialized()
    {
        Employees = EmployeeData.GetAllRecords();
        Orders = OrderData.GetAllRecords();
        Customers = CustomerDetails.GetAllRecords();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
    public int EmployeeID { get; set; }
    public static List<OrderData> GetAllRecords()
    {
        return new List<OrderData>
        {
            new OrderData { OrderID = 10248, CustomerID = "VINET", ShipCity = "Reims", ShipName = "Vins et alcools Chevalier", EmployeeID = 5 },
            new OrderData { OrderID = 10249, CustomerID = "TOMSP", ShipCity = "Münster", ShipName = "Toms Spezialitäten", EmployeeID = 6 },
            new OrderData { OrderID = 10250, CustomerID = "HANAR", ShipCity = "Rio de Janeiro", ShipName = "Hanari Carnes", EmployeeID = 4 },
            new OrderData { OrderID = 10251, CustomerID = "VICTE", ShipCity = "Lyon", ShipName = "Victuailles en stock", EmployeeID = 3 },
            new OrderData { OrderID = 10252, CustomerID = "SUPRD", ShipCity = "Charleroi", ShipName = "Suprêmes délices", EmployeeID = 2 },
            new OrderData { OrderID = 10253, CustomerID = "HANAR", ShipCity = "Rio de Janeiro", ShipName = "Hanari Carnes", EmployeeID = 7 },
            new OrderData { OrderID = 10254, CustomerID = "CHOPS", ShipCity = "Bern", ShipName = "Chop-suey Chinese", EmployeeID = 5 },
            new OrderData { OrderID = 10255, CustomerID = "RICSU", ShipCity = "Genève", ShipName = "Richter Supermarkt", EmployeeID = 9 },
            new OrderData { OrderID = 10256, CustomerID = "WELLI", ShipCity = "Resende", ShipName = "Wellington Importadora", EmployeeID = 3 },
            new OrderData { OrderID = 10257, CustomerID = "HILAA", ShipCity = "San Cristóbal", ShipName = "HILARION-Abastos", EmployeeID = 4 },
            new OrderData { OrderID = 10258, CustomerID = "ERNSH", ShipCity = "Graz", ShipName = "Ernst Handel", EmployeeID = 1 },
            new OrderData { OrderID = 10259, CustomerID = "CENTC", ShipCity = "México D.F.", ShipName = "Centro comercial Moctezuma", EmployeeID = 4 },
            new OrderData { OrderID = 10260, CustomerID = "OTTIK", ShipCity = "Köln", ShipName = "Ottilies Käseladen", EmployeeID = 4 },
            new OrderData { OrderID = 10261, CustomerID = "QUEDE", ShipCity = "Rio de Janeiro", ShipName = "Que Delícia", EmployeeID = 4 },
            new OrderData { OrderID = 10262, CustomerID = "RATTC", ShipCity = "Albuquerque", ShipName = "Rattlesnake Canyon Grocery", EmployeeID = 8 }
        };
    }
}

{% endhighlight %}

{% highlight c# tabtitle="EmployeeData.cs" %}

public class EmployeeData
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Country { get; set; }

    public static List<EmployeeData> GetAllRecords()
    {
        return new List<EmployeeData>
        {
            new EmployeeData { EmployeeID = 1, FirstName = "Nancy", LastName = "Davolio", Country = "USA" },
            new EmployeeData { EmployeeID = 2, FirstName = "Andrew", LastName = "Fuller", Country = "UK" },
            new EmployeeData { EmployeeID = 3, FirstName = "Janet", LastName = "Leverling", Country = "USA" },
            new EmployeeData { EmployeeID = 4, FirstName = "Margaret", LastName = "Peacock", Country = "Canada" },
            new EmployeeData { EmployeeID = 5, FirstName = "Steven", LastName = "Buchanan", Country = "USA" },
            new EmployeeData { EmployeeID = 6, FirstName = "Michael", LastName = "Suyama", Country = "Japan" },
            new EmployeeData { EmployeeID = 7, FirstName = "Robert", LastName = "King", Country = "UK" },
            new EmployeeData { EmployeeID = 8, FirstName = "Laura", LastName = "Callahan", Country = "USA" },
            new EmployeeData { EmployeeID = 9, FirstName = "Anne", LastName = "Dodsworth", Country = "Germany" },
            new EmployeeData { EmployeeID = 10, FirstName = "Paul", LastName = "Henriot", Country = "France" },
            new EmployeeData { EmployeeID = 11, FirstName = "Thomas", LastName = "Hardy", Country = "UK" },
            new EmployeeData { EmployeeID = 12, FirstName = "Maria", LastName = "Anders", Country = "Germany" }
        };
    }
}

{% endhighlight %}

{% highlight c# tabtitle="CustomerDetails.cs" %}

public class CustomerDetails
{
    public string CustomerID { get; set; }
    public string ContactTitle { get; set; }
    public string Country { get; set; }
    public string Address { get; set; }

    public static List<CustomerDetails> GetAllRecords()
    {
        return new List<CustomerDetails>
        {
            new CustomerDetails { CustomerID = "VINET", ContactTitle = "Vins et alcools Chevalier", Country = "France", Address = "59 rue de l'Abbaye" },
            new CustomerDetails { CustomerID = "TOMSP", ContactTitle = "Toms Spezialitäten", Country = "Germany", Address = "Luisenstr. 48" },
            new CustomerDetails { CustomerID = "HANAR", ContactTitle = "Hanari Carnes", Country = "Brazil", Address = "Rua do Paço, 67" },
            new CustomerDetails { CustomerID = "VICTE", ContactTitle = "Victuailles en stock", Country = "France", Address = "1 rue de la Paix" },
            new CustomerDetails { CustomerID = "SUPRD", ContactTitle = "Suprêmes délices", Country = "Belgium", Address = "Boulevard de l'Indépendance" },
            new CustomerDetails { CustomerID = "CHOPS", ContactTitle = "Chop-suey Chinese", Country = "Switzerland", Address = "Münsterstr. 16" },
            new CustomerDetails { CustomerID = "RICSU", ContactTitle = "Richter Supermarkt", Country = "Switzerland", Address = "Hauptstr. 45" },
            new CustomerDetails { CustomerID = "WELLI", ContactTitle = "Wellington Importadora", Country = "Brazil", Address = "Rua dos Três Irmãos" },
            new CustomerDetails { CustomerID = "HILAA", ContactTitle = "HILARION-Abastos", Country = "Venezuela", Address = "Av. de la Independencia" },
            new CustomerDetails { CustomerID = "ERNSH", ContactTitle = "Ernst Handel", Country = "Austria", Address = "Kirchgasse 6" },
            new CustomerDetails { CustomerID = "CENTC", ContactTitle = "Centro comercial Moctezuma", Country = "Mexico", Address = "Av. Moctezuma 56" },
            new CustomerDetails { CustomerID = "OTTIK", ContactTitle = "Ottilies Käseladen", Country = "Germany", Address = "Waldstr. 15" },
            new CustomerDetails { CustomerID = "QUEDE", ContactTitle = "Que Delícia", Country = "Brazil", Address = "Av. Rio Branco 20" },
            new CustomerDetails { CustomerID = "RATTC", ContactTitle = "Rattlesnake Canyon Grocery", Country = "USA", Address = "17th St. W" }
        };
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjLoDoUtUlcPEWyj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> By default, the Syncfusion Blazor DataGrid does not have built-in hierarchical support. However, you can customize the Grid using the detail template feature to display multiple levels of a hierarchical Grid, as shown in the example above.

## Template column in detail DataGrid

A template column in a detail Grid within the Syncfusion Blazor DataGrid is valuable when you want to customize the appearance and functionality of specific columns in the detail Grid. It is useful for incorporating interactive elements, custom formatting, or complex data representation within specific columns of the detail Grid.

To achieve this, you can utilize the `Template` property of a column to display a custom element instead of a field value in the Grid.

The following example demonstrates, how to show a custom image in the **Employee Image** column of the detail Grid by utilizing the `Template` property of the column.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data

<SfGrid DataSource="@Employees" Height="300px">
    <GridTemplates>
        <DetailTemplate>
            @{
                var employee = (context as EmployeeData);
            }
            <SfGrid DataSource="@Orders" Query="@(new Query().Where("EmployeeID", "equal", employee.EmployeeID))">
                <GridColumns>
                    <GridColumn HeaderText="Employee Image" TextAlign="TextAlign.Center" Width="120">
                        <Template Context="orderContext">
                            @{
                                var order = orderContext as OrderData;
                            }
                            <div class="image">
                                <img src="@($"scripts/Images/Employees/{order.EmployeeID}.png")" alt="Employee Image" />
                            </div>
                        </Template>
                    </GridColumn>
                    <GridColumn Field="@nameof(OrderData.OrderID)" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="110" />
                    <GridColumn Field="@nameof(OrderData.CustomerID)" HeaderText="Customer ID" Width="110" />
                    <GridColumn Field="@nameof(OrderData.ShipCity)" HeaderText="Ship City" Width="110" />
                    <GridColumn Field="@nameof(OrderData.ShipName)" HeaderText="Ship Name" Width="110" />
                </GridColumns>
            </SfGrid>
        </DetailTemplate>
    </GridTemplates>
    <GridColumns>
        <GridColumn Field="@nameof(EmployeeData.EmployeeID)" HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="110" />
        <GridColumn Field="@nameof(EmployeeData.FirstName)" HeaderText="First Name" Width="110" />
        <GridColumn Field="@nameof(EmployeeData.LastName)" HeaderText="Last Name" Width="110" />
        <GridColumn Field="@nameof(EmployeeData.Country)" HeaderText="Country" Width="110" />
    </GridColumns>
</SfGrid>
<style>
.image img {
    height: 55px;
    width: 55px;
    border-radius: 50px;
    box-shadow: inset 0 0 1px #e0e0e0, inset 0 0 14px rgba(0,0,0,0.2);
}
</style>
@code {
    public List<EmployeeData> Employees { get; set; }
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Employees = EmployeeData.GetAllRecords();
        Orders = OrderData.GetAllRecords();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="EmployeeData.cs" %}

public class EmployeeData
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Country { get; set; }

    public static List<EmployeeData> GetAllRecords()
    {
        return new List<EmployeeData>
        {
            new EmployeeData { EmployeeID = 1, FirstName = "Nancy", LastName = "Davolio", Country = "USA" },
            new EmployeeData { EmployeeID = 2, FirstName = "Andrew", LastName = "Fuller", Country = "UK" },
            new EmployeeData { EmployeeID = 3, FirstName = "Janet", LastName = "Leverling", Country = "USA" },
            new EmployeeData { EmployeeID = 4, FirstName = "Margaret", LastName = "Peacock", Country = "Canada" },
            new EmployeeData { EmployeeID = 5, FirstName = "Steven", LastName = "Buchanan", Country = "USA" },
            new EmployeeData { EmployeeID = 6, FirstName = "Michael", LastName = "Suyama", Country = "Japan" },
            new EmployeeData { EmployeeID = 7, FirstName = "Robert", LastName = "King", Country = "UK" },
            new EmployeeData { EmployeeID = 8, FirstName = "Laura", LastName = "Callahan", Country = "USA" },
            new EmployeeData { EmployeeID = 9, FirstName = "Anne", LastName = "Dodsworth", Country = "Germany" },
            new EmployeeData { EmployeeID = 10, FirstName = "Paul", LastName = "Henriot", Country = "France" },
            new EmployeeData { EmployeeID = 11, FirstName = "Thomas", LastName = "Hardy", Country = "UK" },
            new EmployeeData { EmployeeID = 12, FirstName = "Maria", LastName = "Anders", Country = "Germany" }
        };
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
    public int EmployeeID { get; set; }
    public double Freight { get; set; } 

    public static List<OrderData> GetAllRecords()
    {
        return new List<OrderData>
        {
            new OrderData { OrderID = 10248, CustomerID = "VINET", ShipCity = "Reims", ShipName = "Vins et alcools Chevalier", EmployeeID = 5, Freight = 32.38 },
            new OrderData { OrderID = 10249, CustomerID = "TOMSP", ShipCity = "Münster", ShipName = "Toms Spezialitäten", EmployeeID = 6, Freight = 11.61 },
            new OrderData { OrderID = 10250, CustomerID = "HANAR", ShipCity = "Rio de Janeiro", ShipName = "Hanari Carnes", EmployeeID = 4, Freight = 65.83 },
            new OrderData { OrderID = 10251, CustomerID = "VICTE", ShipCity = "Lyon", ShipName = "Victuailles en stock", EmployeeID = 3, Freight = 41.34 },
            new OrderData { OrderID = 10252, CustomerID = "SUPRD", ShipCity = "Charleroi", ShipName = "Suprêmes délices", EmployeeID = 2, Freight = 51.30 },
            new OrderData { OrderID = 10253, CustomerID = "HANAR", ShipCity = "Rio de Janeiro", ShipName = "Hanari Carnes", EmployeeID = 7, Freight = 58.17 },
            new OrderData { OrderID = 10254, CustomerID = "CHOPS", ShipCity = "Bern", ShipName = "Chop-suey Chinese", EmployeeID = 5, Freight = 22.98 },
            new OrderData { OrderID = 10255, CustomerID = "RICSU", ShipCity = "Genève", ShipName = "Richter Supermarkt", EmployeeID = 9, Freight = 148.33 },
            new OrderData { OrderID = 10256, CustomerID = "WELLI", ShipCity = "Resende", ShipName = "Wellington Importadora", EmployeeID = 3, Freight = 13.97 },
            new OrderData { OrderID = 10257, CustomerID = "HILAA", ShipCity = "San Cristóbal", ShipName = "HILARION-Abastos", EmployeeID = 4, Freight = 81.91 },
            new OrderData { OrderID = 10258, CustomerID = "ERNSH", ShipCity = "Graz", ShipName = "Ernst Handel", EmployeeID = 1, Freight = 140.51 },
            new OrderData { OrderID = 10259, CustomerID = "CENTC", ShipCity = "México D.F.", ShipName = "Centro comercial Moctezuma", EmployeeID = 4, Freight = 3.25 },
            new OrderData { OrderID = 10260, CustomerID = "OTTIK", ShipCity = "Köln", ShipName = "Ottilies Käseladen", EmployeeID = 1, Freight = 55.09 },
            new OrderData { OrderID = 10261, CustomerID = "QUEDE", ShipCity = "Rio de Janeiro", ShipName = "Que Delícia", EmployeeID = 4, Freight = 3.05 },
            new OrderData { OrderID = 10262, CustomerID = "RATTC", ShipCity = "Albuquerque", ShipName = "Rattlesnake Canyon Grocery", EmployeeID = 8, Freight = 48.29 },
            new OrderData { OrderID = 10263, CustomerID = "ERNSH", ShipCity = "Graz", ShipName = "Ernst Handel", EmployeeID = 9, Freight = 76.13 },
            new OrderData { OrderID = 10264, CustomerID = "FOLKO", ShipCity = "Bräcke", ShipName = "Folk och fä HB", EmployeeID = 6, Freight = 3.67 },
            new OrderData { OrderID = 10265, CustomerID = "BLONP", ShipCity = "Strasbourg", ShipName = "Blondel père et fils", EmployeeID = 2, Freight = 55.28 },
            new OrderData { OrderID = 10266, CustomerID = "WARTH", ShipCity = "Stavern", ShipName = "Wartian Herkku", EmployeeID = 3, Freight = 25.73 },
            new OrderData { OrderID = 10267, CustomerID = "FRANK", ShipCity = "München", ShipName = "Frankenversand", EmployeeID = 4, Freight = 208.58 }
        };
    }
}

{% endhighlight %}
{% endtabs %}

![Template column in detail Grid](images/hierarchy-grid/hierarchy-grid-template.png)

## Expand by external button

By default, detail rows render in collapsed state. You can expand a detail rows by invoking the [ExpandAllDetailRowAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExpandAllDetailRowAsync) method using the external button.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@page "/"

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using BlazorApp1.Data

<SfButton style="margin:5px" Content="Expand" OnClick="BtnClick"></SfButton>
<SfGrid @ref="Grid" DataSource="@Employees">
    <GridTemplates>
        <DetailTemplate>
            @{
                var employee = (context as EmployeeData);
                <table class="detailtable" width="100%">
                    <colgroup>
                        <col width="35%">
                        <col width="35%">
                        <col width="30%">
                    </colgroup>
                    <tbody>
                        <tr>
                            <td rowspan="4" style="text-align: center;">
                                <img class="photo" src="@($" scripts/Images/Employees/{employee.EmployeeID}.png")" alt="@employee.EmployeeID" />
                            </td>
                            <td>
                                <span style="font-weight: 500;">Employee ID: </span> @employee.FirstName
                            </td>
                            <td>
                                <span style="font-weight: 500;">Hire Date: </span> @employee.HireDate.ToShortDateString()
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span style="font-weight: 500;">Last Name: </span> @employee.LastName
                            </td>
                            <td>
                                <span style="font-weight: 500;">City: </span> @employee.City
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span style="font-weight: 500;">Title: </span> @employee.Title
                            </td>
                            <td>
                                <span style="font-weight: 500;">Country: </span> @employee.Country
                            </td>
                        </tr>
                    </tbody>
                </table>
            }
        </DetailTemplate>
    </GridTemplates>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.FirstName) HeaderText="First Name" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(EmployeeData.LastName) HeaderText="Last Name" Width="110"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Title) HeaderText="Title" Width="110"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Country) HeaderText="Country" Width="110"></GridColumn>
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
    }
    .photo {
        width: 100px;
        height: 100px;
        border-radius: 50px;
        box-shadow: inset 0 0 1px #e0e0e0, inset 0 0 14px rgba(0,0,0,0.2);
    }
</style>

@code {
    private SfGrid<EmployeeData> Grid;
    private int TextBox;

    public List<EmployeeData> Employees { get; set; }

    public void BtnClick()
    {
        this.Grid.ExpandAllDetailRowAsync();
    }
    protected override void OnInitialized()
    {
        Employees = EmployeeData.GetAllRecords();
    }

}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
namespace BlazorApp1.Data
{
public class OrderData
{
public static List<OrderData> Orders = new List<OrderData>();

        public OrderData() { }

        public OrderData(int? OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, int employeeID)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.ShipName = ShipName;
            this.Freight = Freight;
            this.OrderDate = OrderDate;
            this.ShippedDate = ShippedDate;
            this.IsVerified = IsVerified;
            this.ShipCity = ShipCity;
            this.ShipCountry = ShipCountry;
            this.EmployeeID = employeeID;
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count == 0)
            {
                Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", 1));
                Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", 2));
                Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "Brazil", 3));
                Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", 1));
                Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", 2));
                Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", 3));
                Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", 2));
                Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "Brazil", 1));
                Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", 3));
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipName { get; set; }
        public double? Freight { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public bool? IsVerified { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public int EmployeeID { get; set; }
    }

}

{% endhighlight %}
{% highlight c# tabtitle="EmployeeData.cs" %}
namespace BlazorApp1.Data
{
public class EmployeeData
{
public static List<EmployeeData> Employees = new List<EmployeeData>();

        public EmployeeData() { }

        public EmployeeData(int EmployeeID, string FirstName, string LastName, string Title, string Country, string City, DateTime HireDate)
        {
            this.EmployeeID = EmployeeID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Title = Title;
            this.Country = Country;
            this.City = City;
            this.HireDate = HireDate;
        }

        public static List<EmployeeData> GetAllRecords()
        {
            if (Employees.Count == 0)
            {
                var firstNames = new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven" };
                var lastNames = new string[] { "Davolio", "Fuller", "Leverling", "Peacock", "Buchanan" };
                var titles = new string[] { "Sales Representative", "Vice President, Sales", "Sales Manager", "Inside Sales Coordinator" };
                var countries = new string[] { "USA", "UK", "UAE", "NED", "BER" };
                var cities = new string[] { "New York", "London", "Dubai", "Amsterdam", "Berlin" };

                Random random = new Random();
                for (int i = 1; i <= 5; i++)
                {
                    Employees.Add(new EmployeeData(
                        i,
                        firstNames[random.Next(firstNames.Length)],
                        lastNames[random.Next(lastNames.Length)],
                        titles[random.Next(titles.Length)],
                        countries[random.Next(countries.Length)],
                        cities[random.Next(cities.Length)],
                        DateTime.Now.AddDays(-random.Next(1000, 5000))
                    ));
                }
            }
            return Employees;
        }

        public int EmployeeID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public DateTime HireDate { get; set; }
    }

}

{% endhighlight %}
{% endtabs %}

![Expand by external button](./images/blazor-datagrid-detail-template-externalbutton.png)

> * You can expand all the rows by using `ExpandAllDetailRowAsync` method.
* If you want to expand all the rows at initial Grid rendering, then use `ExpandAllDetailRowAsync` method in [DataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_DataBound) event of the Grid.

## Expand or collapse specific detail template row

To expand or collapse a specific row of a detail template in the Syncfusion Blazor DataGrid, you can use the [ExpandCollapseDetailRowAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExpandCollapseDetailRowAsync__0_) method. This method allows you to programmatically expand or collapse the detail template for a specific row of data by passing the data object representing that row.

The following code demonstrates how to expand the particular rows using `ExpandCollapseDetailRowAsync` method of the Grid when a button is clicked, using the Grid reference.

In the below code, the **Expand** method is defined to expand or collapse the detail row of a specific employee when the "Expand/Collapse" button is clicked.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@page "/"
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Inputs
@using BlazorApp1.Data

<div style="display: inline-block; padding: 0px 30px 0px 0px; margin:5px">
   <p style="color: red">@message</p>
    <SfTextBox Placeholder="Enter the row index" Width="250px" @bind-Value="rowIndex"></SfTextBox>
<SfButton Content="Expand/Collapse" OnClick="Expand"></SfButton>
</div>
<SfGrid @ref="Grid" DataSource="@Employees" TValue="EmployeeData" Height="315px">
    <GridTemplates>
        <DetailTemplate>
            @{
                var employee = (context as EmployeeData);
                var Order = (context as OrderData);
                <SfGrid DataSource="@Orders" Query="@(new Query().Where("EmployeeID", "equal", employee.EmployeeID))">
                    <GridColumns>
                        <GridColumn Field=@nameof(Order.OrderID) HeaderText="First Name" Width="110"> </GridColumn>
                        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Last Name" Width="110"></GridColumn>
                        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Title" Width="110"></GridColumn>
                    </GridColumns>
                </SfGrid>
            }
        </DetailTemplate>
    </GridTemplates>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.FirstName) HeaderText="First Name" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(EmployeeData.LastName) HeaderText="Last Name" Width="110"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Title) HeaderText="Title" Width="110"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Country) HeaderText="Country" Width="110"></GridColumn>
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
    }

    .photo {
        width: 100px;
        height: 100px;
        border-radius: 50px;
        box-shadow: inset 0 0 1px #e0e0e0, inset 0 0 14px rgba(0,0,0,0.2);
    }
</style>

@code {
    private SfGrid<EmployeeData> Grid;
    private string rowIndex;
    private string message;

    public List<EmployeeData> Employees { get; set; }
    public List<OrderData> Orders { get; set; }

    public async Task Expand()
    {
        if (int.TryParse(rowIndex, out int index) && index >= 0 && index < Employees.Count)
        {
            message= "";
            await this.Grid.ExpandCollapseDetailRowAsync(Employees[index]);
        }
        else
        {
           message = "Invalid index";
        }
    }

    protected override void OnInitialized()
    {
        Employees = EmployeeData.GetAllRecords();
        Orders = OrderData.GetAllRecords();
    }

}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

        public OrderData() { }

        public OrderData(int? OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, int employeeID)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.ShipName = ShipName;
            this.Freight = Freight;
            this.OrderDate = OrderDate;
            this.ShippedDate = ShippedDate;
            this.IsVerified = IsVerified;
            this.ShipCity = ShipCity;
            this.ShipCountry = ShipCountry;
            this.EmployeeID = employeeID;
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count == 0)
            {
                Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", 1));
                Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", 2));
                Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "Brazil", 3));
                Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", 1));
                Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", 2));
                Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", 3));
                Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", 2));
                Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "Brazil", 1));
                Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", 3));
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipName { get; set; }
        public double? Freight { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public bool? IsVerified { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public int EmployeeID { get; set; }
    }

{% endhighlight %}
{% highlight c# tabtitle="EmployeeData.cs" %}

public class EmployeeData
{
public static List<EmployeeData> Employees = new List<EmployeeData>();

        public EmployeeData() { }

        public EmployeeData(int EmployeeID, string FirstName, string LastName, string Title, string Country, string City, DateTime HireDate)
        {
            this.EmployeeID = EmployeeID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Title = Title;
            this.Country = Country;
            this.City = City;
            this.HireDate = HireDate;
        }

        public static List<EmployeeData> GetAllRecords()
        {
            if (Employees.Count == 0)
            {
                var firstNames = new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven" };
                var lastNames = new string[] { "Davolio", "Fuller", "Leverling", "Peacock", "Buchanan" };
                var titles = new string[] { "Sales Representative", "Vice President, Sales", "Sales Manager", "Inside Sales Coordinator" };
                var countries = new string[] { "USA", "UK", "UAE", "NED", "BER" };
                var cities = new string[] { "New York", "London", "Dubai", "Amsterdam", "Berlin" };

                Random random = new Random();
                for (int i = 1; i <= 5; i++)
                {
                    Employees.Add(new EmployeeData(
                        i,
                        firstNames[random.Next(firstNames.Length)],
                        lastNames[random.Next(lastNames.Length)],
                        titles[random.Next(titles.Length)],
                        countries[random.Next(countries.Length)],
                        cities[random.Next(cities.Length)],
                        DateTime.Now.AddDays(-random.Next(1000, 5000))
                    ));
                }
            }
            return Employees;
        }

        public int EmployeeID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public DateTime HireDate { get; set; }
    }

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjVfCMsBMmVxgIHX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize detail template icon

The detail template icon in the Syncfusion Blazor DataGrid is used to expand or collapse the detail content of a row. By default, the icon represents a right arrow for the collapsed state and a down arrow for the expanded state. If you want to customize this icon, you can achieve it by overriding the following CSS styles:

```css
    .e-grid .e-icon-grightarrow::before {
        content: "\e7a9";
    }

    .e-grid .e-icon-gdownarrow::before {
        content: "\e7fe";
    }
```

Here is an example of how to customize the detail template icon:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@page "/"

@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid @ref="Grid" DataSource="@Employees">
    <GridTemplates>
        <DetailTemplate>
            @{
                var employee = (context as EmployeeData);

                <table class="detailtable" width="100%">
                    <colgroup>
                        <col width="35%">
                        <col width="35%">
                        <col width="30%">
                    </colgroup>
                    <tbody>
                        <tr>
                            <td rowspan="4" style="text-align: center;">
                                <img class="photo" src="@($" scripts/Images/Employees/{employee.EmployeeID}.png")" alt="@employee.EmployeeID" />
                            </td>
                            <td>
                                <span style="font-weight: 500;">Employee ID: </span> @employee.FirstName
                            </td>
                            <td>
                                <span style="font-weight: 500;">Hire Date: </span> @employee.HireDate.ToShortDateString()
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span style="font-weight: 500;">Last Name: </span> @employee.LastName
                            </td>
                            <td>
                                <span style="font-weight: 500;">City: </span> @employee.City
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span style="font-weight: 500;">Title: </span> @employee.Title
                            </td>
                            <td>
                                <span style="font-weight: 500;">Country: </span> @employee.Country
                            </td>
                        </tr>
                    </tbody>
                </table>
            }
        </DetailTemplate>
    </GridTemplates>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.FirstName) HeaderText="First Name" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(EmployeeData.LastName) HeaderText="Last Name" Width="110"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Title) HeaderText="Title" Width="110"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Country) HeaderText="Country" Width="110"></GridColumn>
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
    }

    .photo {
        width: 100px;
        height: 100px;
        border-radius: 50px;
        box-shadow: inset 0 0 1px #e0e0e0, inset 0 0 14px rgba(0,0,0,0.2);
    }

    .e-grid .e-icon-grightarrow::before {
        content: "\e7a9";
    }

    .e-grid .e-icon-gdownarrow::before {
        content: "\e7fe";
    }
</style>

@code {
    private SfGrid<EmployeeData> Grid;
    public List<EmployeeData> Employees { get; set; }

    protected override void OnInitialized()
    {
        Employees = EmployeeData.GetAllRecords();
    }

}
{% endhighlight %}
{% highlight c# tabtitle="EmployeeData.cs" %}
namespace BlazorApp1.Data
{
public class EmployeeData
{
public static List<EmployeeData> Employees = new List<EmployeeData>();

        public EmployeeData() { }

        public EmployeeData(int EmployeeID, string FirstName, string LastName, string Title, string Country, string City, DateTime HireDate)
        {
            this.EmployeeID = EmployeeID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Title = Title;
            this.Country = Country;
            this.City = City;
            this.HireDate = HireDate;
        }

        public static List<EmployeeData> GetAllRecords()
        {
            if (Employees.Count == 0)
            {
                var firstNames = new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven" };
                var lastNames = new string[] { "Davolio", "Fuller", "Leverling", "Peacock", "Buchanan" };
                var titles = new string[] { "Sales Representative", "Vice President, Sales", "Sales Manager", "Inside Sales Coordinator" };
                var countries = new string[] { "USA", "UK", "UAE", "NED", "BER" };
                var cities = new string[] { "New York", "London", "Dubai", "Amsterdam", "Berlin" };

                Random random = new Random();
                for (int i = 1; i <= 5; i++)
                {
                    Employees.Add(new EmployeeData(
                        i,
                        firstNames[random.Next(firstNames.Length)],
                        lastNames[random.Next(lastNames.Length)],
                        titles[random.Next(titles.Length)],
                        countries[random.Next(countries.Length)],
                        cities[random.Next(cities.Length)],
                        DateTime.Now.AddDays(-random.Next(1000, 5000)) // Random hire date between 3-14 years ago
                    ));
                }
            }
            return Employees;
        }

        public int EmployeeID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; } // New City property
        public DateTime HireDate { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

![Blazor DataGrid with customized Detail Template icon ](./images/blazor-datagrid-detail-template-customizeicon.png)

## How to access the child component in the detail template

Using the detail template feature of the Syncfusion Blazor DataGrid, a Grid-like structure with hierarchical binding can be achieved by rendering a Grid inside the DetailTemplate. By default, the @ref property of the Grid will be of SfGrid<T>, which will carry a particular Grid instance. But for the hierarchy Grid, this scenario will be different and an instance for each child Grid cannot be found directly. To access each child Grid instance, the @ref property is defined using a dictionary object with a key and value pair. Where the values are of the SfGrid<T> type and the keys are unique within the dictionary object.

In the following sample, you can get the instance of that particular child Grid using the unique key value sent as an additional argument in the [OnToolbarClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnToolbarClick) event and fetch the selected record details from each child Grid using the [GetSelectedRecordsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetSelectedRecordsAsync) method of each child Grid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@page "/"

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Data

<h5 style="text-align:center;color:green">@SelectedRecordsMessage</h5> 

<SfGrid DataSource="@Employees">
    <GridTemplates>
        <DetailTemplate>
            @{
                var order = (context as OrderData);
                var employee = (context as EmployeeData);

                <SfGrid @ref=Grid[(int)employee.EmployeeID] DataSource="@Orders" Toolbar="@Toolbaritems" Query="@(new Query().Where("EmployeeID", "equal", employee.EmployeeID))">
                    <GridEvents TValue="OrderData" OnToolbarClick="@((e)=>ToolbarClickHandler(e, employee.EmployeeID))"></GridEvents>
                    <GridSelectionSettings Type="SelectionType.Multiple"></GridSelectionSettings>
                    <GridColumns>
                        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="OrderID" Width="110"> </GridColumn>
                        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="110"></GridColumn>
                        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="ShipCountry" Width="110"></GridColumn>
                    </GridColumns>
                </SfGrid>
            }
        </DetailTemplate>
    </GridTemplates>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.FirstName) HeaderText="First Name" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(EmployeeData.LastName) HeaderText="Last Name" Width="110"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Title) HeaderText="Title" Width="110"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Country) HeaderText="Country" Width="110"></GridColumn>
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
    }

    .photo {
        width: 100px;
        height: 100px;
        border-radius: 50px;
        box-shadow: inset 0 0 1px #e0e0e0, inset 0 0 14px rgba(0,0,0,0.2);
    }
</style>

@code {

    public List<EmployeeData> Employees { get; set; }
    public List<OrderData> Orders { get; set; }

    Dictionary<int?, SfGrid<OrderData>> Grid = new Dictionary<int?, SfGrid<OrderData>>();
    private List<Object> Toolbaritems = new List<Object>() { new ItemModel() { Text = "Click", TooltipText = "Click", PrefixIcon = "e-click", Id = "Click" } };
    private string SelectedRecordsMessage { get; set; } = "Select records to view details";

    protected override void OnInitialized()
    {
        Employees = EmployeeData.GetAllRecords();
        Orders = OrderData.GetAllRecords();
    }

    public async Task ToolbarClickHandler(ClickEventArgs args, int? employeeID)
    {
        if (args.Item.Id == "Click" && employeeID.HasValue && Grid.ContainsKey(employeeID))
        {
            var selectedRecords = await Grid[employeeID].GetSelectedRecordsAsync();
            SelectedRecordsMessage = selectedRecords.Count > 0
                ? $"Selected records for Employee ID {employeeID}: {string.Join(", ", selectedRecords.Select(r => r.OrderID))}"
                : $"No records selected for Employee ID {employeeID}";
        }
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
public static List<OrderData> Orders = new List<OrderData>();

        public OrderData() { }

        public OrderData(int? OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, int employeeID)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.ShipName = ShipName;
            this.Freight = Freight;
            this.OrderDate = OrderDate;
            this.ShippedDate = ShippedDate;
            this.IsVerified = IsVerified;
            this.ShipCity = ShipCity;
            this.ShipCountry = ShipCountry;
            this.EmployeeID = employeeID;
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count == 0)
            {
                Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", 1));
                Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", 2));
                Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "Brazil", 3));
                Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", 1));
                Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", 2));
                Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", 3));
                Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", 2));
                Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "Brazil", 1));
                Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", 3));
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipName { get; set; }
        public double? Freight { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public bool? IsVerified { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public int EmployeeID { get; set; }
    }

}

{% endhighlight %}
{% highlight c# tabtitle="EmployeeData.cs" %}

public class EmployeeData
{
public static List<EmployeeData> Employees = new List<EmployeeData>();

        public EmployeeData() { }

        public EmployeeData(int EmployeeID, string FirstName, string LastName, string Title, string Country, string City, DateTime HireDate)
        {
            this.EmployeeID = EmployeeID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Title = Title;
            this.Country = Country;
            this.City = City;
            this.HireDate = HireDate;
        }

        public static List<EmployeeData> GetAllRecords()
        {
            if (Employees.Count == 0)
            {
                var firstNames = new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven" };
                var lastNames = new string[] { "Davolio", "Fuller", "Leverling", "Peacock", "Buchanan" };
                var titles = new string[] { "Sales Representative", "Vice President, Sales", "Sales Manager", "Inside Sales Coordinator" };
                var countries = new string[] { "USA", "UK", "UAE", "NED", "BER" };
                var cities = new string[] { "New York", "London", "Dubai", "Amsterdam", "Berlin" };

                Random random = new Random();
                for (int i = 1; i <= 5; i++)
                {
                    Employees.Add(new EmployeeData(
                        i,
                        firstNames[random.Next(firstNames.Length)],
                        lastNames[random.Next(lastNames.Length)],
                        titles[random.Next(titles.Length)],
                        countries[random.Next(countries.Length)],
                        cities[random.Next(cities.Length)],
                        DateTime.Now.AddDays(-random.Next(1000, 5000)) // Random hire date between 3-14 years ago
                    ));
                }
            }
            return Employees;
        }

        public int EmployeeID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; } // New City property
        public DateTime HireDate { get; set; }
    }

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjhpWWCAsuvxiajJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> [View Sample in GitHub.](https://github.com/SyncfusionExamples/blazor-datagrid-set-instance-for-child-component)

## Hide the expand/collapse icon in parent row when no record in detail DataGrid

The Syncfusion Blazor DataGrid allows you to hide the expand/collapse icon in the parent row when there are no records in the detail Grid. However, in certain scenarios, you may want to hide the expand/collapse icon for parent rows that do not have any child records, providing a cleaner and more intuitive interface by eliminating unnecessary icons in empty parent rows.

To achieve this, you can use the [RowDataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowDataBound) event, which is triggered when a row is created in the Grid. In this event, you can check whether the detail Grid has any records by checking the current records's details and the detail Grid's datasource. Based on this condition, you can add a specific class to the row using the `AddClass` method. This allows you to override the default CSS class and hide the expand/collapse icon. Add the custom CSS styles as shown below:

```css

    .e-detail-disable .e-detailrowcollapse {
       pointer-events: none;
    }
    .e-detail-disable .e-detailrowcollapse .e-icon-grightarrow {
        visibility: hidden;
    }

```

The following example demonstrates how to hide the expand/collapse icon in the row with **EmployeeID** as **1**, which does not have record in detail Grid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data

<SfGrid DataSource="@Employees" Height="300px">
    <GridEvents RowDataBound="RowDataBound" TValue="EmployeeData"></GridEvents>
    <GridTemplates>
        <DetailTemplate>
            @{
                var employee = (context as EmployeeData);
            }
            <SfGrid DataSource="@Orders" Query="@(new Query().Where("EmployeeID", "equal", employee.EmployeeID))">
                <GridColumns>
                    <GridColumn Field="@nameof(OrderData.OrderID)" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="110" />
                    <GridColumn Field="@nameof(OrderData.CustomerID)" HeaderText="Customer ID" Width="110"/>
                    <GridColumn Field="@nameof(OrderData.ShipCity)" HeaderText="Ship City" Width="110" />
                    <GridColumn Field="@nameof(OrderData.ShipName)" HeaderText="Ship Name" Width="110" />
                </GridColumns>
            </SfGrid>
        </DetailTemplate>
    </GridTemplates>
    <GridColumns>
        <GridColumn Field="@nameof(EmployeeData.EmployeeID)" HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="110" />
        <GridColumn Field="@nameof(EmployeeData.FirstName)" HeaderText="First Name" Width="110" />
        <GridColumn Field="@nameof(EmployeeData.LastName)" HeaderText="Last Name" Width="110" />
        <GridColumn Field="@nameof(EmployeeData.Country)" HeaderText="Country" Width="110" />
    </GridColumns>
</SfGrid>
<style>
    .e-detail-disable .e-detailrowcollapse {
       pointer-events: none;
    }
    .e-detail-disable .e-detailrowcollapse .e-icon-grightarrow {
        visibility: hidden;
    }
</style>
@code {
    public List<EmployeeData> Employees { get; set; }
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Employees = EmployeeData.GetAllRecords();
        Orders = OrderData.GetAllRecords();
    }
    public void RowDataBound(RowDataBoundEventArgs<EmployeeData> Args) 
    {
        if (Orders.Where(x => x.EmployeeID == Args.Data.EmployeeID).ToList().Count == 0) 
        {
            Args.Row.AddClass(new string[] { "e-detail-disable" });
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="EmployeeData.cs" %}

public class EmployeeData
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Country { get; set; }

    public static List<EmployeeData> GetAllRecords()
    {
        return new List<EmployeeData>
        {
            new EmployeeData { EmployeeID = 1, FirstName = "Nancy", LastName = "Davolio", Country = "USA" },
            new EmployeeData { EmployeeID = 2, FirstName = "Andrew", LastName = "Fuller", Country = "UK" },
            new EmployeeData { EmployeeID = 3, FirstName = "Janet", LastName = "Leverling", Country = "USA" },
            new EmployeeData { EmployeeID = 4, FirstName = "Margaret", LastName = "Peacock", Country = "Canada" },
            new EmployeeData { EmployeeID = 5, FirstName = "Steven", LastName = "Buchanan", Country = "USA" },
            new EmployeeData { EmployeeID = 6, FirstName = "Michael", LastName = "Suyama", Country = "Japan" },
            new EmployeeData { EmployeeID = 7, FirstName = "Robert", LastName = "King", Country = "UK" },
            new EmployeeData { EmployeeID = 8, FirstName = "Laura", LastName = "Callahan", Country = "USA" },
            new EmployeeData { EmployeeID = 9, FirstName = "Anne", LastName = "Dodsworth", Country = "Germany" },
            new EmployeeData { EmployeeID = 10, FirstName = "Paul", LastName = "Henriot", Country = "France" },
            new EmployeeData { EmployeeID = 11, FirstName = "Thomas", LastName = "Hardy", Country = "UK" },
            new EmployeeData { EmployeeID = 12, FirstName = "Maria", LastName = "Anders", Country = "Germany" }
        };
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
    public int EmployeeID { get; set; }
    public double Freight { get; set; } 

    public static List<OrderData> GetAllRecords()
    {
        return new List<OrderData>
        {
            new OrderData { OrderID = 10248, CustomerID = "VINET", ShipCity = "Reims", ShipName = "Vins et alcools Chevalier", EmployeeID = 5, Freight = 32.38 },
            new OrderData { OrderID = 10249, CustomerID = "TOMSP", ShipCity = "Münster", ShipName = "Toms Spezialitäten", EmployeeID = 6, Freight = 11.61 },
            new OrderData { OrderID = 10250, CustomerID = "HANAR", ShipCity = "Rio de Janeiro", ShipName = "Hanari Carnes", EmployeeID = 4, Freight = 65.83 },
            new OrderData { OrderID = 10251, CustomerID = "VICTE", ShipCity = "Lyon", ShipName = "Victuailles en stock", EmployeeID = 3, Freight = 41.34 },
            new OrderData { OrderID = 10252, CustomerID = "SUPRD", ShipCity = "Charleroi", ShipName = "Suprêmes délices", EmployeeID = 2, Freight = 51.30 },
            new OrderData { OrderID = 10253, CustomerID = "HANAR", ShipCity = "Rio de Janeiro", ShipName = "Hanari Carnes", EmployeeID = 7, Freight = 58.17 },
            new OrderData { OrderID = 10254, CustomerID = "CHOPS", ShipCity = "Bern", ShipName = "Chop-suey Chinese", EmployeeID = 5, Freight = 22.98 },
            new OrderData { OrderID = 10255, CustomerID = "RICSU", ShipCity = "Genève", ShipName = "Richter Supermarkt", EmployeeID = 9, Freight = 148.33 },
            new OrderData { OrderID = 10256, CustomerID = "WELLI", ShipCity = "Resende", ShipName = "Wellington Importadora", EmployeeID = 3, Freight = 13.97 },
            new OrderData { OrderID = 10257, CustomerID = "HILAA", ShipCity = "San Cristóbal", ShipName = "HILARION-Abastos", EmployeeID = 4, Freight = 81.91 },
            new OrderData { OrderID = 10258, CustomerID = "ERNSH", ShipCity = "Graz", ShipName = "Ernst Handel", EmployeeID = 4, Freight = 140.51 },
            new OrderData { OrderID = 10259, CustomerID = "CENTC", ShipCity = "México D.F.", ShipName = "Centro comercial Moctezuma", EmployeeID = 4, Freight = 3.25 },
            new OrderData { OrderID = 10260, CustomerID = "OTTIK", ShipCity = "Köln", ShipName = "Ottilies Käseladen", EmployeeID = 3, Freight = 55.09 },
            new OrderData { OrderID = 10261, CustomerID = "QUEDE", ShipCity = "Rio de Janeiro", ShipName = "Que Delícia", EmployeeID = 4, Freight = 3.05 },
            new OrderData { OrderID = 10262, CustomerID = "RATTC", ShipCity = "Albuquerque", ShipName = "Rattlesnake Canyon Grocery", EmployeeID = 8, Freight = 48.29 },
            new OrderData { OrderID = 10263, CustomerID = "ERNSH", ShipCity = "Graz", ShipName = "Ernst Handel", EmployeeID = 9, Freight = 76.13 },
            new OrderData { OrderID = 10264, CustomerID = "FOLKO", ShipCity = "Bräcke", ShipName = "Folk och fä HB", EmployeeID = 6, Freight = 3.67 },
            new OrderData { OrderID = 10265, CustomerID = "BLONP", ShipCity = "Strasbourg", ShipName = "Blondel père et fils", EmployeeID = 2, Freight = 55.28 },
            new OrderData { OrderID = 10266, CustomerID = "WARTH", ShipCity = "Stavern", ShipName = "Wartian Herkku", EmployeeID = 3, Freight = 25.73 },
            new OrderData { OrderID = 10267, CustomerID = "FRANK", ShipCity = "München", ShipName = "Frankenversand", EmployeeID = 4, Freight = 208.58 }
        };
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtryXzhVUTHNobav?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Render aggregates in detail DataGrid

The Aggregates feature in the Syncfusion Blazor DataGrid allows you to display aggregate values in the footer, group footer, and group caption of the detail Grid. With this feature, you can easily perform calculations on specific columns and show summary information.

Rendering aggregates in a detail Grid involves displaying summary data at the footer or group caption of the Grid. This can be particularly useful in detail Grids where each detail Grid represents detailed data that needs to be summarized.

The following example demonstrates how to render aggregates in a detail Grid to display the sum and maximum values of the **Freight** column.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data

<SfGrid @ref="parentGrid" DataSource="@Employees" Height="300px">
    <GridTemplates>
        <DetailTemplate>
          @{
                var employee = (context as EmployeeData);
            }
            <SfGrid DataSource="@Orders" Query="@(new Query().Where("EmployeeID", "equal", employee.EmployeeID))">
                <GridAggregates>
                    <GridAggregate>
                        <GridAggregateColumns>
                            <GridAggregateColumn Field="@nameof(OrderData.Freight)" Format='C2' Type="AggregateType.Sum">
                                <FooterTemplate Context="footerContext">
                                    @{
                                        var aggregate = (footerContext as AggregateTemplateContext);
                                    }
                                    <div>
                                        Sum: @aggregate.Sum
                                    </div>
                                </FooterTemplate>
                            </GridAggregateColumn>
                        </GridAggregateColumns>
                    </GridAggregate>
                    <GridAggregate>
                        <GridAggregateColumns>
                            <GridAggregateColumn Field="@nameof(OrderData.Freight)" Format='C2' Type="AggregateType.Max">
                                <FooterTemplate Context="footerContext">
                                    @{
                                        var aggregate = (footerContext as AggregateTemplateContext);
                                    }
                                    <div>
                                        Max: @aggregate.Max
                                    </div>
                                </FooterTemplate>
                            </GridAggregateColumn>
                        </GridAggregateColumns>
                    </GridAggregate>
                </GridAggregates>
                <GridColumns>
                    <GridColumn Field="@nameof(OrderData.OrderID)" HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100" />
                    <GridColumn Field="@nameof(OrderData.CustomerID)" HeaderText="Customer ID" Width="120" />
                    <GridColumn Field="@nameof(OrderData.Freight)" HeaderText="Freight" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Format="C2" Width="100" />
                    <GridColumn Field="@nameof(OrderData.ShipCity)" HeaderText="Ship City" Width="120" />
                    <GridColumn Field="@nameof(OrderData.ShipName)" HeaderText="Ship Name" Width="150" />
                </GridColumns>
            </SfGrid>
        </DetailTemplate>
    </GridTemplates>
    <GridColumns>
        <GridColumn Field="@nameof(EmployeeData.EmployeeID)" HeaderText="Employee ID" IsPrimaryKey="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120" />
        <GridColumn Field="@nameof(EmployeeData.FirstName)" HeaderText="First Name" Width="150" />
        <GridColumn Field="@nameof(EmployeeData.LastName)" HeaderText="Last Name" Width="150" />
        <GridColumn Field="@nameof(EmployeeData.Country)" HeaderText="Country" Width="120" />
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<EmployeeData> parentGrid;
    public List<EmployeeData> Employees { get; set; }
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Employees = EmployeeData.GetAllRecords();
        Orders = OrderData.GetAllRecords();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="EmployeeData.cs" %}

public class EmployeeData
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Country { get; set; }

    public static List<EmployeeData> GetAllRecords()
    {
        return new List<EmployeeData>
        {
            new EmployeeData { EmployeeID = 1, FirstName = "Nancy", LastName = "Davolio", Country = "USA" },
            new EmployeeData { EmployeeID = 2, FirstName = "Andrew", LastName = "Fuller", Country = "UK" },
            new EmployeeData { EmployeeID = 3, FirstName = "Janet", LastName = "Leverling", Country = "USA" },
            new EmployeeData { EmployeeID = 4, FirstName = "Margaret", LastName = "Peacock", Country = "Canada" },
            new EmployeeData { EmployeeID = 5, FirstName = "Steven", LastName = "Buchanan", Country = "USA" },
            new EmployeeData { EmployeeID = 6, FirstName = "Michael", LastName = "Suyama", Country = "Japan" },
            new EmployeeData { EmployeeID = 7, FirstName = "Robert", LastName = "King", Country = "UK" },
            new EmployeeData { EmployeeID = 8, FirstName = "Laura", LastName = "Callahan", Country = "USA" },
            new EmployeeData { EmployeeID = 9, FirstName = "Anne", LastName = "Dodsworth", Country = "Germany" },
            new EmployeeData { EmployeeID = 10, FirstName = "Paul", LastName = "Henriot", Country = "France" },
            new EmployeeData { EmployeeID = 11, FirstName = "Thomas", LastName = "Hardy", Country = "UK" },
            new EmployeeData { EmployeeID = 12, FirstName = "Maria", LastName = "Anders", Country = "Germany" }
        };
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
    public int EmployeeID { get; set; }
    public double Freight { get; set; } 

    public static List<OrderData> GetAllRecords()
    {
        return new List<OrderData>
        {
            new OrderData { OrderID = 10248, CustomerID = "VINET", ShipCity = "Reims", ShipName = "Vins et alcools Chevalier", EmployeeID = 5, Freight = 32.38 },
            new OrderData { OrderID = 10249, CustomerID = "TOMSP", ShipCity = "Münster", ShipName = "Toms Spezialitäten", EmployeeID = 6, Freight = 11.61 },
            new OrderData { OrderID = 10250, CustomerID = "HANAR", ShipCity = "Rio de Janeiro", ShipName = "Hanari Carnes", EmployeeID = 4, Freight = 65.83 },
            new OrderData { OrderID = 10251, CustomerID = "VICTE", ShipCity = "Lyon", ShipName = "Victuailles en stock", EmployeeID = 3, Freight = 41.34 },
            new OrderData { OrderID = 10252, CustomerID = "SUPRD", ShipCity = "Charleroi", ShipName = "Suprêmes délices", EmployeeID = 2, Freight = 51.30 },
            new OrderData { OrderID = 10253, CustomerID = "HANAR", ShipCity = "Rio de Janeiro", ShipName = "Hanari Carnes", EmployeeID = 7, Freight = 58.17 },
            new OrderData { OrderID = 10254, CustomerID = "CHOPS", ShipCity = "Bern", ShipName = "Chop-suey Chinese", EmployeeID = 5, Freight = 22.98 },
            new OrderData { OrderID = 10255, CustomerID = "RICSU", ShipCity = "Genève", ShipName = "Richter Supermarkt", EmployeeID = 9, Freight = 148.33 },
            new OrderData { OrderID = 10256, CustomerID = "WELLI", ShipCity = "Resende", ShipName = "Wellington Importadora", EmployeeID = 3, Freight = 13.97 },
            new OrderData { OrderID = 10257, CustomerID = "HILAA", ShipCity = "San Cristóbal", ShipName = "HILARION-Abastos", EmployeeID = 4, Freight = 81.91 },
            new OrderData { OrderID = 10258, CustomerID = "ERNSH", ShipCity = "Graz", ShipName = "Ernst Handel", EmployeeID = 1, Freight = 140.51 },
            new OrderData { OrderID = 10259, CustomerID = "CENTC", ShipCity = "México D.F.", ShipName = "Centro comercial Moctezuma", EmployeeID = 4, Freight = 3.25 },
            new OrderData { OrderID = 10260, CustomerID = "OTTIK", ShipCity = "Köln", ShipName = "Ottilies Käseladen", EmployeeID = 1, Freight = 55.09 },
            new OrderData { OrderID = 10261, CustomerID = "QUEDE", ShipCity = "Rio de Janeiro", ShipName = "Que Delícia", EmployeeID = 4, Freight = 3.05 },
            new OrderData { OrderID = 10262, CustomerID = "RATTC", ShipCity = "Albuquerque", ShipName = "Rattlesnake Canyon Grocery", EmployeeID = 8, Freight = 48.29 },
            new OrderData { OrderID = 10263, CustomerID = "ERNSH", ShipCity = "Graz", ShipName = "Ernst Handel", EmployeeID = 9, Freight = 76.13 },
            new OrderData { OrderID = 10264, CustomerID = "FOLKO", ShipCity = "Bräcke", ShipName = "Folk och fä HB", EmployeeID = 6, Freight = 3.67 },
            new OrderData { OrderID = 10265, CustomerID = "BLONP", ShipCity = "Strasbourg", ShipName = "Blondel père et fils", EmployeeID = 2, Freight = 55.28 },
            new OrderData { OrderID = 10266, CustomerID = "WARTH", ShipCity = "Stavern", ShipName = "Wartian Herkku", EmployeeID = 3, Freight = 25.73 },
            new OrderData { OrderID = 10267, CustomerID = "FRANK", ShipCity = "München", ShipName = "Frankenversand", EmployeeID = 4, Freight = 208.58 }

        };
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDLSXTVBKnztlkUQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize the detail Blazor DataGrid

The Syncfusion Blazor DataGrid offers various ways to customize the detail Grid appearance using both default CSS and custom themes. To access the detail Grid elements, you can use the **.e-detailcell** class selector, which targets the detail Grid.

### Header

You can customize the appearance of the header elements in the detail Grid using CSS. Here are examples of how to customize the detail Grid header, header cell, and header cell div element.

**Customizing the detail Grid header**

To customize the appearance of the detail Grid header root element, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-headercontent{
    border: 2px solid green;
}
```
In this example, the **.e-detailcell** class targets the detail Grid and **.e-headercontent** targets its header root element. You can modify the `border` property to change the style of the header border. This customization allows you to override the thin line between the header and content of the detail Grid.

![detail header Grid in Blazor.](images/hierarchy-grid/grid-child-header.png)

**Customizing the detail Grid header cell**

To customize the appearance of the Grid header cell elements, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-headercontent .e-headercell{
    color: #ffffff;
    background-color: #1ea8bd;
}
```
In this example, the **.e-headercell** class targets the header cell elements. You can modify the `color` and `background-color` properties to change the text color and background of the detail Grid's header cells.

![Customize the detail Grid header cell in Blazor.](images/hierarchy-grid/grid-child-header-cell.png)

**Customizing the detail Grid header cell div element**

To customize the appearance of the detail Grid header cell div element, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-headercelldiv {
    font-size: 15px;
    font-weight: bold;
    color: darkblue;
}
```
In this example, the **.e-headercelldiv** class targets the div element within the header cell of the detail Grid. You can modify the `font-size`, `font-weight`, `color` properties to change the font size, font-weight and color of the header text content.

![detail Grid header cell div element in Blazor.](images/hierarchy-grid/grid-child-header-cell-div-element.png)

### Paging

You can customize the appearance of the paging elements in the detail Grid using CSS. Here are examples of how to customize the pager root element, pager container element, pager navigation elements, pager page numeric link elements, and pager current page numeric element of the detail Grid.

**Customizing the detail Grid pager root element**

To customize the appearance of the detail Grid pager root element, you can use the following CSS code:

```css
.e-detailcell .e-grid  .e-gridpager {
    font-family: cursive;
    background-color: #deecf9;
}
```
In this example, the **.e-detailcell** class targets the detail Grid and the **.e-gridpager** class targets the pager root element. You can modify the `font-family` to change the font family and `background-color` property to change the background color of the pager.

![Blazor Grid pager root element.](images/hierarchy-grid/child-grid-pager-root-element.png)

**Customizing the detail Grid pager container element**

To customize the appearance of the detail Grid pager container element, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-pagercontainer {
    border: 2px solid #00b5ff;
    font-family: cursive;
}
```

In this example, the **.e-pagercontainer** class targets the pager container element. You can modify the `border` and `font-family` property to change the border color and font family of the pager container.

![Blazor Grid pager container element.](images/hierarchy-grid/grid-child-pager-container-element.png)

**Customizing the detail Grid pager navigation elements**

To customize the appearance of the detail Grid pager navigation elements, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-gridpager .e-prevpagedisabled,
.e-detailcell .e-grid .e-gridpager .e-prevpage,
.e-detailcell .e-grid .e-gridpager .e-nextpage,
.e-detailcell .e-grid .e-gridpager .e-nextpagedisabled,
.e-detailcell .e-grid .e-gridpager .e-lastpagedisabled,
.e-detailcell .e-grid .e-gridpager .e-lastpage,
.e-detailcell .e-grid .e-gridpager .e-firstpage,
.e-detailcell .e-grid .e-gridpager .e-firstpagedisabled {
    background-color: #deecf9;
}
```

In this example, the classes **.e-prevpagedisabled, .e-prevpage, .e-nextpage, .e-nextpagedisabled, .e-lastpagedisabled, .e-lastpage, .e-firstpage,** and **.e-firstpagedisabled** target the various pager navigation elements of the detail Grid. You can modify the `background-color` property to change the background color of these elements.

![Blazor Grid pager navigation elements.](images/hierarchy-grid/grid-child-pager-navigation-element.png)

**Customizing the detail Grid pager page numeric link elements**

To customize the appearance of the detail Grid pager current page numeric link elements, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-gridpager .e-numericitem {
    background-color: #5290cb;
    color: #ffffff;
    cursor: pointer;
}

.e-detailcell .e-grid .e-gridpager .e-numericitem:hover {
    background-color: white;
    color: #007bff;
}
```

In this example, the **.e-numericitem** class targets the page numeric link elements. You can modify the `background-color`, `color` properties to change the background color and text color of these elements.

![Blazor Grid pager numeric link elements.](images/hierarchy-grid/grid-child-page-numeric-link-elements.png)

**Customizing the detail Grid pager current page numeric element**

To customize the appearance of the detail Grid pager current page numeric element, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-gridpager .e-currentitem {
    background-color: #0078d7;
    color: #fff;
}
```

In this example, the **.e-currentitem** class targets the current page numeric item. You can modify the `background-color` property to change the background color of this element and `color` property to change the text color.

![Blazor Grid current pager numeric element.](images/hierarchy-grid/grid-child-current-page-numeric-element.png)

### Sorting

You can customize the appearance of the sorting icons and multi sorting icons in the detail Grid using CSS.You can use the available Syncfusion [icons](https://blazor.syncfusion.com/documentation/appearance/icons#bootstrap-5) based on your theme. Here's how to do it:

**Customizing the detail Grid sorting icon**

To customize the sorting icon that appears in the detail Grid header when sorting is applied, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-icon-ascending::before {
    content: '\e7a3';
    /* Icon code for ascending order */
}

.e-detailcell .e-grid .e-icon-descending::before {
    content: '\e7b6';
    /* Icon code for descending order */
}
```
In this example, the **.e-detailcell** class targets the detail Grid and the **.e-icon-ascending::before** class targets the sorting icon for ascending order, and the **.e-icon-descending::before** class targets the sorting icon for descending order.

![Blazor Grid sorting icon.](images/hierarchy-grid/grid-child-sorting-icons.png)

**Customizing the detail Grid multi sorting icon**

To customize the multi sorting icon that appears in the detail Grid header when multiple columns are sorted, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-sortnumber {
    background-color: #deecf9;
    font-family: cursive;
}
```

In this example, the **.e-sortnumber** class targets the background color and font family of the multi sorting icon. You can modify the `background-color` and `font-family` properties to customize the appearance of the multi sorting icon.

![Blazor Grid multi sorting icon.](images/hierarchy-grid/grid-child-multi-sorting-icon.png)

### Filtering

You can customize the appearance of filtering elements in the detail Grid using CSS. Below are examples of how to customize various filtering elements, including filter bar cell elements, filter bar input elements, focus styles, clear icons, filter icons, filter dialog content, filter dialog footer, filter dialog input elements, filter dialog button elements, and Excel filter dialog number filters.

**Customizing the detail Grid filter bar cell element**

To customize the appearance of the filter bar cell element in the detail Grid header, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-filterbar .e-filterbarcell {
  background-color: #045fb4;
}

```
In this example, the **.e-detailcell** class targets the detail Grid and the **.e-filterbarcell** class targets the filter bar cell element in the detail Grid header. You can modify the `background-color` property to change the color of the filter bar cell element.

![Blazor Grid filter bar cell element.](images/hierarchy-grid/grid-child-filter-bar-cell-element.png)

**Customizing the detail Grid filter bar input element**

To customize the appearance of the filter bar input element in the detail Grid header, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-filterbarcell .e-input-group input.e-input{
    font-family: cursive;
}
```
In this example, the **.e-filterbarcell** class targets the filter bar cell element, and the **.e-input** class targets the input element within the cell. You can modify the `font-family` property to change the font of the filter bar input element.

![Blazor Grid filter bar input element.](images/hierarchy-grid/grid-child-filter-bar-input-element.png)

**Customizing the detail Grid filter bar input focus**

To customize the appearance of the detail Grid's filter bar input element's focus highlight, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-filterbarcell .e-input-group.e-input-focus{
    background-color: #deecf9;
}
```
In this example, the **.e-filterbarcell** class targets the filter bar cell element, and the **.e-input-group.e-input-focus** class targets the focused input element. You can modify the `background-color` property to change the color of the focus highlight.

![Blazor Grid filter bar input focus.](images/hierarchy-grid/grid-child-filter-bar-input-element-focus.png)

**Customizing the detail Grid filter bar input clear icon**

To customize the appearance of the detail Grid's filter bar input element's clear icon, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-filterbarcell .e-input-group .e-clear-icon::before {
    content: '\e72c';
}
```
In this example, the **.e-clear-icon** class targets the clear icon element within the input group. You can modify the `content` property to change the icon displayed.

![Blazor Grid filter bar input clear icon.](images/hierarchy-grid/child-grid-filter-bar-input-clear-icon.png)

**Customizing the detail Grid filtering icon**

To customize the appearance of the filtering icon in the detail Grid header, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-icon-filter::before{
    content: '\e81e';
}
```
In this example, the **.e-icon-filter** class targets the filtering icon element. You can modify the `content` property to change the icon displayed.

![Blazor Grid filtering icon.](images/hierarchy-grid/grid-child-filtering-icon.png)

**Customizing the detail Grid filter dialog content**

To customize the appearance of the detail Grid's filter dialog's content element, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-filter-popup .e-dlg-content {
    background-color: #deecf9;
}
```
In this example, the **.e-filter-popup .e-dlg-content** classes target the content element within the filter dialog. You can modify the `background-color` property to change the color of the dialog's content.

![Blazor Grid filter dialog content.](images/hierarchy-grid/grid-child-filter-dialog-content.png)

**Customizing the detail Grid filter dialog footer**

To customize the appearance of the detail Grid's filter dialog's footer element, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-filter-popup .e-footer-content {
    background-color: #deecf9;
}
```
In this example, the **.e-filter-popup .e-footer-content** classes target the footer element within the filter dialog. You can modify the `background-color` property to change the color of the dialog's footer.

![Blazor Grid filter dialog footer.](images/hierarchy-grid/child-grid-filter-dialog-footer.png)

**Customizing the detail Grid filter dialog input element**

To customize the appearance of the detail Grid's filter dialog's input elements, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-filter-popup .e-input-group input.e-input{
    font-family: cursive;
}
```
In this example, the **.e-filter-popup** class targets the filter dialog, and the **.e-input** class targets the input elements within the dialog. You can modify the `font-family` property to change the font of the input elements.

![Blazor Grid filter dialog input element.](images/hierarchy-grid/grid-child-filter-dialog-input-element.png)

**Customizing the detail Grid filter dialog button element**

To customize the appearance of the detail Grid's filter dialog's button elements, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-filter-popup .e-btn{
    font-family: cursive;
}
```
In this example, the **.e-filter-popup** class targets the filter dialog, and the **.e-btn** class targets the button elements within the dialog. You can modify the `font-family` property to change the font of the button elements.

![Blazor Grid filter dialog button element.](images/hierarchy-grid/grid-child-filter-dialog-button-element.png)

**Customizing the detail Grid Excel filter dialog number filters element**

To customize the appearance of the Excel filter dialog's number filters in the detail Grid, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-filter-popup .e-contextmenu {
    background-color: #deecf9;
}
```
In this example, the **.e-filter-popup .e-contextmenu** classes target the number filter elements within the Excel filter dialog. You can modify the `background-color` property to change the color of these elements.

![Blazor Grid Excel filter dialog number filters element.](images/hierarchy-grid/grid-child-excel-filter-dialog-element.png)

### Grouping

You can customize the appearance of grouping elements in the detail Grid using CSS. Here are examples of how to customize the group header, group expand/collapse icons, group caption row, and grouping indent cell.

**Customizing the detail Grid group header**

To customize the appearance of the detail Grid's group header element, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-groupdroparea {
    background-color: #132f49;
}
```
In this example, the **.e-detailcell** class targets the detail Grid and the **.e-groupdroparea** class targets the group header element. You can modify the `background-color` property to change the color of the group header.

![detail Grid group header in Blazor.](images/hierarchy-grid/grid-child-group-header.png)

**Customizing the detail Grid group expand or collapse icons**

To customize the appearance of the group expand/collapse icons in the detail Grid, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-icon-gdownarrow::before{
    content:'\e7c9'
}
.e-detailcell .e-grid .e-icon-grightarrow::before{
    content:'\e80f'
}
```

In this example, the **.e-icon-gdownarrow** and **.e-icon-grightarrow** classes target the expand and collapse icons, respectively. You can modify the `content` property to change the icon displayed. You can use the available [Syncfusion icons](https://blazor.syncfusion.com/documentation/appearance/icons) based on your theme.

![detail Grid group expand or collapse icons in Blazor.](images/hierarchy-grid/grid-child-group-expand-or-collapse-icons.png)

**Customizing the detail Grid group caption row**

To customize the appearance of the detail Grid's group caption row and the icons indicating record expansion or collapse, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-groupcaption {
    background-color: #deecf9;
}

.e-detailcell .e-grid .e-recordplusexpand,
.e-detailcell .e-grid .e-recordpluscollapse {
    background-color: #deecf9;
}
```

In this example, the **.e-groupcaption** class targets the group caption row element, and the **.e-recordplusexpand** and **.e-recordpluscollapse** classes target the icons indicating record expansion or collapse. You can modify the `background-color` property to change the color of these elements.

![detail Grid group caption row in Blazor.](images/hierarchy-grid/child-grid-group-caption-row.png)

**Customizing the detail Grid grouping indent cell**

To customize the appearance of the detail Grid's grouping indent cell element, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-indentcell {
    background-color: #deecf9;
}
```

In this example, the **.e-indentcell** class targets the grouping indent cell element. You can modify the `background-color` property to change the color of the indent cell.

![detail Grid grouping indent cell in Blazor.](images/hierarchy-grid/child-grid-indent-cell.png)

### Toolbar

You can customize the appearance of the toolbar in the detail Grid using CSS. Here are examples of how to customize the toolbar root element and toolbar button element.

**Customizing the detail Grid toolbar root element**

To customize the appearance of the detail Grid's toolbar root element, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-toolbar-items {
    background-color: #deecf9;
}
```

In this example, the **.e-detailcell** class targets the detail Grid and the **.e-toolbar-items** class targets the background color of the toolbar root element. You can modify the `background-color` property to change the background color of the toolbar.

![detail Grid toolbar root element in Blazor.](images/hierarchy-grid/child-grid-toolbar-root-element.png)

**Customizing the detail Grid toolbar button element**

To customize the appearance of the detail Grid's toolbar buttons, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-toolbar .e-btn {
    background-color: #deecf9;
}
```

In this example, the **.e-toolbar .e-btn** selector targets the background color of the toolbar button elements. You can modify the `background-color` property to change the background color of the toolbar buttons.

![detail Grid toolbar button element in Blazor.](images/hierarchy-grid/child-grid-toolbar-button-element.png)

### Editing

You can customize the appearance of editing-related elements in the detail Grid using CSS. Below are examples of how to customize various editing-related elements.

**Customizing the detail Grid edited and added row element**

To customize the appearance of edited and added row table elements in the detail Grid, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-editedrow table, 
.e-detailcell .e-grid .e-addedrow table {
	background-color: #62b2eb;
}
```
In this example, the **.e-detailcell** class targets the detail Grid and the .**e-editedrow** class represents the edited row element, and the **.e-addedrow** class represents the added row element. You can modify the `background-color` property to change the color of these row table elements.

![detail Grid customizing the edited row element in Blazor.](images/hierarchy-grid/child-grid-edited-row-element.png)
![detail Grid customizing the added row element in Blazor.](images/hierarchy-grid/child-grid-added-row-element.png)

**Customizing the detail Grid edited row input element**

To customize the appearance of edited row input elements in the detail Grid, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-editedrow .e-input-group input.e-input{
  font-family: cursive;
  color:rgb(214, 33, 123)
}
```
In this example, the **.e-editedrow** class represents the edited row element, and the **.e-input** class represents the input elements within the form. You can modify the `font-family` property to change the font and `color` property  to change text color of the input elements.

![detail Grid customizing the edited row input element in Blazor.](images/hierarchy-grid/child-grid-edited-row-input-element.png)

**Customizing the detail Grid edit dialog header element**

To customize the appearance of the edit dialog header element in the detail Grid, you can use the following CSS code:

```css
.e-edit-dialog .e-dlg-header-content {
    background-color: #deecf9;
}
```
In this example, the **.e-edit-dialog** class represents the edit dialog, and the **.e-dlg-header-content** class targets the header content within the dialog. You can modify the `background-color` property to change the color of the header element.

![detail Grid customizing the edit dialog header element in Blazor.](images/hierarchy-grid/child-grid-edit-dialog-header-element.png)

**Customizing the detail Grid command column buttons**

To customize the appearance of the detail Grid's command column buttons such as edit, delete, update, and cancel, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-delete::before ,.e-grid .e-cancel-icon::before{
    color: #f51717;
}
.e-detailcell .e-grid .e-edit::before, .e-grid .e-update::before {
    color: #077005;
}
```
In this example, the **.e-edit, .e-delete, .e-update, and .e-cancel-icon** classes represent the respective command column buttons. You can modify the `color` property to change the color of these buttons.

![detail Grid customize command column button in Blazor.](images/hierarchy-grid/child-grid-command-button.png)
![detail Grid customize command column button in Blazor.](images/hierarchy-grid/child-grid-next-command-button.png)

### Aggregate

You can customize the appearance of aggregate elements in the detail Grid using CSS. Below are examples of how to customize the aggregate root element and the aggregate cell elements.

**Customizing the detail Grid aggregate root element**

To customize the appearance of the detail Grid's aggregate root elements, you can use the following CSS code:

```css
.e-detailcell .e-grid .e-gridfooter {
    font-family: cursive;
}
```

In this example, the **.e-detailcell** class targets the detail Grid and the **e-gridfooter** class represents the root element of the aggregate row in the grid footer. You can modify the `font-family` property to change the font of the aggregate root element.

![detail Grid customize aggregate root element in Blazor.](images/hierarchy-grid/child-grid-aggregate-root-element.png)

**Customizing the detail Grid aggregate cell elements**

To customize the appearance of the detail Grid's aggregate cell elements (summary row cell elements), you can use the following CSS code:

```css
.e-detailcell .e-grid .e-summaryrow .e-summarycell {
    background-color: #deecf9;
}
```

In this example, the **e-summaryrow** class represents the summary row containing aggregate cells, and the **e-summarycell** class targets individual aggregate cells within the summary row. You can modify the `background-color` property to change the `color` of the aggregate cell elements.

![detail Grid customize aggregate cell element in Blazor.](images/hierarchy-grid/child-grid-aggregate-cell-element.png)

### Selection

You can customize the appearance of the selection in the detail Grid using CSS. Here are examples of how to customize the row selection background, cell selection background, and column selection background.

**Customizing the detail Grid row selection background**

To customize the appearance of the detail Grid's row selection, you can use the following CSS code:

```css
.e-detailcell .e-grid td.e-selectionbackground {
    background-color: #00b7ea;
}
```
In this example, the **.e-detailcell** class targets the detail Grid and the **.e-selectionbackground** class targets the background color of the row selection. You can modify the `background-color` property to change the background color of the selected rows.

![detail Grid row selection in Blazor.](images/hierarchy-grid/child-grid-row-selection.png)

**Customizing the detail Grid cell selection background**

To customize the appearance of the detail Grid's cell selection, you can use the following CSS code:

```css
.e-detailcell .e-grid td.e-cellselectionbackground {
    background-color: #00b7ea;
}
```

In this example, the **.e-cellselectionbackground** class targets the background color of the cell selection. You can modify the `background-color` property to change the background color of the selected cells.

![detail Grid cell selection in Blazor.](images/hierarchy-grid/child-grid-cell-selection.png)

## Limitations

Detail template is not supported with the following features:

* Frozen rows and columns
* Immutable mode
* Infinite scrolling
* Virtual scrolling
* Print
* Row template
* Row spanning
* Column spanning
* Lazy load grouping
* State persistence