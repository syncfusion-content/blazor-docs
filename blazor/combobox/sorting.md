---
layout: post
title: Sorting in Blazor ComboBox Component | Syncfusion
description: Checkout and learn here all about Sorting functionality in Syncfusion Blazor ComboBox component and much more.
platform: Blazor
control: ComboBox
documentation: ug
---

# Sorting in Blazor ComboBox Component

Sorting enables displaying items in ascending or descending order. To enable sorting in the ComboBox, set the [SortOrder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_SortOrder) property to the required value.

The available sort orders are:

SortOrder     | Description
------------ | -------------
  [None](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SortOrder.html#Syncfusion_Blazor_DropDowns_SortOrder_None)       | The data source is not sorted.
  [Ascending](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SortOrder.html#Syncfusion_Blazor_DropDowns_SortOrder_Ascending)     | The data source is sorted in ascending order.
  [Descending](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SortOrder.html#Syncfusion_Blazor_DropDowns_SortOrder_Descending)      | The data source is sorted in descending order.

In the following sample, items in the data source are initially in random order. Use SortOrder to display them alphanumerically in ascending or descending order in the popup.

{% highlight cshtml %}

{% include_relative code-snippet/sorting/sorting.razor %}

{% endhighlight %}

![Blazor ComboBox with SortOrder descending](./images/sorting/blazor_combobox_sorting.png)