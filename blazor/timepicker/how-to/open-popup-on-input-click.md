---
layout: post
title: Open the Blazor TimePicker Picker popup on Focus | Syncfusion
description: Learn here all about opening the Syncfusion Blazor TimePicker Picker popup upon focusing input and much more.
platform: Blazor
control: TimePicker
documentation: ug
---

# Open the Blazor TimePicker Picker popup on Focus

You can also open the TimePicker Picker popup on input focus by setting the [OpenOnFocus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfTimePicker-1.html#Syncfusion_Blazor_Calendars_SfTimePicker_1_OpenOnFocus) property to true.

The following example demonstrates how to open the TimePicker Picker popup when the input is focused.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfTimePicker TValue="DateTime?" FullScreen="true" OpenOnFocus="true" ShowClearButton="true"></SfTimePicker>

```
![Opening Blazor TimePicker Picker Popup](../images/blazor-timepicker-open-focus.gif)



