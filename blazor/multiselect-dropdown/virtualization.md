---
layout: post
title: Virtualization in Blazor MultiSelect Dropdown Component | Syncfusion
description: Checkout and learn here all about virtualization in Syncfusion Blazor MultiSelect Dropdown component and much more.
platform: Blazor
control: MultiSelect Dropdown
documentation: ug
---

# Virtualization in Blazor MultiSelect Dropdown Component

The MultiSelect component includes a virtual scrolling feature that improves UI performance when working with large datasets. By enabling the [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_EnableVirtualization) option, the MultiSelect renders only a subset of items initially. As the user scrolls, additional items are dynamically loaded, resulting in a smooth and efficient experience.

This feature works with both local and remote data. For example, when the MultiSelect is bound to 150 items, only the items that fit within the popup are loaded initially, based on the popup height. As scrolling continues, more items are fetched and rendered on demand, enabling efficient navigation through the entire dataset.

## Binding local data

The MultiSelect component can generate list items from an array of complex data. For this, the appropriate properties should be mapped to the [fields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectFieldSettings.html) property. With virtual scrolling enabled, the list is updated based on the scroll offset and loads additional items from the in-memory data source.

In the following example, the ID and Text properties from the complex data are mapped to the Value and Text fields, respectively.

{% highlight cshtml %}

{% include_relative code-snippet/virtualization/local-data.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZVzZnCLLvDOtKfT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Binding remote data

The MultiSelect supports retrieval of data from remote data services with the help of `DataManager` component. When using remote data, it initially fetches all the data from the server, triggering the `ActionBegin` and `ActionComplete` events, and then stores the data locally. During virtual scrolling, additional data is retrieved from the locally stored data, triggering the `ActionBegin` and `ActionComplete` events at that time as well.

The following sample displays the EmployeeID from the `VirtualDropdownData` Data Service.

{% highlight Razor %}

{% include_relative code-snippet/virtualization/remote-data.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZLfXnsVrFhXwhUz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customizing items count in virtualization 

When the `EnableVirtualization` property is enabled, the `Take` property provided by the user within the Query parameter at the initial state or during the `ActionBegin` event will be considered. Internally, it calculates the items that fit onto the current page (i.e., probably twice the amount of the popup's height). If the user-provided take value is less than the minimum number of items that fit into the popup, the user-provided take value will not be considered.

The following example demonstrates customizing the item count in virtualization.

{% highlight Razor %}

{% include_relative code-snippet/virtualization/item-count.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXrTNHMhLFzBMPHF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Grouping with virtualization

The MultiSelect component supports grouping with virtualization. Items can be organized into groups using the [GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectFieldSettings.html#Syncfusion_Blazor_DropDowns_MultiSelectFieldSettings_GroupBy) field in the data source. After grouping, virtualization behaves as it does with local data binding, providing a seamless experience. When the data source is remote, an initial request retrieves the full dataset for grouping, after which virtualization operates on the grouped data locally.

The following example demonstrates grouping with virtualization.

{% highlight Razor %}

{% include_relative code-snippet/virtualization/group.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDhzZxsVBveNGfJx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Filtering with virtualization

The MultiSelect component supports filtering with virtualization. When the [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectModel-1.html#Syncfusion_Blazor_DropDowns_MultiSelectModel_1_AllowFiltering) option is enabled, the component filters data in response to user input. For remote data, the MultiSelect sends a request to the server based on the typed characters. Before the request is sent, an action begin event is triggered; after data is returned, an action complete event is triggered. Initial data is loaded when the popup opens. Regardless of whether the filtered list has a selection, the popup closes after filtering.

The following example demonstrates filtering with virtualization.

{% highlight Razor %}

{% include_relative code-snippet/virtualization/filter.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZBTjniBrvoGajst?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Checkbox with virtualization

The MultiSelect component supports checkbox selection with virtualization. When the [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectModel-1.html#Syncfusion_Blazor_DropDowns_MultiSelectModel_1_Mode) property is set to CheckBox, each list item renders a checkbox. Based on checkbox selection or clearing, the component’s Value property is updated with the corresponding values.

The following example demonstrates checkbox selection with virtualization.

{% highlight Razor %}

{% include_relative code-snippet/virtualization/checkbox.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjVftRMBVlGAAHBj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Custom value with virtualization

The MultiSelect component supports custom values with virtualization. When the [AllowCustomValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectModel-1.html#Syncfusion_Blazor_DropDowns_MultiSelectModel_1_AllowCustomValue) property is enabled, users can add a new option that is not present in the existing data. Upon selecting a custom value, the CustomValueSpecifier event is triggered, and the custom value is appended to the end of the complete list.

The following example demonstrates custom values with virtualization.

{% highlight Razor %}

{% include_relative code-snippet/virtualization/custom.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjBzjxCrVbHQCKrx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Preselect values with virtualization

The MultiSelect component supports preselected values with virtualization. When binding values from local or remote data, the corresponding items are resolved from the bound data source and applied to the component’s Value. When binding a custom value, it is applied to the component and appended to the end of the complete list.

The following example demonstrates preselect values with virtualization.

{% highlight Razor %}

{% include_relative code-snippet/virtualization/preselect.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDBJNnirVmbkEWqv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}