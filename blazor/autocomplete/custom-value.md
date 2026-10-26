---
layout: post
title: Custom Value in Blazor AutoComplete | Syncfusion®
description: Allow users to enter and submit values not present in the Blazor AutoComplete data source using the AllowCustom property, or restrict to data items only.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Custom Value in Blazor AutoComplete

The AutoComplete supports entering custom values that are not present in the predefined data set. This behavior is controlled by the [AllowCustom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteModel.html#Syncfusion_Blazor_DropDowns_AutoCompleteModel_AllowCustom) property, which is enabled by default. When enabled, a user-entered custom value is accepted and submitted with the form during postback. To restrict input to only the items in the data source, set `AllowCustom="false"`.

{% highlight Razor %}

{% include_relative code-snippet/custom-value/custom-value-enable.razor %}

{% endhighlight %}