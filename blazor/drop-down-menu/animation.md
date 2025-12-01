---
layout: post
title: Animation in Blazor Dropdown Menu Component | Syncfusion
description: Checkout and learn here all about Customize popup width in in Syncfusion Blazor Dropdown Menu component and more.
platform: Blazor
control: Dropdown Menu
documentation: ug
---

# Animation in Blazor Dropdown Menu Component

To change the animation of the DropDownButton, [`AnimationSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.DropDownMenuAnimationSettings.html)  property is used to customize the animation of the DropDownButton popup. The supported effects for DropDownButton are,

| Effect | Functionality |
| ------------ | ----------------------- |
| None | Opens the dropdown menu with no animation. |
| SlideDown | Opens the dropdown menu with a slide-down effect. |
| ZoomIn | Opens the dropdown menu with a zoom-in effect. |
| FadeIn | Opens the dropdown menu with a fade-in effect. |

In this sample, three different SfDropDownButton instances are rendered, each showcasing a unique animation effect for the dropdown menu.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfDropDownButton CssClass="slideDownCss" Content="SlideDownButton" Items="@DropdownItems">
    <DropDownMenuAnimationSettings Effect="@SlideDownEffect" Duration="@Duration" Easing="@Easing"></DropDownMenuAnimationSettings>
</SfDropDownButton>

<SfDropDownButton CssClass="fadeInCss" Content="FadeInButton" Items="@DropdownItems">
    <DropDownMenuAnimationSettings Effect="@FadeInEffect" Duration="@Duration" Easing="@Easing"></DropDownMenuAnimationSettings>
</SfDropDownButton>

<SfDropDownButton CssClass="zoomInCss" Content="ZoomInButton" Items="@DropdownItems">
    <DropDownMenuAnimationSettings Effect="@ZoomInEffect" Duration="@Duration" Easing="@Easing"></DropDownMenuAnimationSettings>
</SfDropDownButton>

@code {

    private readonly List<DropDownMenuItem> DropdownItems = new()
    {
        new DropDownMenuItem { Text = "Unread" },
        new DropDownMenuItem { Text = "Has Attachments" },
        new DropDownMenuItem { Text = "Categorized" },
        new DropDownMenuItem { Text = "Important" },
        new DropDownMenuItem { Text = "More Filters" },
    };

    // Animation settings for each button
    private Syncfusion.Blazor.SplitButtons.DropDownMenuAnimationEffect SlideDownEffect = Syncfusion.Blazor.SplitButtons.DropDownMenuAnimationEffect.SlideDown;
    private Syncfusion.Blazor.SplitButtons.DropDownMenuAnimationEffect FadeInEffect = Syncfusion.Blazor.SplitButtons.DropDownMenuAnimationEffect.FadeIn;
    private Syncfusion.Blazor.SplitButtons.DropDownMenuAnimationEffect ZoomInEffect = Syncfusion.Blazor.SplitButtons.DropDownMenuAnimationEffect.ZoomIn;

    // Common settings for animation duration and easing
    private int Duration = 800; // Animation duration in milliseconds
    private string Easing = "ease"; // Easing for the animation
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNVTWhizMQTMfCYP?appbar=false&editor=false&result=true&errorlist=true&theme=bootstrap5" backgroundimage "[Changing Blazor DropDownMenu Animation](./images/blazor-dropdownmenu-animation.gif)" %}
