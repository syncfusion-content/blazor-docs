---
layout: post
title: How to Create A Block Button in Blazor Button Component | Syncfusion
description: Checkout and learn about Create A Block Button in Blazor Button component of Syncfusion, and more details.
platform: Blazor
control: Button
documentation: ug
---

# Create a Block Button

You can customize a Button into a Block Button that will span the entire width of its parent element. To create a Block Button, set the [`CssClass`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_CssClass)
property to `e-block`.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfButton CssClass="e-block">BLOCKBUTTON</SfButton>
<SfButton CssClass="e-block" IsPrimary="true">BLOCKBUTTON</SfButton>
<SfButton CssClass="e-block e-success">BLOCKBUTTON</SfButton>

```

Output be like

![Button Sample](./../images/button-block.png)