---
layout: post
title: Localization in Blazor DropDownList Component | Syncfusion
description: Checkout and learn here all about Localization in Syncfusion Blazor DropDown List component and more.
platform: Blazor
control: DropDownList
documentation: ug
---

# Globalization and Localization in Dropdown List

## Localization

The [Blazor DropDownList](https://www.syncfusion.com/blazor-components/blazor-dropdown-list) component supports localization of UI text and messages. Refer to the [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) documentation for configuring culture, resource files, and translations across Syncfusion components.

## Globalization

### Enable RTL mode

The direction can be switched to right to left when specifies the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListModel-2.html#Syncfusion_Blazor_DropDowns_DropDownListModel_2_EnableRtl) as `true`. Writing systems like Arabic, Hebrew, and more will require `EnableRtl` property.

Specifies the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListModel-2.html#Syncfusion_Blazor_DropDowns_DropDownListModel_2_EnableRtl) as a boolean value that indicates to enable or disable rendering component in the right to left direction. Writing systems will require Arabic, Hebrew, and more. The direction can be switched to right-to-left.

{% highlight cshtml %}

{% include_relative code-snippet/localization/enableRtl.razor %}

{% endhighlight %}

![Blazor DropDownList rendered in RTL mode](./images/localization/blazor_dropdown_enableRtl.png)