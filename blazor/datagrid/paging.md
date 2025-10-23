---
layout: post
title: Paging in Blazor DataGrid Component | Syncfusion
description: Learn how to configure paging in the Syncfusion Blazor DataGrid, including page size, page count, current page, pager templates, events, and top pager layout.
platform: Blazor
control: DataGrid
documentation: ug
---

# Paging in Blazor DataGrid

Paging provides an option to display Syncfusion Blazor DataGrid data in segmented pages, making it easier to navigate large datasets. This feature is particularly useful when dealing with extensive data sets.

To enable paging, set the [AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPaging) property to true. When paging is enabled, a pager is rendered at the bottom of the Grid, allowing navigation through different pages of data.

Paging options can be configured through the [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PageSettings) component. GridPageSettings allows control of page size, current page, and total record count.

> For large data sources, paging improves performance by fetching and rendering only a subset of records per page. For remote data, combine paging with server-side data retrieval to avoid loading all records at once.

## Customize the pager options

Customizing the pager options in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows tailoring pagination to specific requirements. You can configure the number of numeric buttons using the PageCount property, set the current page using the CurrentPage property, specify the number of records per page using the PageSize property, and provide a page size dropdown using the PageSizes property. <!--Additionally, you can include the current page as a query string in the URL for convenient navigation.-->

### Change the page size

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows control over the number of records displayed per page. Use the [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSize) property in [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PageSettings) to specify the initial page size. By default, PageSize is 12.

The following example demonstrates how to change the page size of a Grid using an external button click based on NumericTextBox input.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<div>
    <label style="padding: 30px 17px 0 0">Enter page size:</label>
    <SfNumericTextBox Width="120px" Value="@value" ShowSpinButton="false" TValue="int?">
        <NumericTextBoxEvents TValue="int?"  ValueChange="@ValueChangeHandler"></NumericTextBoxEvents>
    </SfNumericTextBox>
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
    public int? value { get; set; } = null;
    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }
    private async Task ValueChangeHandler(Syncfusion.Blazor.Inputs.ChangeEventArgs<int?> args)
    {
        if(args.Value != null && args.Value != 0)
        {
            value = args.Value;
        }
    }
    public async Task UpdateValue()
    {
        if (value != null )
        {
            Grid.PageSettings.PageSize = (int)value;
            await Grid.Refresh();
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjVTtshJAItZMYUX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Change the page count

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows adjusting the number of numeric buttons displayed in the pager. By default, PageCount is 8.

To change the page count, use the [PageCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageCount) property in [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PageSettings), which defines how many pages are shown in the pager container.

The following example demonstrates how to change the page count using an external button click based on `NumericTextBox` input.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<div>
    <label style="padding: 30px 17px 0 0">Enter page count:</label>
    <SfNumericTextBox Width="120px" Value="@value" ShowSpinButton="false" TValue="int?">
        <NumericTextBoxEvents TValue="int?" ValueChange="@ValueChangeHandler"></NumericTextBoxEvents>
    </SfNumericTextBox>
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
    public int? value{ get; set; }
    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }
    private async Task ValueChangeHandler(Syncfusion.Blazor.Inputs.ChangeEventArgs<int?> args)
    {
        if (args.Value != null && args.Value != 0)
        {
            value = args.Value;
        }
    }
    public async Task UpdateValue()
    {
        if (value != null)
        {
            Grid.PageSettings.PageCount = (int)value;
            await Grid.Refresh();
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXVpNsrfUyIpaGxQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Change the current page

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows changing the currently displayed page, either on initial render or based on interactions or conditions. By default, `CurrentPage` is 1.

To change the current page, use the [CurrentPage](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_CurrentPage) property in [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PageSettings), which sets the current page number.

The following example demonstrates how to change the current page using an external button click based on `NumericTextBox` input.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<div>
    <label style="padding: 30px 17px 0 0">Enter current page:</label>
    <SfNumericTextBox Width="120px" Value="@value" ShowSpinButton="false" TValue="int?">
        <NumericTextBoxEvents TValue="int?" ValueChange="@ValueChangeHandler"></NumericTextBoxEvents>
    </SfNumericTextBox>
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
    public int? value { get; set; }
    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }
    private async Task ValueChangeHandler(Syncfusion.Blazor.Inputs.ChangeEventArgs<int?> args)
    {
        if (args.Value != null && args.Value != 0)
        {
            value = args.Value;
        }
    }
    public async Task UpdateValue()
    {
        if (value != null)
        {
            Grid.PageSettings.CurrentPage = (int)value;
            await Grid.Refresh();
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtLJjCLJKHyfBBpf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

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

The pager template in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows customizing the appearance and behavior of the pager by using custom elements instead of default items.

To use the pager template, specify the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_Template) property of the [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html) component. Within the template, the context provides access to values such as [CurrentPage](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_CurrentPage), [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSize), [PageCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageCount), TotalPages, and TotalRecordsCount.

The following example demonstrates rendering a `NumericTextBox` in the pager template to navigate to a page.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Navigations

<SfGrid DataSource="@GridData" @ref="Grid" AllowPaging="true">
    <GridPageSettings PageSize="@pageSize">
        <Template>
            @{
                var Paging = (context as PagerTemplateContext);
            }
            <div style="display: flex; align-items: center;">
                <SfNumericTextBox TValue="int" Format="###" Step="1" Min="1" Max="20" Value="@pageSize" Placeholder="Select Page Size" Width="200px">
                    <NumericTextBoxEvents TValue="int" ValueChange="@OnPageSizeChange"></NumericTextBoxEvents>
                </SfNumericTextBox>
                <span style="margin-left: 20px;">
                    of @totalPages pages (@GridData.Count items)
                </span>
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

    private async Task OnPageSizeChange(Syncfusion.Blazor.Inputs.ChangeEventArgs<int> args)
    {
        pageSize = args.Value;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNheXEKNqEnQEOmc?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * Inside the `Template` RenderFragment, access parameters using the implicit parameter named context, which is of type PagerTemplateContext. For details, see [PagerTemplateContent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PagerModel.html#Syncfusion_Blazor_Grids_PagerModel__ctor) API.
> * Refer to the [Blazor Grid Pager Template](https://blazor.syncfusion.com/demos/datagrid/pager-template) online demo showcasing the Pager Template feature in the Syncfusion Blazor DataGrid.

## Pager with page size dropdown

The pager with a page size dropdown in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows dynamically changing the number of records displayed in the Grid.

To enable the page size dropdown, set the [PageSizes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSizes) property to true in [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PageSettings). This renders a dropdown list within the pager to select the desired page size. The selected value determines the number of records displayed on each page.

The following example demonstrates how to enable the page size dropdown using the `PageSizes` property:

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

> * If the PageSizes property is set to a boolean value (true or false), the page size dropdown defaults to options such as [‘All’, ‘5’, ‘10’, ‘15’, ‘20’].
> * Refer to the [Blazor Grid Paging](https://www.syncfusion.com/blazor-components/blazor-datagrid/paging) feature tour for an overview of paging.
> * Refer to the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour and the [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap5) to understand data presentation and manipulation.

### Customize page size dropdown

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows customizing the default values in the page size dropdown. To do this, define the [PageSizes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSizes) property as an array of strings instead of a boolean.

The following example demonstrates how to customize the default dropdown values using the `PageSizes` property:

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

> The PageSizes property can be configured with either an array of strings or a boolean value.

## How to navigate to particular page

Navigating to a particular page in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid is useful when dealing with large datasets, enabling quick jumps to specific pages.

To navigate programmatically, use the [GoToPageAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GoToPageAsync_System_Int32_) method.

The following example demonstrates navigating to a particular page using the `GoToPageAsync` method triggered by an external button click based on `NumericTextBox` input:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<div>
    <label style="padding: 30px 17px 0 0">Enter page index:</label>
    <SfNumericTextBox Width="120px" Value="@value" ShowSpinButton="false" TValue="int?">
        <NumericTextBoxEvents TValue="int?" ValueChange="@ValueChangeHandler"></NumericTextBoxEvents>
    </SfNumericTextBox>
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
    public int? value { get; set; }
    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }
    private async Task ValueChangeHandler(Syncfusion.Blazor.Inputs.ChangeEventArgs<int?> args)
    {
        if (args.Value != null && args.Value != 0)
        {
            value = args.Value;
        }
    }
    public async Task UpdateValue()
    {
        if (value != null)
        {
           await Grid.GoToPageAsync((int)value);
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjhptiBJfZoASXjt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Dynamically calculate page size based on element height

It is possible to dynamically calculate the page size of a Grid by considering the height of its parent element. This helps ensure the Grid’s content fits the available space and avoids unnecessary scrolling. When the parent element’s height changes, computing the PageSize accordingly adjusts the number of visible records and prevents empty space or overflow.

The following example demonstrates how to calculate the page size based on element height using the `NumericTextBox` change event:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<div style="padding:0 0 20px 0">
    <label style="padding: 30px 17px 0 0">Select page size:</label>
    <SfNumericTextBox Placeholder="select container height" Width="200px" Format="###.##" @bind-Value=@value TValue="int?" Min="150"  Step=50>
        <NumericTextBoxEvents TValue="int?" ValueChange="@CalculatePageSize"></NumericTextBoxEvents>
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
    public int? value;
    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    private async Task CalculatePageSize(Syncfusion.Blazor.Inputs.ChangeEventArgs<int?> args)
    {
        value = args.Value;
        GridHeight = (int)args.Value;
        var RowHeight = 37; //height of the each row.
        Grid.Height = GridHeight.ToString(); //DataGrid height.
        var PageSize = (this.Grid.PageSettings as GridPageSettings).PageSize; //Initial page size.
        decimal PageResize = ((GridHeight) - (PageSize * RowHeight)) / RowHeight; //New page size is obtained here.
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNBJZWhzpcLcPshm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Render pager at the top of the Grid

By default, the pager is rendered at the bottom of the Grid when [AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPaging) is enabled. Using SfPager, it is possible to render a pager at the top of the Grid. This is achieved by keeping the Grid’s internal pager disabled (AllowPaging set to false) and rendering SfPager externally. Paging actions are synchronized with the Grid by manually applying Skip and Take based on the pager events.

In the following sample, SfPager is rendered above the Grid. Initially, the Pager’s [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_PageSize) determines the number of records shown. The SfPager also includes a [PageSizes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_PageSizes) property to offer a dropdown of sizes such as { 5, 10, 12, 20 }. Navigation is handled in the [ItemClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_ItemClick) event by computing SkipValue and TakeValue using PageSize and the current page.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Grids

<div @onkeydown=HandleKeyDown>
    <SfPager @ref="Page" PageSize="@TakeValue"  PageSizes=@pagesizes PageSizeChanged="PageSize" NumericItemsCount=4 TotalItemsCount="@count" ShowAllInPageSizes="true" ItemClick="Click">
    </SfPager>
</div>

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
    public void HandleKeyDown(KeyboardEventArgs args) 
    { 
        if (args.Code == "Enter" || args.Key == "Enter")
        {
            var currentPage = Page.CurrentPage; 
            SkipValue = (currentPage * Page.PageSize) - Page.PageSize;
            TakeValue = Page.PageSize;
        } 
    }
    public void Click(PagerItemClickEventArgs args)
    {
        SkipValue = (args.CurrentPage * Page.PageSize) - Page.PageSize;
        TakeValue = Page.PageSize;
    }
    public void PageSize(PageSizeChangedArgs args)
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BthpChMvrRAWDWAS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * In this approach, the Grid’s default pager is not used.
> * During paging, the pager triggers the following events:
>   * [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_Created) — triggered when the Pager is created.
>   * [ItemClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_ItemClick) — triggered when a numeric item in the pager is clicked.
>   * [PageSizeChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_PageSizeChanged) — triggered when a page size is selected from the dropdown.

## Pager events

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid triggers two pager events during paging actions:

[PageChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_PageChanging) - Triggered before any paging action (such as changing the page or page size). Use this event to customize or control paging behavior.

[PageChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_PageChanged) - Triggered after a paging action completes. It provides information such as CurrentPage, CurrentPageSize, PreviousPage, and TotalPages. Use this event to perform follow-up actions or update the UI.

The following example demonstrates how to display notification messages indicating the current and next page during paging actions in the Grid:

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