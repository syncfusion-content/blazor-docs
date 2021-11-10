---
layout: post
title: Tooltip for Button in Blazor Button Component | Syncfusion
description: Checkout and learn here all about Tooltip for Button in Syncfusion Blazor Button component and more.
platform: Blazor
control: Button
documentation: ug
---

# Tooltip for Button in Blazor Button Component

Tooltip can be shown on Button hover and it can be achieved by [HtmlAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html) property.

```csharp

@using Syncfusion.Blazor.Buttons

<SfButton Content="@Content" HtmlAttributes="@primButton" IsPrimary="true"></SfButton>

@code {
    public string Content = "Button";
    private Dictionary<string, object> primButton = new Dictionary<string, object>()
    {
        { "title", "Primary Button"}
    };
}

```

Output be like

![Blazor Button displays ToolTip](./../images/blazor-button-tooltip.png)