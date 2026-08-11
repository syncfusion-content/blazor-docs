---
layout: post
title: How to open the popup on focus in Blazor TimePicker | Syncfusion
description: Open the Blazor TimePicker popup automatically when the input receives focus using OpenOnFocus.
platform: Blazor
control: TimePicker
documentation: ug
---

# How to open the popup on focus in Blazor TimePicker

You can open the TimePicker popup on input focus by setting the [OpenOnFocus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfTimePicker-1.html#Syncfusion_Blazor_Calendars_SfTimePicker_1_OpenOnFocus) property to `true`.

The following example demonstrates how to open the TimePicker popup when the input is focused.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfTimePicker TValue="DateTime?" FullScreen="true" OpenOnFocus="true" ShowClearButton="true"></SfTimePicker>

```

![Opening Blazor TimePicker Popup](../images/blazor-timepicker-open-focus.gif)

## See also

* [Events in Blazor TimePicker](../events)
* [Data Binding in Blazor TimePicker](../data-binding)
* [Style and appearance in Blazor TimePicker](../style-appearance)



