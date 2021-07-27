---
layout: post
title: Disable the DateTimePicker Component in Blazor Datetime Picker Component | Syncfusion
description: Learn here all about Disable the DateTimePicker Component in Syncfusion Blazor Datetime Picker component and more.
platform: Blazor
control: Datetime Picker 
documentation: ug
---

# Disable the DateTimePicker Component in Blazor Datetime Picker Component

To disable the DateTimePicker, set its
[Enabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Calendars.SfDateTimePicker%601~Enabled.html)
property to `false`.

The following code demonstrates the disabled component.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" Enabled=false Value='@DateTimeValue'></SfDateTimePicker>

@code {
    public DateTime? DateTimeValue { get; set; } = DateTime.Now;
}
```

The output will be as follows.

![DateTimePicker](../images/disabled.png)