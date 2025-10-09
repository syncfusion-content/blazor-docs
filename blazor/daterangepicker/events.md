---
layout: post
title: Events in Blazor DateRangePicker Component | Syncfusion
description: Learn about events in the Syncfusion Blazor DateRangePicker component, including ValueChange, OnOpen, OnClose, OnRenderDayCell, RangeSelected, and more.
platform: Blazor
control: DateRangePicker
documentation: ug
---

# Events in Blazor DateRangePicker Component

This section lists and describes the events raised by the DateRangePicker component for common user interactions and lifecycle actions.

The events are configured using the **DateRangePickerEvents** child component.

N> Starting with `v17.2.*`, the DateRangePicker exposes a streamlined set of events. Event names were changed from previous releases, and several events were removed. The following table shows the event name changes from `v17.1.*` to `v17.2.*`.

Event Name(`v17.1.*`) |Event Name(`v17.2.*`)
-----|-----
change |[ValueChange](events#valuechange)
close |[OnClose](events#onclose)
open |[OnOpen](events#onopen)
renderDayCell |[OnRenderDayCell](events#onrenderdaycell)
select |[RangeSelected](events#rangeselected)

## Blur

The `Blur` event is triggered when the input loses focus.

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

The `ValueChange` event is triggered when the DateRangePicker value (start or end date) changes.

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

The `OnClose` event is triggered when the DateRangePicker popup is closed.

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

The `Created` event is triggered when the component is initialized.

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

The `Destroyed` event is triggered when the component is disposed.

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

The `Focus` event is triggered when the input gains focus.

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

The `Navigated` event is triggered when navigating between calendar views (such as month, year, or decade) or within the same view.

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

The `OnOpen` event is triggered when the DateRangePicker popup is opened.

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

The `OnRenderDayCell` event is triggered when each day cell of the calendar is rendered, allowing customization or disabling of specific dates.

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

The `RangeSelected` event is triggered after selecting both the start and end dates of the range.

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

N> The DateRangePicker currently supports the events listed above. Additional events may be introduced in future releases based on user requests. If the required event is not listed, submit a request on the [Syncfusion Feedback](https://www.syncfusion.com/feedback/blazor-components) portal.