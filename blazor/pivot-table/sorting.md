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

Allows to order field members in rows and columns either in ascending or descending order. By default, field members in rows and columns are in ascending order.

Member sorting can be enabled by setting the [EnableSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_EnableSorting) property in [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html) class to **true**. After enabling this API, click the sort icon besides each field in row or column axis, available in the field list or grouping bar UI for re-arranging members either in ascending or descending order.

N> By default the [EnableSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_EnableSorting) property in [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html) class set as **true**. If it is set as **false**, then the field members arrange in pivot table as its data source order. And, the sort icons in grouping bar and field list buttons will be removed.

![Sorting in Blazor PivotTable Field List](images/blazor-pivottable-sorting-in-field-list.png)
<br/>
![Sorting in Blazor PivotTable Grouping Bar](images/blazor-pivottable-sorting-in-groupbar.png)
<br/>
![Sorting in Blazor PivotGrid](images/blazor-pivotgrid-sorting.png)

Member sorting can also be configured using the [PivotViewSortSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewSortSetting.html) class through the code behind, during the initial rendering. The settings required to sort are:

* [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewSortSetting.html#Syncfusion_Blazor_PivotView_PivotViewSortSetting_Name): It allows to set the field name.
* [Order](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewSortSetting.html#Syncfusion_Blazor_PivotView_PivotViewSortSetting_Order): It allows to set the sort direction either to ascending or descending of the respective field.

N> By default the [Order](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewSortSetting.html#Syncfusion_Blazor_PivotView_PivotViewSortSetting_Order) property in the [PivotViewSortSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewSortSetting.html) class set as [Sorting.Ascending](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.Sorting.html). Meanwhile, the field members can arrange its order in data source by setting it as [Sorting.None](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.Sorting.html) where the sort icons in grouping bar and field list buttons for the corresponding field will be removed.

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

Usually string sorting is applied to field members even if it starts with numbers. But this kind of field members can also be sorted on the basis of the numbers that are placed at the beginning of the member name. This can be achieved by setting the [DataType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.FieldOptions.html#Syncfusion_Blazor_PivotView_FieldOptions_DataType) property as number to the desired field.

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

## Value sorting

Allows to sort individual value field and its aggregated values either in row or column axis in both ascending and descending order. It can be enabled by setting the [EnableValueSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_EnableValueSorting) property in [SfPivotView](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html) class to **true**. On enabling, the end user can sort the values by directly clicking the value field header positioned either in row or column axis of the pivot table component.

The value sorting can also be configured using the [PivotViewValueSortSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewValueSortSettings.html) option through the code behind. The settings required to sort value fields are:

* [HeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewValueSortSettings.html#Syncfusion_Blazor_PivotView_PivotViewValueSortSettings_HeaderText): It allows to set the header names with delimiters, that is used for value sorting. The header names are arranged from Level 1 to Level N, down the hierarchy with a delimiter for better specification.
* [HeaderDelimiter](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewValueSortSettings.html#Syncfusion_Blazor_PivotView_PivotViewValueSortSettings_HeaderDelimiter): It allows to set the delimiters string to separate the header text between levels.
* [SortOrder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewValueSortSettings.html#Syncfusion_Blazor_PivotView_PivotViewValueSortSettings_SortOrder): It allows to set the sort direction of the value field.

N> Value fields are set to the column axis by default. In such cases, the value sorting applied will have an effect on the column alone. You need to place the value fields in the row axis to do so in row wise. For more information, [refer here](https://blazor.syncfusion.com/documentation/pivot-table/data-binding#values-in-row-axis).

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

Users can apply value sorting to both row and column axes simultaneously for more dynamic and precise data analysis. The following settings are used to configure sorting:

* [ColumnHeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewValueSortSettings.html#Syncfusion_Blazor_PivotView_PivotViewValueSortSettings_ColumnHeaderText): Specifies the column header hierarchy for value sorting. Header levels are defined from Level 1 to N using a delimiter for clarity.
* [HeaderDelimiter](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewValueSortSettings.html#Syncfusion_Blazor_PivotView_PivotViewValueSortSettings_HeaderDelimiter): It allows to set the delimiters string to separate the header text between levels.
* [ColumnSortOrder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewValueSortSettings.html#Syncfusion_Blazor_PivotView_PivotViewValueSortSettings_ColumnSortOrder): Sets the delimiter string used to separate levels in the column header text.
* [RowHeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewValueSortSettings.html#Syncfusion_Blazor_PivotView_PivotViewValueSortSettings_RowHeaderText): Defines the specific row header for which the value sorting should be applied.
* [RowSortOrder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewValueSortSettings.html#Syncfusion_Blazor_PivotView_PivotViewValueSortSettings_RowSortOrder): Determines the sorting direction for the specified row header.

N> This feature is applicable only to relational data sources.

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
        <PivotViewValueSortSettings ColumnHeaderText="FY 2015##Unit Sold" HeaderDelimiter="##" ColumnSortOrder="Sorting.Descending" RowHeaderText="France" RowSortOrder="Sorting.Ascending"></PivotViewValueSortSettings>
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

The event [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_OnActionBegin) triggers when clicking the value sort icon or the sort icon in the field button, which is present in both grouping bar and field list UI. This allows user to identify the current action being performed at runtime. It has the following parameters:

* [DataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotActionBeginEventArgs.html#Syncfusion_Blazor_PivotView_PivotActionBeginEventArgs_DataSourceSettings) : It holds the current data source settings such as input data source, rows, columns, values, filters, format settings and so on.

* [ActionName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotActionBeginEventArgs.html#Syncfusion_Blazor_PivotView_PivotActionBeginEventArgs_ActionName): It holds the name of the current action began. The following are the UI actions and their names:

| Action | Action Name|
|----------------|-------------|
| [Sort field](./sorting#member-sorting)| Sort field |
| [Value sort icon](./sorting#value-sorting)| Sort value|

* [FieldInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotActionBeginEventArgs.html#Syncfusion_Blazor_PivotView_PivotActionBeginEventArgs_FieldInfo): It holds the selected field information.

N> This option is applicable only when the field based UI actions are performed such as filtering, sorting, removing field from grouping bar, editing and aggregation type change.

* [Cancel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotActionBeginEventArgs.html#Syncfusion_Blazor_PivotView_PivotActionBeginEventArgs_Cancel): It allows user to restrict the current action.

In the following example, sort action can be restricted by setting the **args.Cancel** option to **true** in the `OnActionBegin` event.

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

The event [OnActionComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_OnActionComplete) triggers when the UI actions such as value sorting or sorting via the field button, which is present in both grouping bar and field list UI, is completed. This allows user to identify the current UI action being completed at runtime. It has the following parameters:

* [DataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotActionCompleteEventArgs-1.html#Syncfusion_Blazor_PivotView_PivotActionCompleteEventArgs_1_DataSourceSettings): It holds the current data source settings such as input data source, rows, columns, values, filters, format settings and so on.

* [ActionName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotActionCompleteEventArgs-1.html#Syncfusion_Blazor_PivotView_PivotActionCompleteEventArgs_1_ActionName): It holds the name of the current action completed. The following are the UI actions and their names:

| Action | Action Name|
|----------------|-------------|
| [`Sort field`](./sorting#member-sorting)| Field sorted|
| [`Value sort icon`](./sorting#value-sorting)| Value sorted|

* [FieldInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotActionCompleteEventArgs-1.html#Syncfusion_Blazor_PivotView_PivotActionCompleteEventArgs_1_FieldInfo): It holds the selected field information.

N> This option is applicable only when the field based UI actions are performed such as filtering, sorting, removing field from grouping bar, editing and aggregation type change.

* [ActionInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotActionCompleteEventArgs-1.html#Syncfusion_Blazor_PivotView_PivotActionCompleteEventArgs_1_ActionInfo):  It holds the unique information about the current UI action. For example, if sorting is completed, the event argument contains information such as sort order and the field name.

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

The event [OnActionFailure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_OnActionFailure) triggers when the current UI action fails to achieve the desired result. It has the following parameters:

* [ActionName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotActionFailureEventArgs.html#Syncfusion_Blazor_PivotView_PivotActionFailureEventArgs_ActionName): It holds the name of the current action failed. The following are the UI actions and their names:

| Action | Action Name|
|----------------|-------------|
| [`Sort field`](./sorting#member-sorting)| Sort field |
| [`Value sort icon`](./sorting#value-sorting)| Sort value|

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
