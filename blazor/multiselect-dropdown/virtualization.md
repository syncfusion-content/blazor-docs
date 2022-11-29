---
layout: post
title: Virtualization in Blazor MultiSelect Dropdown Component | Syncfusion
description: Checkout and learn here all about virtualization in Syncfusion Blazor MultiSelect Dropdown component and much more.
platform: Blazor
control: MultiSelect Dropdown
documentation: ug
---

# Virtualization in Blazor MultiSelect Dropdown Component

The MultiSelect has been provided virtualization to improve the UI performance for a large amount of data when [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_EnableVirtualization) is true. This feature doesn’t render out the entire data source on initial component rendering. It loads the N number of items in the popup on initial rendering and the remaining set number of items will load on each scrolling action in the popup. It can work with both local and remote data.

In the following code 150 items bound to the component, but only 6 items will load to the popup when you open the popup. Remaining set number of items will load on each scrolling action in the popup.

```cshtml

@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Data 

<SfMultiSelect TValue="string[]" TItem="Record" Placeholder="Select an item" DataSource="@Records" Query="@LocalDataQuery" PopupHeight="130px" EnableVirtualization="true">
    <MultiSelectFieldSettings Text="Text" Value="ID"></MultiSelectFieldSettings>
</SfMultiSelect>

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

![Blazor MultiSelect with virtualization](./images/blazor-multiselect-dropdown-virtualization.gif)

## Properties

### EnableVirtualization

The Virtual Scrolling feature is used to display a large amount of data that you require without buffering the entire load of a huge database records in the DropDowns, that is, when scrolling, the datamanager request is sent to fetch some amount of data from the server dynamically. To achieve this scenario with DropDowns, set the [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_EnableVirtualization) to `true`.

[Click to refer the code for EnableVirtualization](https://blazor.syncfusion.com/documentation/multiselect-dropdown/virtualization)

### ItemsCount

The data can be fetched in popup based on [ItemsCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_ItemsCount), when enabled the [EnableVirtualization](https://blazor.syncfusion.com/documentation/multiselect-dropdown/virtualization). `ItemsCount` is applicable only when `EnableVirtualization` is used as true. `ItemsCount` is depends on `EnableVirtualization`.

Default value of `ItemsCount` is `5`.

{% highlight Razor %}

{% include_relative code-snippet/virtualization/itemsCount-property.razor %}

{% endhighlight %}