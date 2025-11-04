---
layout: post
title: Sorting in Blazor ComboBox Component | Syncfusion
description: Checkout and learn here all about Sorting functionality in Syncfusion Blazor ComboBox component and much more.
platform: Blazor
control: ComboBox
documentation: ug
---

# Sorting in Blazor ComboBox Component

The Sorting enables you to sort data in the `Ascending` or `Descending` order. To enable sorting in the DropDownList, set the [SortOrder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_SortOrder) property to the required value. 

The available type of sort orders are:

SortOrder     | Description
------------ | -------------
  [None](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SortOrder.html#Syncfusion_Blazor_DropDowns_SortOrder_None)       | The data source is not sorting.
  [Ascending](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SortOrder.html#Syncfusion_Blazor_DropDowns_SortOrder_Ascending)     | The data source is sorting with ascending order.
  [Descending](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SortOrder.html#Syncfusion_Blazor_DropDowns_SortOrder_Descending)      | The data source is sorting with descending order.

In the following demonstration sample, the items in the datasource are shuffled in random order but decide whether the items to be listed in ascending or descending order alphanumerically in the popup.

{% highlight cshtml %}

{% include_relative code-snippet/sorting/sorting.razor %}

{% endhighlight %}

![Blazor ComboBox with sortOrder descending](./images/sorting/blazor_combobox_sorting.png)