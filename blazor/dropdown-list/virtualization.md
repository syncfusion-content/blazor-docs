---
layout: post
title: Virtualization in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Virtualization in Syncfusion Blazor DropDown List component and much more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Virtualization in Blazor DropDown List Component

The DropDownList has been provided virtualization to improve the UI performance for a large amount of data when [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_EnableVirtualization) is true. This feature doesn’t render out the entire data source on initial component rendering. It loads the N number of items in the popup on initial rendering and the remaining set number of items will load on each scrolling action in the popup. It can work with both local and remote data.

## Virtualization in Local Data

In the following code, 150 items are bound to the component, but only 6 items will load to the popup when you open the popup. Remaining set number of items will load on each scrolling action in the popup.

```cshtml

@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Data 

<SfDropDownList TValue="string" TItem="Record" Placeholder="Select an item" DataSource="@Records" Query="@LocalDataQuery" PopupHeight="130px" EnableVirtualization="true">
    <DropDownListFieldSettings Text="Text" Value="ID"></DropDownListFieldSettings>
</SfDropDownList>

@code{
    public Query LocalDataQuery = new Query().Take(6); 
    public class Record 
    { 
        public string ID { get; set; } 
        public string Text { get; set; } 
    } 
    public List<Record> Records { get; set; } 
    protected override void OnInitialized()
    { 
        this.Records = Enumerable.Range(1, 150).Select(i => new Record() 
        { 
            ID = i.ToString(), 
            Text = "Item " + i, 
        }).ToList(); 
    } 
}
```



![Blazor DropDownList with virtualization](./images/blazor_dropdownlist_virtualization.gif)

## Virtualization in Remote Data

Virtualization loads the data on demand while scrolling the popup suggestions. The [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_EnableVirtualization) attribute should be set to true to make this functionality available. Configure Take() in the Query property to load the initial set of data.

```cshtml
@using Syncfusion.Blazor.DropDowns;
@using Syncfusion.Blazor.Data;

<SfDropDownList TValue="string" TItem="OrderDetails" Placeholder="Select a name" Query="@RemoteDataQuery" EnableVirtualization="true"> 
    <SfDataManager Url="https://js.syncfusion.com/demos/ejServices/Wcf/Northwind.svc/Orders" CrossDomain="true" Adaptor="Syncfusion.Blazor.Adaptors.ODataAdaptor"></SfDataManager> 
    <DropDownListFieldSettings Text="CustomerID" Value="CustomerID"></DropDownListFieldSettings> 
</SfDropDownList> 
 
@code { 
 
    public Query RemoteDataQuery = new Query().Select(new List<string> { "CustomerID" }).Take(12).RequiresCount(); 
    public class OrderDetails 
    { 
        public int? OrderID { get; set; } 
        public string CustomerID { get; set; } 
        public int? EmployeeID { get; set; } 
        public double? Freight { get; set; } 
        public string ShipCity { get; set; } 
        public bool Verified { get; set; } 
        public DateTime? OrderDate { get; set; } 
        public string ShipName { get; set; } 
        public string ShipCountry { get; set; } 
        public DateTime? ShippedDate { get; set; } 
        public string ShipAddress { get; set; } 
    } 
} 

```


![virtualization with remote data](./images/blazor_dropdown_virtualization-with-remote-data.gif)