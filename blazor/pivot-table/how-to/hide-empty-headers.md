---
layout: post
title: Hide empty headers in Blazor Pivot Table Component | Syncfusion
description: Checkout and learn here all about how to hide empty headers in Syncfusion Blazor Pivot Table component and more.
platform: Blazor
control: Pivot Table
documentation: ug
---

# Hide empty headers in Blazor Pivot Table Component

When the raw data for a particular field is not defined, it will be shown as 'null' in the pivot table headers. You can hide those headers by setting the [ShowHeaderWhenEmpty](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_ShowHeaderWhenEmpty) property to **false** in the pivot table.

For example, when the raw data contains **"United Kingdom"** for the 'Country' field but the **"State"** field is null, the header displays as **"United Kingdom >> null"**. Here, you can hide those 'null' headers using the [ShowHeaderWhenEmpty](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_ShowHeaderWhenEmpty) property.

N> By default, this property is set to **true**.

```cshtml
@using Syncfusion.Blazor.PivotView

<SfPivotView TValue="ProductDetails">
    <PivotViewDataSourceSettings DataSource="@data" ShowHeaderWhenEmpty=false>
        <PivotViewColumns>
            <PivotViewColumn Name="Products"></PivotViewColumn>
            <PivotViewColumn Name="Year"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="Country"></PivotViewRow>
            <PivotViewRow Name="State"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Sold" Caption="Units Sold"></PivotViewValue>
            <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
        </PivotViewValues>
        <PivotViewFormatSettings>
            <PivotViewFormatSetting Name="Sold" Format="N"></PivotViewFormatSetting>
            <PivotViewFormatSetting Name="Amount" Format="C"></PivotViewFormatSetting>
        </PivotViewFormatSettings>
    </PivotViewDataSourceSettings>
</SfPivotView>

@code {
    public List<ProductDetails> data { get; set; }
    protected override void OnInitialized()
    {
        this.data = ProductDetails.GetProductData().ToList();
        //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
    }

    public class ProductDetails
    {
        public int Sold { get; set; }
        public double Amount { get; set; }
        public string Country { get; set; }
        public string Products { get; set; }
        public string Year { get; set; }
        public string Quarter { get; set; }
        public string State { get; set; }

        public static List<ProductDetails> GetProductData()
        {
            List<ProductDetails> productData = new List<ProductDetails>();
            productData.Add(new ProductDetails { Sold = 2, Amount = 100, Country = "Canada", Products = "Bike", Year = "FY 2005", State = "Alberta" });
            productData.Add(new ProductDetails { Sold = 3, Amount = 0, Country = "Canada", Products = "Van", Year = "FY 2006", State = "British Columbia" });
            productData.Add(new ProductDetails { Sold = 4, Amount = 300, Products = "Car", Year = "FY 2007", State = "Brunswick" });
            productData.Add(new ProductDetails { Sold = 3, Amount = 150, Country = "Canada", Products = "Bike", State = "Manitoba" });
            productData.Add(new ProductDetails { Sold = 4, Amount = 200, Country = "Canada", Year = "FY 2006", State = "Ontario" });
            productData.Add(new ProductDetails { Sold = 0, Amount = 100, Country = "Canada", Products = "Van", Year = "FY 2007", State = "Quebec" });
            productData.Add(new ProductDetails { Sold = 2, Amount = 200, Country = "France", Products = "Bike", Year = "FY 2005" });
            productData.Add(new ProductDetails { Sold = 4, Amount = 0, Country = "France", Products = "Van", Year = "FY 2006", State = "Essonne" });
            productData.Add(new ProductDetails { Sold = 3, Amount = 300, Products = "Car", Year = "FY 2007", State = "Garonne (Haute)" });
            productData.Add(new ProductDetails { Sold = 2, Amount = 150, Country = "France", Products = "Van", State = "Gers" });
            productData.Add(new ProductDetails { Sold = 3, Amount = 200, Country = "Germany", Year = "FY 2006", State = "Bayern" });
            productData.Add(new ProductDetails { Sold = 0, Amount = 250, Country = "Germany", Products = "Car", Year = "FY 2007", State = "Brandenburg" });
            productData.Add(new ProductDetails { Sold = 4, Amount = 150, Country = "Germany", Products = "Car", Year = "FY 2008" });
            productData.Add(new ProductDetails { Sold = 4, Amount = 0, Country = "Germany", Products = "Bike", Year = "FY 2008", State = "Hessen" });
            productData.Add(new ProductDetails { Sold = 3, Amount = 150, Products = "Van", Year = "FY 2007", State = "Nordrhein-Westfalen" });
            productData.Add(new ProductDetails { Sold = 2, Amount = 100, Country = "Germany", Products = "Bike", State = "Saarland" });
            productData.Add(new ProductDetails { Sold = 5, Amount = 150, Country = "United Kingdom", Year = "FY 2008" });
            productData.Add(new ProductDetails { Sold = 0, Amount = 250, Country = "United States", Products = "Car", Year = "FY 2007", State = "Alabama" });
            productData.Add(new ProductDetails { Sold = 4, Amount = 200, Country = "United States", Products = "Van", Year = "FY 2005" });
            productData.Add(new ProductDetails { Sold = 2, Amount = 0, Country = "United States", Products = "Bike", Year = "FY 2006", State = "Colorado" });
            productData.Add(new ProductDetails { Sold = 3, Amount = 150, Products = "Car", Year = "FY 2008", State = "New Mexico" });
            productData.Add(new ProductDetails { Sold = 4, Amount = 200, Country = "United States", Products = "Bike", State = "New York" });
            productData.Add(new ProductDetails { Sold = 3, Amount = 250, Country = "United States", Year = "FY 2008", State = "North Carolina" });
            productData.Add(new ProductDetails { Sold = 0, Amount = 300, Country = "United States", Products = "Van", Year = "FY 2007", State = "South Carolina" });
            return productData;
        }
    }
}
```

N> You can refer to [Blazor Pivot Table](https://www.syncfusion.com/blazor-components/blazor-pivot-table) feature tour page for its groundbreaking feature representations. You can also explore [Blazor Pivot Table example](https://blazor.syncfusion.com/demos/pivot-table/default-functionalities?theme=bootstrap5) to know how to render and configure the pivot table.