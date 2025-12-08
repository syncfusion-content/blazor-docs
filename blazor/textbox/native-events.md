---
layout: post
title: Native Events in Blazor TextBox Component | Syncfusion
description: Checkout and learn here all about Native Events in Syncfusion Blazor TextBox component and much more.
platform: Blazor
control: TextBox
documentation: ug
---

# Native Events in Blazor TextBox Component

The following section explains how to bind native DOM events and pass event data to an event handler in the TextBox component.

## Bind native events to textbox

Native browser events can be handled by adding the @on<event> attribute to the component. The attribute value is an event handler that runs when the corresponding DOM event occurs.

In the following example, the KeyPressed method is called every time a key is pressed in the TextBox.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Placeholder='First Name' @onkeypress='@KeyPressed'></SfTextBox>

@code {
    public void KeyPressed(){
      Console.WriteLine("Key Pressed!");
  }
}
```

The same behavior can be expressed with a lambda expression.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Placeholder='First Name' @onkeypress="@(() => Console.WriteLine("Key Pressed!"))">
</SfTextBox>
```

## Pass event data to event handler

Blazor provides strongly typed event argument classes that map to native events. Common event categories and their corresponding argument types include:

* Focus events – FocusEventArgs
* Mouse events – MouseEventArgs
* Keyboard events – KeyboardEventArgs
* Input/change events – ChangeEventArgs/EventArgs
* Touch events – TouchEventArgs
* Pointer events – PointerEventArgs

In the following example, the KeyPressed method is invoked on every key press in the TextBox, and a message is written only when the "s" key is pressed.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Placeholder='First Name' @onkeypress='@(e => KeyPressed(e))' ></SfTextBox>

@code {
  public void KeyPressed(KeyboardEventArgs args) {
    if (args.Key == "s") {
      Console.WriteLine("S was pressed");
    }
  }
}
```

Event argument types are defined in the Microsoft.AspNetCore.Components.Web namespace. Event handlers can also be async (returning Task) when asynchronous work is required.

## List of Native events supported

| List of Native events |  |  | |
| --- | --- | --- | --- |
| onclick | onblur | onfocus | onfocusout |
| onmousemove | onmouseover | onmouseout | onmousedown |
| onmouseup | ondblclick | onkeydown | onkeyup |
| onkeypress | onfocusin | oninput | onchange |