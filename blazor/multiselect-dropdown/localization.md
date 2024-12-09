---
layout: post
title: Localization in Blazor MultiSelect Dropdown Component | Syncfusion
description: Checkout and learn here all about localization in Syncfusion Blazor MultiSelect Dropdown component and more.
platform: Blazor
control: MultiSelect Dropdown
documentation: ug
---

# Globalization and Localization in Blazor MultiSelect Dropdown Component

## Localization

[Blazor MultiSelect Dropdown](https://www.syncfusion.com/blazor-components/blazor-multiselect-dropdown) component can be localized. Refer to [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) topic to localize Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components.

## Globalization

### Enable RTL mode

The direction can be switched to right to left when specfies the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListModel-2.html#Syncfusion_Blazor_DropDowns_DropDownListModel_2_EnableRtl) as `true`. Writing systems like Arabic, Hebrew, and more will require `EnableRtl` property.

Specifies the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListModel-2.html#Syncfusion_Blazor_DropDowns_DropDownListModel_2_EnableRtl) as a boolean value that indictes to enable or disable rendering component in the right to left direction. Writing systems will require Arabic, Hebrew, and more. The direction can be switched to right-to-left.

{% highlight Razor %}

{% include_relative code-snippet/localization/enableRtl-property.razor %}

{% endhighlight %} 