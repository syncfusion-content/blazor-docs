---
layout: post
title: Open the Blazor DateRangePicker popup on Focus | Syncfusion
description: Learn how to open the Syncfusion Blazor DateRangePicker popup when the input receives focus by enabling the OpenOnFocus property.
platform: Blazor
control: DateRangePicker
documentation: ug
---

# Open the Blazor DateRangePicker popup on Focus

Open the DateRangePicker popup when the input receives focus by setting the [OpenOnFocus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateRangePicker-1.html#Syncfusion_Blazor_Calendars_SfDateRangePicker_1_OpenOnFocus) property to `true`.

The following example demonstrates how to open the DateRangePicker popup when the input is focused.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?" Placeholder="Choose a range" OpenOnFocus="true" ShowClearButton="true"></SfDateRangePicker>

```

![Opening the Blazor DateRangePicker popup when the input is focused](../images/blazor-daterangepicker-open-focus.gif)