---
layout: post
title: Popup Setting in Blazor ListBox | Syncfusion®
description: Configure the Blazor ListBox popup rendering using the AppendTo property to control where the popup appears, ensuring proper display in custom containers.
platform: Blazor
control: ListBox
documentation: ug
---

# Popup Setting in Blazor ListBox

## Render popup in a custom container

Use the `AppendTo` property to render the ListBox popup inside a specific container instead of the default `document.body`. This is useful when the component is placed inside dialogs, side panels, containers with overflow restrictions, or custom stacking contexts.

Specify a valid CSS selector in the `AppendTo` property. When the selector matches an element, the popup is appended to that element. If the selector is null, empty, or no matching element is found, the popup is rendered in the default location.

{% highlight cshtml %}

@using Syncfusion.Blazor.DropDowns

<div id="popupHost">
    <SfListBox TValue="string[]" TItem="GameFields"
               DataSource="@Games"
               AppendTo="@AppendTarget">
        <ListBoxFieldSettings Text="Text" Value="ID"></ListBoxFieldSettings>
    </SfListBox>
</div>

@code {
    private string AppendTarget = "#popupHost";

    public class GameFields
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }

    private List<GameFields> Games = new()
    {
        new() { ID = "Game1", Text = "American Football" },
        new() { ID = "Game2", Text = "Badminton" },
        new() { ID = "Game3", Text = "Basketball" },
        new() { ID = "Game4", Text = "Cricket" }
    };
}

{% endhighlight %}

> The `AppendTo` property accepts a CSS selector such as `#elementId` or `.container`. If the specified element is not found, the popup element will be appended to `document.body`.
