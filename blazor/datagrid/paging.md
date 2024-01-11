---
layout: post
title: Paging in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Paging in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Paging in Blazor Grid component

[Paging](https://www.syncfusion.com/blazor-components/blazor-datagrid/paging)  provides an option to display grid data in segmented pages, making it easier to navigate through large datasets. This feature is particularly useful when dealing with extensive data sets.

To enable paging, you need to set the [AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPaging) property to **true**. This property determines whether paging is enabled or disabled for the grid. When paging is enabled, a pager component rendered at the bottom of the grid, allowing you to navigate through different pages of data.

Paging options can be configured through the [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PageSettings) component. The `GridPageSettings` allows you to control various aspects of paging, such as the page size, current page, and total number of records.

> You can achieve better performance by using grid paging to fetch only a pre-defined number of records from the data source.

# Customize the pager options

Customizing the pager options in the Syncfusion Grid allows you to tailor the pagination control according to your specific requirements. You can customize the pager to display the number of pages using the `PageCount` property, change the current page using `CurrentPage` property, display the number of records in the grid using the `PageSize` property, and even adjust the page sizes in a dropdown using the `PageSizes` property. <!--Additionally, you can include the current page as a query string in the URL for convenient navigation.-->

## Change the page size

The Syncfusion Grid allows you to control the number of records displayed per page, providing you with flexibility in managing your data. This feature is particularly useful when you want to adjust the amount of data visible to you at any given time. To achieve this, you can utilize the [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSize) property in [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PageSettings) component. This property is used to specify the initial number of records to display on each page. The default value of pageSize property is 12.

The following example demonstrates how to change the page size of a Grid using an external button click based on **TextBox** input.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Inputs

<div>
    <label style="padding: 30px 17px 0 0">Enter page size:</label>
    <SfTextBox Input="@InputHandler" Width="120px"></SfTextBox>
    <SfButton @onclick="@UpdateValue">CLICK BUTTON</SfButton>
</div>
<br/>

<SfGrid DataSource="@GridData" @ref="Grid"  AllowPaging="true" Height="325px">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<OrderData> GridData { get; set; }

    SfGrid<OrderData> Grid;

    public int value{ get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    public async Task UpdateValue()
    {
        Grid.PageSettings.PageSize = value;
        await Grid.Refresh();
    }

    private async Task InputHandler(InputEventArgs args)
    {
        if(args.Value != string.Empty)
        {
            value = int.Parse(args.Value);
        }
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
        public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
        {
            this.OrderID = OrderID;    
            this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.ShipName = ShipName;           
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
               
                int OrderID = 10248;

                for (int i = 1; i < 7; i++)
                {
                    Orders.Add(new OrderData(OrderID+1, "VINET", "Reims", "Vins et alcools Chevali"));
                    Orders.Add(new OrderData(OrderID+2, "TOMSP", "Münster", "Toms Spezialitäten"));
                    Orders.Add(new OrderData(OrderID+3, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                    Orders.Add(new OrderData(OrderID+4, "VICTE", "Lyon", "Victuailles en stock"));
                    Orders.Add(new OrderData(OrderID+5, "SUPRD", "Charleroi", "Suprêmes délices"));
                    Orders.Add(new OrderData(OrderID+6, "HANAR", "Lyon", "Hanari Carnes"));
                    Orders.Add(new OrderData(OrderID+7, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                    Orders.Add(new OrderData(OrderID+8, "RICSU", "Münster", "Richter Supermarkt"));
                    Orders.Add(new OrderData(OrderID+9, "WELLI", "Reims", "Wellington Import"));
                   
                    OrderID += 9;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
   }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjLztiturzdVycbb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Change the page count

The Syncfusion Grid allows you to adjust the number of pages displayed in the pager container. This is useful when you want to manage the number of pages you see while navigating through extensive datasets. The default value of **PageCount** property is 8.

To change the page count in the Syncfusion Grid, you can utilize the [PageCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageCount) property in [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PageSettings) component, which defines the number of pages displayed in the pager container.

The following example demonstrates how to change the page count of a Grid using an external button click based on **TextBox** input.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<div>
    <label style="padding: 30px 17px 0 0">Enter page count:</label>
    <SfTextBox Input="@InputHandler" Width="120px"></SfTextBox>
    <SfButton @onclick="@UpdateValue">CLICK BUTTON</SfButton>
</div>
<br/>

<SfGrid DataSource="@GridData" @ref="Grid"  AllowPaging="true" Height="325px">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<OrderData> GridData { get; set; }

    SfGrid<OrderData> Grid;

    public int value{ get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    public async Task UpdateValue()
    {
        Grid.PageSettings.PageCount = value;
        await Grid.Refresh();
    }

    private async Task InputHandler(InputEventArgs args)
    {
        if(args.Value != string.Empty)
        {
            value = int.Parse(args.Value);
        }
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
        public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
        {
            this.OrderID = OrderID;    
            this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.ShipName = ShipName;           
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
               
                int OrderID = 10248;

                for (int i = 1; i < 7; i++)
                {
                    Orders.Add(new OrderData(OrderID+1, "VINET", "Reims", "Vins et alcools Chevali"));
                    Orders.Add(new OrderData(OrderID+2, "TOMSP", "Münster", "Toms Spezialitäten"));
                    Orders.Add(new OrderData(OrderID+3, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                    Orders.Add(new OrderData(OrderID+4, "VICTE", "Lyon", "Victuailles en stock"));
                    Orders.Add(new OrderData(OrderID+5, "SUPRD", "Charleroi", "Suprêmes délices"));
                    Orders.Add(new OrderData(OrderID+6, "HANAR", "Lyon", "Hanari Carnes"));
                    Orders.Add(new OrderData(OrderID+7, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                    Orders.Add(new OrderData(OrderID+8, "RICSU", "Münster", "Richter Supermarkt"));
                    Orders.Add(new OrderData(OrderID+9, "WELLI", "Reims", "Wellington Import"));
                   
                    OrderID += 9;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
   }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNVTtiZELIPCWqIZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Change the current page

The Syncfusion Grid allows you to change the currently displayed page, which can be particularly useful when you need to navigate through different pages of data either upon the initial rendering of the grid or update the displayed page based on interactions or specific conditions. The default value of **CurrentPage** property is 1.

To change the current page in the Syncfusion Grid, you can utilize the [CurrentPage](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_CurrentPage) property in [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PageSettings) component, which defines the current page number of the pager.

The following example demonstrates how to dynamically change the current page using an external button click based on **TextBox** input.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<div>
    <label style="padding: 30px 17px 0 0">Enter current page:</label>
    <SfTextBox Input="@InputHandler" Width="120px"></SfTextBox>
    <SfButton @onclick="@UpdateValue">CLICK BUTTON</SfButton>
</div>
<br />

<SfGrid DataSource="@GridData" @ref="Grid" AllowPaging="true" Height="325px">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<OrderData> GridData { get; set; }

    SfGrid<OrderData> Grid;

    public int value { get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    public async Task UpdateValue()
    {
        Grid.PageSettings.CurrentPage = value;
        await Grid.Refresh();
    }

    private async Task InputHandler(InputEventArgs args)
    {
        if (args.Value != string.Empty)
        {
            value = int.Parse(args.Value);
        }
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
        public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
        {
            this.OrderID = OrderID;    
            this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.ShipName = ShipName;           
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
               
                int OrderID = 10248;

                for (int i = 1; i < 7; i++)
                {
                    Orders.Add(new OrderData(OrderID+1, "VINET", "Reims", "Vins et alcools Chevali"));
                    Orders.Add(new OrderData(OrderID+2, "TOMSP", "Münster", "Toms Spezialitäten"));
                    Orders.Add(new OrderData(OrderID+3, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                    Orders.Add(new OrderData(OrderID+4, "VICTE", "Lyon", "Victuailles en stock"));
                    Orders.Add(new OrderData(OrderID+5, "SUPRD", "Charleroi", "Suprêmes délices"));
                    Orders.Add(new OrderData(OrderID+6, "HANAR", "Lyon", "Hanari Carnes"));
                    Orders.Add(new OrderData(OrderID+7, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                    Orders.Add(new OrderData(OrderID+8, "RICSU", "Münster", "Richter Supermarkt"));
                    Orders.Add(new OrderData(OrderID+9, "WELLI", "Reims", "Wellington Import"));
                   
                    OrderID += 9;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
   }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/htrTXCZuLdnPIeht?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

<!--## Add current page in URL as a query string

The Syncfusion Grid allows you to include the current page information as a query string in the URL. This feature is particularly useful for scenarios where you need to maintain and share the state of the grid’s pagination.

To add the current page detail to the URL as a query string in the Syncfusion Grid, you can enable the [EnableQueryString](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_EnableQueryString) property. When this property is set to true, it will automatically pass the current page information as a query string parameter along with the URL when navigating to other pages within the grid.

> By enabling the `EnableQueryString` property, you can easily copy the URL of the current page and share it with others. When the shared URL is opened, it will load the grid with the exact page that was originally shared.

In the following example, the [Blazor Toggle Switch Button](https://blazor.syncfusion.com/documentation/toggle-switch-button/getting-started) component is added to enable or disable the addition of the current page to the URL as a query string. When the switch is toggled, the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChangeEventArgs-1.html) event is triggered and the `EnableQueryString` property of the grid is updated accordingly.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="padding: 20px 0px 20px 0px">
    <label>Enable/Disable Query String</label>
         <SfSwitch ValueChange="Change" TChecked="bool"></SfSwitch>
</div>

<SfGrid @ref="Grid" DataSource="@GridData" AllowPaging="true" Height="315px">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d"  TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }
    SfGrid<OrderData>? Grid { get; set; }

    public bool enableQuery = false;

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    private async Task Change(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool> args)
    {
        enableQuery = args.Checked;
        Grid.PageSettings.EnableQueryString = enableQuery;
        await Grid.Refresh();
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
        public OrderData(int? OrderID,string CustomerID, DateTime? OrderDate, double? Freight)
        {
           this.OrderID = OrderID;    
           this.CustomerID = CustomerID;
            this.OrderDate = OrderDate;
            this.Freight = Freight;            
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int OrderID = 10248;
                for (int i = 1; i < 7; i++)
                {
                    Orders.Add(new OrderData(OrderID+1, "VINET", new DateTime(1996, 07, 06), 32.38));
                    Orders.Add(new OrderData(OrderID+2, "TOMSP", new DateTime(1996, 07, 06), 11.61));
                    Orders.Add(new OrderData(OrderID+3, "HANAR", new DateTime(1996, 07, 06), 65.83));
                    Orders.Add(new OrderData(OrderID+4, "VICTE", new DateTime(1996, 07, 06), 45.78));
                    Orders.Add(new OrderData(OrderID+5, "SUPRD", new DateTime(1996, 07, 06), 98.6));
                    Orders.Add(new OrderData(OrderID+6, "HANAR", new DateTime(1996, 07, 06), 103.45));
                    Orders.Add(new OrderData(OrderID+7, "CHOPS", new DateTime(1996, 07, 06), 103.45));
                    Orders.Add(new OrderData(OrderID+8, "RICSU", new DateTime(1996, 07, 06), 112.48));
                    Orders.Add(new OrderData(OrderID+9, "WELLI", new DateTime(1996, 07, 06), 33.45));
                    OrderID += 9;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNrpDiZEgFLkOPxe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}-->

## Pager template

The pager template in Syncfusion Grid allows you to customize the appearance and behavior of the pager element, which is used for navigation through different pages of grid data. This feature is particularly useful when you want to use custom elements inside the pager instead of the default elements.

To use the pager template, you need to specify the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_Template) property of the [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html) component in your Syncfusion Grid configuration. The pagerTemplate property allows you to define a custom template for the pager. Within the Template, you can access the [CurrentPage](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_CurrentPage), [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSize), [PageCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageCount), **TotalPage** and **TotalRecordCount** values.

The following example demonstrates how to render a **NumericTextBox** component in the pager using the `Template` property

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs

<SfGrid DataSource="@GridData" @ref="Grid" AllowPaging="true">
    <GridPageSettings PageSize="@pageSize">
        <Template>
              <div>
                <div>
                    <div>
                        <SfNumericTextBox TValue="int" Format="###" Step="1" Min="1" Max="3" Placeholder="Select Page Size" Width="200px">
                            <NumericTextBoxEvents TValue="int" ValueChange="@CalculatePageSize"></NumericTextBoxEvents>
                        </SfNumericTextBox>
                    </div>
                </div>
                <div style="margin-top:5px;margin-left:30px;border: none; display: inline-block">
                    <span> of @totalPages pages (@GridData.Count items)</span>
                </div>
            </div>
        </Template>
    </GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<OrderData> GridData { get; set; }

    SfGrid<OrderData> Grid;

    public int pageSize { get; set; } = 5;
    public int totalPages => (int)Math.Ceiling((double)GridData.Count / pageSize);

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    private async Task CalculatePageSize(Syncfusion.Blazor.Inputs.ChangeEventArgs<int> args)
    {
        await Grid.GoToPageAsync(args.Value);
        await Grid.Refresh();
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
        public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
        {
            this.OrderID = OrderID;    
            this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.ShipName = ShipName;           
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
               
                int OrderID = 10248;

                for (int i = 1; i < 3; i++)
                {
                    Orders.Add(new OrderData(OrderID+1, "VINET", "Reims", "Vins et alcools Chevali"));
                    Orders.Add(new OrderData(OrderID+2, "TOMSP", "Münster", "Toms Spezialitäten"));
                    Orders.Add(new OrderData(OrderID+3, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                    Orders.Add(new OrderData(OrderID+4, "VICTE", "Lyon", "Victuailles en stock"));
                    Orders.Add(new OrderData(OrderID+5, "SUPRD", "Charleroi", "Suprêmes délices"));
                    Orders.Add(new OrderData(OrderID+6, "HANAR", "Lyon", "Hanari Carnes"));
                    Orders.Add(new OrderData(OrderID+7, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                    Orders.Add(new OrderData(OrderID+8, "RICSU", "Münster", "Richter Supermarkt"));
                    Orders.Add(new OrderData(OrderID+9, "WELLI", "Reims", "Wellington Import"));
                   
                    OrderID += 9;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
   }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXLJXCiizsqxrUbb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * Inside the **Template** RenderFragment, you can access the parameters passed to the pager templates using implicit parameter named context matching with the [PagerTemplateContent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PagerModel.html#Syncfusion_Blazor_Grids_PagerModel__ctor) class name. 
> * You can refer to our [Blazor Grid Pager Template](https://blazor.syncfusion.com/demos/datagrid/pager-template) online demo of Pager Template feature in Blazor DataGrid.

## Pager with page size dropdown

The pager with a page size dropdown in Syncfusion Grid allows you to dynamically change the number of records displayed in the grid. This feature is useful when you want to easily customize the number of records to be shown per page.

To enable the page size Dropdown feature in the Syncfusion Grid, you need to set the [PageSizes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSizes) property to true in [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PageSettings) component. This property configuration triggers the rendering of a dropdown list within the pager, allowing you to select the desired page size. The selected page size determines the number of records displayed on each page of the grid.

The following example that demonstrates how to integrate the page size Dropdown feature by configuring the `PageSizes` property:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" @ref="Grid" AllowPaging="true" Height="268px">
    <GridPageSettings PageSizes="true" PageSize="12"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<OrderData> GridData { get; set; }

    SfGrid<OrderData> Grid;

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
        public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
        {
            this.OrderID = OrderID;    
            this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.ShipName = ShipName;           
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
               
                int OrderID = 10248;

                for (int i = 1; i < 7; i++)
                {
                    Orders.Add(new OrderData(OrderID+1, "VINET", "Reims", "Vins et alcools Chevali"));
                    Orders.Add(new OrderData(OrderID+2, "TOMSP", "Münster", "Toms Spezialitäten"));
                    Orders.Add(new OrderData(OrderID+3, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                    Orders.Add(new OrderData(OrderID+4, "VICTE", "Lyon", "Victuailles en stock"));
                    Orders.Add(new OrderData(OrderID+5, "SUPRD", "Charleroi", "Suprêmes délices"));
                    Orders.Add(new OrderData(OrderID+6, "HANAR", "Lyon", "Hanari Carnes"));
                    Orders.Add(new OrderData(OrderID+7, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                    Orders.Add(new OrderData(OrderID+8, "RICSU", "Münster", "Richter Supermarkt"));
                    Orders.Add(new OrderData(OrderID+9, "WELLI", "Reims", "Wellington Import"));
                   
                    OrderID += 9;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
   }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXVfjCjETzzrPfLW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * If the pageSizes property is set to a boolean value like ‘true’ or ‘false,’ the page size dropdown defaults to an array of strings containing options such as [‘All’, ‘5’, ‘10’, ‘15’, ‘20’].
> * You can refer to our [Blazor Grid Paging](https://www.syncfusion.com/blazor-components/blazor-datagrid/paging) Feature tour page to know about paging and its feature representations.
> * You can refer to our [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap4) to understand how to present and manipulate data.

### Customize page size dropdown

The Syncfusion Grid allows you to customize the default values of the page size dropdown in the pager, allowing you to change the number of records displayed per page. To achieve this, you can define the [PageSizes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSizes) property as an array of string instead of boolean value.

The following example demonstrate how to customize the default values of the pager dropdown using the `PageSizes` property:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@GridData" AllowPaging="true" >
    <GridPageSettings PageSizes="@(new string[] { "5", "10", "15", "20", "All" })"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d"  TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }
    SfGrid<OrderData>? Grid { get; set; }


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
        public OrderData(int? OrderID,string CustomerID, DateTime? OrderDate, double? Freight)
        {
           this.OrderID = OrderID;    
           this.CustomerID = CustomerID;
            this.OrderDate = OrderDate;
            this.Freight = Freight;            
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int OrderID = 10248;
                for (int i = 1; i < 7; i++)
                {
                    Orders.Add(new OrderData(OrderID+1, "VINET", new DateTime(1996, 07, 06), 32.38));
                    Orders.Add(new OrderData(OrderID+2, "TOMSP", new DateTime(1996, 07, 06), 11.61));
                    Orders.Add(new OrderData(OrderID+3, "HANAR", new DateTime(1996, 07, 06), 65.83));
                    Orders.Add(new OrderData(OrderID+4, "VICTE", new DateTime(1996, 07, 06), 45.78));
                    Orders.Add(new OrderData(OrderID+5, "SUPRD", new DateTime(1996, 07, 06), 98.6));
                    Orders.Add(new OrderData(OrderID+6, "HANAR", new DateTime(1996, 07, 06), 103.45));
                    Orders.Add(new OrderData(OrderID+7, "CHOPS", new DateTime(1996, 07, 06), 103.45));
                    Orders.Add(new OrderData(OrderID+8, "RICSU", new DateTime(1996, 07, 06), 112.48));
                    Orders.Add(new OrderData(OrderID+9, "WELLI", new DateTime(1996, 07, 06), 33.45));
                    OrderID += 9;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZBfDWZOTOXcRZBT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> The pageSizes property can be configured with either an array of strings or a boolean value.

## How to navigate to particular page

Navigating to a particular page in the Syncfusion Grid is particularly useful when dealing with large datasets. It provides a quick and efficient way to jump to a specific page within the grid.

To achieve page navigation, you can use the [GotoPageAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GoToPageAsync_System_Int32_) method provided by Syncfusion Grid. This method allows you to programmatically navigate to a specific page within the grid.

The following example demonstrates how to dynamically navigate to a particular page using the `GotoPageAsync` method triggered by an external button click based on **TextBox** input:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<div>
    <label style="padding: 30px 17px 0 0">Enter page index:</label>
    <SfTextBox Input="@InputHandler" Width="120px"></SfTextBox>
    <SfButton @onclick="@UpdateValue">CLICK BUTTON</SfButton>
</div>
<br />

<SfGrid DataSource="@GridData" @ref="Grid" AllowPaging="true" Height="325px">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<OrderData> GridData { get; set; }

    SfGrid<OrderData> Grid;

    public int value { get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    public async Task UpdateValue()
    {
        await Grid.GoToPageAsync(value);
    }

    private async Task InputHandler(InputEventArgs args)
    {
        if (args.Value != string.Empty)
        {
            value = int.Parse(args.Value);
        }
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
        public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
        {
            this.OrderID = OrderID;    
            this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.ShipName = ShipName;           
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
               
                int OrderID = 10248;

                for (int i = 1; i < 7; i++)
                {
                    Orders.Add(new OrderData(OrderID+1, "VINET", "Reims", "Vins et alcools Chevali"));
                    Orders.Add(new OrderData(OrderID+2, "TOMSP", "Münster", "Toms Spezialitäten"));
                    Orders.Add(new OrderData(OrderID+3, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                    Orders.Add(new OrderData(OrderID+4, "VICTE", "Lyon", "Victuailles en stock"));
                    Orders.Add(new OrderData(OrderID+5, "SUPRD", "Charleroi", "Suprêmes délices"));
                    Orders.Add(new OrderData(OrderID+6, "HANAR", "Lyon", "Hanari Carnes"));
                    Orders.Add(new OrderData(OrderID+7, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                    Orders.Add(new OrderData(OrderID+8, "RICSU", "Münster", "Richter Supermarkt"));
                    Orders.Add(new OrderData(OrderID+9, "WELLI", "Reims", "Wellington Import"));
                   
                    OrderID += 9;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
   }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjLJXssDNXLlILjc?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Dynamically calculate page size based on element height

You have an option to dynamically calculate the page size of a grid by considering the height of its parent element. This functionality proves invaluable in ensuring that the grid’s content remains within the available space, preventing the need for excessive scrolling. It primarily serves the purpose of automatically adjusting the `PageSize` when the height of the grid’s parent element changes dynamically. Upon each alteration in the parent element’s height, invoking this method will compute the grid’s `PageSize` and present the current page records accordingly. This feature effectively addresses situations where a static `PageSize` value does not cater to the varying heights of different parent elements, preventing any unwanted empty spaces within the grid.

The following example demonstrates how to calculate the page size based on the element height using the change event based on the **NumericTextBox** input:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<div style="padding:0 0 20px 0">
    <label style="padding: 30px 17px 0 0">Select page size:</label>
    <SfNumericTextBox Placeholder="select container height" Width="200px" Format="###.##" TValue="int" Min=150 Step=50>
        <NumericTextBoxEvents TValue="int" ValueChange="@CalculatePageSize"></NumericTextBoxEvents>
    </SfNumericTextBox>
</div>

<SfGrid @ref="Grid" DataSource="@GridData" AllowPaging="true" >
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d"  TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }
    SfGrid<OrderData>? Grid { get; set; }

    public int GridHeight;

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    private async Task CalculatePageSize(Syncfusion.Blazor.Inputs.ChangeEventArgs<int> args)
    {
        GridHeight = args.Value;
        var RowHeight = 37; //height of the each row
        Grid.Height = GridHeight.ToString(); ////datagrid height
        var PageSize = (this.Grid.PageSettings as GridPageSettings).PageSize; //initial page size
        decimal PageResize = ((GridHeight) - (PageSize * RowHeight)) / RowHeight; //new page size is obtained here
        Grid.PageSettings.PageSize = PageSize + (int)Math.Round(PageResize);
        await Grid.Refresh();
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
        public OrderData(int? OrderID,string CustomerID, DateTime? OrderDate, double? Freight)
        {
           this.OrderID = OrderID;    
           this.CustomerID = CustomerID;
            this.OrderDate = OrderDate;
            this.Freight = Freight;            
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int OrderID = 10248;
                for (int i = 1; i < 7; i++)
                {
                    Orders.Add(new OrderData(OrderID+1, "VINET", new DateTime(1996, 07, 06), 32.38));
                    Orders.Add(new OrderData(OrderID+2, "TOMSP", new DateTime(1996, 07, 06), 11.61));
                    Orders.Add(new OrderData(OrderID+3, "HANAR", new DateTime(1996, 07, 06), 65.83));
                    Orders.Add(new OrderData(OrderID+4, "VICTE", new DateTime(1996, 07, 06), 45.78));
                    Orders.Add(new OrderData(OrderID+5, "SUPRD", new DateTime(1996, 07, 06), 98.6));
                    Orders.Add(new OrderData(OrderID+6, "HANAR", new DateTime(1996, 07, 06), 103.45));
                    Orders.Add(new OrderData(OrderID+7, "CHOPS", new DateTime(1996, 07, 06), 103.45));
                    Orders.Add(new OrderData(OrderID+8, "RICSU", new DateTime(1996, 07, 06), 112.48));
                    Orders.Add(new OrderData(OrderID+9, "WELLI", new DateTime(1996, 07, 06), 33.45));
                    OrderID += 9;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZhfXiiWLoaAoCIo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Render pager at the top of the grid

By default, the Pager component will be rendered at the bottom of the Grid when the [AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPaging) property is enabled. Using the `SfPager` component, it is possible to render the Pager at the top of the grid. This can be achieved by disabling the default pager of the Grid using the `AllowPaging` property and rendering the `SfPager` component externally. Now, syncing the paging action with the Grid can be performed by following the step below:

In the following sample, the SfPager component is rendered on top of the grid. Initially, using the [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_PageSize) property of the Pager, the data for the Grid component is bound to the current page. In the following code snippet, the `PageSize` is defined as "10" so that the first ten records from the data source of the Grid will be displayed on the current page using the Skip and Take values. The SfPager also includes a [PageSizes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_PageSizes) property, denoting a list of available page sizes such as { 5, 10, 12, 20 }. The `PageSizes` property provides a dropdown list dynamically, allowing users to select from these predefined page sizes and customize the number of records displayed on each page. Through the navigation of the pager items, you can view the records on the Grid page by page. This can be achieved by using the [ItemClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_ItemClick) event of the Pager. In the `ItemClick` event of the Pager, the SkipValue and TakeValue are calculated using the `PageSize` property and arguments of the `ItemClick` event (CurrentPage, PreviousPage). Based on these details, you can view the records on the Grid page by page.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Grids

<SfPager @ref="Page" PageSize="@TakeValue" PageSizes=@pagesizes PageSizeChanged="PageSize"  NumericItemsCount=4 TotalItemsCount="@count" ShowAllInPageSizes="true" ItemClick="Click">
</SfPager>

@{
    var Data = GridData.Skip(SkipValue).Take(TakeValue).ToList();
    <SfGrid @ref="Grid" DataSource="@Data" Height="268px" >
        <GridColumns>
            <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
            <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
            <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
            <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150"></GridColumn>
        </GridColumns>
    </SfGrid>
}

@code
{
    public int SkipValue;
    public List<OrderData> GridData { get; set; }
    SfGrid<OrderData> Grid;
    public int TakeValue = 10;
    public int count { get; set; }
    public SfPager Page { get; set; }
    public List<int> pagesizes = new List<int> { 5, 10, 12, 20 };

    public async Task Click(PagerItemClickEventArgs args)
    {
        SkipValue = (args.CurrentPage * Page.PageSize) - Page.PageSize;
        TakeValue = Page.PageSize;
    }
   
    public async Task PageSize(PageSizeChangedArgs args)
    {
        int page = Grid.PageSettings.CurrentPage;
        SkipValue = (page * Page.PageSize) - Page.PageSize;
        TakeValue = Page.PageSize;

    }
    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
        count = GridData.Count;
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
        public OrderData(int? OrderID, string CustomerID, string ShipCity, string ShipName)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.ShipName = ShipName;
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {

                int OrderID = 10248;

                for (int i = 1; i < 7; i++)
                {
                    Orders.Add(new OrderData(OrderID + 1, "VINET", "Reims", "Vins et alcools Chevali"));
                    Orders.Add(new OrderData(OrderID + 2, "TOMSP", "Münster", "Toms Spezialitäten"));
                    Orders.Add(new OrderData(OrderID + 3, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                    Orders.Add(new OrderData(OrderID + 4, "VICTE", "Lyon", "Victuailles en stock"));
                    Orders.Add(new OrderData(OrderID + 5, "SUPRD", "Charleroi", "Suprêmes délices"));
                    Orders.Add(new OrderData(OrderID + 6, "HANAR", "Lyon", "Hanari Carnes"));
                    Orders.Add(new OrderData(OrderID + 7, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                    Orders.Add(new OrderData(OrderID + 8, "RICSU", "Münster", "Richter Supermarkt"));
                    Orders.Add(new OrderData(OrderID + 9, "WELLI", "Reims", "Wellington Import"));

                    OrderID += 9;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNhJXsMiVRBvwccP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> Here, default pager action of the Grid component is disabled.

## Pager events

The Syncfusion Grid component triggers two pager events during paging actions:

[PageChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_PageChanging)- This event triggered before any paging action (such as changing the page, changing the page size and etc) is initiated. You can use this event to customize or control the behavior of paging actions.

[PageChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_PageChanged)- This event triggered after a pager action is completed. It provides information about the action, such as the CurrentPage, CurrentPageSize, PreviousPage and TotalPages. You can use this event to perform actions or update the UI after the operation has been executed.

The following example that example demonstrates how to use these events to display notification messages to indicate the current and next page during paging actions in the Syncfusion Blazor Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<div style="text-align : center; color: red">
    <span>@message1</span>
    <br/>
    <span>@message</span>
</div>
<br />

<SfGrid @ref="Grid" DataSource="@GridData" AllowPaging="true" >
    <GridPageSettings PageSize="5"></GridPageSettings>
    <GridEvents PageChanging="PageChangingHandler" PageChanged="PageChangedHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d"  TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }
    SfGrid<OrderData>? Grid { get; set; }


    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    public string message;
    public string message1;

    public async Task PageChangingHandler(GridPageChangingEventArgs args)
    {
         message = args.CurrentPage > args.PreviousPage
               ? $"You are going to switch to page {args.CurrentPage + 1}"
               : $"You are going to switch to page {args.PreviousPage}";
    }

    public async Task PageChangedHandler(GridPageChangedEventArgs args)
    {
         message1 = "Now you are in page " + args.CurrentPage;

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
        public OrderData(int? OrderID,string CustomerID, DateTime? OrderDate, double? Freight)
        {
           this.OrderID = OrderID;    
           this.CustomerID = CustomerID;
            this.OrderDate = OrderDate;
            this.Freight = Freight;            
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int OrderID = 10248;
                for (int i = 1; i < 7; i++)
                {
                    Orders.Add(new OrderData(OrderID+1, "VINET", new DateTime(1996, 07, 06), 32.38));
                    Orders.Add(new OrderData(OrderID+2, "TOMSP", new DateTime(1996, 07, 06), 11.61));
                    Orders.Add(new OrderData(OrderID+3, "HANAR", new DateTime(1996, 07, 06), 65.83));
                    Orders.Add(new OrderData(OrderID+4, "VICTE", new DateTime(1996, 07, 06), 45.78));
                    Orders.Add(new OrderData(OrderID+5, "SUPRD", new DateTime(1996, 07, 06), 98.6));
                    Orders.Add(new OrderData(OrderID+6, "HANAR", new DateTime(1996, 07, 06), 103.45));
                    Orders.Add(new OrderData(OrderID+7, "CHOPS", new DateTime(1996, 07, 06), 103.45));
                    Orders.Add(new OrderData(OrderID+8, "RICSU", new DateTime(1996, 07, 06), 112.48));
                    Orders.Add(new OrderData(OrderID+9, "WELLI", new DateTime(1996, 07, 06), 33.45));
                    OrderID += 9;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNrTNWWXXgQbHprJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## See also

* [How to customize page size dropdown value of pager](https://www.syncfusion.com/forums/166711/how-to-customize-the-grid-page-size-dropdown)
