---
layout: post
title: Data Binding in Blazor DateRangePicker Component | Syncfusion
description: Checkout and learn here all about Data Binding in Syncfusion Blazor DateRangePicker component and more.
platform: Blazor
control: DateRangePicker
documentation: ug
---

# Data Binding in Blazor DateRangePicker Component

This section briefly explains how to bind the value to the DateRangePicker component in the below different ways.

* One-Way Data Binding
* Two-Way Data Binding
* Dynamic Value Binding

## One-way binding

You can bind the value to the DateRangePicker component directly for `StartDate` and `EndDate` properties as mentioned in the following code example. In one-way binding, You need to pass property or variable name along with `@` (For Ex: "@StartValue").

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?" StartDate="@StartValue" EndDate="@EndValue"></SfDateRangePicker>

<button @onclick="@UpdateValue">Update Value</button>

@code {

    public DateTime? StartValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28);

    public DateTime? EndValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 28);

    public void UpdateValue()
    {
        StartValue = new DateTime(DateTime.Now.Year + 1, DateTime.Now.Month, 28);
        EndValue = new DateTime(DateTime.Now.Year + 1, DateTime.Now.Month + 1, 28);
    }
}
```

## Two-way data binding

Two-way binding can be achieved by using the `bind-StartDate` and `bind-EndDate` attributes and it supports string, int, Enum, DateTime, bool types. If the component value has been changed, it will affect all places where the variable is bound for the **bind-StartDate** and **bind-EndDate**attributes.

```cshtml
@using Syncfusion.Blazor.Calendars

<p>DateRangePickers StarteDate and EndDate is: <strong>@StartValue</strong> and <strong>@EndValue</strong></p>

<SfDateRangePicker TValue="DateTime?" @bind-StartDate="@StartValue" @bind-EndDate="@EndValue" ></SfDateRangePicker>

@code {

public DateTime? StartValue { get; set; } = DateTime.Now;

public DateTime? EndValue { get; set; } = DateTime.Now;
}
```

## Dynamic value binding

You can change the property value dynamically by manually calling the `StateHasChanged()` method inside public event of **Blazor DateRangePicker component** only. This method notifies the component that its state has changed and queues a re-render.

There is no need to call this method for native events since it’s called after any lifecycle method has been called and can also be invoked manually to trigger a re-render. Refer the below mentioned code example.

```cshtml
@using Syncfusion.Blazor.Calendars

<p>DateRangePicker StarteDate and EndDate is: <strong> @StartValue </strong> and <strong> @EndValue </strong></p>

<SfDateRangePicker TValue="DateTime?" StartDate="@StartValue" EndDate="@EndValue">
<DateRangePickerEvents TValue="DateTime?" ValueChange="@onChange"></DateRangePickerEvents>
</SfDateRangePicker>

@code {

public DateTime? StartValue { get; set; } = DateTime.Now;

public DateTime? EndValue { get; set; } = DateTime.Now;

private void onChange(RangePickerEventArgs<DateTime?> args)
{
    StartValue = args.StartDate;
    EndValue = args.EndDate;
    StateHasChanged();
}
}
```

N> You can refer to our [Blazor Date Range Picker](https://www.syncfusion.com/blazor-components/blazor-daterangepicker) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Date Range Picker example](https://blazor.syncfusion.com/demos/daterangepicker/default-functionalities?theme=bootstrap5) to understand how to present and manipulate data.
