---
layout: post
title: Events in Blazor Pivot Table Component | Syncfusion
description: Checkout and learn here all about events in Syncfusion Blazor Pivot Table component and much more details.
platform: Blazor
control: Pivot Table
documentation: ug
---

# Events in Blazor Pivot Table Component

## AggregateMenuOpen

To know more about this event, refer [here](./grouping-bar#aggregatemenuopen).

## BeforeColumnsRender

The event [BeforeColumnsRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_BeforeColumnsRender) triggers while framing each columns for rendering in the pivot table. It allows the user to customize the text alignment, column visibility, autofit, re-ordering, minimum and maximum width for a specific column. It has the following parameters: 

* [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.ColumnRenderEventArgs.html#Syncfusion_Blazor_PivotView_ColumnRenderEventArgs_Columns): It holds the leaf level columns (i.e., value headers) information.

* [DataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.ColumnRenderEventArgs.html#Syncfusion_Blazor_PivotView_ColumnRenderEventArgs_DataSourceSettings): It holds the current data source settings such as input data source, rows, columns, values, filters, format settings and so on.

* [StackedColumns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.ColumnRenderEventArgs.html#Syncfusion_Blazor_PivotView_ColumnRenderEventArgs_StackedColumns): It holds the drilled columns (i.e., including column and value headers) information.

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
            <PivotViewValue Name="In_Stock" Caption="In Stock"></PivotViewValue>
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
            <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Amount" Format="C"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>        
     <PivotViewEvents TValue="ProductDetails" BeforeColumnsRender="ColumnRender"></PivotViewEvents>   
</SfPivotView>

@code{
    private List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        data = ProductDetails.GetProductData().ToList();
        // Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
    private void ColumnRender(ColumnRenderEventArgs args)
    {
        // triggers before the columns are rendered.
    }
}

```

## BeforeExport

To know more about this event, refer [here](./tool-bar#beforeexport).

## BeginDrillThrough

The event [BeginDrillThrough](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_BeginDrillThrough) is triggered when the value cell is clicked in the Pivot Table while editing. To use this event, user need to enable editing option with the help of [PivotViewCellEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewCellEditSettings.html) class. It has following parameters - [CellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.BeginDrillThroughEventArgs.html#Syncfusion_Blazor_PivotView_BeginDrillThroughEventArgs_CellInfo) and [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.BeginDrillThroughEventArgs.html#Syncfusion_Blazor_PivotView_BeginDrillThroughEventArgs_Type). This event allows user to view the [CellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.BeginDrillThroughEventArgs.html#Syncfusion_Blazor_PivotView_BeginDrillThroughEventArgs_CellInfo) which contains [ColumnHeaders](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DrillThroughEventArgs.html#Syncfusion_Blazor_PivotView_DrillThroughEventArgs_ColumnHeaders), [CurrentCell](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DrillThroughEventArgs.html#Syncfusion_Blazor_PivotView_DrillThroughEventArgs_CurrentCell), [CurrentTarget](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DrillThroughEventArgs.html#Syncfusion_Blazor_PivotView_DrillThroughEventArgs_CurrentTarget), [RawData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DrillThroughEventArgs.html#Syncfusion_Blazor_PivotView_DrillThroughEventArgs_RawData), [RowHeaders](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DrillThroughEventArgs.html#Syncfusion_Blazor_PivotView_DrillThroughEventArgs_RowHeaders) and [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DrillThroughEventArgs.html#Syncfusion_Blazor_PivotView_DrillThroughEventArgs_Value).

N> In this event, the parameter [GridObj](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.BeginDrillThroughEventArgs.html#Syncfusion_Blazor_PivotView_BeginDrillThroughEventArgs_GridObj) is returned as **null** due to its size.

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
            <PivotViewValue Name="Sold" Caption="Unit Sold"></PivotViewValue>
            <PivotViewValue Name="Amount" Caption="Amount"></PivotViewValue>
        </PivotViewValues>
    </PivotViewDataSourceSettings>
    <PivotViewEvents TValue="ProductDetails" BeginDrillThrough="beginDrill"></PivotViewEvents>
    <PivotViewCellEditSettings AllowEditing=true AllowAdding=true AllowDeleting=true Mode=EditMode.Normal></PivotViewCellEditSettings>
</SfPivotView>

@code{
    public List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
    private void beginDrill(BeginDrillThroughEventArgs args)
    {
        //args.CellInfo -> consists of cell info for drillthrough
    }

}

```

## CalculatedFieldCreate

To know more about this event, refer [here](./calculated-field#calculatedfieldcreate).

## CellClick

The [CellClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_CellClick) event is triggered whenever a cell in the Pivot Table component is clicked. This event has an argument named [Data](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.CellClickEventArgs.html#Syncfusion_Blazor_PivotView_CellClickEventArgs_Data). Using this event, end users may customize the information in the selected cell to their specific requirements.

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
            <PivotViewValue Name="Sold" Caption="Unit Sold"></PivotViewValue>
            <PivotViewValue Name="Amount" Caption="Amount"></PivotViewValue>
        </PivotViewValues>
    </PivotViewDataSourceSettings>
    <PivotViewEvents TValue="ProductDetails" CellClick="cellClick"></PivotViewEvents>
</SfPivotView>

<style>
    .e-pivotview .e-custom {
        font-family: 'Courier New', Courier, monospace;
        font-size: 12px !important;
        background: pink !important;
    }
</style>

@code{
    public List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
    private void cellClick(CellClickEventArgs args)
    {
        // Here, we check that the selected cell belongs to the "France" row, and the "FY 2015" column, and that its value is "450".
        if (args.Data.RowHeaders == "France" && args.Data.ColumnHeaders == "FY 2015" && args.Data.FormattedText == "450")
        {
            // If it does, we apply custom styles to the selected cell
            args.Data.CssClass = "e-custom";
        }
    }
}

```

## CellSelected

To know more about this event, refer [here](./row-and-column#event).

## CellSelecting

The event [CellSelecting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_CellSelecting) is triggered when cell selection is about to initiate in the Pivot Table. To use this event, [AllowSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewGridSettings.html#Syncfusion_Blazor_PivotView_PivotViewGridSettings_AllowSelection) property in [PivotViewGridSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewGridSettings.html) must be set to **true**. It has the following parameters -  [Cancel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotCellSelectedEventArgs.html#Syncfusion_Blazor_PivotView_PivotCellSelectedEventArgs_CurrentCell), [CurrentCell](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotCellSelectedEventArgs.html#Syncfusion_Blazor_PivotView_PivotCellSelectedEventArgs_CurrentCell), [IsCellClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotCellSelectedEventArgs.html#Syncfusion_Blazor_PivotView_PivotCellSelectedEventArgs_IsCellClick) and [Data](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotCellSelectedEventArgs.html#Syncfusion_Blazor_PivotView_PivotCellSelectedEventArgs_Data). For instance, using this event, user can pass those selected cell information to any external component for data binding.

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
			<PivotViewValue Name="Sold" Caption="Unit Sold"></PivotViewValue>
			<PivotViewValue Name="Amount" Caption="Amount"></PivotViewValue>
		</PivotViewValues>
	</PivotViewDataSourceSettings>
	<PivotViewGridSettings AllowSelection="true">
		<PivotViewSelectionSettings CellSelectionMode=PivotCellSelectionMode.Box Type=PivotTableSelectionType.Multiple Mode=SelectionMode.Cell></PivotViewSelectionSettings>
	</PivotViewGridSettings>
	<PivotViewEvents TValue="ProductDetails" CellSelecting="cellSelecting"></PivotViewEvents>
</SfPivotView>

@code {
	public List<ProductDetails> data { get; set; }
	protected override void OnInitialized()
	{
		this.data = ProductDetails.GetProductData().ToList();
		//Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
	}
	private void cellSelecting(PivotCellSelectedEventArgs args)
	{
		if (args.Data != null)
		{
			// args.Data -> get selected cells information
		}
	}
}

```

## ChartSeriesCreated

The event [ChartSeriesCreated](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_ChartSeriesCreated) is triggered once chart series are completely rendered. This event is triggered only when [View](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDisplayOption.html#Syncfusion_Blazor_PivotView_PivotViewDisplayOption_View) property in [PivotViewDisplayOption](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDisplayOption.html) class is set to **Chart**.  It has following parameter - [Cancel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.ChartSeriesCreatedEventArgs.html#Syncfusion_Blazor_PivotView_ChartSeriesCreatedEventArgs_Cancel), and [Series](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.ChartSeriesCreatedEventArgs.html#Syncfusion_Blazor_PivotView_ChartSeriesCreatedEventArgs_Series). When the parameter [Cancel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.ChartSeriesCreatedEventArgs.html#Syncfusion_Blazor_PivotView_ChartSeriesCreatedEventArgs_Cancel) is set to **true**, chart series rendered will be revoked.

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
            <PivotViewValue Name="Sold" Caption="Unit Sold"></PivotViewValue>
            <PivotViewValue Name="Amount" Caption="Amount"></PivotViewValue>
        </PivotViewValues>
    </PivotViewDataSourceSettings>
    <PivotViewDisplayOption View=View.Chart></PivotViewDisplayOption>
    <PivotViewEvents TValue="ProductDetails" ChartSeriesCreated="chartSeries"></PivotViewEvents>
</SfPivotView>

@code{
    public List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
    private void chartSeries(ChartSeriesCreatedEventArgs args)
    {
        args.Cancel = true;//chart series will not be rendered
    }
}

```

## ConditionalFormatting

The event [ConditionalFormatting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_ConditionalFormatting) is triggered initially while clicking the "ADD CONDITION" button inside the conditional formatting dialog in-order to fill user specific condition instead of default condition at runtime. To use this event, [AllowConditionalFormatting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_AllowConditionalFormatting) property in [SfPivotView](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html) class must be set to **true**. It has following parameters - [ApplyGrandTotals](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.IConditionalFormatSettings.html#Syncfusion_Blazor_PivotView_IConditionalFormatSettings_ApplyGrandTotals), [Conditions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.IConditionalFormatSettings.html#Syncfusion_Blazor_PivotView_IConditionalFormatSettings_Conditions), [Label](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.IConditionalFormatSettings.html#Syncfusion_Blazor_PivotView_IConditionalFormatSettings_Label), [Measure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.IConditionalFormatSettings.html#Syncfusion_Blazor_PivotView_IConditionalFormatSettings_Measure), [Style](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.IConditionalFormatSettings.html#Syncfusion_Blazor_PivotView_IConditionalFormatSettings_Style), [Value1](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.IConditionalFormatSettings.html#Syncfusion_Blazor_PivotView_IConditionalFormatSettings_Value1) and [Value2](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.IConditionalFormatSettings.html#Syncfusion_Blazor_PivotView_IConditionalFormatSettings_Value2).

```cshtml

@using Syncfusion.Blazor.PivotView
@using Syncfusion.Blazor.Buttons

<SfButton CssClass="apply-button" IsPrimary="true" OnClick="@OnClick">Apply Format</SfButton>
<SfPivotView TValue="ProductDetails" @ref="@Pivot" AllowConditionalFormatting="true">
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
            <PivotViewValue Name="Amount" Caption="Amount"></PivotViewValue>
        </PivotViewValues>
    </PivotViewDataSourceSettings>
    <PivotViewEvents TValue="ProductDetails" ConditionalFormatting="conditionalFormat"></PivotViewEvents>
</SfPivotView>

@code{
    public List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
    SfPivotView<ProductDetails> Pivot;
    public async Task OnClick(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        await this.Pivot.ShowConditionalFormattingDialogAsync();
    }
    private void conditionalFormat(ConditionalFormatSettings args)
    {
        //to change the conditional formatting settings in conditional format dialog
        args.Style.BackgroundColor = "Blue";
        args.Value1 = 23459;
    }
}

```

## DataBound

The [DataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_DataBound) event triggers when data source is populated in the Pivot Table.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" >
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
            <PivotViewValue Name="Amount" Caption="Amount"></PivotViewValue>
        </PivotViewValues>
    </PivotViewDataSourceSettings>
    <PivotViewEvents TValue="ProductDetails" DataBound="databound"></PivotViewEvents>
</SfPivotView>

@code{
    private List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
    private void databound()
    {
        // Here, you can customize your code.
    }
}
```

## Drill

The event [Drill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_Drill) is triggered whenever a member is expanded or collapsed in the Pivot Table. It has following parameters - [DrillInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DrillArgs-1.html#Syncfusion_Blazor_PivotView_DrillArgs_1_DrillInfo) and [PivotView](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DrillArgs-1.html#Syncfusion_Blazor_PivotView_DrillArgs_1__ctor). For instance using this event, user can alter delimiter and drill action for the respective item.

N> In this event, the parameter [PivotView](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DrillArgs-1.html#Syncfusion_Blazor_PivotView_DrillArgs_1__ctor) is returned as **null** due to its size.

```cshtml

@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" AllowConditionalFormatting="true">
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
            <PivotViewValue Name="Amount" Caption="Amount"></PivotViewValue>
        </PivotViewValues>
    </PivotViewDataSourceSettings>
    <PivotViewEvents TValue="ProductDetails" Drill="drill"></PivotViewEvents>
</SfPivotView>

@code{
    public List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
    private void drill(DrillArgs<ProductDetails> args)
    {
        //args.DrillInfo --> Here you can get drilled cell information.
    }
}

```

## DrillThrough

The event [DrillThrough](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_DrillThrough) is triggered when a value cell is clicked in the Pivot Table during drill through operation. It has following parameter - [ColumnHeaders](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DrillThroughEventArgs.html#Syncfusion_Blazor_PivotView_DrillThroughEventArgs_ColumnHeaders), [CurrentCell](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DrillThroughEventArgs.html#Syncfusion_Blazor_PivotView_DrillThroughEventArgs_CurrentCell), [CurrentTarget](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DrillThroughEventArgs.html#Syncfusion_Blazor_PivotView_DrillThroughEventArgs_CurrentTarget), [RawData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DrillThroughEventArgs.html#Syncfusion_Blazor_PivotView_DrillThroughEventArgs_RawData), [RowHeaders](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DrillThroughEventArgs.html#Syncfusion_Blazor_PivotView_DrillThroughEventArgs_RowHeaders) and [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DrillThroughEventArgs.html#Syncfusion_Blazor_PivotView_DrillThroughEventArgs_Value). This event allows user to view cell information like [ColumnHeaders](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DrillThroughEventArgs.html#Syncfusion_Blazor_PivotView_DrillThroughEventArgs_ColumnHeaders), [CurrentCell](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DrillThroughEventArgs.html#Syncfusion_Blazor_PivotView_DrillThroughEventArgs_CurrentCell), [CurrentTarget](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DrillThroughEventArgs.html#Syncfusion_Blazor_PivotView_DrillThroughEventArgs_CurrentTarget), [RawData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DrillThroughEventArgs.html#Syncfusion_Blazor_PivotView_DrillThroughEventArgs_RawData), [RowHeaders](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DrillThroughEventArgs.html#Syncfusion_Blazor_PivotView_DrillThroughEventArgs_RowHeaders) and [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DrillThroughEventArgs.html#Syncfusion_Blazor_PivotView_DrillThroughEventArgs_Value) for the appropriate cell in which drill through is performed. Exclusively the event helps to view and process the raw data information behind a aggregated value inside value cell.

```cshtml

@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" AllowConditionalFormatting="true" AllowDrillThrough="true">
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
            <PivotViewValue Name="Amount" Caption="Amount"></PivotViewValue>
        </PivotViewValues>
    </PivotViewDataSourceSettings>
    <PivotViewEvents TValue="ProductDetails" DrillThrough="drillThrough"></PivotViewEvents>
</SfPivotView>

@code{
    public List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
    private void drillThrough(DrillThroughEventArgs args)
    {
        //args --> Here you can get the information of the clicked cell.
    }
}

```

## EditCompleted

To know more about this event, refer [here](./editing#editcompleted).

## EnginePopulating

The [EnginePopulating](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_EnginePopulating) event is available in both Pivot Table and Field List.

* The event [EnginePopulating](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotFieldListEvents-1.html#Syncfusion_Blazor_PivotView_PivotFieldListEvents_1_EnginePopulating) is triggered from Field List object whenever the report gets modified in its UI.

* Likewise, [EnginePopulating](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_EnginePopulating) event is triggered from Pivot Table object whenever the report gets modified via grouping bar, toolbar, etc.

This event will be triggered before engine framing works gets initiated and allows user to customize the pivot datasource settings. It has the following parameter - [DataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.EnginePopulatingEventArgs.html#Syncfusion_Blazor_PivotView_EnginePopulatingEventArgs_DataSourceSettings).

```cshtml

@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" AllowConditionalFormatting="true">
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
            <PivotViewValue Name="Amount" Caption="Amount"></PivotViewValue>
        </PivotViewValues>
    </PivotViewDataSourceSettings>
    <PivotViewEvents TValue="ProductDetails" EnginePopulating="enginePopulating"></PivotViewEvents>
</SfPivotView>

@code{
    public List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
    private void enginePopulating(EnginePopulatingEventArgs args)
    {
        //args.DataSourceSettings --> User can modify the report before engine populates.
    }
}

```

## EnginePopulated

The [EnginePopulated](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotFieldListEvents-1.html#Syncfusion_Blazor_PivotView_PivotFieldListEvents_1_EnginePopulated) event is available in both Pivot Table and Field List. To know more about this event, refer [here](./field-list#enginepopulated).

## ExcelHeaderQueryCellInfo

To know more about this event, refer [here](./excel-export#excelheaderquerycellinfo).

## ExcelQueryCellInfo

To know more about this event, refer [here](./excel-export#excelquerycellinfo).

## ExportCompleted 

The event [`ExportCompleted`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_ExportCompleted) is triggered after the pivot table (or) pivot chart has been exported to a PDF, Excel, CSV, or other document.

```cshtml
@using Syncfusion.Blazor.PivotView
@using Syncfusion.Blazor.Grids

<SfPivotView @ref="pivot" TValue="ProductDetails" EnableVirtualization="true" ShowFieldList="true" ShowToolbar="true" Toolbar="@toolbar" AllowNumberFormatting="true" AllowConditionalFormatting="true" AllowPdfExport="true" AllowExcelExport="true" Height="300" Width="800">
    <PivotViewDisplayOption Primary=Primary.Table View=View.Both></PivotViewDisplayOption>
        <PivotViewDataSourceSettings DataSource="@data" ShowGrandTotals="true" ShowSubTotals="true">
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
                <PivotViewFormatSetting Name="Amount" Format="C"></PivotViewFormatSetting>
            </PivotViewFormatSettings>
        </PivotViewDataSourceSettings>
        <PivotViewEvents TValue="ProductDetails" ExportCompleted="ExportCompleted"></PivotViewEvents>
        <PivotViewGridSettings ColumnWidth="120"></PivotViewGridSettings>
</SfPivotView>

@code{
    SfPivotView<ProductDetails> pivot;

    public List<ToolbarItems> toolbar = new List<ToolbarItems> {
        ToolbarItems.Grid,
        ToolbarItems.Chart,
        ToolbarItems.Export,
        ToolbarItems.SubTotal,
        ToolbarItems.GrandTotal,
        ToolbarItems.ConditionalFormatting,
        ToolbarItems.NumberFormatting,
        ToolbarItems.FieldList
    };
    public List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
        // Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
    private void ExportCompleted(object args)
    {
       // Triggers when the pivot table (or) pivot chart has been exported to a pdf, excel, csv etc., document.
    }
}

```

## FetchReport

To know more about this event, refer [here](./tool-bar#fetchreport).

## FieldListRefreshed

To know more about this event, refer [here](./field-list#fieldlistrefreshed).

## FieldDragStart

To know more about this event, refer [here](./grouping-bar#fielddragstart).

## FieldDrop

To know more about this event, refer [here](./grouping-bar#fielddrop).

## FieldDropped

The [FieldDropped](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotFieldListEvents-1.html#Syncfusion_Blazor_PivotView_PivotFieldListEvents_1_FieldDropped) event is available in both Grouping Bar and Field List.

To know more about this event with respect to field list operation, refer [here](./field-list#fielddropped).

To know more about this event with respect to grouping bar operation, refer [here](./grouping-bar#fielddropped).

## FieldRemove

To know more about this event, refer [here](./grouping-bar#fieldremove).

## HyperlinkCellClicked

To know more about this event, refer [here](./hyper-link#event).

## LoadReport

To know more about this event, refer [here](./tool-bar#loadreport).

## MemberEditorOpen

To know more about this event, refer [here](./filtering#membereditoropen).

## NewReport

To know more about this event, refer [here](./tool-bar#newreport).

## OnActionBegin

To know more about this event, refer [here](./tool-bar#onactionbegin).

## OnActionComplete

To know more about this event, refer [here](./tool-bar#onactioncomplete).

## OnActionFailure

To know more about this event, refer [here](./tool-bar#onactionfailure).

## OnLoad

The [OnLoad](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_OnLoad) event is available in both Pivot Table and Field List.

To know more about this event, refer [here](./data-binding#event).

## PdfHeaderQueryCellInfo

To know more about this event, refer [here](./pdf-export#pdfheaderquerycellinfo).

## PdfQueryCellInfo

To know more about this event, refer [here](./pdf-export#pdfquerycellinfo).

## RenameReport

To know more about this event, refer [here](./tool-bar#renamereport).

## RemoveReport

To know more about this event, refer [here](./tool-bar#removereport).

## SaveReport

To know more about this event, refer [here](./tool-bar#savereport).

## ToolbarRendered

The event [ToolbarRendered](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_ToolbarRendered) is triggered before rendering of toolbar. This event is available only when toolbar is enabled in the Pivot Table. It has following parameter - [CustomToolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.ToolbarArgs.html#Syncfusion_Blazor_PivotView_ToolbarArgs_CustomToolbar). Using this event user can add custom toolbar items as well as remove existing items from the toolbar.

```cshtml
@using Syncfusion.Blazor.PivotView
@using Syncfusion.Blazor.Navigations
<SfPivotView @ref="pivot" TValue="ProductDetails" ShowFieldList="true" ShowToolbar="true" Toolbar="@toolbar" ShowTooltip="true" AllowConditionalFormatting="true" AllowPdfExport="true" AllowExcelExport="true">
    <PivotViewDisplayOption Primary=Primary.Table View=View.Both></PivotViewDisplayOption>
        <PivotViewDataSourceSettings DataSource="@Data" ShowGrandTotals="true" ShowSubTotals="true">
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
                <PivotViewFormatSetting Name="Amount" Format="C"></PivotViewFormatSetting>
            </PivotViewFormatSettings>
        </PivotViewDataSourceSettings>
        <PivotViewEvents TValue="ProductDetails" ToolbarRendered="ToolbarRender" ></PivotViewEvents>
        <PivotViewGridSettings ColumnWidth="140"></PivotViewGridSettings>
</SfPivotView>

@code {
    private List< Syncfusion.Blazor.PivotView.ToolbarItems> toolbar = new List<Syncfusion.Blazor.PivotView.ToolbarItems> {
        Syncfusion.Blazor.PivotView.ToolbarItems.New,
        Syncfusion.Blazor.PivotView.ToolbarItems.Grid,
        Syncfusion.Blazor.PivotView.ToolbarItems.Chart,
        Syncfusion.Blazor.PivotView.ToolbarItems.Export,
        Syncfusion.Blazor.PivotView.ToolbarItems.SubTotal,
        Syncfusion.Blazor.PivotView.ToolbarItems.GrandTotal,
        Syncfusion.Blazor.PivotView.ToolbarItems.ConditionalFormatting,
        Syncfusion.Blazor.PivotView.ToolbarItems.FieldList
    };
    private SfPivotView<ProductDetails> pivot;
    public List<ProductDetails> Data { get; set; }
    protected override void OnInitialized()
    {
        this.Data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
    public void ToolbarRender(ToolbarArgs args)
    {
        //To change text of New report button
        args.CustomToolbar[0].Text = "New Report";
        //To remove Export menu
        args.CustomToolbar.RemoveAt(3);
        //To add PDF export button
        args.CustomToolbar.Add(new ItemModel
        {
            Text = "PDF Export",
            TooltipText = "PDF Export",
            Click = EventCallback.Factory.Create<ClickEventArgs>(this, PDFButtonClick)
        });
    }
    public void PDFButtonClick(ClickEventArgs args)
    {
        this.pivot.ExportToPdfAsync();
    }   
}

```

N> You can refer to the [Blazor Pivot Table](https://www.syncfusion.com/blazor-components/blazor-pivot-table) feature tour page for its groundbreaking feature representations. You can also explore the [Blazor Pivot Table example](https://blazor.syncfusion.com/demos/pivot-table/default-functionalities?theme=bootstrap5) to know how to render and configure the pivot table.