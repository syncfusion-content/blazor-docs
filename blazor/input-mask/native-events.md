---
layout: post
title: Native Events in Blazor Input Mask Component | Syncfusion
description: Checkout and learn here all about Native Events in Syncfusion Blazor Input Mask component and much more.
platform: Blazor
control: Input Mask
documentation: ug
---

# Native Events in Blazor Input Mask Component

This section describes how to bind native DOM events to the MaskedTextBox component and how to pass event data to event handlers.

## Bind native events to MaskedTextBox

Bind native DOM events using the Blazor `@on{event}` syntax on the component. The attribute value is the event handler to invoke.

In the following example, the KeyPressed method is called every time a key is pressed in the input.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfMaskedTextBox Mask='000-000-0000' @onkeypress='@KeyPressed'></SfMaskedTextBox>

@code {
      public void KeyPressed() {
      Console.WriteLine("Key Pressed!");
  }
}
```

Also, the previous example can be written using a lambda expression.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfMaskedTextBox Mask='000-000-0000' @onkeypress="@(() => Console.WriteLine("Key Pressed!"))"></SfMaskedTextBox>
```

## Pass event data to event handler

Blazor provides specific argument types for native events. Common mappings include:

* Focus events – FocusEventArgs
* Mouse events – MouseEventArgs
* Keyboard events – KeyboardEventArgs
* Input events – ChangeEventArgs/EventArgs
* Touch events – TouchEventArgs
* Pointer events – PointerEventArgs

In the following example, the KeyPressed method is invoked for every key press in the input, and a message is written only when the "m" key is pressed.

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