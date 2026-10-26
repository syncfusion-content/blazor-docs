---
layout: post
title: Style and Appearance in Blazor Button Group | Syncfusion®
description: Customize the Blazor Button Group appearance by overriding its default CSS classes or by building a custom theme with the Syncfusion Theme Studio.
platform: Blazor
control: Button Group
documentation: ug
---

# Style and Appearance in Blazor Button Group

The appearance of the Blazor Button Group can be modified by overriding the default CSS of the Blazor Button Group component. The following table lists the CSS classes that can be overridden and the corresponding element or state they target. A custom theme for the controls can also be created using the [Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=material).

| CSS Class | Purpose of Class |
|-----|-----|
| `.e-btn` | To customize the buttons inside the Blazor Button Group. |
| `.e-btn:hover` | To customize the buttons inside the Blazor Button Group on hover. |
| `.e-btn:focus` | To customize the buttons inside the Blazor Button Group on focus. |
| `.e-btn:active` | To customize the buttons inside the Blazor Button Group on active (pressed). |

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
