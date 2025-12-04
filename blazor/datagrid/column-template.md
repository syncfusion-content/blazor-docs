---
layout: post
title: Column Template in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about column template in the Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Column Template in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides a [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) property that allows rendering custom elements in a column instead of the default field value. This feature is useful for displaying images, buttons, or other custom content within a column.

{% youtube
"youtube:https://www.youtube.com/watch?v=9YF9HnFY5Ew"%}

> Template columns are primarily intended for rendering custom content and do not provide built-in support for actions such as sorting, filtering, or editing. To enable these actions, it is required to define the [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field) property for the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html).

## Render HTML Elements in a Column

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows rendering HTML elements inside a column using the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) property. This enables embedding custom content such as **images** and **hyperlinks** instead of plain text.

### Render image in a column

To display an image in a DataGrid column, define the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) property for the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html). The `Template` property allows rendering custom HTML or Blazor components instead of the default field value.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

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
![Render image in a column](./images/render-image-column-template.png)

> The `Template` property allows defining any HTML content or Blazor components within a column, enabling complete customization of cell rendering.

### Render hyperlink in a column

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports rendering hyperlinks in columns using the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) property. This feature is useful for displaying data that links to another page or external resource.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@EmployeeData">
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeDetails.EmployeeID) HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.LastName) HeaderText="Last Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.FirstName) HeaderText="First Name" Width="150">
            <Template>
                @{
                    var Data = (context as EmployeeDetails);
                    <div>
                        <a href="https://www.google.com/search?q=@Data.FirstName" target="_blank">@Data.FirstName</a>
                    </div>
                }
            </Template>
        </GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<EmployeeDetails> EmployeeData { get; set; }

    protected override void OnInitialized()
    {
    EmployeeData = EmployeeDetails.GetAllRecords();        
    }       
}
{% endhighlight %}
{% highlight c# tabtitle="EmployeeDetails.cs" %}
public class EmployeeDetails
{
    public static List<EmployeeDetails> employee = new List<EmployeeDetails>();

    public EmployeeDetails() { }

    public EmployeeDetails(int employeeID, string lastName, string firstName)
    {
        this.EmployeeID = employeeID;
        this.LastName = lastName;
        this.FirstName = firstName;
    }

    public static List<EmployeeDetails> GetAllRecords()
    {
        if (employee.Count == 0)
        {
            employee.Add(new EmployeeDetails(1, "Davolio", "Nancy"));
            employee.Add(new EmployeeDetails(2, "Fuller", "Andrew"));
            employee.Add(new EmployeeDetails(3, "Leverling", "Janet"));
            employee.Add(new EmployeeDetails(4, "Peacock", "Margaret"));
            employee.Add(new EmployeeDetails(5, "Buchanan", "Steven"));
            employee.Add(new EmployeeDetails(6, "Suyama", "Michael"));
            employee.Add(new EmployeeDetails(7, "King", "Robert"));
            employee.Add(new EmployeeDetails(8, "Callahan", "Laura"));
            employee.Add(new EmployeeDetails(9, "Dodsworth", "Anne"));
        }
        return employee;
    }

    public int EmployeeID { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
}
{% endhighlight %}
{% endtabs %}


{% previewsample "https://blazorplayground.syncfusion.com/embed/LtBzshXniHTpBqBz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


## Render other components in a column

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports rendering other Syncfusion components inside a column using the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) property. This allows embedding interactive elements for advanced customization.

### Render LineChart in a column

The [LineChart](https://blazor.syncfusion.com/documentation/sparkline/getting-started-webapp) provided by Syncfusion<sup style="font-size:70%">&reg;</sup> offers an elegant way to represent and compare data over time. It displays data points connected by straight line segments to visualize trends.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Charts

<SfGrid DataSource="@EmployeeData">
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeDetails.EmployeeID) HeaderText="Employee ID" Width="150">
        </GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.FirstName) HeaderText="First Name" Width="150">
        </GridColumn>
        <GridColumn HeaderText="Employee Performance Rating" Width="280">
            <Template>
                @{
                    var Data = (context as EmployeeDetails);
                    <SfSparkline Height="50px" Width="90%" Fill="#3C78EF" DataSource="@GetSparkData("line", (Data).EmployeeID + 1)">
                    </SfSparkline>
                }
            </Template>
        </GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<EmployeeDetails> EmployeeData { get; set; }

    protected override void OnInitialized()
    {
    EmployeeData = EmployeeDetails.GetAllRecords();        
    } 
     // Line data
    private List<List<int>> lineData = new List<List<int>>
    {
        new List<int> { 0, 6, -4, 1, -3, 2, 5 },
        new List<int> { 5, -4, 6, 3, -1, 2, 0 },
        new List<int> { 6, 4, 0, 3, -2, 5, 1 },
        new List<int> { 4, -6, 3, 0, 1, -2, 5 },
        new List<int> { 3, 5, -6, -4, 0, 1, 2 },
        new List<int> { 1, -3, 4, -2, 5, 0, 6 },
        new List<int> { 2, 4, 0, -3, 5, -6, 1 },
        new List<int> { 5, 4, -6, 3, 1, -2, 0 },
        new List<int> { 0, -6, 4, 1, -3, 2, 5 },
        new List<int> { 6, 4, 0, -3, 2, -5, 1 }
    };

    // Function to get sparkline data
    private List<int> GetSparkData(string type, int count)
    {
        if (type == "line" && count > 0 && count <= lineData.Count)
        {
            return lineData[count - 1];
        }
        return new List<int>();
    }            
}
{% endhighlight %}
{% highlight c# tabtitle="EmployeeDetails.cs" %}
public class EmployeeDetails
{
    public static List<EmployeeDetails> employee = new List<EmployeeDetails>();

    public EmployeeDetails() { }

    public EmployeeDetails(int employeeID, string lastName, string firstName)
    {
        this.EmployeeID = employeeID;
        this.LastName = lastName;
        this.FirstName = firstName;
    }

    public static List<EmployeeDetails> GetAllRecords()
    {
        if (employee.Count == 0)
        {
            employee.Add(new EmployeeDetails(1, "Davolio", "Nancy"));
            employee.Add(new EmployeeDetails(2, "Fuller", "Andrew"));
            employee.Add(new EmployeeDetails(3, "Leverling", "Janet"));
            employee.Add(new EmployeeDetails(4, "Peacock", "Margaret"));
            employee.Add(new EmployeeDetails(5, "Buchanan", "Steven"));
            employee.Add(new EmployeeDetails(6, "Suyama", "Michael"));
            employee.Add(new EmployeeDetails(7, "King", "Robert"));
            employee.Add(new EmployeeDetails(8, "Callahan", "Laura"));
            employee.Add(new EmployeeDetails(9, "Dodsworth", "Anne"));
        }
        return employee;
    }

    public int EmployeeID { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZLIDogDAvSxmdWU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Render DropDownList in a column

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows rendering a [DropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started-with-web-app) inside a column using the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) property. This feature is commonly used to provide inline selection of predefined values directly within the grid, such as choosing from predefined options for a field.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<SfGrid DataSource="@Orders">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) TextAlign="TextAlign.Right" HeaderText="Employee ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderStatus) HeaderText="Order Status" TextAlign="TextAlign.Right" Width="150">
            <Template>
                @{
                    var Data = (context as OrderDetails);
                    <SfDropDownList TValue="string" Placeholder="Order Placed" PopupWidth="150" PopupHeight="150" TItem="EmployeeNames" @bind-Value="@Data.OrderStatus" DataSource="@EmployeeDetails">
                        <DropDownListFieldSettings Value="Status"></DropDownListFieldSettings>
                    </SfDropDownList>
                }
            </Template>
        </GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderDetails> Orders { get; set; }
    public List<EmployeeNames> EmployeeDetails { get; set; }
    
    protected override void OnInitialized()
    {
        Orders = OrderDetails.GetAllRecords();

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
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerId, double Freight, string Orderstatus)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.Freight = Freight;
        this.OrderStatus = Orderstatus;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", 32.38, "Order Placed"));
            order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Processing"));
            order.Add(new OrderDetails(10250, "HANAR", 65.83, "Order Placed"));
            order.Add(new OrderDetails(10251, "VICTE", 41.34, "Order Placed"));
            order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Processing"));
            order.Add(new OrderDetails(10253, "HANAR", 58.17, "Processing"));
            order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Order Placed"));
            order.Add(new OrderDetails(10255, "RICSU", 148.33, "Processing"));
            order.Add(new OrderDetails(10256, "WELLI", 13.97, "Order Placed"));
            order.Add(new OrderDetails(10257, "HILAA", 81.91, "Processing"));
            order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Order Placed"));
            order.Add(new OrderDetails(10259, "CENTC", 3.25, "Processing"));
            order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Order Placed"));
            order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Order Placed"));
            order.Add(new OrderDetails(10262, "RATTC", 48.29, "Processing"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string OrderStatus { get; set; } 
}  
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNBJCrtKzUHwTXIk?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Render Chip in a column

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports rendering [Chips](https://blazor.syncfusion.com/documentation/chip/getting-started-with-web-app) inside a column using the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) property. This feature is useful for displaying data as visually distinct elements, such as tags or labels, within the grid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfGrid DataSource="@EmployeeData">
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeDetails.LastName) HeaderText="Last Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.City) HeaderText="City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.FirstName) HeaderText="First Name" Width="150">
             <Template>
                @{
                    var Data = (context as EmployeeDetails);                    
                    <SfChip ID="chip">
                        <ChipItems>
                            <ChipItem Text="@Data.FirstName"></ChipItem>
                        </ChipItems>
                    </SfChip>
                }
            </Template>
        </GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<EmployeeDetails> EmployeeData { get; set; }

    protected override void OnInitialized()
    {
    EmployeeData = EmployeeDetails.GetAllRecords();        
    }       
}
{% endhighlight %}
{% highlight c# tabtitle="EmployeeDetails.cs" %}
public class EmployeeDetails
{
    public static List<EmployeeDetails> employee = new List<EmployeeDetails>();

    public EmployeeDetails() { }

    public EmployeeDetails(int employeeID, string lastName, string firstName, string city)
    {
        this.EmployeeID = employeeID;
        this.LastName = lastName;
        this.FirstName = firstName;
        this.City = city;
    }

    public static List<EmployeeDetails> GetAllRecords()
    {
        if (employee.Count == 0)
        {
            employee.Add(new EmployeeDetails(1, "Davolio", "Nancy", "Seattle"));
            employee.Add(new EmployeeDetails(2, "Fuller", "Andrew", "Tacoma"));
            employee.Add(new EmployeeDetails(3, "Leverling", "Janet", "Kirkland"));
            employee.Add(new EmployeeDetails(4, "Peacock", "Margaret", "Redmond"));
            employee.Add(new EmployeeDetails(5, "Buchanan", "Steven", "London"));
            employee.Add(new EmployeeDetails(6, "Suyama", "Michael", "London"));
            employee.Add(new EmployeeDetails(7, "King", "Robert", "London"));
            employee.Add(new EmployeeDetails(8, "Callahan", "Laura", "Seattle"));
            employee.Add(new EmployeeDetails(9, "Dodsworth", "Anne", "London"));
        }
        return employee;
    }

    public int EmployeeID { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string City { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXLfsihZJaDYOHeV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Render ProgressBar in a column

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports rendering a [Progress Bar](https://blazor.syncfusion.com/documentation/progress-bar/getting-started-webapp) inside a column using the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) property. This feature is useful for visually tracking progress related to specific records.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.ProgressBar

<SfGrid DataSource="@OrderData">                
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID"  Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Width="150">
            <Template>
                @{
                    var Data = (context as OrderDetails);
                    <SfProgressBar Type="ProgressType.Linear" Value="Data.Freight" CornerRadius="CornerType.Square" Height="60" TrackThickness="24" ProgressThickness="20">
                    </SfProgressBar>
                }
            </Template>
        </GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerId, int EmployeeId, double Freight)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.EmployeeID = EmployeeId;
        this.Freight = Freight; 

    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET",  5,  32.38));
            order.Add(new OrderDetails(10249, "TOMSP",  6,  11.61));
            order.Add(new OrderDetails(10250, "HANAR",  4,  65.83));
            order.Add(new OrderDetails(10251, "VICTE",  3, 41.34));
            order.Add(new OrderDetails(10252, "SUPRD",  4, 51.3));
            order.Add(new OrderDetails(10253, "HANAR",  3,  58.17));
            order.Add(new OrderDetails(10254, "CHOPS",  5,  22.98));
            order.Add(new OrderDetails(10255, "RICSU",  9,  48.33));
            order.Add(new OrderDetails(10256, "WELLI",  3,  13.97));
            order.Add(new OrderDetails(10257, "HILAA",  4,  81.91));
            order.Add(new OrderDetails(10258, "ERNSH",  1,  40.51));
            order.Add(new OrderDetails(10259, "CENTC",  7, 3.25));
            order.Add(new OrderDetails(10260, "OTTIK",  2, 55.09));
            order.Add(new OrderDetails(10261, "QUEDE",  4, 3.05));
            order.Add(new OrderDetails(10262, "RATTC", 8, 48.29));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public double Freight { get; set; } 
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZVpMWhMhJHQEtIF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Render RadioButton in a column

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports rendering a [RadioButton](https://blazor.syncfusion.com/documentation/radio-button/getting-started-webapp) inside a column using the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) property. This feature is useful for scenarios where a single option must be selected from multiple choices within the grid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfGrid DataSource="@OrderData" AllowPaging="true" Height="350">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.FreightStatus) HeaderText="Order Status" Width="250">
            <Template>
                @{
                    var order = context as OrderDetails;
                    var radioID = $"OrderStatus_{order.OrderID}";
                }
                <SfRadioButton Label="Pending" Name="@radioID" Value="0" Checked="order.FreightStatus"></SfRadioButton>
                <SfRadioButton Label="Confirmed" Name="@radioID" Value="1" Checked="order.FreightStatus"></SfRadioButton>
                <SfRadioButton Label="Shipped" Name="@radioID" Value="2" Checked="order.FreightStatus"></SfRadioButton>
            </Template>
        </GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
using System.Collections.Generic;
public class OrderDetails
{
    public static List<OrderDetails> Orders = new List<OrderDetails>();
    public OrderDetails(int orderID, string customerId, int employeeId, double freight, int freightStatus)
    {
        this.OrderID = orderID;
        this.CustomerID = customerId;
        this.EmployeeID = employeeId;
        this.Freight = freight;
        this.FreightStatus = freightStatus;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderDetails(10248, "VINET", 5, 32.38, 0));
            Orders.Add(new OrderDetails(10249, "TOMSP", 6, 11.61, 1));
            Orders.Add(new OrderDetails(10250, "HANAR", 4, 65.83, 2));
            Orders.Add(new OrderDetails(10251, "VICTE", 3, 41.34, 0));
            Orders.Add(new OrderDetails(10252, "SUPRD", 4, 51.3, 1));
            Orders.Add(new OrderDetails(10253, "HANAR", 3, 58.17, 2));
            Orders.Add(new OrderDetails(10254, "CHOPS", 5, 22.98, 0));
        }
        return Orders;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public double Freight { get; set; }
    public int FreightStatus { get; set; } // 0: Pending, 1: Confirmed, 2: Shipped
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZheXoNwgrBgAFeR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Using condition template

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports conditional rendering within a column using the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) property. This feature allows displaying template elements based on specific conditions in the data source.

The `Template` property provides access to the current row’s data through the implicit **context** parameter, enabling conditional logic for rendering elements such as checkboxes, icons, or status indicators.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

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

### Calculate column value based on other columns in Blazor DataGrid

In the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, a column can display values derived from other fields in the same row using the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) property. This approach is useful for scenarios where calculated values, such as totals or combined costs, need to be shown without adding extra fields to the data source.

The `Template` property allows defining inline expressions or logic that compute values dynamically. The **context** parameter provides access to the row data, enabling calculations like summing two fields or applying custom formulas.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type=ColumnType.Date TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ManfCost) HeaderText="Manufacturing Cost" Format="C2" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.LabCost) HeaderText="Labor Cost" Format="C2" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.FinalCost) HeaderText="Final price" Format="C2" TextAlign="TextAlign.Center" Width="120">
            <Template>
                @{
                    var value = (context as Order);
                    var finalAmount = value.ManfCost + value.LabCost;
                    <div>$@finalAmount</div>
                }
            </Template>
        </GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 25).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            ManfCost = 10 * x,
            LabCost = 3 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? ManfCost { get; set; }
        public int? LabCost { get; set; }
        public double? FinalCost { get; set; }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNVoNfKNztPbnpjL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## How to get the row object by clicking on the template element

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports retrieving the row object when a [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) element inside a column is clicked. This feature is useful for performing custom actions such as showing detailed information, triggering workflows, or updating related UI components based on the selected record.

The `Template` property allows rendering interactive elements like buttons inside a column. When these elements are clicked, the associated row data can be accessed using the [RowSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowSelected) event or by handling the [OnClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_OnClick) event of the template element.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<SfGrid @ref="Grid" ID="Grid" DataSource="@EmployeeData">
    <GridEvents TValue="EmployeeDetails" RowSelected="OnRowSelected"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeDetails.EmployeeID) HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(EmployeeDetails.FirstName) HeaderText="First Name" Width="120"></GridColumn>
        <GridColumn HeaderText="Employee Data" TextAlign="TextAlign.Right" Width="150">
            <Template>
                <SfButton CssClass="empData" OnClick="ShowDetails">View</SfButton>
                <SfDialog @ref="Dialog" Visible="false" Width="50%" ShowCloseIcon="true" Header="Selected Row Details">
                    <DialogTemplates>
                        <Content>
                            @if (selectedRecord !=null)
                            {
                                <p><b>Employee ID:</b> @selectedRecord.EmployeeID</p>
                                <p><b>First Name:</b> @selectedRecord.FirstName</p>
                                <p><b>Last Name:</b> @selectedRecord.LastName</p>
                            }
                        </Content>
                    </DialogTemplates>
                </SfDialog>
            </Template>
        </GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public SfGrid<EmployeeDetails> Grid { get; set; }  
    public List<EmployeeDetails> EmployeeData { get; set; }
    protected override void OnInitialized()
    {
        EmployeeData = EmployeeDetails.GetAllRecords();
    }
    private SfDialog Dialog;
    private EmployeeDetails selectedRecord;

    private void OnRowSelected(RowSelectEventArgs<EmployeeDetails> args)
    {
        selectedRecord = args.Data; 
    }
    private void ShowDetails()
    {
        Dialog.ShowAsync();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="EmployeeDetails.cs" %}
public class EmployeeDetails
{
    public static List<EmployeeDetails> employee = new List<EmployeeDetails>();

    public EmployeeDetails(int employeeID, string lastName, string firstName)
    {
        this.EmployeeID = employeeID;
        this.LastName = lastName;
        this.FirstName = firstName;
    }

    public static List<EmployeeDetails> GetAllRecords()
    {
        if (employee.Count == 0)
        {
            employee.Add(new EmployeeDetails(1, "Davolio", "Nancy"));
            employee.Add(new EmployeeDetails(2, "Fuller", "Andrew"));
            employee.Add(new EmployeeDetails(3, "Leverling", "Janet"));
            employee.Add(new EmployeeDetails(4, "Peacock", "Margaret"));
            employee.Add(new EmployeeDetails(5, "Buchanan", "Steven"));
            employee.Add(new EmployeeDetails(6, "Suyama", "Michael"));
            employee.Add(new EmployeeDetails(7, "King", "Robert"));
            employee.Add(new EmployeeDetails(8, "Callahan", "Laura"));
            employee.Add(new EmployeeDetails(9, "Dodsworth", "Anne"));
        }
        return employee;
    }

    public int EmployeeID { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZhJiCBLfgSrKWdw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Use custom helper inside the template

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports using custom helper functions inside the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) property of a column. This feature is useful for creating complex templates that require additional logic beyond the default template syntax.

Custom helper functions can be defined in the component’s code section and invoked within the template using the **context** parameter. This approach allows implementing dynamic behaviors such as formatting values, applying conditional styles, or rendering custom UI elements based on row data.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData">                    
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" Width="90">
            <Template Context="data">
                @formatCurrency(((OrderDetails)data).Freight)
            </Template>
        </GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" Format="d" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderDetails> OrderData { get; set; }

    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public string formatCurrency(double value)
    {
        return "₹ " + value.ToString("F3"); // Format currency with 3 decimals
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    
    public OrderDetails(int OrderID, string CustomerId, DateTime Orderdate, double Freight)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.OrderDate = Orderdate;
        this.Freight = Freight; 
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", new DateTime(1996, 7, 4), 32.38));
            order.Add(new OrderDetails(10249, "TOMSP", new DateTime(1996, 7, 5), 11.61));
            order.Add(new OrderDetails(10250, "HANAR", new DateTime(1996, 7, 8), 65.83));
            order.Add(new OrderDetails(10251, "VICTE", new DateTime(1996, 7, 8), 41.34));
            order.Add(new OrderDetails(10252, "SUPRD", new DateTime(1996, 7, 9), 51.3));
            order.Add(new OrderDetails(10253, "HANAR", new DateTime(1996, 7, 10), 58.17));
            order.Add(new OrderDetails(10254, "CHOPS", new DateTime(1996, 7, 11), 22.98));
            order.Add(new OrderDetails(10255, "RICSU", new DateTime(1996, 7, 12), 148.33));
            order.Add(new OrderDetails(10256, "WELLI", new DateTime(1996, 7, 15), 13.97));
            order.Add(new OrderDetails(10257, "HILAA", new DateTime(1996, 7, 16), 81.91));
            order.Add(new OrderDetails(10258, "ERNSH", new DateTime(1996, 7, 17), 140.51));
            order.Add(new OrderDetails(10259, "CENTC", new DateTime(1996, 7, 18), 3.25));
            order.Add(new OrderDetails(10260, "OTTIK", new DateTime(1996, 7, 19), 55.09));
            order.Add(new OrderDetails(10261, "QUEDE", new DateTime(1996, 7, 19), 3.05));
            order.Add(new OrderDetails(10262, "RATTC", new DateTime(1996, 7, 22), 48.29));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime OrderDate { get; set; }
    public double Freight { get; set; } 
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VthJiiBVViweNEBD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> Custom helpers can only be used inside the `Template` property of a column.

## Dynamically adding template column

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports dynamically adding template columns at runtime. This feature is useful when the grid structure needs to change based on interactions or dynamic conditions.

Template columns can be created and inserted after the grid has been initialized, allowing custom elements such as dropdowns, buttons, or icons to be rendered dynamically. This approach provides flexibility for scenarios like adding interactive controls or displaying conditional content without modifying the initial grid configuration.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Buttons

<SfButton CssClass="e-outline" OnClick="AddTemplateColumn">Add Column</SfButton>
<SfGrid @ref="Grid" ID="Grid" DataSource="@OrderData" AllowPaging="true">                    
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID"  Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public SfGrid<OrderDetails> Grid { get; set; }
    public List<string> ShipCountryList { get; set; } = new();
    public List<OrderDetails> OrderData { get; set; }

    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
        ShipCountryList = OrderData.Select(o => o.ShipCountry).Distinct().ToList();
    }
    private void AddTemplateColumn()
    {
        List<GridColumn> NewColumns = new List<GridColumn> { 
            new GridColumn { 
                Field = "ShipCountry", 
                Template= data =>
                {                
                    return @<div>
                        <SfDropDownList DataSource="@ShipCountryList" PopupWidth="150" PopupHeight="150" @bind-Value="((OrderDetails)data).ShipCountry">
                        </SfDropDownList>
                    </div>;
                },
                HeaderTemplate = data => {return @<div><span class="e-icons e-location"></span> Ship Country</div>;},
                Width = "120" 
            }
        };
        foreach (GridColumn column in NewColumns)
        {
            Grid.Columns.Add(column);
        }
        Grid.RefreshColumnsAsync();
    }  
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    
    public OrderDetails(int OrderID, string CustomerId, string Shipcountry, double Freight)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.ShipCountry = Shipcountry;
        this.Freight = Freight; 
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET",  "France",  32.38));
            order.Add(new OrderDetails(10249, "TOMSP",  "Germany",  11.61));
            order.Add(new OrderDetails(10250, "HANAR",  "Brazil",  65.83));
            order.Add(new OrderDetails(10251, "VICTE",  "France", 41.34));
            order.Add(new OrderDetails(10252, "SUPRD",  "Belgium", 51.3));
            order.Add(new OrderDetails(10253, "HANAR",  "Brazil",  58.17));
            order.Add(new OrderDetails(10254, "CHOPS",  "Switzerland",  22.98));
            order.Add(new OrderDetails(10255, "RICSU",  "Switzerland",  148.33));
            order.Add(new OrderDetails(10256, "WELLI",  "Brazil",  13.97));
            order.Add(new OrderDetails(10257, "HILAA",  "Venezuela",  81.91));
            order.Add(new OrderDetails(10258, "ERNSH",  "Austria",  140.51));
            order.Add(new OrderDetails(10259, "CENTC",  "Mexico", 3.25));
            order.Add(new OrderDetails(10260, "OTTIK",  "Germany", 55.09));
            order.Add(new OrderDetails(10261, "QUEDE",  "Brazil", 3.05));
            order.Add(new OrderDetails(10262, "RATTC", "USA", 48.29));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCountry { get; set; }
    public double Freight { get; set; } 
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZVJsChWpdcrPOlN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Using hyperlink column and performing routing on click

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports adding routing links inside a column using the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) property. This feature enables navigation to different pages or routes when interacting with template elements.

Routing can be implemented by defining an **anchor tag** or clickable element inside the column template and handling navigation through the [UriHelper](https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/routing?view=aspnetcore-7.0&viewFallbackFrom=aspnetcore-3.0#uri-and-navigation-state-helpers). The **context** parameter provides access to the current row data, allowing dynamic route generation based on record values.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@inject NavigationManager UriHelper
@using Syncfusion.Blazor.Grids

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

In this configuration, the navigation URL is defined in the **Link** field of the Grid data. When the link is clicked, the page is routed to the specified URL.

Next, create a new Razor page with the appropriate routing URL and include any required route parameters. Initialize the page with the necessary details.

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

The following GIF represents template routing in Grid
![Blazor DataGrid with routing template.](./images/blazor-datagrid-template-routing.gif)

## See also

* [FileUpload in Grid Column Template](https://www.syncfusion.com/forums/151021/fileupload-in-grid-column-template)