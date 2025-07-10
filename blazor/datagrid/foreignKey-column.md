---
layout: post
title: Foreign key column in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Foreign key column in the Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Foreign key column in Blazor DataGrid

The Foreign key column in the Syncfusion Blazor DataGrid allows you to display related data from a foreign key data source in a column within the Grid. This feature is particularly useful when you have a column in the Grid that represents a foreign key relationship with another data source.

Foreign key column can be enabled by using `ForeignDataSource`, [ForeignKeyField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyField) and [ForeignKeyValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyValue) properties of **GridForeignColumn** directive.

Define the foreign key column in the Grid using the following properties:

* `ForeignDataSource` - Specifies the foreign data source that contains the related data.
* [ForeignKeyField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyField) - Maps the column name in the Grid to the field in the foreign data source that represents the foreign key relationship.
* [ForeignKeyValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyValue) -Specifies the field from the foreign data source that should be displayed in the Grid as the related data.

## Binding local data

The Syncfusion Blazor DataGrid provides a convenient way to bind local data to a foreign key column. This allows you to display related data from a local data source within the Grid. Here’s an example of how to bind local data to a Foreign Key column in Grid:

In this example, data is the local data source for the Grid, and **Employee Name** is the local data source for the foreign key column. The ForeignKeyValue property is set to **FirstName** which represents the field name in the  **Employee Name** that you want to display in the foreign key column.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridForeignColumn Field=@nameof(OrderDetails.EmployeeID) HeaderText="Employee Name" ForeignKeyValue="FirstName" ForeignDataSource="@Employees" Width="150"></GridForeignColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderDetails> Orders { get; set; }
    public List<EmployeeDetails> Employees { get; set; }
    protected override void OnInitialized()
    {
        Orders = OrderDetails.GetAllRecords();
        Employees = EmployeeDetails.GetAllRecords();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{        
    public static List<OrderDetails> order = new List<OrderDetails>();    
    public OrderDetails(int OrderID, string Shipcity, int EmployeeId, double Freight)
    {
        this.OrderID = OrderID;
        this.ShipCity = Shipcity;
        this.EmployeeID = EmployeeId;
        this.Freight = Freight; 
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "Reims", 5, 32.38));
            order.Add(new OrderDetails(10249, "Münster", 6, 11.61));
            order.Add(new OrderDetails(10250, "Rio de Janeiro", 4, 65.83));
            order.Add(new OrderDetails(10251, "Lyon", 3, 41.34));
            order.Add(new OrderDetails(10252, "Charleroi", 4, 51.3));
            order.Add(new OrderDetails(10253, "Rio de Janeiro", 3, 58.17));
            order.Add(new OrderDetails(10254, "Bern", 5, 22.98));
            order.Add(new OrderDetails(10255, "Genève", 9, 48.33));
            order.Add(new OrderDetails(10256, "Resende", 3, 13.97));
            order.Add(new OrderDetails(10257, "San Cristóbal", 4, 81.91));
            order.Add(new OrderDetails(10258, "Graz", 1, 40.51));
            order.Add(new OrderDetails(10259, "México D.F.", 4, 3.25));
            order.Add(new OrderDetails(10260, "Köln", 4, 55.09));
            order.Add(new OrderDetails(10261, "Rio de Janeiro", 4, 3.05));
            order.Add(new OrderDetails(10262, "Albuquerque", 8, 48.29));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string ShipCity { get; set; }
    public int EmployeeID { get; set; }
    public double Freight { get; set; } 
}
public class EmployeeDetails
{
    public static List<EmployeeDetails> employee = new List<EmployeeDetails>();
    public EmployeeDetails(int employeeID, string firstName)
    {
        this.EmployeeID = employeeID;
        this.FirstName = firstName;
    }
    public static List<EmployeeDetails> GetAllRecords()
    {
        if (employee.Count == 0)
        {
            employee.Add(new EmployeeDetails(1, "Nancy"));
            employee.Add(new EmployeeDetails(2, "Andrew"));
            employee.Add(new EmployeeDetails(3, "Janet"));
            employee.Add(new EmployeeDetails(4, "Margaret"));
            employee.Add(new EmployeeDetails(5, "Steven"));
            employee.Add(new EmployeeDetails(6, "Michael"));
            employee.Add(new EmployeeDetails(7, "Robert"));
            employee.Add(new EmployeeDetails(8, "Laura"));
            employee.Add(new EmployeeDetails(9, "Anne"));
        }
        return employee;
    }
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXhTWhNzzhjrqtUe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Binding remote data

The Foreign key column in Syncfusion Blazor DataGrid allows you to bind remote data for a foreign key column. You can use `SfDataManager` instead of using `DataSource` property. 

This example demonstrates how to use the foreign key column with remote data binding using the `ODataV4Adaptor` in the Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
         <GridForeignColumn TValue="EmployeeData" Field=@nameof(OrderDetails.EmployeeID) HeaderText="Employee Name" ForeignKeyValue="FirstName" Width="150">
            <Syncfusion.Blazor.Data.SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svc/Employees" CrossDomain="true" Adaptor=" Syncfusion.Blazor.Adaptors.ODataV4Adaptor">
            </Syncfusion.Blazor.Data.SfDataManager>
        </GridForeignColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderDetails> Orders { get; set; }  
    protected override void OnInitialized()
    {
        Orders = OrderDetails.GetAllRecords();      
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
public class EmployeeData
    {
        public static List<EmployeeData> Employees = new List<EmployeeData>();
        public EmployeeData()
        {
        }        
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
    }
public class OrderDetails
{    
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string Shipcity, int EmployeeId, double Freight)
    {
        this.OrderID = OrderID;
        this.ShipCity = Shipcity;
        this.EmployeeID = EmployeeId;
        this.Freight = Freight; 
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "Reims", 5, 32.38));
            order.Add(new OrderDetails(10249, "Münster", 6, 11.61));
            order.Add(new OrderDetails(10250, "Rio de Janeiro", 4, 65.83));
            order.Add(new OrderDetails(10251, "Lyon", 3, 41.34));
            order.Add(new OrderDetails(10252, "Charleroi", 4, 51.3));
            order.Add(new OrderDetails(10253, "Rio de Janeiro", 3, 58.17));
            order.Add(new OrderDetails(10254, "Bern", 5, 22.98));
            order.Add(new OrderDetails(10255, "Genève", 9, 48.33));
            order.Add(new OrderDetails(10256, "Resende", 3, 13.97));
            order.Add(new OrderDetails(10257, "San Cristóbal", 4, 81.91));
            order.Add(new OrderDetails(10258, "Graz", 1, 40.51));
            order.Add(new OrderDetails(10259, "México D.F.", 4, 3.25));
            order.Add(new OrderDetails(10260, "Köln", 4, 55.09));
            order.Add(new OrderDetails(10261, "Rio de Janeiro", 4, 3.05));
            order.Add(new OrderDetails(10262, "Albuquerque", 8, 48.29));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string ShipCity { get; set; }
    public int EmployeeID { get; set; }
    public double Freight { get; set; } 
}
{% endhighlight %}
{% endtabs %}

<!-- cors issue {% previewsample "https://blazorplayground.syncfusion.com/embed/LjrJXMWBgWWmRbjx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}  -->
![Foreign key column with remote data](./images/foreignkey-remote-data.png)

> * For remote data, the sorting and grouping is done based on [ForeignKeyField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyField) instead of [ForeignKeyValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyValue).
> * If [ForeignKeyField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyField) is not defined, then the column uses [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field) property of **GridColumn** tag helper.

## Use edit template in foreign key column

The Syncfusion Blazor DataGrid provides support for using an edit template in a foreign key column. By default, a dropdown is used for editing foreign key column. Other editable components can be rendered using the `EditTemplate` feature of Grid. The following example demonstrates the way of using edit template with `ComboBox` in the foreign column.

In the following code example, the Employee Name is a foreign key column. When editing, the `ComboBox` is rendered instead of `DropDownList`:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<SfGrid DataSource="@Orders" Height="315" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridForeignColumn Field=@nameof(OrderData.EmployeeID) HeaderText="Employee Name" ForeignKeyValue="FirstName" ForeignDataSource="@Employees" Width="150">
            <EditTemplate>
                <SfComboBox TValue="int?" TItem="EmployeeData" @bind-Value="@((context as OrderData).EmployeeID)" DataSource="Employees">
                    <ComboBoxFieldSettings Value="EmployeeID" Text="FirstName"></ComboBoxFieldSettings>
                </SfComboBox>
            </EditTemplate>
        </GridForeignColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderData> Orders { get; set; }
    public List<EmployeeData> Employees { get; set; }
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
        Employees = EmployeeData.GetAllRecords();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
    public class EmployeeData
    {
        public static List<EmployeeData> Employees = new List<EmployeeData>();
        public EmployeeData() 
        { 

        }
        public EmployeeData(int? employeeID, string firstName)
        {
            EmployeeID = employeeID;
            FirstName = firstName;
        }
        public static List<EmployeeData> GetAllRecords()
        {
            if (Employees.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Employees.Add(new EmployeeData( 1, "Nancy"));
                    Employees.Add(new EmployeeData( 2, "Andrew"));
                    Employees.Add(new EmployeeData( 3, "Janet"));
                    Employees.Add(new EmployeeData( 4, "Nancy"));
                    Employees.Add(new EmployeeData( 5, "Margaret"));
                    Employees.Add(new EmployeeData( 6, "Steven"));
                    Employees.Add(new EmployeeData( 7, "Janet"));
                    Employees.Add(new EmployeeData( 8, "Andrew"));
                    Employees.Add(new EmployeeData(9, "Nancy"));
                    code += 5;
                }
            }
            return Employees;
        }
        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
    }
    public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();        
       
        public OrderData()
        {

        }
        public OrderData(int? OrderID, int? EmployeeID, string ShipCity, double? Freight)
        {
           this.OrderID = OrderID;
           this.EmployeeID = EmployeeID;
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
                    Orders.Add(new OrderData(10248,1, "Reims", 32.18));
                    Orders.Add(new OrderData(10249,2, "Münster",33.33));
                    Orders.Add(new OrderData(10250,3, "Rio de Janeiro",12.35));
                    Orders.Add(new OrderData(10251,4, "Reims", 22.65));
                    Orders.Add(new OrderData(10252,5, "Lyon", 63.43));
                    Orders.Add(new OrderData(10253,6, "Charleroi",56.98));
                    Orders.Add(new OrderData(10254,7, "Rio de Janeiro", 45.65));
                    Orders.Add(new OrderData(10255,8, "Münster", 11.13));
                    Orders.Add(new OrderData(10256,9, "Reims", 87.59));
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public int? EmployeeID { get; set; }
        public string ShipCity { get; set; }
        public double? Freight { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rthqiCZnKFZSBjXt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize filter UI in foreign key column

The Syncfusion Blazor DataGrid allows you to customize the filtering user interface (UI) for foreign key columns by using the [FilterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_FilterTemplate) property. By default, a dropdown is used for filtering foreign key columns. However, you can create your own custom filtering UI by [FilterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_FilterTemplate) property. Here’s an example that demonstrates how to create a custom filtering UI in a foreign key column:

> For all filter types other than FilterBar, filtering parameters will be sent in the form of `PredicateModel<T>`. Here, T represents the type of `ForeignKeyValue` property when using the foreign key column.

In this example, a `DropDownList` is rendered as the filter UI for the **“EmployeeID”** foreign key column. The  **DataSource** property of the `SfDropDownList` is set to the employees data, and the Fields property is configured to display the **FirstName** field as the text and **EmployeeID** field as the value. The `value` property is set to the current filter value of the column.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<SfGrid DataSource="@Orders" Height="315" AllowFiltering="true">
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridForeignColumn Field=@nameof(OrderDetails.EmployeeID) HeaderText="Employee Name" ForeignKeyValue="FirstName" ForeignDataSource="@Employees" Width="150">
            <FilterTemplate>
                <SfDropDownList Placeholder="FirstName" ID="FirstName" @bind-Value="@((context as PredicateModel<string>).Value)" TItem="EmployeeDetails" TValue="string" DataSource="@Employees">
                    <DropDownListFieldSettings Value="FirstName" Text="FirstName"></DropDownListFieldSettings>
                </SfDropDownList>
            </FilterTemplate>
        </GridForeignColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderDetails> Orders { get; set; }
    public List<EmployeeDetails> Employees { get; set; }
    protected override void OnInitialized()
    {
        Orders = OrderDetails.GetAllRecords();
        Employees = EmployeeDetails.GetAllRecords();
    }   
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();    
    public OrderDetails(int OrderID, string Shipcity, int EmployeeId, double Freight)
    {
        this.OrderID = OrderID;
        this.ShipCity = Shipcity;
        this.EmployeeID = EmployeeId;
        this.Freight = Freight; 
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "Reims", 5, 32.38));
            order.Add(new OrderDetails(10249, "Münster", 6, 11.61));
            order.Add(new OrderDetails(10250, "Rio de Janeiro", 4, 65.83));
            order.Add(new OrderDetails(10251, "Lyon", 3, 41.34));
            order.Add(new OrderDetails(10252, "Charleroi", 4, 51.3));
            order.Add(new OrderDetails(10253, "Rio de Janeiro", 3, 58.17));
            order.Add(new OrderDetails(10254, "Bern", 5, 22.98));
            order.Add(new OrderDetails(10255, "Genève", 9, 48.33));
            order.Add(new OrderDetails(10256, "Resende", 3, 13.97));
            order.Add(new OrderDetails(10257, "San Cristóbal", 4, 81.91));
            order.Add(new OrderDetails(10258, "Graz", 1, 40.51));
            order.Add(new OrderDetails(10259, "México D.F.", 4, 3.25));
            order.Add(new OrderDetails(10260, "Köln", 4, 55.09));
            order.Add(new OrderDetails(10261, "Rio de Janeiro", 4, 3.05));
            order.Add(new OrderDetails(10262, "Albuquerque", 8, 48.29));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string ShipCity { get; set; }
    public int EmployeeID { get; set; }
    public double Freight { get; set; } 
}
public class EmployeeDetails
{
    public static List<EmployeeDetails> employee = new List<EmployeeDetails>();
    public EmployeeDetails(int employeeID, string firstName)
    {
        this.EmployeeID = employeeID;
        this.FirstName = firstName;
    }
    public static List<EmployeeDetails> GetAllRecords()
    {
        if (employee.Count == 0)
        {
            employee.Add(new EmployeeDetails(1, "Nancy"));
            employee.Add(new EmployeeDetails(2, "Andrew"));
            employee.Add(new EmployeeDetails(3, "Janet"));
            employee.Add(new EmployeeDetails(4, "Margaret"));
            employee.Add(new EmployeeDetails(5, "Steven"));
            employee.Add(new EmployeeDetails(6, "Michael"));
            employee.Add(new EmployeeDetails(7, "Robert"));
            employee.Add(new EmployeeDetails(8, "Laura"));
            employee.Add(new EmployeeDetails(9, "Anne"));
        }
        return employee;
    }
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZVTMLDyAzdAAcbt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> [View Sample in GitHub.](https://github.com/SyncfusionExamples/blazor-datagrid-customize-filter-ui-in-foreignkey-column)

## Use filter bar template in foreign key column

You can use the filter template in a foreign key column in Syncfusion Blazor DataGrid by using the [FilterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_FilterTemplate) property. This allows you to customize the filter bar for the foreign key column with a custom component or HTML template. Here’s an example that demonstrates how to use a Filter template in a foreign key column:

In this example, the **“EmployeeID”** column is a foreign key column. The `FilterTemplate` property is used to render a `DropDownList` as a filter, you can select filter value by using the **DropDown** options.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<SfGrid @ref="Grid" DataSource="@Orders" Height="315" AllowFiltering="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridForeignColumn Field=@nameof(OrderDetails.EmployeeID) HeaderText="Employee Name" ForeignKeyValue="FirstName" ForeignDataSource="@Employees" Width="150">
            <FilterTemplate>
                <SfDropDownList ID="EmployeeID" PlaceHolder="Employee Name" Value="@((string)(context as PredicateModel).Value)" DataSource="@DropDownData" TValue="string" TItem="DropDownOrder">
                    <DropDownListEvents ValueChange="@Change" TItem="DropDownOrder" TValue="string"></DropDownListEvents>
                    <DropDownListFieldSettings Value="FirstName" Text="FirstName"></DropDownListFieldSettings>
                </SfDropDownList>
            </FilterTemplate>
        </GridForeignColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderDetails> Grid;
    public List<OrderDetails> Orders { get; set; }
    public List<EmployeeDetails> Employees { get; set; }
    protected override void OnInitialized()
    {
        Orders = OrderDetails.GetAllRecords();
        Employees = EmployeeDetails.GetAllRecords();
    }
    public async Task Change(@Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, DropDownOrder> args)
    {   
        if (args.Value == "All" || args.Value == null)
        {
            await Grid.ClearFilteringAsync();
        }
        else
        {
            await Grid.FilterByColumnAsync("EmployeeID", "contains", args.Value);
        }
    }
    public class DropDownOrder
    {
        public string FirstName { get; set; }
    }
    List<DropDownOrder> DropDownData = new List<DropDownOrder>
    {
        new DropDownOrder() { FirstName = "All" },
        new DropDownOrder() { FirstName = "Nancy" },
        new DropDownOrder() { FirstName = "Janet" },
        new DropDownOrder() { FirstName = "Margaret" },
        new DropDownOrder() { FirstName = "Steven" },
        new DropDownOrder() { FirstName = "Michael" },
        new DropDownOrder() { FirstName = "Laura" },
        new DropDownOrder() { FirstName = "Anne" },
    };
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();    
    public OrderDetails(int OrderID, string Shipcity, int EmployeeId, double Freight)
    {
        this.OrderID = OrderID;
        this.ShipCity = Shipcity;
        this.EmployeeID = EmployeeId;
        this.Freight = Freight; 
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "Reims", 5, 32.38));
            order.Add(new OrderDetails(10249, "Münster", 6, 11.61));
            order.Add(new OrderDetails(10250, "Rio de Janeiro", 4, 65.83));
            order.Add(new OrderDetails(10251, "Lyon", 3, 41.34));
            order.Add(new OrderDetails(10252, "Charleroi", 4, 51.3));
            order.Add(new OrderDetails(10253, "Rio de Janeiro", 3, 58.17));
            order.Add(new OrderDetails(10254, "Bern", 5, 22.98));
            order.Add(new OrderDetails(10255, "Genève", 9, 48.33));
            order.Add(new OrderDetails(10256, "Resende", 3, 13.97));
            order.Add(new OrderDetails(10257, "San Cristóbal", 4, 81.91));
            order.Add(new OrderDetails(10258, "Graz", 1, 40.51));
            order.Add(new OrderDetails(10259, "México D.F.", 4, 3.25));
            order.Add(new OrderDetails(10260, "Köln", 4, 55.09));
            order.Add(new OrderDetails(10261, "Rio de Janeiro", 4, 3.05));
            order.Add(new OrderDetails(10262, "Albuquerque", 8, 48.29));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string ShipCity { get; set; }
    public int EmployeeID { get; set; }
    public double Freight { get; set; } 
}
public class EmployeeDetails
{
    public static List<EmployeeDetails> employee = new List<EmployeeDetails>();
    public EmployeeDetails(int employeeID, string firstName)
    {
        this.EmployeeID = employeeID;
        this.FirstName = firstName;
    }
    public static List<EmployeeDetails> GetAllRecords()
    {
        if (employee.Count == 0)
        {
            employee.Add(new EmployeeDetails(1, "Nancy"));
            employee.Add(new EmployeeDetails(2, "Andrew"));
            employee.Add(new EmployeeDetails(3, "Janet"));
            employee.Add(new EmployeeDetails(4, "Margaret"));
            employee.Add(new EmployeeDetails(5, "Steven"));
            employee.Add(new EmployeeDetails(6, "Michael"));
            employee.Add(new EmployeeDetails(7, "Robert"));
            employee.Add(new EmployeeDetails(8, "Laura"));
            employee.Add(new EmployeeDetails(9, "Anne"));
        }
        return employee;
    }
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtBpiVDnrpdKsebf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Perform aggregation in foreign key column

By default, aggregations are not supported in a foreign key column in the Syncfusion Blazor DataGrid. However, you can achieve aggregation for a foreign key column by using `customAggregate`.

To perform aggregation in a foreign key column, follow these steps:

1. Define a foreign key column in the Grid.
2. Implement a custom aggregate function to calculate the aggregation for the foreign key column.
3. Set the `customAggregate` property of the column to the custom aggregate function.

Here's an example that demonstrates how to perform aggregation in a foreign key column:

In the provided example, the `customAggregateFn` function is used to filter and count the **Margaret** data based on the **FirstName** field of the foreign key column. The result is displayed in the Grid's footer template using the [FooterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_FooterTemplate) property.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" Height="315" >
    <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field="EmployeeID" Type="AggregateType.Custom">
                    <FooterTemplate Context="data">
                        Count of Margaret: @CustomAggregateFn()
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridForeignColumn Field=@nameof(OrderDetails.EmployeeID) HeaderText="Employee Name" ForeignKeyValue="FirstName" ForeignDataSource="@EmployeeData" Width="120"></GridForeignColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Right" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderDetails> OrderData { get; set; }
    public List<EmployeeDetails> EmployeeData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
        EmployeeData = EmployeeDetails.GetAllRecords();
    }   
    private int CustomAggregateFn()
    {
        var Count=  OrderData.Count(order => EmployeeData
            .FirstOrDefault(data => data.EmployeeID == order.EmployeeID)?.FirstName == "Margaret");
        return Count;
    }    
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();    
    public OrderDetails(int OrderID, string Shipcity, int EmployeeId, double Freight)
    {
        this.OrderID = OrderID;
        this.ShipCity = Shipcity;
        this.EmployeeID = EmployeeId;
        this.Freight = Freight; 
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "Reims", 5, 32.38));
            order.Add(new OrderDetails(10249, "Münster", 6, 11.61));
            order.Add(new OrderDetails(10250, "Rio de Janeiro", 4, 65.83));
            order.Add(new OrderDetails(10251, "Lyon", 3, 41.34));
            order.Add(new OrderDetails(10252, "Charleroi", 4, 51.3));
            order.Add(new OrderDetails(10253, "Rio de Janeiro", 3, 58.17));
            order.Add(new OrderDetails(10254, "Bern", 5, 22.98));
            order.Add(new OrderDetails(10255, "Genève", 9, 48.33));
            order.Add(new OrderDetails(10256, "Resende", 3, 13.97));
            order.Add(new OrderDetails(10257, "San Cristóbal", 4, 81.91));
            order.Add(new OrderDetails(10258, "Graz", 1, 40.51));
            order.Add(new OrderDetails(10259, "México D.F.", 4, 3.25));
            order.Add(new OrderDetails(10260, "Köln", 4, 55.09));
            order.Add(new OrderDetails(10261, "Rio de Janeiro", 4, 3.05));
            order.Add(new OrderDetails(10262, "Albuquerque", 8, 48.29));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string ShipCity { get; set; }
    public int EmployeeID { get; set; }
    public double Freight { get; set; } 
}
public class EmployeeDetails
{
    public static List<EmployeeDetails> employee = new List<EmployeeDetails>();
    public EmployeeDetails(int employeeID, string firstName)
    {
        this.EmployeeID = employeeID;
        this.FirstName = firstName;
    }
    public static List<EmployeeDetails> GetAllRecords()
    {
        if (employee.Count == 0)
        {
            employee.Add(new EmployeeDetails(1, "Nancy"));
            employee.Add(new EmployeeDetails(2, "Andrew"));
            employee.Add(new EmployeeDetails(3, "Janet"));
            employee.Add(new EmployeeDetails(4, "Margaret"));
            employee.Add(new EmployeeDetails(5, "Steven"));
            employee.Add(new EmployeeDetails(6, "Michael"));
            employee.Add(new EmployeeDetails(7, "Robert"));
            employee.Add(new EmployeeDetails(8, "Laura"));
            employee.Add(new EmployeeDetails(9, "Anne"));
        }
        return employee;
    }
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDVzisLyKJzudYVg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Prevent filter query generation for foreign key column

By default, a filter query for the foreign key column will be generated based on the foreign key value. You can prevent the default filter query generation for the foreign key column and add the custom filter query. This can be achieved by setting the [PreventFilterQuery](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ActionEventArgs-1.html#Syncfusion_Blazor_Grids_ActionEventArgs_1_PreventFilterQuery) argument of the [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnActionBegin) event to true.

In the following code sample, you can prevent default filter query generation using the `PreventFilterQuery` property and generate a custom filter query to execute a filter operation:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using System.ComponentModel.DataAnnotations;
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using Newtonsoft.Json

<SfGrid ID="Grid" @ref="Grid" Query="@currentQuery" TValue="Book" Toolbar="@ToolbarItems" Height="100%" AllowPaging="true" AllowSorting="true" AllowFiltering="true">
    <GridPageSettings PageSize="10" PageSizes="true"></GridPageSettings>
    <SfDataManager Url="http://localhost:64956/odata/books" Adaptor="Syncfusion.Blazor.Adaptors.ODataV4Adaptor"></SfDataManager>
    <GridEvents TValue="Book" OnActionBegin="OnActionBegin"/>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="@EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Book.Id) IsPrimaryKey="true" Width="150"></GridColumn>
        <GridForeignColumn TValue="Customer" Field=@nameof(Book.CustomerId)  AllowFiltering="true" ForeignKeyValue="Name" ForeignKeyField="Id" HeaderText="Name" Width="100" >
            <SfDataManager Url="http://localhost:64956/odata/customers" Adaptor="Syncfusion.Blazor.Adaptors.ODataV4Adaptor"></SfDataManager>
        </GridForeignColumn>
        <GridColumn Field=@nameof(Book.CreditLimit) Width="200" EditType="EditType.NumericEdit"></GridColumn>
        <GridColumn Field=@nameof(Book.Active) Width="200" EditType="EditType.BooleanEdit"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    SfGrid<Book> Grid { get; set; }
    private Query currentQuery = new Query();
    public List<string> ToolbarItems = new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" };
 
    private void OnActionBegin(Syncfusion.Blazor.Grids.ActionEventArgs<Book> args)
    {  
        if (args.RequestType == Syncfusion.Blazor.Grids.Action.Filtering)
        {
            if (String.Equals(args.CurrentFilteringColumn, nameof(Book.CustomerId), StringComparison.OrdinalIgnoreCase))
            {
                args.PreventFilterQuery = true;
                currentQuery = new Query().Where("Customer/Name", args.CurrentFilterObject.Operator.ToString().ToLower(), args.CurrentFilterObject.Value, true, true);
            }
        }
    }

    public class Book
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CustomerId1 { get; set; }
        public virtual Customer Customer { get; set; }
        public int CreditLimit { get; set; }
        public bool Active { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }      
        [JsonIgnore]
        public List<Book> CustomerBooks { get; set; }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZrzXrWOrKYCkblp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Render foreign key value in column template

The Syncfusion Blazor DataGrid supports rendering foreign key values within a column template, allowing for a more meaningful display of related data. Instead of showing the underlying foreign key value, you can customize the column to display a corresponding descriptive value from a related data source.

To achieve this, define a column using the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) property and use the foreign key mapping to bind and render the desired value. This approach is especially useful when the foreign key refers to an ID and you want to display the corresponding name or label.

The following example demonstrates how to render a foreign key value using a column template in the Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@inject IJSRuntime JS

<SfGrid DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" Width="120" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" />
        <GridForeignColumn Field="EmployeeID" HeaderText="Employee Name" ForeignDataSource="@Employees" ForeignKeyField="EmployeeID" ForeignKeyValue="FirstName" Width="150">
            <Template Context="data">
                @{
                    var order = (OrderData)data;
                    var emp = Employees.FirstOrDefault(e => e.EmployeeID == order.EmployeeID);
                }
                <a href="#" @onclick="() => LogToConsole(order?.OrderID)">@emp?.FirstName</a>
            </Template>
        </GridForeignColumn>
        <GridColumn Field="Freight" HeaderText="Freight" Format="C2" Width="120" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" />
        <GridColumn Field="ShipCity" HeaderText="Ship City" Width="120" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" />
    </GridColumns>
</SfGrid>
@code {
    public List<OrderData> Orders { get; set; }
    public List<EmployeeData> Employees { get; set; }
    protected override void OnInitialized()
    {
        Employees = EmployeeData.GetAllRecords();
        Orders = OrderData.GetAllRecords();
    }
    private async Task LogToConsole(int? orderId)
    {
        await JS.InvokeVoidAsync("console.log", $"OrderID clicked: {orderId}");
    }
    public class EmployeeData
    {
        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
        public EmployeeData(int? employeeID, string firstName)
        {
            EmployeeID = employeeID;
            FirstName = firstName;
        }
        public static List<EmployeeData> GetAllRecords()
        {
            return new List<EmployeeData>
            {
                new EmployeeData(1, "Nancy"),
                new EmployeeData(2, "Andrew"),
                new EmployeeData(3, "Janet"),
                new EmployeeData(4, "Margaret"),
                new EmployeeData(5, "Steven")
            };
        }
    }
    public class OrderData
    {
        public int? OrderID { get; set; }
        public int? EmployeeID { get; set; }
        public string ShipCity { get; set; }
        public double? Freight { get; set; }
        public OrderData(int? orderId, int? employeeId, string shipCity, double? freight)
        {
            OrderID = orderId;
            EmployeeID = employeeId;
            ShipCity = shipCity;
            Freight = freight;
        }
        public static List<OrderData> GetAllRecords()
        {
            return new List<OrderData>
            {
                new OrderData(10248, 1, "Reims", 32.18),
                new OrderData(10249, 2, "Münster", 33.33),
                new OrderData(10250, 3, "Rio de Janeiro", 12.35),
                new OrderData(10251, 4, "Lyon", 63.43),
                new OrderData(10252, 5, "Charleroi", 56.98),
            };
        }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXrSDojmVniWmsTS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Enable multiple foreign key columns

The Syncfusion Blazor DataGrid supports the feature of enabling multiple foreign key columns with editing options. This allows users to display columns from foreign data sources in the Grid.

In the following example, Employee Name and Ship City are foreign key columns that display the FirstName and ShipCity columns from foreign data:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315" Toolbar="@(new List<string>() { "Add", "Delete", "Update", "Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridForeignColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" ForeignKeyValue="CustomerName" ForeignDataSource="@Employees" Width="150"></GridForeignColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridForeignColumn Field=@nameof(OrderDetails.EmployeeID) HeaderText=" Ship City" ForeignKeyValue="City" ForeignDataSource="@Countries" Width="150"></GridForeignColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderDetails> Orders { get; set; }
    public List<CountryDetails> Countries { get; set; }
    public List<EmployeeDetails> Employees { get; set; }
    protected override void OnInitialized()
    {
        Orders = OrderDetails.GetAllRecords();
        Employees = EmployeeDetails.GetAllRecords();
        Countries = CountryDetails.GetAllRecords();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerId, int EmployeeId, string Shipcountry, double Freight)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.EmployeeID = EmployeeId;
        this.ShipCountry = Shipcountry;
        this.Freight = Freight; 
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", 3, "France",  32.38));
            order.Add(new OrderDetails(10249, "TOMSP", 5, "Germany",  11.61));
            order.Add(new OrderDetails(10250, "HANAR", 1, "Brazil",  65.83));
            order.Add(new OrderDetails(10251, "VICTE", 6, "France", 41.34));
            order.Add(new OrderDetails(10252, "SUPRD", 2, "Belgium", 51.3));
            order.Add(new OrderDetails(10253, "HANAR", 4, "Brazil",  58.17));
            order.Add(new OrderDetails(10254, "CHOPS", 9, "Switzerland",  22.98));
            order.Add(new OrderDetails(10255, "RICSU", 7, "Switzerland",  148.33));
            order.Add(new OrderDetails(10256, "WELLI", 8, "Brazil",  13.97));
            order.Add(new OrderDetails(10257, "HILAA", 5, "Venezuela",  81.91));
            order.Add(new OrderDetails(10258, "ERNSH", 1, "Austria",  140.51));
            order.Add(new OrderDetails(10259, "CENTC", 6, "Mexico", 3.25));
            order.Add(new OrderDetails(10260, "OTTIK", 2, "Germany", 55.09));
            order.Add(new OrderDetails(10261, "QUEDE", 7, "Brazil", 3.05));
            order.Add(new OrderDetails(10262, "RATTC", 4, "USA", 48.29));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public string ShipCountry { get; set; }
    public double Freight { get; set; } 
}
public class CountryDetails
{
    public static List<CountryDetails> country = new List<CountryDetails>();
    public CountryDetails(int employeeID, string city)
    {
        this.EmployeeID = employeeID;
        this.City = city;
    }
    public static List<CountryDetails> GetAllRecords()
    {
        if (country.Count == 0)
        {
            country.Add(new CountryDetails(1, "Seattle"));
            country.Add(new CountryDetails(2, "Tacoma"));
            country.Add(new CountryDetails(3, "Kirkland"));
            country.Add(new CountryDetails(4, "Redmond"));
            country.Add(new CountryDetails(5, "London"));
            country.Add(new CountryDetails(6, "London"));
            country.Add(new CountryDetails(7, "London"));
            country.Add(new CountryDetails(8, "Seattle"));
            country.Add(new CountryDetails(9, "London"));
        }
        return country;
    }
    public int EmployeeID { get; set; }
    public string City { get; set; }
}
public class EmployeeDetails
{
    public static List<EmployeeDetails> employee = new List<EmployeeDetails>();
    public EmployeeDetails(string customerId, string customerName)
    {
        this.CustomerID = customerId;
        this.CustomerName = customerName;
    }
    public static List<EmployeeDetails> GetAllRecords()
    {
        if (employee.Count == 0)
        {
            employee.Add(new EmployeeDetails("VINET", "Paul Henriot"));
            employee.Add(new EmployeeDetails("TOMSP", "Karin Josephs"));
            employee.Add(new EmployeeDetails("HANAR", "Mario Pontes"));
            employee.Add(new EmployeeDetails("VICTE", "Mary Saveley"));
            employee.Add(new EmployeeDetails("SUPRD", "Pascale Cartrain"));
            employee.Add(new EmployeeDetails("HANAR", "Mario Pontes"));
            employee.Add(new EmployeeDetails("CHOPS", "Yang Wang"));
            employee.Add(new EmployeeDetails("RICSU", "Michael Holz"));
            employee.Add(new EmployeeDetails("WELLI", "Paula Parente"));
            employee.Add(new EmployeeDetails("HILAA", "Carlos Hernández"));
            employee.Add(new EmployeeDetails("ERNSH", "Roland Mendel"));
            employee.Add(new EmployeeDetails("CENTC", "Francisco Chang"));
            employee.Add(new EmployeeDetails("OTTIK", "Henriette Pfalzheim"));
            employee.Add(new EmployeeDetails("QUEDE", "Bernardo Batista"));
            employee.Add(new EmployeeDetails("RATTC", "Paula Wilson"));
        }
        return employee;
    }
    public string CustomerID { get; set; }
    public string CustomerName { get; set; }
} 
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNBJCLZnLheGLept?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> You can find the fully working sample [here](https://github.com/SyncfusionExamples/blazor-datagrid-prevent-query-generation-for-foriegnkey-column).

## Edit template in foreign key column using remote data

The Syncfusion Blazor DataGrid allows you to customize the edit template for foreign key columns when using remote data. By default, a [DropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started-with-web-app) is used for editing foreign key column. Other editable components can be rendered using the edit template feature of Grid. 

This example demonstrates how to use an edit template in a foreign key column with remote data. In this case, an [AutoComplete](https://blazor.syncfusion.com/documentation/autocomplete/getting-started-with-web-app)  is rendered as the edit template for the **EmployeeID** foreign key column. You can use `SfDataManager` instead of the `DataSource` property to bind remote data. Follow the steps below to achieve this:

**1. Create a Blazor web app**

You can create a **Blazor Web App** named **EditTemplate** using Visual Studio 2022, either via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). Make sure to configure the appropriate [interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=windows).

**2. Install Syncfusion Blazor DataGrid, AutoComplete, and Themes NuGet Packages**

To add the `Grid` and `AutoComplete` in the app, open the NuGet Package Manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/), [Syncfusion.Blazor.DropDowns](https://www.nuget.org/packages/Syncfusion.Blazor.DropDowns), and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

If your Blazor Web App uses `WebAssembly` or `Auto` render modes, install the Syncfusion Blazor NuGet packages in the client project.

Alternatively, use the following Package Manager commands:

```powershell
Install-Package Syncfusion.Blazor.Grid -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.DropDowns -Version {{ site.releaseversion }}
```

> Syncfusion Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for a complete list of available packages.
 
**3. Register Syncfusion Blazor service**

- Open the **~/_Imports.razor** file and import the required namespaces.

```csharp
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
```

- Register the Syncfusion Blazor service in the **~/Program.cs** file.

```csharp
using Syncfusion.Blazor;

builder.Services.AddSyncfusionBlazor();
```

For apps using `WebAssembly` or `Auto (Server and WebAssembly)` render modes, register the service in both **~/Program.cs** files.

**4. Add stylesheet and script resources**

Include the theme stylesheet and script references in the **~/Components/App.razor** file.

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>
....
<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

> * Refer to the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic for various methods to include themes (e.g., Static Web Assets, CDN, or CRG).
> * Set the render mode to **InteractiveServer** or **InteractiveAuto** in your Blazor Web App configuration.

**5. Register controllers in `Program.cs`**

Add the following lines in the `Program.cs` file to register controllers:

```csharp
// Register controllers in the service container.
builder.Services.AddControllers();

// Map controller routes.
app.MapControllers();
```

**6. Create a model class**

Create a new folder named **Models**. Inside this folder, add a model class named **OrdersDetails.cs** to represent the order data, and another model class named **EmployeeData.cs** to represent the employee data.

{% tabs %}
{% highlight cs tabtitle="GridController.cs" %}

namespace EditTemplate.Models
{
    public class OrdersDetails
    {
        private static List<OrdersDetails> order = new List<OrdersDetails>();
        public OrdersDetails() { }

        public OrdersDetails(int OrderID, string CustomerID, int EmployeeID, string ShipName, string ShipCountry)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.EmployeeID = EmployeeID;
            this.ShipName = ShipName;
            this.ShipCountry = ShipCountry;
        }

        public static List<OrdersDetails> GetAllRecords()
        {
            if (order.Count == 0)
            {
                order.Add(new OrdersDetails(1, "ALFKI", 1, "Simons Bistro", "Denmark"));
                order.Add(new OrdersDetails(2, "ANATR", 2, "Queen Cozinha", "Brazil"));
                order.Add(new OrdersDetails(3, "ANTON", 3, "Frankenversand", "Germany"));
                order.Add(new OrdersDetails(4, "BLONP", 4, "Ernst Handel", "Austria"));
                order.Add(new OrdersDetails(5, "BOLID", 5, "Hanari Carnes", "Switzerland"));
                order.Add(new OrdersDetails(6, "ALFKI", 6, "Smith Foods", "UK"));
                order.Add(new OrdersDetails(7, "ANATR", 7, "La Cuisine", "France"));
                order.Add(new OrdersDetails(8, "ANTON", 8, "Gourmet Market", "USA"));
                order.Add(new OrdersDetails(9, "BLONP", 9, "Pasta Supremo", "Italy"));
                order.Add(new OrdersDetails(10, "BOLID", 10, "Frankenversand", "Germany"));
            }
            return order;
        }

        public int? OrderID { get; set; }
        public string? CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public string? ShipName { get; set; }
        public string? ShipCountry { get; set; }
    }
}

{% endhighlight %}

{% highlight cs tabtitle="EmployeeData.cs" %}

namespace EditTemplate.Models
{
    public class EmployeeData
    {
            public int? EmployeeID { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Department { get; set; }
            public string? Email { get; set; }
            public string? PhoneNumber { get; set; }

            public static List<EmployeeData> GetAllRecords()
            {
                return new List<EmployeeData>
                {
                    new EmployeeData { EmployeeID = 1, FirstName = "John", LastName = "Doe", Department = "Sales", Email = "john.doe@example.com", PhoneNumber = "123-456-7890" },
                    new EmployeeData { EmployeeID = 2, FirstName = "David", LastName = "Smith", Department = "Marketing", Email = "david.smith@example.com", PhoneNumber = "987-654-3210" },
                    new EmployeeData { EmployeeID = 3, FirstName = "Maria", LastName = "Gonzalez", Department = "HR", Email = "maria.gonzalez@example.com", PhoneNumber = "456-789-0123" },
                    new EmployeeData { EmployeeID = 4, FirstName = "Sophia", LastName = "Brown", Department = "Finance", Email = "sophia.brown@example.com", PhoneNumber = "321-654-0987" },
                    new EmployeeData { EmployeeID = 5, FirstName = "James", LastName = "Wilson", Department = "IT", Email = "james.wilson@example.com", PhoneNumber = "654-321-7654" },
                    new EmployeeData { EmployeeID = 6, FirstName = "Emma", LastName = "Taylor", Department = "Operations", Email = "emma.taylor@example.com", PhoneNumber = "213-546-8790" },
                    new EmployeeData { EmployeeID = 7, FirstName = "Daniel", LastName = "Anderson", Department = "Logistics", Email = "daniel.anderson@example.com", PhoneNumber = "789-654-3210" },
                    new EmployeeData { EmployeeID = 8, FirstName = "Olivia", LastName = "Thomas", Department = "Procurement", Email = "olivia.thomas@example.com", PhoneNumber = "567-890-1234" },
                    new EmployeeData { EmployeeID = 9, FirstName = "Michael", LastName = "Harris", Department = "R&D", Email = "michael.harris@example.com", PhoneNumber = "890-123-4567" },
                    new EmployeeData { EmployeeID = 10, FirstName = "Lucas", LastName = "Martin", Department = "Customer Service", Email = "lucas.martin@example.com", PhoneNumber = "345-678-9012" },
                };
            }
    }
}

{% endhighlight %}
{% endtabs %}

**7. Create an API controller**

Create an API controller (aka, **GridController.cs and EmployeesController.cs**) file under **Controllers** folder that helps to establish data communication with the Grid.

  * The **GetOrderData** method retrieves sample order data. Replace it with your custom logic to fetch data from a database or other sources.
  * The **GetEmployeeDetails** method retrieves sample employee data. Replace it with your custom logic to fetch data from a database or other sources.

{% tabs %}
{% highlight cs tabtitle="GridController.cs" %}

using EditTemplate.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;

namespace EditTemplate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GridController : ControllerBase
    {
        /// <summary>
        /// Retrieves the list of orders.
        /// </summary>
        /// <returns>Retrieve data from the data source.</returns>
        [HttpGet]
        public List<OrdersDetails> GetOrdersDetails()
        {
            return OrdersDetails.GetAllRecords().ToList();
        }

        /// <summary>
        /// Handles server-side paging and returns the processed data.
        /// </summary>
        /// <returns>Returns the paged data and total record count in result and count format.</returns>
        [HttpPost]
        public object Post([FromBody] DataManagerRequest DataManagerRequest)
        {
            // Retrieve data source and convert to queryable.
            IQueryable<OrdersDetails> DataSource = GetOrdersDetails().AsQueryable();

            // Get the total records count.
            int totalRecordsCount = DataSource.Count();

            // Handling Paging in UrlAdaptor.
            if (DataManagerRequest.Skip != 0)
            {
                DataSource = DataOperations.PerformSkip(DataSource, DataManagerRequest.Skip);
                //Add custom logic here if needed and remove above method.
            }
            if (DataManagerRequest.Take != 0)
            {
                DataSource = DataOperations.PerformTake(DataSource, DataManagerRequest.Take);
                //Add custom logic here if needed and remove above method.
            }
            // Get total records count.
            int totalRecordsCount = DataSource.Count();
            
            // Return data and count.
           return new { result = DataSource, count = totalRecordsCount };
        }

        /// <summary>
        /// Inserts a new data item into the data collection.
        /// </summary>
        /// <param name="value">It contains the new record detail which is need to be inserted.</param>
        /// <returns>Returns void.</returns>
        [HttpPost("Insert")]
        public void Insert([FromBody] CRUDModel<OrdersDetails> newRecord)
        {
            if (newRecord.value != null)
            {
                // Add the new record to the data collection.
                OrdersDetails.GetAllRecords().Insert(0, newRecord.value);
            }
        }

        /// <summary>
        /// Update a existing data item from the data collection.
        /// </summary>
        /// <param name="updatedRecord">It contains the updated record detail which is need to be updated.</param>
        /// <returns>Returns void.</returns>
        [HttpPost("Update")]
        public void Update([FromBody] CRUDModel<OrdersDetails> updatedRecord)
        {
            var updatedOrder = updatedRecord.value;
            if (updatedOrder != null)
            {
                var data = OrdersDetails.GetAllRecords().FirstOrDefault(or => or.OrderID == updatedOrder.OrderID);
                if (data != null)
                {
                    // Update the existing record.
                    data.OrderID = updatedOrder.OrderID;
                    data.CustomerID = updatedOrder.CustomerID;
                    data.EmployeeID = updatedOrder.EmployeeID;
                    data.ShipCountry = updatedOrder.ShipCountry;
                    // Update other properties similarly.
                }
            }
        }

        /// <summary>
        /// Remove a specific data item from the data collection.
        /// </summary>
        /// <param name="deletedRecord">It contains the specific record detail which is need to be removed.</param>
        /// <return>Returns void.</return>
        [HttpPost("Remove")]
        public void Remove([FromBody] CRUDModel<OrdersDetails> deletedRecord)
        {
            // Get the key value from the deletedRecord.
            int orderId = int.Parse(deletedRecord.key.ToString());
            var data = OrdersDetails.GetAllRecords().FirstOrDefault(OrdersDetails => OrdersDetails.OrderID == orderId);
            if (data != null)
            {
                // Remove the record from the data collection.
                OrdersDetails.GetAllRecords().Remove(data);
            }
        }

        public class CRUDModel<T> where T : class
        {
            public string? action { get; set; }
            public string? keyColumn { get; set; }
            public object? key { get; set; }
            public T? value { get; set; }
            public List<T>? added { get; set; }
            public List<T>? changed { get; set; }
            public List<T>? deleted { get; set; }
            public IDictionary<string, object>? @params { get; set; }
        }
    }
}

{% endhighlight %}

{% highlight cs tabtitle="EmployeesController.cs" %}

using EditTemplate.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Blazor;

namespace EditTemplate.Controllers
{
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        /// <summary>
        /// Retrieves all employee data from the data source.
        /// </summary>
        /// <returns>Returns the full list of employee data.</returns>
        [HttpGet]
        [Route("api/[controller]")]
        public List<EmployeeData> GetEmployeeDetails()
        {
            var data = EmployeeData.GetAllRecords().ToList();
            return data;
        }

        /// <summary>
        /// Returns all employee data for the POST request.
        /// </summary>
        /// <returns>Returns the full employee data as an IQueryable collection.</returns>
        [HttpPost]
        [Route("api/[controller]")]
        public object Post([FromBody] DataManagerRequest DataManagerRequest)
        {
            // Retrieve data from the data source (e.g., database).
            IQueryable<EmployeeData> DataSource = GetEmployeeDetails().AsQueryable();
            return DataSource;
        }
    }
}

{% endhighlight %}
{% endtabs %}

**8. Add Grid, AutoComplete and configure with server**

To implement a Grid with an editable foreign key column using **AutoComplete** with remote data, add the following code to the **Home.razor** file:

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Data
@using EditTemplate.Models
@using Syncfusion.Blazor.DropDowns

<SfGrid TValue="OrdersDetails" ID="Grid" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <SfDataManager Url="https://localhost:xxxx/api/grid" InsertUrl="https://localhost:xxxx/api/grid/Insert" UpdateUrl="https://localhost:xxxx/api/grid/Update" RemoveUrl="https://localhost:xxxx/api/grid/Remove" Adaptor="Adaptors.UrlAdaptor">
    </SfDataManager>  //Use remote server host number instead ****. 
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field="@nameof(OrdersDetails.OrderID)" HeaderText="Order ID" IsPrimaryKey="true" Width="150"></GridColumn>
        <GridForeignColumn TValue="EmployeeData" Field=@nameof(OrdersDetails.EmployeeID) HeaderText="Employee Name" ForeignKeyValue="FirstName" Width="150">
            <ChildContent>
                <Syncfusion.Blazor.Data.SfDataManager Url="https://localhost:xxxx/api/employees" CrossDomain="true" Adaptor="Syncfusion.Blazor.Adaptors.UrlAdaptor">
                </Syncfusion.Blazor.Data.SfDataManager>
            </ChildContent>
             <EditTemplate>
                @{
                    var data = context as OrdersDetails;
                }
                <SfAutoComplete ID="CustomerID" TValue="int?" TItem="EmployeeData" @bind-Value="data.EmployeeID">
                    <Syncfusion.Blazor.Data.SfDataManager Url="https://localhost:xxxx/api/employees" 
                        Adaptor="Syncfusion.Blazor.Adaptors.UrlAdaptor"> //Use remote server host number instead ****.
                    </Syncfusion.Blazor.Data.SfDataManager>
                    <AutoCompleteFieldSettings Text="FirstName" Value="EmployeeID" />                    
                </SfAutoComplete>
            </EditTemplate>
        </GridForeignColumn>
        <GridColumn Field="@nameof(OrdersDetails.ShipName)" HeaderText="Ship Name" Width="150"></GridColumn>
        <GridColumn Field="@nameof(OrdersDetails.ShipCountry)" HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
@code {

    public class OrdersDetails
    {
        public int? OrderID { get; set; }
        public int? EmployeeID { get; set; }
        public string? ShipCountry { get; set; }
        public string? ShipName { get; set; }
    }

    public class EmployeeData
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}


**5. Run the application**

When you run the application, the Grid  will display data fetched from the API.

![Edit template in foreign key column using remote data](./images/edit-template.gif)
