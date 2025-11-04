---
layout: post
title: Open the Blazor Datetime Picker popup on Focus | Syncfusion
description: Learn here all about opening the Syncfusion Blazor Datetime Picker popup upon focusing input and much more.
platform: Blazor
control: Datetime Picker 
documentation: ug
---

# Open the Blazor Datetime Picker popup on Focus

You can also open the Datetime Picker popup on input focus by setting the [OpenOnFocus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateTimePicker-1.html#Syncfusion_Blazor_Calendars_SfDateTimePicker_1_OpenOnFocus) property to true.

The following example demonstrates how to open the Datetime Picker popup when the input is focused.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?"  OpenOnFocus="true" ShowClearButton="true"></SfDateTimePicker>

```
![Opening Blazor Datetime Picker Popup](../images/blazor-datetimepicker-open-focus.gif)


