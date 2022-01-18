---
layout: post
title: Native Events in Blazor Numeric TextBox Component | Syncfusion
description: Checkout and learn here all about native events in Syncfusion Blazor Numeric TextBox component and more.
platform: Blazor
control: Numeric TextBox
documentation: ug
---

# Native Events in Blazor Numeric TextBox Component

This section explains the steps to include native events and pass data to event handler in the NumericTextBox component.

## Bind native events to NumericTextBox

You can access any native event by using on `<event>` attribute with a component. The attribute's value is treated as an event handler.

In the following example, the KeyPressed method is called every time the key is pressed on input.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfNumericTextBox TValue="int?" @onkeypress='@KeyPressed'></SfNumericTextBox>

@code {
    public void KeyPressed(){
      Console.WriteLine("Key Pressed!");
  }
}
```

Also, you can rewrite the previous example code as follows using Lambda expressions.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfNumericTextBox TValue="int?" @onkeypress="@(() => Console.WriteLine("Key Pressed!"))"></SfNumericTextBox>
```

## Pass event data to event handler

Blazor provides set of argument types to map to native events. The list of event types and event arguments are:

* Focus Events - FocusEventArgs
* Mouse Events - MouseEventArgs
* Keyboard Events - KeyboardEventArgs
* Input Events - ChangeEventArgs/EventArgs
* Touch Events – TouchEventArgs
* Pointer Events – PointerEventArgs

In the following example, the KeyPressed method is called every time any key is pressed inside input. But the message will be printed when you press "n" key.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfNumericTextBox TValue="int?" @onkeypress='@(e => KeyPressed(e))'></SfNumericTextBox>

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

## List of Native events supported

| List of Native events |  |  | |
| --- | --- | --- | --- |
| onclick | onblur | onfocus | onfocusout |
| onmousemove | onmouseover | onmouseout | onmousedown | onmouseup |
| ondblclick | onkeydown | onkeyup | onkeypress |
| ontouchend | onfocusin | onmouseup | ontouchstart |