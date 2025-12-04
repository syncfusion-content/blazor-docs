---
layout: post
title: Native events in Blazor AutoComplete component | Syncfusion
description: Check out how to use native events with the Syncfusion Blazor AutoComplete component, including @on{event} binding and passing event argument data.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Native Events in Blazor AutoComplete Component

The following section explains how to include native DOM events and pass data to an event handler in the [Blazor AutoComplete](https://www.syncfusion.com/blazor-components/blazor-autocomplete) component. Native events are bound using the `@on{event}` attribute syntax, and the attribute value is the event handler.

## Bind native events to AutoComplete

Bind any native event by adding the corresponding `@on{event}` attribute to the component. The event is attached to the component’s input element, and the attribute’s value is treated as an event handler.

In the following example, the `KeyPressed` method is called each time a key is pressed in the input.

```cshtml
<SfAutoComplete TValue="string" TItem="Country" @onkeypress="@KeyPressed" DataSource="@LocalData">
    <AutoCompleteFieldSettings Value="Name"></AutoCompleteFieldSettings>
</SfAutoComplete>

@code {
    public void KeyPressed()
    {
        Console.WriteLine("Key Pressed!");
    }

    public class Country
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    List<Country> LocalData = new List<Country> {
        new Country() { Name = "Australia", Code = "AU" },
        new Country() { Name = "Bermuda", Code = "BM" },
        new Country() { Name = "Canada", Code = "CA" },
        new Country() { Name = "Cameroon", Code = "CM" },
        new Country() { Name = "Denmark", Code = "DK" },
        new Country() { Name = "France", Code = "FR" },
    };
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjVUMrifgyJMzUUB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

The same behavior can be written using a lambda expression. The following example prints a message when a key is pressed.

```cshtml
<SfAutoComplete TValue="string" DataSource="@LocalData" @onkeypress="@(() => Console.WriteLine("Key Pressed!"))"></SfAutoComplete>
```

Note: Handlers can be synchronous or asynchronous. Event modifiers such as `:preventDefault` and `:stopPropagation` can be appended to native events (for example, `@onkeydown:preventDefault`).

## Pass event data to event handler

Blazor provides strongly typed event argument classes that map to native events. Common event types and corresponding argument classes include:

- Focus events – FocusEventArgs
- Mouse events – MouseEventArgs
- Keyboard events – KeyboardEventArgs
- Input/change events – ChangeEventArgs/EventArgs
- Touch events – TouchEventArgs
- Pointer events – PointerEventArgs

In the following example, the keypress handler receives `KeyboardEventArgs`. The message is printed only when the “a” key is pressed.

```cshtml
<SfAutoComplete TValue="string" TItem="Country" @onkeypress="@(e => KeyPressed(e))" DataSource="@LocalData">
    <AutoCompleteFieldSettings Value="Name"></AutoCompleteFieldSettings>
</SfAutoComplete>

@code {
  public void KeyPressed(KeyboardEventArgs args) {
    if (args.Key == "a") {
      Console.WriteLine("A was pressed");
    }
  }
  public class Country
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    List<Country> LocalData = new List<Country> {
        new Country() { Name = "Australia", Code = "AU" },
        new Country() { Name = "Bermuda", Code = "BM" },
        new Country() { Name = "Canada", Code = "CA" },
        new Country() { Name = "Cameroon", Code = "CM" },
        new Country() { Name = "Denmark", Code = "DK" },
        new Country() { Name = "France", Code = "FR" },
    };
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXVgCVWTAdxsbIip?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

Lambda expressions can also pass event data to the event handler as shown above. Native events can be used alongside Syncfusion component events (such as `ValueChange`), depending on the use case.

## List of native events supported

Common native events that can be bound to the component include:

| List of Native events |  |  | |
| --- | --- | --- | --- |
| onclick | onblur | onfocus | onfocusout |
| onmousemove | onmouseover | onmouseout | onmousedown | onmouseup |
| ondblclick | onkeydown | onkeyup | onkeypress |
| ontouchend | onfocusin | onmouseup | ontouchstart |