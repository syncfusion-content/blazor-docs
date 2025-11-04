---
layout: post
title: Events in Blazor Datetime Picker Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor Datetime Picker component and much more.
platform: Blazor
control: Datetime Picker 
documentation: ug
---

# Events in Blazor Datetime Picker Component

This section explains the list of events of the DateTimePicker component which will be triggered for appropriate DateTimePicker actions.

Event Name(`v17.1.*`) |Event Name(`v17.2.*`)
-----|-----
change |[ValueChange](events#valuechange)
close |[OnClose](events#onclose)
open |[OnOpen](events#onopen)
renderDayCell |[OnRenderDayCell](events#onrenderdaycell)

## Blur

`Blur` event triggers when the input loses the focus.

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

`ValueChange` event triggers when the Calendar value is changed.

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

`OnClose` event triggers when popup is closed.

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

`Created` event triggers when DateTimePicker is created.

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

`Destroyed` event triggers when DateTimePicker is destroyed.

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

`Focus` event triggers when the input gets focus.

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

`Navigated` event triggers when the Calendar is navigated to another level or within the same level of view.

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

`OnOpen` event triggers when popup is opened.

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

`OnRenderDayCell` event triggers when each day cell of the Calendar is rendered.

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

N> DateTimePicker will be limited with these events and new events will be added in future based on the user requests. If the event you are looking for is not in the list, then request [here](https://www.syncfusion.com/feedback/blazor-components).
