# Open the DatePicker popup upon focusing input of DatePicker

You can open the DatePicker popup on input focus by calling the `show` method in the input `focus` event.

The following example demonstrates how to open the DatePicker popup when the input is focused.

```csharp
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

The output will be as follows.

![datepicker](../images/openpopup.png)
