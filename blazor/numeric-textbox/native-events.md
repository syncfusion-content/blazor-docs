---
layout: post
title: Native Events in Blazor Numeric TextBox Component | Syncfusion
description: Checkout and learn here all about native events in Syncfusion Blazor Numeric TextBox component and more.
platform: Blazor
control: Numeric TextBox
documentation: ug
---

# Native Events in Blazor Numeric TextBox Component

This section explains how to attach native DOM events to the Numeric TextBox and how to pass event data to handlers.

## Bind native events to NumericTextBox

Attach native event by using on `<event>` attribute with a component. The attribute's value is treated as an event handler method.

In the following example, the KeyPressed method is invoked every time a key is pressed in the input.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfNumericTextBox TValue="int?" @onkeypress='@KeyPressed'></SfNumericTextBox>

@code {
    public void KeyPressed(){
      Console.WriteLine("Key Pressed!");
  }
}
```

The same behavior can be expressed with a lambda expression.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfNumericTextBox TValue="int?" @onkeypress="@(() => Console.WriteLine("Key Pressed!"))"></SfNumericTextBox>
```

## Pass event data to event handler

Blazor provides strongly typed event argument classes that map to native events. Common examples include:
- Focus events: FocusEventArgs
- Mouse events: MouseEventArgs
- Keyboard events: KeyboardEventArgs
- Input/change events: ChangeEventArgs
- Touch events: TouchEventArgs
- Pointer events: PointerEventArgs

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

Using a lambda expression, event data can be forwarded to the handler as shown above.

## List of Native events supported

| List of Native events |  |  | |
| --- | --- | --- | --- |
| onclick | onblur | onfocus | onfocusout |
| onmousemove | onmouseover | onmouseout | onmousedown | onmouseup |
| ondblclick | onkeydown | onkeyup | onkeypress |
| ontouchend | onfocusin | onmouseup | ontouchstart |