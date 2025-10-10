---
layout: post
title: Native Events in Blazor DatePicker Component | Syncfusion
description: Learn how to use native DOM events with the Syncfusion Blazor DatePicker component, bind event handlers, and pass event data.
platform: Blazor
control: DatePicker
documentation: ug
---

# Native Events in Blazor DatePicker Component

This section explains how to attach native DOM events to the DatePicker component and how to pass event data to the event handler.

## Bind native events to DatePicker

Native events can be attached by using the `@on<event>` attribute on the component. The attribute value is treated as the event handler. For keyboard scenarios, `onkeydown` or `onkeyup` is recommended.

In the following example, the `KeyDown` method is called every time a key is pressed in the input.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" @onkeydown='@KeyDown'></SfDatePicker>

@code {
    public void KeyDown()
    {
        Console.WriteLine("Key pressed.");
    }
}
```

The previous example can also be written using a lambda expression.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" @onkeydown='@(() => Console.WriteLine("Key pressed."))'></SfDatePicker>
```

## Pass event data to event handler

Blazor provides argument types that map to native DOM events. The common event categories and argument types include:

- Focus events – FocusEventArgs
- Mouse events – MouseEventArgs
- Keyboard events – KeyboardEventArgs
- Input/change events – ChangeEventArgs/EventArgs
- Touch events – TouchEventArgs
- Pointer events – PointerEventArgs

In the following example, the `KeyPressed` method is invoked on each key press, and a message is written only when the "5" key is pressed.

```cshtml
@using Syncfusion.Blazor.Calendars
@using Microsoft.AspNetCore.Components.Web

<SfDatePicker TValue="DateTime?" @onkeydown='@(e => KeyPressed(e))'></SfDatePicker>

@code {
    public void KeyPressed(KeyboardEventArgs args)
    {
        if (args.Key == "5")
        {
            Console.WriteLine("5 was pressed");
        }
    }
}
```

Lambda expressions can be used to pass the event data to the handler. For more details about Blazor event arguments, refer to the Microsoft documentation: https://learn.microsoft.com/aspnet/core/blazor/components/event-handling. For DatePicker component details, refer to the Syncfusion documentation: https://blazor.syncfusion.com/documentation/datepicker/getting-started

## Preview of the code snippet

- When any key is pressed while the DatePicker input is focused, a console message is written.
- When the "5" key is pressed, a specific console message indicating that "5 was pressed" is written.

## List of native events supported

| List of Native events |  |  | |
| --- | --- | --- | --- |
| onclick | onblur | onfocus | onfocusout |
| onmousemove | onmouseover | onmouseout | onmousedown | onmouseup |
| ondblclick | onkeydown | onkeyup | onkeypress |
| ontouchend | onfocusin | onmouseup | ontouchstart |
