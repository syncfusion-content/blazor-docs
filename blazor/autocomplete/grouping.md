---
layout: post
title: Grouping in Blazor AutoComplete Component | Syncfusion
description: Learn how to group items in the Syncfusion Blazor AutoComplete component using the GroupBy field, fixed group headers, and group header templates.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Grouping in Blazor AutoComplete Component

The [AutoComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html) supports grouping list items by category. Map the category field using [AutoCompleteFieldSettings.GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteFieldSettings.html#Syncfusion_Blazor_DropDowns_AutoCompleteFieldSettings_GroupBy). Group headers are shown both inline and as fixed headers. The fixed header updates dynamically while scrolling the suggestion list to reflect the current group.

To get started quickly with grouping in the Blazor AutoComplete component, see the following video.

{% youtube "https://www.youtube.com/watch?v=XtqNSV0B3h8" %}

In the following sample, vegetables are grouped by category using the `AutoCompleteFieldSettings.GroupBy` field.

{% highlight cshtml %}

{% include_relative code-snippet/grouping/grouping.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNhqMhMfLJxZyQGD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor AutoComplete Grouping](./images/blazor-autocomplete-grouping.png)

## Fixed group header

Classify items based on the [AutoCompleteFieldSettings.GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteFieldSettings.html#Syncfusion_Blazor_DropDowns_AutoCompleteFieldSettings_GroupBy) field mapped to the component. Group headers remain fixed at the top while scrolling until all items in the current group have scrolled out of view.

## Group header template

Customize the group header title using the [GroupTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_GroupTemplate) property. This template applies to both inline and floating group headers. The floating header can also be customized with the [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_HeaderTemplate) property.

## Limitations of grouping

The grouping feature has the following limitation:

* Only a single level of grouping is supported; hierarchical (multi-level) grouping like in the TreeView component is not supported.