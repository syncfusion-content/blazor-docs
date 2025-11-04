---
layout: post
title: Hyperlink in Blazor Pivot Table Component | Syncfusion
description: Checkout and learn here all about Hyperlink in Syncfusion Blazor Pivot Table component and much more.
platform: Blazor
control: Pivot Table
documentation: ug
---

# Hyperlink in Blazor Pivot Table Component

The Pivot Table component provides built-in support for displaying hyperlinks within individual cells. This feature allows users to link data in specific cells, enhancing interactivity and navigation.

Hyperlinks can be selectively enabled for various cell types, including:

- Row headers
- Column headers
- Value cells
- Summary cells

You can control hyperlink behavior using the [PivotViewHyperlinkSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewHyperlinkSettings.html) class, which can be defined during the initial rendering through the code-behind.

## Available Hyperlink Settings

The following properties are available in PivotViewHyperlinkSettings:

* [ShowHyperlink](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewHyperlinkSettings.html#Syncfusion_Blazor_PivotView_PivotViewHyperlinkSettings_ShowHyperlink): It allows to set the visibility of hyperlink in all cells.
* [ShowRowHeaderHyperlink](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewHyperlinkSettings.html#Syncfusion_Blazor_PivotView_PivotViewHyperlinkSettings_ShowRowHeaderHyperlink): It allows to set the visibility of hyperlink in row headers.
* [ShowColumnHeaderHyperlink](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewHyperlinkSettings.html#Syncfusion_Blazor_PivotView_PivotViewHyperlinkSettings_ShowColumnHeaderHyperlink): It allows to set the visibility of hyperlink in column headers.
* [ShowValueCellHyperlink](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewHyperlinkSettings.html#Syncfusion_Blazor_PivotView_PivotViewHyperlinkSettings_ShowValueCellHyperlink): It allows to set the visibility of hyperlink in value cells.
* [ShowSummaryCellHyperlink](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewHyperlinkSettings.html#Syncfusion_Blazor_PivotView_PivotViewHyperlinkSettings_ShowSummaryCellHyperlink): It allows to set the visibility of hyperlink in summary cells.
* [HeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewHyperlinkSettings.html#Syncfusion_Blazor_PivotView_PivotViewHyperlinkSettings_HeaderText): It allows to set the visibility of hyperlink based on header text.
* [ConditionalSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewConditionalSetting.html): It allows to set the visibility of hyperlink based on specific condition.

<!-- markdownlint-disable MD028 -->
N> By default, the hyperlink options are disabled for all cells in the Pivot Table.

N> User defined style can be applied to hyperlink using [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewHyperlinkSettings.html#Syncfusion_Blazor_PivotView_PivotViewHyperlinkSettings_CssClass) property in [PivotViewHyperlinkSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewHyperlinkSettings.html) class.

## Hyperlink for all cells

The Pivot Table provides an option to display hyperlinks across **all cells** currently visible in the table. To enable this functionality, set the [ShowHyperlink](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewHyperlinkSettings.html#Syncfusion_Blazor_PivotView_PivotViewHyperlinkSettings_ShowHyperlink) property to **true** within the [PivotViewHyperlinkSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewHyperlinkSettings.html).

Once enabled, hyperlinks will be shown consistently in row headers, column headers, value cells, and summary cells.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" ShowFieldList="true">
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
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Amount" Format="C0"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
    <PivotViewHyperlinkSettings ShowHyperlink="true" CssClass="e-custom-class">
    </PivotViewHyperlinkSettings>
</SfPivotView>

<style>
.e-custom-class,.e-custom-class:hover {
    text-decoration: underline !important;
    color: blue !important;
}
.e-custom-class:hover {
    color: red !important;
}
</style>
@code{
    public List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
}
```

![Hyperlink with All Cells in Blazor PivotTable](images/blazor-pivottable-hyperlink-with-cells.png)

## Hyperlink for row headers

The Pivot Table provides a way to display hyperlinks specifically in **row header cells** that are currently visible. To enable this functionality, set the [ShowRowHeaderHyperlink](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewHyperlinkSettings.html#Syncfusion_Blazor_PivotView_PivotViewHyperlinkSettings_ShowRowHeaderHyperlink) property to **true** within the [PivotViewHyperlinkSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewHyperlinkSettings.html). This ensures that only the row headers will display hyperlinks, while other cell types remain unaffected.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails">
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
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Amount" Format="C0"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
    <PivotViewHyperlinkSettings ShowRowHeaderHyperlink="true" CssClass="e-custom-class">
    </PivotViewHyperlinkSettings>
</SfPivotView>

<style>
.e-custom-class,.e-custom-class:hover {
    text-decoration: underline !important;
    color: blue !important;
}
.e-custom-class:hover {
    color: red !important;
}
</style>
@code{
    public List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
}
```

![Hyperlink in Blazor PivotTable Row Headers](images/blazor-pivottable-hyperlink-in-row-headers.png)

## Hyperlink for column headers

The Pivot Table provides an option to display hyperlinks specifically in column header cells that are currently visible. To enable this functionality, set the [ShowColumnHeaderHyperlink](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewHyperlinkSettings.html#Syncfusion_Blazor_PivotView_PivotViewHyperlinkSettings_ShowColumnHeaderHyperlink) property to **true** within the [PivotViewHyperlinkSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewHyperlinkSettings.html) class. This ensures that only the column headers will display hyperlinks, while other cell types remain unaffected.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails">
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
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Amount" Format="C0"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
    <PivotViewHyperlinkSettings ShowColumnHeaderHyperlink="true" CssClass="e-custom-class">
    </PivotViewHyperlinkSettings>
</SfPivotView>

<style>
.e-custom-class,.e-custom-class:hover {
    text-decoration: underline !important;
    color: blue !important;
}
.e-custom-class:hover {
    color: red !important;
}
</style>
@code{
    public List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
}
```

![Hyperlink in Blazor Column Headers](images/blazor-pivottable-hyperlink-in-column-headers.png)

## Hyperlink for value cells

The Pivot Table provides support for displaying hyperlinks specifically in value cells that are currently visible. To enable this option, set the [ShowValueCellHyperlink](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewHyperlinkSettings.html#Syncfusion_Blazor_PivotView_PivotViewHyperlinkSettings_ShowValueCellHyperlink) property to **true** within the [PivotViewHyperlinkSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewHyperlinkSettings.html) class. This ensures that only the value cells will display hyperlinks, while other cell types remain unaffected.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails">
    <PivotViewDataSourceSettings DataSource="@data" ExpandAll="true">
        <PivotViewColumns>
            <PivotViewColumn Name="Year"></PivotViewColumn>
            <PivotViewColumn Name="Quarter"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="Country"></PivotViewRow>
            <PivotViewRow Name="Products"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Amount" Format="C0"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
    <PivotViewHyperlinkSettings ShowValueCellHyperlink="true" CssClass="e-custom-class">
    </PivotViewHyperlinkSettings>
</SfPivotView>

<style>
.e-custom-class,.e-custom-class:hover {
    text-decoration: underline !important;
    color: blue !important;
}
.e-custom-class:hover {
    color: red !important;
}
</style>
@code{
    public List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
}
```

![Hyperlink with Value Cells in Blazor PivotTable](images/blazor-pivottable-hyperlink-in-value-cells.png)

## Hyperlink for summary cells

The Pivot Table provides support for displaying hyperlinks specifically in summary cells that are currently visible. To enable this option, set the [ShowSummaryCellHyperlink](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewHyperlinkSettings.html#Syncfusion_Blazor_PivotView_PivotViewHyperlinkSettings_ShowSummaryCellHyperlink) property to **true** within the [PivotViewHyperlinkSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewHyperlinkSettings.html) class. This ensures that only the summary cells will display hyperlinks, while other cell types remain unaffected.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails">
    <PivotViewDataSourceSettings DataSource="@data" ExpandAll="true">
        <PivotViewColumns>
            <PivotViewColumn Name="Year"></PivotViewColumn>
            <PivotViewColumn Name="Quarter"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="Country"></PivotViewRow>
            <PivotViewRow Name="Products"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Amount" Format="C0"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
    <PivotViewHyperlinkSettings ShowSummaryCellHyperlink="true" CssClass="e-custom-class">
    </PivotViewHyperlinkSettings>
</SfPivotView>

<style>
.e-custom-class,.e-custom-class:hover {
    text-decoration: underline !important;
    color: blue !important;
}
.e-custom-class:hover {
    color: red !important;
}
</style>
@code{
    public List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
}
```

![Hyperlink in Blazor PivotTable Summary Cells](images/blazor-pivottable-hyperlink-in-summary-cells.png)

## Condition based hyperlink

The Pivot Table supports displaying hyperlinks in specific cells based on defined conditions. This functionality can be configured through code-behind during initial rendering using the [PivotViewConditionalSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewConditionalSetting.html) class.

* [Measure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewConditionalSetting.html#Syncfusion_Blazor_PivotView_PivotViewConditionalSetting_Measure): Specifies the value field name for which the hyperlink should be shown when the condition is met.
* [Conditions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewConditionalSetting.html#Syncfusion_Blazor_PivotView_PivotViewConditionalSetting_Conditions): Specifies the operator type such as [Condition.Equals](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.Condition.html), [Condition.GreaterThan](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.Condition.html), [Condition.LessThan](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.Condition.html), etc.
* [Value1](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewConditionalSetting.html#Syncfusion_Blazor_PivotView_PivotViewConditionalSetting_Value1): Sets the starting value for the condition.
* [Value2](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewConditionalSetting.html#Syncfusion_Blazor_PivotView_PivotViewConditionalSetting_Value2): Sets the ending value for the condition (used in range-based comparisons).

In the example below, the Pivot Table is configured to display hyperlinks only in cells where the "Units Sold" field value is between **100** and **200**. This highlights specific aggregated values that meet the given condition.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails">
    <PivotViewDataSourceSettings DataSource="@data" ExpandAll="true">
        <PivotViewColumns>
            <PivotViewColumn Name="Year"></PivotViewColumn>
            <PivotViewColumn Name="Quarter"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="Country"></PivotViewRow>
            <PivotViewRow Name="Products"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Sold" Caption="Units Sold"></PivotViewValue>
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Amount" Format="C0"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
    <PivotViewHyperlinkSettings CssClass="e-custom-class">
        <PivotViewConditionalSettings>
            <PivotViewConditionalSetting Measure="Sold" Conditions=Condition.Between Value1="100" Value2="200"></PivotViewConditionalSetting>
        </PivotViewConditionalSettings>
    </PivotViewHyperlinkSettings>
</SfPivotView>

<style>
.e-custom-class,.e-custom-class:hover {
    text-decoration: underline !important;
    color: blue !important;
}
.e-custom-class:hover {
    color: red !important;
}
</style>
@code{
    public List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
}
```

![Hyperlink in Blazor PivotTable Cells based on Condition](images/blazor-pivottable-hyperlink-cell-based-on-condition.png)

## Header based hyperlink

The Pivot Table supports displaying hyperlinks in cells based on specific row or column headers. This functionality can be enabled using the [HeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewHyperlinkSettings.html#Syncfusion_Blazor_PivotView_PivotViewHyperlinkSettings_HeaderText) property, which is configured through code-behind during initial rendering.

In the below code example, the value **FY 2015** is assigned to [HeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewHyperlinkSettings.html#Syncfusion_Blazor_PivotView_PivotViewHyperlinkSettings_HeaderText), which means the Pivot Table will show hyperlinks only in cells that match this specific header combination.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails">
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
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Amount" Format="C0"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
    <PivotViewHyperlinkSettings HeaderText="FY 2015" CssClass="e-custom-class"></PivotViewHyperlinkSettings>
</SfPivotView>

<style>
.e-custom-class,.e-custom-class:hover {
    text-decoration: underline !important;
    color: blue !important;
}
.e-custom-class:hover {
    color: red !important;
}
</style>

@code{
    public List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
}
```

![Hyperlink in Blazor PivotTable Cells based on Header](images/blazor-pivottable-hyperlink-cell-based-on-header.png)

## Event

The Pivot Table triggers the [`HyperlinkCellClicked`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_HyperlinkCellClicked) event whenever a hyperlink cell is clicked. This event allows you to either customize the clicked cell or retrieve information about it.

It provides two parameters:

* [`CurrentCell`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.HyperCellClickEventArgs.html#Syncfusion_Blazor_PivotView_HyperCellClickEventArgs_CurrentCell): Refers to the clicked cell element, which can be modified as needed.
* [`Cancel`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.HyperCellClickEventArgs.html#Syncfusion_Blazor_PivotView_HyperCellClickEventArgs_Cancel): If set to **true**, prevents any changes from being applied to the cell.
* [`Data`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.HyperCellClickEventArgs.html#Syncfusion_Blazor_PivotView_HyperCellClickEventArgs_Data): Contains detailed information about the clicked cell, including its value, row and column headers, position, and whether it’s a summary cell.
* [`NativeEvent`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.HyperCellClickEventArgs.html#Syncfusion_Blazor_PivotView_HyperCellClickEventArgs_NativeEvent): Represents the original browser event triggered by the click, useful for advanced event handling.

In the example below, when a hyperlink cell is clicked, the cell is checked to determine if it is a row header. If it is a row header (e.g., 'France'), the user is redirected to the corresponding Wikipedia page (e.g., 'https://en.wikipedia.org/wiki/France'). If the clicked cell is a column header, value cell, or summary cell, the user is redirected to 'https://syncfusion.com/'. The [`Cancel`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.HyperCellClickEventArgs.html#Syncfusion_Blazor_PivotView_HyperCellClickEventArgs_Cancel) property is set to **false** to enable this interaction.

```cshtml
@using Syncfusion.Blazor.PivotView
@inject IJSRuntime JSRuntime

<SfPivotView TValue="ProductDetails" ShowFieldList="true">
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
			<PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
		</PivotViewValues>
	</PivotViewDataSourceSettings>
	<PivotViewHyperlinkSettings ShowHyperlink="true" CssClass="e-custom-class">
	</PivotViewHyperlinkSettings>
	<PivotViewEvents TValue="ProductDetails" HyperlinkCellClicked="OnHyperLinkClick"></PivotViewEvents>
</SfPivotView>

<script type="text/javascript">
	function navigateFromPivotCellCoordinates(rowIndex, colIndex, baseUrl) {
		const element = document.querySelector('[index="' + rowIndex + '"][aria-colindex="' + (colIndex + 1) + '"]');
		const cellcontent =  element.innerText;
		if (element && element.classList.contains('e-rowsheader') && cellcontent != "Grand Total")
		{
			const finalUrl = `${baseUrl}${encodeURIComponent(cellcontent)}`;
			console.log(`Navigating from DOM element at [${rowIndex}, ${colIndex}] to: ${finalUrl}`);
			window.location.href = finalUrl;
		}
		else
		{
			const finalUrl = "https://syncfusion.com/";
			console.log(`Navigating from DOM element at [${rowIndex}, ${colIndex}] to: ${finalUrl}`);
			window.location.href = finalUrl;
		}
	}
</script>

<style>
	.e-custom-class, .e-custom-class:hover {
		text-decoration: underline !important;
		color: blue !important;
	}

	.e-custom-class:hover {
		color: red !important;
	}
</style>
@code {
	public List<ProductDetails> data { get; set; }
	protected override void OnInitialized()
	{
		this.data = ProductDetails.GetProductData().ToList();
		//Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
	}
	public async Task OnHyperLinkClick(HyperCellClickEventArgs args)
	{
		int row = (args.Data as AxisSet).RowIndex;
		int col = (args.Data as AxisSet).ColIndex;
		string baseUrl = "https://en.wikipedia.org/wiki/";
		await JSRuntime.InvokeVoidAsync("navigateFromPivotCellCoordinates", row, col, baseUrl);
	}
}
```

N> Refer to the [Blazor Pivot Table](https://www.syncfusion.com/blazor-components/blazor-pivot-table) feature tour page for its groundbreaking feature representations. You can also explore the [Blazor Pivot Table example](https://blazor.syncfusion.com/demos/pivot-table/default-functionalities?theme=bootstrap5) to know how to render and configure the pivot table.
