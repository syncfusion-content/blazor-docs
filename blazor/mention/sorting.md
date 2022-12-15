---
layout: post
title: Sorting in Blazor Mention Component | Syncfusion
description: Checkout and learn here all about Sorting in Syncfusion Blazor Mention component and much more.
platform: Blazor
control: Mention
documentation: ug
---

# Sorting in Mention

You can display the suggestion list items in a specific order. It has possible types of `Ascending` or `Descending` and `None` in the `SortOrder` property.

The available type of sort orders are:

SortOrder     | Description
------------  | -------------
  `None`      | The data source is not sorted..
  `Ascending` | The data source is sorting in ascending order.
  `Descending`| The data source is sorted in descending order.

{% highlight razor %}

{% include_relative code-snippet/sorting.razor %}

{% endhighlight %}

![Blazor Mention with sortOrder descending](./images/blazor-mention-sorting.png)