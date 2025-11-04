---
layout: post
title: Native Events in Blazor TextBox Component | Syncfusion
description: Checkout and learn here all about Native Events in Syncfusion Blazor TextBox component and much more.
platform: Blazor
control: TextBox
documentation: ug
---

# Native Events in Blazor TextBox Component

The following section explains the steps to include native events and pass data to event handler in textbox component.

## Bind native events to textbox

Any native event can be accessed by using on `<event>` attribute with a component. The attribute's value is treated as an event handler.

In the following example, the KeyPressed method is called every time the key is pressed on textbox.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Placeholder='First Name' @onkeypress='@KeyPressed'></SfTextBox>

@code {
    public void KeyPressed(){
      Console.WriteLine("Key Pressed!");
  }
}
```

Also, the above example code can be rewritten as follows using Lambda expressions.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Placeholder='First Name' @onkeypress="@(() => Console.WriteLine("Key Pressed!"))">
</SfTextBox>
```

## Pass event data to event handler

Blazor provides set of argument types for map to native events. The list of event types and event arguments are:

* Focus Events - FocusEventArgs
* Mouse Events - MouseEventArgs
* Keyboard Events - KeyboardEventArgs
* Input Events - ChangeEventArgs/EventArgs
* Touch Events – TouchEventArgs
* Pointer Events – PointerEventArgs

In the following example, the KeyPressed method is called every time any key is pressed inside textbox. But the message will be printed when the "s" key is pressed.

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

Using Lambda expression also, the event data can be passed to the event handler.

## List of Native events supported

| List of Native events |  |  | |
| --- | --- | --- | --- |
| onclick | onblur | onfocus | onfocusout |
| onmousemove | onmouseover | onmouseout | onmousedown | onmouseup |
| ondblclick | onkeydown | onkeyup | onkeypress |
| ontouchend | onfocusin | onmouseup | ontouchstart |