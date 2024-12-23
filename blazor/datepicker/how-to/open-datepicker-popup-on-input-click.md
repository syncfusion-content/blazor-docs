---
layout: post
title: Open the Blazor DatePicker popup on Focus | Syncfusion
description: Learn here all about opening the Syncfusion Blazor DatePicker popup upon focusing input and much more.
platform: Blazor
control: DatePicker
documentation: ug
---

# Open the Blazor DatePicker popup on Focus

You can open the DatePicker popup on input focus by calling the `ShowPopupAsync` method in the input `focus` event.

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

![Opening Blazor DatePicker Popup](../images/blazor-datepicker-popup.png)

## Open the Blazor DatePicker popup on Focus


You can also open the DatePicker popup on input focus by setting the [OpenOnFocus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_OpenOnFocus) property to true.

The following example demonstrates how to open the DatePicker popup when the input is focused.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" Placeholder="Choose a Date" OpenOnFocus="true" FullScreen="true" ShowClearButton="true"></SfDatePicker>

```

![Opening Blazor DatePicker Popup](../images/blazor-datepicker-open-focus.gif)

