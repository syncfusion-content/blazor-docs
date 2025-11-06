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

When binding one million raw data, the pivot table processes all raw data to generate aggregated data during initial rendering and report manipulation. However, with data compression, the input raw data is compressed based on the uniqueness of the raw data, and the final compressed raw data are utilized by the pivot table. The compressed raw data is then used for further operations at all times, reducing the looping complexity and improving the performance of the pivot table. For example, if the pivot table is connected to one million raw data compressed to 1,000 unique raw data, it will render within 3 seconds rather than 10 seconds. You can enable this option by using the [AllowDataCompression](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_AllowDataCompression) property along with [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_EnableVirtualization) property.

> This options will only function when the virtual scrolling is enabled.

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

**Limitations during data compression**

- The following aggregation types will not be supported.
    - Average
    - Populationsdev
    - Samplestdev
    - Populationvar
    - Samplevar
- If you use any of the aggregations above, it will result in an aggregation type **Sum**.
- **Distinct count** will act as **Count** aggregation type.
- In the calculated field, an existing field can be inserted without altering its default aggregation type. Even if changed, it would revert to the default aggregation type for calculation.

> You can refer to the [Blazor Pivot Table](https://www.syncfusion.com/blazor-components/blazor-pivot-table) feature tour page for its groundbreaking feature representations. You can also explore the [Blazor Pivot Table example](https://blazor.syncfusion.com/demos/pivot-table/default-functionalities?theme=bootstrap5) to know how to render and configure the pivot table.