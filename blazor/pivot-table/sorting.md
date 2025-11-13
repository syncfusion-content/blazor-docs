---
layout: post
title: Sorting in Blazor Pivot Table Component | Syncfusion
description: Checkout and learn here all about sorting in Syncfusion Blazor Pivot Table component and much more details.
platform: Blazor
control: Pivot Table
documentation: ug
---

<!-- markdownlint-disable MD012 -->

# Sorting in Blazor Pivot Table Component

To have a quick glance on how to sort data in the Blazor Pivot Table, watch this video:

{% youtube
"youtube:https://www.youtube.com/watch?v=r6__Vaz4FDg"%}

## Member Sorting

The Member Sorting functionality enables you to arrange field members in the rows and columns of a pivot table in either **ascending** or **descending** order. By default, field members are sorted in ascending order.

### Enabling Member Sorting

To enable member sorting, set the [EnableSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_EnableSorting) property in [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html) class to **true**. Once enabled, you can click the sort icon next to each field in the row or column axis within the **Field List** or **Grouping Bar** UI to reorder members in ascending or descending order.

N> By default the [EnableSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_EnableSorting) property in [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html) class set as **true**. If we set it as **false**, then the field members arrange in pivot table as its data source order. And, the sort icons in grouping bar and field list buttons will be removed.

#### Visual Reference

- **Field List Sort Icon**:  
  ![Member sorting icon in field list](images/blazor-pivottable-sorting-in-field-list.png)

- **Grouping Bar Sort Icon**:  
  ![Member sorting icon in grouping bar](images/blazor-pivottable-sorting-in-groupbar.png)

- **Sorted Pivot Table**:  
  ![Resultant pivot table after member sorting](images/blazor-pivotgrid-sorting.png)

### Configuring Member Sorting Code Behind

You can also configure member sorting during initial rendering using the [PivotViewSortSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewSortSetting.html) class through code behind. The required settings are:

* [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotSortSetting.html#Syncfusion_Blazor_PivotView_PivotSortSetting_Name): Specifies the name of the field to sort.
* [Order](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotSortSetting.html#Syncfusion_Blazor_PivotView_PivotSortSetting_Order): Defines the sort direction, either **Ascending** or **Descending**.

N> By default the [Order](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotSortSetting.html#Syncfusion_Blazor_PivotView_PivotSortSetting_Order) property in the [PivotViewSortSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewSortSetting.html) class set as [Sorting.Ascending](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.Sorting.html). Meanwhile, we can arrange the field members as its order in data source by setting it as [Sorting.None](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.Sorting.html#Syncfusion_Blazor_PivotView_Sorting_None) where the sort icons in grouping bar and field list buttons for the corresponding field will be removed.

The following example demonstrates how to configure the Pivot Table to enable member sorting and set the "Country" field to sort in descending order:

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" ShowGroupingBar="true">
     <PivotViewDataSourceSettings DataSource="@data" EnableSorting=true>
        <PivotViewColumns>
            <PivotViewColumn Name="Year"></PivotViewColumn>
            <PivotViewColumn Name="Quarter"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="Country"></PivotViewRow>
            <PivotViewRow Name="Products"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Sold" Caption="Unit Sold"></PivotViewValue>
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Amount" Format="C"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
        <PivotViewSortSettings>
            <PivotViewSortSetting Name="Country" Order=Sorting.Descending></PivotViewSortSetting>
        </PivotViewSortSettings>
    </PivotViewDataSourceSettings>
</SfPivotView>

@code{
    public List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
}

```

![Sorting in Blazor PivotGrid](images/blazor-pivotgrid-sorting.png)

### Alphanumeric Sorting

Usually, string sorting is applied to field members even if their names start with numbers. To sort field members numerically based on the numbers at the beginning of their names, you can set the [DataType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.FieldOptions.html#Syncfusion_Blazor_PivotView_FieldOptions_DataType) property to **number** for the specific field. This enables numeric sorting instead of alphabetical sorting, allowing for better logical ordering of numbered items.

When [DataType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.FieldOptions.html#Syncfusion_Blazor_PivotView_FieldOptions_DataType) is set to **number**, the component intelligently sorts members like '71-AJ', '209-FB', '36-SW' in the correct numerical sequence (36-SW, 71-AJ, 209-FB) rather than alphabetical order (209-FB, 36-SW, 71-AJ).

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView ID="PivotView" TValue="AlphaNumericData" Width="800" Height="350" ShowGroupingBar="true" ShowFieldList="true" ShowTooltip="false">
    <PivotViewDataSourceSettings DataSource="@data" ExpandAll="false" AllowMemberFilter="true" EnableSorting=true>
        <PivotViewColumns>
            <PivotViewColumn Name="Country"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="ProductID"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Sold" Caption="Units Sold"></PivotViewValue>
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFieldMapping>
            <PivotViewField Name="ProductID" DataType="number"></PivotViewField>
        </PivotViewFieldMapping>
    </PivotViewDataSourceSettings>
</SfPivotView>

@code {
    public List<AlphaNumericData> data { get; set; }
    public class AlphaNumericData
    {
        public string ProductID { get; set; }
        public string Country { get; set; }
        public int Sold { get; set; }
        public long Amount { get; set; }
    }
    protected override void OnInitialized()
    {
        data = new List<AlphaNumericData>
        {
            new AlphaNumericData { ProductID = "618-XW", Country = "Canada", Sold = 90, Amount = 9219069 },
            new AlphaNumericData { ProductID = "1111-GQ", Country = "Australia", Sold = 37, Amount = 1571126 },
            new AlphaNumericData { ProductID = "330-BR", Country = "Germany", Sold = 31, Amount = 9523258 },
            new AlphaNumericData { ProductID = "1035-VC", Country = "United States", Sold = 86, Amount = 1004572 },
            new AlphaNumericData { ProductID = "36-SW", Country = "United Kingdom", Sold = 73, Amount = 4532163 },
            new AlphaNumericData { ProductID = "71-AJ", Country = "Germany", Sold = 45, Amount = 1916052 },
            new AlphaNumericData { ProductID = "980-PP", Country = "Canada", Sold = 85, Amount = 6586156 },
            new AlphaNumericData { ProductID = "209-FB", Country = "Australia", Sold = 51, Amount = 6348087 },
            new AlphaNumericData { ProductID = "428-PL", Country = "Germany", Sold = 65, Amount = 1365854 },
            new AlphaNumericData { ProductID = "618-XW", Country = "United States", Sold = 81, Amount = 6461768 },
            new AlphaNumericData { ProductID = "1111-GQ", Country = "United Kingdom", Sold = 33, Amount = 6181560 },
            new AlphaNumericData { ProductID = "330-BR", Country = "Germany", Sold = 17, Amount = 611364 },
            new AlphaNumericData { ProductID = "1035-VC", Country = "Canada", Sold = 41, Amount = 3688930 },
            new AlphaNumericData { ProductID = "36-SW", Country = "Australia", Sold = 51, Amount = 4648920 },
            new AlphaNumericData { ProductID = "71-AJ", Country = "Germany", Sold = 56, Amount = 4579862 },
            new AlphaNumericData { ProductID = "980-PP", Country = "United States", Sold = 25, Amount = 1249117 },
            new AlphaNumericData { ProductID = "209-FB", Country = "United Kingdom", Sold = 60, Amount = 9603891 },
            new AlphaNumericData { ProductID = "428-PL", Country = "Canada", Sold = 31, Amount = 9548655 },
            new AlphaNumericData { ProductID = "618-XW", Country = "Australia", Sold = 93, Amount = 7496742 },
            new AlphaNumericData { ProductID = "1111-GQ", Country = "Germany", Sold = 62, Amount = 8692814 },
            new AlphaNumericData { ProductID = "330-BR", Country = "United States", Sold = 22, Amount = 4789234 },
            new AlphaNumericData { ProductID = "1035-VC", Country = "United Kingdom", Sold = 61, Amount = 7927531 },
            new AlphaNumericData { ProductID = "36-SW", Country = "Germany", Sold = 68, Amount = 5440025 },
            new AlphaNumericData { ProductID = "71-AJ", Country = "Canada", Sold = 87, Amount = 8097913 },
            new AlphaNumericData { ProductID = "980-PP", Country = "Australia", Sold = 87, Amount = 1809071 },
            new AlphaNumericData { ProductID = "209-FB", Country = "Germany", Sold = 96, Amount = 9893092 },
            new AlphaNumericData { ProductID = "428-PL", Country = "United States", Sold = 22, Amount = 8136252 },
            new AlphaNumericData { ProductID = "618-XW", Country = "United Kingdom", Sold = 29, Amount = 9190577 },
            new AlphaNumericData { ProductID = "1111-GQ", Country = "Germany", Sold = 85, Amount = 5410172 }
        };
    }
}

```

![Alpha Numeric Sorting in Blazor PivotTable](images/blazor-pivottable-alpha-numberic-sorting.png)

## Value Sorting

Value sorting allows users to sort a specific value field and its aggregated values in either the row or column axis, in ascending or descending order. To enable this functionality, set the [EnableValueSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_EnableValueSorting) property in [SfPivotView](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html) class to **true**. Once enabled, users can sort values by clicking the header of a value field in the pivot table's row or column axis.

You can also configure value sorting programmatically using the [PivotViewValueSortSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewValueSortSettings.html) option. The required settings are:

* [HeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotValueSortSettings.html#Syncfusion_Blazor_PivotView_PivotValueSortSettings_HeaderText): It allows to set the header names with delimiters, that is used for value sorting. The header names are arranged from Level 1 to Level N, down the hierarchy with a delimiter for better specification.
* [HeaderDelimiter](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotValueSortSettings.html#Syncfusion_Blazor_PivotView_PivotValueSortSettings_HeaderDelimiter): It allows to set the delimiters string to separate the header text between levels.
* [SortOrder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotValueSortSettings.html#Syncfusion_Blazor_PivotView_PivotValueSortSettings_SortOrder): It allows to set the sort direction of the value field.

N> Value fields are set to the column axis by default. In such cases, the value sorting applied will have an effect on the column alone. You need to place the value fields in the row axis to do so in row wise. For more information, please [refer here](https://blazor.syncfusion.com/documentation/pivot-table/data-binding#values-in-row-axis).

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" EnableValueSorting="true">
     <PivotViewDataSourceSettings DataSource="@data">
        <PivotViewColumns>
            <PivotViewColumn Name="Year"></PivotViewColumn>
            <PivotViewColumn Name="Quarter"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="Country"></PivotViewRow>
            <PivotViewRow Name="Products"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Sold" Caption="Unit Sold"></PivotViewValue>
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Amount" Format="C"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
        <PivotViewValueSortSettings HeaderText="FY 2015##Sold Amount" HeaderDelimiter="##" SortOrder=Sorting.Descending></PivotViewValueSortSettings>
    </PivotViewDataSourceSettings>
</SfPivotView>

@code{
    public List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
}

```

![Value Sorting in Blazor PivotTable](images/blazor-pivottable-value-sorting.png)

### Multiple Axis Sorting

Multiple axis sorting allows simultaneous sorting of value fields in both row and column axes for more flexible and precise data analysis. Apply this functionality using the following settings in [PivotViewValueSortSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewValueSortSettings.html):

* [ColumnHeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotValueSortSettings.html#Syncfusion_Blazor_PivotView_PivotValueSortSettings_ColumnHeaderText): Specifies the column header hierarchy for value sorting. Header levels are defined from Level 1 to N using a delimiter for clarity.
* [HeaderDelimiter](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotValueSortSettings.html#Syncfusion_Blazor_PivotView_PivotValueSortSettings_HeaderDelimiter): It allows to set the delimiters string to separate the header text between levels.
* [ColumnSortOrder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotValueSortSettings.html#Syncfusion_Blazor_PivotView_PivotValueSortSettings_ColumnSortOrder): Determines the sorting direction for the specified column header.
* [RowHeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotValueSortSettings.html#Syncfusion_Blazor_PivotView_PivotValueSortSettings_RowHeaderText): Defines the specific row header for which the value sorting should be applied.
* [RowSortOrder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotValueSortSettings.html#Syncfusion_Blazor_PivotView_PivotValueSortSettings_RowSortOrder): Determines the sorting direction for the specified row header.

N> This feature is applicable only to relational data sources and operates exclusively with client-side engine.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" EnableValueSorting="true">
     <PivotViewDataSourceSettings DataSource="@data">
        <PivotViewColumns>
            <PivotViewColumn Name="Year"></PivotViewColumn>
            <PivotViewColumn Name="Quarter"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="Country"></PivotViewRow>
            <PivotViewRow Name="Products"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Sold" Caption="Unit Sold"></PivotViewValue>
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Amount" Format="C"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
        <PivotViewValueSortSettings ColumnHeaderText="FY 2015##Unit Sold" HeaderDelimiter="##" ColumnSortOrder=Sorting.Descending RowHeaderText="France" RowSortOrder=Sorting.Ascending></PivotViewValueSortSettings>
    </PivotViewDataSourceSettings>
</SfPivotView>

@code{
    public List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
}

```

## Events

### OnActionBegin

The [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_OnActionBegin) event is triggered when the user clicks the value sort icon or the sort icon in a field button, available in both the grouping bar and field list UI. This event allows the user to detect the current action being performed at runtime. The event argument includes the following properties:

* [DataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotActionBeginEventArgs.html#Syncfusion_Blazor_PivotView_PivotActionBeginEventArgs_DataSourceSettings): Contains the current data source settings, including input data, rows, columns, values, filters, format settings, and more.
* [ActionName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotActionBeginEventArgs.html#Syncfusion_Blazor_PivotView_PivotActionBeginEventArgs_ActionName): Indicates the name of the action that has begun. The possible UI actions and corresponding names are:

   | Action | Action Name|
   |------|-------------|
   | [Sort field](./sorting#member-sorting) | Sort field |
   | [Value sort icon](./sorting#value-sorting) | Sort value |

* [FieldInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotActionBeginEventArgs.html#Syncfusion_Blazor_PivotView_PivotActionBeginEventArgs_FieldInfo): Provides information about the selected field.
* [Cancel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotActionBeginEventArgs.html#Syncfusion_Blazor_PivotView_PivotActionBeginEventArgs_Cancel): Set this property to **true** to prevent the current action.

N> This event is triggered only when field-based UI actions such as filtering, sorting, removing fields from the grouping bar, editing, or changing the aggregation type are performed.

In the sample below, the sort action is restricted by setting the **args.Cancel** property to **true** in the [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_OnActionBegin) event handler.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" ShowFieldList="true" ShowGroupingBar="true">
     <PivotViewDataSourceSettings DataSource="@data">
        <PivotViewColumns>
            <PivotViewColumn Name="Year"></PivotViewColumn>
            <PivotViewColumn Name="Quarter"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="Country"></PivotViewRow>
            <PivotViewRow Name="Products"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Sold" Caption="Unit Sold"></PivotViewValue>
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Amount" Format="C"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>    
   <PivotViewEvents TValue="ProductDetails" OnActionBegin="ActionBegin"></PivotViewEvents>
</SfPivotView>

@code{
    private List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }

    // Triggers when the UI action begins.
    public void ActionBegin(PivotActionBeginEventArgs args)
    {
        if(args.ActionName == "Sort field" || args.ActionName == "Sort value")
        {
          args.Cancel = true;
        }       
    }

}
```

### OnActionComplete

The event [OnActionComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_OnActionComplete) triggers when the UI actions such as value sorting or sorting via the field button, which is present in both grouping bar and field list UI, is completed. This allows user to identify the current UI actions being completed at runtime. The event argument includes the following properties:

* [DataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotActionCompleteEventArgs-1.html#Syncfusion_Blazor_PivotView_PivotActionCompleteEventArgs_1_DataSourceSettings): Contains the current data source settings, including input data, rows, columns, values, filters, format settings, and more.
* [ActionName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotActionCompleteEventArgs-1.html#Syncfusion_Blazor_PivotView_PivotActionCompleteEventArgs_1_ActionName): Indicates the name of the completed action. The possible UI actions and corresponding names are:

   | Action | Action Name|
   |------|-------------|
   | [Sort field](./sorting#member-sorting) | Field sorted |
   | [Value sort icon](./sorting#value-sorting) | Value sorted |

* [FieldInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotActionCompleteEventArgs-1.html#Syncfusion_Blazor_PivotView_PivotActionCompleteEventArgs_1_FieldInfo): Provides information about the selected field.
* [ActionInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotActionCompleteEventArgs-1.html#Syncfusion_Blazor_PivotView_PivotActionCompleteEventArgs_1_ActionInfo): It holds the unique information about the current UI action. For example, if sorting is completed, the event argument contains information such as sort order and the field name.

N> This event is triggered only when field-based UI actions such as filtering, sorting, removing fields from the grouping bar, editing, or changing the aggregation type are performed.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" ShowFieldList="true" ShowGroupingBar="true">
     <PivotViewDataSourceSettings DataSource="@data">
        <PivotViewColumns>
            <PivotViewColumn Name="Year"></PivotViewColumn>
            <PivotViewColumn Name="Quarter"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="Country"></PivotViewRow>
            <PivotViewRow Name="Products"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Sold" Caption="Unit Sold"></PivotViewValue>
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Amount" Format="C"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>    
   <PivotViewEvents TValue="ProductDetails" OnActionComplete="ActionComplete"></PivotViewEvents>
</SfPivotView>

@code{
    private List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }

    // Triggers when the UI action is completed.
    public void ActionComplete(PivotActionCompleteEventArgs<ProductDetails> args)
    {
        if(args.ActionName == "Field sorted" || args.ActionName == "Value sorted")
        {
          // Triggers when the sort action is completed.
        }       
    }

}
```

### OnActionFailure

The [OnActionFailure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_OnActionFailure) event is triggered when a UI action fails to produce the expected result. This event provides detailed information about the failure through the following parameters:

* [ActionName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotActionFailureEventArgs.html#Syncfusion_Blazor_PivotView_PivotActionFailureEventArgs_ActionName): It holds the name of the current action failed. The following are the UI actions and their names:

   | Action | Action Name|
   |------|-------------|
   | [Sort field](./sorting#member-sorting)| Sort field |
   | [Value sort icon](./sorting#value-sorting)| Sort value|

* [ErrorInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotActionFailureEventArgs.html#Syncfusion_Blazor_PivotView_PivotActionFailureEventArgs_ErrorInfo): It holds the error information of the current UI action.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" AllowExcelExport="true" AllowPdfExport="true" Width="100%"  ShowToolbar="true" Toolbar="@toolbar" ShowGroupingBar="true" AllowCalculatedField="true"  AllowDrillThrough="true" AllowConditionalFormatting="true" AllowNumberFormatting="true" ShowFieldList="true" Height="350">
     <PivotViewDataSourceSettings DataSource="@data">
        <PivotViewColumns>
            <PivotViewColumn Name="Year"></PivotViewColumn>
            <PivotViewColumn Name="Quarter"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="Country"></PivotViewRow>
            <PivotViewRow Name="Products"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Sold" Caption="Unit Sold"></PivotViewValue>
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Amount" Format="C"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>    
   <PivotViewEvents TValue="ProductDetails" OnActionFailure="ActionFailure"></PivotViewEvents>
</SfPivotView>

@code{
    private List<ProductDetails> data { get; set; }
    private List<Syncfusion.Blazor.PivotView.ToolbarItems> toolbar = new List<Syncfusion.Blazor.PivotView.ToolbarItems> {
        ToolbarItems.New,
        ToolbarItems.Save,
        ToolbarItems.Grid,
        ToolbarItems.Chart,
        ToolbarItems.Export,
        ToolbarItems.SubTotal,
        ToolbarItems.GrandTotal,
        ToolbarItems.ConditionalFormatting,
        ToolbarItems.NumberFormatting,
        ToolbarItems.FieldList            
    };
    protected override void OnInitialized()
    {
        data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
    public void ActionFailure(PivotActionFailureEventArgs args)
    {
        if(args.ActionName == "Sort field" || args.ActionName == "Sort value")
        {
          // Triggers when the current UI action fails to achieve the desired result.
        }       
    }
}
```

N> You can refer to the [Blazor Pivot Table](https://www.syncfusion.com/blazor-components/blazor-pivot-table) feature tour page for its groundbreaking feature representations. You can also explore the [Blazor Pivot Table example](https://blazor.syncfusion.com/demos/pivot-table/default-functionalities?theme=bootstrap5) to know how to render and configure the pivot table.
