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

You can access any native event by using on `<event>` attribute with a component. The attribute's value is treated as an event handler.

In the following example, the keyPressed method is called every time the key is pressed on input.

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

Also, you can rewrite the previous code example as follows using Lambda expressions.

```cshtml
<SfComboBox TValue="string" @onkeypress="@(() => Console.WriteLine("Key Pressed!"))"></SfComboBox>
```

## Pass event data to event handler

Blazor provides set of argument types to map to native events. The list of event types and event arguments are:

* Focus Events - FocusEventArgs
* Mouse Events - MouseEventArgs
* Keyboard Events - KeyboardEventArgs
* Input Events - ChangeEventArgs/EventArgs
* Touch Events – TouchEventArgs
* Pointer Events – PointerEventArgs

In the following example, the keyPressed method is called every time any key is pressed inside input. But the message will print when you press "c" key.

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