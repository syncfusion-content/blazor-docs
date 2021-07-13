---
layout: post
title: How to Customize Button Appearance in Blazor Button Component | Syncfusion
description: Checkout and learn about Customize Button Appearance in Blazor Button component of Syncfusion, and more details.
platform: Blazor
control: Button
documentation: ug
---

# Customize Button Appearance

You can customize the appearance of the Button by using the Cascading Style Sheets (CSS). Define the CSS according to your requirement, and assign the class name to the [`CssClass`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_CssClass)
property. In the following code snippet the background color, text color, height, width, and sharp corner of the Button can be customized through the `e-custom` class for all states (hover, focus, and active).

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

Output be like

![Button Sample](./../images/button-custom.png)