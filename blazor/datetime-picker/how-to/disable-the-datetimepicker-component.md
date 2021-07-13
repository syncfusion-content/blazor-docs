# Disable the component

To disable the DateTimePicker, set its
[Enabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Calendars.SfDateTimePicker%601~Enabled.html)
property to `false`.

The following code demonstrates the disabled component.

```csharp
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" Enabled=false Value='@DateTimeValue'></SfDateTimePicker>

@code {
    public DateTime? DateTimeValue { get; set; } = DateTime.Now;
}
```

The output will be as follows.

![DateTimePicker](../images/disabled.png)
