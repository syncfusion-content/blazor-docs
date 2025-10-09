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

The events are configured using the DateRangePickerEvents child component.

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

@code {
    public void BlurHandler(Syncfusion.Blazor.Calendars.BlurEventArgs args)
    {
        // Add logic to handle input losing focus.
    }
}
```

Preview: When the input field loses focus, the BlurHandler method executes.

## ValueChange

The `ValueChange` event is triggered when the DateRangePicker value (start or end date) changes.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?">
    <DateRangePickerEvents TValue="DateTime?" ValueChange="ValueChangeHandler"></DateRangePickerEvents>
</SfDateRangePicker>

@code {
    public void ValueChangeHandler(RangePickerEventArgs<DateTime?> args)
    {
        // Add logic to respond to start/end date changes.
    }
}
```

Preview: Selecting or modifying the range invokes ValueChangeHandler with the updated start and end dates.

## OnClose

The `OnClose` event is triggered when the DateRangePicker popup is closed.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?">
    <DateRangePickerEvents TValue="DateTime?" OnClose="OnCloseHandler"></DateRangePickerEvents>
</SfDateRangePicker>

@code {
    public void OnCloseHandler(RangePopupEventArgs args)
    {
        // Add logic to handle popup close action.
    }
}
```

Preview: Closing the popup triggers OnCloseHandler after the popup is dismissed.

## Created

The `Created` event is triggered when the component is initialized.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?">
    <DateRangePickerEvents TValue="DateTime?" Created="CreatedHandler"></DateRangePickerEvents>
</SfDateRangePicker>

@code {
    public void CreatedHandler(object args)
    {
        // Add initialization logic after component creation.
    }
}
```

Preview: After the component is initialized and rendered, CreatedHandler executes once.

## Destroyed

The `Destroyed` event is triggered when the component is disposed.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?">
    <DateRangePickerEvents TValue="DateTime?" Destroyed="DestroyHandler"></DateRangePickerEvents>
</SfDateRangePicker>

@code {
    public void DestroyHandler(object args)
    {
        // Add cleanup logic during component disposal.
    }
}
```

Preview: When the component is disposed, DestroyHandler runs for cleanup operations.

## Focus

The `Focus` event is triggered when the input gains focus.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?">
    <DateRangePickerEvents TValue="DateTime?" Focus="FocusHandler"></DateRangePickerEvents>
</SfDateRangePicker>

@code {
    public void FocusHandler(Syncfusion.Blazor.Calendars.FocusEventArgs args)
    {
        // Add logic to handle input focus.
    }
}
```

Preview: When the input receives focus, FocusHandler is executed.

## Navigated

The `Navigated` event is triggered when navigating between calendar views (such as month, year, or decade) or within the same view.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?">
    <DateRangePickerEvents TValue="DateTime?" Navigated="NavigateHandler"></DateRangePickerEvents>
</SfDateRangePicker>

@code {
    public void NavigateHandler(NavigatedEventArgs args)
    {
        // Add logic to respond to view navigation.
    }
}
```

Preview: Changing the calendar view or moving within a view triggers NavigateHandler with navigation details.

## OnOpen

The `OnOpen` event is triggered when the DateRangePicker popup is opened.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?">
    <DateRangePickerEvents TValue="DateTime?" OnOpen="OpenHandler"></DateRangePickerEvents>
</SfDateRangePicker>

@code {
    public void OpenHandler(RangePopupEventArgs args)
    {
        // Add logic to handle popup open action.
    }
}
```

Preview: Opening the popup invokes OpenHandler before interaction with the calendar.

## OnRenderDayCell

The `OnRenderDayCell` event is triggered when each day cell of the calendar is rendered, allowing customization or disabling of specific dates.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?">
    <DateRangePickerEvents TValue="DateTime?" OnRenderDayCell="OnRenderDayCellHandler"></DateRangePickerEvents>
</SfDateRangePicker>

@code {
    public void OnRenderDayCellHandler(RenderDayCellEventArgs args)
    {
        // Add logic to customize or disable specific dates.
        // Example: args.IsDisabled = true; // to disable a date
    }
}
```

Preview: As each calendar day cell is rendered, OnRenderDayCellHandler executes, enabling customization such as disabling dates or adding styles.

## RangeSelected

The `RangeSelected` event is triggered after selecting both the start and end dates of the range.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?">
    <DateRangePickerEvents TValue="DateTime?" RangeSelected="RangeSelectHandler"></DateRangePickerEvents>
</SfDateRangePicker>

@code {
    public void RangeSelectHandler(RangePickerEventArgs<DateTime?> args)
    {
        // Add logic to respond after the full range is selected.
    }
}
```

Preview: After both dates are selected, RangeSelectHandler receives the finalized start and end dates.

N> The DateRangePicker currently supports the events listed above. Additional events may be introduced in future releases based on feature requests. If a required event is not listed, submit a request on the [Syncfusion Feedback](https://www.syncfusion.com/feedback/blazor-components) portal.