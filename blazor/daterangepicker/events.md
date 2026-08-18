---
layout: post
title: Events in Blazor DateRangePicker | Syncfusion®
description: Handle Blazor DateRangePicker events such as ValueChange, RangeSelected, OnOpen, OnClose, and Navigated to react to user input.
platform: Blazor
control: DateRangePicker
documentation: ug
---

# Events in Blazor DateRangePicker

This section lists the events of the DateRangePicker component that are triggered by corresponding user actions.

The events should be provided to the DateRangePicker using the **DateRangePickerEvents** component, which is available in the `Syncfusion.Blazor.Calendars` namespace.

N> Starting with `v17.2.*`, the DateRangePicker supports a defined set of events. The event names have changed from previous releases, and several events have been removed. The following are the event name changes from `v17.1.*` to `v17.2.*`.

Event Name(`v17.1.*`) |Event Name(`v17.2.*`)
-----|-----
change |[ValueChange](events#valuechange)
close |[OnClose](events#onclose)
open |[OnOpen](events#onopen)
renderDayCell |[OnRenderDayCell](events#onrenderdaycell)
select |[RangeSelected](events#rangeselected)

## Blur

The `Blur` event triggers when the input loses focus. The `BlurEventArgs` provides event details for handling the blur action.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?">
    <DateRangePickerEvents TValue="DateTime?" Blur="BlurHandler"></DateRangePickerEvents>
</SfDateRangePicker>
@code{

    public void BlurHandler(Syncfusion.Blazor.Calendars.BlurEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## ValueChange

The `ValueChange` event triggers when the calendar value changes. The `RangePickerEventArgs<TValue>` provides the `StartDate` and `EndDate` properties containing the newly selected range.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?">
    <DateRangePickerEvents TValue="DateTime?" ValueChange="ValueChangeHandler"></DateRangePickerEvents>
</SfDateRangePicker>
@code{

    public void ValueChangeHandler(RangePickerEventArgs<DateTime?> args)
    {
        // Here, you can customize your code.
    }
}
```

## OnClose

The `OnClose` event triggers when the DateRangePicker popup is closed. The `RangePopupEventArgs` provides event details for handling the close action.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?">
    <DateRangePickerEvents TValue="DateTime?" OnClose="OnCloseHandler"></DateRangePickerEvents>
</SfDateRangePicker>
@code{

    public void OnCloseHandler(RangePopupEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## Created

The `Created` event triggers after the component is created and initialized.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?">
    <DateRangePickerEvents TValue="DateTime?" Created="CreatedHandler"></DateRangePickerEvents>
</SfDateRangePicker>
@code{

    public void CreatedHandler(object args)
    {
        // Here, you can customize your code.
    }
}
```

## Destroyed

The `Destroyed` event triggers when the component is destroyed.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?">
    <DateRangePickerEvents TValue="DateTime?" Destroyed="DestroyHandler"></DateRangePickerEvents>
</SfDateRangePicker>
@code{

    public void DestroyHandler(object args)
    {
        // Here, you can customize your code.
    }
}
```

## Focus

The `Focus` event triggers when the input receives focus. The `FocusEventArgs` provides event details for handling the focus action.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?">
    <DateRangePickerEvents TValue="DateTime?"  Focus="FocusHandler"></DateRangePickerEvents>
</SfDateRangePicker>

@code{

    public void FocusHandler(Syncfusion.Blazor.Calendars.FocusEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## Navigated

The `Navigated` event triggers when the calendar is navigated to another level or within the same level of view. The `NavigatedEventArgs` provides properties such as `View` and `Date` describing the current view.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?">
    <DateRangePickerEvents TValue="DateTime?" Navigated="NavigateHandler"></DateRangePickerEvents>
</SfDateRangePicker>

@code{

    public void NavigateHandler(NavigatedEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## OnOpen

The `OnOpen` event triggers when the DateRangePicker popup is opened. The `RangePopupEventArgs` provides event details for handling the open action.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?">
    <DateRangePickerEvents TValue="DateTime?" OnOpen="OpenHandler"></DateRangePickerEvents>
</SfDateRangePicker>

@code{

    public void OpenHandler(RangePopupEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## OnRenderDayCell

The `OnRenderDayCell` event triggers when each day cell of the calendar is rendered. The `RenderDayCellEventArgs` provides properties such as `Date`, `IsDisabled`, and `IsOutOfRange` to customize each cell.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?">
    <DateRangePickerEvents TValue="DateTime?" OnRenderDayCell="onRenderDayCellHandler"></DateRangePickerEvents>
</SfDateRangePicker>

@code{

    public void onRenderDayCellHandler(RenderDayCellEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## RangeSelected

The `RangeSelected` event triggers when both the start and end dates of a range are selected. The `RangePickerEventArgs<TValue>` provides the `StartDate` and `EndDate` properties of the selected range.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?">
    <DateRangePickerEvents TValue="DateTime?" RangeSelected="RangeSelectHandler"></DateRangePickerEvents>
</SfDateRangePicker>

@code{

    public void RangeSelectHandler(RangePickerEventArgs<DateTime?> args)
    {
        // Here, you can customize your code.
    }
}
```

N> The DateRangePicker is limited to the events listed above, and new events will be added in the future based on user requests. If the event you are looking for is not in the list, you can request it [here](https://www.syncfusion.com/feedback/blazor-components).
