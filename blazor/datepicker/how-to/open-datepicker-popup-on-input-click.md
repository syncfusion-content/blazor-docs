---
layout: post
title: How to open the DatePicker popup on Focus in Blazor DatePicker | Syncfusion®
description: Open the Blazor DatePicker popup automatically when the user focuses the input, with the ShowPopupOnFocus property for keyboard-only interaction.
platform: Blazor
control: DatePicker
documentation: ug
---

# Open the Blazor DatePicker popup on Focus

You can open the DatePicker popup when the input receives focus by handling the [Focus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.DatePickerEvents-1.html) event of `DatePickerEvents` and calling the `ShowPopupAsync` method.

The following example demonstrates how to open the DatePicker popup when the input is focused.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" @ref="@DateObj">
    <DatePickerEvents TValue="DateTime?" Focus="FocusHandler"></DatePickerEvents>
</SfDatePicker>

@code{
    SfDatePicker<DateTime?> DateObj;
    public async void FocusHandler(Syncfusion.Blazor.Calendars.FocusEventArgs args)    {
        await this.DateObj.ShowPopupAsync();
    }
}
```

![Opening Blazor DatePicker Popup](../images/blazor-datepicker-popup.webp)

## Open the Blazor DatePicker popup on Focus

You can also open the DatePicker popup on input focus by setting the [OpenOnFocus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_OpenOnFocus) property to `true`. The default value of `OpenOnFocus` is `false`.

The following example demonstrates how to open the DatePicker popup when the input is focused.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" Placeholder="Choose a Date" OpenOnFocus="true" FullScreen="true" ShowClearButton="true"></SfDatePicker>

```

![Opening Blazor DatePicker Popup](../images/blazor-datepicker-open-focus.gif)
