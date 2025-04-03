---
layout: post
title: Events in Blazor Calendar Component | Syncfusion
description: Checkout and learn here all about available Events in Syncfusion Blazor Calendar component and much more.
platform: Blazor
control: Calendar
documentation: ug
---

# Events in Blazor Calendar Component

This section explains the list of events of the [Blazor Calendar](https://www.syncfusion.com/blazor-components/blazor-calendar) component which will be triggered for appropriate Calendar actions.

N> From `v17.2.*` added only the limited number of events for the Calendar component. The event names are different from the previous releases and also removed several events. The following are the event name changes from `v17.1.*` to `v17.2.*`

Event Name(`v17.1.*`) |Event Name(`v17.2.*`)
-----|-----
change |[ValueChange](events#valuechange)
renderDayCell |[OnRenderDayCell](events#onrenderdaycell)

## OnRenderDayCell

`onRenderDayCellHandler` event triggers when each day cell of the Calendar is rendered.

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

`ValueChange` event triggers when the Calendar value is changed.

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

`Created` event triggers when Calendar is created.

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

`OnOpen` event triggers when Calendar is destroyed.

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

`Navigated` event triggers when the Calendar is navigated to another level or within the same level of view.

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

N> Calendar will be limited with these events and new events will be added in future based on the user requests. If the event you are looking for is not in the list, then request [here](https://www.syncfusion.com/feedback/blazor-components).
