---
layout: post
title: Native Events in Blazor TimePicker Component | Syncfusion
description: Checkout and learn here all about native events in Syncfusion Blazor TimePicker component and much more.
platform: Blazor
control: TimePicker
documentation: ug
---

# Native Events in Blazor TimePicker Component

The following section explains how to include native DOM events using Blazor’s `@on...` attributes and how to pass event data to handlers in the TimePicker component.

## Bind native events to TimePicker

Attach any native DOM event by using the `@on<event>` attribute on the component. The attribute value is treated as the event handler.

In the following example, the `KeyPressed` method is called every time a key is pressed in the input.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfTimePicker TValue="DateTime?" @onkeypress='@KeyPressed'></SfTimePicker>

@code {
    public void KeyPressed(){
      Console.WriteLine("Key Pressed!");
  }
}
```

The same example can be expressed using a lambda expression:

```cshtml
@using Syncfusion.Blazor.Calendars

<SfTimePicker TValue="DateTime?" @onkeypress="@(() => Console.WriteLine("Key Pressed!"))"></SfTimePicker>
```

## Pass event data to event handler

Blazor provides a set of event argument types that map to native events (from the `Microsoft.AspNetCore.Components.Web` namespace). Common event types and argument classes include:

* Focus events – `FocusEventArgs`
* Mouse events – `MouseEventArgs`
* Keyboard events – `KeyboardEventArgs`
* Input events – `ChangeEventArgs` / `EventArgs`
* Touch events – `TouchEventArgs`
* Pointer events – `PointerEventArgs`

In the following example, the `KeyPressed` method is called whenever a key is pressed inside the input, but a message is printed only when the “5” key is pressed.

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

Using a lambda expression, the event data can also be passed directly to the event handler.

## List of Native events supported

| List of Native events |  |  | |
| --- | --- | --- | --- |
| onclick | onblur | onfocus | onfocusout |
| onmousemove | onmouseover | onmouseout | onmousedown | onmouseup |
| ondblclick | onkeydown | onkeyup | onkeypress |
| ontouchend | onfocusin | onmouseup | ontouchstart |