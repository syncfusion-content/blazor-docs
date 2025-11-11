---
layout: post
title: Tooltip for Button in Blazor Button Component | Syncfusion
description: Checkout and learn here all about Tooltip for Button in Syncfusion Blazor Button component and more.
platform: Blazor
control: Button
documentation: ug
---

# Tooltip for Button in Blazor Button Component

Tooltip can be shown on Button hover and it can be achieved by title attribute.

```csharp

@using Syncfusion.Blazor.Buttons

<SfButton Content="@Content" title="Primary Button" IsPrimary="true"></SfButton>

@code {
    public string Content = "Button";
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDVqMVVLsbtDTzCr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Button displays ToolTip](./../images/blazor-button-tooltip.png)" %}
