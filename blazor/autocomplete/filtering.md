---
layout: post
title: Filtering in Blazor AutoComplete Component | Syncfusion
description: Checkout and learn here all about Filtering in Syncfusion Blazor AutoComplete component and much more.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Filtering in Blazor AutoComplete

The AutoComplete has built-in support to filter data items when [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_AllowFiltering) is enabled. Filtering begins as the user types in the input. The default value of AllowFiltering is `false`.

## Local data

The following example demonstrates filtering with local data in the AutoComplete component.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/local-data.razor %}

{% endhighlight %}

![Blazor AutoComplete with local data filtering](./images/filtering/blazor_autocomplete_local-data.png)

## Remote data

For remote data, each filtered query (subject to DebounceDelay and MinLength) results in a request to the server.

The following example demonstrates filtering with the [ODataAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#odata-adaptor) using the [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.Query.html) property.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/remote-data.razor %}

{% endhighlight %}

![Blazor AutoComplete with remote data filtering](./images/filtering/blazor_autocomplete_remote-data.png)

## Debounce delay

Use the [DebounceDelay](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_DebounceDelay) property for filtering, enabling you to set a delay in milliseconds. This functionality helps reduce the frequency of filtering as you type, enhancing performance and responsiveness for a smoother user experience.By default, a DebounceDelay of 300ms is set. If you wish to disable this feature entirely, can set it to 0ms.


{% highlight cshtml %}

{% include_relative code-snippet/filtering/debounce-delay.razor %}

{% endhighlight %}

![Blazor AutoComplete with DebounceDelay in filtering](./images/filtering/blazor_autocomplete_debounce-delay.gif)


## Filter type

Use the [FilterType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_FilterType) property to define how search text is matched. Available options:

FilterType     | Description
------------ | -------------
  [StartsWith](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FilterType.html#Syncfusion_Blazor_DropDowns_FilterType_StartsWith)       | Checks whether a value begins with the specified text.
  [EndsWith](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FilterType.html#Syncfusion_Blazor_DropDowns_FilterType_EndsWith)     | Checks whether a value ends with the specified text.
  [Contains](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FilterType.html#Syncfusion_Blazor_DropDowns_FilterType_Contains)      | Checks whether a value contains the specified text.

In the following example, the `StartsWith` filter type is applied to the `FilterType` property.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/filter-type.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjBKMhipBzHIgAvv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor AutoComplete with filter type](./images/filtering/blazor_autocomplete_filter-type.png)

## Minimum length

Limit filtering until a minimum number of characters is typed using the [MinLength](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_MinLength) property.

In the following example, the remote request does not run until the search text contains three or more characters.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/minimum-filter-length.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDBUsBsJhzbSDGTo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Filtering Blazor AutoComplete items based on character count](./images/blazor-autocomplete-filter-based-length.png)

## Multi column filtering

In the built-in Syncfusion Blazor theme files, multi-column rendering can be enabled by adding the `e-multi-column` class using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_CssClass) property.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/multi-column.razor %}

{% endhighlight %}

![Blazor AutoComplete with multi-column filtering](./images/filtering/blazor_autocomplete_multi-column.png)

Multiple column (field) filtering can be achieved by passing a list of [predicates](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WhereFilter.html#Syncfusion_Blazor_Data_WhereFilter_predicates) to the [And](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WhereFilter.html#Syncfusion_Blazor_Data_WhereFilter_And_Syncfusion_Blazor_Data_WhereFilter_) or [Or](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WhereFilter.html#Syncfusion_Blazor_Data_WhereFilter_Or_Syncfusion_Blazor_Data_WhereFilter_) methods of [WhereFilters](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WhereFilter.html#Syncfusion_Blazor_Data_WhereFilter__ctor).

{% highlight cshtml %}

{% include_relative code-snippet/filtering/multi-column-filtering.razor %}

{% endhighlight %}

![Blazor AutoComplete with multi-column filtering](./images/filtering/blazor_autocomplete_multi-colum-filtering.gif)

## Case sensitive filtering

Data items can be filtered with or without case sensitivity using the [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html). Pass the fourth optional parameter [IgnoreCase](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WhereFilter.html#Syncfusion_Blazor_Data_WhereFilter_IgnoreCase) to the [Where](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.Query.html#Syncfusion_Blazor_Data_Query_Where_Syncfusion_Blazor_Data_WhereFilter_) clause. Setting `IgnoreCase` to `true` performs case-insensitive filtering; setting it to `false` results in case-sensitive filtering.

The following example shows how to perform case-sensitive filtering.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/case-sentitive.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDVACVWJhzFwRqep?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Custom filtering

Filter queries can be customized using the [Filtering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteEvents-2.html#Syncfusion_Blazor_DropDowns_AutoCompleteEvents_2_Filtering) event. This also enables filtering across multiple columns in the data source.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/custom-filtering.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXhKsLiprJawVKuX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Suggestion item count

Specify the number of suggested items using the [SuggestionCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_SuggestionCount) property.

The following example restricts the suggestion list to 3 items.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/suggestion-filtering.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNrgMVWTLTmOENnq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Filtering Blazor AutoComplete items based on count](./images/blazor-autocomplete-filter-item-count.png)

## AutoComplete with google search result

The Blazor AutoComplete component offers Google-like search suggestions. This simulates performing a search on each keypress and shows relevant results in the suggestion list.

{% highlight Razor %}

{% include_relative code-snippet/filtering/google-search-result.razor %}

{% endhighlight %} 

![Blazor AutoComplete with Google search result](./images/filtering/blazor_autocomplete_google-search-result.gif)

### Highlighting Search character using property

Highlight the search text in suggestion list items by enabling the `Highlight` property. When set to true, characters matching the search query are highlighted in list items.

{% highlight Razor %}

{% include_relative code-snippet/filtering/high-light-property.razor %}

{% endhighlight %} 

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZLAMLszLyjsCNWA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor AutoComplete with highlight property](./images/filtering/blazor_autocomplete_highlight-property.png)

### Highlighting Search character using method

Highlight the search text in suggestion list items using the `HighLightSearch` method. It accepts the following arguments: `textValue`, `ignoreCase`, `filtertype`, and `highLighText`. When called, it highlights characters that match the search query in the list items.

* `textValue` - The text to evaluate and highlight within the list item.
* `ignoreCase` - When set to true, performs case-insensitive matching.
* `filterType` - Determines which filter type is used to evaluate the highlight.
* `highlightText` - The text to highlight. Optional; if not provided, the current filter value is used.

{% highlight Razor %}

{% include_relative code-snippet/filtering/highLightSearch-method.razor %}

{% endhighlight %} 

![Blazor AutoComplete with HighLightSearch method](./images/filtering/blazor_dropdown_highLightSearch-method.png)

{% previewsample "https://blazorplayground.syncfusion.com/embed/rthUsLsphSZYvuHw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}