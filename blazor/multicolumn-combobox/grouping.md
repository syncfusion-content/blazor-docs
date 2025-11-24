---
layout: post
title: Grouping in Syncfusion Blazor MultiColumn ComboBox
description: Checkout and learn here all about grouping support in Syncfusion Blazor MultiColumn ComboBox component, it's elements and more.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Grouping in Blazor MultiColumn ComboBox Component

The MultiColumn ComboBox supports wrapping of the nested elements into a group based on different categories. The category of each list item can be mapped through the [GroupByField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_GroupByField) field in the data table. 

In the following sample, the product names are grouped according to their category using the [GroupByField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_GroupByField) field.

{% highlight cshtml %}

{% include_relative code-snippet/grouping/grouping.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXLftOhUpZaoRSjs?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox with Grouping](./images/grouping/blazor_multicolumn_combobox_grouping.gif)" %}
