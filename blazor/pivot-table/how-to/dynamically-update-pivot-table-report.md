---
layout: post
title: Dynamically update report configuration in Blazor Pivot Table | Syncfusion
description: Checkout and learn here all about handling OLAP service events in the Syncfusion Blazor Pivot Table component 
platform: Blazor
control: Pivot Table
documentation: ug
---

# Dynamically update report configuration in Blazor Pivot Table Component



```cshtml
@using Syncfusion.Blazor.PivotView
@using Syncfusion.Blazor.Buttons
 
<SfButton OnClick="updatePivotReport" Content="Update pivot report"></SfButton>
 
<SfPivotView TValue="ProductDetails" @ref="@pivot" Width="1200" Height="400" ShowGroupingBar="@groupingbar" ShowFieldList="true" >
    <PivotViewDataSourceSettings DataSource="@data" ExpandAll="true">
        <PivotViewColumns>
            <PivotViewColumn Name="Year"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="Country"></PivotViewRow>
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
    private SfPivotView<ProductDetails> pivot = null!;
    public List<ProductDetails> data { get; set; } = null!;
    public bool isReportListReset = false;
    public bool isClick = true;

    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
    }

    public async Task updatePivotReport(Microsoft.AspNetCore.Components.Web.MouseEventArgs args) {
        pivot.DataSourceSettings.Columns.Add(new PivotViewRow
        {
            Name = "Quarter",
            Caption = "Quart name"
        });
        pivot.DataSourceSettings.Rows.Add(new PivotViewColumn
        {
            Name = "Products",
            Caption = "Products"
        });
        await pivot.RefreshAsync(true);
    }
}
```
