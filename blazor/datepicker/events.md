---
layout: post
title: Events in Blazor DatePicker Component | Syncfusion
description: Learn about events in the Syncfusion Blazor DatePicker component, including ValueChange, OnOpen, OnClose, OnRenderDayCell, and more.
platform: Blazor
control: DatePicker
documentation: ug
---

# Events in Blazor DatePicker Component

This section lists and describes the events raised by the DatePicker component for common user interactions and component lifecycle actions.

N> Starting with `v17.2.*`, the DatePicker exposes a streamlined set of events. Event names were changed from previous releases, and several events were removed. The following table shows the event name changes from `v17.1.*` to `v17.2.*`.

Event Name(`v17.1.*`) |Event Name(`v17.2.*`)
-----|-----
change |[ValueChange](#valuechange)
close |[OnClose](#onclose)
open |[OnOpen](#onopen)
renderDayCell |[OnRenderDayCell](#onrenderdaycell)

## Blur

The `Blur` event is triggered when the input loses focus.
- API: [Blur](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Blur)

```cshtml
@using Syncfusion.Blazor.Calendars

<p>Last event: @LastEvent</p>

<SfDatePicker TValue="DateTime?">
    <DatePickerEvents TValue="DateTime?" Blur="BlurHandler"></DatePickerEvents>
</SfDatePicker>

@code{
    private string LastEvent { get; set; } = "None";
    public void BlurHandler(Syncfusion.Blazor.Calendars.BlurEventArgs args)
    {
        LastEvent = $"Blur at {DateTime.Now:T}";
    }
}
```

Preview:
- When the input loses focus, the paragraph updates to show “Blur at HH:MM:SS”.

## ValueChange

The `ValueChange` event is triggered when the DatePicker value changes.
- API: [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_ValueChange)
- Args: [ChangedEventArgs<TValue>](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.ChangedEventArgs-1.html)

```cshtml
@using Syncfusion.Blazor.Calendars

<p>Current value: @CurrentValue</p>

<SfDatePicker TValue="DateTime?">
    <DatePickerEvents TValue="DateTime?" ValueChange="ValueChangeHandler"></DatePickerEvents>
</SfDatePicker>

@code{
    private string CurrentValue { get; set; } = "None";
    public void ValueChangeHandler(ChangedEventArgs<DateTime?> args)
    {
        CurrentValue = args.Value?.ToString("yyyy-MM-dd") ?? "null";
    }
}
```

Preview:
- Selecting a date updates the paragraph to the selected date (or “null” when cleared).

## OnClose

The `OnClose` event is triggered when the popup is closed.
- API: [OnClose](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_OnClose)
- Args: [PopupObjectArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.PopupObjectArgs.html)

```cshtml
@using Syncfusion.Blazor.Calendars

<p>Popup state: @PopupState</p>

<SfDatePicker TValue="DateTime?">
    <DatePickerEvents TValue="DateTime?" OnClose="OnCloseHandler"></DatePickerEvents>
</SfDatePicker>

@code{
    private string PopupState { get; set; } = "Idle";
    public void OnCloseHandler(PopupObjectArgs args)
    {
        PopupState = "Closed";
    }
}
```

Preview:
- Closing the popup updates the paragraph to “Closed”.

## Created

The `Created` event is triggered when the component is created.
- API: [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Created)

```cshtml
@using Syncfusion.Blazor.Calendars

<p>Lifecycle: @LifecycleState</p>

<SfDatePicker TValue="DateTime?">
    <DatePickerEvents TValue="DateTime?" Created="CreatedHandler"></DatePickerEvents>
</SfDatePicker>

@code{
    private string LifecycleState { get; set; } = "Initializing...";
    public void CreatedHandler(object args)
    {
        LifecycleState = "Created";
    }
}
```

Preview:
- After the component initializes, the paragraph shows “Created”.

## Destroyed

The `Destroyed` event is triggered when the component is destroyed.
- API: [Destroyed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Destroyed)

```cshtml
@using Syncfusion.Blazor.Calendars

<p>Lifecycle: @LifecycleState</p>

@if (ShowPicker)
{
    <SfDatePicker TValue="DateTime?">
        <DatePickerEvents TValue="DateTime?" Destroyed="DestroyHandler"></DatePickerEvents>
    </SfDatePicker>
}
<button @onclick="() => ShowPicker = !ShowPicker">Toggle</button>

@code{
    private bool ShowPicker = true;
    private string LifecycleState { get; set; } = "Mounted";
    public void DestroyHandler(object args)
    {
        LifecycleState = "Destroyed";
    }
}
```

Preview:
- Clicking “Toggle” to remove the component updates the paragraph to “Destroyed”.

## Focus

The `Focus` event is triggered when the input gains focus.
- API: [Focus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Focus)
- Args: [FocusEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.FocusEventArgs.html)

```cshtml
@using Syncfusion.Blazor.Calendars

<p>Last event: @LastEvent</p>

<SfDatePicker TValue="DateTime?">
    <DatePickerEvents TValue="DateTime?" Focus="FocusHandler"></DatePickerEvents>
</SfDatePicker>

@code{
    private string LastEvent { get; set; } = "None";
    public void FocusHandler(FocusEventArgs args)
    {
        LastEvent = $"Focus at {DateTime.Now:T}";
    }
}
```

Preview:
- Focusing the input updates the paragraph to “Focus at HH:MM:SS”.

## Navigated

The `Navigated` event is triggered when navigating between calendar views (such as month, year, or decade) or within the same view.
- API: [Navigated](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_Navigated)
- Args: [NavigatedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.NavigatedEventArgs.html)

```cshtml
@using Syncfusion.Blazor.Calendars

<p>Navigation: @NavInfo</p>

<SfDatePicker TValue="DateTime?">
    <DatePickerEvents TValue="DateTime?" Navigated="NavigateHandler"></DatePickerEvents>
</SfDatePicker>

@code{
    private string NavInfo { get; set; } = "None";
    public void NavigateHandler(NavigatedEventArgs args)
    {
        NavInfo = $"Action: {args.Action}, View: {args.View}";
    }
}
```

Preview:
- Navigating the calendar updates the paragraph with the navigation action and current view.

## OnOpen

The `OnOpen` event is triggered when the popup is opened.
- API: [OnOpen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_OnOpen)
- Args: [PopupObjectArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.PopupObjectArgs.html)

```cshtml
@using Syncfusion.Blazor.Calendars

<p>Popup state: @PopupState</p>

<SfDatePicker TValue="DateTime?">
    <DatePickerEvents TValue="DateTime?" OnOpen="OpenHandler"></DatePickerEvents>
</SfDatePicker>

@code{
    private string PopupState { get; set; } = "Idle";
    public void OpenHandler(PopupObjectArgs args)
    {
        PopupState = "Opened";
    }
}
```

Preview:
- Opening the popup updates the paragraph to “Opened”.

## OnRenderDayCell

The `OnRenderDayCell` event is triggered when each day cell of the calendar is rendered.
- API: [OnRenderDayCell](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html#Syncfusion_Blazor_Calendars_SfDatePicker_1_OnRenderDayCell)
- Args: [RenderDayCellEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.RenderDayCellEventArgs.html)

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?">
    <DatePickerEvents TValue="DateTime?" OnRenderDayCell="OnRenderDayCellHandler"></DatePickerEvents>
</SfDatePicker>

@code{
    public void OnRenderDayCellHandler(RenderDayCellEventArgs args)
    {
        // Example: mark weekends as disabled
        if (args.Date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
        {
            args.IsDisabled = true;
        }
    }
}
```

Preview:
- Weekend dates appear disabled in the calendar.

N> The DatePicker supports the events listed above. Additional events may be introduced in future releases. Requests can be submitted on the [Syncfusion Feedback](https://www.syncfusion.com/feedback/blazor-components) portal.
