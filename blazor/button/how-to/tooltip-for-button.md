---
layout: post
title: Tooltip for Button in Blazor Button Component | Syncfusion
description: Checkout and learn here all about Tooltip for Button in Syncfusion Blazor Button component and more.
platform: Blazor
control: Button
documentation: ug
---

# Tooltip for Button in Blazor Button Component

Tooltip can be shown on Button hover and it can be achieved by Title HtmlAttributes.

```csharp

@using Syncfusion.Blazor.Buttons

<SfButton Content="@Content" Title="Primary Button" IsPrimary="true"></SfButton>

@code {
    public string Content = "Button";
}

```


![Blazor Button displays ToolTip](./../images/blazor-button-tooltip.png)
