---
layout: post
title: Data Binding in Blazor Pager Component | Syncfusion
description: Learn how the Syncfusion Blazor Pager component segments local or remote data collections into paged views.
platform: Blazor
control: Pager
documentation: ug
---

# Data Binding in Blazor Pager Component

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pager component divides **local** or **remote** data collections into paged views. It provides navigation controls to manage large datasets efficiently.

**When to Use:**

- Use **Local Data** for **small**, **static** collections that can be loaded in memory.
- Use **Remote Data** for **large** or **dynamic** datasets that require server-side operations.

## Local Data Binding

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pager component can segment an in-memory data collection into multiple pages. The [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_PageSize) property defines the number of items displayed per page. The [ItemClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_ItemClick) event updates the displayed subset when navigating between pages.

```csharp
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Lists

<div class="listview-container">
    @{
    var listData = ListData.Skip(SkipValue).Take(TakeValue).ToList();
    <SfListView CssClass="listview" TValue="DataModel" DataSource="listData" HeaderTitle="Products" ShowHeader="true">
       <ListViewFieldSettings TValue="DataModel" Id="ProductID" Text="ProductName"></ListViewFieldSettings>     
    </SfListView>
    }
     <div class="pager-container">
        <SfPager @ref="@Page" PageSize=5  NumericItemsCount=5 TotalItemsCount=25 ItemClick="Click">
        </SfPager>
    </div>
</div>
@code {
    SfPager Page;
    public SfListView<DataModel> List { get; set; }
    public int pageSize { get; set; } 
    public int SkipValue ;
    public int TakeValue = 5;
    List<DataModel> ListData = new List<DataModel>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        ListData.Add(new DataModel { ProductID = 1,  ProductName = "Chai" });
        ListData.Add(new DataModel { ProductID = 2, ProductName = "Chang" });
        ListData.Add(new DataModel { ProductID = 3, ProductName = "Aniseed Syrup" });
        ListData.Add(new DataModel { ProductID = 4,  ProductName = "Chef Anton's Cajun Seasoning" });
        ListData.Add(new DataModel { ProductID = 5, ProductName = "Chef Anton's Gumbo Mix" });
        ListData.Add(new DataModel { ProductID = 6,ProductName = "Grandma's Boysenberry Spread" });
        ListData.Add(new DataModel { ProductID = 7, ProductName = "Uncle Bob's Organic Dried Pears" });
        ListData.Add(new DataModel { ProductID = 8, ProductName = "Northwoods Cranberry Sauce" });
        ListData.Add(new DataModel { ProductID = 9, ProductName = "Mishi Kobe Niku" });
        ListData.Add(new DataModel { ProductID = 10,ProductName = "Ikura" });
        ListData.Add(new DataModel { ProductID =11, ProductName = "Queso Cabrales" });
        ListData.Add(new DataModel { ProductID = 12, ProductName = "Queso Manchego La Pastora" });
        ListData.Add(new DataModel { ProductID = 13, ProductName = "Konbu" });
        ListData.Add(new DataModel { ProductID = 14, ProductName = "Tofu" });
        ListData.Add(new DataModel { ProductID = 15 ,ProductName = "Genen Shouyu" });
        ListData.Add(new DataModel { ProductID = 16, ProductName = "Pavlova" });
        ListData.Add(new DataModel { ProductID = 17, ProductName = "Alice Mutton" });
        ListData.Add(new DataModel { ProductID = 18, ProductName = "Carnarvon Tigers" });
        ListData.Add(new DataModel { ProductID = 19, ProductName = "Teatime Chocolate Biscuits" });
        ListData.Add(new DataModel { ProductID = 20, ProductName = "Sir Rodney's Marmalade" });
        ListData.Add(new DataModel { ProductID = 21, ProductName = "Sir Rodney's Scones" });
        ListData.Add(new DataModel { ProductID = 22, ProductName = "Gustaf's Knäckebröd" });
        ListData.Add(new DataModel { ProductID = 23, ProductName = "Tunnbröd" });
        ListData.Add(new DataModel { ProductID = 24, ProductName = "Guaraná Fantástica" });
        ListData.Add(new DataModel { ProductID = 25, ProductName = "NuNuCa Nuß-Nougat-Creme" });
    }
    public void Click(PagerItemClickEventArgs args)
    {
        SkipValue = (args.CurrentPage * Page.PageSize) - Page.PageSize;
        TakeValue = Page.PageSize;
    }
    public class DataModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
    }
}

 <style>
    .listview-container {
        margin: 0 auto 2em;
        max-width: 460px;
    }
    .pager-container {
        margin: 0 auto 2em;
        max-width: 460px;
    }
</style>
```

## Remote Data Binding

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pager component supports paging for data retrieved from remote services. The [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component manages remote operations such as **querying**, **filtering**, and **paging**. The [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_PageSize) property specifies the number of items displayed per page. The [ItemClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_ItemClick) event updates query parameters to fetch the correct subset of data.

```csharp
@using Syncfusion.Blazor.Lists
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Navigations

<div class="listview-container">
    @{
    Query query = new Query().From("Products").Select(new List<string>() { "ProductID","ProductName"}).Take(TakeValue).Skip(SkipValue);
    <SfListView CssClass="listview" TValue="DataModel" HeaderTitle="Products" ShowHeader="true" Query="@query">
        <ListViewFieldSettings TValue="DataModel" Id="ProductID" Text="ProductName"></ListViewFieldSettings>
        <SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svc/" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
    </SfListView>
    }
     <div class="pager-container">
        <SfPager @ref="@Page" PageSize=5  NumericItemsCount=5 TotalItemsCount=25 ItemClick="Click">
        </SfPager>
    </div>
</div>

@code{
    SfPager Page;
    public int SkipValue ;
    public int TakeValue = 5;
    public class DataModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
    }
    public void Click(PagerItemClickEventArgs args)
    {
        SkipValue = (args.CurrentPage * Page.PageSize) - Page.PageSize;
        TakeValue = Page.PageSize;
    }
}
<style>
    .listview-container {
         margin: 0 auto 2em;
        max-width: 460px;
    }
    .pager-container {
        margin: 0 auto 2em;
        max-width: 460px;
    }
</style>

```