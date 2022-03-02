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

> The pivot table component can be exported to PDF format using options available in the toolbar. For more details [refer](./tool-bar) here.

```cshtml
@using Syncfusion.Blazor.PivotView
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="OnPdfExport" Content="Pdf Export"></SfButton>
<SfPivotView TValue="ProductDetails" @ref="@pivot" AllowPdfExport="true" >
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
    public List<ProductDetails> data { get; set; }
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

> By default, material theme will be applied to the pivot table during PDF exporting.

```cshtml
@using Syncfusion.Blazor.PivotView
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="OnPdfExport" Content="Pdf Export"></SfButton>
<SfPivotView TValue="ProductDetails" @ref="@pivot" AllowPdfExport="true" >
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
    public List<ProductDetails> data { get; set; }
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
       //Bind your dataSource collection here, kindly refer the getting started section. for more information.
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

**Supported page sizes are:** Letter, Note, Legal, A0, A1, A2, A3, A5, A6, A7, A8, A9, B0, B1, B2, B3, B4, B5, Archa, Archb, Archc, Archd,
Arche, Flsa, HalfLetter, Letter11x17, Ledger.

```cshtml
@using Syncfusion.Blazor.PivotView
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="OnPdfExport" Content="Pdf Export"></SfButton>
<SfPivotView TValue="ProductDetails" @ref="@pivot" AllowPdfExport="true" >
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
    public List<ProductDetails> data { get; set; }
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
    public List<ProductDetails> data { get; set; }
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

> You can refer to the [Blazor Pivot Table](https://www.syncfusion.com/blazor-components/blazor-pivot-table) feature tour page for its groundbreaking feature representations. You can also explore the [Blazor Pivot Table example](https://blazor.syncfusion.com/demos/pivot-table/default-functionalities?theme=bootstrap4) to know how to render and configure the pivot table.