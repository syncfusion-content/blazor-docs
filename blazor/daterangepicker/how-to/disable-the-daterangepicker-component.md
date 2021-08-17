---
layout: post
title: Disable the Syncfusion Blazor DateRangePicker Component | Syncfusion
description: Checkout and learn here all about disabling the Syncfusion Blazor DateRangePicker Component and much more.
platform: Blazor
control: DateRangePicker
documentation: ug
---

# Disable the Blazor DateRangePicker Component

DateRangePicker can be inactivated on a page. By setting [Enabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateRangePicker.html#Syncfusion_Blazor_Calendars_SfDateRangePicker_Enabled) value to false will disable the component completely from all the user interactions including in the form post. The following code demonstrates the disabled component.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?" Enabled=false StartDate="@Start" EndDate="@End"></SfDateRangePicker>

@code {
    public DateTime? Start { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 20);
    public DateTime? End { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 25);
}
```

The output will be as follows.

![Disable State in Blazor DateRangePicker](../images/blazor-daterangepicker-disable-state.png)

> You can refer to our [Blazor Date Range Picker](https://www.syncfusion.com/blazor-components/blazor-daterangepicker) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Date Range Picker example](https://blazor.syncfusion.com/demos/daterangepicker/default-functionalities?theme=bootstrap4) to understand how to present and manipulate data.