---
layout: post
title: Open the Blazor DatePicker popup on Focus | Syncfusion
description: Learn here all about opening the Syncfusion Blazor DatePicker popup upon focusing input and much more.
platform: Blazor
control: DatePicker
documentation: ug
---

# Open the Blazor DatePicker popup on Focus

Open the DatePicker popup when the input receives focus. This can be done by calling `ShowPopupAsync` from the input’s focus event, or by enabling the built-in `OpenOnFocus` property as shown below.

The DatePicker popup can be opened on input focus by calling the [`ShowPopupAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_ShowPopupAsync) method in the input `focus` event.

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

![Opening the Blazor DatePicker popup on input focus via Focus event](../images/blazor-datepicker-popup.png)

## Open the Blazor DatePicker popup on Focus

The DatePicker popup can also be opened on input focus by setting the [OpenOnFocus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_OpenOnFocus) property to `true`. This is the built-in option and does not require handling the focus event manually.

The following example demonstrates how to open the DatePicker popup when the input is focused.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" Placeholder="Choose a Date" OpenOnFocus="true" FullScreen="true" ShowClearButton="true"></SfDatePicker>
```

![Opening the Blazor DatePicker popup using the OpenOnFocus property](../images/blazor-datepicker-open-focus.gif)