---
layout: post
title: Customization in Blazor Chip Component | Syncfusion
description: Checkout and learn here all about Customization in the Syncfusion Blazor Chip component and much more.
platform: Blazor
control: Chip
documentation: ug
---

# Customization in Blazor Chip Component

This section explains the customization of styles, leading icons, avatar, and trailing icons in Chip control.

## Styles

The Chip control has the following predefined styles that can be defined using the `CssClass` property.

| Class | Description |
| -------- | -------- |
| e-primary | Represents a primary chip. |
| e-success | Represents a positive chip. |
| e-info |  Represents an informative chip. |
| e-warning | Represents a chip with caution. |
| e-danger | Represents a negative chip. |

```cshtml
@using Syncfusion.Blazor.Buttons
<SfChip>
    <ChipItems>
        <ChipItem Text="Default"></ChipItem>
        <ChipItem Text="Primary" CssClass="e-primary"></ChipItem>
        <ChipItem Text="Success" CssClass="e-success"></ChipItem>
        <ChipItem Text="Info" CssClass="e-info"></ChipItem>
        <ChipItem Text="Warning" CssClass="e-warning"></ChipItem>
        <ChipItem Text="Danger" CssClass="e-danger"></ChipItem>
    </ChipItems>
</SfChip>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXLKsrBcBIwnwbXs?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Customizing Blazor Chip Styles](./images/blazor-chip-style.png)

## Leading icon

You can add and customize the leading icon of chip using the `LeadingIconCss` property.

```cshtml
@using Syncfusion.Blazor.Buttons
<SfChip ID="chip-avatar" EnableDelete="true">
    <ChipItems>
        <ChipItem Text="Anne" LeadingIconCss="anne"></ChipItem>
        <ChipItem Text="Janet" LeadingIconCss="janet"></ChipItem>
        <ChipItem Text="Laura" LeadingIconCss="laura"></ChipItem>
        <ChipItem Text="Margaret" LeadingIconCss="margaret"></ChipItem>
    </ChipItems>
</SfChip>

<style>
    #chip-avatar .anne {
        background-image: url('./anne.png')
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjrgirrwBoGkWnCI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Customizing LeadingIcon of Blazor Chip](./images/blazor-chip-leading-icon.gif)

## Avatar

You can add and customize the avatar of chip using the `LeadingIconCss` property.

```csharp

<SfChip EnableDelete="true" CssClass="e-leading-avatar">
    <ChipItems>
        <ChipItem Text="Andrew" LeadingIconCss="andrew"></ChipItem>
        <ChipItem Text="Janet" LeadingIconCss="janet"></ChipItem>
        <ChipItem Text="Laura" LeadingIconCss="laura"></ChipItem>
        <ChipItem Text="Margaret" LeadingIconCss="margaret"></ChipItem>
    </ChipItems>
</SfChip>

<style>
    .chip-avatar .andrew {
        background-image: url('./andrew.png')
    }

    .chip-avatar .margaret {
        background-image: url('./margaret.png')
    }

    .chip-avatar .laura {
        background-image: url('./laura.png')
    }

    .chip-avatar .janet {
        background-image: url('./janet.png')
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNrgCBhQLIvJWaER?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}



## Leading content

You can add and customize the avatar content of chip using the `LeadingText` property.

```cshtml
@using Syncfusion.Blazor.Buttons
<SfChip EnableDelete="true" CssClass="e-leading-avatar">
    <ChipItems>
        <ChipItem Text="Andrew" LeadingText="A"></ChipItem>
        <ChipItem Text="Janet" LeadingText="J"></ChipItem>
        <ChipItem Text="Laura" LeadingText="L"></ChipItem>
        <ChipItem Text="Margaret" LeadingText="M"></ChipItem>
    </ChipItems>
</SfChip>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXrqCLrQrovxnFxf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


![Customizing Avatar Text of Blazor Chip](./images/blazor-chip-avatar-content.gif)

## Trailing icon

You can add and customize the trailing icon of chip using the `TrailingIconCss` property.

```cshtml
@using Syncfusion.Blazor.Buttons
<SfChip>
    <ChipItems>
        <ChipItem Text="Andrew" TrailingIconCss="e-dlt-btn"></ChipItem>
        <ChipItem Text="Janet" TrailingIconCss="e-dlt-btn"></ChipItem>
        <ChipItem Text="Laura" TrailingIconCss="e-dlt-btn"></ChipItem>
        <ChipItem Text="Margaret" TrailingIconCss="e-dlt-btn"></ChipItem>
    </ChipItems>
</SfChip>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZVUiBhwBekjUuOz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


![Customizing Blazor Chip TrailingIcon](./images/blazor-chip-trailing-icon.png)

## Outline chip

Outline chip has the border with the background transparent. It can be set using the `CssClass` property.

```cshtml
@using Syncfusion.Blazor.Buttons
<SfChip EnableDelete="true">
    <ChipItems>
        <ChipItem CssClass="e-outline" Text="Andrew"></ChipItem>
        <ChipItem CssClass="e-outline" Text="Janet"></ChipItem>
        <ChipItem CssClass="e-outline" Text="Laura"></ChipItem>
        <ChipItem CssClass="e-outline" Text="Margaret"></ChipItem>
    </ChipItems>
</SfChip>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VtVgshrQrokgrCJD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}



![Blazor Outline Chip with Transparent Background](./images/blazor-outline-chip-transparent-background.gif)