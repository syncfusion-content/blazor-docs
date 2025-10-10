---
layout: post
title: Customization in Blazor DateRangePicker Component | Syncfusion
description: Learn how to customize the Syncfusion Blazor DateRangePicker, including configuring the first day of the week with the FirstDayOfWeek property.
platform: Blazor
control: DateRangePicker
documentation: ug
---

# Customization in Blazor DateRangePicker Component

The DateRangePicker supports UI customization through built-in properties and events. This topic shows how to configure the first day of the week.

## First day of week

The first day of the week varies by culture, and the DateRangePicker uses the current culture’s default when not explicitly set. To override the default, use the [FirstDayOfWeek](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.DateRangePickerModel-1.html#Syncfusion_Blazor_Calendars_DateRangePickerModel_1_FirstDayOfWeek) property. Valid values are integers 0–6, corresponding to Sunday (0) through Saturday (6). For example, in en-US the default first day is Sunday; the following example sets it to Wednesday by specifying `3`.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?" Placeholder="Select a range" FirstDayOfWeek=3></SfDateRangePicker>
```

![Customization in Blazor DateRangePicker showing Wednesday as the first day of the week](./images/blazor-daterangepicker-customization.png)

N> Additional resources: The [Blazor Date Range Picker](https://www.syncfusion.com/blazor-components/blazor-daterangepicker) feature tour page provides an overview of capabilities. A live [Blazor Date Range Picker example](https://blazor.syncfusion.com/demos/daterangepicker/default-functionalities?theme=bootstrap5) demonstrates default functionalities.