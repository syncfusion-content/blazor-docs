---
layout: post
title: Events in Blazor TimePicker Component | Syncfusion
description: Checkout and learn here all about events in Syncfusion Blazor TimePicker component and much more details.
platform: Blazor
control: TimePicker
documentation: ug
---

# Events in Blazor TimePicker Component

This section describes the TimePicker events that are raised for user and programmatic interactions. The following table maps legacy event names to current event names.

| Event Name(`v17.1.*`) |Event Name(`v17.2.*`) |
| ----- | ----- |
| change | [ValueChange](events#valuechange) |
| close | [OnClose](events#onclose) |
| itemRender | [OnItemRender](events#onitemrender) |
| open | [OnOpen](events#onopen) |

## Blur

The `Blur` event triggered when the input loses the focus.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfTimePicker TValue="DateTime?">
    <TimePickerEvents TValue="DateTime?" Blur="BlurHandler"></TimePickerEvents>
</SfTimePicker>

@code{

    public void BlurHandler(Syncfusion.Blazor.Calendars.BlurEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## ValueChange

The `ValueChange` event triggered when the Calendar value is changed.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfTimePicker TValue="DateTime?">
    <TimePickerEvents TValue="DateTime?" ValueChange="ValueChangeHandler"></TimePickerEvents>
</SfTimePicker>

@code{

    public void ValueChangeHandler(Syncfusion.Blazor.Calendars.ChangeEventArgs<DateTime?> args)
    {
        // Here you can customize your code
    }
}
```

## OnClose

The `OnClose` event triggered when the popup is closed.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfTimePicker TValue="DateTime?">
    <TimePickerEvents TValue="DateTime?" OnClose="OnCloseHandler"></TimePickerEvents>
</SfTimePicker>

@code{

    public void OnCloseHandler(Syncfusion.Blazor.Calendars.PopupEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## Created

The `Created` event triggered when the component is created.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfTimePicker TValue="DateTime?">
    <TimePickerEvents TValue="DateTime?" Created="CreatedHandler"></TimePickerEvents>
</SfTimePicker>

@code{

    public void CreatedHandler(object args)
    {
        // Here you can customize your code
    }
}
```

## Destroyed

The `Destroyed` event triggered when the component is destroyed.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfTimePicker TValue="DateTime?">
    <TimePickerEvents TValue="DateTime?" Destroyed="DestroyHandler"></TimePickerEvents>
</SfTimePicker>
@code{

    public void DestroyHandler(object args)
    {
        // Here you can customize your code
    }
}
```

## Focus

The `Focus` event triggered when the input gets focus.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfTimePicker TValue="DateTime?">
    <TimePickerEvents TValue="DateTime" Focus="FocusHandler"></TimePickerEvents>
</SfTimePicker>

@code{

    public void FocusHandler(Syncfusion.Blazor.Calendars.FocusEventArgs args)
    {
        // Here you can customize your code
    }
}

```

## OnItemRender

The `OnItemRender` event triggered while rendering the each popup list item.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfTimePicker TValue="DateTime?">
    <TimePickerEvents TValue="DateTime?" OnItemRender="OnItemRenderHandler"></TimePickerEvents>
</SfTimePicker>
@code{

    public void OnItemRenderHandler(Syncfusion.Blazor.Calendars.ItemEventArgs<DateTime?> args)
    {
        // Here you can customize your code
    }
}
```

## OnOpen

The `OnOpen` event triggered when the popup is opened.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfTimePicker TValue="DateTime?">
    <TimePickerEvents TValue="DateTime?" OnOpen="OpenHandler"></TimePickerEvents>
</SfTimePicker>

@code{

    public void OpenHandler(Syncfusion.Blazor.Calendars.PopupEventArgs args)
    {
        // Here you can customize your code
    }
}
```

N> The TimePicker currently exposes the events listed above. Additional events may be introduced based on user feedback. If an event needed for a scenario is not available, submit a request in the [Syncfusion Blazor feedback portal](https://www.syncfusion.com/feedback/blazor-components).