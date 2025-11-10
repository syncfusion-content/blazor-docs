---
layout: post
title: Events in Blazor DatePicker Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor DatePicker component and much more details.
platform: Blazor
control: DatePicker
documentation: ug
---

# Events in Blazor DatePicker Component

This section explains the list of events of the DatePicker component which will be triggered for appropriate DatePicker actions.

N> From `v17.2.*` added only the limited number of events for the DatePicker component. The event names are different from the previous releases and also removed several events. The following are the event name changes from `v17.1.*` to `v17.2.*`

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

<SfDatePicker TValue="DateTime?">
    <DatePickerEvents TValue="DateTime?" Blur="BlurHandler"></DatePickerEvents>
</SfDatePicker>
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

<SfDatePicker TValue="DateTime?">
    <DatePickerEvents TValue="DateTime?" ValueChange="ValueChangeHandler"></DatePickerEvents>
</SfDatePicker>
@code{

    public void ValueChangeHandler(ChangedEventArgs<DateTime?> args)
    {
        // Here, you can customize your code.
    }
}
```

## OnClose

`OnClose` event triggers when the popup is closed.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?">
    <DatePickerEvents TValue="DateTime?" OnClose="OnCloseHandler"></DatePickerEvents>
</SfDatePicker>
@code{

    public void OnCloseHandler(PopupObjectArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## Created

`Created` event triggers when the component is created.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?">
    <DatePickerEvents TValue="DateTime?" Created="CreatedHandler"></DatePickerEvents>
</SfDatePicker>
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

<SfDatePicker TValue="DateTime?">
    <DatePickerEvents TValue="DateTime?" Destroyed="DestroyHandler"></DatePickerEvents>
</SfDatePicker>
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

<SfDatePicker TValue="DateTime?">
    <DatePickerEvents TValue="DateTime?" Focus="FocusHandler"></DatePickerEvents>
</SfDatePicker>
@code{

    public void FocusHandler(FocusEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## Navigated

`Navigated` event triggers when the Calendar is navigated to another level or within the same level of view.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?">
    <DatePickerEvents TValue="DateTime?" Navigated="NavigateHandler"></DatePickerEvents>
</SfDatePicker>
@code{

    public void NavigateHandler(NavigatedEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## OnOpen

`OnOpen` event triggers when the popup is opened.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?">
    <DatePickerEvents TValue="DateTime?" OnOpen="OpenHandler"></DatePickerEvents>
</SfDatePicker>
@code{

    public void OpenHandler(PopupObjectArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## OnRenderDayCell

`OnRenderDayCell` event triggers when each day cell of the Calendar is rendered.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?">
    <DatePickerEvents TValue="DateTime?" OnRenderDayCell="onRenderDayCellHandler"></DatePickerEvents>
</SfDatePicker>
@code{

    public void onRenderDayCellHandler(RenderDayCellEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

N> Datepicker will be limited with these events and new events will be added in future based on the user requests. If the event you are looking for is not in the list, then request [here](https://www.syncfusion.com/feedback/blazor-components).
