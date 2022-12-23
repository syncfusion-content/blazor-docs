---
layout: post
title: Sorting in Blazor Mention Component | Syncfusion
description: Checkout and learn here all about sorting in Syncfusion Blazor Mention component and much more.
platform: Blazor
control: Mention
documentation: ug
---

# Sorting in Blazor Mention Component

The [SortOrder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_SortOrder) property of the Mention component allows you to specify the order in which the suggestion list items should be displayed. By default, the `SortOrder` property is set to `None`, which means that the suggestion list items will be displayed in their original order. The `SortOrder` property can be set to one of the below three values.

SortOrder     | Description
------------  | -------------
  `Ascending` | The suggestion list items will be sorted in ascending order, from lowest to highest..
  `Descending`| The suggestion list items will be sorted in descending order, from highest to lowest.
  `None`      | The suggestion list items will not be sorted at all and will be displayed in their original order.

{% highlight razor %}

{% include_relative code-snippet/sorting.razor %}

{% endhighlight %}

![Blazor Mention with sortOrder descending](./images/blazor-mention-sorting.png)