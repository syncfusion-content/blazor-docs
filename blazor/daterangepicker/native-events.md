---
layout: post
title: Native Events in Blazor DateRangePicker | Syncfusion®
description: Attach native DOM events to the Blazor DateRangePicker using the on{event} attribute, and pass event argument data to the handler.
platform: Blazor
control: DateRangePicker
documentation: ug
---

# Native Events in Blazor DateRangePicker

The following section explains the steps to bind native events to the Blazor DateRangePicker and pass data to the event handler.

## Bind native events to Blazor DateRangePicker

You can access any native event by using the `<event>` attribute on the component. The attribute's value is treated as an event handler.

In the following example, the `KeyPressed` method is called every time a key is pressed on the input.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?" @onkeypress='@KeyPressed'></SfDateRangePicker>

@code {
    public void KeyPressed(){
      Console.WriteLine("Key Pressed!");
  }
}
```

## Pass event data to event handler

Blazor provides a set of argument types to map to native events. The list of event types and event arguments are:

* Focus Events - FocusEventArgs
* Mouse Events - MouseEventArgs
* Keyboard Events - KeyboardEventArgs
* Input Events - ChangeEventArgs/EventArgs
* Touch Events – TouchEventArgs
* Pointer Events – PointerEventArgs

In the following example, the `KeyPressed` method is called every time any key is pressed inside the input, but the message is printed only when the "5" key is pressed.

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

Using Lambda expression also, you can pass the event data to the event handler.

## List of native events supported

The following native events are supported on the `SfDateRangePicker` component:

| List of Native events |  |  | |
| --- | --- | --- | --- |
| onclick | onblur | onfocusout | onfocusin |
| onmousemove | onmouseover | onmouseout | onmousedown | onmouseup |
| ondblclick | onkeydown | onkeyup | onkeypress |
| ontouchend | ontouchstart | | |

N> You can refer to our [Blazor Date Range Picker](https://www.syncfusion.com/blazor-components/blazor-daterangepicker) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Date Range Picker example](https://blazor.syncfusion.com/demos/daterangepicker/default-functionalities?theme=fluent2) to understand how to present and manipulate data.