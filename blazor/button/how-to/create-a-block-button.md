---
layout: post
title: Create a Block Button in Blazor Button Component | Syncfusion®
description: Checkout and learn here all feature about Creating a Block Button in Blazor Button component and much more.
platform: Blazor
control: Button
documentation: ug
---

# Create a Block Button in Blazor Button Component

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