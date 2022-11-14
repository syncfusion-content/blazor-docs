---
layout: post
title: Grouping in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Grouping in Syncfusion Blazor DropDown List component and much more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Grouping in Dropdown List

The DropDownList supports wrapping nested elements into a group based on different categories. The category of each list item can be mapped through the [GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListFieldSettings.html#Syncfusion_Blazor_DropDowns_DropDownListFieldSettings_GroupBy) field in the data table. The group header is displayed both as inline and fixed headers. The fixed group header content is updated dynamically on scrolling the popup list with its category value.

To get started quickly with grouping in the Blazor DropDown List component, you can check the video below.

{% youtube "https://www.youtube.com/watch?v=9Ouje7KEOEU" %}

In the following sample, vegetables are grouped according on its category using `GroupBy` field.

{% highlight cshtml %}

{% include_relative code-snippet/grouping/grouping.razor %}

{% endhighlight %}

![Grouping in Blazor DropdownList](./images/grouping/blazor-dropdownlist-grouping.png)

## Fixed group header

You can classify the items based on the [GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListFieldSettings.html#Syncfusion_Blazor_DropDowns_DropDownListFieldSettings_GroupBy) field mapped to the control. The headers of group items will fixed at the top till its belonging items ends up on scrolling.

## Group header template

The group header title under which appropriate sub-items are categorized can also be customize with the help of [GroupTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_GroupTemplate) property. This template is common for both inline and floating group header template.

## Limitations of grouping

Grouping feature has a certain limitations. Those are listed below.

* The component will support only single level of grouping, and you cannot specify it as like TreeView component.

* The Virtualization is not supported in the Grouping feature. Only assign fixed number of datasource items at initial rendering of the component.