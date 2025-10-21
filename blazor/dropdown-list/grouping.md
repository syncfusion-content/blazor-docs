---
layout: post
title: Grouping in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Grouping in Syncfusion Blazor DropDown List component and much more.
platform: Blazor
control: DropDownList
documentation: ug
---

# Grouping in Dropdown List

The DropDownList supports grouping items by category using a field from the data source. Assign the category field through the [DropDownListFieldSettings.GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListFieldSettings.html#Syncfusion_Blazor_DropDowns_DropDownListFieldSettings_GroupBy) property. Group headers are shown both inline and as fixed (floating) headers. While scrolling the popup list, the fixed group header updates dynamically to reflect the current group.

To get started quickly with grouping in the Blazor DropDown List component, you can check the video below.

{% youtube "https://www.youtube.com/watch?v=9Ouje7KEOEU" %}

In the following sample, vegetables are grouped according to their category using the `DropDownListFieldSettings.GroupBy` field.

{% highlight cshtml %}

{% include_relative code-snippet/grouping/grouping.razor %}

{% endhighlight %}

![Grouping in Blazor DropDownList](./images/grouping/blazor-dropdownlist-grouping.png)

## Fixed group header

Classify items based on the [DropDownListFieldSettings.GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListFieldSettings.html#Syncfusion_Blazor_DropDowns_DropDownListFieldSettings_GroupBy) field mapped to the control. The headers of grouped items remain fixed at the top while their corresponding items are in view and update as the list is scrolled.

## Group header template

Customize the group header title under which sub-items are categorized by using the [GroupTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_GroupTemplate) property. This template is applied to both inline group headers and the floating group [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_HeaderTemplate).

## Limitations of grouping

Grouping has the following limitation:

* The component supports only a single level of grouping; hierarchical grouping like the TreeView component is not supported.