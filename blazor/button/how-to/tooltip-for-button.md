---
layout: post
title: How to add tooltip in Blazor Button | Syncfusion®
description: Show a tooltip on Blazor Button hover by using the native HTML title attribute, or by binding a custom element and toggling a tooltip component.
platform: Blazor
control: Button
documentation: ug
---

# How to add tooltip in Blazor Button

A tooltip can be shown on Button hover by using the native HTML `title` attribute. This provides a quick, browser-native tooltip with no additional setup.

```csharp

@using Syncfusion.Blazor.Buttons

<SfButton Content="@Content" title="Primary Button" IsPrimary="true"></SfButton>

@code {
    public string Content = "Button";
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZVxNRiBhzZOVWOZ?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Button displays ToolTip](./../images/blazor-button-tooltip.webp)" %}

> For richer tooltips with custom content, open/close events, and multiple positions, use the [SfTooltip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfTooltip.html) component and target the Button.

## See also

* [Native Events in Blazor Button](../native-event.md)
* [Types and Styles in Blazor Button](../types-and-styles.md)
* [Blazor Button API reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html)
