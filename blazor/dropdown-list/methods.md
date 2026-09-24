---
layout: post
title: Methods in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about methods in Syncfusion Blazor DropDown List component and much more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Methods in Blazor DropDown List Component

This section explains the methods of the DropDown List component.

## ClearAsync()

Allows you to clear the selected values from the component.

### Declarations

> public Task ClearAsync()

{% highlight Razor %}

{% include_relative code-snippet/methods/ClearAsync.razor %}

{% endhighlight %} 

## FilterAsync(IEnumerable<TItem>, Query, FieldSettingsModel)

To filter the data from given data source by using query.

### Declarations

> protected Task FilteringAction(IEnumerable<TItem> dataSource, Query query, FieldSettingsModel fields)

### Parameters

* dataSource - Specifies the data source.
* query	- Specifies the query.
* fields - Specifies the fields.

[Click to refer the code for FilterAsync](https://blazor.syncfusion.com/documentation/dropdown-list/filtering)

## FocusAsync()

Sets the focus to the DropDownList component for interaction.

### Declarations

> public Task FocusAsync()

{% highlight Razor %}

{% include_relative code-snippet/methods/Focus.razor %}

{% endhighlight %} 

## FocusOutAsync()

Remove the focus from the DropDownList component, if the component is in focus state.

### Declarations

> public Task FocusOutAsync()

{% highlight Razor %}

{% include_relative code-snippet/methods/Focus.razor %}

{% endhighlight %} 

## GetDataByValue(TValue)

Gets the data Object that matches the given value.

### Declarations

> public TItem GetDataByValue(TValue ddlValue)

### Parameters

* ddlValue - Specifies the DropDownList value.

{% highlight Razor %}

{% include_relative code-snippet/methods/GetDataByValue.razor %}

{% endhighlight %} 

## GetItemsAsync()

Gets all the list items bound on this component.

### Declarations

> public Task<IEnumerable<TItem>> GetItemsAsync()

{% highlight Razor %}

{% include_relative code-snippet/methods/GetItemsAsync.razor %}

{% endhighlight %} 

## HidePopupAsync()

Hides the DropDownList popup.

### Declarations

> public Task HidePopupAsync()

{% highlight Razor %}

{% include_relative code-snippet/methods/Popup.razor %}

{% endhighlight %} 

## HideSpinnerAsync()

Hides the spinner loader.

### Declarations

> public Task HideSpinnerAsync()

{% highlight Razor %}

{% include_relative code-snippet/methods/Spinner.razor %}

{% endhighlight %} 

## RefreshDataAsync()

Refreshes the popup list items. The method is useful if the popup list item changed externally.

### Declarations

> public Task RefreshDataAsync()

{% highlight Razor %}

{% include_relative code-snippet/methods/RefreshDataAsync.razor %}

{% endhighlight %} 

## ShowPopupAsync()

Opens the popup that displays the list of items.

### Declarations

> public Task ShowPopupAsync()

{% highlight Razor %}

{% include_relative code-snippet/methods/Popup.razor %}

{% endhighlight %} 

## ShowSpinnerAsync()

Shows the spinner loader.

### Declarations

> public Task ShowSpinnerAsync()

{% highlight Razor %}

{% include_relative code-snippet/methods/Spinner.razor %}

{% endhighlight %} 


