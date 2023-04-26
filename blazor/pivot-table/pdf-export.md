---
layout: post
title: PDF Export in Blazor Pivot Table Component | Syncfusion
description: Checkout and learn here all about PDF Export in Syncfusion Blazor Pivot Table component and much more.
platform: Blazor
control: Pivot Table
documentation: ug
---

# PDF Export in Blazor Pivot Table Component

The PDF export allows Pivot Table data to be exported as PDF document. To enable PDF export in the pivot table, set the [AllowPdfExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_AllowPdfExport) in [SfPivotView](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html) as **true**. Once the API is set, the user needs to call the [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_PdfExport_System_Object_System_Nullable_System_Boolean__System_Object_System_Nullable_System_Boolean__) method for exporting, on external button click.

N> The pivot table component can be exported to PDF format using options available in the toolbar. For more details [refer](./tool-bar) here.

```cshtml
@using Syncfusion.Blazor.PivotView
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="OnPdfExport" Content="Pdf Export"></SfButton>
<SfPivotView TValue="ProductDetails" @ref="@pivot" AllowPdfExport="true" >
    <PivotViewDataSourceSettings DataSource="@Data" EnableSorting=true>
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
            <PivotViewFormatSetting Name="Amount" Format="C0" UseGrouping=true></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
</SfPivotView>

@code{
    SfPivotView<ProductDetails> pivot;
    public List<ProductDetails> Data { get; set; }
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
       //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
    public void OnPdfExport(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        this.pivot.ExportToPdfAsync();
    }
}
```

![PDF Export in Blazor PivotTable](images/blazor-pivottable-pdf-export.png)

## Changing the pivot table style while exporting

The PDF export provides an option to change colors for headers, caption and records in the pivot table before exporting. In-order to apply colors, define **theme** settings in **pdfExportProperties** object and pass it as a parameter to the [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_PdfExport_System_Object_System_Nullable_System_Boolean__System_Object_System_Nullable_System_Boolean__) method.

N> By default, material theme will be applied to the pivot table during PDF exporting.

```cshtml
@using Syncfusion.Blazor.PivotView
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="OnPdfExport" Content="Pdf Export"></SfButton>
<SfPivotView TValue="ProductDetails" @ref="@pivot" AllowPdfExport="true" >
    <PivotViewDataSourceSettings DataSource="@Data" EnableSorting=true>
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
            <PivotViewFormatSetting Name="Amount" Format="C0" UseGrouping=true></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
</SfPivotView>

@code{
    SfPivotView<ProductDetails> pivot;
    public List<ProductDetails> Data { get; set; }
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
       //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
    public void OnPdfExport(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        Syncfusion.Blazor.Grids.PdfExportProperties pdfExportProperties = new Syncfusion.Blazor.Grids.PdfExportProperties()
        {
            Theme = new Syncfusion.Blazor.Grids.PdfTheme()
            {
                Header = new Syncfusion.Blazor.Grids.PdfThemeStyle()
                {
                    FontColor = "#0fb5fc",
                    FontName = "Calibri",
                    FontSize = 15,
                    Bold = true,
                    Border = new Syncfusion.Blazor.Grids.PdfBorder() { Color = "#000000" }
                },
                Record = new Syncfusion.Blazor.Grids.PdfThemeStyle()
                {
                    FontColor = "#000000",
                    FontName = "Segoe UI",
                    FontSize = 12
                },
                Caption = new Syncfusion.Blazor.Grids.PdfThemeStyle()
                {
                    FontColor = "#000000",
                    FontName = "Segoe UI",
                    FontSize = 12,
                }
            }
        };
        this.pivot.ExportToPdfAsync(pdfExportProperties);
    }
}
```

![Changing Blazor PivotTable Style while Exporting](images/blazor-pivottable-pdf-formatting.png)

## Changing the file name while exporting

The PDF export provides an option to change the file name of the document before exporting. In-order to change the file name, define **fileName** property in **pdfExportProperties** object and pass it as a parameter to the [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_PdfExport_System_Object_System_Nullable_System_Boolean__System_Object_System_Nullable_System_Boolean__) method.

```cshtml
@using Syncfusion.Blazor.PivotView
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="OnPdfExport" Content="Pdf Export"></SfButton>
<SfPivotView TValue="ProductDetails" @ref="@pivot" AllowPdfExport="true" >
    <PivotViewDataSourceSettings DataSource="@Data" EnableSorting=true>
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
            <PivotViewFormatSetting Name="Amount" Format="C0" UseGrouping=true></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
</SfPivotView>

@code{
    SfPivotView<ProductDetails> pivot;
    public List<PivotViewData.ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        this.data = PivotViewData.GetProductData().ToList();
       //Bind your dataSource collection here, refer the getting started section. for more information.
    }
    public void OnPdfExport(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        Syncfusion.Blazor.Grids.PdfExportProperties pdfExportProperties = new Syncfusion.Blazor.Grids.PdfExportProperties() { FileName = "sample.pdf" };
        this.pivot.ExportToPdfAsync(pdfExportProperties);
    }
}
```

![Changing Blazor PivotTable File Name while Exporting](images/blazor-pivottable-change-pdf-file-name.png)

## Changing page size while exporting

The PDF export provides an option to change page size of the document before exporting. In-order to change the page size, define **pageSize** property in **pdfExportProperties** object and pass it as a parameter to the [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_PdfExport_System_Object_System_Nullable_System_Boolean__System_Object_System_Nullable_System_Boolean__) method.

**Supported page sizes are:** Letter, Note, Legal, A0, A1, A2, A3, A5, A6, A7, A8, A9, B0, B1, B2, B3, B4, B5, Archa, Archb, Archc, Archd, Arche, Flsa, HalfLetter, Letter11x17, Ledger.

```cshtml
@using Syncfusion.Blazor.PivotView
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="OnPdfExport" Content="Pdf Export"></SfButton>
<SfPivotView TValue="ProductDetails" @ref="@pivot" AllowPdfExport="true" >
    <PivotViewDataSourceSettings DataSource="@Data" EnableSorting=true>
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
            <PivotViewFormatSetting Name="Amount" Format="C0" UseGrouping=true></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
</SfPivotView>

@code{
    SfPivotView<ProductDetails> pivot;
    public List<ProductDetails> Data { get; set; }
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
       //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
    public void OnPdfExport(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        Syncfusion.Blazor.Grids.PdfExportProperties pdfExportProperties = new Syncfusion.Blazor.Grids.PdfExportProperties() {  PageSize = Syncfusion.Blazor.Grids.PdfPageSize.A3 };
        this.pivot.ExportToPdfAsync(pdfExportProperties);
    }
}
```

![Changing Blazor PivotTable Page Size while Exporting](images/blazor-pivottable-change-pdf-page-size.png)

## Changing page orientation while exporting

The PDF export provides an option to change page orientation of the document before exporting. In-order to change the page orientation, define **pageOrientation** property in **pdfExportProperties** object and pass it as a parameter to the [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_PdfExport_System_Object_System_Nullable_System_Boolean__System_Object_System_Nullable_System_Boolean__) method. By default, the page orientation will be in **Portrait** and it can be changed to **Landscape** based on the user requirement.

```cshtml
@using Syncfusion.Blazor.PivotView
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="OnPdfExport" Content="Pdf Export"></SfButton>
<SfPivotView TValue="ProductDetails" @ref="@pivot" AllowPdfExport="true" >
    <PivotViewDataSourceSettings DataSource="@Data" EnableSorting=true>
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
            <PivotViewFormatSetting Name="Amount" Format="C0" UseGrouping=true></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
</SfPivotView>

@code{
    SfPivotView<ProductDetails> pivot;
    public List<ProductDetails> Data { get; set; }
    protected override void OnInitialized(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        this.data = ProductDetails.GetProductData().ToList();
       //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
    public void OnPdfExport()
    {
        Syncfusion.Blazor.Grids.PdfExportProperties pdfExportProperties = new Syncfusion.Blazor.Grids.PdfExportProperties() { PageOrientation = Syncfusion.Blazor.Grids.PageOrientation.PageOrientation.Landscape };
        this.pivot.ExportToPdfAsync(pdfExportProperties);
    }
}
```

![Changing Blazor PivotTable Page Orientation while Exporting](images/blazor-pivottable-change-pdf-orientation.png)

## Events

### PdfQueryCellInfo

The event [PdfQueryCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_PdfQueryCellInfo) triggers on framing each row and value cell during PDF export. It allows the user customize the cell value, style, etc. of the current cell. It has the following parameters.

* [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfQueryCellInfoEventArgs-1.html#Syncfusion_Blazor_Grids_PdfQueryCellInfoEventArgs_1_Value) : It holds the cell value.
* [Column](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfQueryCellInfoEventArgs-1.html#Syncfusion_Blazor_Grids_PdfQueryCellInfoEventArgs_1_Column) : It holds the column information, including row and column indexes required to obtain the current cell information. **Note:** This option is applicable only when virtualization is disabled.
* [Cell](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfQueryCellInfoEventArgs-1.html#Syncfusion_Blazor_Grids_PdfQueryCellInfoEventArgs_1_Cell) : It holds the current cell information.
* [Style](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfQueryCellInfoEventArgs-1.html#Syncfusion_Blazor_Grids_PdfQueryCellInfoEventArgs_1_Style) : It holds the style properties for the cell.
* [RowIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfQueryCellInfoEventArgs-1.html#Syncfusion_Blazor_Grids_PdfQueryCellInfoEventArgs_1_RowIndex) : It holds the row index required to get the current cell information. **Note:** When virtualization is enabled, this option is applicable.
* [ColumnIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfQueryCellInfoEventArgs-1.html#Syncfusion_Blazor_Grids_PdfQueryCellInfoEventArgs_1_ColumnIndex) : It holds the column index required to get the current cell information. **Note:** When virtualization is enabled, this option is applicable.

```cshtml
@using Syncfusion.Blazor.PivotView
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton OnClick="OnPdfExport" Content="Pdf Export"></SfButton>
<SfPivotView TValue="ProductDetails" @ref="@pivot" EnableVirtualization="true" AllowPdfExport="true" >
    <PivotViewDataSourceSettings DataSource="@Data" EnableSorting=true>
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
            <PivotViewFormatSetting Name="Amount" Format="C0" UseGrouping=true></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
     <PivotViewEvents TValue="ProductDetails" PdfQueryCellInfo="PdfQueryCellEvent"></PivotViewEvents>
</SfPivotView>

@code{
    private SfPivotView<ProductDetails> pivot;
    public List<ProductDetails> Data { get; set; }

    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
        // Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }
    
    public void OnPdfExport(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        this.pivot.ExportToPdfAsync();
    }

    // Triggers every time for row header and value cells during exporting.
    public void PdfQueryCellEvent(PdfQueryCellInfoEventArgs<ProductDetails> args)
    {
        Matrix<Matrix<AxisSet>> pivotValues = Pivot?.PivotValues;
        AxisSet cellInfo = null;
        if (Pivot?.EnableVirtualization == true)
        {
            if (pivotValues != null)
            {
                cellInfo = pivotValues[args.RowIndex]?[args.ColumnIndex];
            }
        }
        else
        {
            IDictionary<string, object> cellCoordinates = args.Column?.CustomAttributes;
            if (pivotValues != null && cellCoordinates != null && cellCoordinates.ContainsKey("aria-colindex") && cellCoordinates.ContainsKey("aria-rowindex"))
            {
                // You will get the row index required to find the current cell information from the pivot value collection here.
                int rowIndex = int.Parse(cellCoordinates["aria-rowindex"].ToString(), System.Globalization.NumberStyles.None);
                // You will get the column index required to find the current cell information from the pivot value collection here.
                int colIndex = int.Parse(cellCoordinates["aria-colindex"].ToString(), System.Globalization.NumberStyles.None);
                cellInfo = pivotValues[rowIndex]?[colIndex];
            }
        }
        if (cellInfo?.IsGrandSum == true || cellInfo?.Axis == "row")
        {
            args.Style.BackgroundBrush = new Syncfusion.PdfExport.PdfSolidBrush(cellInfo?.Axis == "row" ? new Syncfusion.PdfExport.PdfColor(System.Drawing.Color.LightGoldenrodYellow) : new Syncfusion.PdfExport.PdfColor(System.Drawing.Color.LightYellow));
            args.Style.TextPen = new Syncfusion.PdfExport.PdfPen(System.Drawing.Color.IndianRed);
        }
    }
}
```

### PdfHeaderQueryCellInfo

N> The row header cell can be obtained by using the `PdfQueryCellInfo` event. It can be identified using `AxisSet.Axis == "row"` and for reference, see the code snippet in the previous topic.

The event [PdfHeaderQueryCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_PdfHeaderQueryCellInfo) triggers on framing each column header cell during PDF export. It allows the user to customize the cell value, style, etc. of the current cell. It has the following parameters:

* [Column](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfHeaderQueryCellInfoEventArgs.html#Syncfusion_Blazor_Grids_PdfHeaderQueryCellInfoEventArgs_Column) : It holds the column information, including row and column indexes required to obtain the current cell information. **Note:** This option is applicable only when virtualization is disabled.
* [Cell](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfHeaderQueryCellInfoEventArgs.html#Syncfusion_Blazor_Grids_PdfHeaderQueryCellInfoEventArgs_Cell) : It holds the current cell information.
* [Style](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfHeaderQueryCellInfoEventArgs.html#Syncfusion_Blazor_Grids_PdfHeaderQueryCellInfoEventArgs_Style) : It holds the style properties for the cell.
* [RowIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfHeaderQueryCellInfoEventArgs.html#Syncfusion_Blazor_Grids_PdfHeaderQueryCellInfoEventArgs_RowIndex) : It holds the row index required to get the current cell information. **Note:** When virtualization is enabled, this option is applicable.
* [ColumnIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfHeaderQueryCellInfoEventArgs.html#Syncfusion_Blazor_Grids_PdfHeaderQueryCellInfoEventArgs_ColumnIndex) : It holds the column index required to get the current cell information. **Note:** When virtualization is enabled, this option is applicable.

```cshtml
@using Syncfusion.Blazor.PivotView
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton OnClick="OnPdfExport" Content="Pdf Export"></SfButton>
<SfPivotView TValue="ProductDetails" @ref="@pivot" EnableVirtualization="true" AllowPdfExport="true" >
    <PivotViewDataSourceSettings DataSource="@Data" EnableSorting=true>
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
            <PivotViewFormatSetting Name="Amount" Format="C0" UseGrouping=true></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
     <PivotViewEvents TValue="ProductDetails" PdfHeaderQueryCellInfo="PdfHeaderEvent"></PivotViewEvents>
</SfPivotView>

@code{
    private SfPivotView<ProductDetails> pivot;
    public List<ProductDetails> Data { get; set; }

    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
        // Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }

    public void OnPdfExport(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
    {
        this.pivot.ExportToPdfAsync();
    }

    // Triggers every time for column header cell during exporting.
    public void PdfHeaderEvent(PdfHeaderQueryCellInfoEventArgs args)
    {
        Matrix<Matrix<AxisSet>> pivotValues = Pivot?.PivotValues;
        AxisSet cellInfo = null;

        if (Pivot?.EnableVirtualization == true)
        {
            if (pivotValues != null)
            {
                cellInfo = pivotValues[args.RowIndex]?[args.ColumnIndex];
            }
        }
        else
        {
            IDictionary<string, object> cellCoordinates = args.Column?.CustomAttributes;
            if (pivotValues != null && cellCoordinates != null && cellCoordinates.ContainsKey("aria-colindex") && cellCoordinates.ContainsKey("index"))
            {
                // You will get the row index required to find the current cell information from the pivot value collection here.
                int rowIndex = int.Parse(cellCoordinates["index"].ToString(), System.Globalization.NumberStyles.None);
                // You will get the column index required to find the current cell information from the pivot value collection here.
                int colIndex = int.Parse(cellCoordinates["aria-colindex"].ToString(), System.Globalization.NumberStyles.None);
                cellInfo = pivotValues[rowIndex]?[colIndex];
            }
        }
        if (cellInfo != null)
        {
            args.Style.BackgroundBrush = new Syncfusion.PdfExport.PdfSolidBrush(new Syncfusion.PdfExport.PdfColor(System.Drawing.Color.LightGoldenrodYellow));
            args.Style.TextPen = new Syncfusion.PdfExport.PdfPen(System.Drawing.Color.IndianRed);
        }
    }
}
```

![Customizing the Blazor Pivot Table cell values and styles while exporting](images/blazor-pivottable-pdfexportevents.png)

N> You can refer to the [Blazor Pivot Table](https://www.syncfusion.com/blazor-components/blazor-pivot-table) feature tour page for its groundbreaking feature representations. You can also explore the [Blazor Pivot Table example](https://blazor.syncfusion.com/demos/pivot-table/default-functionalities?theme=bootstrap5) to know how to render and configure the pivot table.