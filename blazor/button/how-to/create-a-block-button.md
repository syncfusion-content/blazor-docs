---
layout: post
title: Create a Block Button in Blazor Button Component | Syncfusion
description: Checkout and learn here all about Creating a Block Button in Syncfusion Blazor Button component and more.
platform: Blazor
control: Button
documentation: ug
---

# Create a Block Button in Blazor Button Component

Create a block button that spans the full width of its parent by setting the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_CssClass) property to `e-block`. The `e-block` class applies a 100% width and block-level layout. It can be combined with visual variants such as `IsPrimary` and `e-success`, as shown below.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfButton CssClass="e-block">BLOCKBUTTON</SfButton>
<SfButton CssClass="e-block" IsPrimary="true">BLOCKBUTTON</SfButton>
<SfButton CssClass="e-block e-success">BLOCKBUTTON</SfButton>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDrKWVVBMmGAcBTQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Button styled as a full-width block button](./../images/blazor-block-button.png)