---
layout: post
title: Customize Button Appearance in Blazor Button Component | Syncfusion
description: Check out how to customize button appearance in the Syncfusion Blazor Button component using CSS, including background, text color, size, and state styling.
platform: Blazor
control: Button
documentation: ug
---

# Customize Button Appearance in Blazor Button Component

Customize the appearance of the button using Cascading Style Sheets (CSS). Define the required CSS and assign the class name to the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_CssClass) property. In the following example, the background color, text color, height, width, and corner radius are customized via the `e-custom` class, and styles are applied consistently across hover, focus, and active states.

```csharp

@using Syncfusion.Blazor.Buttons

<SfButton CssClass="e-custom">CUSTOM</SfButton>

<style>
    .e-custom {
        border-radius: 0;
        height: 30px;
        width: 80px;
    }

    .e-custom, .e-custom:hover, .e-custom:focus, .e-custom:active {
        background-color: #ff6e40;
        color: #fff;
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZLKMBBBsmGcZMPJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Customizing the appearance of a Blazor Button with CSS](./../images/blazor-button-customization.png)