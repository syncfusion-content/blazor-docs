---
layout: post
title: Change animation settings in Blazor Dropdown Menu Component | Syncfusion
description: Checkout and learn here all about Customize popup width in in Syncfusion Blazor Dropdown Menu component and more.
platform: Blazor
control: Dropdown Menu
documentation: ug
---

# Change animation settings in Blazor Dropdown Menu Component

To change the animation of the DropDownButton, [`AnimationSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfDropDownButton.html#Syncfusion_Blazor_SplitButtons_SfDropDownButton_AnimationSettings) property is used. The supported effects for DropDownButton are,

| Effect | Functionality |
| ------------ | ----------------------- |
| None | Specifies the Dropdown popup transform with no animation effect. |
| SlideDown | Specifies the Dropdown popup transform with slide down effect. |
| ZoomIn | Specifies the Dropdown popup transform with zoom in effect. |
| FadeIn | Specifies the Dropdown popup transform with fade in effect. |

In this sample, three different buttons are initialized using the DropDownButton component from Syncfusion, each showcasing a unique animation effect for the dropdown menu:

SlideDown Effect: The following sample illustrates how to open DropDownButton with `SlideDown` [`effect`](../../api/drop-down-button/animationSettingsModel/#effect) with the [`duration`](../../api/drop-down-button/animationSettingsModel/#duration) of `800ms`. Also we can set [`easing`](../../api/drop-down-button/animationSettingsModel/#easing) for Dropdown popup.

FadeIn Effect: The following sample illustrates how to open DropDownButton with ,`FadeIn` [`effect`](../../api/drop-down-button/animationSettingsModel/#effect) with the [`duration`](../../api/drop-down-button/animationSettingsModel/#duration) of `800ms`. Also we can set [`easing`](../../api/drop-down-button/animationSettingsModel/#easing) for Dropdown popup.

ZoomIn Effect: The following sample illustrates how to open DropDownButton with ,`ZoomIn` [`effect`](../../api/drop-down-button/animationSettingsModel/#effect) with the [`duration`](../../api/drop-down-button/animationSettingsModel/#duration) of `800ms`. Also we can set [`easing`](../../api/drop-down-button/animationSettingsModel/#easing) for Dropdown popup.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfDropDownButton CssClass="slideDownCss" Content="SlideDownButton" Items="@DropdownItems" 
    AnimationSettings="new AnimationSettings { Effect = AnimationEffect.SlideDown, Duration = 800 }">
</SfDropDownButton>

<SfDropDownButton CssClass="fadeInCss" Content="FadeInButton" Items="@DropdownItems" 
    AnimationSettings="new AnimationSettings { Effect = AnimationEffect.FadeIn, Duration = 800 }">
</SfDropDownButton>

<SfDropDownButton CssClass="zoomInCss" Content="ZoomInButton" Items="@DropdownItems" 
    AnimationSettings="new AnimationSettings { Effect = AnimationEffect.ZoomIn, Duration = 800 }">
</SfDropDownButton>

@code {
    private readonly List<DropDownMenuItem> DropdownItems = new List<DropDownMenuItem>
    {
        new DropDownMenuItem { Text = "Unread" },
        new DropDownMenuItem { Text = "Has Attachments" },
        new DropDownMenuItem { Text = "Categorized" },
        new DropDownMenuItem { Separator = true },  // Specifies a separator
        new DropDownMenuItem { Text = "Important" },
        new DropDownMenuItem { Text = "More Filters" }
    };
}

<style>
    .e-caret {
        transform: rotate(0deg);
        transition: transform 200ms ease-in-out;
    }

    .e-caret-up .e-caret {
        transform: rotate(180deg);
    }
</style>

```



![Changing Caret Icon in Blazor DropDownMenu](./../images/blazor-dropdownmenu-caret-icon.png)