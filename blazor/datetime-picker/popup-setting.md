---
layout: post
title: Popup Settings in Blazor DateTimePicker | Syncfusion®
description: Learn how to use the AppendTo property in Blazor DateTimePicker to control popup placement and ensure correct display in custom containers.
platform: Blazor
control: DateTimePicker
documentation: ug
---

# Popup Settings in Blazor DateTimePicker

## Render popup in a custom container

Use the `AppendTo` property to render the DateTimePicker popup inside a specific container instead of the default `document.body`. This is useful when the component is placed inside dialogs, side panels, containers with overflow restrictions, or custom stacking contexts.

Specify a valid CSS selector in the `AppendTo` property. When the selector matches an element, the popup is appended to that element. If the selector is null, empty, or no matching element is found, the popup is rendered in the default location.

{% highlight cshtml %}

@using Syncfusion.Blazor.Calendars

<div id="popupHost">
    <SfDateTimePicker TValue="DateTime" AppendTo="@AppendTarget"></SfDateTimePicker>
</div>

@code {
    private string AppendTarget = "#popupHost";
}

{% endhighlight %}

> The `AppendTo` property accepts a CSS selector such as `#elementId` or `.container`. If the specified element is not found, the popup element will be appended to `document.body`.
