---
layout: post
title: Styles and Appearances in Blazor AppBar Component | Syncfusion®
description: Check out and learn in detail about Styles and Appearances in Blazor AppBar component and more here.
platform: Blazor
control: AppBar
documentation: ug
---

# Styles and Appearances in Blazor AppBar Component

To modify the AppBar appearance, override the default CSS of the AppBar component. The following table lists the built-in CSS classes and their corresponding sections in the AppBar component. These classes are state modifiers that are applied automatically based on the [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfAppBar.html#Syncfusion_Blazor_Navigations_SfAppBar_Mode) and [ColorMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfAppBar.html#Syncfusion_Blazor_Navigations_SfAppBar_ColorMode) property values, so they can be combined with a custom class to scope overrides. Alternatively, create a custom theme using the [Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=material).

N> Refer to the [Getting Started with Blazor AppBar](https://blazor.syncfusion.com/documentation/appbar/getting-started) page for prerequisites (NuGet packages, theme, and script references) before running the samples in this document.

| CSS Class | Description |
|-----|----- |
| .e-appbar | Applied to the AppBar root element. Customize the base AppBar. |
| .e-appbar.e-regular | Applied when `Mode` is `AppBarMode.Regular` (the default). Customize the regular AppBar. |
| .e-appbar.e-prominent | Applied when `Mode` is `AppBarMode.Prominent`. Customize the prominent AppBar (overrides such as `height` apply here). |
| .e-appbar.e-dense | Applied when `Mode` is `AppBarMode.Dense`. Customize the dense AppBar. |
| .e-appbar.e-light | Applied when `ColorMode` is `AppBarColor.Light` (the default). Customize the light AppBar. |
| .e-appbar.e-dark | Applied when `ColorMode` is `AppBarColor.Dark`. Customize the dark AppBar. |
| .e-appbar.e-primary | Applied when `ColorMode` is `AppBarColor.Primary`. Customize the primary AppBar. |
| .e-appbar.e-inherit | Applied when `ColorMode` is `AppBarColor.Inherit`. Customize the inherit AppBar. |

## CSS Class

The [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfAppBar.html#Syncfusion_Blazor_Navigations_SfAppBar_CssClass) property is used to apply a custom CSS class to the AppBar for further customization. The property accepts a space-separated list of class names. In the example below, the AppBar background and color are customized by combining the `CssClass` property with a custom CSS rule.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<div class="control-container">
    <SfAppBar ColorMode="AppBarColor.Primary" CssClass="custom-appbar">
       <SfButton CssClass="e-inherit" IconCss="e-icons e-home"></SfButton>
    </SfAppBar>
</div>

<style>
    .control-container .e-appbar.custom-appbar {
        background: #ff0000;
        color: #fff;
    }
</style>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjhnDxMCLmTfSmJh?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor AppBar with CssClass customization](./images/cssclass_appbar.webp)" %}

## HTML Attributes

The [HtmlAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfAppBar.html#Syncfusion_Blazor_Navigations_SfAppBar_HtmlAttributes) parameter is used to apply additional inline attributes to the AppBar either directly (as an inline attribute) or by passing a dictionary via the `@attributes` directive. It is a `Dictionary<string, object>` with `CaptureUnmatchedValues = true`, so any attribute not explicitly declared on `SfAppBar` is forwarded to the root element.

The following example sets the `aria-label` of the AppBar by using an inline attribute:

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<div class="control-container">
    <SfAppBar ColorMode="AppBarColor.Primary" aria-label="appbar">
       <SfButton CssClass="e-inherit" IconCss="e-icons e-home"></SfButton>
    </SfAppBar>
</div>
```

The following example achieves the same result by using the `@attributes` directive with a dictionary:

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<div class="control-container">
    <SfAppBar ColorMode="AppBarColor.Primary" HtmlAttributes="CustomAttributes">
       <SfButton CssClass="e-inherit" IconCss="e-icons e-home"></SfButton>
    </SfAppBar>
</div>

@code {
    private Dictionary<string, object> CustomAttributes = new Dictionary<string, object>()
    {
        { "aria-label", "appbar" }
    };
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNhnDdCMrGnUwvdG?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## See Also

* [Getting Started with Blazor AppBar](https://blazor.syncfusion.com/documentation/appbar/getting-started)
* [Positioning in Blazor AppBar](https://blazor.syncfusion.com/documentation/appbar/position)
* [Designing the User Interface in Blazor AppBar](https://blazor.syncfusion.com/documentation/appbar/design)
* [Size and Color in Blazor AppBar](https://blazor.syncfusion.com/documentation/appbar/size-and-color)
* [Accessibility in Blazor AppBar](https://blazor.syncfusion.com/documentation/appbar/accessibility)