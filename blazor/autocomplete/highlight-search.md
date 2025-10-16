---
layout: post
title: Highlight search in Blazor AutoComplete component | Syncfusion
description: Check out how to highlight search text in the Syncfusion Blazor AutoComplete component, including template-based highlighting and CSS customization.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Highlight Search Blazor AutoComplete Component

Highlight the search text in the suggested list items of the AutoComplete component by using the `Highlight` property. The default value is `false`. When set to `true`, the component highlights the characters that match the current search query in the suggestion list. The rendered markup uses the `e-highlight` CSS class for the matched segments.

{% highlight Razor %}

{% include_relative code-snippet/filtering/high-light-property.razor %}

{% endhighlight %} 

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZLAMLszLyjsCNWA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![AutoComplete highlighting matched search text using the Highlight property](./images/filtering/blazor_autocomplete_highlight-property.png)

## Highlight with template

Use the `HighLightSearch` method within an item template to highlight matched text in custom-rendered list items. It accepts the following arguments and highlights characters that match the search query based on the specified options.

* `textValue` - The display text from the current list item to evaluate and render with highlights.
* `ignoreCase` - When `true`, performs case-insensitive matching.
* `filterType` - Specifies how matches are determined (for example, starts with, contains, or ends with).
* `highlightText` - Optional. The text to highlight. If not provided, the method uses the current filter value.

{% highlight Razor %}

{% include_relative code-snippet/filtering/highLightSearch-method.razor %}

{% endhighlight %} 

![Blazor AutoComplete highlighting using the HighLightSearch method in a template](./images/filtering/blazor_autocomplete_highLightSearch-method.png)

{% previewsample "https://blazorplayground.syncfusion.com/embed/rthUsLsphSZYvuHw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Change the highlight style

Customize the appearance of the highlighted text using the `.e-highlight` class. In the following example, the background color for matched text is styled to improve visibility.

{% highlight Razor %}

{% include_relative code-snippet/highlight-search/highlight-style.razor %}

{% endhighlight %} 

![Blazor AutoComplete custom highlight style using the e-highlight class](./images/highlight-search/blazor_autocomplete_highlight-style.png)