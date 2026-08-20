---
layout: post
title: Style and Appearance in Blazor Button | Syncfusion®
description: Customize the Blazor Button appearance by overriding its default CSS classes or by building a custom theme with the Syncfusion Theme Studio.
platform: Blazor
control: Button
documentation: ug
---

# Style and Appearance in Blazor Button

To modify the Button appearance, you need to override the default CSS of the Button component. The following table lists the available CSS classes and their corresponding section in the Button component. You can also create your own custom theme for the controls using the [Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=material).

| CSS Class | Purpose of Class |
| --- | --- |
| .e-btn | To customize the button. |
| .e-btn:hover | To customize the button on hover. |
| .e-btn:focus | To customize the button on focus. |
| .e-btn:active | To customize the button on active. |
| .e-btn:disabled | To customize the button in the disabled state. |

## Customizing the appearance of button

Use the following CSS to customize the background color of the button while clicking, hovering, and focusing.

```cshtml

@using Syncfusion.Blazor.Buttons

<SfButton>CUSTOM</SfButton>

<style>
    .e-btn {
        background-color: #ff6e40;
    }

    .e-btn:hover {
        background-color: #0b6a0b;
    }

    .e-btn:focus, .e-btn:active {
        background-color: #0078d4;
    }
</style>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/htrdZHCVVKwTFEJD?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Button with Style and Appearance](./images/blazor-button-style-and-appearance.gif)" %}

## See also

* [Types and Styles in Blazor Button](types-and-styles.md)
* [Accessibility in Blazor Button](accessibility.md)
* [Blazor Button API reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html)