---
layout: post
title: Styles and Appearances in Blazor ButtonGroup Component | Syncfusion®
description: Learn how to customize the look and feel of the Blazor Button Group component by overriding its default CSS classes or by using the Theme Studio.
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

## Using the Theme Studio

The [Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=material) can be used to create a custom theme that matches the application's branding. After generating the theme:

1. The generated theme file is downloaded from the Theme Studio.
2. The file is placed under `wwwroot/styles/` (or the preferred folder).
3. The theme CSS is referenced in `~/Components/App.razor` (used by Blazor Server, Blazor WebAssembly, and Blazor Web Apps) using a `<link>` tag inside the `<head>`, and the default Syncfusion theme reference is removed or commented.

## See also

* [Getting Started with Blazor Button Group](getting-started.md)
* [Types and Styles in Blazor Button Group](types-and-styles.md)
* [Selection and Nesting in Blazor Button Group](selection-and-nesting.md)
* [Native Events in Blazor Button Group](native-event.md)
* [Accessibility in Blazor Button Group](accessibility.md)
* [Theme Studio for Syncfusion Blazor](https://blazor.syncfusion.com/themestudio/?theme=material)
