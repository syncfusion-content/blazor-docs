---
layout: post
title: Disabled Items in Blazor AutoComplete Component | Syncfusion
description: Learn how to configure and manage disabled items in the Syncfusion Blazor AutoComplete component, including field mapping and dynamic enabling or disabling.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Disabled Items in Blazor AutoComplete Component

The [AutoComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html) supports marking individual items as enabled or disabled for specific scenarios. Map the disabled state by using the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteFieldSettings.html#Syncfusion_Blazor_DropDowns_AutoCompleteFieldSettings_Disabled) field in the data source via `AutoCompleteFieldSettings.Disabled`. Disabled items cannot be selected.

In the following sample, items are disabled based on the `Disabled` field value in the bound data.

{% highlight cshtml %}

{% include_relative code-snippet/disabled-items/disabled-items.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZrTZxiVzQacaXHw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Disable Item Method

The disableItem method can be used to change the disabled state of a specific item at runtime. One item can be updated per call. To update multiple items, call this method iteratively for each target item. When an item is disabled using this method, the corresponding `Disabled` field value in the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_DataSource) is updated. If the currently selected item becomes disabled, the selection is cleared.

| Parameter | Type | Description |
|------|------|------|
| itemValue | <code>string</code> \| <code>number</code> \| <code>boolean</code> \| <code>object</code> | The value of the item to enable or disable (should match the value field type of the bound data). |
| itemIndex | <code>number</code> | The zero-based index of the item to enable or disable. |

## Enabled

To disable the entire component, set the [Enabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_Enabled) property to false.

![AutoComplete component in a disabled state](./images/autocomplete-disable.png)