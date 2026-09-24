---
layout: post
title: Methods in Blazor AutoComplete Component | Syncfusion
description: Checkout and learn here all about Methods in Syncfusion Blazor AutoComplete component and much more.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Methods in Blazor AutoComplete Component

This section explains the methods of the AutoComplete component.

## HighLightSearch(String, Boolean, FilterType, String)

Highlight the searched characters on suggested list items.

### Declaration

> public string HighLightSearch(string textValue, bool ignoreCase, FilterType filtertype, string highLighText = null)

### Paramaters

* textValue	- highlight the list item.
* ignoreCase - performing the search text based on casing.
* filtertype - Determines on which filter type, the highlight text update on the text.
* highLighText - Higlighted the char based on hightligh text and this is optional. If not provide the highlightText, it wil get the filter value.

{% highlight Razor %}

{% include_relative code-snippet/methods/HighLightSearch.razor %}

{% endhighlight %} 