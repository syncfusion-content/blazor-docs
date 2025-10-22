---
layout: post
title: Disabled Items in Blazor DropDownList Component | Syncfusion
description: Checkout and learn here all about Disabled Items in Syncfusion Blazor DropDownList component and much more.
platform: Blazor
control: DropDownList
documentation: ug
---

# Disabled Items in Blazor DropDownList Component

The [DropDownList](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html) supports disabling individual items for scenario-specific control. Map a boolean field in your data model to the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListFieldSettings.html#Syncfusion_Blazor_DropDowns_DropDownListFieldSettings_Disabled) property of the field settings to render items as non-interactive. Disabled items cannot be selected or focused through keyboard navigation.

In the following sample, items are rendered as disabled based on the value of the `Disabled` field.

{% highlight cshtml %}

{% include_relative code-snippet/disabled-items/disabled-items.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtVfZRsLzvcQPnwt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Disable Item Method

Use the disable item API to change the disabled state of an item at runtime (for example, in response to user actions or data changes). This method updates the disabled state for a single item; iterate your item set to disable multiple entries. If the currently selected item is disabled dynamically, the selection is cleared automatically. The underlying [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_DataSource) should also reflect the updated disabled state to keep UI and data in sync.

| Parameter | Type | Description |
|------|------|------|
| itemValue | <code>string</code> \| <code>number</code> \| <code>boolean</code> \| <code>object</code> | The value of the item to disable. |
| itemIndex | <code>number</code> | The zero-based index of the item to disable. |

## Enabled

If you want to disabled the overall component to set the [Enabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_Enabled) property to false.

![Disabled DropDownList Component](./images/dropdownlist-disable.png)
