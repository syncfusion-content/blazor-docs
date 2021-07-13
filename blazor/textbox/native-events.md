---
layout: post
title: Native Events in Blazor TextBox Component | Syncfusion 
description: Learn about Native Events in Blazor TextBox component of Syncfusion, and more details.
platform: Blazor
control: TextBox
documentation: ug
---

# Overview

The following section explains the steps to include native events and pass data to event handler in textbox component.

## Bind native events to textbox

You can access any native event by using on `<event>` attribute with a component. The attribute's value is treated as an event handler.

In the following example, the KeyPressed method is called every time the key is pressed on textbox.

```csharp
@using Syncfusion.Blazor.Inputs

<SfTextBox Placeholder='First Name' @onkeypress='@KeyPressed'></SfTextBox>

@code {
    public void KeyPressed(){
      Console.WriteLine("Key Pressed!");
  }
}
```

Also, you can rewrite the above example code as follows using Lambda expressions.

```csharp
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

In the following example, the KeyPressed method is called every time any key is pressed inside textbox. But the message will be printed when you press "s" key.

```csharp
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

Using Lambda expression also, you can pass the event data to the event handler.

## List of Native events supported

| List of Native events |  |  | |
| --- | --- | --- | --- |
| onclick | onblur | onfocus | onfocusout |
| onmousemove | onmouseover | onmouseout | onmousedown | onmouseup |
| ondblclick | onkeydown | onkeyup | onkeypress |
| ontouchend | onfocusin | onmouseup | ontouchstart |
