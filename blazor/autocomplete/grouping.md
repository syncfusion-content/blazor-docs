---
layout: post
title: Grouping in Blazor AutoComplete Component | Syncfusion
description: Checkout and learn here all about Grouping in Syncfusion Blazor AutoComplete component and much more.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Grouping in Blazor AutoComplete Component

The [AutoComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html) supports wrapping nested elements into a group based on different categories. The category of each list item can be mapped through the [AutoCompleteFieldSettings.GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteFieldSettings.html#Syncfusion_Blazor_DropDowns_AutoCompleteFieldSettings_GroupBy) field in the data table. The group header is displayed as both inline and fixed headers. The fixed group header content is updated dynamically on scrolling the suggestion list with its category value.

To get started quickly with grouping in the Blazor AutoComplete component, you can check the video below.

{% youtube "https://www.youtube.com/watch?v=XtqNSV0B3h8" %}

In the following sample, vegetables are grouped according to their category using the `AutoCompleteFieldSettings.GroupBy` field.

{% highlight cshtml %}

{% include_relative code-snippet/grouping/grouping.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNhqMhMfLJxZyQGD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor AutoComplete Grouping](./images/blazor-autocomplete-grouping.png)

## Fixed group header

Classify the items based on the [AutoCompleteFieldSettings.GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteFieldSettings.html#Syncfusion_Blazor_DropDowns_AutoCompleteFieldSettings_GroupBy) field mapped to the component. The headers of group items will be fixed at the top till their belonging items ends up on scrolling.

## Group header template

The group header title under which appropriate sub-items are categorized is customize with the help of the [GroupTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_GroupTemplate) property. This template is common for both inline and floating group [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_HeaderTemplate).

## Limitations of grouping

Grouping feature has some limitations. These are:

* The component will support only single level of grouping, and you cannot specify it as like TreeView component.
