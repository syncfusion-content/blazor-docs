---
layout: post
title: Native Events in Blazor DateTimePicker Component | Syncfusion
description: Checkout and learn here all about Native Events in Syncfusion Blazor Datetime Picker component and more.
platform: Blazor
control: DateTimePicker
documentation: ug
---

# Native Events in Blazor DateTimePicker Component

The following section explains how to attach native DOM events to the DateTimePicker component and pass event data to the handler.

## Bind native events to DateTimePicker

Native events can be attached by using the `@on<event>` attribute on the component. The attribute value is treated as the event handler.

In the following example, the `KeyPressed` method is called every time a key is pressed in the input.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" @onkeypress='@KeyPressed'></SfDateTimePicker>

@code {
    public void KeyPressed(){
      Console.WriteLine("Key Pressed!");
  }
}
```

The previous example can also be written using a lambda expression.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" @onkeypress="@(() => Console.WriteLine("Key Pressed!"))"></SfDateTimePicker>
```

## Pass event data to event handler

Blazor provides argument types that map to native DOM events. Common event categories and argument types include:

* Focus events - FocusEventArgs
* Mouse events - MouseEventArgs
* Keyboard events - KeyboardEventArgs
* Input events - ChangeEventArgs/EventArgs
* Touch events – TouchEventArgs
* Pointer events – PointerEventArgs

In the following example, the `KeyPressed` method is invoked on each key press, and a message is written only when the "5" key is pressed.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" @onkeypress='@(e => KeyPressed(e))'></SfDateTimePicker>

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

Lambda expressions can also be used to pass the event data to the handler.

## List of native events supported

| List of Native events |  |  | |
| --- | --- | --- | --- |
| onclick | onblur | onfocus | onfocusout |
| onmousemove | onmouseover | onmouseout | onmousedown | onmouseup |
| ondblclick | onkeydown | onkeyup | onkeypress |
| ontouchend | onfocusin | onmouseup | ontouchstart |