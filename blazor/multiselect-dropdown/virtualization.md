---
layout: post
title: Virtualization in Blazor MultiSelect Dropdown Component | Syncfusion
description: Checkout and learn here all about virtualization in Syncfusion Blazor MultiSelect Dropdown component and much more.
platform: Blazor
control: MultiSelect Dropdown
documentation: ug
---

# Virtualization in Blazor MultiSelect Dropdown Component

The MultiSelect component includes a virtual scrolling feature designed to enhance UI performance, particularly for handling large datasets. By enabling the [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_EnableVirtualization) option, the MultiSelect intelligently manages data rendering, ensuring only a subset of items is initially loaded when the component is rendered. As you interact with the dropdown, additional items are dynamically loaded as you scroll, creating a smooth and efficient user experience.

This feature is applicable to both local and remote data scenarios, providing flexibility in its implementation. For instance, consider a case where the MultiSelect is bound to a dataset containing 150 items. Upon opening the dropdown, only a few items are loaded initially, based on the height of the popup. As you scroll through the list, additional items are fetched and loaded on-demand, allowing you to effortlessly explore the complete dataset.

## Binding local data

The MultiSelect component can generate its list items through an array of complex data. For this, the appropriate columns should be mapped to the [fields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectFieldSettings.html) property. When using virtual scrolling, the list updates based on the scroll offset value, triggering a request to fetch more data from the server.

In the following example, `ID` column and `Text` column from complex data have been mapped to the `Value` field and `Text` field, respectively.

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

The following sample shows the example for Customizing items count in virtualization.

{% highlight Razor %}

{% include_relative code-snippet/virtualization/item-count.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXrTNHMhLFzBMPHF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Grouping with virtualization

The MultiSelect component supports grouping with Virtualization. It allows you to organize elements into groups based on different categories. Each item in the list can be classified using the [GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectFieldSettings.html#Syncfusion_Blazor_DropDowns_MultiSelectFieldSettings_GroupBy) field in the data table. After grouping, virtualization works similarly to local data binding, providing a seamless user experience. When the data source is bound to remote data, an initial request is made to retrieve all data for the purpose of grouping. Subsequently, the grouped data works in the same way as local data binding on virtualization. 

The following sample shows the example for Grouping with Virtualization. 

{% highlight Razor %}

{% include_relative code-snippet/virtualization/group.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDhzZxsVBveNGfJx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Filtering with virtualization

The MultiSelect component supports Filtering with Virtualization. The MultiSelect includes a built-in feature that enables data filtering when the [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectModel-1.html#Syncfusion_Blazor_DropDowns_MultiSelectModel_1_AllowFiltering) option is enabled. In the context of Virtual Scrolling, the filtering process operates in response to the typed characters. Specifically, the MultiSelect sends a request to the server, utilizing the full data source, to achieve filtering. Before initiating the request, an action event is triggered. Upon successful retrieval of data from the server, an action complete event is triggered. The initial data is loaded when the popup is opened. Whether the filter list has a selection or not, the popup closes.

The following sample shows the example for Filtering with Virtualization.

{% highlight Razor %}

{% include_relative code-snippet/virtualization/filter.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZBTjniBrvoGajst?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Checkbox with virtualization

The MultiSelect component supports CheckBox selection with Virtualization. The MultiSelect comes with integrated functionality that allows for the selection of multiple values using checkboxes when the [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectModel-1.html#Syncfusion_Blazor_DropDowns_MultiSelectModel_1_Mode) property is configured to `CheckBox`. In the context of Virtual Scrolling, the checkbox render with each list element. based on the checkbox selection and unselection, component value property updated with respective values.

The following sample shows the example for checkbox with Virtualization.

{% highlight Razor %}

{% include_relative code-snippet/virtualization/checkbox.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjVftRMBVlGAAHBj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Custom value with virtualization

The MultiSelect component supports custom value with Virtualization. When the [AllowCustomValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectModel-1.html#Syncfusion_Blazor_DropDowns_MultiSelectModel_1_AllowCustomValue) property is enabled, the MultiSelect enables users to include a new option not currently available in the component value. Upon selecting this newly added custom value, the MultiSelect triggers the `CustomValueSpecifier` event and also custom value will be added to the end of the complete list.

The following sample shows the example for custom value with Virtualization.

{% highlight Razor %}

{% include_relative code-snippet/virtualization/custom.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjBzjxCrVbHQCKrx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Preselect values with virtualization

The MultiSelect component extends its support for preselected values with Virtualization. When binding values from local or remote data to the MultiSelect component, the corresponding data value is fetched from the server and promptly updated within the component. Moreover, when binding a custom value to the component, the value is updated within the component, and the bound custom value is seamlessly appended to the end of the complete list.

The following sample shows the example for Preselect value with Virtualization.

{% highlight Razor %}

{% include_relative code-snippet/virtualization/preselect.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDBJNnirVmbkEWqv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}