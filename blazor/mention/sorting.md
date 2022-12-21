---
layout: post
title: Sorting in Blazor Mention Component | Syncfusion
description: Checkout and learn here all about sorting in Syncfusion Blazor Mention component and much more.
platform: Blazor
control: Mention
documentation: ug
---

# Sorting in Blazor Mention Component

The `SortOrder` property that allows you to specify the order in which the suggestion list items should be displayed. The `SortOrder` property can be set to one of three values: `Ascending`, `Descending`, or `None`.

The available type of sort orders are:

SortOrder     | Description
------------  | -------------
  `Ascending` | This value specifies that the suggestion list items should be sorted in ascending order, from lowest to highest.
  `Descending`| This value specifies that the suggestion list items should be sorted in descending order, from highest to lowest.
  `None`      | This value specifies that the suggestion list items should not be sorted at all.

{% highlight razor %}

{% include_relative code-snippet/sorting.razor %}

{% endhighlight %}

![Blazor Mention with sortOrder descending](./images/blazor-mention-sorting.png)