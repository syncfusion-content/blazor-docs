---
layout: post
title: Paging in Syncfusion Blazor MultiColumn ComboBox
description: Checkout and learn here all about Paging in Syncfusion Blazor MultiColumn ComboBox component and much more details.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Paging in Blazor MultiColumn ComboBox component

Paging provides an option to display data in segmented pages, making it easier to navigate large datasets. To enable paging, set the [AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_AllowPaging) property to `true` (default is `false`). When paging is enabled, a pager component is rendered at the bottom of the MultiColumn ComboBox popup to navigate between pages. If the total records fit on a single page, the pager is hidden. Paging works with both local and remote data sources; when used with remote data, queries can be shaped to request only the current page of data.

## Customize the pager options

Customize the pager to meet specific requirements using the following properties:
- [PageCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_PageCount): Number of page links displayed in the pager (default is `8`).
- [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_PageSize): Number of records displayed per page (default is `12`).

### Change the page size

The Syncfusion<sup style="font-size:70%">&reg;</sup> MultiColumn ComboBox allows you to control the number of records displayed per page, providing you with flexibility in managing your data. This feature is particularly useful when you want to adjust the amount of data visible to you at any given time. To achieve this, you can utilize the [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_PageSize) property. This property is used to specify the initial number of records to display on each page. The default value of pageSize property is 12.

The following example demonstrates how to change the page size of a MultiColumn ComboBox using an external button click based on **NumericTextBox** input.

{% highlight cshtml %}

{% include_relative code-snippet/paging/page-size.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXVzXkBAfiXjxboe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox with Page size](./images/paging/blazor_multicolumn_combobox_page_size.gif)" %}

### Change the page count

Adjust how many page links are visible in the pager using the `PageCount` property (default is `8`). Increasing the page count shows more page links at once; decreasing it shows fewer links and may require more navigation.

To change the page count in the Blazor MultiColumn ComboBox, use the [PageCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_PageCount) property.

The following example demonstrates how to change the page count of a MultiColumn ComboBox using an external button click based on NumericTextBox input.

{% highlight cshtml %}

{% include_relative code-snippet/paging/page-count.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtrTtOrqpWjngqOp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox with Page count](./images/paging/blazor_multicolumn_combobox_page_count.gif)" %}
