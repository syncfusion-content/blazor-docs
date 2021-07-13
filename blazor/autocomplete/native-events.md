---
layout: post
title: Native Events in Blazor AutoComplete Component | Syncfusion 
description: Learn about Native Events in Blazor AutoComplete component of Syncfusion, and more details.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Overview

The following section explains the steps to include native events and pass data to event handler in the AutoComplete component.

## Bind native events to AutoComplete

You can access any native event by using on `<event>` attribute with a component. The attribute's value is treated as an event handler.

In the following example, the keyPressed method is called every time the key is pressed on input.

```csharp
<SfAutoComplete TValue="string" TItem="Countries" @onkeypress="@KeyPressed">
    <AutoCompleteFieldSettings Value="Name"></AutoCompleteFieldSettings>
</SfAutoComplete>

@code {
    public void KeyPressed()
    {
        Console.WriteLine("Key Pressed!");
    }

    public class Countries
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    List<Countries> LocalData = new List<Countries> {
        new Countries() { Name = "Australia", Code = "AU" },
        new Countries() { Name = "Bermuda", Code = "BM" },
        new Countries() { Name = "Canada", Code = "CA" },
        new Countries() { Name = "Cameroon", Code = "CM" },
        new Countries() { Name = "Denmark", Code = "DK" },
        new Countries() { Name = "France", Code = "FR" },
    };
}
```

Also, you can rewrite the above example code as follows using Lambda expressions.

```csharp
<SfAutoComplete TValue="string" @onkeypress="@(() => Console.WriteLine("Key Pressed!"))"></SfAutoComplete>
```

## Pass event data to event handler

Blazor provides set of argument types to map to native events. The list of event types and event arguments are:

* Focus Events - FocusEventArgs
* Mouse Events - MouseEventArgs
* Keyboard Events - KeyboardEventArgs
* Input Events - ChangeEventArgs/EventArgs
* Touch Events – TouchEventArgs
* Pointer Events – PointerEventArgs

In the following example, the onkeypress method is called every time any key is pressed inside input. But the message will print when you press "a" key.

```csharp
<SfAutoComplete TValue="string" TItem="Countries" @onkeypress="@(e => KeyPressed(e))" >
    <AutoCompleteFieldSettings Value="Name"></AutoCompleteFieldSettings>
</SfAutoComplete>

@code {
  public void KeyPressed(KeyboardEventArgs args) {
    if (args.Key == "a") {
      Console.WriteLine("A was pressed");
    }
  }
  public class Countries
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    List<Countries> LocalData = new List<Countries> {
        new Countries() { Name = "Australia", Code = "AU" },
        new Countries() { Name = "Bermuda", Code = "BM" },
        new Countries() { Name = "Canada", Code = "CA" },
        new Countries() { Name = "Cameroon", Code = "CM" },
        new Countries() { Name = "Denmark", Code = "DK" },
        new Countries() { Name = "France", Code = "FR" },
    };
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
