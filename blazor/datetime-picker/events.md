---
layout: post
title: Events in Blazor DateTimePicker Component | Syncfusion
description: Learn about events in the Syncfusion Blazor DateTimePicker component, including ValueChange, OnOpen, OnClose, OnRenderDayCell, and more.
platform: Blazor
control: DateTimePicker
documentation: ug
---

# Events in Blazor Datetime Picker Component

This section lists and describes the events raised by the DateTimePicker component for user interactions and lifecycle actions.

N> Starting with `v17.2.*`, the DateTimePicker exposes a streamlined set of events. Event names were changed from previous releases, and several events were removed. The following table shows the event name changes from `v17.1.*` to `v17.2.*`.

Event Name(`v17.1.*`) |Event Name(`v17.2.*`)
-----|-----
change |[ValueChange](events#valuechange)
close |[OnClose](events#onclose)
open |[OnOpen](events#onopen)
renderDayCell |[OnRenderDayCell](events#onrenderdaycell)

## Blur

The `Blur` event is triggered when the input loses focus.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" >
    <DateTimePickerEvents TValue="DateTime?" Blur="BlurHandler"></DateTimePickerEvents>
</SfDateTimePicker>

@code{

    public void BlurHandler(Syncfusion.Blazor.Calendars.BlurEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## ValueChange

The `ValueChange` event is triggered when the DateTimePicker value (date and time) changes.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" >
    <DateTimePickerEvents TValue="DateTime?" ValueChange="ValueChangeHandler"></DateTimePickerEvents>
</SfDateTimePicker>

@code{

    public void ValueChangeHandler(ChangedEventArgs<DateTime?> args)
    {
        // Here, you can customize your code.
    }
}
```

## OnClose

The `OnClose` event is triggered when the popup is closed.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" >
    <DateTimePickerEvents TValue="DateTime?" OnClose="OnCloseHandler"></DateTimePickerEvents>
</SfDateTimePicker>

@code{

    public void OnCloseHandler(object args)
    {
        // Here, you can customize your code.
    }
}
```

## Created

The `Created` event is triggered when the component is created.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" >
    <DateTimePickerEvents TValue="DateTime?" Created="CreatedHandler"></DateTimePickerEvents>
</SfDateTimePicker>

@code{

    public void CreatedHandler(object args)
    {
        // Here, you can customize your code.
    }
}
```

## Destroyed

The `Destroyed` event is triggered when the component is destroyed.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" >
    <DateTimePickerEvents TValue="DateTime?" Destroyed="DestroyHandler"></DateTimePickerEvents>
</SfDateTimePicker>

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

<SfDateTimePicker TValue="DateTime?" >
    <DateTimePickerEvents TValue="DateTime?" Focus="FocusHandler"></DateTimePickerEvents>
</SfDateTimePicker>

@code{

    public void FocusHandler(object args)
    {
        // Here, you can customize your code.
    }
}

```

## Navigated

The `Navigated` event is triggered when navigating between calendar views (such as month, year, or decade) or within the same view.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" >
    <DateTimePickerEvents TValue="DateTime?" Navigated="NavigateHandler"></DateTimePickerEvents>
</SfDateTimePicker>


@code{

    public void NavigateHandler(NavigatedEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## OnOpen

The `OnOpen` event is triggered when the popup is opened.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" >
    <DateTimePickerEvents TValue="DateTime?" OnOpen="OpenHandler"></DateTimePickerEvents>
</SfDateTimePicker>


@code{

    public void OpenHandler(object args)
    {
        // Here, you can customize your code.
    }
}
```

## OnRenderDayCell

The `OnRenderDayCell` event is triggered when each day cell of the calendar is rendered.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" >
    <DateTimePickerEvents TValue="DateTime?" OnRenderDayCell="onRenderDayCellHandler"></DateTimePickerEvents>
</SfDateTimePicker>

@code{

    public void onRenderDayCellHandler(RenderDayCellEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

N> The DateTimePicker currently supports the events listed above. Additional events may be introduced in future releases based on user requests. If the required event is not listed, submit a request on the [Syncfusion Feedback](https://www.syncfusion.com/feedback/blazor-components) portal.