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

Native events can be attached by using the `@on<event>` attribute on the component. The attribute value is treated as the event handler.

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

The previous example can also be written using a lambda expression.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" @onkeypress="@(() => Console.WriteLine("Key Pressed!"))"></SfDatePicker>
```

## Pass event data to event handler

Blazor provides argument types that map to native DOM events. The common event categories and argument types include:

* Focus events - FocusEventArgs
* Mouse events - MouseEventArgs
* Keyboard events - KeyboardEventArgs
* Input events - ChangeEventArgs/EventArgs
* Touch events – TouchEventArgs
* Pointer events – PointerEventArgs

In the following example, the `KeyPressed` method is invoked on each key press, and a message is written only when the "5" key is pressed.

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

Lambda expressions can be used to pass the event data to the handler.

## List of native events supported

| List of Native events |  |  | |
| --- | --- | --- | --- |
| onclick | onblur | onfocus | onfocusout |
| onmousemove | onmouseover | onmouseout | onmousedown | onmouseup |
| ondblclick | onkeydown | onkeyup | onkeypress |
| ontouchend | onfocusin | onmouseup | ontouchstart |