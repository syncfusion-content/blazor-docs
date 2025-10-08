---
layout: post
title: Grouping in Blazor Pivot Table Component | Syncfusion
description: Checkout and learn here all about grouping in Syncfusion Blazor Pivot Table component and much more.
platform: Blazor
control: Pivot Table
documentation: ug
---

# Grouping in Blazor Pivot Table Component

Grouping is one of the most useful features in the Pivot Table component, automatically organizing date, time, number, and string data types into meaningful categories. For example, date fields can be formatted and displayed based on year, quarter, month, and other time periods. Similarly, number fields can be grouped into ranges, such as 1-5, 6-10, and so on. These grouped fields function as individual fields, allowing users to drag them between different axes including columns, rows, values, and filters to create dynamic Pivot Tables at runtime.

N> This feature is applicable only for relational data source.

The grouping feature can be enabled by setting the [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_AllowGrouping) property in [SfPivotView](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html) class to **true**. To perform grouping actions through the user interface, right-click on the Pivot Table's row or column header and select **Group**. A dialog will appear where you can configure the appropriate options to group the data. To ungroup data, right-click on the Pivot Table's row or column header and select **Ungroup**.

The following are the three different types of grouping:

* Number Grouping
* Date Grouping
* Custom Grouping

To have a quick glance on how to group row and column field items in the Blazor Pivot Table, watch this video:

{% youtube
"youtube:https://www.youtube.com/watch?v=t-LDymoVUzA"%}

N> Similar to Excel, only one type of grouping can be applied to a field at a time.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" ShowGroupingBar="true" AllowGrouping="true">
    <PivotViewDataSourceSettings DataSource="@data">
        <PivotViewColumns>
            <PivotViewColumn Name="Product_ID" Caption="Product ID"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="Date" Caption="Date"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Sold" Caption="Unit Sold"></PivotViewValue>
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Date" Type="FormatType.DateTime" Format="dd/MM/yyyy-hh:mm"></PivotViewFormatSetting>
            <PivotViewFormatSetting Name="Product_ID" Format="N" UseGrouping=true></PivotViewFormatSetting>
            <PivotViewFormatSetting Name="Amount" Format="C" UseGrouping=true></PivotViewFormatSetting>
        </PivotViewFormatSettings>
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

## Number Grouping

Number grouping allows users to organize numerical data into different ranges, such as 1–5, 6–10, and so on. This can be configured via the UI by right-clicking a number-based header in the Pivot Table and selecting the **Group** option from the context menu.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" ShowGroupingBar="true" AllowGrouping="true">
    <PivotViewDataSourceSettings DataSource="@data">
        <PivotViewColumns>
            <PivotViewColumn Name="Products" Caption="Products"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="Product_ID" Caption="Product ID"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Sold" Caption="Unit Sold"></PivotViewValue>
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Product_ID" Format="N0" UseGrouping=true></PivotViewFormatSetting>
            <PivotViewFormatSetting Name="Amount" Format="C" UseGrouping=true></PivotViewFormatSetting>
        </PivotViewFormatSettings>
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

![Number Grouping in Blazor PivotTable](images/blazor-pivottable-number-grouping.png)

### Range selection

The "**Starting at**" and "**Ending at**" options are used to set the number range depending on which the headers will be grouped. For example, if the "Product_ID" field holds the number from "1001" to "1010" and the user chooses to group the number range by setting "**1004**" to "**Starting at**" and "**1008**" to "**Ending at**" options on their own, then the specified number range will be used for number grouping and the rest will be grouped as "**Out of Range**".

![Number Grouping within Range in Blazor PivotTable](images/blazor-pivottable-number-group-within-range.png)

### Range interval

The "**Interval by**" option is used to separate the selected number data type field into range-wise such as 1-5, 6-10, etc. For example, if the user wants to display the "Product_ID" data field with a group interval of "**2**" by setting the "**Interval by**" option on their own, the "Product_ID" field will then be grouped by the specified range of intervals, such as "**1004-1005**", "**1006-1007**", etc.

![Grouping with Blazor PivotTable Range Interval](images/blazor-pivottable-group-within-range-interval.png)
<br/>
![Updating Number Group in Blazor PivotTable](images/blazor-pivottable-update-number-group.png)

### Configuring Number Grouping Programmatically

You can configure number grouping through code-behind using the [PivotViewGroupSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewGroupSetting.html) class. This allows you to define how numbers are grouped without relying on the UI. Below are the key settings you need:

* [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotGroupSetting.html#Syncfusion_Blazor_PivotView_PivotGroupSetting_Name): Allows user to set the field name.
* [RangeInterval](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotGroupSetting.html#Syncfusion_Blazor_PivotView_PivotGroupSetting_RangeInterval): Allows user to set the interval between two numbers.
* [StartingAt](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotGroupSetting.html#Syncfusion_Blazor_PivotView_PivotGroupSetting_StartingAt): Allows user to set the starting number.
* [EndingAt](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotGroupSetting.html#Syncfusion_Blazor_PivotView_PivotGroupSetting_EndingAt): Allows user to set the ending number.
* [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotGroupSetting.html#Syncfusion_Blazor_PivotView_PivotGroupSetting_Type): Allows user to set the group type. For number grouping, [GroupType.Number](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.GroupType.html#Syncfusion_Blazor_PivotView_GroupType_Number) is set.

N> If starting and ending numbers specified in [StartingAt](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotGroupSetting.html#Syncfusion_Blazor_PivotView_PivotGroupSetting_StartingAt) and [EndingAt](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotGroupSetting.html#Syncfusion_Blazor_PivotView_PivotGroupSetting_EndingAt) properties are in-between the number range, then the rest of the numbers will be grouped and placed in “Out of Range” section introduced specifically to this feature.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" ShowGroupingBar="true" AllowGrouping="true">
    <PivotViewDataSourceSettings DataSource="@data">
        <PivotViewColumns>
            <PivotViewColumn Name="Products" Caption="Products"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="Product_ID" Caption="Product ID"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Sold" Caption="Unit Sold"></PivotViewValue>
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Product_ID" Format="N" UseGrouping=true></PivotViewFormatSetting>
            <PivotViewFormatSetting Name="Amount" Format="C" UseGrouping=true></PivotViewFormatSetting>
        </PivotViewFormatSettings>
        <PivotViewGroupSettings>
            <PivotViewGroupSetting Name="Product_ID" Type=GroupType.Number RangeInterval=2 StartingAt="1004"  EndingAt="1008"></PivotViewGroupSetting>
        </PivotViewGroupSettings>
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

![Updating Number Group in Blazor PivotTable](images/blazor-pivottable-update-number-group.png)

### Ungrouping the existing number groups

To remove an applied number grouping, simply right-click on the grouped header in the Pivot Table and select **Ungroup** option from the context menu. This action will break apart the grouped ranges and display the original, ungrouped values in the table.

![UnGrouping in Blazor PivotTable](images/blazor-pivottable-ungroup.png)

## Date Grouping

Date grouping organizes date and time data into hierarchical segments, such as years, quarters, months, days, hours, minutes, or seconds. Users can configure date grouping through the UI by right-clicking a date or time-based header in the Pivot Table and selecting **Group** option from the context menu. A dialog will appear, allowing users to choose the desired grouping intervals.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" ShowGroupingBar="true" AllowGrouping="true">
    <PivotViewDataSourceSettings DataSource="@data">
        <PivotViewColumns>
            <PivotViewColumn Name="Product_Categories" Caption="Product Categories"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="Date"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Sold" Caption="Unit Sold"></PivotViewValue>
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
            <PivotViewFilters>
            <PivotViewFilter Name="Products"></PivotViewFilter>
            <PivotViewFilter Name="Product_ID" Caption="Product ID"></PivotViewFilter>
        </PivotViewFilters>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Date" Type="date" Format="dd/MM/yyyy-hh:mm a"></PivotViewFormatSetting>
            <PivotViewFormatSetting Name="Amount" Format="C" UseGrouping=true></PivotViewFormatSetting>
        </PivotViewFormatSettings>
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

![Date Grouping in Blazor PivotTable](images/blazor-pivottable-date-grouping.png)

### Range Selection

The **Starting at** and **Ending at** options allow users to define the date range for grouping headers. For example, if the "Date" field contains data from "01/01/2015" to "02/12/2018" and the user sets **Starting at** to "**01/07/2015**" and **Ending at** to "**31/07/2017**", only records within this range will be grouped according to the selected settings. Dates outside this range are labeled as **Out of Range**.

![Range Selection in Blazor PivotTable](images/blazor-pivottable-range-selection.png)

### Group Interval

The **Interval by** option allows users to split date fields into years, quarters, months, days, hours, minutes, or seconds. For example, selecting **Years** and **Months** as intervals for the "Date" field results in two new fields: **Years (Date)**, containing the year values, and **Months (Date)**, containing the month values. These grouped fields can be used for report manipulations in the Pivot Table at runtime.

N> If no options are selected in the **Interval by** section, the **OK** button in the dialog remains disabled. At least one interval must be chosen to enable date grouping.

![Interval Grouping in Blazor PivotTable](images/blazor-pivottable-interval-grouping.png)
<br/>
![Date Grouping in Blazor PivotTable](images/blazor-pivottable-date-group.png)
<br/>
![Displaying Updated Date Group in Blazor PivotTable](images/blazor-pivottable-update-date-group.png)

### Configuring Date Grouping Programmatically

You can configure date grouping programmatically using the [PivotViewGroupSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewGroupSetting.html) class. This allows you to define how dates are grouped without using the UI. The key settings are:

* [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotGroupSetting.html#Syncfusion_Blazor_PivotView_PivotGroupSetting_Name): Allows user to set the field name.
* [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotGroupSetting.html#Syncfusion_Blazor_PivotView_PivotGroupSetting_Type): Allows user to set the group type. For date grouping, [GroupType.Date](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.GroupType.html#Syncfusion_Blazor_PivotView_GroupType_Date) is set.
* [StartingAt](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotGroupSetting.html#Syncfusion_Blazor_PivotView_PivotGroupSetting_StartingAt): Allows user to set starting date.
* [EndingAt](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotGroupSetting.html#Syncfusion_Blazor_PivotView_PivotGroupSetting_EndingAt): Allows user to set ending date.
* [GroupInterval](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotGroupSetting.html#Syncfusion_Blazor_PivotView_PivotGroupSetting_GroupInterval): Allows user to set interval in year, quarter, month, day, hour, minute, or second pattern.

N> For example, if your date format is "YYYY-DD-MM HH:MM:SS" and you want to group only by year and month, set the [GroupInterval](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotGroupSetting.html#Syncfusion_Blazor_PivotView_PivotGroupSetting_GroupInterval) property with just [DateGroup.Years](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DateGroup.html#Syncfusion_Blazor_PivotView_DateGroup_Years) and [DateGroup.Months](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DateGroup.html#Syncfusion_Blazor_PivotView_DateGroup_Months). You can also rearrange the order of the intervals (Year, Quarter, Month, Day, etc.) as needed—this order will reflect in the Pivot Table display.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" ShowGroupingBar="true" AllowGrouping="true">
    <PivotViewDataSourceSettings DataSource="@data">
        <PivotViewColumns>
            <PivotViewColumn Name="Product_Categories" Caption="Product Categories"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="Date"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Sold" Caption="Unit Sold"></PivotViewValue>
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
            <PivotViewFilters>
            <PivotViewFilter Name="Products"></PivotViewFilter>
            <PivotViewFilter Name="Product_ID" Caption="Product ID"></PivotViewFilter>
        </PivotViewFilters>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Date" Type="date" Format="dd/MM/yyyy-hh:mm a"></PivotViewFormatSetting>
            <PivotViewFormatSetting Name="Amount" Format="C" UseGrouping=true></PivotViewFormatSetting>
        </PivotViewFormatSettings>
        <PivotViewGroupSettings>
            <PivotViewGroupSetting Name="Date" Type=GroupType.Date GroupInterval="new List<DateGroup> { DateGroup.Years, DateGroup.Months }" StartingAt="2015-07-01" EndingAt="2017-07-31"></PivotViewGroupSetting>
        </PivotViewGroupSettings>
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

![Displaying Updated Date Group in Blazor PivotTable](images/blazor-pivottable-update-date-group.png)

### Ungrouping the existing date groups

To remove a previously applied date grouping, simply right-click the relevant date-based header within the Pivot Table and select the **Ungroup** option from the context menu. This action will revert the grouped dates back to their original, ungrouped state, allowing you to view and analyze the raw date values in the Pivot Table component.

![UnGrouping Date Groups in Blazor PivotTable](images/blazor-pivottable-date-ungroup.png)

## Custom Grouping

Custom grouping is an option that enables users to group data types (date, time, number, or string) into custom fields based on specific requirements. This functionality can be accessed through the user interface by right-clicking a header in the Pivot Table.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" ShowGroupingBar="true" AllowGrouping="true">
    <PivotViewDataSourceSettings DataSource="@data">
        <PivotViewColumns>
            <PivotViewColumn Name="Product_ID" Caption="Product ID"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="Products"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Sold" Caption="Unit Sold"></PivotViewValue>
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Product_ID" Format="N0" UseGrouping=true></PivotViewFormatSetting>
            <PivotViewFormatSetting Name="Amount" Format="C" UseGrouping=true></PivotViewFormatSetting>
        </PivotViewFormatSettings>
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

### Creating a Custom Group

To create a custom group in the Pivot Table, select at least two headers from the same field. Hold the **CTRL** key to select multiple headers individually or the **SHIFT** key to select a range of headers. Then, right-click and choose **Group** from the context menu.

![Custom Grouping in Blazor PivotTable](images/blazor-pivottable-custom-grouping.png)

In the dialog box:
- **Field Caption**: Set an alias name for the new custom field, which will appear in the Pivot Table.
- **Group Name**: Define the top-level name for the group that will contain the selected headers.

For example, to group the headers "Gloves," "Jerseys," and "Shorts" in the "Products" field under a single group, set the **Group Name** to "Clothings." The selected headers will then appear under "Clothings" in the Pivot Table.

![Caption with Custom Grouping in Blazor PivotTable](images/blazor-pivottable-custom-group-with-caption.png)
<br/>
![Blazor PivotTable with Custom Grouping](images/blazor-pivottable-custom-group.png)
<br/>
![Displaying Updated Custom Grouping in Blazor PivotTable](images/blazor-pivottable-update-custom-group.png)

### Nested Custom Grouping

Users can also apply new custom grouping options to an existing custom field by right-clicking on the custom group header in the Pivot Table. For example, if the user wants to create a new custom group for the current custom group headers such as "**Bottles and Cages**", "**Cleaners**" and "**Fenders**" by setting the top level name as "**Accessories**" to "**Group Name**" on their own. The selected headers will then be grouped in the Pivot Table under the name "**Accessories**" with a new custom field called "**Product category 1**".

![Nested Custom Grouping in Blazor PivotTable](images/blazor-pivottable-nested-custom-group.png)
<br/>
![Applying Nested Custom Grouping in Blazor PivotTable](images/blazor-pivottable-apply-nested-custom-group.png)
<br/>
![Displaying Updated Nested Custom Grouping in Blazor PivotTable](images/blazor-pivottable-update-nested-custom-group.png)

### Configuring Custom Grouping Programmatically

You can configure custom grouping programmatically using the [PivotViewGroupSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewGroupSetting.html) class in the Pivot Table component. This property allows you to define how fields are grouped in the Pivot Table without using the UI. The available properties are:

* [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotGroupSetting.html#Syncfusion_Blazor_PivotView_PivotGroupSetting_Name): Allows user to set the field name.
* [Caption](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotGroupSetting.html#Syncfusion_Blazor_PivotView_PivotGroupSetting_Caption): Allows user to set the caption name for custom grouping field.
* [PivotViewCustomGroups](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewCustomGroups.html): Allows user to set the custom groups.
* [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotGroupSetting.html#Syncfusion_Blazor_PivotView_PivotGroupSetting_Type): Allows user to set the group type. For custom grouping, [GroupType.Custom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.GroupType.html#Syncfusion_Blazor_PivotView_GroupType_Custom) is set.

The available custom group properties in [PivotViewCustomGroup](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewCustomGroup.html) in [PivotViewCustomGroups](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewCustomGroups.html) class are:

* [GroupName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotCustomGroupSettings.html#Syncfusion_Blazor_PivotView_PivotCustomGroupSettings_GroupName): Allows user to set the group name (or title) for selected headers.
* [Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotCustomGroupSettings.html#Syncfusion_Blazor_PivotView_PivotCustomGroupSettings_Items): Allows to set the headers which needs to be grouped from display.

N> Headers listed in [Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotCustomGroupSettings.html#Syncfusion_Blazor_PivotView_PivotCustomGroupSettings_Items) are grouped under the specified [GroupName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotCustomGroupSettings.html#Syncfusion_Blazor_PivotView_PivotCustomGroupSettings_GroupName) in the Pivot Table. Headers not included in [Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotCustomGroupSettings.html#Syncfusion_Blazor_PivotView_PivotCustomGroupSettings_Items) are displayed under their original names.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" ShowGroupingBar="true" AllowGrouping="true">
    <PivotViewDataSourceSettings DataSource="@data">
        <PivotViewColumns>
            <PivotViewColumn Name="Product_ID" Caption="Product ID"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="Products"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Sold" Caption="Unit Sold"></PivotViewValue>
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Product_ID" Format="N0" UseGrouping=true></PivotViewFormatSetting>
            <PivotViewFormatSetting Name="Amount" Format="C" UseGrouping=true></PivotViewFormatSetting>
        </PivotViewFormatSettings>
        <PivotViewGroupSettings>
            <PivotViewGroupSetting Name="Products" Caption="Product catergory" Type=GroupType.Custom>
                <PivotViewCustomGroups>
                    <PivotViewCustomGroup GroupName="Clothings" Items="@(new string[] { "Gloves", "Jerseys", "Shorts" })"></PivotViewCustomGroup>
                </PivotViewCustomGroups>
            </PivotViewGroupSetting>
        </PivotViewGroupSettings>
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

![Displaying Updated Custom Grouping in Blazor PivotTable](images/blazor-pivottable-update-custom-group.png)

### Ungrouping Existing Custom Groups

To remove a custom group in the Pivot Table, simply right-click on the grouped header and select the "**Ungroup**" option from the context menu. This action will separate the grouped items back into their individual headers within the Pivot Table.

N> After ungrouping, if you remove the related field from the report, any custom group fields associated with it will also be removed from the Pivot Table.

![Custom UnGrouping in Blazor PivotTable](images/blazor-pivottable-custom-ungroup.png)

N> Refer to the [Blazor Pivot Table](https://www.syncfusion.com/blazor-components/blazor-pivot-table) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Pivot Table example](https://blazor.syncfusion.com/demos/pivot-table/default-functionalities?theme=bootstrap5) to know how to render and configure the Pivot Table.