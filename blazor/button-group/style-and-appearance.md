---
layout: post
title: Styles and Appearances in Blazor ButtonGroup Component | Syncfusion®
description: Checkout and learn here all features about Styles and Appearances in Blazor ButtonGroup component and more.
platform: Blazor
control: Button Group
documentation: ug
---

# Styles and Appearances in Blazor Button Group Component

The appearance of the Button Group can be modified by overriding the default CSS of the Button Group component. The following table lists the CSS classes that can be overridden and the corresponding element or state they target. A custom theme for the controls can also be created using the [Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=material).

| CSS Class | Purpose of Class |
|-----|-----|
| `.e-btn` | To customize the buttons inside the Button Group. |
| `.e-btn:hover` | To customize the buttons inside the Button Group on hover. |
| `.e-btn:focus` | To customize the buttons inside the Button Group on focus. |
| `.e-btn:active` | To customize the buttons inside the Button Group on active (pressed). |

## Applying custom styles

The following example demonstrates a global stylesheet override that changes the background color of the buttons on hover.

```cshtml

@using Syncfusion.Blazor.SplitButtons

<SfButtonGroup>
    <ButtonGroupButton>View</ButtonGroupButton>
    <ButtonGroupButton>Edit</ButtonGroupButton>
    <ButtonGroupButton>Delete</ButtonGroupButton>
</SfButtonGroup>

<style>
    .e-btn-group .e-btn:hover {
        background-color: #ffaa00;
        color: #ffffff;
    }
</style>
```

## See also

* [Getting Started with Blazor Button Group](getting-started.md)
* [Types and Styles in Blazor Button Group](types-and-styles.md)
