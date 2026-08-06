---
layout: post
title: Events in Blazor DatePicker Component | Syncfusion®
description: Checkout and learn here all the features about Events in Blazor DatePicker component and much more details.
platform: Blazor
control: DatePicker
documentation: ug
---

# Events in Blazor DatePicker Component

This section lists the events of the DatePicker component and the actions that trigger them. The events are exposed through the [DatePickerEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.DatePickerEvents-1.html) child content and use the `Syncfusion.Blazor.Calendars` namespace for their event-argument types.

N> Starting with `v17.2.*`, the DatePicker component exposes a limited set of events with new names. Several legacy events from `v17.1.*` were renamed or removed. The mapping is shown in the table below.

Event Name(`v17.1.*`) |Event Name(`v17.2.*`)
-----|-----
change |[ValueChange](#valuechange)
close |[OnClose](#onclose)
open |[OnOpen](#onopen)
renderDayCell |[OnRenderDayCell](#onrenderdaycell)

## Blur

The [Blur](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.DatePickerEvents-1.html#Syncfusion_Blazor_Calendars_DatePickerEvents_1_Blur) event triggers when the input loses focus. It receives a [BlurEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.BlurEventArgs.html) parameter that contains the original browser event in `args.Event`.

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

The [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.DatePickerEvents-1.html#Syncfusion_Blazor_Calendars_DatePickerEvents_1_ValueChange) event triggers when the Calendar value changes. It receives a [ChangedEventArgs<T>](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.ChangedEventArgs-1.html) parameter. Use `args.Value` to read the newly selected date.

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

The [OnClose](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.DatePickerEvents-1.html#Syncfusion_Blazor_Calendars_DatePickerEvents_1_OnClose) event triggers when the popup is closed. It receives a [PopupObjectArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.PopupObjectArgs.html) parameter that exposes the closing popup element and related metadata.

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

The [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.DatePickerEvents-1.html#Syncfusion_Blazor_Calendars_DatePickerEvents_1_Created) event triggers after the component finishes its initial render. It is typically used for one-time setup such as attaching JS interop callbacks.

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

The [Destroyed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.DatePickerEvents-1.html#Syncfusion_Blazor_Calendars_DatePickerEvents_1_Destroyed) event triggers when the component is disposed. Use it to release any resources allocated in the `Created` handler.

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

The [Focus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.DatePickerEvents-1.html#Syncfusion_Blazor_Calendars_DatePickerEvents_1_Focus) event triggers when the input receives focus. It receives a [FocusEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.FocusEventArgs.html) parameter that contains the original browser event in `args.Event`.

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

The [Navigated](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.DatePickerEvents-1.html#Syncfusion_Blazor_Calendars_DatePickerEvents_1_Navigated) event triggers when the Calendar navigates to another level (for example, from month to year) or within the same level. It receives a [NavigatedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.NavigatedEventArgs.html) parameter with `args.View` and `args.Date` properties.

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

The [OnOpen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.DatePickerEvents-1.html#Syncfusion_Blazor_Calendars_DatePickerEvents_1_OnOpen) event triggers when the popup is opened. It receives a [PopupObjectArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.PopupObjectArgs.html) parameter that exposes the opening popup element and related metadata.

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

The [OnRenderDayCell](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.DatePickerEvents-1.html#Syncfusion_Blazor_Calendars_DatePickerEvents_1_OnRenderDayCell) event triggers when each day cell of the Calendar is rendered. It receives a [RenderDayCellEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.RenderDayCellEventArgs.html) parameter that you can use to add custom classes or attributes to the cell via `args.Cell.AddClass(...)` or to set `args.IsDisabled` and other properties.

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

N> The DatePicker is limited to the events listed on this page. New events will be added in future releases based on user feedback. If the event you need is not in the list, [submit a feature request](https://www.syncfusion.com/feedback/blazor-components).

## See also

* [DatePickerEvents API](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.DatePickerEvents-1.html)
* [Data Binding](data-binding)
