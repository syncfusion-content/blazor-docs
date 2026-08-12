---
layout: post
title: Native Events in Blazor TimePicker | Syncfusion
description: Bind native DOM events like keypress to Blazor TimePicker using on-event attributes and event handlers.
platform: Blazor
control: TimePicker
documentation: ug
---

# Native Events in Blazor TimePicker

The following sections explain how to bind native HTML events to the Blazor TimePicker component and how to pass event data to the handler.

## Bind native events to TimePicker

Any native event can be bound to the TimePicker by using an `on<event>` attribute on the component. The attribute's value is treated as an event handler.

In the following example, the `KeyPressed` method is invoked every time a key is pressed inside the input.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfTimePicker TValue="DateTime?" @onkeypress='@KeyPressed'></SfTimePicker>

@code {
    public void KeyPressed()
    {
        Console.WriteLine("Key Pressed!");
    }
}
```

The same example can also be written using a lambda expression, as shown below.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfTimePicker TValue="DateTime?" @onkeypress="@(e => Console.WriteLine($"Key Pressed: {e.Key}"))"></SfTimePicker>
```

## Pass event data to the event handler

Blazor provides a set of argument types that map to native events. The list of event categories and their corresponding argument types is:

* Focus Events – `FocusEventArgs`
* Mouse Events – `MouseEventArgs`
* Keyboard Events – `KeyboardEventArgs`
* Input Events – `ChangeEventArgs` / `EventArgs`
* Touch Events – `TouchEventArgs`
* Pointer Events – `PointerEventArgs`

In the following example, the `KeyPressed` method is invoked every time any key is pressed inside the input, but the message is printed only when the `5` key is pressed.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfTimePicker TValue="DateTime?" @onkeypress='@(e => KeyPressed(e))'></SfTimePicker>

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

A lambda expression can also be used to pass the event data to the event handler.

## List of Native events supported

| List of Native events |  |  |  |
| --- | --- | --- | --- |
| onclick | onblur | onfocus | onfocusout |
| onmousemove | onmouseover | onmouseout | onmousedown |
| onmouseup | ondblclick | onkeydown | onkeyup |
| onkeypress | ontouchend | onfocusin | ontouchstart |

## See also

* [Events in Blazor TimePicker](events)
* [Data Binding in Blazor TimePicker](data-binding)
* [Accessibility in Blazor TimePicker](accessibility)