---
layout: post
title: Disable the Syncfusion Blazor DateRangePicker Component | Syncfusion
description: Learn how to disable the Syncfusion Blazor DateRangePicker component using the Enabled property to prevent focus, typing, popup opening, and user selection.
platform: Blazor
control: DateRangePicker
documentation: ug
---

# Disable the Blazor DateRangePicker Component

DateRangePicker can be disabled on a page by setting the [Enabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateRangePicker-1.html#Syncfusion_Blazor_Calendars_SfDateRangePicker_1_Enabled) property to `false`. When disabled, the input cannot receive focus, typing is blocked, and the popup cannot be opened; user selection is not possible. Disabled inputs are typically excluded from form posts. The default value of `Enabled` is `true`, and this property can be data-bound to toggle the disabled state at runtime. Programmatic values (such as `StartDate` and `EndDate`) can still be set in code even when the component is disabled.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?" Enabled=false StartDate="@Start" EndDate="@End"></SfDateRangePicker>

@code {
    public DateTime? Start { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 20);
    public DateTime? End { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 25);
}
```

![Blazor DateRangePicker shown in a disabled state](../images/blazor-daterangepicker-disable-state.png)

N> You can refer to our [Blazor Date Range Picker](https://www.syncfusion.com/blazor-components/blazor-daterangepicker) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Date Range Picker example](https://blazor.syncfusion.com/demos/daterangepicker/default-functionalities?theme=bootstrap5) to understand how to present and manipulate data.