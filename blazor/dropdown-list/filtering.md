---
layout: post
title: Filtering in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Filtering in Syncfusion Blazor DropDown List component and much more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Filtering in Dropdown List

The DropDownList has built-in support to filter data items when [`AllowFiltering`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_AllowFiltering) is enabled. The filter operation starts as soon as you start typing characters in the search box.

## Local data

In the below code, demonstrated the filtering functionality with local data in the DropDownList component.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/local-data.razor %}

{% endhighlight %}

![Blazor DropdownList with local data filtering](./images/filtering/blazor_dropdown_local-data.png)

## Remote data

In the below code, demonstrated the filtering functionality with ODataAdaptor in the DropDownList component with help of [`Query`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.Query.html) property.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/remote-data.razor %}

{% endhighlight %}

![Blazor DropdownList with Remote Data filtering](./images/filtering/blazor_dropdown_remote-data.png)

## Filter type

You can use [`FilterType`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_FilterType) property to determine on which filter type, the component needs to be considered on search action and its supported data types are,

FilterType     | Description
------------ | -------------
  StartsWith       | Checks whether a value begins with the specified value.
  EndsWith     | Checks whether a value ends with specified value.
  Contains      | Checks whether a value contains with specified value.

In the following example, `EndsWith` filter type has been mapped to the `FilterType` property.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/filter-type.razor %}

{% endhighlight %}

![Blazor DropdownList with Filter Type](./images/filtering/blazor_dropdown_filter-type.png)

## Case sensitive filtering

The Data items can be filtered either with or without case sensitivity using the [`DataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html). This can be done by passing the fourth optional parameter [`IgnoreCase`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WhereFilter.html#Syncfusion_Blazor_Data_WhereFilter_IgnoreCase) of the [`Where clause`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.Query.html#Syncfusion_Blazor_Data_Query_Where_Syncfusion_Blazor_Data_WhereFilter_).

The following example shows how to perform case-sensitive filter.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/case-sentitive.razor %}

{% endhighlight %}

## Filter textbox placeholder 

You can use [`FilterBarPlaceholder`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_FilterBarPlaceholder) to accept the value to be displayed as a watermark text on the filter bar.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/filter-textbox-placeholder.razor %}

{% endhighlight %}

![Blazor DropdownList with Filter Textbox Placeholder](./images/filtering/blazor_dropdown_filter-textbox-placeholder.png)

## Custom filtering

DropDownList component filter queries can be customized. You can also use your own filter libraries to filter data like Fuzzy search.

In the below sample demonstration, filter the data either using its `FirstName` or `LastName` field. Hence in the Filtering event, [`Predicate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WhereFilter.html#Syncfusion_Blazor_Data_WhereFilter_Condition) is used with `or` condition for filtering both the fields. 

For instance , the data source item consist of `FirstName` as `Nancy` and `LastName` as `Davalio`. But you can filter the data either by typing `N` or `D` character and it will showcase the `Nancy` (FirstName field) in the popup.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/case-sentitive.razor %}

{% endhighlight %}

![Blazor DropdownList with custom filtering](./images/filtering/blazor_dropdown_custom-filtering.png)

## Multi column filtering 

Provided a multi column style class in the built-in Syncfusion Blazor theme files. So, need to provide the multicolumn root class API name as `e-multi-column` in the CssClass property.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/multi-column.razor %}

{% endhighlight %}

![Blazor DropdownList with Multi Column filtering](./images/filtering/blazor_dropdown_multi-column.png)

## Minimum filter length

When filtering the list items, you can set the limit for character count to raise remote request and fetch filtered data on the DropDownList. This can be done by manual validation by using the [`Filtering event arguments`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FilteringEventArgs.html#Syncfusion_Blazor_DropDowns_FilteringEventArgs_Text) within the [`Filtering`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_Filtering) event handler.

In the following example, the remote request does not fetch the search data until the search key contains three characters.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/minimum-filter-length.razor %}

{% endhighlight %}

![Blazor DropdownList with Multi Column filtering](./images/filtering/blazor_dropdown_minimum-filter-length.png)