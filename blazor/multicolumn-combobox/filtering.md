---
layout: post
title: Filtering in Blazor MultiColumn ComboBox Component | Syncfusion
description: Checkout and learn here all about Filtering in the Syncfusion Blazor MultiColumn ComboBox component and much more.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Filtering in Blazor MultiColumn ComboBox Component

The MultiColumn ComboBox offers built-in functionality for filtering data items when the [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_AllowFiltering) option is enabled. The filtering action starts as soon as you begin typing in the search box. By default, the AllowFiltering property is set to `false`.

## Local data

The following code demonstrates the filtering functionality with local data in the MultiColumn ComboBox component.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/local-data.razor %}

{% endhighlight %}

![Blazor MultiColumn ComboBox with local data filtering](./images/filtering/blazor_combobox_local-data.png)

## Remote data

For remote data, every key press and filter action request is processed on the server side.

The following code illustrates the filtering capabilities using the [ODataAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#odata-adaptor) in the MultiColumn ComboBox component, utilizing the [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.Query.html) property.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/remote-data.razor %}

{% endhighlight %}

## Filter type

You can use [FilterType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_FilterType) property to specify on which filter type needed to be considered on the search action of the component. The available `FilterType` and its supported data types are:

FilterType     | Description
------------ | -------------
  [StartsWith](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.FilterType.html#Syncfusion_Blazor_MultiColumnComboBox_FilterType_StartsWith)       | Checks whether a value begins with the specified value.
  [EndsWith](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.FilterType.html#Syncfusion_Blazor_MultiColumnComboBox_FilterType_EndsWith)     | Checks whether a value ends with specified value.
  [Contains](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.FilterType.html#Syncfusion_Blazor_MultiColumnComboBox_FilterType_Contains)      | Checks whether a value contained with specified value.

In the following example, `EndsWith` filter type has been mapped to the `FilterType` property.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/filter-type.razor %}

{% endhighlight %}

![Blazor MultiColumn ComboBox with Filter Type](./images/filtering/blazor_combobox_filter-type.png)

<!-- ## Minimum filter length

When filtering list items, you can specify a character count limit to trigger a remote request and retrieve filtered data for the DropDownList. This can be achieved through manual validation using the [Filtering event arguments](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.FilteringEventArgs.html) within the [Filtering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_Filtering) event handler.

In the following example, the remote request does not fetch the search data until the search key contains three characters.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/minimum-filter-length.razor %}

{% endhighlight %} -->

<!-- ## Multi column filtering

To enable multi-column support in the built-in Syncfusion Blazor theme files, simply add the `e-multi-column` class to the [CssClass]() property.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/multi-column.razor %}

{% endhighlight %}


You can achieve multiple column(field) filtering by passing the List of [predicates](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WhereFilter.html#Syncfusion_Blazor_Data_WhereFilter_predicates) to the [And](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WhereFilter.html#Syncfusion_Blazor_Data_WhereFilter_And_Syncfusion_Blazor_Data_WhereFilter_) or [Or](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WhereFilter.html#Syncfusion_Blazor_Data_WhereFilter_Or_Syncfusion_Blazor_Data_WhereFilter_) methods of [WhereFilters](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WhereFilter.html#Syncfusion_Blazor_Data_WhereFilter__ctor).

{% highlight cshtml %}

{% include_relative code-snippet/filtering/multi-column-filtering.razor %}

{% endhighlight %}

<!-- ## Case sensitive filtering

The Data items can be filtered with or without case sensitivity using the [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html). This can be done by passing the fourth optional parameter [IgnoreCase](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WhereFilter.html#Syncfusion_Blazor_Data_WhereFilter_IgnoreCase) of the [Where clause](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.Query.html#Syncfusion_Blazor_Data_Query_Where_Syncfusion_Blazor_Data_WhereFilter_).

The following example shows how to perform case-sensitive filter.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/case-sentitive.razor %}

{% endhighlight %} -->

<!-- ## Custom filtering

The filter queries for the MultiColumn ComboBox component can be tailored using the [Filtering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_Filtering) event, allowing you to filter text across multiple columns in the data source.

In the following example, you can filter the data based on either the `FirstName` or `LastName` fields. The Filtering event utilizes a [Predicate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WhereFilter.html#Syncfusion_Blazor_Data_WhereFilter_Condition) with an `or` condition to accommodate filtering on both fields.

For example, if a data source item has `FirstName` as `Nancy` and `LastName` as `Davalio`, you can type either the character `N` or `D` to filter the data. This will display `Nancy` (from the FirstName field) in the popup.


{% highlight cshtml %}

{% include_relative code-snippet/filtering/custom-filtering.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXLKsLVmKwTcWkyh?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} -->

## Prevent popup opening when filtering

To prevent the MultiColumn ComboBox dropdown from opening when filtering is applied, you can use the [PopupOpeningEventArgs.Cancel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.PopupOpeningEventArgs.html#Syncfusion_Blazor_MultiColumnComboBox_PopupOpeningEventArgs_Cancel) argument in the [PopupOpeningEventArgs](hhttps://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.PopupOpeningEventArgs.html#properties). The `PopupOpeningEventArgs.Cancel` argument is a boolean value that can be set to true to cancel the dropdown opening, or false to allow the dropdown to open.

In the following example, the isTyped flag is used to track whether the filtering action is taking place. The `OnFiltering` method sets the flag to true when the filtering action starts, and the `OnBeforeOpen` method cancels the dropdown opening if the flag is set to true. Finally, the `OnBeforeOpen` method resets the flag to false to prepare for the next filtering action.

> This will prevent the MultiColumn ComboBox dropdown from opening when filtering is applied, while still allowing the user to filter the items using the input field in the MultiColumn ComboBox.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/prevent-popupopen-in-filtering.razor %}

{% endhighlight %}