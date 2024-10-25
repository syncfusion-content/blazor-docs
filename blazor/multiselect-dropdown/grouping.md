---
layout: post
title: Grouping in Blazor MultiSelect Dropdown Component | Syncfusion
description: Checkout and learn here all about grouping in Syncfusion Blazor MultiSelect Dropdown component and more.
platform: Blazor
control: MultiSelect Dropdown
documentation: ug
---

# Grouping in Blazor MultiSelect Dropdown Component

The MultiSelect supports wrapping of the nested elements into a group based on different categories. The category of each list item can be mapped through the [MultiSelectFieldSettings.GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectFieldSettings.html#Syncfusion_Blazor_DropDowns_MultiSelectFieldSettings_GroupBy) field in the data table. The group header is displayed both as inline and fixed headers. The fixed group header content is updated dynamically on scrolling the popup list with its category value.

To get started quickly with grouping in the Blazor MultiSelect Dropdown component, you can check the video below.

{% youtube "https://www.youtube.com/watch?v=9PRq4u-t2Yw" %}

In the following sample, vegetables are grouped according to their category using the `MultiSelectFieldSettings.GroupBy` field.

{% highlight cshtml %}

{% include_relative code-snippet/grouping/grouping.razor %}

{% endhighlight %}

![Grouping in Blazor MultiSelect DropDown](./images/blazor-multiselect-dropdown-grouping.png)

## Fixed group header

Classify the items based on the [MultiSelectFieldSettings.GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectFieldSettings.html#Syncfusion_Blazor_DropDowns_MultiSelectFieldSettings_GroupBy) field mapped to the control. The headers of group items will be fixed at the top till their belonging items ends up on scrolling.

## Group header template

The group header title under which appropriate sub-items are categorized is customize with the help of the [GroupTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectModel-1.html#Syncfusion_Blazor_DropDowns_MultiSelectModel_1_GroupTemplate) property. This template is common for both inline and floating group [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectModel-1.html#Syncfusion_Blazor_DropDowns_MultiSelectModel_1_HeaderTemplate).

## Limitations of grouping

Grouping feature has some limitations. These are:

* The component will support only single level of grouping, and you cannot specify it as like TreeView component.