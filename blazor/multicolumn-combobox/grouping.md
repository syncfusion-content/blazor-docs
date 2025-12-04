---
layout: post
title: Grouping in Syncfusion Blazor MultiColumn ComboBox
description: Checkout and learn here all about grouping support in Syncfusion Blazor MultiColumn ComboBox component, it's elements and more.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Grouping in Blazor MultiColumn ComboBox Component

The Blazor MultiColumn ComboBox supports grouping items by a specified category. Use the [GroupByField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_GroupByField) property to map the data field that provides the group key for each item.

In the following example, product names are grouped by their category using the `GroupByField` property.

{% highlight cshtml %}

{% include_relative code-snippet/grouping/grouping.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXLftOhUpZaoRSjs?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox with Grouping](./images/grouping/blazor_multicolumn_combobox_grouping.gif)" %}
