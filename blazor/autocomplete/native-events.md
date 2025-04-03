---
layout: post
title: Native Events in Blazor AutoComplete Component | Syncfusion
description: Checkout and learn here all about Native Events in Syncfusion Blazor AutoComplete component and more.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Native Events in Blazor AutoComplete Component

The following section explains the steps to include native events and pass data to event handler in the [AutoComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html) component.

## Bind native events to AutoComplete

You can access any native event by using on `<event>` attribute with a component. The attribute's value is treated as an event handler.

In the following example, the keyPressed method is called every time the key is pressed on input.

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

Also, you can rewrite the above example code as follows using Lambda expressions.

```cshtml
<SfAutoComplete TValue="string" DataSource="@LocalData" @onkeypress="@(() => Console.WriteLine("Key Pressed!"))"></SfAutoComplete>
```

## Pass event data to event handler

Blazor provides set of argument types to map to native events. The list of event types and event arguments are:

* Focus Events - FocusEventArgs
* Mouse Events - MouseEventArgs
* Keyboard Events - KeyboardEventArgs
* Input Events - ChangeEventArgs/EventArgs
* Touch Events – TouchEventArgs
* Pointer Events – PointerEventArgs

In the following example, the on keypress method is called every time any key is pressed inside input. But the message will print when you press "a" key.

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

Using Lambda expression also, you can pass the event data to the event handler.

## List of native events supported

| List of Native events |  |  | |
| --- | --- | --- | --- |
| onclick | onblur | onfocus | onfocusout |
| onmousemove | onmouseover | onmouseout | onmousedown | onmouseup |
| ondblclick | onkeydown | onkeyup | onkeypress |
| ontouchend | onfocusin | onmouseup | ontouchstart |