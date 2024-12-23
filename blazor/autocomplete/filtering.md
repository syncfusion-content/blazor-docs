---
layout: post
title: Filtering in Blazor AutoComplete Component | Syncfusion
description: Checkout and learn here all about Filtering in Syncfusion Blazor AutoComplete component and much more.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Filtering in Blazor AutoComplete

The AutoComplete has built-in support to filter data items when [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_AllowFiltering) is enabled. The filter operation starts as soon as you start typing characters in the search box.  Default value of AllowFiltering is `false`.

## Local data

The following code demonstrates the filtering functionality with local data in the AutoComplete component.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/local-data.razor %}

{% endhighlight %}

![Blazor AutoComplete with local data filtering](./images/filtering/blazor_autocomplete_local-data.png)

## Remote data

For Remote data, each key press, filter action request is made at the server end.

The below code demonstrates the filtering functionality with [ODataAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#odata-adaptor) in the AutoComplete component with help of [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.Query.html) property.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/remote-data.razor %}

{% endhighlight %}

![Blazor AutoComplete with Remote Data filtering](./images/filtering/blazor_autocomplete_remote-data.png)

## Debounce delay

You can use the [DebounceDelay](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_DebounceDelay) property for filtering, enabling you to set a delay in milliseconds. This functionality helps reduce the frequency of filtering as you type, enhancing performance and responsiveness for a smoother user experience.By default, a DebounceDelay of 300ms is set. If you wish to disable this feature entirely, you can set it to 0ms.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/debounce-delay.razor %}

{% endhighlight %}

![Blazor AutoComplete with DebounceDelay in filtering](./images/filtering/blazor_autocomplete_debounce-delay.gif)


## Filter type

You can use [FilterType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_FilterType) property to specify on which filter type needed to be considered on the search action of the component. The available `FilterType` and its supported data types are:

FilterType     | Description
------------ | -------------
  [StartsWith](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FilterType.html#Syncfusion_Blazor_DropDowns_FilterType_StartsWith)       | Checks whether a value begins with the specified value.
  [EndsWith](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FilterType.html#Syncfusion_Blazor_DropDowns_FilterType_EndsWith)     | Checks whether a value ends with specified value.
  [Contains](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FilterType.html#Syncfusion_Blazor_DropDowns_FilterType_Contains)      | Checks whether a value contained with specified value.

In the following example, `StartsWith` filter type has been mapped to the `FilterType` property.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/filter-type.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjBKMhipBzHIgAvv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor AutoComplete with Filter Type](./images/filtering/blazor_autocomplete_filter-type.png)

## Minimum length

You can set the limit for the character count to filter the data on the AutoComplete. This can be done by setting the [MinLength](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_MinLength) property to AutoComplete.

In the following example, the remote request does not fetch the search data until the search key contains three characters.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/minimum-filter-length.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDBUsBsJhzbSDGTo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Filtering Blazor AutoComplete Items based on Character Count](./images/blazor-autocomplete-filter-based-length.png)

## Multi column filtering

In the built-in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor theme files, support for multi column can be enabled by adding `e-multi-column` class in the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListModel-2.html#Syncfusion_Blazor_DropDowns_DropDownListModel_2_CssClass) property.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/multi-column.razor %}

{% endhighlight %}

![Blazor AutoComplete with Multi Column filtering](./images/filtering/blazor_autocomplete_multi-column.png)

You can achieve multiple column(field) filtering by passing the List of [predicates](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WhereFilter.html#Syncfusion_Blazor_Data_WhereFilter_predicates) to the [And](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WhereFilter.html#Syncfusion_Blazor_Data_WhereFilter_And_Syncfusion_Blazor_Data_WhereFilter_) or [Or](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WhereFilter.html#Syncfusion_Blazor_Data_WhereFilter_Or_Syncfusion_Blazor_Data_WhereFilter_) methods of [WhereFilters](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WhereFilter.html#Syncfusion_Blazor_Data_WhereFilter__ctor).

{% highlight cshtml %}

{% include_relative code-snippet/filtering/multi-column-filtering.razor %}

{% endhighlight %}

![Blazor AutoComplete with Multi Column filtering](./images/filtering/blazor_autocomplete_multi-colum-filtering.gif)

## Case sensitive filtering

The Data items can be filtered with or without case sensitivity using the [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html). This can be done by passing the fourth optional parameter [IgnoreCase](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WhereFilter.html#Syncfusion_Blazor_Data_WhereFilter_IgnoreCase) of the [Where clause](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.Query.html#Syncfusion_Blazor_Data_Query_Where_Syncfusion_Blazor_Data_WhereFilter_).

The following example shows how to perform case-sensitive filter.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/case-sentitive.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDVACVWJhzFwRqep?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Custom filtering

The AutoComplete component filter queries can be customized using [Filtering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteEvents-2.html#Syncfusion_Blazor_DropDowns_AutoCompleteEvents_2_Filtering) event. You can also filter the text in multiple columns in the data source.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/custom-filtering.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXhKsLiprJawVKuX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Suggestion item count

You can specify the filter suggestion item count using the [SuggestionCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html#Syncfusion_Blazor_DropDowns_SfAutoComplete_2_SuggestionCount) property of AutoComplete.

Refer to the following example to restrict the suggestion list item counts as 3.

{% highlight cshtml %}

{% include_relative code-snippet/filtering/suggestion-filtering.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNrgMVWTLTmOENnq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Filtering Blazor AutoComplete Items based on Count](./images/blazor-autocomplete-filter-item-count.png)

## AutoComplete with google search result

The Blazor AutoComplete component offers Google-like search suggestions. This functionality simulates the behavior of conducting a Google search with each keypress, displaying relevant results in the suggestion list.

{% highlight Razor %}

{% include_relative code-snippet/filtering/google-search-result.razor %}

{% endhighlight %} 

![Blazor AutoComplete with google search result](./images/filtering/blazor_autocomplete_google-search-result.gif)

### Highlighting Search character using property

You can highlight the search text in the suggested list items of the autocomplete component by using the `Highlight` property. When set to true, it will highlight the characters that match the search query in the list items.

{% highlight Razor %}

{% include_relative code-snippet/filtering/high-light-property.razor %}

{% endhighlight %} 

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZLAMLszLyjsCNWA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor AutoComplete with highlight property](./images/filtering/blazor_autocomplete_highlight-property.png)

### Highlighting Search character using method

You can highlight the search text in the suggested list items of the autocomplete component by using the `HighLightSearch` method. It accepts several arguments, including `textValue`, `ignoreCase`, `filtertype` and `highLighText`. When called, it will highlight the characters that match the search query in the list items."

* `textValue` - The text to be highlighted in the list item.
* `ignoreCase` - A boolean value which when set to true performs the search text based on casing.
* `filterType` - Determines on which filter type the highlight text is updated on the text.
* `highlightText` - The text to be highlighted. This is an optional argument. If not provided, it will use the filter value as the highlight text."

{% highlight Razor %}

{% include_relative code-snippet/filtering/highLightSearch-method.razor %}

{% endhighlight %} 

![Blazor AutoComplete with HighLightSearch method](./images/filtering/blazor_dropdown_highLightSearch-method.png)

{% previewsample "https://blazorplayground.syncfusion.com/embed/rthUsLsphSZYvuHw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
