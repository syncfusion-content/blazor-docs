---
layout: post
title: Grouping in Blazor ComboBox Component | Syncfusion
description: Checkout and learn here all about grouping support in Syncfusion Blazor ComboBox component, it's elements and more.
platform: Blazor
control: ComboBox
documentation: ug
---

# Grouping in Blazor ComboBox Component

The ComboBox supports wrapping of the nested elements into a group based on different categories. The category of each list item can be mapped through the [ComboBoxFieldSettings.GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ComboBoxFieldSettings.html#Syncfusion_Blazor_DropDowns_ComboBoxFieldSettings_GroupBy) field in the data table. The group header is displayed both as inline and fixed headers. The fixed group header content is updated dynamically on scrolling the popup list with its category value.

To get started quickly with grouping in the Blazor ComboBox component, you can check the video below.

{% youtube "https://www.youtube.com/watch?v=2UuJzgfbi48" %}

In the following sample, vegetables are grouped according to their category using the [ComboBoxFieldSettings.GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ComboBoxFieldSettings.html#Syncfusion_Blazor_DropDowns_ComboBoxFieldSettings_GroupBy) field.

{% highlight cshtml %}

{% include_relative code-snippet/grouping/grouping.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXrAsLhwUmUFCjYX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Grouping in Blazor ComboBox](./images/blazor-combobox-grouping.png)

## Fixed group header

Classify the items based on the [ComboBoxFieldSettings.GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ComboBoxFieldSettings.html#Syncfusion_Blazor_DropDowns_ComboBoxFieldSettings_GroupBy) field mapped to the control. The headers of group items will be fixed at the top till their belonging items ends up on scrolling.

The group header title under which appropriate sub-items are categorized is customize with the help of the [GroupTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_GroupTemplate) property. This template is common for both inline and floating group [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_HeaderTemplate).

## Limitations of grouping

Grouping feature has some limitations. These are:

* The component will support only single level of grouping, and you cannot specify it as like TreeView component.

