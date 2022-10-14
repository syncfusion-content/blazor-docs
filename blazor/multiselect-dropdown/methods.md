---
layout: post
title: Methods in Blazor MultiSelect Dropdown Component | Syncfusion
description: Checkout and learn here all about Methods in Syncfusion Blazor MultiSelect Dropdown component and more.
platform: Blazor
control: MultiSelect Dropdown
documentation: ug
---

# Methods in Blazor MultiSelect Dropdown Component

This section explains the methods of the MultiSelect DropDown List component.

## ClearAsync()

Allows you to clear the selected values from the MultiSelect component.

### Declaration

> public Task ClearAsync()

{% highlight Razor %}

{% include_relative code-snippet/methods/ClearAsync.razor %}

{% endhighlight %}

## FilterAsync(IEnumerable<TItem>, Query, FieldSettingsModel)

To filter the data from given data source by using query.

### Declaration

> public Task FilterAsync(IEnumerable<TItem> dataSource, Query query = null, FieldSettingsModel fields = null)

### Parameters

* dataSource -Specifies the data source.
* query - Specifies the query.
* fields - Specifies the fields.

[Click to refer the code for FilterAsync](https://blazor.syncfusion.com/documentation/multiselect-dropdown/filtering)

## FocusAsync()

Sets the focus to the MultiSelect component for interaction.

### Declaration

> public Task FocusAsync()

{% highlight Razor %}

{% include_relative code-snippet/methods/Focus.razor %}

{% endhighlight %}

## FocusOutAsync()

Remove the focus from the MultiSelect component, if the component is in focus state.

### Declaration

> public Task FocusOutAsync()

{% highlight Razor %}

{% include_relative code-snippet/methods/Focus.razor %}

{% endhighlight %}

## GetDataByValueAsync(TValue)

Gets the array of data Object that matches the given array of values.

### Declaration

> public Task<List<TItem>> GetDataByValueAsync(TValue dataValue)

### Parameters

* dataValue	- Specifies the value(s).

{% highlight Razor %}

{% include_relative code-snippet/methods/GetDataByValueAsync.razor %}

{% endhighlight %}

## GetItemsAsync()

Gets all the list items bound on this component.

### Declaration

> public Task<IEnumerable<TItem>> GetItemsAsync()

{% highlight Razor %}

{% include_relative code-snippet/methods/GetItemsAsync.razor %}

{% endhighlight %}

## HidePopupAsync()

Hides the popup if it is in an open state.

### Declaration

> public Task HidePopupAsync()

{% highlight Razor %}

{% include_relative code-snippet/methods/PopupAsync.razor %}

{% endhighlight %}

## HideSpinner()

Hides the spinner loader.

### Declaration

> public Task HideSpinner()

{% highlight Razor %}

{% include_relative code-snippet/methods/SpinnerAsync.razor %}

{% endhighlight %}

## RefreshDataAsync()

Refreshes the popup list items. The method is useful if the popup list item changed externally.

### Declaration

> public Task RefreshDataAsync()

{% highlight Razor %}

{% include_relative code-snippet/methods/RefreshDataAsync.razor %}

{% endhighlight %}

## SelectAllAsync(Boolean)

Based on the state parameter, entire list item will be selected/deselected.

### Declaration

> public Task SelectAllAsync(bool state)

### parameter

* TrueSelects entire list items.
* FalseUn Selects entire list items.

{% highlight Razor %}

{% include_relative code-snippet/methods/SelectAllAsync.razor %}

{% endhighlight %}

## ShowPopupAsync()

Opens the popup that displays the list of items.

### Declaration

> public Task ShowPopupAsync()

{% highlight Razor %}

{% include_relative code-snippet/methods/PopupAsync.razor %}

{% endhighlight %}

## ShowSpinner()

Shows the spinner loader.

### Declaration

> public Task ShowSpinner()

{% highlight Razor %}

{% include_relative code-snippet/methods/SpinnerAsync.razor %}

{% endhighlight %}

