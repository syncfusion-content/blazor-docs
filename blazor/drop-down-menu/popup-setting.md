---
layout: post
title: Popup Setting in Blazor DropDown Button | Syncfusion®
description: Configure the Blazor DropDown Button popup rendering using the AppendTo property to control where the popup appears, ensuring proper display in custom containers.
platform: Blazor
control: DropDown Button
documentation: ug
---

# Popup Setting in Blazor DropDown Button

## Render popup in a custom container

Use the `AppendTo` property to render the DropDown Button popup inside a specific container instead of the default `document.body`. This is useful when the component is placed inside dialogs, side panels, containers with overflow restrictions, or custom stacking contexts.

Specify a valid CSS selector in the `AppendTo` property. When the selector matches an element, the popup is appended to that element. If the selector is null, empty, or no matching element is found, the popup is rendered in the default location.

{% highlight cshtml %}

@using Syncfusion.Blazor.SplitButtons

<div id="popupHost">
    <SfDropDownButton Items="@Items" AppendTo="@AppendTarget"></SfDropDownButton>
</div>

@code {
    private string AppendTarget = "#popupHost";
    List<ItemModel> Items = new List<ItemModel>
    {
        new ItemModel { Text = "Save" },
        new ItemModel { Text = "Open" },
        new ItemModel { Text = "Exit" }
    };
}

{% endhighlight %}

> The `AppendTo` property accepts a CSS selector such as `#elementId` or `.container`. If the specified element is not found, the popup element will be appended to `document.body`.
