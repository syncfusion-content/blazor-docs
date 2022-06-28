---
layout: post
title: Data Binding in Blazor Pager Component | Syncfusion
description: Checkout and learn here all about working Syncfusion Blazor Pager component with both local or remote data collection and how it splits into sectioned pages.
platform: Blazor
control: Pager
documentation: ug
---

# Data Binding in Blazor Pager Component

## Local Data

The ListView component provides an option to get the list view items from the local data. It can be done through a list of business objects or a collection of values. 

Using the Click event of the Pager, how many number of items displayed per page in the ListView component is demonstrated in the following sample.

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
        <SfPager @ref="@Page" PageSize=5  NumericItemsCount=5 TotalItemsCount=25 Click="Click">
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
    public void Click(PageClickEventArgs args)
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

## Remote Data

The ListView supports to retrieve the data from remote data services with the help of `DataManager` component. The `Query` property allows to fetch data and return it to the ListView from the database.

Using the Click event of the Pager, how many number of items displayed per page in the ListView component is demonstrated in the following sample.

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
        <SfPager @ref="@Page" PageSize=5  NumericItemsCount=5 TotalItemsCount=25 Click="Click">
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
    public void Click(PageClickEventArgs args)
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