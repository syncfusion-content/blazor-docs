---
layout: post
title: Native Events in Blazor DateRangePicker Component | Syncfusion
description: Learn how to use native DOM events with the Syncfusion Blazor DateRangePicker component, bind event handlers, and pass event data.
platform: Blazor
control: DateRangePicker
documentation: ug
---

# Native Events in Blazor DateRangePicker Component

The following section explains how to attach native DOM events to the DateRangePicker component and pass event data to the handler.

## Bind native events to DateRangePicker

Native events can be attached using the `@on<event>` attribute on the component. The attribute value is treated as the event handler.

In the following example, the `KeyPressed` method is called every time a key is pressed in the input.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?" @onkeypress='@KeyPressed'></SfDateRangePicker>

@code {
    public void KeyPressed(){
      Console.WriteLine("Key Pressed!");
  }
}
```

The previous example can also be written using a lambda expression.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?" @onkeypress="@(() => Console.WriteLine("Key Pressed!"))"></SfDateRangePicker>
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

<SfDateRangePicker TValue="DateTime?" @onkeypress='@(e => KeyPressed(e))'></SfDateRangePicker>

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

N> You can refer to our [Blazor Date Range Picker](https://www.syncfusion.com/blazor-components/blazor-daterangepicker) feature tour page for its key feature representations. You can also explore our [Blazor Date Range Picker example](https://blazor.syncfusion.com/demos/daterangepicker/default-functionalities?theme=bootstrap5) to understand how to present and manipulate data.