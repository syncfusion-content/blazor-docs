---
layout: post
title: How to Disable The Datetimepicker Component in Blazor Datetime Picker  Component | Syncfusion
description: Checkout and learn about Disable The Datetimepicker Component in Blazor Datetime Picker  component of Syncfusion, and more details.
platform: Blazor
control: Datetime Picker 
documentation: ug
---

# Disable the component

To disable the DateTimePicker, set its
[Enabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Calendars.SfDateTimePicker%601~Enabled.html)
property to `false`.

The following code demonstrates the disabled component.

```csharp
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" Enabled=false Value='@DateTimeValue'></SfDateTimePicker>

@code {
    public DateTime? DateTimeValue { get; set; } = DateTime.Now;
}
```

The output will be as follows.

![DateTimePicker](../images/disabled.png)
