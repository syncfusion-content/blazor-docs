---
layout: post
title: Filtering in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Filtering in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Filtering in Blazor DataGrid Component

Filtering allows you to view particular records based on filter criteria. To enable filtering in the DataGrid, set the [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering) to true. Filtering options can be configured through [GridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FilterSettings) component.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowFiltering="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = (new DateTime[] { new DateTime(2010, 5, 1), new DateTime(2010, 5, 2), new DateTime(2010, 5, 3), })[new Random().Next(3)],
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

The following screenshot shows filtering using FilterBar

![Filtering in Blazor DataGrid](./images/blazor-datagrid-filtering.png)

> * You can apply and clear filtering by using **FilterByColumn** and **ClearFiltering** methods.
> * To disable filtering for a particular column, set [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowFiltering) property of **GridColumn** as false.

## Initial filter

To apply the filter at initial rendering, set the filter **Predicate** object in [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterSettings.html#Syncfusion_Blazor_Grids_GridFilterSettings_Columns) property of **GridFilterSettings** component.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowFiltering="true">
    <GridFilterSettings>
        <GridFilterColumns>
            <GridFilterColumn Field = "CustomerID" MatchCase =false Operator = "Operator.StartsWith" Predicate = "and" Value = "@val" ></GridFilterColumn>
        </GridFilterColumns>
    </GridFilterSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }
    public string val="ANANTR";

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = (new DateTime[] { new DateTime(2010, 5, 1), new DateTime(2010, 5, 2), new DateTime(2010, 5, 3), })[new Random().Next(3)]
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

The following screenshot shows Initial filtering using FilterBar

![Blazor DataGrid with Initial Filter](./images/blazor-datagrid-initial-filtering.png)

## Filter operators

The filter operator for a column can be defined in the **Operator** in [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterSettings.html#Syncfusion_Blazor_Grids_GridFilterSettings_Columns) property of **GridFilterSettings** component.

The available operators and their supported data types are:

Operator |Description |Supported Types
-----|-----|-----
StartsWith |Checks whether the value begins with the specified value. |String
EndsWith |Checks whether the value ends with the specified value. |String
Contains |Checks whether the value contains the specified value. |String
Equal |Checks whether the value is equal to the specified value. |String &#124; Number &#124; Boolean &#124; Date
NotEqual |Checks for values not equal to the specified value. |String &#124; Number &#124; Boolean &#124; Date
GreaterThan |Checks whether the value is greater than the specified value. |Number &#124; Date
GreaterThanOrEqual |Checks whether a value is greater than or equal to the specified value. |Number &#124; Date
LessThan |Checks whether the value is less than the specified value. |Number &#124; Date
LessThanOrEqual |Checks whether the value is less than or equal to the specified value. |Number &#124; Date

> By default, the **Operator** value is **Equal** in [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterSettings.html#Syncfusion_Blazor_Grids_GridFilterSettings_Columns) property of **GridFilterSettings** component.

## Get filtered records when using remote data source

Use the [GetFilteredRecordsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetFilteredRecordsAsync) method to retrieve the details of the filtered records from the Grid component. The `GetFilteredRecordsAsync` method returns the filtered records in the form of objects when using a remote data source. So, you need to deserialize the object to retrieve the filtered records.

```cshtml
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using Newtonsoft.Json

<SfButton OnClick="Click">GetFilteredRecord</SfButton>

<SfGrid @ref="Grid" TValue="EmployeeData" ID="Grid" AllowPaging="true" AllowFiltering="true">
    <SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svc/Orders/" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.OrderID) TextAlign="TextAlign.Center" HeaderText="Order ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.EmployeeID) TextAlign="TextAlign.Center" HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.CustomerID) TextAlign="TextAlign.Center" HeaderText="Customer Name" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    SfGrid<EmployeeData> Grid;
    public class EmployeeData
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public int EmployeeID { get; set; }
    }

    public async Task Click()
    {
        var filteredData = await Grid.GetFilteredRecordsAsync();
        List<EmployeeData> filteredList = JsonConvert.DeserializeObject<List<EmployeeData>>(JsonConvert.SerializeObject(filteredData));
    }
}

```

## Filter enum column

Filter the enum type data in the grid column using the Filter Template feature of the Grid.

In the following sample, the `SfDropDownList` component is rendered in the [FilterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_FilterTemplate) for the Type column. The enumerated list data can be bound to the Type column. In the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_ValueChange) event of the `SfDropDownList`, dynamically filter the Type column using the [FilterByColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FilterByColumnAsync_System_String_System_String_System_Object_System_String_System_Nullable_System_Boolean__System_Nullable_System_Boolean__System_Object_System_Object_) method of the Grid.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<SfGrid @ref="Grid" DataSource="@Orders" AllowFiltering="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.Type) HeaderText="Type" Type="ColumnType.String" Width="130">
            <FilterTemplate>
                <SfDropDownList Placeholder="Type" ID="Type" Value="@((string)(context as PredicateModel).Value)" DataSource="@FilterDropData" TValue="string" TItem="Data">
                    <DropDownListEvents TItem="Data" ValueChange="Change" TValue="string"></DropDownListEvents>
                    <DropDownListFieldSettings Value="Type" Text="Type"></DropDownListFieldSettings>
                </SfDropDownList>
            </FilterTemplate>
        </GridColumn>
    </GridColumns>
</SfGrid>


@code{
    public SfGrid<Order> Grid;
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Random rnd = new Random();
        var values = Enum.GetValues(typeof(FileType));
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = (new DateTime[] { new DateTime(2010, 5, 1), new DateTime(2010, 5, 2), new DateTime(2010, 5, 3), })[new Random().Next(3)],
            Type = (FileType)(values.GetValue(rnd.Next(values.Length)))
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public FileType Type { get; set; }
    }

    public enum FileType : short
    {
        Base = 1,
        Replace = 2,
        Delta = 3
    }
    public class Data
    {
        public string Type { get; set; }
    }
    List<Data> FilterDropData = new List<Data>
    {
        new Data() { Type= "All" },
        new Data() { Type= "Base" },
        new Data() { Type= "Replace" },
        new Data() { Type= "Delta" }
    };
    public async Task Change(ChangeEventArgs<string, Data> args)
    {
        if (args.Value == "All")
        {
           await this.Grid.ClearFilteringAsync();
        }
        else
        {
            await this.Grid.FilterByColumnAsync("Type", "contains", args.Value);
        }
    }
}

```

> You can find the fully working sample [here](https://github.com/SyncfusionExamples/blazor-datagrid-filtering-enum-column).

## Filter multiple values using method

To apply a filter to a column with multiple values in the Grid, you can utilize the [FilterByColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FilterByColumnAsync_System_String_System_String_System_Object_System_String_System_Nullable_System_Boolean__System_Nullable_System_Boolean__System_Object_System_Object_) method. This method allows you to pass a list of multiple values as an argument to the `FilterByColumnAsync` method to perform filtering actions on a specific `GridColumn`.

In the following example, this is demonstrated by filtering the CustomerID column using the "Contains" operator with multiple values.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton OnClick="FilterColumn" Content="FilterRecord"></SfButton>

<SfGrid DataSource="@Orders" @ref="Grid" AllowFiltering="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }
    public SfGrid<Order> Grid { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = (new DateTime[] { new DateTime(2010, 5, 1), new DateTime(2010, 5, 2), new DateTime(2010, 5, 3), })[new Random().Next(3)]
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string? CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }

    private async Task FilterColumn()
    {
        
        await Grid.FilterByColumnAsync("CustomerID", "equal", new List<string> { "BOLID", "BLONP" });

    }

}
```

The following screenshot shows filter multiple values using FilterBycolumnAsync method,

![Filter Multiple Values using FilterByColumnAsync in Blazor DataGrid](./images/blazor-datagrid-filter-multiplevalues.gif)


## See also

* [How to Perform Multiple Value Filtering for Same Column in Grid](https://support.syncfusion.com/kb/article/10996/how-to-perform-multiple-value-filtering-for-same-column-in-grid)
