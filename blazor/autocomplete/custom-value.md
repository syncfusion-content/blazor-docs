---
layout: post
title: Custom value in Blazor AutoComplete Component | Syncfusion
description: Learn how to enable or disable custom values in the Syncfusion Blazor AutoComplete component using the AllowCustom property.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Custom value enable and disable

The AutoComplete supports entering custom values that are not present in the predefined data set. This behavior is controlled by the [AllowCustom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteModel.html#Syncfusion_Blazor_DropDowns_AutoCompleteModel_AllowCustom) property, which is enabled by default. When enabled, a user-entered custom value is accepted and submitted with the form during postback. To restrict input to only the items in the data source, set `AllowCustom="false"`.

{% highlight Razor %}

{% include_relative code-snippet/custom-value/custom-value-enable.razor %}

{% endhighlight %}