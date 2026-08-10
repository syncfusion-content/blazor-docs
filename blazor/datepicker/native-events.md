---
layout: post
title: Native Events in Blazor DatePicker Component | Syncfusion®
description: Checkout and learn here all the features about native events in Blazor DatePicker component and much more.
platform: Blazor
control: DatePicker
documentation: ug
---

# Native Events in Blazor DatePicker Component

This section explains how to bind native DOM events to the DatePicker component and how to pass event data to the event handler. The DatePicker component supports the standard Blazor event-binding syntax (`@on<event>`) on its root input element.

## Bind native events to DatePicker

You can access any native event by using on `<event>` attribute with a component. The attribute's value is treated as an event handler.

In the following example, the `KeyPressed` method is called every time a key is pressed in the input.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" @onkeypress='@KeyPressed'></SfDatePicker>

@code {
    public void KeyPressed(){
      Console.WriteLine("Key Pressed!");
  }
}
```

You can also rewrite the previous example using a lambda expression.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" @onkeypress="@(() => Console.WriteLine("Key Pressed!"))"></SfDatePicker>
```

## Pass event data to event handler

Blazor provides a set of argument types that map to native events. The supported event types and their arguments are:

* Focus events – `FocusEventArgs`
* Mouse events – `MouseEventArgs`
* Keyboard events – `KeyboardEventArgs`
* Input events – `ChangeEventArgs` / `EventArgs`
* Touch events – `TouchEventArgs`
* Pointer events – `PointerEventArgs`

In the following example, the `KeyPressed` method is called every time a key is pressed in the input, but the message is printed only when the `5` key is pressed.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" @onkeypress='@(e => KeyPressed(e))'></SfDatePicker>

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

You can also use a lambda expression to forward the event data to the handler.

## List of native events supported

| Category | Events |
| --- | --- |
| Focus | `onfocus`, `onblur`, `onfocusin`, `onfocusout` |
| Mouse | `onclick`, `ondblclick`, `onmousedown`, `onmouseup`, `onmouseover`, `onmouseout`, `onmousemove` |
| Keyboard | `onkeydown`, `onkeyup`, `onkeypress` |
| Touch | `ontouchstart`, `ontouchend` |

## See also

* [Events](events)
* [Blazor event handling](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/event-handling)