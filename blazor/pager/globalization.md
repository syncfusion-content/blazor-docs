---
layout: post
title: Globalization in Blazor Pager Component | Syncfusion
description: Checkout and learn here all about globalization and RTL in Syncfusion Blazor Pager component and much more details.
platform: Blazor
control: Pager
documentation: ug
---

# Globalization in Blazor Pager Component

## Localization

Blazor Pager component can be localized. Refer to [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) topic to localize Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components.

## Right to left (RTL)

RTL provides an option to switch the text direction and layout of the Pager component from right to left. It improves the user experiences and accessibility for users who use right-to-left languages (Arabic, Farsi, Urdu, etc.). In the following sample, [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_EnableRtl) property is used to enable RTL in the Pager.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfPager TotalItemsCount=20 NumericItemsCount=5 PageSize=5 EnableRtl=true></SfPager>
```