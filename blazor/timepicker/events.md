---
layout: post
title: Events in Blazor TimePicker Component | Syncfusion
description: Checkout and learn here all about events in Syncfusion Blazor TimePicker component and much more details.
platform: Blazor
control: TimePicker
documentation: ug
---

# Events in Blazor TimePicker Component

This section explains the list of events of the TimePicker component which will be triggered for appropriate TimePicker actions.

| Event Name(`v17.1.*`) |Event Name(`v17.2.*`) |
| ----- | ----- |
| change | [ValueChange](events#valuechange) |
| close | [OnClose](events#onclose) |
| itemRender | [OnItemRender](events#onitemrender) |
| open | [OnOpen](events#onopen) |

## Blur

`Blur` event triggers when the input loses the focus.

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

`ValueChange` event triggers when the Calendar value is changed.

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

`OnClose` event triggers when popup is closed.

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

`Created` event triggers when the component is created.

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

`Destroyed` event triggers when the component is destroyed.

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

`Focus` event triggers when the input gets focus.

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

`OnItemRender` event triggers while rendering the each popup list item.

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

`OnOpen` event triggers when the popup is opened.

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

N> TimePicker will be limited with these events and new events will be added in future based on the user requests. If the event you are looking for is not in the list, then request [here](https://www.syncfusion.com/feedback/blazor-components).
