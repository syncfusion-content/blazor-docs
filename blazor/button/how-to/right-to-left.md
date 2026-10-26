---
layout: post
title: How to enable RTL in Blazor Button | Syncfusion®
description: Enable right-to-left rendering in the Blazor Button by setting EnableRtl to true, which mirrors icon position and content alignment for RTL languages.
platform: Blazor
control: Button
documentation: ug
---

# How to enable RTL in Blazor Button

The Blazor Button component has RTL support. This can be achieved by setting the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_EnableRtl) property to `true`. When RTL is enabled, the icon position and content alignment are mirrored automatically.

The following example illustrates how to enable right-to-left support in the Blazor Button component.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfButton IconCss="e-icons e-setting-icon" EnableRtl="true">Settings</SfButton>

<style>
    .e-setting-icon::before {
        content: '\e880';
    }
</style>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDhHjRWVVquoFAIg?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Right to Left in Blazor Button](./../images/blazor-button-in-right-to-left.webp)" %}

## See also

* [Types and Styles in Blazor Button](../types-and-styles.md)
* [Accessibility in Blazor Button](../accessibility.md)
* [Blazor Button API reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html)