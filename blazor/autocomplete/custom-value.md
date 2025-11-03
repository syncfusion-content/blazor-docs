---
layout: post
title: Custom value in Blazor AutoComplete Component | Syncfusion
description: Learn how to enable or disable custom values in the Syncfusion Blazor AutoComplete using the AllowCustom property.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Custom value enable and disable

The AutoComplete allows users to enter values that are not present in the predefined list. By default, this behavior is enabled by the [AllowCustom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteModel.html#Syncfusion_Blazor_DropDowns_AutoCompleteModel_AllowCustom) property.

When a form is submitted, the custom value is included as the input value. To restrict input to the provided list, set `AllowCustom="false"`.

When `AllowCustom="false"`, non-matching user input will not be accepted.

{% highlight Razor %}

{% include_relative code-snippet/custom-value/custom-value-enable.razor %}

{% endhighlight %}

