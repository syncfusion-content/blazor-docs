---
layout: post
title: Filter Bar in Blazor DataGrid | Syncfusion
description: Learn about the Filter Bar feature in Syncfusion Blazor DataGrid, including configuration, usage, and customization options.
platform: Blazor
control: DataGrid
documentation: ug
---

# Filter Bar in Blazor DataGrid

The filter bar feature provides an efficient and intuitive way to filter data within the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid component. This feature displays input fields below each column header, enabling straightforward data filtering based on column-specific criteria. The filter bar enhances data exploration by allowing users to narrow down large datasets to display only relevant records.

To enable the filter bar, set the [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering) property to **true** on the grid component. This action adds a filter row beneath the column headers, allowing filtering through various expression operators based on the respective column data type.

**Supported filter expressions**

The following table outlines the filter expressions (operators) that can be manually entered in the filter bar, organized by column data type:

| Operator | Example | Description | Data Type |
|----------|---------|-------------|-----------|
| = | =value | Equal | Number |
| != | !=value | Not Equal | Number |
| > | >value | Greater Than | Number |
| < | <value | Less Than | Number |
| >= | >=value | Greater Than or Equal | Number |
| <= | <=value | Less Than or Equal | Number |
| * | *value | Starts With | Text |
| % | %value | Ends With | Text |
| N/A | N/A | Always uses equal | Date |
| N/A | N/A | Always uses equal | Boolean |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" @ref="Grid" AllowFiltering="true" AllowPaging="true" Height="273px">
    <GridPageSettings PageSize="5"></GridPageSettings>
    <GridFilterSettings Type="FilterType.FilterBar"></GridFilterSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Width="100"></GridColumn>
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

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides two distinct operational modes for the filter bar. These modes determine how and when filtering is executed:

* **OnEnter Mode**: Filters are applied only after pressing the **Enter** key, allowing multiple changes before execution
* **Immediate Mode**: Filters are applied automatically as values are entered, providing real-time results

**OnEnter Mode Implementation**

The [OnEnter](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.FilterBarMode.html#Syncfusion_Blazor_Grids_FilterBarMode_OnEnter) mode executes filtering when the **Enter** key is pressed. Set the [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterSettings.html#Syncfusion_Blazor_Grids_GridFilterSettings_Mode) property to **OnEnter** within [GridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FilterSettings) to enable this mode. This approach enables multiple filter criteria to be adjusted before triggering the filter operation.

**Immediate Mode Implementation**

The [Immediate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.FilterBarMode.html#Syncfusion_Blazor_Grids_FilterBarMode_Immediate) mode applies filters automatically as data is entered. Set the [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterSettings.html#Syncfusion_Blazor_Grids_GridFilterSettings_Mode) property to **Immediate** within [GridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FilterSettings) to enable this mode. This delivers live filtering results as values are modified in the filter bar.

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
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Width="100"></GridColumn>
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

### Display filter text in pager

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can display active filter information within the pager section. This visibility enhancement allows clear tracking of currently applied filters and their criteria.

Enable this functionality by setting the [ShowFilterBarStatus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterSettings.html#Syncfusion_Blazor_Grids_GridFilterSettings_ShowFilterBarStatus) property to **true** within the [GridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FilterSettings) configuration.

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
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Width="100"></GridColumn>
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

### Disable filter for specific columns

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports disabling the filter bar for particular columns. Configure the [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering) property of the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) object to **false** to restrict filtering for that specific column.

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

### Hide filter bar for template column

Template columns in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid do not display filter bars by default. To maintain or further customize the filter behavior for template columns, use the [FilterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_FilterTemplate) property. This property defines a custom template for the filter bar area of the column.

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

### Filter bar template with custom component

The [FilterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_FilterTemplate) property enables customization of components displayed in the filter bar. By default, the filter bar displays a standard text input field. However, specific filtering scenarios may benefit from alternative components.

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports integration of the following specialized components within the filter bar:

* [DatePicker](https://blazor.syncfusion.com/documentation/datepicker/getting-started) - For date-based filtering
* [NumericTextBox](https://blazor.syncfusion.com/documentation/numeric-textbox/getting-started) - For numeric value filtering  
* [ComboBox](https://blazor.syncfusion.com/documentation/combobox/getting-started-with-web-app) - For predefined selection filtering
* [MultiSelect Dropdown](https://blazor.syncfusion.com/documentation/multiselect-dropdown/getting-started-webapp) - For multi-value filtering

To implement a custom filter component, define a template using the `FilterTemplate` property of the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html).

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
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Width="100">
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
