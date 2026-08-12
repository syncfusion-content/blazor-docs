---
layout: post
title: Events in Blazor TimePicker | Syncfusion
description: Handle Blazor TimePicker events such as ValueChange, OnOpen, OnClose, and OnItemRender for custom interactions.
platform: Blazor
control: TimePicker
documentation: ug
---

# Events in Blazor TimePicker

This section lists the events exposed by the Blazor TimePicker component and the actions that trigger them.

| Event Name(`v17.1.*`) |Event Name(`v17.2.*`) |
| ----- | ----- |
| change | [ValueChange](events#valuechange) |
| close | [OnClose](events#onclose) |
| created | [Created](events#created) |
| destroyed | [Destroyed](events#destroyed) |
| focus | [Focus](events#focus) |
| blur | [Blur](events#blur) |
| itemRender | [OnItemRender](events#onitemrender) |
| open | [OnOpen](events#onopen) |

## Blur

The `Blur` event is triggered when the input loses focus.

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

The `ValueChange` event is triggered when the TimePicker value is changed.

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

The `OnClose` event is triggered when the popup is closed.

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

The `Created` event is triggered after the component is created.

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

The `Destroyed` event is triggered when the component is destroyed.

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

The `Focus` event is triggered when the input receives focus.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfTimePicker TValue="DateTime?">
    <TimePickerEvents TValue="DateTime?" Focus="FocusHandler"></TimePickerEvents>
</SfTimePicker>

@code{

    public void FocusHandler(Syncfusion.Blazor.Calendars.FocusEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## OnItemRender

The `OnItemRender` event is triggered while rendering each popup list item.

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

The `OnOpen` event is triggered when the popup is opened.

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

N> The TimePicker currently supports the events listed above. New events may be added in the future based on user requests. If the event you are looking for is not in the list, request it at the [Syncfusion Blazor feedback portal](https://www.syncfusion.com/feedback/blazor-components).

## See also

* [Data Binding in Blazor TimePicker](data-binding)
* [Accessibility in Blazor TimePicker](accessibility)
* [Time Format in Blazor TimePicker](time-format)
