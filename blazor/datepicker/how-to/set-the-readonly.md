---
layout: post
title: Set the Readonly in Blazor DatePicker Component | Syncfusion
description: Checkout and learn here all about Set the Readonly in Syncfusion Blazor DatePicker component and more.
platform: Blazor
control: DatePicker
documentation: ug
---

# Set the Readonly in Blazor DatePicker Component

This article describes how the DatePicker properties Readonly, AllowEdit, and Enabled control end-user interaction, including typing in the input, opening the popup calendar, and overall interactivity. A comparison and example are provided.

## Enabled

By default, the `Enabled` property is `true`. When `Enabled` is `true`, the input can receive focus, text entry is allowed (subject to `AllowEdit`), and the popup calendar can be opened and used to select a date. When `Enabled` is set to `false`, the component is fully disabled: the input cannot be focused or edited, and the popup cannot be opened. This property can be data-bound to toggle the disabled state at runtime.

- API reference: [Enabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Enabled)

## AllowEdit

By default, the `AllowEdit` property is `true`. When `AllowEdit` is `true`, the input accepts typing and a value can also be selected from the popup. When `AllowEdit` is `false`, typing in the textbox is blocked, but the popup can still be opened to select a value with the mouse or keyboard. This setting is suitable for selection-only scenarios while keeping the component interactive.

- API reference: [AllowEdit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_AllowEdit)

## Readonly

By default, the `Readonly` property is `false`. When `Readonly` is `true`, user-initiated value changes are prevented. The input remains focusable for accessibility and form navigation, but editing is blocked and the popup is not interactive for changing the value. To present a fully read-only UI surface (no typing and no date selection), set `Readonly="true"` and also set `AllowEdit="false"`.

- API reference: [Readonly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Readonly)

The following code demonstrates how to configure the DatePicker for read-only display by combining `Readonly` and `AllowEdit`.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?"
              Value="@DateValue"
              Enabled="true"
              AllowEdit="false"
              Readonly="true">
</SfDatePicker>

@code {
    public DateTime? DateValue { get; set; } = DateTime.Now;
}
```

![Blazor DatePicker in read-only mode](../images/blazor-datepicker-read-only-mode.png)
