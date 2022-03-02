---
layout: post
title: Native Events in Blazor Input Mask Component | Syncfusion
description: Checkout and learn here all about Native Events in Syncfusion Blazor Input Mask component and much more.
platform: Blazor
control: Input Mask
documentation: ug
---

# Native Events in Blazor Input Mask Component

The following section explains the steps to include native events and pass data to event handler in MaskedTextBox component.

## Bind native events to MaskedTextBox

You can access any native event by using on `<event>` attribute with a component. The attribute's value is treated as an event handler.

In the following example, the KeyPressed method is called every time the key is pressed on input.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfMaskedTextBox Mask='000-000-0000' @onkeypress='@KeyPressed'></SfMaskedTextBox>

@code {
      public void KeyPressed() {
      Console.WriteLine("Key Pressed!");
  }
}
```

Also, you can rewrite the previous example code as follows using Lambda expressions.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfMaskedTextBox Mask='000-000-0000' @onkeypress="@(() => Console.WriteLine("Key Pressed!"))"></SfMaskedTextBox>
```

## Pass event data to event handler

Blazor provides set of argument types to map to native events. The list of event types and event arguments are:

* Focus Events - FocusEventArgs
* Mouse Events - MouseEventArgs
* Keyboard Events - KeyboardEventArgs
* Input Events - ChangeEventArgs/EventArgs
* Touch Events – TouchEventArgs
* Pointer Events – PointerEventArgs

In the following example, the KeyPressed method is called every time any key is pressed inside input. But the message will be printed when you press "m" key.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfMaskedTextBox Mask='000-000-0000' @onkeypress='@(e => KeyPressed(e))' ></SfMaskedTextBox>

@code {
  public void KeyPressed(KeyboardEventArgs args) {
    if (args.Key == "m") {
      Console.WriteLine("M was pressed");
    }
  }
}
```

Using Lambda expression also, you can pass the event data to the event handler.

## List of native events supported

| List of Native events |  |  | |
| --- | --- | --- | --- |
| onclick | onblur | onfocus | onfocusout |
| onmousemove | onmouseover | onmouseout | onmousedown | onmouseup |
| ondblclick | onkeydown | onkeyup | onkeypress |
| ontouchend | onfocusin | onmouseup | ontouchstart |
