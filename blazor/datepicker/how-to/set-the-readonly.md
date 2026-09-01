---
layout: post
title: How to set the Readonly in Blazor DatePicker | Syncfusion®
description: Set the Blazor DatePicker as read-only so users can view the selected date without editing it, by using the Readonly property.
platform: Blazor
control: DatePicker
documentation: ug
---

# How to set the Readonly in Blazor DatePicker

The DatePicker component exposes three related properties that control user interaction: [Enabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Enabled), [AllowEdit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_AllowEdit), and [Readonly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Readonly). Together they determine whether the input can be focused, edited, and whether the popup can be opened.

## Enabled

By default, the [Enabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Enabled) property is `true`. When enabled, the input can be focused and edited, and the popup can be opened to select a date. When set to `false`, the input is not focusable, is non-editable, and cannot open the popup.

## AllowEdit

By default, the [AllowEdit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_AllowEdit) property is `true`, which allows the textbox input to be changed directly and also lets the user select a value from the popup. When set to `false`, the input is not editable but the user can still select a value from the popup.

## Readonly

By default, the [Readonly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Readonly) property is `false`, which allows the input to be edited and the value to be selected from the popup. When set to `true`, user input is not allowed and the popup will not open, but the input can still receive focus. To use the `Readonly` property, you must also disable the `AllowEdit` property.

The following example demonstrates how to set `Readonly` in the DatePicker component by using the [Readonly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Readonly) and [AllowEdit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_AllowEdit) properties.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" AllowEdit="false" Readonly="true" Value="@DateValue"></SfDatePicker>

@code {
    public DateTime? DateValue { get; set; } = DateTime.Now;
}
```

![Blazor DatePicker in Read-only Mode](../images/blazor-datepicker-read-only-mode.webp)