---
layout: post
title: Dynamically update report configuration in Blazor Pivot Table | Syncfusion
description: Learn how to dynamically update report configuration and refresh the Blazor Pivot Table component using the RefreshAsync method.
platform: Blazor
control: Pivot Table
documentation: ug
---

# Dynamically update report configuration in Blazor Pivot Table Component

The Blazor Pivot Table component supports dynamic data source handling and report manipulation through the [`RefreshAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_RefreshAsync_System_Boolean_) method. This method provides a streamlined and efficient approach to either refresh the component's layout or refresh the entire component, which re-initiates the engine process based on new data or report settings.

The [`RefreshAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_RefreshAsync_System_Boolean_) method enables dynamic and asynchronous refreshing of the Pivot Table layout. It simplifies the update process and enhances responsiveness during runtime changes to report configurations.

## RefreshAsync method parameters

This method accepts a boolean parameter, **allowDataRefresh**, which determines whether the underlying data source should be reprocessed:

*   **`false`**: Refreshes only the component's layout based on the current report settings without reprocessing the entire data source.
*   **`true`**: Performs a complete data refresh, which includes reprocessing the data source and recalculating all aggregations.

> By default, the parameter is `false`, which refreshes only the component's layout without reprocessing the underlying data.

In the following example, `true` is passed to the [`RefreshAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_RefreshAsync_System_Boolean_) method to trigger a full data refresh, updating the Pivot Table with a new row and column added to the report at runtime.

```cshtml
@using Syncfusion.Blazor.PivotView
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="UpdatePivotReport" Content="Update Pivot Report"></SfButton>

<SfPivotView TValue="ProductDetails" @ref="@pivot" Width="1200" Height="400" ShowGroupingBar="true" ShowFieldList="true">
    <PivotViewDataSourceSettings DataSource="@data" ExpandAll="true">
        <PivotViewColumns>
            <PivotViewColumn Name="Year"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="Country"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Sold" Caption="Units Sold"></PivotViewValue>
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Amount" Format="C"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
</SfPivotView>

@code {
    private SfPivotView<ProductDetails> pivot = null!;
    public List<ProductDetails> data { get; set; } = null!;

    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData();
    }

    public async Task UpdatePivotReport()
    {
        // Adding a new row to the report
        pivot.DataSourceSettings.Rows.Add(new PivotViewRow
        {
            Name = "Products"
        });
        // Adding a new column to the report
        pivot.DataSourceSettings.Columns.Add(new PivotViewColumn
        {
            Name = "Quarter",
            Caption = "Quarter Name"
        });
        // Refresh the Pivot Table to reflect the changes
        await pivot.RefreshAsync(true);
    }

    public class ProductDetails
    {
        public int Sold { get; set; }
        public double Amount { get; set; }
        public string? Country { get; set; }
        public string? Products { get; set; }
        public string? Year { get; set; }
        public string? Quarter { get; set; }

        public static List<ProductDetails> GetProductData()
        {
            List<ProductDetails> productDetails = new List<ProductDetails>()
            {
                new ProductDetails { Country = "Canada", Products = "Bike", Year = "FY 2022", Quarter = "Q1", Sold = 35, Amount = 52500 },
                new ProductDetails { Country = "Canada", Products = "Car", Year = "FY 2022", Quarter = "Q2", Sold = 25, Amount = 62500 },
                new ProductDetails { Country = "Germany", Products = "Bike", Year = "FY 2023", Quarter = "Q3", Sold = 40, Amount = 60000 },
                new ProductDetails { Country = "Germany", Products = "Car", Year = "FY 2023", Quarter = "Q4", Sold = 30, Amount = 75000 },
                new ProductDetails { Country = "United States", Products = "Bike", Year = "FY 2022", Quarter = "Q1", Sold = 50, Amount = 75000 },
            };
            return productDetails;
        }
    }
}
```
