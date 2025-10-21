---
layout: post
title: Grouping in Blazor MultiSelect Dropdown Component | Syncfusion
description: Checkout and learn here all about grouping in Syncfusion Blazor MultiSelect Dropdown component and more.
platform: Blazor
control: MultiSelect Dropdown
documentation: ug
---

# Grouping in Blazor MultiSelect Dropdown Component

The MultiSelect supports grouping list items by category. Map the category field of each item to the [MultiSelectFieldSettings.GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectFieldSettings.html#Syncfusion_Blazor_DropDowns_MultiSelectFieldSettings_GroupBy) property. Group headers appear inline and also as fixed headers. The fixed group header updates dynamically while scrolling to reflect the current group.

To get started quickly with grouping in the Blazor MultiSelect Dropdown component, refer to the following video:

{% youtube "https://www.youtube.com/watch?v=9PRq4u-t2Yw" %}

In the following sample, vegetables are grouped by category using the `MultiSelectFieldSettings.GroupBy` field.

{% highlight cshtml %}

{% include_relative code-snippet/grouping/grouping.razor %}

{% endhighlight %}

![Grouping in Blazor MultiSelect Dropdown](./images/blazor-multiselect-dropdown-grouping.png)

## Fixed group header

Classify items by mapping a category field to [MultiSelectFieldSettings.GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectFieldSettings.html#Syncfusion_Blazor_DropDowns_MultiSelectFieldSettings_GroupBy). Group headers remain fixed at the top of the popup while scrolling through their corresponding group items and update when the next group begins.

## Group header template

Customize the group header title (used for both inline and floating headers) with the [GroupTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectModel-1.html#Syncfusion_Blazor_DropDowns_MultiSelectModel_1_GroupTemplate) property. The same template content is used for the floating group [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectModel-1.html#Syncfusion_Blazor_DropDowns_MultiSelectModel_1_HeaderTemplate).

## Limitations of grouping

Grouping has the following limitation:

* Only a single level of grouping is supported (nested or hierarchical grouping, as in TreeView, is not available).