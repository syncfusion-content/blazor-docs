---
layout: post
title: How to set the Placeholder in Blazor DateTime Picker | Syncfusion®
description: Set the Placeholder in the Blazor DateTime Picker to display hint text in the input that guides users on the expected date and time format.
platform: Blazor
control: DateTimePicker
documentation: ug
---

# How to set the Placeholder in Blazor DateTime Picker

The following example demonstrates how to set the `Placeholder` in the DateTimePicker component.

Using the [Placeholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateTimePicker-1.html#Syncfusion_Blazor_Calendars_SfDateTimePicker_1_Placeholder) property, a short hint can be displayed in the input element to guide users before a value is selected.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" Placeholder="Choose a datetime"></SfDateTimePicker>
```

![Blazor DateTimePicker displays hint text using the Placeholder property](../images/blazor-datetimepicker-hint-element.webp)