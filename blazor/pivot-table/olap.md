---
layout: post
title: OLAP in Blazor Pivot Table component | Syncfusion
description: Checkout and learn here all about OLAP in Syncfusion Blazor Pivot Table component and much more details.
platform: Blazor
control: Pivot Table
documentation: ug
---

<!-- markdownlint-disable MD024 -->
<!-- markdownlint-disable MD012 -->

# OLAP in Blazor Pivot Table component

## Getting started

This section explains how to create a simple [Blazor Pivot Table](https://www.syncfusion.com/blazor-components/blazor-pivot-table) using an OLAP data source. For details on setting up a Blazor application, refer to the [Getting started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for client-side in Visual Studio 2022](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app) guide, which covers the initial setup and configuration steps.

### Adding the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor component package

To use the Pivot Table, install the **Syncfusion.Blazor** NuGet package in your application using the NuGet Package Manager. Make sure to select the **Include prerelease** option to access the latest package versions.

### Setting up the Pivot Table component

You can add the Syncfusion<sup style="font-size:70%">&reg;</sup> Pivot Table component to any Razor page in the `~/Pages` folder. In this example, the component is added to the `~/Pages/Index.razor` page. If the `Index.razor` page contains default content, remove it and add the following code to initialize the Pivot Table.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails"></SfPivotView>
```

### Assigning olap data to the pivot table

To enable users to perform meaningful analysis with OLAP data, the [Blazor Pivot Table](https://www.syncfusion.com/blazor-components/blazor-pivot-table) component requires a properly configured OLAP data source. This data source connects to an OLAP cube, such as Microsoft SQL Server Analysis Services (SSAS), to fetch multidimensional data for analysis.

For demonstration purposes, we'll use the **Adventure Works** cube. The OLAP data source is assigned to the Pivot Table component through the [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html) class. Refer [here](#data-binding) to know more details about OLAP data binding.

```cshtml

@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails">
    <PivotViewDataSourceSettings TValue="ProductDetails" ProviderType="ProviderType.SSAS" Catalog="Adventure Works DW 2008 SE" Cube="Adventure Works" Url="https://bi.syncfusion.com/olap/msmdpump.dll" LocaleIdentifier="1033" EnableSorting="true"></PivotViewDataSourceSettings>
</SfPivotView>

```

### Adding OLAP Cube Elements to Row, Column, Value, and Filter Axes

After initializing the Pivot Table and assigning a sample OLAP data source, you can organize the [OLAP cube elements](#olap-cube-elements) to define how your data is displayed using the [PivotViewRows](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewRow.html), [PivotViewColumns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewColumn.html), [PivotViewValues](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewValue.html), and [PivotViewFilters](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewFilter.html) properties in the [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html) class.

You can use these four main axes to arrange OLAP cube elements from your data source and control how the Pivot Table displays the information.

- [PivotViewRows](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewRow.html): Add OLAP cube elements such as hierarchies, named sets, or calculated members to show them as rows in the Pivot Table.
- [PivotViewColumns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewColumn.html): Add OLAP cube elements like hierarchies, named sets, or calculated members to show them as columns in the Pivot Table.
- [PivotViewValues](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewValue.html): Add OLAP cube elements such as measures or calculated measures to display summarized numeric data in the Pivot Table.
- [PivotViewFilters](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewFilter.html): Add OLAP cube elements like hierarchies or calculated members here to filter the data shown in the row, column, and value axes.

To specify each [OLAP cube element](#olap-cube-elements) in the required axis, set the following options:

- [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotFieldOptions.html#Syncfusion_Blazor_PivotView_PivotFieldOptions_Name): Specifies the unique name of the hierarchy, named set, measure, or calculated member from the OLAP data source. The name must be entered exactly as it appears in the data source. If the name is not matched, the Pivot Table will be empty.
- [Caption](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotFieldOptions.html#Syncfusion_Blazor_PivotView_PivotFieldOptions_Caption): Specifies a caption or display name for the item in the Pivot Table. If a caption is not set, the unique name appears by default.

In this sample, the element "Product Categories" is assigned to the columns axis, "Customer Geography" is assigned to the rows axis, and both "Customer Count" and "Internet Sales Amount" are set in the values axis.

```cshtml

@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" Width="800" Height="350">
    <PivotViewDataSourceSettings TValue="ProductDetails" ProviderType="ProviderType.SSAS" Catalog="Adventure Works DW 2008 SE" Cube="Adventure Works" Url="https://bi.syncfusion.com/olap/msmdpump.dll" LocaleIdentifier="1033" EnableSorting="true">
        <PivotViewColumns>
            <PivotViewColumn Name="[Product].[Product Categories]" Caption="Product Category"></PivotViewColumn>
            <PivotViewColumn Name="[Measures]" Caption="Measure"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="[Customer].[Customer Geography]" Caption="Customer Geography"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="[Measures].[Customer Count]" Caption="Customer Count"></PivotViewValue>
            <PivotViewValue Name="[Measures].[Internet Sales Amount]" Caption="Internet Sales Amount"></PivotViewValue>
        </PivotViewValues>
        </PivotViewDataSourceSettings>
    <PivotViewGridSettings ColumnWidth="160"></PivotViewGridSettings>
</SfPivotView>
<style>
    .e-pivotview {
        min-height: 200px;
    }
</style>

@code{
    public class ProductDetails
    {
        public int Sold { get; set; }
        public double Amount { get; set; }
        public string Country { get; set; }
        public string Products { get; set; }
        public string Year { get; set; }
        public string Quarter { get; set; }
    }
}

```

### Applying Formatting to a Value Field

You can change how values in the Pivot Table are displayed by applying formatting. For example, you can display values as currency by using the **C0** format string. To apply formatting, use the [PivotViewFormatSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewFormatSettings.html) class within the [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html) class, and define both the [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotFormatSetting.html#Syncfusion_Blazor_PivotView_PivotFormatSetting_Name) (the value field to format) and the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotFormatSetting.html#Syncfusion_Blazor_PivotView_PivotFormatSetting_Format) (the format to apply).

In the following example, the [PivotViewFormatSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewFormatSettings.html) class is used to apply the **C0** format to the **[Measures].[Internet Sales Amount]** field. This causes its values to be displayed as currency, showing the currency symbol without any decimal places. You can add formatting for other value fields in a similar way by including them in the [PivotViewFormatSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewFormatSettings.html) class.

N> Only fields from the [PivotViewValues](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewValue.html) axis containing numeric data can be formatted.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" Width="800" Height="350">
    <PivotViewDataSourceSettings TValue="ProductDetails" ProviderType="ProviderType.SSAS" Catalog="Adventure Works DW 2008 SE" Cube="Adventure Works" Url="https://bi.syncfusion.com/olap/msmdpump.dll" LocaleIdentifier="1033" EnableSorting="true">
        <PivotViewColumns>
            <PivotViewColumn Name="[Product].[Product Categories]" Caption="Product Category"></PivotViewColumn>
            <PivotViewColumn Name="[Measures]" Caption="Measure"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="[Customer].[Customer Geography]" Caption="Customer Geography"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="[Measures].[Customer Count]" Caption="Customer Count"></PivotViewValue>
            <PivotViewValue Name="[Measures].[Internet Sales Amount]" Caption="Internet Sales Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="[Measures].[Internet Sales Amount]" Format="C0"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
    <PivotViewGridSettings ColumnWidth="160"></PivotViewGridSettings>
</SfPivotView>
<style>
    .e-pivotview {
        min-height: 200px;
    }
</style>

@code{
    public class ProductDetails
    {
        public int Sold { get; set; }
        public double Amount { get; set; }
        public string Country { get; set; }
        public string Products { get; set; }
        public string Year { get; set; }
        public string Quarter { get; set; }
    }
}
```

After successful compilation of the application, simply press F5 to run the same. The pivot table component will render in the default web browser.

![OLAP in Blazor PivotTable](images/blazor-pivottable-with-olap.png)

### Enable Pivot Field List

The Pivot Table component includes a built-in Field List, similar to the one in Microsoft Excel. This Field List allows users to add or remove [OLAP cube elements](#olap-cube-elements), and to move them between different axes: [PivotViewRows](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewRow.html), [PivotViewColumns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewColumn.html), [PivotViewValues](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewValue.html), and [PivotViewFilters](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewFilter.html). Users can also filter and sort these elements as needed, all during runtime.

To display the Field List, set the [ShowFieldList](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_ShowFieldList) property in the SfPivotView class to **true**. To know more about the field list, [refer](./field-list) here.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" ShowFieldList="true" Width="800" Height="350">
    <PivotViewDataSourceSettings TValue="ProductDetails" ProviderType="ProviderType.SSAS" Catalog="Adventure Works DW 2008 SE" Cube="Adventure Works" Url="https://bi.syncfusion.com/olap/msmdpump.dll" LocaleIdentifier="1033" EnableSorting="true">
        <PivotViewColumns>
            <PivotViewColumn Name="[Product].[Product Categories]" Caption="Product Category"></PivotViewColumn>
            <PivotViewColumn Name="[Measures]" Caption="Measure"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="[Customer].[Customer Geography]" Caption="Customer Geography"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="[Measures].[Customer Count]" Caption="Customer Count"></PivotViewValue>
            <PivotViewValue Name="[Measures].[Internet Sales Amount]" Caption="Internet Sales Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="[Measures].[Internet Sales Amount]" Format="C0"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
    <PivotViewGridSettings ColumnWidth="160"></PivotViewGridSettings>
</SfPivotView>
<style>
    .e-pivotview {
        min-height: 200px;
    }
</style>

@code{
    public class ProductDetails
    {
        public int Sold { get; set; }
        public double Amount { get; set; }
        public string Country { get; set; }
        public string Products { get; set; }
        public string Year { get; set; }
        public string Quarter { get; set; }
    }
}
```

![Blazor PivotTable with OLAP FieldList Icon](images/blazor-pivottable-olap-fieldlist-icon.png)
<br/>

![Blazor PivotTable with OLAP FieldList Dialog](images/blazor-pivottable-olap-fieldlist-dialog.png)

### Enable Grouping Bar

The grouping bar lets users easily organize [OLAP cube elements](#olap-cube-elements) from the connected data source. Users can drag these cube elements between different axes, such as [PivotViewRows](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewRow.html), [PivotViewColumns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewColumn.html), [PivotViewValues](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewValue.html), and [PivotViewFilters](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewFilter.html), to quickly change how data is shown in the Pivot Table. It also allows sorting, filtering, and removing of elements directly from the grouping bar, making it simple to customize the Pivot Table layout at runtime.

To display the grouping bar, set the [ShowGroupingBar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_ShowGroupingBar) property to **true** in the [SfPivotView](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html) component as follows. To know more about grouping bar, [refer](./grouping-bar) here.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" ShowGroupingBar="true" Width="800" Height="350" >
    <PivotViewDataSourceSettings TValue="ProductDetails" ProviderType="ProviderType.SSAS" Catalog="Adventure Works DW 2008 SE" Cube="Adventure Works" Url="https://bi.syncfusion.com/olap/msmdpump.dll" LocaleIdentifier="1033" EnableSorting="true">
        <PivotViewColumns>
            <PivotViewColumn Name="[Product].[Product Categories]" Caption="Product Category"></PivotViewColumn>
            <PivotViewColumn Name="[Measures]" Caption="Measure"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="[Customer].[Customer Geography]" Caption="Customer Geography"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="[Measures].[Customer Count]" Caption="Customer Count"></PivotViewValue>
            <PivotViewValue Name="[Measures].[Internet Sales Amount]" Caption="Internet Sales Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="[Measures].[Internet Sales Amount]" Format="C0"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
    <PivotViewGridSettings ColumnWidth="160"></PivotViewGridSettings>
</SfPivotView>
<style>
    .e-pivotview {
        min-height: 200px;
    }
</style>

@code{
    public class ProductDetails
    {
        public int Sold { get; set; }
        public double Amount { get; set; }
        public string Country { get; set; }
        public string Products { get; set; }
        public string Year { get; set; }
        public string Quarter { get; set; }
    }
}
```

![Blazor PivotTable with OLAP Grouping Bar](images/blazor-pivottable-olap-grouping-bar.png)

### Exploring Filter Axis

The filter axis in the Pivot Table allows users to control which data is displayed in the [PivotViewRows](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewRow.html), [PivotViewColumns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewColumn.html), and [PivotViewValues](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewValue.html) axes. It includes various [OLAP cube elements](#olap-cube-elements), such as hierarchies and calculated members. When elements are placed in the filter axis, they act as master filters that refine the data shown in the Pivot Table.

Users can add [OLAP cube elements](#olap-cube-elements) and filter members to the filter axis either by updating the report in code behind or by dragging items from other axes to the filter axis using the grouping bar or field list at runtime. This makes it easy to filter data according to specific requirements directly within the Pivot Table interface.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" ShowGroupingBar="true" ShowFieldList="true">
     <PivotViewDataSourceSettings TValue="ProductDetails" Catalog="Adventure Works DW 2008 SE" Cube="Adventure Works" Url="https://bi.syncfusion.com/olap/msmdpump.dll" ProviderType="ProviderType.SSAS" EnableSorting="true">
        <PivotViewColumns>
            <PivotViewColumn Name="[Product].[Product Categories]" Caption="Product Categories"></PivotViewColumn>
            <PivotViewColumn Name="[Measures]" Caption="Measures"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="[Customer].[Customer Geography]" Caption="Customer Geography"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="[Measures].[Customer Count]" Caption="Customer Count"></PivotViewValue>
            <PivotViewValue Name="[Measures].[Internet Sales Amount]" Caption="Internet Sales Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFilters>
            <PivotViewFilter Name="[Date].[Fiscal]" Caption="Date Fiscal"></PivotViewFilter>
        </PivotViewFilters>
    </PivotViewDataSourceSettings>
</SfPivotView>

@code{
    public class ProductDetails
    {
        public int Sold { get; set; }
        public double Amount { get; set; }
        public string Country { get; set; }
        public string Products { get; set; }
        public string Year { get; set; }
        public string Quarter { get; set; }
    }
}
```

![Blazor PivotTable with Filter Axis in Field List](images/blazor-pivottable-filter-axis-in-fieldlist.png)
<br/>
<br/>

![Blazor PivotTable with Filter Axis in Grouping Bar](images/blazor-pivottable-filter-axis-in-grouping-bar.png)

### Calculated Field

The calculated field option lets users create a new field in the Pivot Table by using expressions based on existing [OLAP cube elements](#olap-cube-elements) from the connected data source. These calculated fields are new custom dimensions or measures built from an expression defined by the user.

There are two types of calculated fields:

- **Calculated Measure** – Creates a new measure by using a custom expression.
- **Calculated Dimension** – Creates a new dimension by using a custom expression.

You can define calculated fields in your code by using the [PivotViewCalculatedFieldSetting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewCalculatedFieldSetting.html) class in the [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings.html) configuration. The available options for calculated fields are:

- [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotCalculatedFieldSetting.html#Syncfusion_Blazor_PivotView_PivotCalculatedFieldSetting_Name): Sets a unique name for the new calculated field.
- [Formula](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotCalculatedFieldSetting.html#Syncfusion_Blazor_PivotView_PivotCalculatedFieldSetting_Formula): Allows you to set the expression for the calculated field.
- [HierarchyUniqueName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotCalculatedFieldSetting.html#Syncfusion_Blazor_PivotView_PivotCalculatedFieldSetting_HierarchyUniqueName): Specifies the dimension’s unique name, so that only hierarchies within that dimension are used in the expression. This option applies only to calculated dimensions.
- [FormatString](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotCalculatedFieldSetting.html#Syncfusion_Blazor_PivotView_PivotCalculatedFieldSetting_FormatString): Sets the format for the calculated field result.

When adding calculated fields to an axis in your code, set the [IsCalculatedField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotFieldOptions.html#Syncfusion_Blazor_PivotView_PivotFieldOptions_IsCalculatedField) property to **true**.

You can also add calculated fields at runtime through the built-in dialog. To enable this dialog, set the [AllowCalculatedField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_AllowCalculatedField) property to **true**. This will display a button in the Field List UI, letting users open the calculated field dialog and create or edit calculated fields as needed.

N> Calculated measures can be added only to the value axis.

```cshtml

@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" ShowFieldList="true" AllowCalculatedField="true" Width="800" Height="350" >
<PivotViewDataSourceSettings TValue="ProductDetails" ProviderType="ProviderType.SSAS" Catalog="Adventure Works DW 2008 SE" Cube="Adventure Works" Url="https://bi.syncfusion.com/olap/msmdpump.dll" LocaleIdentifier="1033" EnableSorting="true">
    <PivotViewColumns>
        <PivotViewColumn Name="[Product].[Product Categories]" Caption="Product Categories"></PivotViewColumn>
        <PivotViewColumn Name="[Measures]" Caption="Measures"></PivotViewColumn>
    </PivotViewColumns>
    <PivotViewRows>
        <PivotViewRow Name="[Customer].[Customer Geography]" Caption="Customer Geography"></PivotViewRow>
    </PivotViewRows>
    <PivotViewValues>
        <PivotViewValue Name="[Measures].[Customer Count]" Caption="Customer Count"></PivotViewValue>
        <PivotViewValue Name="[Measures].[Internet Sales Amount]" Caption="Internet Sales Amount"></PivotViewValue>
        <PivotViewValue Name="Order on Discount" IsCalculatedField="true"></PivotViewValue>
    </PivotViewValues>
    <PivotViewFilters>
        <PivotViewFilter Name="[Date].[Fiscal]" Caption="Date Fiscal"></PivotViewFilter>
    </PivotViewFilters>
    <PivotViewCalculatedFieldSettings>
        <PivotViewCalculatedFieldSetting Name="BikeAndComponents" Formula="([Product].[Product Categories].[Category].[Bikes] + [Product].[Product Categories].[Category].[Components])" HierarchyUniqueName="[Product].[Product Categories]" FormatString="Standard"></PivotViewCalculatedFieldSetting>
        <PivotViewCalculatedFieldSetting Name="Order on Discount" Formula="[Measures].[Order Quantity] + ([Measures].[Order Quantity] * 0.10)" FormatString="Currency"></PivotViewCalculatedFieldSetting>
    </PivotViewCalculatedFieldSettings>
</PivotViewDataSourceSettings>
<PivotViewGridSettings ColumnWidth="160"></PivotViewGridSettings>
</SfPivotView>
@code{
    public class ProductDetails
    {
        public int Sold { get; set; }
        public double Amount { get; set; }
        public string Country { get; set; }
        public string Products { get; set; }
        public string Year { get; set; }
        public string Quarter { get; set; }
    }
}

```

![Adding Calculated Field in Blazor PivotGrid](images/blazor-pivotgrid-calculated-field.png)
<br/>

Users can add a calculated field at runtime using the built-in dialog by following these steps:

**Step 1:** Click the **CALCULATED FIELD** button in the field list dialog, located at the top right corner. The calculated field dialog appears. Enter the name for the new calculated field in the dialog.
<br/>

![Enbling Calculated Field in Blazor PivotTable UI](images/blazor-pivottable-enable-calculated-field.png)
<br/>

![Displaying Create Calculated Field in Blazor PivotTable](images/blazor-pivottable-calculated-field-name.png)
<br/>

**Step 2:** Create the expression for your calculated field. To do this, drag and drop fields from the tree view on the left side of the dialog and use simple arithmetic operators. **For example**: `IIF([Measures].[Internet Sales Amount]^0.5 > 100, [Measures].[Internet Sales Amount]*100, [Measures].[Internet Sales Amount]/100)`  
For more information about supported [operators](https://learn.microsoft.com/en-us/sql/mdx/operators-mdx-syntax?view=sql-server-ver15) and [functions](https://learn.microsoft.com/en-us/sql/mdx/functions-mdx-syntax?view=sql-server-ver15), see the Microsoft documentation.
<br/>

![Dragging Fields from TreeView to Blazor PivotTable Expression](images/blazor-pivottable-expression-in-calculated-field.png)
<br/>

**Step 3:** Select the type for the new field, either calculated measure or calculated dimension.
<br/>

![Selecting Field Type in Blazor PivotTable Calculated Field](images/blazor-pivottable-calculated-field-type.png)
<br/>

**Step 4:** If you are creating a calculated dimension, select its parent hierarchy from the drop-down list. This step is only required when adding a calculated dimension.
<br/>

![Choosing Parent Hierarchy in Blazor PivotTable Calculated Field](images/blazor-pivottable-hierarchy-in-calculated-field.png)
<br/>

**Step 5:** Select a format string from the drop-down list and then click **OK** to finalize the calculated field.
<br/>

![Selecting Format in Blazor PivotTable Calculated Field](images/blazor-pivottable-calculated-field-format-string.png)
<br/>


#### Format String

When creating a calculated field in the Pivot Table, you can choose the format for displaying values by selecting a format string. The available options are:

* **Standard** – Displays values as standard numbers.
* **Currency** – Displays values in currency format.
* **Percent** – Displays values as a percentage.
* **Custom** – Allows you to define your own format string. For example, entering "###0.##0#" will show the value "9584.3" as "9584.300".

By default, the **Standard** option is selected in the drop-down list.

This option helps users present calculated field results in the most suitable format for their needs.

![Format String in Blazor PivotTable Calculated Field](images/blazor-pivottable-calculated-field-format.png)

#### Renaming the Existing Calculated Field

You can rename any existing calculated field directly through the user interface at runtime. This option allows you to update calculated field names to keep them clear and meaningful as your analysis needs change.

To rename a calculated field:

1. Open the calculated field dialog in the Pivot Table.
2. Click the name of the field you want to rename. The current name will be shown in the text box at the top of the dialog.
3. Enter the new name in the text box.
4. Click **OK** to save the new name.

![Before Renaming in Blazor PivotTable Calculated Field](images/blazor-pivottable-before-renaming-in-field.png)
<br/>

![After Renaming in Blazor PivotTable Calculated Field](images/blazor-pivottable-after-renaming-in-field.png)

#### Editing an Existing Calculated Field Formula

You can edit an existing calculated field formula directly through the user interface at runtime. To do this:

1. Open the calculated field dialog in the Pivot Table.
2. From the list, select the calculated field you want to edit.
3. The current formula for the selected field will appear in the **Expression** section.
4. Modify the formula as needed based on your requirements.
5. Click **OK** to apply and save your changes.

The Pivot Table will automatically update to show the changes in the calculated values.

![Before Editing Existing Field Formula in Blazor PivotTable](images/blazor-pivottable-before-renaming-in-field.png)
<br/>

![After Editing Existing Field Formula in Blazor PivotTable](images/blazor-pivottable-after-editing-existing-field.png)

#### Reusing an Existing Formula in a New Calculated Field

This option allows you to easily create a new calculated field in the Pivot Table by reusing a formula from an existing calculated field. This saves time and helps keep your calculations consistent.

To reuse an existing formula when working with the OLAP data source:

1. Open the calculated field dialog in the Pivot Table.
2. Find the existing calculated field that contains the formula you want to use again.
3. Drag the existing calculated field from the field list treeview.
4. Drop it into the **Expression** section. The formula from the selected field is then added automatically.
5. If needed, you can adjust the formula further or use it without changes.
6. Click **OK** to add your new calculated field.

![Before Dragging Formula to Blazor PivotTable Calculated Field](images/blazor-pivottable-before-renaming-in-field.png)
<br/>

![Dragging Formula to Blazor PivotTable Calculated Field](images/blazor-pivottable-dragging-existing-field.png)
<br/>

![Reusing Existing Formula in Blazor PivotTable Calculated Field](images/blazor-pivottable-reusing-formula-in-calculated-field.png)

#### Modifying the Existing Format String

You can modify the format string of an existing calculated field at runtime through the user interface. To do this:

1. Open the calculated field dialog in the Pivot Table.
2. Click the name of the calculated field you want to edit.
3. The dialog will display the current format string in a drop-down list.
4. Select or enter a new format string based on your requirements.
5. Click **OK** to apply and save your changes.

![Before Modifying Existing Format in Blazor PivotTable Field](images/blazor-pivottable-before-renaming-in-field.png)
<br/>

![After Modifying Existing Format in Blazor PivotTable Field](images/blazor-pivottable-after-modify-format-in-field.png)

#### Clearing the Changes While Editing the Calculated Field

If you make edits while creating or modifying a calculated field, you can easily remove all the current changes by clicking the **Clear** button. This option is available in the bottom left corner of the calculated field dialog. Using the Clear button helps you start over without manually undoing each change, ensuring a smooth editing experience.

![Clearing Changes while Editing in Blazor PivotTable Field](images/blazor-pivottable-clear-edit-in-field.png)

### Virtual Scrolling

Virtual scrolling helps you view large amounts of data smoothly in the Pivot Table. It loads and displays only the rows and columns currently visible in the viewport. As you scroll vertically or horizontally, new data is brought into view automatically, ensuring good performance even with a large data source.

To enable virtual scrolling, set the [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_EnableVirtualization) property in the [SfPivotView](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html) class to **true**.

```cshtml

@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails"  Width="800" Height="350" EnableVirtualization="true" ShowGroupingBar="true">
    <PivotViewDataSourceSettings TValue="ProductDetails" ProviderType="ProviderType.SSAS" Catalog="Adventure Works DW 2008 SE" Cube="Adventure Works" Url="https://bi.syncfusion.com/olap/msmdpump.dll" LocaleIdentifier="1033" EnableSorting="true">
        <PivotViewColumns>
            <PivotViewColumn Name="[Product].[Product Categories]" Caption="Product Category"></PivotViewColumn>
            <PivotViewColumn Name="[Measures]" Caption="Measure"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="[Customer].[Customer]" Caption="Customer"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="[Measures].[Customer Count]" Caption="Customer Count"></PivotViewValue>
            <PivotViewValue Name="[Measures].[Internet Sales Amount]" Caption="Internet Sales Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="[Measures].[Internet Sales Amount]" Format="C0"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
    <PivotViewGridSettings ColumnWidth="160"></PivotViewGridSettings>
</SfPivotView>
<style>
    .e-pivotview {
        min-height: 200px;
    }
</style>

@code{
    public class ProductDetails
    {
        public int Sold { get; set; }
        public double Amount { get; set; }
        public string Country { get; set; }
        public string Products { get; set; }
        public string Year { get; set; }
        public string Quarter { get; set; }
    }
}

```

![Virtual Scrolling in Blazor PivotTable](images/blazor-pivottable-virtual-scrolling.png)

#### Limitations for virtual scrolling

- When using virtual scrolling, the [ColumnWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewGridSettings.html#Syncfusion_Blazor_PivotView_PivotViewGridSettings_ColumnWidth) property under [PivotViewGridSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewGridSettings.html) class must be set in pixels; percentage values are not supported.
- Resizing columns or setting width to individual columns affects the calculation used to pick the correct page on scrolling.
- With OLAP data, subtotals and grand totals are shown only when measures are placed at the end of the [Rows](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_Rows) or [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_Columns) axes within [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html) class. If measures appear elsewhere, data will display without summary totals.
- If the width and height of the Pivot Table are set to large values, the amount of data loaded in the current, previous, and next pages increases. This may impact loading performance during scrolling.

## Data Binding

To connect an OLAP data source to the Pivot Table, use the [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html) class. Several properties within the [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html) class must be specified to bind data correctly:

| Properties | Description |
|------------|-------------|
| [Cube](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_Cube) | Specifies the name of the OLAP cube to use from the database. |
| [ProviderType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_ProviderType) | Indicates the type of provider, helping the Pivot Table determine how to connect to the data source. |
| [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_Url) | The URL of the OLAP service. Use this to establish an online connection to the cube. |
| [Catalog](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_Catalog) | The database or catalog name containing the cube data. |

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" Width="800" Height="350">
    <PivotViewDataSourceSettings TValue="ProductDetails" ProviderType="ProviderType.SSAS" Catalog="Adventure Works DW 2008 SE" Cube="Adventure Works" Url="https://bi.syncfusion.com/olap/msmdpump.dll" LocaleIdentifier="1033" EnableSorting="true">
        <PivotViewColumns>
            <PivotViewColumn Name="[Product].[Product Categories]" Caption="Product Category"></PivotViewColumn>
            <PivotViewColumn Name="[Measures]" Caption="Measure"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="[Customer].[Customer Geography]" Caption="Customer Geography"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="[Measures].[Customer Count]" Caption="Customer Count"></PivotViewValue>
            <PivotViewValue Name="[Measures].[Internet Sales Amount]" Caption="Internet Sales Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="[Measures].[Internet Sales Amount]" Format="C"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
    <PivotViewGridSettings ColumnWidth="160"></PivotViewGridSettings>
</SfPivotView>
<style>
    .e-pivotview {
        min-height: 200px;
    }
</style>

@code{
    public class ProductDetails
    {
        public int Sold { get; set; }
        public double Amount { get; set; }
        public string Country { get; set; }
        public string Products { get; set; }
        public string Year { get; set; }
        public string Quarter { get; set; }
    }
}
```

![Binding OLAP Data in Blazor PivotTable](images/blazor-pivottable-with-olap.png)

### Fields

#### Measures in the Row Axis

By default, measures are shown on the columns axis in the Pivot Table. If you would like to display measures on the rows axis instead, you can do this using the grouping bar or the field list UI. Simply drag the "Measures" button and drop it onto the rows axis.

Alternatively, you can set up the measure directly in your code by configuring the [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html) class, as shown in the code below:

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" Width="800" Height="350">
    <PivotViewDataSourceSettings TValue="ProductDetails" ProviderType="ProviderType.SSAS" Catalog="Adventure Works DW 2008 SE" Cube="Adventure Works" Url="https://bi.syncfusion.com/olap/msmdpump.dll" LocaleIdentifier="1033" EnableSorting="true">
        <PivotViewColumns>
            <PivotViewColumn Name="[Product].[Product Categories]" Caption="Product Category"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="[Customer].[Customer Geography]" Caption="Customer Geography"></PivotViewRow>
            <PivotViewRow Name="[Measures]" Caption="Measures"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="[Measures].[Customer Count]" Caption="Customer Count"></PivotViewValue>
            <PivotViewValue Name="[Measures].[Internet Sales Amount]" Caption="Internet Sales Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="[Measures].[Internet Sales Amount]" Format="C0"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
    <PivotViewGridSettings ColumnWidth="160"></PivotViewGridSettings>
</SfPivotView>
<style>
    .e-pivotview {
        min-height: 200px;
    }
</style>

@code{
    public class ProductDetails
    {
        public int Sold { get; set; }
        public double Amount { get; set; }
        public string Country { get; set; }
        public string Products { get; set; }
        public string Year { get; set; }
        public string Quarter { get; set; }
    }
}
```

![Blazor PivotTable OLAP Values in Row Axis](images/blazor-pivottable-olap-value-axis.png)

### Named Set

A named set is a multidimensional expression (MDX) that provides a predefined group of members from a dimension. It is created by combining cube data with arithmetic operators, numbers, or functions.

To display a named set in the Pivot Table, set its unique name using the [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotFieldOptions.html#Syncfusion_Blazor_PivotView_PivotFieldOptions_Name) property within either the row or column axis in the [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html) class. Additionally, set the [IsNamedSet](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotFieldOptions.html#Syncfusion_Blazor_PivotView_PivotFieldOptions_IsNamedSet) property to **true**. In the example below, the "Core Product Group" named set is added to the column axis.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" Width="800" Height="350">
    <PivotViewDataSourceSettings TValue="ProductDetails" ProviderType="ProviderType.SSAS" Catalog="Adventure Works DW 2008 SE" Cube="Adventure Works" Url="https://bi.syncfusion.com/olap/msmdpump.dll" LocaleIdentifier="1033" EnableSorting="true">
        <PivotViewColumns>
            <PivotViewColumn Name="[Core Product Group]" Caption="Core Product Group" IsNamedSet="true"></PivotViewColumn>
            <PivotViewColumn Name="[Measures]" Caption="Measures"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="[Customer].[Customer Geography]" Caption="Customer Geography"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="[Measures].[Customer Count]" Caption="Customer Count"></PivotViewValue>
            <PivotViewValue Name="[Measures].[Internet Sales Amount]" Caption="Internet Sales Amount"></PivotViewValue>
        </PivotViewValues>
    </PivotViewDataSourceSettings>
    <PivotViewGridSettings ColumnWidth="160"></PivotViewGridSettings>
</SfPivotView>
<style>
    .e-pivotview {
        min-height: 200px;
    }
</style>

@code{
    public class ProductDetails
    {
        public int Sold { get; set; }
        public double Amount { get; set; }
        public string Country { get; set; }
        public string Products { get; set; }
        public string Year { get; set; }
        public string Quarter { get; set; }
    }
}
```

![Binding Named Set in Blazor PivotTable](images/blazor-pivottable-bind-named-set.png)

### Configuring Authentication

To connect to an OLAP data source that requires authentication, users can provide basic authentication details through the [PivotViewAuthentication](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_Authentication) property within the [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html) class of the Pivot Table. The authentication options include:

- [UserName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotAuthentication.html#Syncfusion_Blazor_PivotView_PivotAuthentication_UserName): Enter the username required for access to the OLAP server.
- [Password](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotAuthentication.html#Syncfusion_Blazor_PivotView_PivotAuthentication_Password): Enter the password associated with the username.

N> If authentication details are not provided, the browser will display a default pop-up window prompting users to enter the required information.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" Width="800" Height="350">
    <PivotViewDataSourceSettings TValue="ProductDetails" ProviderType="ProviderType.SSAS" Catalog="Adventure Works DW 2008 SE" Cube="Adventure Works" Url="https://bi.syncfusion.com/olap/msmdpump.dll" LocaleIdentifier="1033" EnableSorting="true">
        <PivotViewColumns>
            <PivotViewColumn Name="[Product].[Product Categories]" Caption="Product Category"></PivotViewColumn>
            <PivotViewColumn Name="[Measures]" Caption="Measure"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="[Customer].[Customer Geography]" Caption="Customer Geography"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="[Measures].[Customer Count]" Caption="Customer Count"></PivotViewValue>
            <PivotViewValue Name="[Measures].[Internet Sales Amount]" Caption="Internet Sales Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="[Measures].[Internet Sales Amount]" Format="C0"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
        <PivotViewAuthentication UserName="UserName" Password="Password"></PivotViewAuthentication>
    </PivotViewDataSourceSettings>
    <PivotViewGridSettings ColumnWidth="160"></PivotViewGridSettings>
</SfPivotView>
<style>
    .e-pivotview {
        min-height: 200px;
    }
</style>

@code{
    public class ProductDetails
    {
        public int Sold { get; set; }
        public double Amount { get; set; }
        public string Country { get; set; }
        public string Products { get; set; }
        public string Year { get; set; }
        public string Quarter { get; set; }
    }
}
```

### Roles

SQL Server Analysis Services (SSAS) uses [Roles](https://learn.microsoft.com/en-us/analysis-services/multidimensional-models/roles-and-permissions-analysis-services?view=asallproducts-allversions) to control user access to the data inside an OLAP cube. Each role is defined with a set of permissions that can be assigned to individual users or groups. By assigning roles, you can restrict access to sensitive data and also determine who can view or modify information in the cube.

In the Blazor Pivot Table, you can specify roles using the [Roles](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_Roles) property within the [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html) class. This allows you to provide one or more role names for connecting to an OLAP cube. If you want to use multiple roles, list them as a comma-separated string.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ExpandoObject" Width="800" Height="350">
    <PivotViewDataSourceSettings TValue="ExpandoObject" ProviderType="ProviderType.SSAS" Catalog="Adventure Works DW 2008 SE" Cube="Adventure Works" Url="https://bi.syncfusion.com/olap/msmdpump.dll" Roles="Role1" LocaleIdentifier="1033" EnableSorting="true">
        <PivotViewColumns>
            <PivotViewColumn Name="[Product].[Product Categories]" Caption="Product Category"></PivotViewColumn>
            <PivotViewColumn Name="[Measures]" Caption="Measure"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="[Customer].[Customer Geography]" Caption="Customer Geography"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="[Measures].[Customer Count]" Caption="Customer Count"></PivotViewValue>
            <PivotViewValue Name="[Measures].[Internet Sales Amount]" Caption="Internet Sales Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="[Measures].[Internet Sales Amount]" Format="C0"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
        <PivotViewAuthentication UserName="UserName" Password="Password"></PivotViewAuthentication>
    </PivotViewDataSourceSettings>
    <PivotViewGridSettings ColumnWidth="120"></PivotViewGridSettings>
</SfPivotView>
```

## OLAP Cube: Elements

### Field List

The field list, also called the cube dimension browser, displays the cube elements from the selected OLAP cube in a tree view structure. It organizes elements such as dimensions, hierarchies, and measures into logical groups, making it easier for the user to explore and arrange data for analysis using the Pivot Table.

#### Types of Nodes in the Field List

- **Display folder**: Contains a set of similar cube elements grouped together.
- **Measure**: Represents the numeric values or quantities that users can analyze and summarize in the Pivot Table.
- **Dimension**: Groups related data and helps users to categorize and filter information in the cube.
- **Attribute hierarchy**: Shows data at different attribute levels within a dimension, allowing users to drill down for more specific analysis.
- **User-defined hierarchy**: Presents a custom arrangement of members within a dimension, structured in multiple levels for easier navigation and deeper data analysis.
- **Level**: Indicates a specific position or stage within a hierarchy for more focused data review.
- **Named set**: A saved collection of tuples or members that can be reused in analysis as part of the cube definition.

#### Measure

A measure in a cube refers to a numeric value that comes from a column in the cube’s fact table. Measures are the main values analyzed in the Pivot Table. They help users investigate metrics such as sales, costs, expenditures, or production counts. Users can select measures based on their analysis needs. In the field list, all available measures are grouped separately, making it easy to select or remove measures as required. When a user chooses a measure, it is displayed in the desired area of the Pivot Table and participates in calculations and summary values.

#### Dimension

A dimension is an essential part of the OLAP cube in the Pivot Table. It holds key information, such as its name, hierarchies, levels, and members. To use a dimension, you specify its name, along with the desired hierarchy and the corresponding level. Each dimension contains detailed information about its hierarchies, and each hierarchy is made up of one or more levels. Within each level, there are members, and each member can also have child members. This structure helps users organize and explore data easily in the Pivot Table.

#### Hierarchy

A hierarchy organizes elements within a dimension into a series of parent-child relationships. Each parent member groups its child members, summarizing their data. These parent members can also be grouped under another parent for further summarization. For example, in a time dimension, the month of May 2005 can be grouped under Second Quarter 2005, which is then summarized under the year 2005.

#### Level

A level is a child element of a hierarchy in the field list. It contains a group of members that share the same rank within that hierarchy. For example, in a hierarchy representing geographical data, a level might include members like cities or states, all at the same depth.

#### Attribute Hierarchy

An attribute hierarchy in the Pivot Table organizes data into levels for easier analysis. It includes:

- **Leaf level**: This level contains unique attribute members, known as leaf members. Each leaf member represents a distinct data point.
- **Intermediate levels**: These exist in a parent-child hierarchy, connecting the leaf level to higher levels for structured data exploration.
- **Optional (all) level**: This level shows the combined total of all leaf members' values. The member at this level is called the (all) member.

#### User-Defined Hierarchy

A user-defined hierarchy arranges the members of a dimension into a structured, hierarchical format, making it easier to navigate and analyze data in the cube. For example, consider a dimension table with attributes like year, quarter, and month. These attributes can be combined to create a user-defined hierarchy named Calendar within the time dimension. This hierarchy connects all levels—year, quarter, and month—allowing users to explore data across different time periods seamlessly.

#### Differentiating User-Defined Hierarchy and Attribute Hierarchy

In the field list of the Pivot Table, hierarchies help users organize and analyze data in different ways. There are two main types of hierarchies:

- **User-defined hierarchy**: This type of hierarchy consists of two or more levels. Each level is created by combining related fields, which allows users to drill down through the data step by step—for example, from "Year" to "Quarter" to "Month" within a "Date" dimension. User-defined hierarchies use fields from the same dimension to create a logical path for navigation.
- **Attribute hierarchy**: In this type, there is only a single level. Each field in the dimension automatically forms an attribute hierarchy. For example, if "Country" is a field, it will appear as an attribute hierarchy with just one level, letting the user view data for each country individually.

#### Named Set

A named set is a group of specific tuples or members that can be defined and stored within the OLAP cube. Named sets are saved inside the sets folder under a dimension element in the field list, making them easy to locate. Users can add these named sets to the [PivotViewRows](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewRow.html) or [PivotViewColumns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewColumn.html) axes through the grouping bar or the field list when working with the Pivot Table at runtime. Named sets are useful for handling long, complex, or frequently used expressions. The cube supports defining named sets using Multidimensional Expressions (MDX), which helps users manage these expressions more efficiently.

#### Calculated Field

The calculated field option lets users create a new field in the Pivot Table using their own formula or expression, based on the existing OLAP cube elements in the connected data source. These fields act as custom dimensions or measures, allowing users to add calculations that are not originally available in the cube.

There are two types of calculated fields:

* **Calculated measure** – This allows users to create a new measure by defining a custom expression. The new measure is then available in the field list along with the other measures.
* **Calculated dimension** – This allows users to create a new dimension using a user-defined expression. The dimension is grouped together with other dimensions in the field list.

#### Symbolic Representation of the Nodes Inside Field List

In the field list, each node uses a specific icon to help users quickly identify its type and purpose. The following table describes each type of node, its symbol, and whether it can be dragged into the Axis Fields:

| Icon | Name | Node Type | Is Draggable? |
|------|------|-----------|--------------|
| ![Folder icon in Blazor pivot table component](images/Folder.png) | Display folder | Display Folder | No |
| ![Measure icon in Blazor pivot table component](images/Measure.png) | Measure | Measure | No |
| ![Dimension icon in Blazor pivot table component](images/Dimension.png) | Dimension | Dimension | No |
| ![User-defined hierarchy icon in Blazor pivot table component](images/UserDefinedHierarchy.png) | User-defined hierarchy | Hierarchy | Yes |
| ![Attribute hierarchy icon in Blazor pivot table component](images/AttributeHierarchy.png) | Attribute hierarchy | Hierarchy | Yes |
| ![First level icon in Blazor pivot table component](images/FirstLevel.png)<br>![Second level icon in Blazor pivot table component](images/SecondLevel.png)<br>![Third level icon in Blazor pivot table component](images/ThirdLevel.png) | Levels (in order) | Level Element | Yes |
| ![NamedSet icon in Blazor pivot client control](images/NamedSet.png) | Named set | Named Set | Yes |

N> You can also explore the [Blazor Pivot Table example](https://blazor.syncfusion.com/demos/pivot-table/default-functionalities?theme=bootstrap5) to know how to render and configure the pivot table.