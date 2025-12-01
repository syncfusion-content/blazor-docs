---
layout: post
title: Grouping in Blazor ComboBox Component | Syncfusion
description: Checkout and learn here all about grouping support in Syncfusion Blazor ComboBox component, it's elements and more.
platform: Blazor
control: ComboBox
documentation: ug
---

# Grouping in Blazor ComboBox Component

The ComboBox supports grouping items by a category field in the data source. Map the category of each list item using the [ComboBoxFieldSettings.GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ComboBoxFieldSettings.html#Syncfusion_Blazor_DropDowns_ComboBoxFieldSettings_GroupBy) field. Group headers are shown inline and as a fixed (floating) header. The fixed group header updates dynamically while scrolling the popup list to reflect the current group in view.

To get started quickly with grouping in the Blazor ComboBox component, you can check the video below.

{% youtube "https://www.youtube.com/watch?v=2UuJzgfbi48" %}

In the following sample, vegetables are grouped according to their category using the [ComboBoxFieldSettings.GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ComboBoxFieldSettings.html#Syncfusion_Blazor_DropDowns_ComboBoxFieldSettings_GroupBy) field.

{% highlight cshtml %}

{% include_relative code-snippet/grouping/grouping.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXrAsLhwUmUFCjYX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Grouping in Blazor ComboBox](./images/blazor-combobox-grouping.png)" %}

## Fixed group header

Classify items by mapping the [ComboBoxFieldSettings.GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ComboBoxFieldSettings.html#Syncfusion_Blazor_DropDowns_ComboBoxFieldSettings_GroupBy) field. The headers for grouped items remain fixed at the top of the popup while scrolling, until the last item in that group passes out of view.

The group header text, under which the corresponding sub-items are categorized, can be customized using the [GroupTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_GroupTemplate) property. This template applies to both the inline group headers and the floating (fixed) group [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_HeaderTemplate).
## Limitations of grouping

Grouping has the following limitations:

* Only a single level of grouping is supported; hierarchical grouping (as in a TreeView) is not available.
* Group headers are non-selectable and used for visual categorization only.