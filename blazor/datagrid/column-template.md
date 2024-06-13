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

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders">
    <GridColumns>
    <GridColumn HeaderText="Employee Image" TextAlign="TextAlign.Center" Width="120">
            <Template>
                @{
                    var employee = (context as OrderData);
                        <div class="image">
                            <img src="@($"scripts/Images/Employees/{employee.EmployeeID}.png")" alt="@employee.EmployeeID" />
                        </div>
                }
            </Template>
        </GridColumn>
        <GridColumn Field=@nameof(OrderData.FirstName) HeaderText="First Name" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.LastName) HeaderText="Last Name" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.City) HeaderText="City" Width="120"></GridColumn>
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
    public List<OrderData> Orders { get; set; }
    
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
    public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData()
        {

        }
        public OrderData(int EmployeeID, string FirstName, string LastName, string City,DateTime? HireDate)
        {
           this.EmployeeID = EmployeeID;
           this.FirstName = FirstName;
           this.LastName = LastName;
           this.City = City;
           this.HireDate = HireDate;            
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "Nancy", "Davolio", "Seattle", new DateTime(1996,07,08)));
                    Orders.Add(new OrderData(10249, "Andrew", "Fuller", "Tacoma", new DateTime(1996, 07, 18)));
                    Orders.Add(new OrderData(10250, "Janet", "Leverling", "Kirkland", new DateTime(1996, 07, 05)));
                    Orders.Add(new OrderData(10251, "Margaret", "Peacock", "Redmond", new DateTime(1996, 07, 23)));
                    Orders.Add(new OrderData(10252, "Steven", "Buchanan", "London", new DateTime(1996, 07, 16)));
                    Orders.Add(new OrderData(10253, "Michael", "Suyama", "London", new DateTime(1996, 07, 12)));
                    Orders.Add(new OrderData(10254, "Robert", "King", "London", new DateTime(1996, 07, 18)));
                    Orders.Add(new OrderData(10255, "Anne", "Callahan", "London", new DateTime(1996, 07, 05)));
                    Orders.Add(new OrderData(10256, "Laura", "Dodsworth", "London", new DateTime(1996, 07, 01)));
                    code += 5;
                }
            }
            return Orders;
        }
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public DateTime? HireDate { get; set; }
    }
{% endhighlight %}
{% endtabs %}

<!-- {% previewsample "https://blazorplayground.syncfusion.com/embed/VZhAMiNMBnKKvMuz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} -->

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

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using BlazorApp1.Data

<SfGrid DataSource="@Orders">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) TextAlign="TextAlign.Right" HeaderText="Employee ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderStatus) HeaderText="Order Status" TextAlign="TextAlign.Right" Width="150">
            <Template>
                <SfDropDownList TValue="string" Placeholder="Order Placed" PopupWidth="150" PopupHeight="150" TItem="EmployeeNames" DataSource="@EmployeeDetails">
                    <DropDownListFieldSettings Value="Status"></DropDownListFieldSettings>
                </SfDropDownList>
            </Template>
        </GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderData> Orders { get; set; }
    public List<EmployeeNames> EmployeeDetails { get; set; }
    
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();

        EmployeeDetails = Enumerable.Range(1, 3).Select(x => new EmployeeNames()
            {
                Id = x,
                Status = (new string[] { "Order Placed", "Processing", "Delivered" })[new Random().Next(3)]
            }).ToList();
    }
    public class EmployeeNames
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData()
        {

        }
        public OrderData(int? OrderID, string CustomerID, double Freight, string Title, string OrderStatus)
        {
           this.OrderID = OrderID;
           this.CustomerID = CustomerID;
           this.Freight = Freight;
           this.Title = Title;
           this.OrderStatus = OrderStatus;            
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "Nancy",32.14, "Sales Representative", "Order Placed"));
                    Orders.Add(new OrderData(10249, "Andrew", 33.33, "Vice President, Sales", "Processing"));
                    Orders.Add(new OrderData(10250, "Janet", 56.78, "Sales Manager", "Delivered"));
                    Orders.Add(new OrderData(10251, "Margaret",43.34, "Inside Sales Coordinator", "Delivered"));
                    Orders.Add(new OrderData(10252, "Steven", 17.98, "Sales Manager", "Delivered"));
                    Orders.Add(new OrderData(10253, "Michael", 53.33, "Sales Representative", "Processing"));
                    Orders.Add(new OrderData(10254, "Robert", 78.99, "Vice President, Sales", "Delivered"));
                    Orders.Add(new OrderData(10255, "Anne", 46.66, "Inside Sales Coordinator", "Order Placed"));
                    Orders.Add(new OrderData(10256, "Laura", 98.76, "Sales Manager", "Delivered"));
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
        public string Title { get; set; }
        public string OrderStatus { get; set; }
    }  
{% endhighlight %}
{% endtabs %}


{% previewsample "https://blazorplayground.syncfusion.com/embed/hjhKiMZsUppLpTZe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Using condition template

The conditional column [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) allows you to display template elements based on specific conditions.


In the following code, checkbox is rendered based on **Discontinued** field value in the datasource. This data can be accessed inside the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) using the implicit named parameter **context**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders">
    <GridColumns>
        <GridColumn HeaderText="Discontinued" TextAlign="TextAlign.Center" Width="120">
            <Template>
                @{
                    var employee = (context as OrderData);
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
        <GridColumn Field=@nameof(OrderData.ProductID) TextAlign="TextAlign.Center" HeaderText="Employee ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CategoryName) HeaderText="Category Name" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ProductName) HeaderText="Product Name" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderData> Orders { get; set; }     
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();      
    }  
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
    public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData()
        {

        }
        public OrderData(int? ProductID, string CategoryName, string ProductName, bool Discontinued)
        {
           this.ProductID = ProductID;
           this.CategoryName = CategoryName;
           this.ProductName = ProductName;
           this.Discontinued = Discontinued;            
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(1, "Beverages", "Chai", true));
                    Orders.Add(new OrderData(2, "Beverages", "Chang", true));
                    Orders.Add(new OrderData(3, "Beverages", "Aniseed Syrup", false));
                    Orders.Add(new OrderData(4, "Beverages", "Mishi Kobe Niku",false));
                    Orders.Add(new OrderData(5, "Beverages", "Chai", true));
                    Orders.Add(new OrderData(6, "Beverages", "Aniseed Syrup", true));
                    Orders.Add(new OrderData(7, "Beverages", "Chai", false));
                    Orders.Add(new OrderData(8, "Beverages", "Mishi Kobe Niku", true));
                    Orders.Add(new OrderData(9, "Beverages", "Aniseed Syrup", true));
                    code += 5;
                }
            }
            return Orders;
        }
        public int? ProductID { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public Boolean Discontinued { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNrKWsDsASInUbPD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Using hyperlink column and performing routing on click

The Column template property can be used to provide routing links inside the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) property of the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html). For routing, [UriHelper](https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/routing?view=aspnetcore-7.0&viewFallbackFrom=aspnetcore-3.0#uri-and-navigation-state-helpers) can be utilized.

This can be achieved by initially defining an anchor tag inside the column template and binding click event to it. In this event, the DataGrid data **context** is passed on to its function.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@inject NavigationManager UriHelper
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.EmployeeID) TextAlign="TextAlign.Center" HeaderText="Employee ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Name) HeaderText="First Name" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Title) HeaderText="Title" Width="120"></GridColumn>
        <GridColumn HeaderText="User profile" TextAlign="TextAlign.Center" Width="120">
            <Template>
                @{
                    var Employee = (context as OrderData);
                    <div><a href="#" @onclick="@(() => Navigate(Employee))">View</a></div>
                }
            </Template>
        </GridColumn>
    </GridColumns>
</SfGrid>


@code {
    public List<OrderData> Orders { get; set; }
     
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
      
    }
    private void Navigate(OrderData Orders)
    {
        UriHelper.NavigateTo($"{Orders.Link}/{Orders.EmployeeID.ToString()}/{Orders.Name}/{Orders.Title}");
    }

}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
   public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData()
        {

        }
        public OrderData(int EmployeeID, string Name, string Title, string Link)
        {
           this.EmployeeID = EmployeeID;
           this.Name = Name;
           this.Title = Title;
           this.Link = Link;            
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(1, "Nancy Fuller", "Vice President", "nancy_fuller"));
                    Orders.Add(new OrderData(2, "Steven Buchanan", "Sales Manager", "steven_buchanan"));
                    Orders.Add(new OrderData(3, "Steven Buchanan", "Sales Representative", "steven_buchanan"));
                    Orders.Add(new OrderData(4, "Janet Leverling", "Inside Sales Coordinator", "janet_leverling"));
                    Orders.Add(new OrderData(5, "Andrew Davolio", "Vice President", "andrew_davolio"));
                    Orders.Add(new OrderData(6, "Andrew Davolio", "Inside Sales Coordinator", "andrew_davolio"));
                    Orders.Add(new OrderData(7, "Janet Leverling", "Sales Representative", "janet_leverling"));
                    Orders.Add(new OrderData(8, "Steven Buchanan", "Sales Manager", "steven_buchanan"));
                    Orders.Add(new OrderData(9, "Nancy Fuller", "Vice President", "nancy_fuller"));
                    code += 5;
                }
            }
            return Orders;
        }
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
    } 
{% endhighlight %}
{% endtabs %}


In the above code, the url to be navigated is specified in the Link variable of the DataGrid data. Based on this, the page is routed to the corresponding url.

After that, add new razor page for routing with routing url along with the parameters to be received, and initialize it with the required details.

{% tabs %}
{% highlight razor tabtitle="FetchData.razor" %}
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
{% endhighlight %}
{% endtabs %}


The following GIF represents template routing in DataGrid
![Blazor DataGrid with routing template.](./images/blazor-datagrid-template-routing.gif)

## See also

* [FileUpload in Grid Column Template](https://www.syncfusion.com/forums/151021/fileupload-in-grid-column-template)