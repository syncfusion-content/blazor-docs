---
layout: post
title: Set the Readonly in Blazor DatePicker Component | Syncfusion
description: Checkout and learn here all about Set the Readonly in Syncfusion Blazor DatePicker component and more.
platform: Blazor
control: DatePicker
documentation: ug
---

# Set the Readonly in Blazor DatePicker Component

## Enabled

By default, the `Enabled` property is `true`. When `Enabled` is `true`, the input can receive focus, users can type into the textbox, and the popup calendar can be opened and used to select a date. When `Enabled` is set to `false`, the input cannot be focused or edited, and the popup cannot be opened (the component is fully disabled). This property can be data-bound to toggle the disabled state at runtime.

## AllowEdit

By default, the `AllowEdit` property is `true`. When `AllowEdit` is `true`, users can type in the textbox and also select a value from the popup. When `AllowEdit` is `false`, the textbox becomes non-editable (typing is blocked), but users can still open the popup and select a value with the mouse or keyboard. Use this setting for selection-only scenarios while keeping the component interactive.

## Readonly

By default, the `Readonly` property is `false`. When `Readonly` is `false`, the input is editable and users can select a value from the popup. When `Readonly` is `true`, user input is not allowed and the popup should not be opened; the input can still receive focus for accessibility and form navigation. To enforce a fully read-only UI, set `Readonly="true"` and also disable editing with `AllowEdit="false"`.

The following code demonstrates how to set `Readonly` in the DatePicker component. This is achieved using the [Readonly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Readonly) and [AllowEdit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_AllowEdit) properties.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" AllowEdit="false" Readonly=true Value="@DateValue"></SfDatePicker>

@code {
    public DateTime? DateValue { get; set; } = DateTime.Now;
}
```

![Blazor DatePicker in read-only mode](../images/blazor-datepicker-read-only-mode.png)