---
layout: post
title: Native Events in Blazor ComboBox Component | Syncfusion
description: Checkout and learn here all about Native Events in Syncfusion Blazor ComboBox component and much more.
platform: Blazor
control: ComboBox
documentation: ug
---

# Native Events in Blazor ComboBox Component

The following section explains the steps to include native events and pass data to event handler in ComboBox component.

## Bind native events to ComboBox

Bind any native event by adding the corresponding `@on<event>` attribute to the component and assigning an event handler. The attribute’s value is treated as the handler to invoke when the event occurs.

In the following example, the `KeyPressed` method is invoked whenever a key is pressed inside the ComboBox input.

```cshtml
@using Syncfusion.Blazor.Data

<SfComboBox TValue="string" TItem="Country" @onkeypress="@KeyPressed" DataSource="@Countries">
    <ComboBoxFieldSettings Text="Name" Value="Code"></ComboBoxFieldSettings>
</SfComboBox>

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
    List<Country> Countries = new List<Country>
    {
        new Country() { Name = "Australia", Code = "AU" },
        new Country() { Name = "Bermuda", Code = "BM" },
        new Country() { Name = "Canada", Code = "CA" },
        new Country() { Name = "Cameroon", Code = "CM" },
        new Country() { Name = "Denmark", Code = "DK" },
        new Country() { Name = "France", Code = "FR" },
    };
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/htVgiLrGUlddXtaX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

Also, rewrite the previous code example as follows using Lambda expressions.

```cshtml
<SfComboBox TValue="string" @onkeypress="@(() => Console.WriteLine("Key Pressed!"))"></SfComboBox>
```

## Pass event data to event handler

Blazor maps native events to strongly typed argument classes. Choose the handler parameter type that matches the event being handled:

- Focus events: FocusEventArgs
- Mouse events: MouseEventArgs
- Keyboard events: KeyboardEventArgs
- Input/change events: ChangeEventArgs or EventArgs
- Touch events: TouchEventArgs
- Pointer events: PointerEventArgs

In the following example, the `KeyPressed` method receives `KeyboardEventArgs` and conditionally processes only when the “c” key is pressed.

```cshtml
<SfComboBox TValue="string" TItem="Country" @onkeypress="@(e => KeyPressed(e))" DataSource="@Countries">
    <ComboBoxFieldSettings Text="Name" Value="Code"></ComboBoxFieldSettings>
</SfComboBox>

@code {
    public void KeyPressed(KeyboardEventArgs args)
    {
        if (args.Key == "c")
        {
            Console.WriteLine("C was pressed");
        }
    }
    public class Country
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }
    List<Country> Countries = new List<Country>
    {
        new Country() { Name = "Australia", Code = "AU" },
        new Country() { Name = "Bermuda", Code = "BM" },
        new Country() { Name = "Canada", Code = "CA" },
        new Country() { Name = "Cameroon", Code = "CM" },
        new Country() { Name = "Denmark", Code = "DK" },
        new Country() { Name = "France", Code = "FR" },
    };
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VNrKshBGqFwXkbUb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

Using Lambda expression also, you can pass the event data to the event handler.

## List of native events supported

| List of Native events |  |  | |
| --- | --- | --- | --- |
| onclick | onblur | onfocus | onfocusout |
| onmousemove | onmouseover | onmouseout | onmousedown | onmouseup |
| ondblclick | onkeydown | oninput | onkeypress |
| ontouchend | onfocusin | onmouseup | ontouchstart |