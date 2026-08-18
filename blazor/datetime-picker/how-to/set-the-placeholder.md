---
layout: post
title: How to set the Placeholder in Blazor DateTime Picker | Syncfusion®
description: Set the Placeholder in the Blazor DateTime Picker to display hint text in the input that guides users on the expected date and time format.
platform: Blazor
control: DateTimePicker
documentation: ug
---

# How to set the Placeholder in Blazor DateTime Picker

Use the [Placeholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateTimePicker-1.html#Syncfusion_Blazor_Calendars_SfDateTimePicker_1_Placeholder) property to display a short hint in the input that guides users before a value is selected.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" Placeholder="Choose a datetime"></SfDateTimePicker>
```

![Blazor DateTimePicker displays hint text using the Placeholder property](../images/blazor-datetimepicker-hint-element.webp)

## See also

* [Disable the Blazor DateTimePicker component](./disable-the-datetimepicker-component)
* [Open the Blazor DateTimePicker popup on focus](./open-popup-on-input-click)