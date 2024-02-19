---
layout: post
title: Foreign key column in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Foreign key column in the Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Foreign key column in Blazor DataGrid component

The Foreign key column in the Syncfusion Grid component allows you to display related data from a foreign key data source in a column within the grid. This feature is particularly useful when you have a column in the grid that represents a foreign key relationship with another data source.

Foreign key column can be enabled by using [ForeignDataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html), [ForeignKeyField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyField) and [ForeignKeyValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyValue) properties of **GridForeignColumn** directive.

Define the foreign key column in the grid using the following properties:

* [ForeignDataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) - Specifies the foreign data source that contains the related data.
* [ForeignKeyField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyField) - Maps the column name in the grid to the field in the foreign data source that represents the foreign key relationship.
* [ForeignKeyValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyValue) -Specifies the field from the foreign data source that should be displayed in the grid as the related data.

## Binding local data

The Syncfusion Grid component provides a convenient way to bind local data to a foreign key column. This allows you to display related data from a local data source within the grid. Here’s an example of how to bind local data to a Foreign Key column in Syncfusion Grid:

In this example, data is the local data source for the Grid, and **Employee Name** is the local data source for the foreign key column. The ForeignKeyValue property is set to **FirstName** which represents the field name in the  **Employee Name** that you want to display in the foreign key column.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" Height="315" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridForeignColumn Field=@nameof(OrderData.EmployeeID) HeaderText="Employee Name" ForeignKeyValue="FirstName" ForeignDataSource="@Employees" Width="150"></GridForeignColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Right" Width="120"></GridColumn>
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjrqNPVEApFgHAZq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Binding remote data

The Foreign key column in Syncfusion Grid allows you to bind remote data for a foreign key column. You can use  ```SfDataManager``` component instead of using ```DataSource```  property. 

This example demonstrates how to use the foreign key column with remote data binding using the ```ODataV4Adaptor``` in the grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
         <GridForeignColumn TValue="EmployeeData" Field=@nameof(OrderData.EmployeeID) HeaderText="Employee Name" ForeignKeyValue="FirstName" Width="150">
            <Syncfusion.Blazor.Data.SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svc/Employees" CrossDomain="true" Adaptor=" Syncfusion.Blazor.Adaptors.ODataV4Adaptor">
            </Syncfusion.Blazor.Data.SfDataManager>
        </GridForeignColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Right" Width="120"></GridColumn>
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
      public class EmployeeData
    {
        public static List<EmployeeData> Employees = new List<EmployeeData>();
        public EmployeeData()
        {

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
                    Orders.Add(new OrderData(10248, 1, "Reims", 32.18));
                    Orders.Add(new OrderData(10249, 2, "Münster", 33.33));
                    Orders.Add(new OrderData(10250, 3, "Rio de Janeiro", 12.35));
                    Orders.Add(new OrderData(10251, 4, "Reims", 22.65));
                    Orders.Add(new OrderData(10252, 5, "Lyon", 63.43));
                    Orders.Add(new OrderData(10253, 6, "Charleroi", 56.98));
                    Orders.Add(new OrderData(10254, 7, "Rio de Janeiro", 45.65));
                    Orders.Add(new OrderData(10255, 8, "Münster", 11.13));
                    Orders.Add(new OrderData(10256, 9, "Reims", 87.59));
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

 {% previewsample "https://blazorplayground.syncfusion.com/embed/LjrJXMWBgWWmRbjx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} 

> * For remote data, the sorting and grouping is done based on [ForeignKeyField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyField) instead of [ForeignKeyValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyValue).
> * If [ForeignKeyField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyField) is not defined, then the column uses [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field) property of **GridColumn** tag helper.

## Use edit template in foreign key column

The Syncfusion Grid provides support for using an edit template in a foreign key column. By default, a dropdown component is used for editing foreign key column. Other editable components can be rendered using the EditTemplate feature of Grid. The following example demonstrates the way of using edit template with ComboBox component in the foreign column.

In the following code example, the Employee Name is a foreign key column. When editing, the ComboBox component is rendered instead of DropDownList.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using BlazorApp1.Data

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
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Right" Width="120"></GridColumn>
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

## Customize filter UI in foreignkey column

The Syncfusion Grid allows you to customize the filtering user interface (UI) for foreign key columns by using the [FilterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_FilterTemplate)  property. By default, a dropdown component is used for filtering foreign key columns. However, you can create your own custom filtering UI by [FilterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_FilterTemplate) property. Here’s an example that demonstrates how to create a custom filtering UI in a foreign key column:

> For all filter types other than FilterBar, filtering parameters will be sent in the form of `PredicateModel<T>`. Here, T represents the type of `ForeignKeyValue` property when using the foreignkey column.

In this example, a DropDownList component is rendered as the filter UI for the **“EmployeeID”** foreign key column. The  **DataSource** property of the `SfDropDownList` component is set to the employees data, and the Fields property is configured to display the FirstName field as the text and EmployeeID field as the value. The `value` property is set to the current filter value of the column.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" Height="315" AllowFiltering="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridForeignColumn Field=@nameof(OrderData.EmployeeID) HeaderText="Employee Name" ForeignKeyValue="FirstName" ForeignDataSource="@Employees" Width="150">
            <FilterTemplate>
                <SfDropDownList Placeholder="FirstName" ID="FirstName" @bind-Value="@((context as PredicateModel<string>).Value)" TItem="EmployeeData" TValue="string" DataSource="@Employees">
                    <DropDownListFieldSettings Value="FirstName" Text="FirstName"></DropDownListFieldSettings>
                </SfDropDownList>
            </FilterTemplate>
        </GridForeignColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Right" Width="120"></GridColumn>
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
                    Employees.Add(new EmployeeData(1, "Nancy"));
                    Employees.Add(new EmployeeData(2, "Andrew"));
                    Employees.Add(new EmployeeData(3, "Janet"));
                    Employees.Add(new EmployeeData(4, "Nancy"));
                    Employees.Add(new EmployeeData(5, "Margaret"));
                    Employees.Add(new EmployeeData(6, "Steven"));
                    Employees.Add(new EmployeeData(7, "Janet"));
                    Employees.Add(new EmployeeData(8, "Andrew"));
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
                    Orders.Add(new OrderData(10248, 1, "Reims", 32.18));
                    Orders.Add(new OrderData(10249, 2, "Münster", 33.33));
                    Orders.Add(new OrderData(10250, 3, "Rio de Janeiro", 12.35));
                    Orders.Add(new OrderData(10251, 4, "Reims", 22.65));
                    Orders.Add(new OrderData(10252, 5, "Lyon", 63.43));
                    Orders.Add(new OrderData(10253, 6, "Charleroi", 56.98));
                    Orders.Add(new OrderData(10254, 7, "Rio de Janeiro", 45.65));
                    Orders.Add(new OrderData(10255, 8, "Münster", 11.13));
                    Orders.Add(new OrderData(10256, 9, "Reims", 87.59));
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNhqWMXHAlMwnaCg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> [View Sample in GitHub.](https://github.com/SyncfusionExamples/blazor-datagrid-customize-filter-ui-in-foreignkey-column)

## Use filter bar template in foreign key column

You can use the filter  template in a foreign key column in Grid by using the **FilterTemplate** property. This allows you to customize the filter bar for the foreign key column with a custom component or HTML template. Here’s an example that demonstrates how to use a Filter  template in a foreign key column:

In this example, the “EmployeeID” column is a foreign key column, and the filter function is used as the filter template for this column. The filter function can be defined in your component code and should return the desired component or HTML template for the filter bar. The column header shows the custom filter bar template and you can select filter value by using the DropDown options.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using BlazorApp1.Data

<SfGrid @ref="Grid" DataSource="@Orders" Height="315" AllowFiltering="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridForeignColumn Field=@nameof(OrderData.EmployeeID) HeaderText="Employee Name" ForeignKeyValue="FirstName" ForeignDataSource="@Employees" Width="150">
            <FilterTemplate>
                <SfDropDownList PlaceHolder="Employee Name" ID="EmployeeID" Value="@((string)(context as PredicateModel).Value)" DataSource="@Dropdown" TValue="string" TItem="EmployeeData">
                    <DropDownListEvents ValueChange="@Change" TItem="EmployeeData" TValue="string"></DropDownListEvents>
                    <DropDownListFieldSettings Value="FirstName" Text="FirstName"></DropDownListFieldSettings>
                </SfDropDownList>
            </FilterTemplate>
        </GridForeignColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
    public List<EmployeeData> Employees { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
        Employees = EmployeeData.GetAllRecords();
    }
    public void Change(@Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, EmployeeData> args)
    {
        if (args.Value == "All")
        {
            Grid.ClearFilteringAsync();
            Grid.RefreshAsync();
        }
        else
        {
            Grid.FilterByColumnAsync("EmployeeID", "contains", args.Value);
        }
    }
    List<EmployeeData> Dropdown = new List<EmployeeData>
    {
        new EmployeeData() { FirstName= "All" },
        new EmployeeData() { FirstName= "Andrew" },
        new EmployeeData() { FirstName= "Janet" },
        new EmployeeData() { FirstName= "Margaret" },
        new EmployeeData() { FirstName= "Steven" },
    };
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXBAiiZngvqDDFvZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Prevent filter query generation for foreignkey column

By default, a filter query for the foreignkey column will be generated based on the foreignkey value. You can prevent the default filter query generation for the foreignkey column and add the custom filter query. This can be achieved by setting the [PreventFilterQuery](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ActionEventArgs-1.html#Syncfusion_Blazor_Grids_ActionEventArgs_1_PreventFilterQuery) argument of the [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnActionBegin) event to true.

In the following code sample, you can prevent default filter query generation using the `PreventFilterQuery` property and generate a custom filter query to execute a filter operation.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using System.ComponentModel.DataAnnotations;
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using Newtonsoft.Json

<SfGrid ID="Grid" @ref="Grid" Query="@currentQuery" TValue="Book" Toolbar="@ToolbarItems" Height="100%" AllowPaging="true" AllowSorting="true" AllowFiltering="true">
    <GridPageSettings PageSize="10" PageSizes="true"></GridPageSettings>
    <SfDataManager Url="http://localhost:64956/odata/books" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
    <GridEvents TValue="Book" OnActionBegin="OnActionBegin"/>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="@EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Book.Id) IsPrimaryKey="true" Width="150"></GridColumn>
        <GridForeignColumn TValue="Customer" Field=@nameof(Book.CustomerId)  AllowFiltering="true" ForeignKeyValue="Name" ForeignKeyField="Id" HeaderText="Name" Width="100" >
            <SfDataManager Url="http://localhost:64956/odata/customers" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
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


## Enable multiple foreign key columns

The Syncfusion Grid component supports the feature of enabling multiple foreign key columns with editing options. This allows users to display columns from foreign data sources in the Grid component.

In the following example, Employee Name and Ship City are foreign key columns that display the FirstName and ShipCity columns from foreign data.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" Height="315" Toolbar="@(new List<string>() { "Add", "Delete", "Update", "Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridForeignColumn Field=@nameof(OrderData.EmployeeID) HeaderText="Customer Name" ForeignKeyValue="FirstName" ForeignDataSource="@Employees" Width="150"></GridForeignColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridForeignColumn Field=@nameof(OrderData.ShipID) HeaderText=" Ship City" ForeignKeyValue="ShipCity" ForeignDataSource="@Countries" Width="150"></GridForeignColumn>
    </GridColumns>
</SfGrid>
@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
    public List<ShipCountry> Countries { get; set; }
    public List<EmployeeData> Employees { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
        Employees = EmployeeData.GetAllRecords();
        Countries = ShipCountry.GetAllRecords();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
    public class ShipCountry
    {
        public static List<ShipCountry> Countries = new List<ShipCountry>();
        public ShipCountry() 
        { 

        }
        public ShipCountry(int? shipID, string shipCity)
        {
            ShipID = shipID;
            ShipCity = shipCity;
        }
        public static List<ShipCountry> GetAllRecords()
        {
            if (Countries.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Countries.Add(new ShipCountry(1, "US"));
                    Countries.Add(new ShipCountry(2, "France"));
                    Countries.Add(new ShipCountry(3, "UK"));
                    Countries.Add(new ShipCountry(4, "Italy"));
                    Countries.Add(new ShipCountry(5, "Australia"));
                    Countries.Add(new ShipCountry(6, "Australia"));
                    Countries.Add(new ShipCountry(7, "UK"));
                    Countries.Add(new ShipCountry(8, "Andrew"));
                    Countries.Add(new ShipCountry(9, "UK"));
                    code += 5;
                }
            }
            return Countries;
        }
        public int? ShipID { get; set; }
        public string ShipCity { get; set; }
    }
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
        public OrderData(int? OrderID, int? EmployeeID, int? ShipID, double? Freight)
        {
           this.OrderID = OrderID;
           this.EmployeeID = EmployeeID;
           this.ShipID = ShipID;
           this.Freight = Freight;            
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248,1, 1, 32.18));
                    Orders.Add(new OrderData(10249,2, 2,33.33));
                    Orders.Add(new OrderData(10250,3, 3,12.35));
                    Orders.Add(new OrderData(10251,4, 4, 22.65));
                    Orders.Add(new OrderData(10252,5, 5, 63.43));
                    Orders.Add(new OrderData(10253,6, 6,56.98));
                    Orders.Add(new OrderData(10254,7, 7, 45.65));
                    Orders.Add(new OrderData(10255,8, 8, 11.13));
                    Orders.Add(new OrderData(10256,9, 9, 87.59));
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public int? EmployeeID { get; set; }
        public int? ShipID { get; set; }
        public double? Freight { get; set; }
    }  
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXLUsWDnKvoInklv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> You can find the fully working sample [here](https://github.com/SyncfusionExamples/blazor-datagrid-prevent-query-generation-for-foriegnkey-column).


