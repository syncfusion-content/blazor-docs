---
layout: post
title: Open the Blazor DatePicker popup on Focus | Syncfusion
description: Learn here all about opening the Syncfusion Blazor DatePicker popup upon focusing input and much more.
platform: Blazor
control: DatePicker
documentation: ug
---

# Open the Blazor DatePicker popup on Focus

You can open the DatePicker popup on input focus by calling the `show` method in the input `focus` event.

The following example demonstrates how to open the DatePicker popup when the input is focused.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" @ref="@DateObj">
    <DatePickerEvents TValue="DateTime?" Focus="FocusHandler"></DatePickerEvents>
</SfDatePicker>

@code{
    SfDatePicker<DateTime?> DateObj;
    public void FocusHandler(Syncfusion.Blazor.Calendars.FocusEventArgs args)    {
        this.DateObj.ShowAsync();
    }
}
```


![Opening Blazor DatePicker Popup](../images/blazor-datepicker-popup.png)