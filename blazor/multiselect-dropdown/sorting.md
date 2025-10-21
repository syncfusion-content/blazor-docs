---
layout: post
title: Sorting in Blazor MultiSelect Component | Syncfusion
description: Checkout and learn here all about Sorting functionality in Syncfusion Blazor MultiSelect component and much more.
platform: Blazor
control: MultiSelect
documentation: ug
---

# Sorting in Blazor MultiSelect Component

Enable sorting of items in ascending or descending order by setting the [SortOrder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_SortOrder) property.

The available sort orders are:

SortOrder | Description
------------ | -------------
[None](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SortOrder.html#Syncfusion_Blazor_DropDowns_SortOrder_None) | No sorting; items appear in their original order.
[Ascending](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SortOrder.html#Syncfusion_Blazor_DropDowns_SortOrder_Ascending) | Items are sorted in ascending order.
[Descending](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SortOrder.html#Syncfusion_Blazor_DropDowns_SortOrder_Descending) | Items are sorted in descending order.

In the following demonstration sample, the items in the datasource are shuffled in random order but decide whether the items to be listed in ascending or descending order alphanumerically in the popup.

{% highlight cshtml %}

{% include_relative code-snippet/sorting/sorting.razor %}

{% endhighlight %}

![Blazor MultiSelect sorted in descending order](./images/sorting/blazor_MultiSelect_sorting.png)