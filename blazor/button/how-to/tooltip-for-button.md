---
layout: post
title: Tooltip for Button in Blazor Button Component | Syncfusion
description: Checkout and learn here all about Tooltip for Button in Syncfusion Blazor Button component and more.
platform: Blazor
control: Button
documentation: ug
---

# Tooltip for Button in Blazor Button Component

A tooltip can be shown on hover or focus by using the native `title` attribute on the Button. The browser renders this default tooltip without additional scripts or services.

```csharp

@using Syncfusion.Blazor.Buttons

<SfButton Content="@Content" title="Primary Button" IsPrimary="true"></SfButton>

@code {
    public string Content = "Button";
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDVqMVVLsbtDTzCr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Button displaying a tooltip via the title attribute](./../images/blazor-button-tooltip.png)