---
layout: post
title: Popup Settings in Blazor DatePicker | Syncfusion®
description: Configure the Blazor DatePicker popup rendering using the AppendTo property to control where the popup appears, ensuring proper display in custom containers.
platform: Blazor
control: DatePicker
documentation: ug
---

# Popup Settings in Blazor DatePicker

## Render popup in a custom container

Use the `AppendTo` property to render the DatePicker popup inside a specific container instead of the default `document.body`. This is useful when the component is placed inside dialogs, side panels, containers with overflow restrictions, or custom stacking contexts.

Specify a valid CSS selector in the `AppendTo` property. When the selector matches an element, the popup is appended to that element. If the selector is null, empty, or no matching element is found, the popup is rendered in the default location.

{% highlight cshtml %}

@using Syncfusion.Blazor.Calendars

<div id="popupHost">
    <SfDatePicker TValue="DateTime?"
                  AppendTo="@AppendTarget"
                  Placeholder="Choose a Date">
    </SfDatePicker>
</div>

@code {
    private string AppendTarget = "#popupHost";
}

{% endhighlight %}

> The `AppendTo` property accepts a CSS selector such as `#elementId` or `.container`. If the specified element is not found, the popup element will be appended to `document.body`.
