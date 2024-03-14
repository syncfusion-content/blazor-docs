---
layout: post
title: Column Chooser in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about column chooser in the Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Column Chooser in Blazor DataGrid

The column chooser feature in the Syncfusion Blazor Grid component allows you to dynamically show or hide columns. This feature can be enabled by defining the [ShowColumnChooser](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ShowColumnChooser) property as **true**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" ShowColumnChooser="true" Toolbar=@ToolbarItems>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.DateOnly" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public string[] ToolbarItems = new string[] { "ColumnChooser" };
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
        public OrderData(int? OrderID,string ShipCountry,double Freight,DateTime OrderDate)
        {
           this.OrderID = OrderID;          
           this.ShipCountry = ShipCountry;           
           this.Freight = Freight;
           this.OrderDate = OrderDate;            
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248,  "France", 33.33,new DateTime(1996,07,07)));
                    Orders.Add(new OrderData(10249,  "Germany", 89.76, new DateTime(1996, 07, 12)));
                    Orders.Add(new OrderData(10250,  "Brazil",78.67, new DateTime(1996, 07, 13)));
                    Orders.Add(new OrderData(10251,  "Belgium", 55.65, new DateTime(1996, 07, 14)));
                    Orders.Add(new OrderData(10252, "Venezuela",11.09, new DateTime(1996, 07, 15)));
                    Orders.Add(new OrderData(10253, "Venezuela",98.98, new DateTime(1996, 07, 16)));
                    Orders.Add(new OrderData(10254, "Belgium", 78.75, new DateTime(1996, 07, 17)));
                    Orders.Add(new OrderData(10255, "Germany", 44.07, new DateTime(1996, 07, 18)));
                    Orders.Add(new OrderData(10256, "France", 67.74, new DateTime(1996, 07, 19)));
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }                
        public DateTime OrderDate { get; set; }      
        public string ShipCountry { get; set; }
        public double Freight { get; set; }

    } 
{% endhighlight %}
{% endtabs %}

> The column chooser dialog displays the header text of each column by default. If the header text is not defined for a column, the corresponding column field name is displayed instead.

The following GIF represents the column chooser functionality in DataGrid

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZhACCjWydDhkWrH?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Hide column in column chooser dialog

You can hide the column names in column chooser by defining the [ShowInColumnChooser](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ShowInColumnChooser) property as false. This feature is useful when working with a large number of columns or when you want to limit the number of columns that are available for selection in the column chooser dialog.

In this example, the [ShowInColumnChooser](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ShowInColumnChooser) property is set to false for the OrderID column. As a result, the OrderID column will not be displayed in the column chooser dialog.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" ShowColumnChooser="true" Toolbar=@ToolbarItems>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" ShowInColumnChooser="false" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.DateOnly" TextAlign=" Syncfusion.Blazor.Grids.TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Visible="false" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public string[] ToolbarItems = new string[] { "ColumnChooser" };
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
        public OrderData(int? OrderID,string ShipCountry,double Freight,DateTime OrderDate,string ShipCity)
        {
           this.OrderID = OrderID;          
           this.ShipCountry = ShipCountry;           
           this.Freight = Freight;
           this.OrderDate = OrderDate;     
           this.ShipCity = ShipCity;
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248,  "France", 33.33,new DateTime(1996,07,07), "Reims"));
                    Orders.Add(new OrderData(10249,  "Germany", 89.76, new DateTime(1996, 07, 12), "Münster"));
                    Orders.Add(new OrderData(10250,  "Brazil",78.67, new DateTime(1996, 07, 13), "Rio de Janeiro"));
                    Orders.Add(new OrderData(10251,  "Belgium", 55.65, new DateTime(1996, 07, 14), "Lyon"));
                    Orders.Add(new OrderData(10252, "Venezuela",11.09, new DateTime(1996, 07, 15), "Charleroi"));
                    Orders.Add(new OrderData(10253, "Venezuela",98.98, new DateTime(1996, 07, 16), "Lyon"));
                    Orders.Add(new OrderData(10254, "Belgium", 78.75, new DateTime(1996, 07, 17), "Rio de Janeiro"));
                    Orders.Add(new OrderData(10255, "Germany", 44.07, new DateTime(1996, 07, 18), "Münster"));
                    Orders.Add(new OrderData(10256, "France", 67.74, new DateTime(1996, 07, 19), "Reims"));
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }                
        public DateTime OrderDate { get; set; }      
        public string ShipCountry { get; set; }
        public double Freight { get; set; }
        public string ShipCity { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjVUCijMSnycYcHm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> The `ShowInColumnChooser` property is applied to each element individually. By setting it to false, you can hide specific columns from the column chooser dialog.


## Open column chooser by external button

The Syncfusion Blazor Grid provides the flexibility to open the column chooser dialog on a web page using an external button. By default, the column chooser button is displayed in the right corner of the grid component, and clicking the button opens the column chooser dialog below it. However, you can programmatically open the column chooser dialog at specific X and Y axis positions by using the [OpenColumnChooserAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_OpenColumnChooserAsync_System_Nullable_System_Double__System_Nullable_System_Double__) method.

Here’s an example of how to open the column chooser in the Grid using an external button:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using BlazorApp1.Data

<SfButton OnClick="Show" CssClass="e-primary" IsPrimary="true" Content="Open column chooser"></SfButton>

<SfGrid @ref="DefaultGrid" DataSource="@Orders" ShowColumnChooser="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" ShowInColumnChooser="false" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.DateOnly" TextAlign=" Syncfusion.Blazor.Grids.TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Visible="false" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    private SfGrid<OrderData> DefaultGrid;
    public List<OrderData> Orders { get; set; }   
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();       
    }  
    public void Show()
    {
        this.DefaultGrid.OpenColumnChooserAsync(100, 40);
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
        public OrderData(int? OrderID,string ShipCountry,double Freight,DateTime OrderDate,string ShipCity)
        {
           this.OrderID = OrderID;          
           this.ShipCountry = ShipCountry;           
           this.Freight = Freight;
           this.OrderDate = OrderDate;     
           this.ShipCity = ShipCity;
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248,  "France", 33.33,new DateTime(1996,07,07), "Reims"));
                    Orders.Add(new OrderData(10249,  "Germany", 89.76, new DateTime(1996, 07, 12), "Münster"));
                    Orders.Add(new OrderData(10250,  "Brazil",78.67, new DateTime(1996, 07, 13), "Rio de Janeiro"));
                    Orders.Add(new OrderData(10251,  "Belgium", 55.65, new DateTime(1996, 07, 14), "Lyon"));
                    Orders.Add(new OrderData(10252, "Venezuela",11.09, new DateTime(1996, 07, 15), "Charleroi"));
                    Orders.Add(new OrderData(10253, "Venezuela",98.98, new DateTime(1996, 07, 16), "Lyon"));
                    Orders.Add(new OrderData(10254, "Belgium", 78.75, new DateTime(1996, 07, 17), "Rio de Janeiro"));
                    Orders.Add(new OrderData(10255, "Germany", 44.07, new DateTime(1996, 07, 18), "Münster"));
                    Orders.Add(new OrderData(10256, "France", 67.74, new DateTime(1996, 07, 19), "Reims"));
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }                
        public DateTime OrderDate { get; set; }      
        public string ShipCountry { get; set; }
        public double Freight { get; set; }
        public string ShipCity { get; set; }
    }
{% endhighlight %}
{% endtabs %}

<!-- {% previewsample "https://blazorplayground.syncfusion.com/embed/BDLgWMNMIHuMlAUe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} -->

## Customize column chooser dialog size

The column chooser dialog in Syncfusion Blazor Grid comes with default size, but you can modify its height and width as per your specific needs using CSS styles.

To customize the column chooser dialog size, you can use the following CSS styles:

```csharp
<style> 
    .e-grid .e-dialog.e-ccdlg {         
        max-height: 600px !important; 
        width: 300px !important; 
    } 
    .e-grid .e-ccdlg .e-cc-contentdiv { 
        height: 250px !important; 
        width: 250px !important;         
    } 
</style> 
```
> Here, **!important** attribute is used to apply custom styles since the column chooser dialog position will be calculated dynamically based on content.

This can be demonstrated in the following sample:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid ID="Grid" DataSource="@Orders" ShowColumnChooser="true" Toolbar=@ToolbarItems>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" ShowInColumnChooser="false" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.DateOnly" TextAlign=" Syncfusion.Blazor.Grids.TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Visible="false" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
<style>
    .e-grid .e-dialog.e-ccdlg {
        max-height: 600px !important;
        width: 300px !important;
    }

    .e-grid .e-ccdlg .e-cc-contentdiv {
        height: 250px !important;
        width: 250px !important;
    }
</style>
@code {
    private SfGrid<OrderData> DefaultGrid;
    public string[] ToolbarItems = new string[] { "ColumnChooser" };
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
        public OrderData(int? OrderID,string ShipCountry,double Freight,DateTime OrderDate,string ShipCity)
        {
           this.OrderID = OrderID;          
           this.ShipCountry = ShipCountry;           
           this.Freight = Freight;
           this.OrderDate = OrderDate;     
           this.ShipCity = ShipCity;
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248,  "France", 33.33,new DateTime(1996,07,07), "Reims"));
                    Orders.Add(new OrderData(10249,  "Germany", 89.76, new DateTime(1996, 07, 12), "Münster"));
                    Orders.Add(new OrderData(10250,  "Brazil",78.67, new DateTime(1996, 07, 13), "Rio de Janeiro"));
                    Orders.Add(new OrderData(10251,  "Belgium", 55.65, new DateTime(1996, 07, 14), "Lyon"));
                    Orders.Add(new OrderData(10252, "Venezuela",11.09, new DateTime(1996, 07, 15), "Charleroi"));
                    Orders.Add(new OrderData(10253, "Venezuela",98.98, new DateTime(1996, 07, 16), "Lyon"));
                    Orders.Add(new OrderData(10254, "Belgium", 78.75, new DateTime(1996, 07, 17), "Rio de Janeiro"));
                    Orders.Add(new OrderData(10255, "Germany", 44.07, new DateTime(1996, 07, 18), "Münster"));
                    Orders.Add(new OrderData(10256, "France", 67.74, new DateTime(1996, 07, 19), "Reims"));
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }                
        public DateTime OrderDate { get; set; }      
        public string ShipCountry { get; set; }
        public double Freight { get; set; }
        public string ShipCity { get; set; }
    }  
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjLgCMZLiJiGNLIf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Change default search operator of the column chooser

The column chooser dialog in the Syncfusion Blazor Grid provides a search box that allows you to search for column names. By default, the search functionality uses the **StartsWith** operator to match columns and display the results in the column chooser dialog. However, there might be cases where you need to change the default search operator to achieve more precise data matching.

To change the default search operator of the column chooser in Syncfusion Grid, you need to use the [Operator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Operator.html) property of the [GridColumnChooserSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumnChooserSettings.html) class.

Here’s an example of how to change the default search operator of the column chooser to **Contains** in the Blazor Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid ID="Grid" DataSource="@Orders" ShowColumnChooser="true" Toolbar=@ToolbarItems>
    <GridColumnChooserSettings Operator="Operator.Contains"></GridColumnChooserSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.DateOnly" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Visible="false" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public string[] ToolbarItems = new string[] { "ColumnChooser" };
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
        public OrderData(int? OrderID,string ShipCountry,double Freight,DateTime OrderDate,string ShipCity)
        {
           this.OrderID = OrderID;          
           this.ShipCountry = ShipCountry;           
           this.Freight = Freight;
           this.OrderDate = OrderDate;     
           this.ShipCity = ShipCity;
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248,  "France", 33.33,new DateTime(1996,07,07), "Reims"));
                    Orders.Add(new OrderData(10249,  "Germany", 89.76, new DateTime(1996, 07, 12), "Münster"));
                    Orders.Add(new OrderData(10250,  "Brazil",78.67, new DateTime(1996, 07, 13), "Rio de Janeiro"));
                    Orders.Add(new OrderData(10251,  "Belgium", 55.65, new DateTime(1996, 07, 14), "Lyon"));
                    Orders.Add(new OrderData(10252, "Venezuela",11.09, new DateTime(1996, 07, 15), "Charleroi"));
                    Orders.Add(new OrderData(10253, "Venezuela",98.98, new DateTime(1996, 07, 16), "Lyon"));
                    Orders.Add(new OrderData(10254, "Belgium", 78.75, new DateTime(1996, 07, 17), "Rio de Janeiro"));
                    Orders.Add(new OrderData(10255, "Germany", 44.07, new DateTime(1996, 07, 18), "Münster"));
                    Orders.Add(new OrderData(10256, "France", 67.74, new DateTime(1996, 07, 19), "Reims"));
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }                
        public DateTime OrderDate { get; set; }      
        public string ShipCountry { get; set; }
        public double Freight { get; set; }
        public string ShipCity { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDhgsCXRrcwxcGEU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


## Column chooser template

Using the column chooser template, you can customize the column chooser dialog using [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumnChooserSettings.html#Syncfusion_Blazor_Grids_GridColumnChooserSettings_Template) and [FooterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumnChooserSettings.html#Syncfusion_Blazor_Grids_GridColumnChooserSettings_FooterTemplate) of the [GridColumnChooserSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumnChooserSettings.html) component. You can access the parameters passed to the templates using implicit parameter named context.

### Customize the content of column chooser

 The [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumnChooserSettings.html#Syncfusion_Blazor_Grids_GridColumnChooserSettings_Template) tag in the [GridColumnChooserSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumnChooserSettings.html) component is used to customize the content in the column chooser dialog. You can type cast the context as [ColumnChooserTemplateContext](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnChooserTemplateContext.html) to get columns inside content template.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids;
@using BlazorApp.Data
<SfGrid ID="Grid" @ref="Grid" AllowPaging="true" DataSource="@Orders" ShowColumnChooser="true" Toolbar="@ToolbarItems">
    <GridColumnChooserSettings>
        <Template>
            @{
                var ContextData = context as ColumnChooserTemplateContext;
                <CustomComponent @key="ContextData.Columns.Count" ColumnContext="ContextData"></Counter>
            }
        </Template>
         <FooterTemplate>

        </FooterTemplate>
    </GridColumnChooserSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"> </GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"> </GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Visible="false" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) Visible="false" HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.EmployeeID) Visible="false" HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="120"> </GridColumn>
        <GridColumn Field=@nameof(OrderData.FirstName) Visible="false" HeaderText="First Name" Width="150"> </GridColumn>
        <GridColumn Field=@nameof(OrderData.LastName) HeaderText="Last Name" Visible="false" Format="d" Type="ColumnType.Date" Width="130"> </GridColumn>
        <GridColumn Field=@nameof(OrderData.Title) HeaderText="Title" Visible="false" Width="120"> </GridColumn>
        <GridColumn Field=@nameof(OrderData.HireDate) HeaderText="Hire Date" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    #Grid.e-grid .e-ccdlg .e-dlg-content {
        margin-top: 0px;
    }

    .e-list-item.e-level-1.e-checklist.e-focused {
        background-color: none;
    }

    #Grid_ccdlg .e-content {
        overflow-y: unset;
    }
</style>

@code
{
    public SfGrid<OrderData> Grid { get; set; }
    public string[] ToolbarItems = new string[] { "ColumnChooser" };
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
     public OrderData(int? OrderID, string CustomerID, double Freight, DateTime OrderDate, int? EmployeeID, string FirstName, string LastName, string Title, DateTime? HireDate)
     {
         this.OrderID = OrderID;
         this.CustomerID = CustomerID;
         this.Freight = Freight;
         this.OrderDate = OrderDate;
         this.EmployeeID = EmployeeID;
         this.FirstName = FirstName;
         this.LastName = LastName;
         this.Title = Title;
         this.HireDate = HireDate;
     }
     public static List<OrderData> GetAllRecords()
     {
         if (Orders.Count() == 0)
         {
             int code = 10247;
             int EmployeeID = 0;
             for (int i = 1; i < 5; i++)
             {
                 Orders.Add(new OrderData(code + 1, "ALFKI", 33.33, new DateTime(1996, 07, 07), EmployeeID + 1, "Nancy", "Davolio", "Sales Representative", new DateTime(1992, 05, 01)));
                 Orders.Add(new OrderData(code + 2, "ANANTR", 89.76, new DateTime(1996, 07, 12), EmployeeID + 2, "Andrew", "Fuller", "Vice President, Sales", new DateTime(1992, 08, 14)));
                 Orders.Add(new OrderData(code + 3, "ANTON", 78.67, new DateTime(1996, 07, 13), EmployeeID + 3, "Janet", "Leverling", "Sales Manager", new DateTime(1993, 05, 03)));
                 Orders.Add(new OrderData(code + 4, "BLONP", 55.65, new DateTime(1996, 07, 14), EmployeeID + 4, "Margaret", "Peacock", "Inside Sales Coordinator", new DateTime(1963, 08, 30)));
                 Orders.Add(new OrderData(code + 5, "BOLID", 65.65, new DateTime(1996, 07, 15), EmployeeID + 5, "Steven", "Buchanan", "Sales Manager", new DateTime(1973, 08, 25)));
                 code += 5;
                 EmployeeID += 5;
             }
         }
         return Orders;
     }

     public int? OrderID { get; set; }
     public string CustomerID { get; set; }
     public DateTime? OrderDate { get; set; }
     public double? Freight { get; set; }
     public int? EmployeeID { get; set; }
     public string FirstName { get; set; }
     public string LastName { get; set; }
     public string Title { get; set; }
     public DateTime? HireDate { get; set; }

 }
{% endhighlight %}
{% highlight razor tabtitle="customComponent.razor" %}
@using Syncfusion.Blazor.Lists;
@using Syncfusion.Blazor.Inputs;
@using Syncfusion.Blazor.Grids;
@using BlazorApp.Data
@using Model

<div class="setMargin">
    <SfTextBox Placeholder="Search" Input="@OnInput"></SfTextBox>
</div>

<SfListView @ref="ListView" Height="100%" ShowCheckBox="true" DataSource="@CloneData">
    <ListViewFieldSettings TValue="DataModel" Id="Id" Text="Text"></ListViewFieldSettings>
    <ListViewEvents Clicked="OnClicked" Created="@(()=>OnCreated(ColumnContext.Columns))" TValue="DataModel"></ListViewEvents>
</SfListView>

<style>
    .setMargin {
        margin-bottom: 10px;
    }
</style>

@code
{
    public List<DataModel> CloneData { get; set; } = new List<DataModel>();

    [CascadingParameter]
    public SfGrid<OrderData> Grid { get; set; }

    [Parameter]
    public ColumnChooserTemplateContext ColumnContext { get; set; }

    public SfListView<DataModel> ListView { get; set; }

    async Task OnInput(InputEventArgs eventArgs)
    {
        CloneData = DataSource.FindAll(e => e.Text.ToLower().StartsWith(eventArgs.Value.ToLower()));
        await Task.Delay(100);
        await Preselect();
    }

    protected override async Task OnInitializedAsync()
    {
        CloneData = DataSource;
        await Task.Delay(100);
        await Preselect();
    }

    List<DataModel> DataSource = new List<DataModel>
    {
        new DataModel() { Text = "Order ID", Id = "OrderID" },
        new DataModel() { Text = "Customer ID", Id ="CustomerID"},
        new DataModel() { Text = "Employee ID", Id = "EmployeeID" },
        new DataModel() { Text = "First Name", Id = "FirstName"},
        new DataModel() { Text = "Order Date", Id = "OrderDate" },
        new DataModel() { Text = "Last Name", Id = "LastName" },
        new DataModel() { Text = "Hire Date", Id = "HireDate"},
        new DataModel() { Text = "Title", Id = "Title"},
        new DataModel() { Text = "Freight", Id = "Freight"},
    };

    public async Task Preselect()
    {
        var cols = ColumnContext.Columns.FindAll(x => x.Visible == true).ToList();
        var selectlist = new List<DataModel>();
        foreach (var column in cols)
        {
            selectlist.Add(DataSource.Where(x => x.Text == column.HeaderText).FirstOrDefault());
        }
        if (selectlist.Count > 0)
        {
            if (ListView != null)
            {
                await ListView?.CheckItemsAsync(selectlist.AsEnumerable());
            }
        }
    }

    public async Task OnCreated(List<GridColumn> args)
    {
        await Preselect();
    }

    public async Task OnClicked(ClickEventArgs<DataModel> args)
    {
        if (args.IsChecked)
        {
            await Grid.ShowColumnAsync(args.Text);
        }
        else
        {
            await Grid.HideColumnAsync(args.Text);
        }
    }
}
{% endhighlight %}
{% highlight c# tabtitle="Model.cs" %}
namespace Model
{
    public class DataModel
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
    }
}
{% endhighlight %}
{% endtabs %}

> You can build reusable custom component based on your customization need as like above code example.
<br/> In the above example, Syncfusion [ListView](https://blazor.syncfusion.com/documentation/listview/getting-started) component is used as custom component in the content template to show/hide columns.

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDBTXUszLlWhsBgB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor DataGrid with ListView in Column Chooser](./images/blazor-datagrid-column-chooser-content-template.png)

### Customize the footer of column chooser

 The [FooterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumnChooserSettings.html#Syncfusion_Blazor_Grids_GridColumnChooserSettings_FooterTemplate) tag in the  [GridColumnChooserSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumnChooserSettings.html) component is used to customize the footer in the column chooser dialog. You can type cast the context as [ColumnChooserFooterTemplateContext](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnChooserFooterTemplateContext.html) to get columns inside FooterTemplate.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using BlazorApp1.Data

<SfGrid @ref="grid" TValue="OrderData" DataSource="@GridData" ShowColumnChooser="true" Toolbar="@( new List<string>() { "ColumnChooser"})" AllowPaging="true">
    <GridColumnChooserSettings>
        <FooterTemplate>
            @{
                var ContextData = context as ColumnChooserFooterTemplateContext;
                var visibles = ContextData.Columns.Where(x => x.Visible).Select(x => x.HeaderText).ToArray();
                var hiddens = ContextData.Columns.Where(x => !x.Visible).Select(x => x.HeaderText).ToArray();
            }
            <SfButton IsPrimary="true" OnClick="@(async () => {
            await grid.ShowColumnsAsync(visibles);
            await grid.HideColumnsAsync(hiddens); })">Submit</SfButton>
            <SfButton @onclick="@(async () => await ContextData.CancelAsync())">Abort</SfButton>
        </FooterTemplate>
    </GridColumnChooserSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" IsPrimaryKey="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShippedDate) HeaderText="Shipped Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Visible="false" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Visible="false" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderData> GridData { get; set; }
    SfGrid<OrderData> grid { get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
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
        public OrderData(int? OrderID,string CustomerID,string ShipCountry,double Freight,DateTime OrderDate,DateTime ShippedDate,string ShipCity)
        {
           this.OrderID = OrderID;    
           this.CustomerID = CustomerID;
           this.ShipCountry = ShipCountry;           
           this.Freight = Freight;
           this.OrderDate = OrderDate;     
           this.ShippedDate = ShippedDate;     
           this.ShipCity = ShipCity;
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "ALFKI", "France", 33.33,new DateTime(1996,07,07), new DateTime(1996, 08, 07), "Reims"));
                    Orders.Add(new OrderData(10249, "ANANTR", "Germany", 89.76, new DateTime(1996, 07, 12), new DateTime(1996, 08, 08), "Münster"));
                    Orders.Add(new OrderData(10250, "ANTON", "Brazil", 78.67, new DateTime(1996, 07, 13), new DateTime(1996, 08, 09), "Rio de Janeiro"));
                    Orders.Add(new OrderData(10251, "BLONP", "Belgium", 55.65, new DateTime(1996, 07, 14), new DateTime(1996, 08, 10), "Lyon"));
                    Orders.Add(new OrderData(10252, "BOLID", "Venezuela",11.09, new DateTime(1996, 07, 15), new DateTime(1996, 08, 11), "Charleroi"));
                    Orders.Add(new OrderData(10253, "BLONP", "Venezuela",98.98, new DateTime(1996, 07, 16), new DateTime(1996, 08, 12), "Lyon"));
                    Orders.Add(new OrderData(10254, "ANTON", "Belgium", 78.75, new DateTime(1996, 07, 17), new DateTime(1996, 08, 13), "Rio de Janeiro"));
                    Orders.Add(new OrderData(10255, "ANANTR", "Germany", 44.07, new DateTime(1996, 07, 18), new DateTime(1996, 08, 14), "Münster"));
                    Orders.Add(new OrderData(10256, "ALFKI", "France", 67.74, new DateTime(1996, 07, 19), new DateTime(1996, 08, 15), "Reims"));
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }      
        public string ShipCountry { get; set; }
        public double Freight { get; set; }
        public string ShipCity { get; set; }

    } 
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDhUiMtVWQPZQjGs?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


