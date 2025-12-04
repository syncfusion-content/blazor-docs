---
layout: post
title: Localization in Blazor MultiSelect Dropdown Component | Syncfusion
description: Checkout and learn here all about localization in Syncfusion Blazor MultiSelect Dropdown component and more.
platform: Blazor
control: MultiSelect Dropdown
documentation: ug
---

# Globalization and Localization in Multiselect Dropdown

## Localization

The [Blazor MultiSelect Dropdown](https://www.syncfusion.com/blazor-components/blazor-multiselect-dropdown) supports localization of built-in UI text (for example, select all, no records, clear). Refer to the [Blazor localization](https://blazor.syncfusion.com/documentation/common/localization) documentation to configure culture files and resource keys for Syncfusion components.
## Globalization

### Enable right-to-left (RTL) mode

The direction can be switched to right to left when specifies the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListModel-2.html#Syncfusion_Blazor_DropDowns_DropDownListModel_2_EnableRtl) as `true`. Writing systems like Arabic, Hebrew, and more will require `EnableRtl` property.

Specifies the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListModel-2.html#Syncfusion_Blazor_DropDowns_DropDownListModel_2_EnableRtl) as a boolean value that indicts to enable or disable rendering component in the right to left direction. Writing systems will require Arabic, Hebrew, and more. The direction can be switched to right-to-left.

{% highlight Razor %}

{% include_relative code-snippet/localization/enableRtl-property.razor %}

{% endhighlight %}