---
layout: post
title: Events in Blazor DateRangePicker Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor DateRangePicker component and much more.
platform: Blazor
control: DateRangePicker
documentation: ug
---

# Events in Blazor DateRangePicker Component

This section explains the list of events of the DateRangePicker component which will be triggered for appropriate DateRangePicker actions.

The events should be provided to the DateRangePicker using **DateRangePickerEvents** component.

N> From `v17.2.*` added only the limited number of events for the DateRangePicker component. The event names are different from the previous releases and also removed several events. The following are the event name changes from `v17.1.*` to `v17.2.*`

Event Name(`v17.1.*`) |Event Name(`v17.2.*`)
-----|-----
change |[ValueChange](events#valuechange)
close |[OnClose](events#onclose)
open |[OnOpen](events#onopen)
renderDayCell |[OnRenderDayCell](events#onrenderdaycell)
select |[RangeSelected](events#rangeselected)

## Blur

`Blur` event triggers when the input loses the focus.

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

`ValueChange` event triggers when the Calendar value is changed.

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

`OnClose` event triggers when the DateRangePicker is closed.

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

`Created` event triggers when the component is created.

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

`Destroyed` event triggers when the component is destroyed.

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

`Focus` event triggers when the input gets focus.

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

`Navigated` event triggers when the Calendar is navigated to another level or within the same level of view.

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

`OnOpen` event triggers when the DateRangePicker is opened.

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

`OnRenderDayCell` event triggers when each day cell of the Calendar is rendered.

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

`RangeSelected` event triggers on selecting the start and end date.

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

N> Datepicker will be limited with these events and new events will be added in future based on the user requests. If the event you are looking for is not in the list, then request [here](https://www.syncfusion.com/feedback/blazor-components).
