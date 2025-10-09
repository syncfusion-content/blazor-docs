```markdown
---
layout: post
title: Filtering in Blazor AutoComplete Component | Syncfusion
description: Learn how to enable and configure data filtering in the Syncfusion Blazor AutoComplete component, including local/remote data, debounce delay, filter types, and custom filtering.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Filtering in Blazor AutoComplete

The AutoComplete component provides built-in support for filtering data items when the [`AllowFiltering`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_AllowFiltering) property is enabled. Filtering begins as soon as you start typing characters in the search box. The default value for `AllowFiltering` is `false`.

## Local data

The following code demonstrates the filtering functionality with local data in the AutoComplete component.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/local-data.razor %}

{% endhighlight %}

![Blazor AutoComplete with local data filtering](./images/filtering/blazor_autocomplete_local-data.png)

## Remote data

For remote data, a filter action request is made to the server (via the [`DataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) and its configured adaptor) with each key press, depending on the [`DebounceDelay`](#debounce-delay).

The code below demonstrates the filtering functionality with [`ODataAdaptor`](https://blazor.syncfusion.com/documentation/data/adaptors#odata-adaptor) in the AutoComplete component using the [`Query`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.Query.html) property.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/remote-data.razor %}

{% endhighlight %}

![Blazor AutoComplete with remote data filtering](./images/filtering/blazor_autocomplete_remote-data.png)

## Debounce delay

You can control the frequency of filtering operations by using the [`DebounceDelay`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_DebounceDelay) property, which sets a delay in milliseconds. This feature helps to reduce the number of filter requests as you type, improving performance and responsiveness for a smoother user experience, especially with remote data sources.

By default, the `DebounceDelay` is set to `300ms`. To disable this feature entirely (triggering a filter on every key stroke), you can set it to `0ms`.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/debounce-delay.razor %}

{% endhighlight %}

![Blazor AutoComplete with DebounceDelay in filtering](./images/filtering/blazor_autocomplete_debounce-delay.gif)

## Filter type

You can specify the type of filter action to be used during the search operation using the [`FilterType`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_FilterType) property. These filter types are typically applied to string fields in your data.

| FilterType | Description |
| :--------- | :---------- |
| [`StartsWith`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FilterType.html#Syncfusion_Blazor_DropDowns_FilterType_StartsWith) | Checks whether a value begins with the specified search string. |
| [`EndsWith`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FilterType.html#Syncfusion_Blazor_DropDowns_FilterType_EndsWith) | Checks whether a value ends with the specified search string. |
| [`Contains`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FilterType.html#Syncfusion_Blazor_DropDowns_FilterType_Contains) | Checks whether a value contains the specified search string. |

In the following example, `StartsWith` filter type has been mapped to the `FilterType` property.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/filter-type.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjBKMhipBzHIgAvv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor AutoComplete with `StartsWith` filter type](./images/filtering/blazor_autocomplete_filter-type.png)

## Minimum length

You can set a minimum character count required to trigger data filtering in the AutoComplete component by setting the [`MinLength`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_MinLength) property. This can reduce unnecessary filtering operations, especially with remote data.

In the following example, the search data will not be fetched (for either local or remote data) until the input contains at least three characters.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/minimum-filter-length.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDBUsBsJhzbSDGTo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Filtering Blazor AutoComplete items based on character count](./images/blazor-autocomplete-filter-based-length.png)

## Multi-column filtering

The AutoComplete component can visually present data across multiple columns. This layout support is enabled by adding the `e-multi-column` class to the [`CssClass`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_CssClass) property.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/multi-column.razor %}

{% endhighlight %}

![Blazor AutoComplete with multi-column display](./images/filtering/blazor_autocomplete_multi-column.png)

You can achieve filtering across multiple data fields by passing a list of [`predicates`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WhereFilter.html#Syncfusion_Blazor_Data_WhereFilter_predicates) to the [`And`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WhereFilter.html#Syncfusion_Blazor_Data_WhereFilter_And_Syncfusion_Blazor_Data_WhereFilter_) or [`Or`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WhereFilter.html#Syncfusion_Blazor_Data_WhereFilter_Or_Syncfusion_Blazor_Data_WhereFilter_) methods of [`WhereFilters`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WhereFilter.html).

{% highlight cshtml %}

{% include_relative code-snippet/filtering/multi-column-filtering.razor %}

{% endhighlight %}

![Blazor AutoComplete with multi-field filtering](./images/filtering/blazor_autocomplete_multi-colum-filtering.gif)

## Case-sensitive filtering

Data items can be filtered with or without case sensitivity using the [`DataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html). This is done by setting the optional `IgnoreCase` parameter within a [`Where` clause](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.Query.html#Syncfusion_Blazor_Data_Query_Where_Syncfusion_Blazor_Data_WhereFilter_). Set `IgnoreCase` to `false` for case-sensitive filtering.

The following example shows how to perform case-sensitive filtering.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/case-sensitive.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDVACVWJhzFwRqep?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Custom filtering

The AutoComplete component's filter queries can be customized using the [`Filtering`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteEvents-2.html#Syncfusion_Blazor_DropDowns_AutoCompleteEvents_2_Filtering) event. This event allows you to implement custom logic, such as filtering text across multiple columns in the data source.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/custom-filtering.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXhKsLiprJawVKuX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Suggestion item count

You can specify the maximum number of filter suggestion items displayed in the dropdown list using the [`SuggestionCount`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_SuggestionCount) property of the AutoComplete.

Refer to the following example to restrict the suggestion list to 3 items.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/suggestion-filtering.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNrgMVWTLTmOENnq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Filtering Blazor AutoComplete items based on count](./images/blazor-autocomplete-filter-item-count.png)

## AutoComplete with Google search results

The Blazor AutoComplete component offers functionality for displaying Google-like search suggestions. This simulates the behavior of generating relevant results in the suggestion list with each keypress, often by querying an external service.

{% highlight Razor %}

{% include_relative code-snippet/filtering/google-search-result.razor %}

{% endhighlight %} 

![Blazor AutoComplete with Google search results](./images/filtering/blazor_autocomplete_google-search-result.gif)

### Highlighting search characters using the Highlight property

You can highlight the search text within the suggested list items of the AutoComplete component by setting the [`Highlight`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_Highlight) property to `true`. When enabled, characters that match the search query in the list items will be visually emphasized.

{% highlight Razor %}

{% include_relative code-snippet/filtering/highlight-property.razor %}

{% endhighlight %} 

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZLAMLszLyjsCNWA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor AutoComplete with highlight property](./images/filtering/blazor_autocomplete_highlight-property.png)

### Highlighting search characters using a method

You can programmatically highlight the search text in the suggested list items of the AutoComplete component by using the `HighLightSearch` method. This method accepts several arguments, allowing for granular control over the highlighting process:

*   `textValue`: The text content of the list item where highlighting needs to occur.
*   `ignoreCase`: A boolean value which, when set to `true`, performs the search text comparison without considering casing.
*   `filterType`: Determines which filter type (`StartsWith`, `EndsWith`, `Contains`, etc.) dictates how the highlight text is matched within the `textValue`.
*   `highlightText`: (Optional) The specific text string to be highlighted. If not provided, the method typically uses the current filter value as the `highlightText`.

{% highlight Razor %}

{% include_relative code-snippet/filtering/highLightSearch-method.razor %}

{% endhighlight %} 

![Blazor AutoComplete with HighLightSearch method](./images/filtering/blazor_dropdown_highLightSearch-method.png)

{% previewsample "https://blazorplayground.syncfusion.com/embed/rthUsLsphSZYvuHw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
```