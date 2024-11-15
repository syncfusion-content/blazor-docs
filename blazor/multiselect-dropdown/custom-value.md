---
layout: post
title: Custom Value in Blazor MultiSelect Dropdown Component | Syncfusion
description: Checkout and learn here all about custom value in Syncfusion Blazor MultiSelect Dropdown component and more.
platform: Blazor
control: MultiSelect Dropdown
documentation: ug
---

# Custom Value in Blazor MultiSelect Dropdown Component

The MultiSelect allows the user to select and tag the typed custom value that is not present in the data source when you set the [AllowCustomValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMultiSelect-2.html#Syncfusion_Blazor_DropDowns_SfMultiSelect_2_AllowCustomValue) as true. The selected custom value is added to the suggestion list alone. It will not affect the original data source. The `CustomValueSpecifier` event will trigger when you select or tag the typed custom value.

N> The `Value` field, `Text` field, and `Value` property must be of `string` type when you enable the custom value. For other types, you must provide the custom data for the typed custom value in the `CustomValueSpecifier` event. Find the details on [Value as non-string type](https://blazor.syncfusion.com/documentation/multiselect-dropdown/custom-value#value-as-non-string-type) section. 

{% highlight cshtml %}

{% include_relative code-snippet/custom-value/custom-value.razor %}

{% endhighlight %}

![Blazor MultiSelect DropDown with Custom Value](./images/blazor-multiselect-dropdown-custom-value.png)

## Value as non-string type

By default, the typed custom value is updated to both the Value and Text field of the custom data. If the TValue type is a non-`string` type, then you have to provide the custom data for the typed custom value in the `CustomValueSpecifier` event.

In the `CustomValueSpecifier` event, you will get the typed custom value in the `Text` argument of the event. Based on that text value, you should form the data for the custom value and set it to the `NewData` argument of the event.

The following sample demonstrates configuration of custom value in `CustomValueSpecifier` event.

{% highlight cshtml %}

{% include_relative code-snippet/custom-value/custom-value-non-string.razor %}

{% endhighlight %}

## Limitation in Checkbox mode 

The MultiSelect component supports adding custom values in various modes, including `Default`, `Box`, and `Delimiter`. However, in `Checkbox` mode, the input element is non-editable, preventing the addition of custom values. This limitation is due to the specific functionality of Checkbox mode, where the parent input field remains read-only. As a result, entering custom values is not supported in Checkbox mode, which is the default behavior of the component.

