---
layout: post
title: Highlight searching  in Blazor AutoComplete Component | Syncfusion
description: Checkout and learn here all about highlight searching in Syncfusion Blazor AutoComplete component and much more.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Highlight Search Blazor AutoComplete Component

You can highlight the search text in the suggested list items of the autocomplete component by using the `Highlight` property. When set to true, it will highlight the characters that match the search query in the list items.

{% highlight Razor %}

{% include_relative code-snippet/filtering/high-light-property.razor %}

{% endhighlight %} 

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZLAMLszLyjsCNWA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor AutoComplete with highlight property](./images/filtering/blazor_autocomplete_highlight-property.png)

## Highlight with template

You can highlight the search text in the suggested list items of the autocomplete component by using the `HighLightSearch` method. It accepts several arguments, including `textValue`, `ignoreCase`, `filterType` and `highLightText`. When called, it will highlight the characters that match the search query in the list items."

* `textValue` - The text to be highlighted in the list item.
* `ignoreCase` - A boolean value which when set to true performs the search text based on casing.
* `filterType` - Determines on which filter type the highlight text is updated on the text.
* `highlightText` - The text to be highlighted. This is an optional argument. If not provided, it will use the filter value as the highlight text."

{% highlight Razor %}

{% include_relative code-snippet/filtering/highLightSearch-method.razor %}

{% endhighlight %} 

![Blazor AutoComplete with HighLightSearch method](./images/filtering/blazor_autocomplete_highLightSearch-method.png)

{% previewsample "https://blazorplayground.syncfusion.com/embed/rthUsLsphSZYvuHw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Change the highlight style

You can customize the appearance of highlighted text using the `.e-highlight` class. In the example below, we have styled the background color for the highlighted text.

{% highlight Razor %}

{% include_relative code-snippet/highlight-search/highlight-style.razor %}

{% endhighlight %} 

![Blazor AutoComplete with HighLightSearch method](./images/highlight-search/blazor_autocomplete_highlight-style.png)
