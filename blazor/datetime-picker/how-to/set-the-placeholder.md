---
layout: post
title: Set the Placeholder in Blazor DateTimePicker Component | Syncfusion
description: Learn how to set the Placeholder in the Syncfusion Blazor DateTimePicker component to display hint text in the input.
platform: Blazor
control: DateTimePicker 
documentation: ug
---

# Set the Placeholder in Blazor DateTimePicker Component

The following example demonstrates how to set the `Placeholder` in the DateTimePicker component.

Using the [Placeholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateTimePicker-1.html#Syncfusion_Blazor_Calendars_SfDateTimePicker_1_Placeholder) property, a short hint can be displayed in the input element to guide users before a value is selected.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" Placeholder="Choose a datetime"></SfDateTimePicker>
```

![Blazor DateTimePicker displays hint text using the Placeholder property](../images/blazor-datetimepicker-hint-element.png)