---
layout: post
title:  Data Compression in Blazor Pivot Table component | Syncfusion
description: Checkout and Learn here all about data compression in Syncfusion Blazor Pivot Table component and more.
platform: Blazor
control: Pivot Table
documentation: ug
---

# Data Compression in Blazor Pivot Table component

> This property is applicable only for relational data source.

When binding large volumes of raw data, the pivot table processes all raw data to generate aggregated data during initial rendering and report manipulation. However, with data compression enabled, the input raw data is compressed based on the uniqueness of the raw data, and the final compressed raw data is utilized by the pivot table. The compressed raw data is then used for all subsequent operations, reducing the looping complexity and improving the performance of the pivot table. For example, if the pivot table connects to one million raw data records that compress to 1,000 unique raw data records, it will render significantly faster—potentially within 3 seconds rather than 10 seconds, depending on the data complexity and system specifications. Enable this option by using the [AllowDataCompression](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_AllowDataCompression) property along with [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_EnableVirtualization) property.

> N> This option will only function when the virtual scrolling is enabled.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails" Width="800" Height="300" EnableVirtualization="true" AllowDataCompression="true">
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

**Limitations during data compression:**

- The following aggregation types are not supported:
  - Average
  - PopulationStDev
  - SampleStDev
  - PopulationVar
  - SampleVar
- If any of the above aggregation types are used, they will be automatically converted to **"Sum"** aggregation.
- **"DistinctCount"** will function as **"Count"** aggregation type.
- In a calculated field, existing fields can be inserted without changing their default aggregation type. Even if the aggregation type is changed, it will revert to the default aggregation type for calculation purposes.

> You can refer to the [Blazor Pivot Table](https://www.syncfusion.com/blazor-components/blazor-pivot-table) feature tour page for its groundbreaking feature representations. You can also explore the [Blazor Pivot Table example](https://blazor.syncfusion.com/demos/pivot-table/default-functionalities?theme=bootstrap5) to know how to render and configure the pivot table.