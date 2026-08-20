---
layout: post
title: How to create a block button in Blazor Button | Syncfusion®
description: Create a Blazor Button that spans the full width of its parent element by setting the CssClass property to e-block.
platform: Blazor
control: Button
documentation: ug
---

# How to create a block button in Blazor Button

You can customize a Button into a Block Button that spans the entire width of its parent element. To create a Block Button, set the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_CssClass) property to `e-block`.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfButton CssClass="e-block">BLOCKBUTTON</SfButton>
<SfButton CssClass="e-block" IsPrimary="true">BLOCKBUTTON</SfButton>
<SfButton CssClass="e-block e-success">BLOCKBUTTON</SfButton>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZrxDHsrBgmaYJkA?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Block Button](./../images/blazor-block-button.webp)" %}

## See also

* [Types and Styles in Blazor Button](../types-and-styles.md)
* [Set the Disabled State in Blazor Button](set-the-disabled-state.md)
* [Blazor Button API reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html)