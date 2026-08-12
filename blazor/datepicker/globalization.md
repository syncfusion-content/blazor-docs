---
layout: post
title: Globalization in Blazor DatePicker Component | Syncfusion®
description: Checkout and learn here all the features about globalization support in Blazor DatePicker component, it's elements and more.
platform: Blazor
control: DatePicker
documentation: ug
---

# Globalization in Blazor DatePicker Component


The [Blazor DatePicker](https://www.syncfusion.com/blazor-components/blazor-datepicker) component can be localized. Refer to the [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) topic to localize Blazor components.


## Right-To-Left

The DatePicker supports RTL (right-to-left) functionality for languages like Arabic and Hebrew. Use the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.DatePickerModel.html#Syncfusion_Blazor_Calendars_DatePickerModel_EnableRtl) property to set the RTL direction. The component renders based on the system culture.

The following code example initializes the DatePicker component in RTL mode.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" EnableRtl=true></SfDatePicker>
```

![Right to Left in Blazor DatePicker](./images/blazor-datepicker-right-to-left.webp)

## See also

* [Blazor Localization](../common/localization)
* [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_EnableRtl) property
* [Date Format](date-format)