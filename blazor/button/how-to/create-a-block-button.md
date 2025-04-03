---
layout: post
title: Create a Block Button in Blazor Button Component | Syncfusion
description: Checkout and learn here all about Creating a Block Button in Syncfusion Blazor Button component and more.
platform: Blazor
control: Button
documentation: ug
---

# Create a Block Button in Blazor Button Component

You can customize a Button into a Block Button that will span the entire width of its parent element. To create a Block Button, set the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_CssClass) property to `e-block`.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfButton CssClass="e-block">BLOCKBUTTON</SfButton>
<SfButton CssClass="e-block" IsPrimary="true">BLOCKBUTTON</SfButton>
<SfButton CssClass="e-block e-success">BLOCKBUTTON</SfButton>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDrKWVVBMmGAcBTQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Block Button](./../images/blazor-block-button.png)