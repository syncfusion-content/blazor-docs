---
layout: post
title: Accessibility in Blazor Chip Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Chip component and much more details.
platform: Blazor
control: Chip
documentation: ug
---

# Accessibility in Blazor Chip Component

## Keyboard interaction

The following shortcut keys are used to access the Chip control without any interruption.

| Keyboard shortcuts | Actions |
|------------|-------------------|
| <kbd>Enter</kbd> | Selects the targeted chip from the Chip/ChipItems. |
| <kbd>Delete</kbd> | Deletes the targeted chip from the Chip/ChipItems. |

```cshtml
@using Syncfusion.Blazor.Buttons
<SfChip ID="chip-avatar" EnableDelete="true" CssClass="e-chip-avatar" Selection="SelectionType.Single">
    <ChipItems>
        <ChipItem Text="Andrew" LeadingIconCss='andrew'></ChipItem>
        <ChipItem Text="Janet" LeadingIconCss='janet'></ChipItem>
        <ChipItem Text="Laura" LeadingIconCss='laura'></ChipItem>
        <ChipItem Text="Margaret" LeadingIconCss='margaret'></ChipItem>
    </ChipItems>
</SfChip>

<style>
    #chip-avatar .andrew {
        background-image: url('./andrew.png')
    }

    #chip-avatar .margaret {
        background-image: url('./margaret.png')
    }

    #chip-avatar .laura {
        background-image: url('./laura.png')
    }

    #chip-avatar .janet {
        background-image: url('./janet.png')
    }
</style>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXBgChrcBRGexhup?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Accessibility in Blazor Chip](./images/blazor-chip-accessibility.gif)