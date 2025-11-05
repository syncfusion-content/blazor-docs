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

By default, the Enabled property is true, it specifies the input can be focused, editable, and allows you to select date from the popup. But when enabled property is false, the input is not focusable, non-editable and cannot open the popup.

## AllowEdit

By default, the AllowEdit property is true, it allows the textbox input to be changed as well as the user can select the value from the popup and false state defines the input is not editable but allows to select the value from the popup.

## Readonly

By default, the Readonly property is false, it allows the input to be editable, and also allows value selection from the popup, and the true state does not allow user input, nor does it open popup, but the input can be focused. If you want to use the property Readonly, then you must disable the AllowEdit API.

The following code demonstrates how to set `Readonly` in DatePicker component. You can achieve this by using the [Readonly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Readonly) and [AllowEdit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_AllowEdit) properties.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" AllowEdit="false" Readonly=true Value="@DateValue"></SfDatePicker>

@code {
    public DateTime? DateValue { get; set; } = DateTime.Now;
}
```



![Blazor DatePicker in Read-only Mode](../images/blazor-datepicker-read-only-mode.png)