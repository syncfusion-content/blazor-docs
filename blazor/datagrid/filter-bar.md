---
layout: post
title: Filter Bar in Blazor DataGrid | Syncfusion
description: Checkout and learn here all about Filter Bar in Syncfusion Blazor DataGrid and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Filter bar in Blazor DataGrid

The filter bar feature provides a user-friendly way to filter data in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid. It displays an input field for each column, allowing you to enter filter criteria and instantly see the filtered results.

By defining the [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering) to true, then filter bar row will be rendered next to header which allows you to filter data. You can filter the records with different expressions depending upon the column type.

**Filter bar expressions**
You can enter the following filter expressions (operators) manually in the filter bar.

Expression |Example |Description |Column Type
-----|-----|-----|-----
= |=value |StartsWith |Number
!= |!=value |NotEqual |Number
> |>value |GreaterThan |Number
< |<value |LessThan |Number
>= |>=value |GreaterThanOrEqual |Number
<=|<=value|LessThanOrEqual |Number
* |*value |StartsWith |String
% |%value |EndsWith |String
N/A |N/A | **equal** operator will always be used for date filter. |Date
N/A |N/A |**equal** operator will always be used for Boolean filter. |Boolean

The following example demonstrates how to activate default filtering in the Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" @ref="Grid" AllowFiltering="true" AllowPaging="true" Height="273px">
    <GridPageSettings PageSize="5"></GridPageSettings>
    <GridFilterSettings Type="FilterType.FilterBar"></GridFilterSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="100"></GridColumn>
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

    public OrderData() {}
    public OrderData(int? OrderID, string CustomerID, DateTime? OrderDate, string ShipCity, string ShipName)
    {
        this.OrderID = OrderID;    
        this.CustomerID = CustomerID;
        this.OrderDate = OrderDate;
        this.ShipCity = ShipCity;
        this.ShipName = ShipName;           
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
               
            int OrderID = 10247;

            for (int i = 1; i < 3; i++)
            {
                Orders.Add(new OrderData(OrderID + 1, "VINET", new DateTime(1996, 07, 06), "Reims", "Vins et alcools Chevali"));
                Orders.Add(new OrderData(OrderID + 2, "TOMSP", new DateTime(1996, 07, 06), "Münster", "Toms Spezialitäten"));
                Orders.Add(new OrderData(OrderID + 3, "HANAR", new DateTime(1996, 07, 06), "Rio de Janeiro", "Hanari Carnes"));
                Orders.Add(new OrderData(OrderID + 4, "VICTE", new DateTime(1996, 07, 06), "Lyon", "Victuailles en stock"));
                Orders.Add(new OrderData(OrderID + 5, "SUPRD", new DateTime(1996, 07, 06), "Charleroi", "Suprêmes délices"));
                Orders.Add(new OrderData(OrderID + 6, "HANAR", new DateTime(1996, 07, 06), "Lyon", "Hanari Carnes"));
                Orders.Add(new OrderData(OrderID + 7, "CHOPS", new DateTime(1996, 07, 06), "Rio de Janeiro", "Chop-suey Chinese"));
                Orders.Add(new OrderData(OrderID + 8, "RICSU", new DateTime(1996, 07, 06), "Münster", "Richter Supermarkt"));
                Orders.Add(new OrderData(OrderID + 9, "WELLI", new DateTime(1996, 07, 06), "Reims", "Wellington Import"));
                OrderID += 9;
            }
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime? OrderDate { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZLpDMBrqxKqAFyw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Filter bar modes

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid refers to two different ways in which the Grid’s filter bar can operate when filtering criteria are applied. These modes, **OnEnter Mode** and **Immediate Mode**, offer users different experiences and behaviors when interacting with the filter bar.

**OnEnter Mode:**

By Setting the filter bar [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterSettings.html#Syncfusion_Blazor_Grids_GridFilterSettings_Mode) property as [OnEnter](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.FilterBarMode.html#Syncfusion_Blazor_Grids_FilterBarMode_OnEnter) within the [GridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FilterSettings), the filter bar captures the filter criteria entered but doesn’t initiate filtering until the **Enter** key is pressed. This allows multiple criteria modifications without triggering immediate filtering actions.

**Immediate Mode:**

By Setting the filter bar [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterSettings.html#Syncfusion_Blazor_Grids_GridFilterSettings_Mode) property as [Immediate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.FilterBarMode.html#Syncfusion_Blazor_Grids_FilterBarMode_Immediate) within the [GridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FilterSettings), the filter bar instantly applies filtering as filter criteria are entered. Filtering actions take place as soon as criteria are input or modified, providing real-time previews of filtering results.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<label>Select Filter Mode</label>
<SfDropDownList TValue="string" TItem="string" Width="150px" DataSource="@filterModesData">
    <DropDownListEvents TValue="string" TItem="string" ValueChange="onModeChange"></DropDownListEvents>
</SfDropDownList>

<SfGrid DataSource="@GridData" @ref="Grid" AllowFiltering="true" AllowPaging="true" Height="273px">
    <GridPageSettings PageSize="5"></GridPageSettings>
    <GridFilterSettings Mode="@currentFilterMode" Type="Syncfusion.Blazor.Grids.FilterType.FilterBar"></GridFilterSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<OrderData> GridData { get; set; }

    SfGrid<OrderData> Grid;

    List<string> filterModesData = new List<string>() { "Immediate", "OnEnter" };

    FilterBarMode currentFilterMode = FilterBarMode.OnEnter;

    public async Task onModeChange(ChangeEventArgs<string, string> args)
    {
        if (args.Value == "Immediate")
        {
            currentFilterMode = FilterBarMode.Immediate;
        }
        else if (args.Value == "OnEnter")
        {
            currentFilterMode = FilterBarMode.OnEnter;
        }

        await Grid.Refresh();
    }

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
    public OrderData() {}
    public OrderData(int? OrderID, string CustomerID, DateTime? OrderDate, string ShipCity, string ShipName)
    {
        this.OrderID = OrderID;    
        this.CustomerID = CustomerID;
        this.OrderDate = OrderDate;
        this.ShipCity = ShipCity;
        this.ShipName = ShipName;           
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
               
            int OrderID = 10247;
            for (int i = 1; i < 3; i++)
            {
                Orders.Add(new OrderData(OrderID + 1, "VINET", new DateTime(1996, 07, 06), "Reims", "Vins et alcools Chevali"));
                Orders.Add(new OrderData(OrderID + 2, "TOMSP", new DateTime(1996, 07, 06), "Münster", "Toms Spezialitäten"));
                Orders.Add(new OrderData(OrderID + 3, "HANAR", new DateTime(1996, 07, 06), "Rio de Janeiro", "Hanari Carnes"));
                Orders.Add(new OrderData(OrderID + 4, "VICTE", new DateTime(1996, 07, 06), "Lyon", "Victuailles en stock"));
                Orders.Add(new OrderData(OrderID + 5, "SUPRD", new DateTime(1996, 07, 06), "Charleroi", "Suprêmes délices"));
                Orders.Add(new OrderData(OrderID + 6, "HANAR", new DateTime(1996, 07, 06), "Lyon", "Hanari Carnes"));
                Orders.Add(new OrderData(OrderID + 7, "CHOPS", new DateTime(1996, 07, 06), "Rio de Janeiro", "Chop-suey Chinese"));
                Orders.Add(new OrderData(OrderID + 8, "RICSU", new DateTime(1996, 07, 06), "Münster", "Richter Supermarkt"));
                Orders.Add(new OrderData(OrderID + 9, "WELLI", new DateTime(1996, 07, 06), "Reims", "Wellington Import"));
                OrderID += 9;
            }
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime? OrderDate { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjBJjCrLfIsxkmhV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Display filter text in pager

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides an option to display filter text within the pager, indicating the current filtering status. Enabling this feature provides you with a clear understanding of the applied filters and the criteria used for filtering.

To enable the display of filter text within the pager, you should set the [ShowFilterBarStatus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterSettings.html#Syncfusion_Blazor_Grids_GridFilterSettings_ShowFilterBarStatus) property within the [GridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FilterSettings) configuration.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="padding: 20px 0px 20px 0px">
    <label><b>Show filter bar status</b></label>
    <SfSwitch ValueChange="Change" Checked="@Checked" TChecked="bool"></SfSwitch>
</div>

<SfGrid DataSource="@GridData" @ref="Grid" AllowFiltering="true" AllowPaging="true" Height="150px">
    <GridPageSettings PageSize="5"></GridPageSettings>
    <GridFilterSettings  ShowFilterBarStatus="@BarStatus"></GridFilterSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

@if(Checked == false)
{
<style>
    .e-pager .e-pagerexternalmsg 
    {
    display : none;
    }
</style>
}

@code {

    public List<OrderData> GridData { get; set; }

    SfGrid<OrderData> Grid;

    public bool BarStatus = true;
    public bool Checked = true;

    private async Task Change(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool> args)
    {
        if(args.Checked == true)
        {
            BarStatus = true;
            Checked = true;
            await Grid.Refresh();
        }
        else
        {
            BarStatus = !BarStatus;
            Checked = !Checked;
            await Grid.Refresh();
        }
    }

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
    public OrderData(){}
    public OrderData(int? OrderID, string CustomerID, DateTime? OrderDate, string ShipCity, string ShipName)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.OrderDate = OrderDate;
        this.ShipCity = ShipCity;
        this.ShipName = ShipName;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {

            int OrderID = 10247;
            for (int i = 1; i < 3; i++)
            {
                Orders.Add(new OrderData(OrderID + 1, "VINET", new DateTime(1996, 07, 06), "Reims", "Vins et alcools Chevali"));
                Orders.Add(new OrderData(OrderID + 2, "TOMSP", new DateTime(1996, 07, 06), "Münster", "Toms Spezialitäten"));
                Orders.Add(new OrderData(OrderID + 3, "HANAR", new DateTime(1996, 07, 06), "Rio de Janeiro", "Hanari Carnes"));
                Orders.Add(new OrderData(OrderID + 4, "VICTE", new DateTime(1996, 07, 06), "Lyon", "Victuailles en stock"));
                Orders.Add(new OrderData(OrderID + 5, "SUPRD", new DateTime(1996, 07, 06), "Charleroi", "Suprêmes délices"));
                Orders.Add(new OrderData(OrderID + 6, "HANAR", new DateTime(1996, 07, 06), "Lyon", "Hanari Carnes"));
                Orders.Add(new OrderData(OrderID + 7, "CHOPS", new DateTime(1996, 07, 06), "Rio de Janeiro", "Chop-suey Chinese"));
                Orders.Add(new OrderData(OrderID + 8, "RICSU", new DateTime(1996, 07, 06), "Münster", "Richter Supermarkt"));
                Orders.Add(new OrderData(OrderID + 9, "WELLI", new DateTime(1996, 07, 06), "Reims", "Wellington Import"));
                OrderID += 9;
            }
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime? OrderDate { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZVfZhtdTBLebNJe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Prevent filtering for particular column

In the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, you can prevent filtering for a specific column by utilizing the [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering) property of the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) object and setting it to **false**. This feature is useful when you want to disable filtering options for a particular column.

Here’s an example that demonstrates how to remove the filter bar for the **CustomerID** column in Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" AllowFiltering="true" Height="273px">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" AllowFiltering="false" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<OrderData> GridData { get; set; }

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
    public OrderData(){}

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
                Orders.Add(new OrderData(OrderID + 1, "VINET", "Reims", "Vins et alcools Chevalier"));
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtLpZirLweUEtUYL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Hide filter bar for template column

By default, the filter bar is set to a disabled mode for template columns in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid. However, in certain cases, you may want to hide the filter bar for a template column to provide a customized filtering experience.

To hide the filter bar for a template column, you can use the  [FilterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_FilterTemplate) property  of the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html). This property allows you to define a custom template for the filter bar of a column.

Here’s an example that demonstrates how to hide the filter bar for a template column in the Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfGrid DataSource="@GridData" AllowFiltering="true" AllowPaging="true" Height="350">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID"  Width="150"></GridColumn>
        <GridColumn HeaderText="Action" Width="150">
            <Template>
                <SfButton>Custom action</SfButton>
            </Template>
            <FilterTemplate>
                <span></span>
            </FilterTemplate>
        </GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<OrderData> GridData { get; set; }

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
    public OrderData() {}

    public OrderData(int? OrderID,string CustomerID)
    {
        this.OrderID = OrderID;    
        this.CustomerID = CustomerID;          
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
               
            int OrderID = 10247;
            for (int i = 1; i < 3; i++)
            {
                Orders.Add(new OrderData(OrderID + 1, "VINET"));
                Orders.Add(new OrderData(OrderID+2, "TOMSP"));
                Orders.Add(new OrderData(OrderID+3, "HANAR"));
                Orders.Add(new OrderData(OrderID+4, "VICTE"));
                Orders.Add(new OrderData(OrderID+5, "SUPRD"));
                Orders.Add(new OrderData(OrderID+6, "HANAR"));
                Orders.Add(new OrderData(OrderID+7, "CHOPS"));
                Orders.Add(new OrderData(OrderID+8, "RICSU"));
                Orders.Add(new OrderData(OrderID+9, "WELLI"));   
                OrderID += 9;
            }
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjrTNshUBMYiOnUm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Filter bar template with custom component

The [FilterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_FilterTemplate) feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to customize the components displayed in the filter bar. Normally, a text box is the default element rendered in the filter bar cell. This flexibility allows you to use various components, such as [DatePicker](https://blazor.syncfusion.com/documentation/datepicker/getting-started), [NumericTextBox](https://blazor.syncfusion.com/documentation/numeric-textbox/getting-started), [ComboBox](https://blazor.syncfusion.com/documentation/combobox/getting-started-with-web-app), and [MultiSelect Dropdown](https://blazor.syncfusion.com/documentation/multiselect-dropdown/getting-started-webapp), within the filter bar based on your specific requirements.

To utilize this feature, you can define a custom template for the filter bar by setting the `FilterTemplate` property  of the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) in your Blazor application:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Calendars

<SfGrid DataSource="@GridData" @ref="Grid" AllowPaging="true" AllowFiltering="true" AllowSorting="true">
    <GridPageSettings PageCount="5"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100">
             <FilterTemplate>
                <SfDropDownList PlaceHolder="All" ID="CustomerID" @bind-Value="@stringvalue" DataSource="@CustomerIDDropdown" TValue="string" TItem="string">
                    <DropDownListEvents ValueChange="@DropDownValueChange" TItem="string" TValue="string"></DropDownListEvents>
                    <DropDownListFieldSettings Value="CustomerID" Text="CustomerID"></DropDownListFieldSettings>
                </SfDropDownList>
            </FilterTemplate>
        </GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Width="120">
            <FilterTemplate>
                <SfNumericTextBox TValue="double?" Format="00.00" @bind-Value="@NumericValue">
                    <NumericTextBoxEvents TValue="double?" ValueChange="NumericTextBoxValueChange"></NumericTextBoxEvents>
                </SfNumericTextBox>
            </FilterTemplate>
        </GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d" Width="100">
            <FilterTemplate>
                <SfDatePicker TValue="DateTime?" @bind-Value="@DateValue">
                    <DatePickerEvents TValue="DateTime?" ValueChange="DatePickerValueChange"></DatePickerEvents>
                </SfDatePicker>
            </FilterTemplate>
        </GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100">
            <FilterTemplate>
                <SfComboBox Placeholder="Select a city" @bind-Value="@ComboVal" TValue="string" TItem="string" DataSource="@ShipCityData">
                    <ComboBoxEvents TItem="string" TValue="string" ValueChange="@ComboBoxValueChange"></ComboBoxEvents>
                </SfComboBox>
            </FilterTemplate>
        </GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="120">
            <FilterTemplate>
                <SfMultiSelect Placeholder="Select a country" TItem="string" TValue="string[]" DataSource="@ShipCountryData">
                    <MultiSelectEvents TItem="string" TValue="string[]" ValueChange="@MultiSelectValueChange"></MultiSelectEvents>
                </SfMultiSelect>
            </FilterTemplate>
        </GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<OrderData> GridData { get; set; }

    SfGrid<OrderData> Grid;

    public string stringvalue = "All";

    public string ComboVal;

    public List<string> CustomerIDDropdown = new List<string>() { "All", "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD", "CHOPS", "RICSU", "WELLI" };

    public List<string> ShipCountryData = new List<string>() { "France", "Germany", "Brazil", "Belgium", "Switzerland", "Venezuela", "Austria", "Mexico", "USA" };

    private async Task MultiSelectValueChange(MultiSelectChangeEventArgs<string[]> args)
    {
        if(args.Value== null)
        {
            await Grid.ClearFiltering();
        }
        else
        {
            string[] filvalue = args.Value;
            await Grid.FilterByColumnAsync("ShipCountry", "equal", filvalue);
        }
    }

    public async Task DropDownValueChange(@Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, string> args)
    {
        if (args.Value == "All" || args.Value == null)
        {
            await Grid.ClearFiltering();
        }
        else
        { 
            stringvalue = args.Value;
            await Grid.FilterByColumnAsync("CustomerID", "contains", args.Value);
        }
    }
    
    public List<string> ShipCityData = new List<string>() { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" };

    private async Task ComboBoxValueChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, string> args)
    {
        if (args.Value == null)
        {
            await Grid.ClearFiltering();
        }
        else
        {
            ComboVal = args.Value;
            await Grid.FilterByColumnAsync("ShipCity", "equal", args.Value);
        }
    }

    public double? NumericValue { get; set; } = 10;

    public async Task NumericTextBoxValueChange(Syncfusion.Blazor.Inputs.ChangeEventArgs<double?> args)
    {
        if(args.Value == null)
        {
            await Grid.ClearFiltering();
        }
        else
        {
            NumericValue = (double)args.Value;
            
            await Grid.FilterByColumnAsync("Freight", "equal", args.Value);
        }

    }

    public DateTime? DateValue { get; set; } 

    public async Task DatePickerValueChange(Syncfusion.Blazor.Calendars.ChangedEventArgs<DateTime?> args)
    {
        if (args.Value == null)
        {
            await Grid.ClearFiltering();
        }
        else
        {
            DateValue = args.Value;

            await Grid.FilterByColumnAsync("OrderDate", "equal", args.Value);
        }
    }

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

    public OrderData() { }
    public OrderData(int? OrderID, string CustomerID, double? Freight, DateTime? OrderDate, string ShipCity, string ShipCountry)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int OrderID = 10247;
            for (int i = 1; i < 3; i++)
            {
                Orders.Add(new OrderData(OrderID + 1, "VINET", 32.38, new DateTime(1996, 07, 04), "Reims", "France"));
                Orders.Add(new OrderData(OrderID + 2, "TOMSP", 11.61, new DateTime(1996, 07, 05), "Münster", "Germany"));
                Orders.Add(new OrderData(OrderID + 3, "HANAR", 65.83, new DateTime(1996, 07, 06), "Rio de Janeiro", "Brazil"));
                Orders.Add(new OrderData(OrderID + 4, "VICTE", 45.78, new DateTime(1996, 07, 07), "Lyon", "Belgium"));
                Orders.Add(new OrderData(OrderID + 5, "SUPRD", 98.6, new DateTime(1996, 07, 08), "Charleroi", "Switzerland"));
                Orders.Add(new OrderData(OrderID + 6, "HANAR", 103.45, new DateTime(1996, 07, 09), "Lyon", "Venezuela"));
                Orders.Add(new OrderData(OrderID + 7, "CHOPS", 103.45, new DateTime(1996, 07, 10), "Rio de Janeiro", "Austria"));
                Orders.Add(new OrderData(OrderID + 8, "RICSU", 112.48, new DateTime(1996, 07, 11), "Münster", "Mexico"));
                Orders.Add(new OrderData(OrderID + 9, "WELLI", 33.45, new DateTime(1996, 07, 12), "Reims", "USA"));
                OrderID += 9;
            }
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public string ShipCountry { get; set; }
    public string ShipCity { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNhTtWrFGgPwVFGP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}