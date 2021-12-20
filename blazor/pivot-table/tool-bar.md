---
layout: post
title: Toolbar in Blazor Pivot Table Component | Syncfusion
description: Checkout and learn here all about Toolbar in Syncfusion Blazor Pivot Table component and much more details.
platform: Blazor
control: Pivot Table
documentation: ug
---

# Toolbar in Blazor Pivot Table Component

Toolbar option allows to access the frequently used features like switching between pivot table and pivot chart, changing chart types, conditional formatting, exporting, etc... with ease at runtime. This option can be enabled by setting the [ShowToolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_ShowToolbar) property in [SfPivotView](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html) class to **true**. The [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_Toolbar) property in [SfPivotView](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html) class accepts the collection of built-in toolbar options.

## Built-in Toolbar Options

The following table shows built-in toolbar options and its actions.

| Built-in Toolbar Options | Actions |
|------------------------|---------|
| New | Creates a new report |
| Save | Saves the current report |
| Save As | Save as current report |
| Rename | Renames the current report |
| Delete | Deletes the current report |
| Load | Loads any report from the report list |
| Grid | Shows pivot table |
| Chart | Shows a chart in any type from the built-in list and option to enable/disable multiple axes |
| Exporting | Exports the pivot table as PDF/Excel/CSV and the pivot chart as PDF and image |
| Sub-total | Shows or hides sub totals |
| Grand Total | Shows or hides grand totals |
| Conditional Formatting | Shows the conditional formatting pop-up to apply formatting |
| Number Formatting | Shows the number formatting pop-up to apply number formatting |
| Field List | Shows the fieldlist pop-up |
| MDX | Shows the MDX query that was run to retrieve data from the OLAP data source. **NOTE: This applies only to the OLAP data source.** |

> The order of toolbar options can be changed by simply moving the position of items in the [ToolbarItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.ToolbarItems.html) collection. Also if end user wants to remove any toolbar option from getting displayed, it can be simply ignored from adding into the [ToolbarItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.ToolbarItems.html) collection.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" @ref="pivot" ShowFieldList="true" ShowToolbar="true" Toolbar="@toolbar" AllowConditionalFormatting="true" AllowPdfExport="true" AllowExcelExport="true">
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
        <PivotViewEvents TValue="ProductDetails" RenameReport="renamereport" RemoveReport="removereport" SaveReport="savereport" LoadReport="loadreport" FetchReport="fetchreport" ></PivotViewEvents>
        <PivotViewGridSettings ColumnWidth="140"></PivotViewGridSettings>
</SfPivotView>

@code{
    SfPivotView<ProductDetails> pivot;
    public List<ToolbarItems> toolbar = new List<ToolbarItems> {
        ToolbarItems.New,
        ToolbarItems.Load,
        ToolbarItems.Remove,
        ToolbarItems.Rename,
        ToolbarItems.SaveAs,
        ToolbarItems.Save,
        ToolbarItems.Grid,
        ToolbarItems.Chart,
        ToolbarItems.Export,
        ToolbarItems.SubTotal,
        ToolbarItems.GrandTotal,
        ToolbarItems.ConditionalFormatting,
        ToolbarItems.FieldList
    };
    public List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
    public List<string> report = new List<string>();
    public List<string> reportName = new List<string>();
    //to save report
    public void savereport(SaveReportArgs args)
    {
        var i = 0;
        bool isSaved = false;
        for (i = 0; i < this.reportName.Count; i++)
        {
            if (this.reportName[i] == args.ReportName)
            {
                this.report[i] = args.Report;
                isSaved = true;
            }
        }
        if (args.Report != null && !(isSaved))
        {
            this.report.Add(args.Report);
            this.reportName.Add(args.ReportName);
        }

    }
    //fetch reports
    public void fetchreport(FetchReportArgs args)
    {
        args.ReportName = this.reportName.ToArray();

    }
    //to load the selected report
    public void loadreport(LoadReportArgs args)
    {
        var i = 0;
        var j = 0;
        for (i = 0; i < this.reportName.Count; i++)
        {
            if (this.reportName[i] == args.ReportName)
            {
                j = i;
            }
        }
        this.pivot.LoadPersistDataAsync(this.report[j]);
    }
    //to delete a report
    public void removereport(RemoveReportArgs args)
    {
        var i = 0;
        for( i=0;i<this.reportName.Count; i++)
        {
            if(this.reportName[i] == args.ReportName)
            {
                this.reportName.RemoveAt(i);
                this.report.RemoveAt(i);
            }
        }
    }
    // to rename a report
    public void renamereport(RenameReportArgs args)
    {
        var i = 0;
        for( i=0;i<=(this.reportName.Count - 1); i++)
        {
            if(this.reportName[i] == args.ReportName)
            {
                this.reportName.RemoveAt(i);
                this.reportName.Add(args.Rename);
            }
        }
    }
}

```

![Blazor PivotTable with Toolbar](images/blazor-pivottable-with-toolbar.png)

## Show desired chart types in the dropdown menu

By default, all chart types are displayed in the dropdown menu included in the toolbar. However, based on the request for an application, we may need to show selective chart types on our own. This can be achieved using the [ChartTypes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_ChartTypes) property. To know more about supporting chart types, [click here](https://blazor.syncfusion.com/documentation/pivot-table/pivot-chart/#chart-types).

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" ShowToolbar="true" Toolbar="@toolbar" ChartTypes="@chartTypes">
    <PivotViewDisplayOption Primary=Primary.Table View=View.Both></PivotViewDisplayOption>
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
                <PivotViewValue Name="Sold" Caption="Units Sold"></PivotViewValue>
                <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
            </PivotViewValues>
            <PivotViewFormatSettings>
                <PivotViewFormatSetting Name="Amount" Format="C"></PivotViewFormatSetting>
            </PivotViewFormatSettings>
        </PivotViewDataSourceSettings>
        <PivotViewGridSettings ColumnWidth="140"></PivotViewGridSettings>
</SfPivotView>

@code{
    public List<ToolbarItems> toolbar = new List<ToolbarItems> {
        ToolbarItems.Grid,
        ToolbarItems.Chart,
    };
    public List<ChartSeriesType> chartTypes = new List <ChartSeriesType> {
        ChartSeriesType.Column,
        ChartSeriesType.Bar,
        ChartSeriesType.Line,
        ChartSeriesType.Area,
    };
    public List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
}

```

![Displaying Blazor PivotChart in DropDown Menu](images/blazor-pivotchart-in-dropdown-menu.png)

## Switch the chart to multiple axes

In the chart, the user can switch from single axis to multiple axes with the help of the built-in checkbox available inside the chart type dropdown menu in the toolbar. For more information [refer here](https://blazor.syncfusion.com/documentation/pivot-table/pivot-chart/#multi-axis).

![Displaying Multiple Axes in Blazor PivotTable DropDown Menu](images/blazor-pivotchart-show-multiple-axes.png)

## Show or hide legend

In the chart, legend can be shown or hidden dynamically with the help of the built-in option available in the chart type drop-down menu.
> By default, the legend is not be visible for the accumulation chart types like pie, doughnut, pyramid, and funnel. Users can enable or disable using the built-in checkbox option.

![Blazor PivotChart with Legend](images/blazor-pivotchart-legend.png)

## Events

### FetchReport

The event [FetchReport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_FetchReport) is triggered when dropdown list is clicked in the toolbar in-order to retrieve and populate saved reports. It has following parameter - [ReportName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.FetchReportArgs.html#Syncfusion_Blazor_PivotView_FetchReportArgs_ReportName). This event allows user to fetch the report names from local storage and populate the dropdown list.

### LoadReport

The event [LoadReport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_FetchReport) is triggered when a report is selected from the dropdown list in the toolbar. It has following parameters - [Report](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.LoadReportArgs.html#Syncfusion_Blazor_PivotView_LoadReportArgs_Report) and [ReportName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.LoadReportArgs.html#Syncfusion_Blazor_PivotView_LoadReportArgs_ReportName). This event allows user to load the selected report to the pivot table.

### NewReport

The event [NewReport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_NewReport) is triggered when the new report icon is clicked in the toolbar. It has following parameter - [Report](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.NewReportArgs.html#Syncfusion_Blazor_PivotView_NewReportArgs_Report). This event allows user to create new report and add to the report list.

### RenameReport

The event [RenameReport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_RenameReport) is triggered when rename report icon is clicked in the toolbar. It has following parameters  - [Rename](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.RenameReportArgs.html#Syncfusion_Blazor_PivotView_RenameReportArgs_Rename), [Report](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.RenameReportArgs.html#Syncfusion_Blazor_PivotView_RenameReportArgs_Report) and [ReportName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.RenameReportArgs.html#Syncfusion_Blazor_PivotView_RenameReportArgs_ReportName). This event allows user to rename the selected report from the report list.

### RemoveReport

The event [RemoveReport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_RemoveReport) is triggered when remove report icon is clicked in the toolbar. It has following parameters  - [Report](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.RemoveReportArgs.html#Syncfusion_Blazor_PivotView_RemoveReportArgs_Report) and [ReportName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.RemoveReportArgs.html#Syncfusion_Blazor_PivotView_RemoveReportArgs_ReportName). This event allows user to remove the selected report from the report list.

### SaveReport

The event [SaveReport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_SaveReport) is triggered when save report icon is clicked in the toolbar. It has following parameters  - [Report](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SaveReportArgs.html#Syncfusion_Blazor_PivotView_SaveReportArgs_Report) and [ReportName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SaveReportArgs.html#Syncfusion_Blazor_PivotView_SaveReportArgs_ReportName). This event allows user to save the altered report to the report list.

<!-- markdownlint-disable MD028 -->

### BeforeExport

The pivot table (or) pivot chart can be exported as a pdf, excel, csv etc.,  document using the toolbar options. And, you can customize the export settings for exporting document by using the `BeforeExport` event in the toolbar.

For example, you can add the header and footer for the pdf document by setting the `header` and `footer` properties for the `PdfExportProperties` in the `BeforeExport` event.

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
        <PivotViewEvents TValue="ProductDetails" BeforeExport="beforeExport" RenameReport="renamereport" RemoveReport="removereport" SaveReport="savereport" LoadReport="loadreport" FetchReport="fetchreport" ></PivotViewEvents>
        <PivotViewGridSettings ColumnWidth="140"></PivotViewGridSettings>
</SfPivotView>

@code{
    SfPivotView<ProductDetails> pivot;

    public List<ToolbarItems> toolbar = new List<ToolbarItems> {
        ToolbarItems.New,
        ToolbarItems.Load,
        ToolbarItems.Remove,
        ToolbarItems.Rename,
        ToolbarItems.SaveAs,
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
    public List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
    public List<PdfHeaderFooterContent> HeaderContent = new List<PdfHeaderFooterContent>
    {
        new PdfHeaderFooterContent() { Type = ContentType.Line, Points = new PdfPoints() { X1 = 0, Y1 = 4, X2 = 685, Y2 = 4 }, Style = new PdfContentStyle() { PenColor = "#000080", DashStyle = PdfDashStyle.Solid }}
    };
    public void beforeExport(BeforeExportEventArgs args) {
        PdfExportProperties ExportProperties = new PdfExportProperties();
        PdfHeader Header = new PdfHeader()
        {
            FromTop = 0,
            Height = 130,
            Contents = HeaderContent
        };
        ExportProperties.Header = Header;
        args.PdfExportProperties = ExportProperties;

            ExcelExportProperties ExcelProperties = new ExcelExportProperties();
        ExcelTheme Theme = new ExcelTheme();

        ExcelStyle ThemeStyle = new ExcelStyle()
        {
            FontName = "Segoe UI",
            FontColor = "#666666",
            FontSize = 20
        };

        Theme.Header = ThemeStyle;
        Theme.Record = ThemeStyle;
        Theme.Caption = ThemeStyle;
        ExcelProperties.Theme = Theme;
        args.ExcelExportProperties = ExcelProperties;
    }
    public List<string> report = new List<string>();
    public List<string> reportName = new List<string>();
    //to save report
    public void savereport(SaveReportArgs args)
    {
        var i = 0;
        bool isSaved = false;
        for (i = 0; i < this.reportName.Count; i++)
        {
            if (this.reportName[i] == args.ReportName)
            {
                this.report[i] = args.Report;
                isSaved = true;
            }
        }
        if (args.Report != null && !(isSaved))
        {
            this.report.Add(args.Report);
            this.reportName.Add(args.ReportName);
        }

    }
    //fetch reports
    public void fetchreport(FetchReportArgs args)
    {
        args.ReportName = this.reportName.ToArray();

    }
    //to load the selected report
    public void loadreport(LoadReportArgs args)
    {
        var i = 0;
        var j = 0;
        for (i = 0; i < this.reportName.Count; i++)
        {
            if (this.reportName[i] == args.ReportName)
            {
                j = i;
            }
        }
        this.pivot.LoadPersistDataAsync(this.report[j]);
    }
    //to delete a report
    public void removereport(RemoveReportArgs args)
    {
        var i = 0;
        for( i=0;i<this.reportName.Count; i++)
        {
            if(this.reportName[i] == args.ReportName)
            {
                this.reportName.RemoveAt(i);
                this.report.RemoveAt(i);
            }
        }
    }
    // to rename a report
    public void renamereport(RenameReportArgs args)
    {
        var i = 0;
        for( i=0;i<=(this.reportName.Count - 1); i++)
        {
            if(this.reportName[i] == args.ReportName)
            {
                this.reportName.RemoveAt(i);
                this.reportName.Add(args.Rename);
            }
        }
    }
}

```

> You can refer to our [Blazor Pivot Table](https://www.syncfusion.com/blazor-components/blazor-pivot-table) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Pivot Table example](https://blazor.syncfusion.com/demos/pivot-table/default-functionalities?theme=bootstrap4) to knows how to render and configure the pivot table.