---
layout: post
title: Disable the DateRangePicker in Blazor | Syncfusion®
description: Disable the Blazor DateRangePicker so users cannot change the range, by setting the Enabled property to false on the component.
platform: Blazor
control: DateRangePicker
documentation: ug
---

# How to disable the DateRangePicker in Blazor DateRangePicker

The DateRangePicker can be deactivated on a page. Setting the [Enabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateRangePicker-1.html#Syncfusion_Blazor_Calendars_SfDateRangePicker_1_Enabled) property to `false` will disable the component completely from all user interactions, including form submission. The default value of the `Enabled` property is `true`. To allow users to view the value without editing it, use the `Readonly` property instead. The following sample demonstrates the disabled DateRangePicker.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?" Enabled=false StartDate="@Start" EndDate="@End"></SfDateRangePicker>

@code {
    public DateTime? Start { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 20);
    public DateTime? End { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 25);
}
```


![Disable State in Blazor DateRangePicker](../images/blazor-daterangepicker-disable-state.webp)

N> You can refer to our [Blazor Date Range Picker](https://www.syncfusion.com/blazor-components/blazor-daterangepicker) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Date Range Picker example](https://blazor.syncfusion.com/demos/daterangepicker/default-functionalities?theme=fluent2) to understand how to present and manipulate data.