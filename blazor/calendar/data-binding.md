---
layout: post
title: Data Binding in Blazor Calendar Component | Syncfusion
description: Checkout and learn here all about Data Binding in Syncfusion Blazor Calendar component and much more.
platform: Blazor
control: Calendar
documentation: ug
---

# Data Binding in Blazor Calendar Component

This section briefly explains how to bind the value to the Calendar component in the below different ways.

* One-Way Data Binding
* Two-Way Data Binding
* Dynamic Value Binding

## One-Way Binding

You can bind the value to the Calendar component directly for `Value` property as mentioned in the following code example. In one-way binding, you need to pass property or variable name along with `@` (For Ex: "@DateValue").

```cshtml
@using Syncfusion.Blazor.Calendars

<SfCalendar TValue="DateTime?" Value="@DateValue"></SfCalendar>

<button @onclick="@UpdateValue">Update Value</button>

@code {
    public DateTime? DateValue {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28);

    public void UpdateValue()
    {
        DateValue = DateTime.Now;
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BXhKiVLVVoLNbXdK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Two-Way data binding

Two-way binding can be achieved by using `bind-Value` attribute and it supports string, int, Enum, DateTime, bool types. If the component value has been changed, it will affect all the places where the variable is bound for the **bind-value** attribute.

```cshtml
@using Syncfusion.Blazor.Calendars

<p>Calendar value is: @DateValue</p>

<SfCalendar TValue="DateTime?" @bind-Value="@DateValue"></SfCalendar>

@code {
public DateTime? DateValue { get; set; } = DateTime.Now;
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNhgWLhrrSBqdcMZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Dynamic value binding

You can change the property value dynamically by manually calling the `StateHasChanged()` method inside public event of **Blazor Calendar component** only. This method notifies the component that its state has changed and queues a re-render.

There is no need to call this method for native events since it’s called after any lifecycle method has been called. It can also be invoked manually to trigger a re-render. Refer the below mentioned code example.

```cshtml
@using Syncfusion.Blazor.Calendars

<p>Calendar value is: @DateValue</p>

<SfCalendar TValue="DateTime?" Value="@DateValue">
    <CalendarEvents TValue="DateTime?" ValueChange="@onChange"></CalendarEvents>
</SfCalendar>

@code {

public DateTime? DateValue { get; set; } = DateTime.Now;

private void onChange(Syncfusion.Blazor.Calendars.ChangedEventArgs<DateTime?> args)
    {
        DateValue = args.Value;
        StateHasChanged();
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDhKMBhBreLoYIse?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}