---
layout: post
title: Events in Blazor Calendar Component | Syncfusion
description: Checkout and learn here all about available Events in Syncfusion Blazor Calendar component and much more.
platform: Blazor
control: Calendar
documentation: ug
---

# Events in Blazor Calendar Component

This section lists the events of the [Blazor Calendar](https://www.syncfusion.com/blazor-components/blazor-calendar) component and describes when they are triggered during user interaction and rendering.

N> Starting with `v17.2.*`, only a limited set of events are available for the Calendar component. Event names differ from previous releases, and several events were removed. The following table summarizes event name changes from `v17.1.*` to `v17.2.*`.

Event Name(`v17.1.*`) |Event Name(`v17.2.*`)
-----|-----
change |[ValueChange](events#valuechange)
renderDayCell |[OnRenderDayCell](events#onrenderdaycell)

## OnRenderDayCell

The `OnRenderDayCell` event is triggered as each day cell is rendered, enabling customization of cell content and state.  

```cshtml
@using Syncfusion.Blazor.Calendars

<SfCalendar TValue="DateTime">
    <CalendarEvents TValue="DateTime?" OnRenderDayCell="onRenderDayCellHandler"></CalendarEvents>
</SfCalendar>

@code{

    public void onRenderDayCellHandler(RenderDayCellEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## ValueChange

The `ValueChange` event is triggered after the selected date value changes in the Calendar.  

```cshtml
@using Syncfusion.Blazor.Calendars

<SfCalendar TValue="DateTime">
    <CalendarEvents TValue="DateTime?" ValueChange="ValuechangeHandler"></CalendarEvents>
</SfCalendar>

@code{

    public void ValuechangeHandler(ChangedEventArgs<DateTime?> args)
    {
        // Here, you can customize your code.
    }
}
```

## Created

The `Created` event is triggered after the Calendar is initialized and rendered.  

```cshtml
@using Syncfusion.Blazor.Calendars

<SfCalendar TValue="DateTime">
    <CalendarEvents TValue="DateTime?" Created="createdHandler"></CalendarEvents>
</SfCalendar>

@code{

    public void createdHandler(object args)
    {
        // Here, you can customize your code.
    }
}
```

## Destroyed

The `Destroyed` event is triggered when the Calendar is disposed.  

```cshtml
@using Syncfusion.Blazor.Calendars

<SfCalendar TValue="DateTime">
    <CalendarEvents TValue="DateTime?" Destroyed="DestroyHandler"></CalendarEvents>
</SfCalendar>

@code{

    public void DestroyHandler(object args)
    {
        // Here, you can customize your code.
    }
}
```

## Navigated

The `Navigated` event is triggered after navigating to another view level or within the same level (for example, changing month, year, or decade).  

```cshtml
@using Syncfusion.Blazor.Calendars

<SfCalendar TValue="DateTime">
    <CalendarEvents TValue="DateTime?" Navigated="NavigatedHandler"></CalendarEvents>
</SfCalendar>

@code{

    public void NavigatedHandler(NavigatedEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

N> The Calendar is currently limited to these events. Additional events may be introduced in future versions based on user feedback. If a required event is missing, submit a request on the Syncfusion feedback portal: [Request a feature](https://www.syncfusion.com/feedback/blazor-components).